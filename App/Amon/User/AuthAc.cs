using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.User.Auth;
using Me.Amon.Util;

namespace Me.Amon.User
{
    /// <summary>
    /// 口令修改
    /// </summary>
    public partial class AuthAc : Form
    {
        private UserModel _UserModel;
        private IAuthAc _AuthAc;

        #region 构造函数
        public AuthAc()
        {
            InitializeComponent();
        }

        public AuthAc(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void InitOnce()
        {
        }
        #endregion

        #region 公共函数
        public void ShowView(EAuthAc authAc)
        {
            switch (authAc)
            {
                case EAuthAc.AuthPk:
                    ShowAuthPk();
                    break;
                case EAuthAc.AuthSk:
                    ShowAuthSk();
                    break;
            }
        }

        public void ShowAlert(string alert)
        {
            MessageBox.Show(this, alert, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 私有函数
        private AuthPk _AuthPk;
        private void ShowAuthPk()
        {
            if (_AuthPk == null)
            {
                _AuthPk = new AuthPk();
            }
            ShowView(_AuthPk);
            _AuthAc = _AuthPk;
        }

        private void ShowAuthFk()
        {
        }

        private AuthSk _AuthSk;
        private void ShowAuthSk()
        {
            if (_AuthSk == null)
            {
                _AuthSk = new AuthSk();
            }
            ShowView(_AuthSk);
            _AuthAc = _AuthSk;
        }

        private void ShowView(Control control)
        {
            int step;
            if (_AuthAc == null)
            {
                step = 0;
                BeanUtil.CenterToScreen(this);
            }
            else
            {
                if (_AuthAc.Name == control.Name)
                {
                    return;
                }

                step = _AuthAc.Control.Height;
                Controls.Remove(_AuthAc.Control);
            }

            control.Location = new Point(12, 50);
            control.TabIndex = 1;
            Controls.Add(control);

            step -= control.Height;
            Height -= step;
            Point p = Location;
            p.Y += (step >> 1);
            Location = p;
        }
        #endregion
    }
}
