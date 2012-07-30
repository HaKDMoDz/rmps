using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Auth
{
    /// <summary>
    /// 屏幕加锁
    /// </summary>
    public partial class AuthLs : Form
    {
        private UserModel _UserModel;
        private bool _SysAction;
        private int _ErrorCnt;
        private int _DelayTime = 30;
        private int _RightTime;

        #region 构造函数
        public AuthLs()
        {
            InitializeComponent();
        }

        public AuthLs(UserModel userModel, Form owner)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
            BeanUtil.CenterToParent(this, owner);
        }
        #endregion

        public AmonHandler<int> CallBackHandler { get; set; }

        private void BtOk_Click(object sender, EventArgs e)
        {
            string pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (!_UserModel.CaAuthRc(pass))
            {
                _ErrorCnt += 1;
                if (_ErrorCnt < 3)
                {
                    ShowAlert("口令输入错误！");
                    TbPass.Focus();
                    return;
                }

                ShowAlert("您输入的错误次数太多！");
                TbPass.Enabled = false;
                BtOk.Enabled = false;

                _RightTime = _DelayTime;
                _DelayTime <<= 1;
                BgTimer.Start();
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

        private void BgTimer_Tick(object sender, EventArgs e)
        {
            ShowAlert(string.Format("请在 {0} 秒后重试！", _RightTime--));

            if (_RightTime > 0)
            {
                return;
            }

            BgTimer.Stop();
            _ErrorCnt = 0;
            TbPass.Enabled = true;
            BtOk.Enabled = true;
            ShowAlert("请重新尝试输入解锁口令！");
            TbPass.Focus();
        }
    }
}
