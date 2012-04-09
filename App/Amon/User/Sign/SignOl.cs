using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace Me.Amon.User.Sign
{
    /// <summary>
    /// 联机注册
    /// </summary>
    public partial class SignOl : UserControl, ISignAc
    {
        private string _Name;
        private string _Mail;
        private string _Pass;
        private string _Root;
        private UserModel _UserModel;
        private DFAccess _Prop;
        private SignAc _SignAc;

        #region 构造函数
        public SignOl()
        {
            InitializeComponent();
        }

        public SignOl(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), IEnv.DIR_DATA);
        }
        #endregion

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
                _SignAc.ShowAlert("请输入【登录用户】！");
                TbName.Focus();
                return;
            }
            if (!CharUtil.IsValidateName(_Name))
            {
                _SignAc.ShowAlert("【登录用户】应在 4 到 32 个字符之间，且仅能为大小写字母、下划线及英文点号！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 用户邮件
            _Mail = TbMail.Text;
            if (string.IsNullOrEmpty(_Mail))
            {
                _SignAc.ShowAlert("请输入【电子邮件】！");
                TbMail.Focus();
                return;
            }
            if (!CharUtil.IsValidateMail(_Mail))
            {
                _SignAc.ShowAlert("请输入一个有效的【电子邮件】！");
                TbMail.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                _SignAc.ShowAlert("请输入【登录口令】！");
                TbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                _SignAc.ShowAlert("【登录口令】不能少于 4 个字符！");
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
                _Root = IEnv.DIR_DATA;
            }
            #endregion

            _SignAc.ShowWaiting();

            #region 本地用户判断
            _Name = _Name.ToLower();
            _Prop = new DFAccess();
            _Prop.Load(IEnv.AMON_SYS);
            string home = _Prop.Get(string.Format(IEnv.AMON_SYS_HOME, _Name));
            if (!string.IsNullOrEmpty(home))
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", _Name));
                TbName.Focus();
                return;
            }
            #endregion

            // 在线注册
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpV_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=rsa&m=0");
        }

        public void DoCancel()
        {
            _SignAc.ShowView(ESignAc.SignIn);
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion

        #region 事件处理
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
            TbPath.Text = path;
        }
        #endregion

        #region 私有函数
        private void SignUpV_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            string t = null;
            string d = null;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
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
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpS_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sup&t=" + t + "&d=" + d);
        }

        private void SignUpS_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                string code = null;
                if (reader.Name == "Code" || reader.ReadToFollowing("Code"))
                {
                    code = reader.ReadElementContentAsString();
                }
                if (!CharUtil.IsValidateCode(code))
                {
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("注册用户失败，请稍后重试！");
                    return;
                }
                _Root = Path.Combine(_Root, code);
                if (Directory.Exists(_Root))
                {
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert(string.Format("指定路径下已存在名为 {0} 的目录！", code));
                    return;
                }
                Directory.CreateDirectory(_Root);

                if (!_UserModel.WsSignIn(_Root, code, _Name, _Pass, reader))
                {
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("注册用户失败，请稍后重试！");
                    TbName.Focus();
                }
                else
                {
                    DFAccess prop = new DFAccess();
                    prop.Load(IEnv.AMON_SYS);
                    prop.Set(string.Format(IEnv.AMON_SYS_CODE, _Name), _UserModel.Code);
                    prop.Set(string.Format(IEnv.AMON_SYS_HOME, _Name), _UserModel.Home);
                    prop.Save(IEnv.AMON_SYS);

                    InitDat();
                }
            }

            _Pass = null;
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

            byte[] b = Encoding.UTF8.GetBytes(_Name + '\n' + _Mail + '\n' + _Pass);
            b = rsa.ProcessBlock(b, 0, b.Length);
            return HttpUtil.ToBase64String(b);
        }

        private void InitDat()
        {
            _UserModel.Init();

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitCat_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=cat&c=" + _UserModel.Code);
        }

        private void InitCat_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Cat cat = new Cat();
                cat.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Cat"))
                {
                    if (!cat.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(cat);
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitLib_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=lib&c=" + _UserModel.Code);
        }

        private void InitLib_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Lib header = new Lib();
                header.Order = 0;
                header.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Lib"))
                {
                    if (!header.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(header);
                    header.Order += 1;
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitUdc_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=udc&c=" + _UserModel.Code);
        }

        private void InitUdc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Udc udc = new Udc();
                udc.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Udc"))
                {
                    if (!udc.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(udc);
                }
            }

            BeanUtil.UnZip("Amon.dat", _UserModel.Home);
            _SignAc.CallBack(IEnv.IAPP_APWD);
        }
        #endregion
    }
}
