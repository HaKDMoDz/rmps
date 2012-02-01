using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.User.Sign;
using Me.Amon.Util;

namespace Me.Amon.User
{
    /// <summary>
    /// 权限认证
    /// </summary>
    public partial class SignAc : Form
    {
        private ISignAc _SignAc;
        private UserModel _UserModel;

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
            BtOk.Enabled = false;
            BtNo.Enabled = false;
        }

        public void HideWaiting()
        {
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
            _UserModel.Init();
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

        private SignPc _SignUp;
        private void ShowSignOl()
        {
            if (_SignUp == null)
            {
                _SignUp = new SignPc(this, _UserModel);
            }
            _SignUp.IsPcMode = false;
            ShowView(_SignUp);
            _SignAc = _SignUp;
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

        private void ShowSignPc()
        {
            if (_SignUp == null)
            {
                _SignUp = new SignPc(this, _UserModel);
            }
            _SignUp.IsPcMode = true;
            ShowView(_SignUp);
            _SignAc = _SignUp;
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
            if (_SignAc == null)
            {
                control.Location = new Point(12, 46);
                control.TabIndex = 1;
                Controls.Add(control);
                Height += control.Height;
                BeanUtil.CenterToScreen(this);
                return;
            }

            if (_SignAc.Name == control.Name)
            {
                return;
            }
            Controls.Remove(_SignAc.Control);

            control.Location = new Point(12, 46);
            control.TabIndex = 1;
            Controls.Add(control);
            int step = control.Height - _SignAc.Control.Height;
            Height += step;
            Point p = Location;
            p.Y -= (step >> 1);
            Location = p;
        }
        #endregion
    }
}
