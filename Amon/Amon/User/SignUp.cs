using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Event;
using Me.Amon.Model;

namespace Me.Amon.User
{
    public partial class SignUp : Form
    {
        private string _Name;
        private string _Pass;
        private string _Root;
        private UserModel _UserModel;
        private Uc.Properties _Prop;

        #region 构造函数
        public SignUp()
        {
            InitializeComponent();
        }

        public SignUp(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            _Root = IEnv.DATA_DIR + Path.DirectorySeparatorChar;
        }
        #endregion

        public AmonHandler<int> CallBackHandler { get; set; }

        #region 事件处理
        private void BtOk_Click(object sender, System.EventArgs e)
        {
            DoSignUp();
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }
        #endregion

        #region 私有函数
        private void DoSignUp()
        {
            _Name = TbName.Text;

            #region 用户名判断
            if (string.IsNullOrEmpty(_Name))
            {
                ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 5)
            {
                ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{5,}$"))
            {
                ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                ShowAlert("登录口令不能少于4个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            string pass = TbPass2.Text;
            TbPass2.Text = "";
            if (_Pass != pass)
            {
                ShowAlert("您两次输入的口令不一致！");
                TbPass1.Focus();
                return;
            }
            #endregion

            _Name = _Name.ToLower();
            pass = null;

            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_CFG);
            string root = _Prop.Get(string.Format("amon.{0}.root", _Name));
            if (!string.IsNullOrEmpty(root))
            {
                ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", _Name));
                return;
            }

            string info = _UserModel.Digest(_Name, _Pass);

            // 在线注册
            if (MiLocal.Checked)
            {
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUp_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sup&n=" + _Name + "&k=" + info);
                return;
            }

            // 本地注册
            bool ok = _UserModel.SignUp(_Root, _Name, _Pass, info);
            _Prop = null;

            if (!ok)
            {
                ShowAlert("系统异常，请稍后重试！");
                return;
            }

            LoadUser(0);
        }

        private void SignUp_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            string code = null;
            string info = null;
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

                reader.ReadToFollowing("code");
                code = reader.ReadElementContentAsString();

                info = reader.ReadElementContentAsString();

                data = reader.ReadElementContentAsString();

                view = reader.ReadElementContentAsInt();
            }

            _UserModel.SignNw(_Root, code, _Name, info, data);
            _Pass = null;

            LoadUser(view);
        }

        private void LoadUser(int view)
        {
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

        private void MiLocal_Click(object sender, EventArgs e)
        {
            MiLocal.Checked = !MiLocal.Checked;
        }
    }
}
