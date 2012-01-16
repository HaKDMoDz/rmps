using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Pwd;
using Me.Amon.Util;

namespace Me.Amon.User
{
    public partial class SignIn : Form
    {
        private string _Name;
        private string _Pass;
        private string _Code;
        private Uc.Properties _Prop;

        #region 构造函数
        public SignIn()
        {
            InitializeComponent();
        }
        #endregion

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

        private void ShowAlert(string alert)
        {
        }

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
            if (string.IsNullOrEmpty(_Pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (_Pass.Length < 3)
            {
                ShowAlert("登录口令不能少于3个字符！");
                TbPass.Text = "";
                TbPass.Focus();
                return;
            }
            #endregion

            // 口令散列
            _Pass = SafeUtil.EncryptPass(_Pass);

            _Prop = new Uc.Properties();
            _Prop.Load("amon.cfg");

            _Code = _Prop.Get(string.Format("amon.{0}.code", _Name));
            if (!CharUtil.IsValidateCode(_Code))
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignIn_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sin&n=" + _Name + "&k=" + _Pass);
                return;
            }

            _Pass = _Prop.Get(string.Format("amon.{0}.info", _Name));
            LoadUser();
        }

        private void SignIn_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            string xml = e.Result;
            int view = 0;
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
                _Code = reader.ReadElementContentAsString();

                _Pass = reader.ReadElementContentAsString();

                view = reader.ReadElementContentAsInt();
            }

            _Prop.Set(string.Format("amon.{0}.code", _Name), _Code);
            _Prop.Set(string.Format("amon.{0}.info", _Name), _Pass);
            _Prop.Set(string.Format("amon.{0}.view", _Name), view.ToString());
            _Prop.Save("amon.cfg");

            LoadUser();
        }

        private void LoadUser()
        {
            UserModel userModel = new UserModel();
            if (userModel.SignIn(_Name, _Pass, _Code))
            {
                userModel.Init();

                APwd pwd = new APwd(userModel);
                pwd.Init();
                pwd.Show();
                Close();
            }
        }
        #endregion
    }
}
