using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace Me.Amon.User.Auth
{
    /// <summary>
    /// 登录口令
    /// </summary>
    public partial class AuthOl : UserControl, IAuthAc
    {
        private AuthAc _AuthAc;
        private UserModel _UserModel;
        private string _OldPass;
        private string _NewPass;

        #region 构造函数
        public AuthOl()
        {
            InitializeComponent();
        }

        public AuthOl(AuthAc authAc, UserModel userModel)
        {
            _AuthAc = authAc;
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoAuthAc()
        {
            #region 已有口令
            _OldPass = TbOldPass.Text;
            if (string.IsNullOrEmpty(_OldPass))
            {
                _AuthAc.ShowAlert("请输入已有口令！");
                TbOldPass.Focus();
                return;
            }
            TbOldPass.Text = "";
            #endregion

            #region 新口令
            _NewPass = TbNewPass1.Text;
            if (string.IsNullOrEmpty(_NewPass))
            {
                _AuthAc.ShowAlert("请输入登录口令！");
                TbNewPass1.Focus();
                return;
            }

            if (_NewPass.Length < 4)
            {
                _AuthAc.ShowAlert("登录口令不能少于4个字符！");
                TbNewPass1.Text = "";
                TbNewPass2.Text = "";
                TbNewPass1.Focus();
                return;
            }

            if (_NewPass != TbNewPass2.Text)
            {
                TbNewPass2.Text = "";
                _AuthAc.ShowAlert("您两次输入的口令不一致！");
                TbNewPass1.Focus();
                return;
            }
            TbNewPass1.Text = "";
            TbNewPass2.Text = "";
            #endregion

            // 在线注册
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpV_UploadStringCompleted);
            client.UploadStringAsync(new Uri(EApp.SERVER_PATH), "POST", "&o=rsa&m=0");
        }

        public void DoCancel()
        {
            _AuthAc.Close();
        }

        public void ShowMenu(Control control, int x, int y)
        {
            CmMenu.Show(control, x, y);
        }
        #endregion

        private void SignUpV_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _AuthAc.HideWaiting();
                _AuthAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            string t = null;
            string d = null;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _AuthAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _AuthAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (reader.Name == "t" || reader.ReadToFollowing("t"))
                {
                    t = reader.ReadElementContentAsString();
                }

                if (reader.Name == "k" || reader.ReadToFollowing("k"))
                {
                    d = reader.ReadElementContentAsString();
                }
            }

            switch (EApp.SERVER_TYPE)
            {
                case "NET":
                    d = Net(d);
                    break;
                case "PHP":
                    d = Php(d);
                    break;
                default:
                    break;
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpS_UploadStringCompleted);
            client.UploadStringAsync(new Uri(EApp.SERVER_PATH), "POST", "c=" + _UserModel.Code + "&o=spk&t=" + t + "&d=" + d);
        }

        private void SignUpS_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _AuthAc.HideWaiting();
                _AuthAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _AuthAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _AuthAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (!_UserModel.WsSignPk(_OldPass, _NewPass, reader))
                {
                    _AuthAc.HideWaiting();
                    _AuthAc.ShowAlert("注册用户失败，请稍后重试！");
                    TbOldPass.Focus();
                }
            }
        }

        private string Net(string t)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(t);

            byte[] b = Encoding.UTF8.GetBytes(_UserModel.Code + '\n' + _OldPass + '\n' + _NewPass);
            b = rsa.Encrypt(b, false);
            return HttpUtil.ToBase64String(b);
        }

        private string Php(string t)
        {
            AsymmetricKeyParameter keyPair;
            using (StringReader sr = new StringReader(t))
            {
                PemReader pr = new PemReader(sr);
                keyPair = (AsymmetricKeyParameter)pr.ReadObject();
            }

            IAsymmetricBlockCipher rsa = new Pkcs1Encoding(new RsaEngine());
            rsa.Init(true, keyPair);

            byte[] b = Encoding.UTF8.GetBytes(_UserModel.Code + '\n' + _OldPass + '\n' + _NewPass);
            b = rsa.ProcessBlock(b, 0, b.Length);
            return HttpUtil.ToBase64String(b);
        }

        #region 事件处理
        private void MiAuthUl_Click(object sender, EventArgs e)
        {
            _AuthAc.ShowView(EAuthAc.AuthUl);
        }

        private void MiAuthPc_Click(object sender, EventArgs e)
        {
            _AuthAc.ShowView(EAuthAc.AuthPc);
        }
        #endregion
    }
}
