using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Util;
using System.Text;

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

            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_SYS);

            _Name = _Name.ToLower();
            string code = _Prop.Get(string.Format(IEnv.AMON_SYS_CODE, _Name));
            _Home = _Prop.Get(string.Format(IEnv.AMON_SYS_HOME, _Name));

            #region 已有用户首次登录
            if (!CharUtil.IsValidateCode(code))
            {
                _Waiting = true;
                _SignAc.ShowWaiting();

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
                _SignAc.ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbName.Focus();
            }
            else
            {
                _SignAc.CallBack(0);
            }

            _Pass = null;
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
                _SignAc.ShowAlert(e.Error.Message);
                _SignAc.HideWaiting();
                _Waiting = false;
                return;
            }

            string xml = e.Result;

            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (!_UserModel.WsSignIn(_Home, _Name, _Pass, reader))
                {
                    _SignAc.ShowAlert("注册用户失败，请稍后重试！");
                    TbName.Focus();
                }
                else
                {
                    Uc.Properties prop = new Uc.Properties();
                    prop.Load(IEnv.AMON_SYS);
                    prop.Set(string.Format(IEnv.AMON_SYS_HOME, _Name), _UserModel.Home);
                    prop.Set(string.Format(IEnv.AMON_SYS_CODE, _Name), _UserModel.Code);
                    prop.Save(IEnv.AMON_SYS);

                    _SignAc.CallBack(IEnv.IAPP_APWD);
                }
            }

            _Pass = null;
        }
        #endregion
    }
}
