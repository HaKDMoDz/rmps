﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Da.Df;
using Me.Amon.M;
using Me.Amon.User;
using Me.Amon.User.Uc;
using Me.Amon.Util;

namespace Me.Amon.Auth
{
    public partial class SignAc : UserControl
    {
        private Main _Main;
        private ISignAc _SignAc;
        private AUserModel _UserModel;
        private KeyEventHandler _KeyDownHandler;
        private FormClosingEventHandler _ClosingHandler;

        #region 构造函数
        public SignAc()
        {
            InitializeComponent();
        }

        public SignAc(Main main, AUserModel userModel)
        {
            _Main = main;
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitData()
        {
            _Main.AcceptButton = BtOk;
            _Main.CancelButton = BtNo;
            _Main.FormBorderStyle = FormBorderStyle.FixedSingle;
            _Main.MaximizeBox = false;

            if (_ClosingHandler == null)
            {
                _ClosingHandler = new FormClosingEventHandler(Main_FormClosing);
            }
            _Main.FormClosing -= _ClosingHandler;
            if (_KeyDownHandler == null)
            {
                _KeyDownHandler = new KeyEventHandler(Main_KeyDown);
            }
            _Main.KeyDown += _KeyDownHandler;

            ShowSignIn();
        }

        public void DeInit()
        {
            _Main.KeyDown -= _KeyDownHandler;
            _Main.FormClosing -= _ClosingHandler;
        }

        public bool WillExit()
        {
            return true;
        }

        public void Close()
        {
            _Main.Close();
        }
        #endregion

        public void ShowTips(Control control, string caption)
        {
            _Main.ShowTips(control, caption);
        }

        public AmonHandler<string> CallBack;

        public void ShowWaiting()
        {
            PbMenu.Image = Me.Amon.Properties.Resources.Loading;
            BtOk.Enabled = false;
            BtNo.Enabled = false;
        }

        public void HideWaiting()
        {
            PbMenu.Image = Me.Amon.Properties.Resources.Menu;
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

        #region 事件处理
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

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
            OpenFileDialog fdOpen = Main.OpenFileDialog;
            fdOpen.Filter = "阿木密码箱配置文件|*.cfg";
            fdOpen.FileName = CApp.AMON_CFG;
            fdOpen.InitialDirectory = _UserModel.SysHome;
            fdOpen.Multiselect = false;
            if (DialogResult.OK != fdOpen.ShowDialog(_Main))
            {
                return;
            }

            string path = fdOpen.FileName;
            if (!File.Exists(path))
            {
                Main.ShowAlert("无法访问您选择的文件！");
                return;
            }

            string file = (Path.GetFileName(path) ?? "").ToLower();
            if (CApp.AMON_CFG.ToLower() != file)
            {
                Main.ShowAlert(string.Format("请确认您选择的文件名是否为：{0}！", CApp.AMON_CFG));
                return;
            }

            DFEngine prop = new DFEngine();
            prop.Load(path);
            string name = prop.Get(CApp.AMON_CFG_NAME);
            string code = prop.Get(CApp.AMON_CFG_CODE);
            if (!CharUtil.IsValidateCode(code) || !CharUtil.IsValidate(name))
            {
                Main.ShowAlert("请确认您选择的数据路径是否正确！");
                return;
            }

            prop.Clear();
            string sysFile = Path.Combine(_UserModel.SysHome, CApp.AMON_SYS);
            prop.Load(sysFile);
            prop.Set(string.Format(CApp.AMON_SYS_CODE, name), code);
            path = Path.GetDirectoryName(path);
            if (path.StartsWith(Application.StartupPath))
            {
                path = path.Substring(Application.StartupPath.Length + 1);
            }
            prop.Set(string.Format(CApp.AMON_SYS_HOME, name), path);
            prop.Save(sysFile);
        }

        /// <summary>
        /// 联机注册(&R)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOnSignUp_Click(object sender, EventArgs e)
        {
            //ShowSignOl();
        }

        /// <summary>
        /// 脱机注册(&N)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOfSignUp_Click(object sender, EventArgs e)
        {
            //ShowSignUl();
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
            //ShowSignFk();
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

            _Main.Width = this.Width;
            step -= control.Height;
            Height -= step;
            _Main.ClientSize = this.Size;
            Point p = _Main.Location;
            p.Y += (step >> 1);
            _Main.Location = p;
        }
        #endregion
    }
}
