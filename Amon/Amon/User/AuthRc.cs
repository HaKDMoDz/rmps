using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;

namespace Me.Amon.User
{
    /// <summary>
    /// 重新认证
    /// </summary>
    public partial class AuthRc : Form
    {
        private UserModel _UserModel;
        private int _ErrorCnt;

        #region 构造函数
        public AuthRc()
        {
            InitializeComponent();
        }

        public AuthRc(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
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
            pass = "";
            if (string.IsNullOrEmpty(pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass.Focus();
                return;
            }

            if (!_UserModel.SignAc(pass))
            {
                ShowAlert("口令输入错误！");
                TbPass.Focus();
                _ErrorCnt += 1;
                return;
            }

            Close();
        }

        private void AuthAc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void ShowAlert(string alert)
        {
            //LbInfo.Text = alert;
        }
    }
}
