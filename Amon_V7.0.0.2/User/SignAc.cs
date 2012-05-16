using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Properties;
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

        public AmonHandler<int> CallBackHandler { get; set; }

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

        #region 事件处理
        #region 界面事件
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
            if (BtOk.Enabled)
            {
                CmMenu.Show(PbMenu, 0, PbMenu.Height);
            }
        }
        #endregion

        #region 选单事件
        /// <summary>
        /// 打开(&O)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            string home = fd.SelectedPath;
            if (!Directory.Exists(home))
            {
                ShowAlert("您选择的路径不存在！");
                return;
            }

            string path = Path.Combine(home, IEnv.AMON_CFG);
            if (!File.Exists(path))
            {
                ShowAlert("请确认您选择的数据路径是否正确！");
                return;
            }
            DFAccess prop = new DFAccess();
            prop.Load(path);
            string name = prop.Get(IEnv.AMON_CFG_NAME);
            string code = prop.Get(IEnv.AMON_CFG_CODE);
            if (!CharUtil.IsValidateCode(code) || !CharUtil.IsValidate(name))
            {
                ShowAlert("请确认您选择的数据路径是否正确！");
                return;
            }

            prop.Clear();
            prop.Load(IEnv.AMON_SYS);
            prop.Set(string.Format(IEnv.AMON_SYS_CODE, name), code);
            prop.Set(string.Format(IEnv.AMON_SYS_HOME, name), home);
            prop.Save(IEnv.AMON_SYS);
        }

        /// <summary>
        /// 联机注册(&R)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOnSignUp_Click(object sender, EventArgs e)
        {
            ShowSignOl();
        }

        /// <summary>
        /// 脱机注册(&N)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOfSignUp_Click(object sender, EventArgs e)
        {
            ShowSignUl();
        }

        /// <summary>
        /// 单机注册(&P)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiPcSignUp_Click(object sender, EventArgs e)
        {
            ShowSignPc();
        }

        /// <summary>
        /// 忘记口令(&F)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void MiSignFk_Click(object sender, EventArgs e)
        {
            ShowSignFk();
        }

        /// <summary>
        /// 升级(&U)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiUpgrade_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #endregion

        #region 公共函数
        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
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

            if (_SignAc != null)
            {
                _SignAc.Focus();
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

            MiOpen.Visible = true;
            MiSep0.Visible = true;
            MiPcSignUp.Visible = true;
            MiSignFk.Visible = true;
            MiSep1.Visible = true;
            MiUpgrade.Visible = true;
            MiSep2.Visible = true;

            Text = "用户登录";
            BtOk.Text = "登录(&O)";
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

            MiOpen.Visible = false;
            MiSep0.Visible = false;
            MiSignFk.Visible = false;
            MiSep1.Visible = false;
            MiUpgrade.Visible = false;
            MiSep2.Visible = false;

            Text = "联机注册";
            BtOk.Text = "注册(&O)";
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

            MiOpen.Visible = false;
            MiSep0.Visible = false;
            MiSignFk.Visible = false;
            MiSep1.Visible = false;
            MiUpgrade.Visible = false;
            MiSep2.Visible = false;

            Text = "脱机注册";
            BtOk.Text = "注册(&O)";
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

            MiOpen.Visible = false;
            MiSep0.Visible = false;
            MiPcSignUp.Visible = false;
            MiSignFk.Visible = false;
            MiSep1.Visible = false;
            MiUpgrade.Visible = false;
            MiSep2.Visible = false;

            Text = "单机注册";
            BtOk.Text = "注册(&O)";
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

            Text = "找回口令";
            BtOk.Text = "找回(&O)";
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

            step -= control.Height;
            Height -= step;
            Point p = Location;
            p.Y += (step >> 1);
            Location = p;
        }
        #endregion
    }
}
