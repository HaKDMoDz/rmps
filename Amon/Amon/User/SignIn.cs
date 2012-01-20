using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User
{
    public partial class SignIn : Form
    {
        private string _Name;
        private string _Pass;
        private UserModel _UserModel;
        private Uc.Properties _Prop;

        #region 构造函数
        public SignIn()
        {
            InitializeComponent();
        }

        public SignIn(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        public AmonHandler<int> CallBackHandler { get; set; }

        #region 事件处理
        private void BtOk_Click(object sender, EventArgs e)
        {
            DoSignIn();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有方法
        private void DoSignIn()
        {
            _Name = TbName.Text;

            #region 用户名判断
            if (string.IsNullOrEmpty(_Name))
            {
                ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 3)
            {
                ShowAlert("用户名不能少于3个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{3,}$"))
            {
                ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (_Pass.Length < 3)
            {
                ShowAlert("登录口令不能少于3个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            // 口令散列
            _Pass = _UserModel.Digest(_Name, _Pass);

            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_CFG);

            string code = _Prop.Get(string.Format("amon.{0}.code", _Name));
            if (!CharUtil.IsValidateCode(code))
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignIn_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sin&n=" + _Name + "&k=" + _Pass);
                return;
            }

            if (_Pass != _Prop.Get(string.Format("amon.{0}.info", _Name)))
            {
                ShowAlert("身份验证错误，请确认您输入的用户及口令是否正确！");
                return;
            }

            string data = _Prop.Get(string.Format("amon.{0}.data", _Name));

            string t = _Prop.Get(string.Format("amon.{0}.view", _Name));
            int view = CharUtil.IsValidateLong(t) ? int.Parse(t) : IEnv.IAPP_NONE;

            LoadUser(_Name, code, "", data, view);
        }

        private void SignIn_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowAlert(e.Error.Message);
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
                    ShowAlert(reader.ReadElementContentAsString());
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

            _Prop.Set(string.Format("amon.{0}.code", _Name), code);
            _Prop.Set(string.Format("amon.{0}.info", _Name), _Pass);
            _Prop.Set(string.Format("amon.{0}.data", _Name), data);
            _Prop.Set(string.Format("amon.{0}.view", _Name), view.ToString());
            _Prop.Save(IEnv.AMON_CFG);

            LoadUser(_Name, code, "", data, view);
        }

        private void LoadUser(string name, string code, string pass, string data, int view)
        {
            if (!_UserModel.SignIn(_Name, code, pass, data))
            {
                ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbName.Focus();
                return;
            }
            _UserModel.Init();

            if (CallBackHandler != null)
            {
                CallBackHandler.Invoke(view);
            }
            Close();
        }

        private void ShowAlert(string alert)
        {
            MessageBox.Show(this, alert, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }
    }
}
