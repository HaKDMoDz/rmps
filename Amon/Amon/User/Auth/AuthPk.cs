using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.User.Auth
{
    /// <summary>
    /// 登录口令
    /// </summary>
    public partial class AuthPk : UserControl, IAuthAc
    {
        private AuthAc _AuthAc;
        private UserModel _UserModel;

        #region 构造函数
        public AuthPk()
        {
            InitializeComponent();
        }

        public AuthPk(AuthAc authAc, UserModel userModel)
        {
            _AuthAc = authAc;
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
            string oldPass = TbOldPass.Text;
            if (string.IsNullOrEmpty(oldPass))
            {
                _AuthAc.ShowAlert("请输入已有口令！");
                TbOldPass.Focus();
                return;
            }
            TbOldPass.Text = "";

            string newPass = TbNewPass1.Text;
            if (string.IsNullOrEmpty(newPass))
            {
                _AuthAc.ShowAlert("请输入登录口令！");
                TbNewPass1.Focus();
                return;
            }

            if (newPass.Length < 4)
            {
                _AuthAc.ShowAlert("登录口令不能少于4个字符！");
                TbNewPass1.Text = "";
                TbNewPass2.Text = "";
                TbNewPass1.Focus();
                return;
            }

            if (newPass != TbNewPass2.Text)
            {
                TbNewPass2.Text = "";
                _AuthAc.ShowAlert("您两次输入的口令不一致！");
                TbNewPass1.Focus();
                return;
            }
            TbNewPass1.Text = "";
            TbNewPass2.Text = "";

            if (!_UserModel.CaSignPk(oldPass, newPass))
            {
                oldPass = null;
                newPass = null;
                _AuthAc.ShowAlert("登录口令修改失败，请重试！");
                TbOldPass.Focus();
                return;
            }

            _AuthAc.Close();
        }

        public void DoCancel()
        {
            _AuthAc.Close();
        }
        #endregion
    }
}
