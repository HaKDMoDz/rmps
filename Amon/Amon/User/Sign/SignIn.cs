using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User.Sign
{
    public partial class SignIn : UserControl, ISignAc
    {
        private string _Name;
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
                _SignAc.ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 3)
            {
                _SignAc.ShowAlert("用户名不能少于3个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{3,}$"))
            {
                _SignAc.ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            string pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                _SignAc.ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (pass.Length < 3)
            {
                _SignAc.ShowAlert("登录口令不能少于3个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_CFG);

            _Name = _Name.ToLower();
            _Info = _UserModel.Digest(_Name, pass);
            string code = _Prop.Get(string.Format("amon.{0}.code", _Name));

            #region 已有用户首次登录
            if (!CharUtil.IsValidateCode(code))
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignIn_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sin&n=" + _Name + "&k=" + _Info);
                return;
            }
            #endregion

            #region 已有用户正常登录
            if (!_UserModel.SignIn(_Home, code, _Name, pass, _Info))
            {
                pass = null;
                _SignAc.ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbName.Focus();
                return;
            }

            pass = null;
            _SignAc.CallBack(0);
            #endregion
        }

        public void DoCancel()
        {
            _SignAc.Close();
        }
        #endregion

        private void BtPath_Click(object sender, EventArgs e)
        {

        }

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
        }

        /// <summary>
        /// 联机注册(&R)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOnSignUp_Click(object sender, EventArgs e)
        {
            //ShowSignOn();
        }

        /// <summary>
        /// 脱机注册(&N)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOfSignUp_Click(object sender, EventArgs e)
        {
            //ShowSignOf();
        }

        /// <summary>
        /// 单机注册(&P)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiPcSignUp_Click(object sender, EventArgs e)
        {
            //ShowSignPc();
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
                return;
            }

            string xml = e.Result;
            string code = null;
            string data = null;
            int view = IEnv.IAPP_NONE;
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
                    return;
                }
                code = reader.ReadElementContentAsString();

                data = reader.ReadElementContentAsString();

                view = reader.ReadElementContentAsInt();
            }

            _UserModel.SignNw(_Home, code, _Info, data);

            _SignAc.CallBack(view);
        }
        #endregion

    }
}
