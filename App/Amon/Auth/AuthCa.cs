using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User
{
    /// <summary>
    /// 重新验证
    /// </summary>
    public partial class SignRc : Form
    {
        private UserModel _UserModel;

        #region 构造函数
        public SignRc()
        {
            InitializeComponent();
        }

        public SignRc(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void InitOnce()
        {
            BeanUtil.CenterToScreen(this);
        }
        #endregion

        public AmonHandler<string> CallBackHandler { get; set; }

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
            #region 用户判断
            string name = TbName.Text;
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
            name = name.ToLower();
            #endregion

            #region 口令判断
            string pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                ShowAlert("请输入解屏口令！");
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

            if (!_UserModel.CaSignRc(name, pass))
            {
                ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbName.Focus();
                return;
            }

            if (CallBackHandler != null)
            {
                CallBackHandler(EApp.IAPP_NONE);
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
