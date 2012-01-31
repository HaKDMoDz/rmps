using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace Me.Amon.User.Sign
{
    /// <summary>
    /// 联机/单机注册
    /// </summary>
    public partial class SignUp : UserControl, ISignAc
    {
        private string _Name;
        private string _Mail;
        private string _Pass;
        private string _Root;
        private UserModel _UserModel;
        private Uc.Properties _Prop;
        private SignAc _SignAc;

        public SignUp()
        {
            InitializeComponent();
        }

        public SignUp(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = IEnv.DATA_DIR + Path.DirectorySeparatorChar;
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
            #region 用户判断
            _Name = TbName.Text;
            if (string.IsNullOrEmpty(_Name))
            {
                _SignAc.ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 5)
            {
                _SignAc.ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{5,}$"))
            {
                _SignAc.ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }

            _Name = _Name.ToLower();
            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_SYS);
            string home = _Prop.Get(string.Format(IEnv.AMON_SYS_HOME, _Name));
            if (!string.IsNullOrEmpty(home))
            {
                _SignAc.ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", _Name));
                return;
            }
            #endregion

            #region 用户邮件
            _Mail = "a@b.c";
            #endregion

            #region 口令判断
            _Pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                _SignAc.ShowAlert("请输入登录口令！");
                TbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                _SignAc.ShowAlert("登录口令不能少于4个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            if (_Pass != TbPass2.Text)
            {
                TbPass2.Text = "";
                _SignAc.ShowAlert("您两次输入的口令不一致！");
                TbPass1.Focus();
                return;
            }
            TbPass2.Text = "";
            #endregion

            #region 路径判断
            _Root = TbPath.Text;
            if (string.IsNullOrEmpty(_Root))
            {
                _Root = IEnv.DATA_DIR + Path.DirectorySeparatorChar;
            }
            if (!Directory.Exists(_Root))
            {
                try
                {
                    Directory.CreateDirectory(_Root);
                }
                catch (Exception exp)
                {
                    _SignAc.ShowAlert(exp.Message);
                    TbPath.Text = IEnv.DATA_DIR;
                    return;
                }
            }
            if (_Root[_Root.Length - 1] != (Path.DirectorySeparatorChar))
            {
                _Root += Path.DirectorySeparatorChar;
            }
            #endregion

            // 在线注册
            if (!IsPcMode)
            {
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpV_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=rsa&m=0");
                return;
            }

            // 本地注册
            if (!_UserModel.SignUp(_Root, _Name, _Pass))
            {
                _Pass = null;
                _SignAc.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            _Prop.Set(string.Format(IEnv.AMON_SYS_CODE, _Name), _UserModel.Code);
            _Prop.Set(string.Format(IEnv.AMON_SYS_HOME, _Name), _Root + _UserModel.Code + Path.DirectorySeparatorChar);
            _Prop.Save(IEnv.AMON_SYS);

            _SignAc.CallBack(0);
        }

        public void DoCancel()
        {
            _SignAc.ShowView(ESignAc.SignIn);
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion

        public bool IsPcMode { get; set; }

        private void BtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = TbPath.Text;
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }
            string path = fd.SelectedPath;
            if (string.IsNullOrEmpty(path))
            {
                _SignAc.ShowAlert("请选择数据存放目录！");
                BtPath.Focus();
                return;
            }
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception exp)
                {
                    _SignAc.ShowAlert(exp.Message);
                    BtPath.Focus();
                    return;
                }
            }
            if (path[path.Length - 1] != Path.DirectorySeparatorChar)
            {
                path += Path.DirectorySeparatorChar;
            }
            TbPath.Text = path;
        }

        #region 私有函数
        private void SignUpV_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            string t = null;
            string d = null;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    reader.ReadToFollowing("error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
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

            switch (IEnv.SERVER_TYPE)
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
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpS_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sup&m=" + t + "&d=" + d);
        }

        private void SignUpS_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            string code;
            string info;
            string data;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    reader.ReadToFollowing("error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (!reader.ReadToFollowing("code"))
                {
                    _SignAc.ShowAlert("服务器返回异常，请稍后再试！");
                    return;
                }
                code = reader.ReadElementContentAsString();

                info = reader.ReadElementContentAsString();

                data = reader.ReadElementContentAsString();
            }

            _UserModel.SignNw(_Root, code, _Name, info, data);
            _Pass = null;

            _SignAc.CallBack(0);
        }

        private string Net(string t)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(t);

            byte[] b = Encoding.UTF8.GetBytes(_Name + '\n' + _Mail + '\n' + _Pass);
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

            byte[] b = Encoding.UTF8.GetBytes(_Pass);
            b = rsa.ProcessBlock(b, 0, b.Length);
            return HttpUtil.ToBase64String(b);
        }
        #endregion
    }
}
