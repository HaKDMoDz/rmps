using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Auth.Uc;
using Me.Amon.M;
using Me.Amon.Properties;
using Me.Amon.Util;

namespace Me.Amon.Auth
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

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void InitOnce()
        {
            BeanUtil.CenterToScreen(this);
        }
        #endregion

        #region 公共函数
        public void ShowView(EAuthAc authAc)
        {
            switch (authAc)
            {
                case EAuthAc.AuthOl:
                    ShowAuthOl();
                    break;
                case EAuthAc.AuthUl:
                    ShowAuthUl();
                    break;
                case EAuthAc.AuthPc:
                    ShowAuthPc();
                    break;
                case EAuthAc.AuthSk:
                    ShowAuthSk();
                    break;
                case EAuthAc.AuthLk:
                    ShowAuthLk();
                    break;
            }
        }

        public void ShowAlert(string alert)
        {
            MessageBox.Show(this, alert, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWaiting()
        {
            PbMenu.Image = Resources.Loading;
            BtOk.Enabled = false;
            BtNo.Enabled = false;
        }

        public void HideWaiting()
        {
            PbMenu.Image = Resources.Menu;
            BtNo.Enabled = true;
            BtOk.Enabled = true;
        }
        #endregion

        #region 私有函数
        private AuthOl _AuthPk;
        private void ShowAuthOl()
        {
            if (_AuthPk == null)
            {
                _AuthPk = new AuthOl(this, _UserModel);
            }
            ShowView(_AuthPk);
            _AuthAc = _AuthPk;

            Text = "修改登录口令（联机）";
            BtOk.Text = "确定(&O)";
        }

        private AuthUl _AuthUl;
        private void ShowAuthUl()
        {
            if (_AuthUl == null)
            {
                _AuthUl = new AuthUl(this, _UserModel);
            }
            ShowView(_AuthUl);
            _AuthAc = _AuthUl;

            Text = "修改登录口令（脱机）";
            BtOk.Text = "确定(&O)";
        }

        private AuthPc _AuthPc;
        private void ShowAuthPc()
        {
            if (_AuthPc == null)
            {
                _AuthPc = new AuthPc(this, _UserModel);
            }
            ShowView(_AuthPc);
            _AuthAc = _AuthPc;

            Text = "修改登录口令（单机）";
            BtOk.Text = "确定(&O)";
        }

        private AuthSk _AuthSk;
        private void ShowAuthSk()
        {
            if (_AuthSk == null)
            {
                _AuthSk = new AuthSk(this, _UserModel);
            }
            ShowView(_AuthSk);
            _AuthAc = _AuthSk;

            Text = "设置安全口令";
            BtOk.Text = "确定(&O)";
        }

        private AuthLk _AuthLk;
        private void ShowAuthLk()
        {
            if (_AuthLk == null)
            {
                _AuthLk = new AuthLk(this, _UserModel);
            }
            ShowView(_AuthLk);
            _AuthAc = _AuthLk;

            Text = "修改解屏口令";
            BtOk.Text = "确定(&O)";
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

        #region 事件处理
        private void BtOk_Click(object sender, System.EventArgs e)
        {
            _AuthAc.DoAuthAc();
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            _AuthAc.DoCancel();
        }

        private void PbMenu_Click(object sender, System.EventArgs e)
        {
            _AuthAc.ShowMenu(PbMenu, 0, PbMenu.Height);
        }
        #endregion
    }
}
