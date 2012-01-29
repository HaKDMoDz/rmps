using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.User.Sign;

namespace Me.Amon.User
{
    /// <summary>
    /// 权限认证
    /// </summary>
    public partial class SignAc : Form
    {
        private bool _Waiting;
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
            _SignIn = new SignIn(this, _UserModel);
            _SignIn.Location = new Point(12, 46);
            _SignIn.TabIndex = 1;
            Controls.Add(_SignIn);
            _SignAc = _SignIn;
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
        }
        #endregion

        #region 公共函数
        public void ShowAlert(string alert)
        {
            MessageBox.Show(this, alert, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWaiting(string message)
        {
            _Waiting = true;

            //LbInfo.Text = message;
            BtOk.Enabled = false;
            BtNo.Enabled = false;
        }

        public void HideWaiting(string message)
        {
            BtNo.Enabled = true;
            BtOk.Enabled = true;
            //LbInfo.Text = message;

            _Waiting = false;
        }

        public void ShowView(ESignAc signAc)
        {
            switch (signAc)
            {
                case ESignAc.SignIn:
                    ShowSignIn();
                    break;
                case ESignAc.SignOn:
                    ShowSignOn();
                    break;
                case ESignAc.SignOf:
                    ShowSignOf();
                    break;
                case ESignAc.SignPc:
                    ShowSignPc();
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

        private SignUp _SignUp;
        private void ShowSignOn()
        {
            if (_SignUp == null)
            {
                _SignUp = new SignUp(this, _UserModel);
            }
            _SignUp.IsOnLine = true;
            ShowView(_SignUp);
            _SignAc = _SignUp;
        }

        private void ShowSignOf()
        {
            if (_SignUp == null)
            {
                _SignUp = new SignUp(this, _UserModel);
            }
            _SignUp.IsOnLine = false;
            ShowView(_SignUp);
            _SignAc = _SignUp;
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

        private void ShowView(Control control)
        {
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
