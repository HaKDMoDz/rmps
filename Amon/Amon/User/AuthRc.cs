using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User
{
    /// <summary>
    /// 屏幕加锁
    /// </summary>
    public partial class AuthRc : Form
    {
        private UserModel _UserModel;
        private int _ErrorCnt;
        private bool _SysAction;

        #region 构造函数
        public AuthRc()
        {
            InitializeComponent();
        }

        public AuthRc(UserModel userModel, Form owner)
        {
            _UserModel = userModel;

            InitializeComponent();

            BeanUtil.CenterToParent(this, owner);
        }
        #endregion

        public AmonHandler<int> CallBackHandler { get; set; }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (_ErrorCnt > 3)
            {
                ShowAlert("您输入的错误次数太多！");
                return;
            }

            string pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (!_UserModel.CaSignAc(pass))
            {
                _ErrorCnt += 1;
                ShowAlert("口令输入错误！");
                TbPass.Focus();
                return;
            }

            _SysAction = true;
            Close();
        }

        private void AuthRc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_SysAction;
        }

        private void ShowAlert(string alert)
        {
            LbInfo.Text = alert;
        }
    }
}
