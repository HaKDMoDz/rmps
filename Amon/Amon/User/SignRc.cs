using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;

namespace Me.Amon.User
{
    /// <summary>
    /// 口令修改
    /// </summary>
    public partial class SignRc : Form
    {
        private UserModel _UserModel;

        public SignRc()
        {
            InitializeComponent();
        }

        public AmonHandler<int> CallBackHandler { get; set; }

        #region 事件处理
        private void BtOk_Click(object sender, EventArgs e)
        {
            DoSignRc();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有函数
        private void DoSignRc()
        {
            string name = TbName.Text;

            #region 用户名判断
            if (string.IsNullOrEmpty(name))
            {
                ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (name.Length < 3)
            {
                ShowAlert("用户名不能少于3个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(name, "^\\w{3,}$"))
            {
                ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            string pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (pass.Length < 3)
            {
                ShowAlert("登录口令不能少于3个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            pass = _UserModel.Digest(name, pass);

            if (!_UserModel.SignRc(name, pass))
            {
                ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbName.Focus();
                return;
            }
            _UserModel.Init();

            if (CallBackHandler != null)
            {
                CallBackHandler.Invoke(IEnv.IAPP_NONE);
            }
            Close();
        }

        private void ShowAlert(string alert)
        {
            MessageBox.Show(this, alert, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
