using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User.Sign
{
    public partial class SignIn : UserControl, ISignAc
    {
        private bool _Waiting;
        private string _Name;
        private string _Pass;
        private string _Info;
        private string _Home;
        private UserModel _UserModel;
        private Uc.Properties _Prop;
        private SignAc _SignAc;

        public SignIn()
        {
            InitializeComponent();
        }

        public SignIn(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();
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

            #region 口令判断
            _Pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                _SignAc.ShowAlert("请输入【登录口令】！");
                TbPass.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                _SignAc.ShowAlert("【登录口令】不能少于 4 个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            _SignAc.ShowWaiting();

            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_SYS);

            _Name = _Name.ToLower();
            string code = _Prop.Get(string.Format(IEnv.AMON_SYS_CODE, _Name));
            _Home = _Prop.Get(string.Format(IEnv.AMON_SYS_HOME, _Name));

            #region 已有用户首次登录
            if (!CharUtil.IsValidateCode(code))
            {
                _Home = IEnv.DATA_DIR + Path.DirectorySeparatorChar;

                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.Encoding = Encoding.UTF8;
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignIn_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sin&d=" + _Name);
                return;
            }
            #endregion

            #region 已有用户正常登录
            if (!_UserModel.CaSignIn(_Home, code, _Name, _Pass))
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbName.Focus();
                return;
            }

            _UserModel.Init();
            _SignAc.CallBack(0);
            #endregion
        }

        public void DoCancel()
        {
            _SignAc.Close();
        }

        public void ShowMenu(Control control, int x, int y)
        {
            CmMenu.Show(control, x, y);
        }
        #endregion

        #region 菜单事件
        /// <summary>
        /// 打开(&O)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            string path = fd.SelectedPath;
            if (!Directory.Exists(path))
            {
                _SignAc.ShowAlert("您选择的路径不存在！");
                return;
            }
            path += IEnv.AMON_CFG;
            if (!File.Exists(path))
            {
                _SignAc.ShowAlert("请确认您选择的数据路径是否正确！");
                return;
            }
            Uc.Properties prop = new Uc.Properties();
            prop.Load(path);
            string name = prop.Get(IEnv.AMON_CFG_NAME);
            string code = prop.Get(IEnv.AMON_CFG_CODE);
            if (!CharUtil.IsValidateCode(code) || !CharUtil.IsValidate(name))
            {
                _SignAc.ShowAlert("请确认您选择的数据路径是否正确！");
                return;
            }

            prop.Clear();
            prop.Load(IEnv.AMON_SYS);
            prop.Set(string.Format(IEnv.AMON_SYS_CODE, name), code);
            prop.Set(string.Format(IEnv.AMON_SYS_HOME, name), path);
            prop.Save(IEnv.AMON_SYS);
        }

        /// <summary>
        /// 联机注册(&R)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOnSignUp_Click(object sender, EventArgs e)
        {
            _SignAc.ShowView(ESignAc.SignOl);
        }

        /// <summary>
        /// 脱机注册(&N)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOfSignUp_Click(object sender, EventArgs e)
        {
            _SignAc.ShowView(ESignAc.SignUl);
        }

        /// <summary>
        /// 单机注册(&P)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiPcSignUp_Click(object sender, EventArgs e)
        {
            _SignAc.ShowView(ESignAc.SignPc);
        }

        /// <summary>
        /// 忘记口令(&F)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiFind_Click(object sender, EventArgs e)
        {
            _SignAc.ShowView(ESignAc.SignFk);
        }

        /// <summary>
        /// 升级(&U)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiUpgrade_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 私有函数
        private void SignIn_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                _Waiting = false;
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

                if (!_UserModel.WsSignIn(_Home, _Name, _Pass, reader))
                {
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("请确认您输入的登录用户及登录口令是否正确！");
                    TbName.Focus();
                }
                else
                {
                    Uc.Properties prop = new Uc.Properties();
                    prop.Load(IEnv.AMON_SYS);
                    prop.Set(string.Format(IEnv.AMON_SYS_HOME, _Name), _UserModel.Home);
                    prop.Set(string.Format(IEnv.AMON_SYS_CODE, _Name), _UserModel.Code);
                    prop.Save(IEnv.AMON_SYS);

                    InitDat();
                }
            }

            _Pass = null;
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
                    cat.Save(_UserModel.DBAccess, false);
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

                LibHeader header = new LibHeader();
                header.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Libh"))
                {
                    if (!header.FromXml(reader))
                    {
                        continue;
                    }
                    header.Save(_UserModel.DBAccess, false);
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
                    udc.Save(_UserModel.DBAccess, false);
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitKey_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=key&c=" + _UserModel.Code);
        }

        private void InitKey_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
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

                Key key = new Key();
                key.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Key"))
                {
                    if (!key.FromXml(reader))
                    {
                        continue;
                    }
                    key.Save(_UserModel.DBAccess, false);
                }
            }

            _SignAc.CallBack(IEnv.IAPP_APWD);
        }
        #endregion
    }
}
