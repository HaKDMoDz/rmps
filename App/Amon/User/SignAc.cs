using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.User.Sign;
using Me.Amon.Util;
using Me.Amon.Properties;

namespace Me.Amon.User
{
    /// <summary>
    /// 权限认证
    /// </summary>
    public partial class SignAc : Form
    {
        private ISignAc _SignAc;
        private UserModel _UserModel;
        private Uc.Properties _Prop;

        #region 构造函数
        public SignAc()
        {
            InitializeComponent();
        }

        public SignAc(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void InitOnce()
        {
            BeanUtil.CenterToScreen(this);
        }
        #endregion

        public AmonHandler<int> CallBackHandler { get; set; }

        #region 事件处理
        private void BtOk_Click(object sender, EventArgs e)
        {
            _SignAc.DoSignAc();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            _SignAc.DoCancel();
        }
        private void PbMenu_Click(object sender, EventArgs e)
        {
            _SignAc.ShowMenu(PbMenu, 0, PbMenu.Height);
        }
        #endregion

        #region 公共函数
        public void ShowAlert(string alert)
        {
            MessageBox.Show(this, alert, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWaiting()
        {
            PbMenu.Image = Resources.Load;
            BtOk.Enabled = false;
            BtNo.Enabled = false;
        }

        public void HideWaiting()
        {
            PbMenu.Image = Resources.Menu;
            BtNo.Enabled = true;
            BtOk.Enabled = true;
        }

        public void ShowView(ESignAc signAc)
        {
            switch (signAc)
            {
                case ESignAc.SignIn:
                    ShowSignIn();
                    break;
                case ESignAc.SignOl:
                    ShowSignOl();
                    break;
                case ESignAc.SignUl:
                    ShowSignUl();
                    break;
                case ESignAc.SignPc:
                    ShowSignPc();
                    break;
                case ESignAc.SignFk:
                    ShowSignFk();
                    break;
            }
        }

        public void CallBack(int view)
        {
            if (CallBackHandler != null)
            {
                CallBackHandler.Invoke(view);
            }
            Close();
        }
        #endregion

        #region 私有函数
        private SignIn _SignIn;
        private void ShowSignIn()
        {
            if (_SignIn == null)
            {
                _SignIn = new SignIn(this, _UserModel);
            }
            ShowView(_SignIn);
            _SignAc = _SignIn;
        }

        private SignOl _SignOl;
        private void ShowSignOl()
        {
            if (_SignOl == null)
            {
                _SignOl = new SignOl(this, _UserModel);
            }
            ShowView(_SignOl);
            _SignAc = _SignOl;
        }

        private SignUl _SignOf;
        private void ShowSignUl()
        {
            if (_SignOf == null)
            {
                _SignOf = new SignUl(this, _UserModel);
            }
            ShowView(_SignOf);
            _SignAc = _SignOf;
        }

        private SignPc _SignPc;
        private void ShowSignPc()
        {
            if (_SignPc == null)
            {
                _SignPc = new SignPc(this, _UserModel);
            }
            ShowView(_SignPc);
            _SignAc = _SignPc;
        }

        private SignFk _SignFk;
        private void ShowSignFk()
        {
            if (_SignFk == null)
            {
                _SignFk = new SignFk(this, _UserModel);
            }
            ShowView(_SignFk);
            _SignAc = _SignFk;
        }

        private void ShowView(Control control)
        {
            int step;

            if (_SignAc == null)
            {
                step = 0;
                BeanUtil.CenterToScreen(this);
            }
            else
            {
                if (_SignAc.Name == control.Name)
                {
                    return;
                }

                step = _SignAc.Control.Height;
                Controls.Remove(_SignAc.Control);
            }

            control.Location = new Point(12, 50);
            control.TabIndex = 1;
            Controls.Add(control);

            step = control.Height - step;
            Height += step;
            Point p = Location;
            p.Y -= (step >> 1);
            Location = p;
        }
        #endregion
    }
}
