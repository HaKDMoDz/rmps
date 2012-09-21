using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Api.Enums;
using Me.Amon.Api.User32;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Robot;
using Me.Amon.Kms.Target;
using Me.Amon.Kms.V.Cfg;
using Me.Amon.Kms.V.Sln;
using Me.Amon.Properties;
using Me.Amon.Util;

namespace Me.Amon.Kms
{
    public partial class AKms : Form
    {
        private UserModel _UserModel;

        #region 全局变量
        private MSolution _solution;
        private readonly IRobot _Robot;

        //private ManTarget _manTarget;
        //private AppTarget _appTarget;
        //private ScbTarget _scbTarget;

        private Training.Training _training;

        /// <summary>
        /// 用户配置
        /// </summary>
        private static Uc.Properties _Configure;
        /// <summary>
        /// 方案管理菜单
        /// </summary>
        private ToolStripMenuItem _solutionEdit;
        /// <summary>
        /// 当前选择菜单
        /// </summary>
        private ToolStripMenuItem _solutionLast;
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public AKms()
        {
            InitializeComponent();

            ShowView(Settings.Default.TrayIcon);

            _Robot = new KmsRobot();
            _Robot.TrayPtn = this;
            _LastMethod = MiMethod;
            _LastTarget = MiTarget;
        }

        #region 事件处理
        private void AKms_Load(object sender, EventArgs e)
        {
            Point loc = Settings.Default.WinLoc;
            if (loc.X < 0 || loc.Y < 0)
            {
                loc.X = Screen.PrimaryScreen.WorkingArea.Width - 160;
                loc.Y = 80;
            }
            Location = loc;

            _UserModel = new UserModel();
            _UserModel.Init();
            _UserModel.Load();

            InitData();
            LoadMenu();
            SetHotKey();
        }

        private void AKms_FormClosing(object sender, FormClosingEventArgs e)
        {
            DelHotKey();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_HOTKEY)
            {
                RunHotKey(m.WParam.ToInt32());
            }
            base.WndProc(ref m);
        }

        #region 窗口移动
        private Point _mouseOffset;
        private bool _isLeftDown;
        private bool _isMoving;
        /// <summary>
        /// 窗口移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isLeftDown)
            {
                return;
            }

            var mousePos = MousePosition;
            mousePos.Offset(_mouseOffset);
            Location = mousePos;
            _isMoving = true;
        }

        /// <summary>
        /// 鼠标放松事件，用于窗口最后定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _mouseOffset = new Point(-e.X, -e.Y);
            _isLeftDown = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayPtn_MouseUp(object sender, MouseEventArgs e)
        {
            _isLeftDown = false;
            if (e.Button == MouseButtons.Left && _isMoving)
            {
                _isMoving = false;
                Settings.Default.WinLoc = Location;
                Settings.Default.Save();
            }
        }
        #endregion
        #endregion

        private void InitData()
        {
            ITarget target = ATarget.ManTarget;
            var handler = new EventHandler(MiTarget_Click);
            var item = new ToolStripMenuItem { Name = target.TargetName, Text = target.TargetName };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            target = ATarget.AppTarget;
            item = new ToolStripMenuItem { Name = target.TargetName, Text = target.TargetName };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            target = ATarget.ScbTarget;
            item = new ToolStripMenuItem { Name = target.TargetName, Text = target.TargetName };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            target = ATarget.ImgTarget;
            item = new ToolStripMenuItem { Name = target.TargetName, Text = target.TargetName };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            string solHash = Configure.Get("sln.hash", "");
            if (CharUtil.IsValidateHash(solHash))
            {
                _solution = DataModel.ReadSolution(solHash);
            }
        }

        private void LoadMenu()
        {
            if (_solutionEdit == null)
            {
                _solutionEdit = new ToolStripMenuItem();
                _solutionEdit.Click += SlnEdit_Click;
                _solutionEdit.Name = "0";
                //_slnItem.Size = new System.Drawing.Size(152, 22);
                _solutionEdit.Text = "管理(&M)";
            }
            MuSolution.DropDownItems.Add(_solutionEdit);

            List<MSolution> list = DataModel.ListSolution();
            if (list.Count > 0)
            {
                //ToolStripSeparator MiSol0 = new ToolStripSeparator();
                //MiSol0.Name = "MiSol0";
                //MiSol0.Size = new System.Drawing.Size(149, 6);
                MuSolution.DropDownItems.Add(new ToolStripSeparator());
            }

            ToolStripMenuItem item;
            string hash = _solution != null ? _solution.Hash : "";
            var handler = new EventHandler(SlnItem_Click);
            foreach (MSolution sol in list)
            {
                item = new ToolStripMenuItem();
                item.Click += handler;
                if (hash == sol.Hash)
                {
                    item.Checked = true;
                    _solutionLast = item;
                }
                item.Name = sol.Hash;
                item.Text = sol.Name;
                MuSolution.DropDownItems.Add(item);
            }
        }

        private void ShowView(bool tray)
        {
            Visible = !tray;

            if (tray)
            {
                WindowState = FormWindowState.Minimized;
                MiTray.Text = "显示为罗盘模式(&V)";
            }
            else
            {
                WindowState = FormWindowState.Normal;
                MiTray.Text = "显示为托盘模式(&V)";
                ClientSize = new Size(24, 24);
            }

            NiTray.Visible = tray;
        }

        private void ShowTalk()
        {
            if (_solution == null)
            {
                MessageBox.Show(this, "请先选择一个会话方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_training == null)
            {
                _training = new Training.Training(this);
            }
            _training.Start();
        }
        #endregion

        #region 快捷键
        private const int DO_WORK = 1;
        private const int DO_HALT = 2;
        private const int DO_NEXT = 3;
        private const int DO_STOP = 4;
        private void RegHotKey(int key, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            string[] arr = text.Split(' ');
            int j = arr.Length - 1;
            WMHotKeys tmpDat = 0;
            for (int i = 0; i < j; i += 1)
            {
                if ("control" == arr[i].ToLower())
                {
                    tmpDat |= WMHotKeys.Ctrl;
                    continue;
                }
                if ("alt" == arr[i].ToLower())
                {
                    tmpDat |= WMHotKeys.Alt;
                }
                if ("shift" == arr[i].ToLower())
                {
                    tmpDat |= WMHotKeys.Shift;
                }
            }

            var tmpKey = (Keys)Enum.Parse(typeof(Keys), arr[j]);
            User32API.RegisterHotKey(Handle, key, (int)tmpDat, (int)tmpKey);
        }

        private void SetHotKey()
        {
            if (_solution == null)
            {
                return;
            }
            RegHotKey(DO_WORK, _solution.WorkKey);
            RegHotKey(DO_HALT, _solution.HaltKey);
            RegHotKey(DO_NEXT, _solution.NextKey);
            RegHotKey(DO_STOP, _solution.StopKey);
        }

        private void DelHotKey()
        {
            if (_solution == null)
            {
                return;
            }
            User32API.UnregisterHotKey(Handle, DO_WORK);
            User32API.UnregisterHotKey(Handle, DO_HALT);
            User32API.UnregisterHotKey(Handle, DO_NEXT);
            User32API.UnregisterHotKey(Handle, DO_STOP);
        }

        private void RunHotKey(int key)
        {
            switch (key)
            {
                case DO_WORK:
                    DoWork();
                    break;
                case DO_HALT:
                    DoHalt();
                    break;
                case DO_NEXT:
                    DoNext();
                    break;
                case DO_STOP:
                    DoStop();
                    break;
            }
        }
        #endregion

        #region 机器人控制
        private void DoWork()
        {
            if (_Robot.Running)
            {
                return;
            }

            if (_solution == null)
            {
                MessageBox.Show(this, "请选择会话方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ITarget target = ATarget.GetTarget(_solution.Target);
            target.TrayWin = this;

            // 会话对象开始工作
            if (!target.Start())
            {
                return;
            }

            // 机器人开始工作
            _Robot.AppendTarget(target);
            if (!_Robot.Work())
            {
                return;
            }

            SessionStart();
        }

        private void DoHalt()
        {
            if (!_Robot.Running)
            {
                return;
            }

            if (_solution == null)
            {
                MessageBox.Show(this, "请选择会话方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MiWork.Enabled = false;
            MiHalt.Enabled = false;
            MiNext.Enabled = true;
            MiStop.Enabled = true;

            _Robot.Halt();
        }

        private void DoNext()
        {
            if (!_Robot.Running)
            {
                return;
            }

            if (_solution == null)
            {
                MessageBox.Show(this, "请选择会话方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MiWork.Enabled = false;
            MiHalt.Enabled = true;
            MiNext.Enabled = false;
            MiStop.Enabled = true;

            _Robot.Next();
        }

        private void DoStop()
        {
            if (!_Robot.Running)
            {
                return;
            }

            if (_solution == null)
            {
                MessageBox.Show(this, "请选择会话方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SessionClose();

            _Robot.Stop();
        }
        #endregion

        #region 右键菜单事件
        /// <summary>
        /// 管理方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlnEdit_Click(object sender, EventArgs e)
        {
            new EditSln(this).ShowDialog();
        }

        /// <summary>
        /// 选择方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlnItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string hash = item.Name;
            if (!CharUtil.IsValidateHash(hash))
            {
                return;
            }

            MSolution sln = DataModel.ReadSolution(hash);
            if (_solutionLast != null)
            {
                _solutionLast.Checked = false;
            }
            DelHotKey();

            _solution = sln;
            _solutionLast = item;
            _solutionLast.Checked = true;
            SetHotKey();
            Configure.Set("sln.hash", hash);
        }

        #region 会话对象
        private void MiTargetDef_Click(object sender, EventArgs e)
        {
            //_Robot.Target = _solution.Target;
            ChangeTarget(MiTarget);
        }

        private void MiTarget_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            //_Robot.Target = (ETarget)Enum.Parse(typeof(ETarget), item.Name);
            ChangeTarget(item);
        }

        private ToolStripMenuItem _LastTarget;
        private void ChangeTarget(ToolStripMenuItem item)
        {
            if (_LastTarget != null)
            {
                _LastTarget.Checked = false;
            }
            _LastTarget = item;
            _LastTarget.Checked = true;
        }
        #endregion

        #region 会话控制
        private void MiWork_Click(object sender, EventArgs e)
        {
            DoWork();
        }

        private void MiHalt_Click(object sender, EventArgs e)
        {
            DoHalt();
        }

        private void MiNext_Click(object sender, EventArgs e)
        {
            DoNext();
        }

        private void MiStop_Click(object sender, EventArgs e)
        {
            DoStop();
        }
        #endregion

        #region 会话方式
        private void MiMethod_Click(object sender, EventArgs e)
        {
            _Robot.Method = _solution.Method;

            ChangeMethod(MiMethod);
        }

        private void MiAnswer_Click(object sender, EventArgs e)
        {
            _Robot.Method = EMethod.Answer;

            ChangeMethod(MiAnswer);
        }

        private void MiActive_Click(object sender, EventArgs e)
        {
            _Robot.Method = EMethod.Active;

            ChangeMethod(MiActive);
        }

        private void MiAttack_Click(object sender, EventArgs e)
        {
            _Robot.Method = EMethod.Attack;

            ChangeMethod(MiAttack);
        }

        private ToolStripMenuItem _LastMethod;
        private void ChangeMethod(ToolStripMenuItem item)
        {
            if (_LastMethod != null)
            {
                _LastMethod.Checked = false;
            }
            _LastMethod = item;
            _LastMethod.Checked = true;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiAction_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 对话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiTalk_Click(object sender, EventArgs e)
        {
            ShowTalk();
        }

        /// <summary>
        /// 管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOpts_Click(object sender, EventArgs e)
        {
            new UserCfg().ShowDialog(this);
        }

        /// <summary>
        /// 视图模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiTray_Click(object sender, EventArgs e)
        {
            bool tray = !Settings.Default.TrayIcon;
            ShowView(tray);
            Settings.Default.TrayIcon = tray;
            Settings.Default.Save();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiExit_Click(object sender, EventArgs e)
        {
            Configure.Save(Application.StartupPath + @"\magickms.cfg");
            Application.Exit();
        }
        #endregion

        #region 系统托盘事件
        /// <summary>
        /// 托盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NiTray_DoubleClick(object sender, EventArgs e)
        {
            ShowTalk();
        }
        #endregion

        #region 系统徽标事件
        /// <summary>
        /// 徽标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbLogo_DoubleClick(object sender, EventArgs e)
        {
            ShowTalk();
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 
        /// </summary>
        public MSolution Solution
        {
            get
            {
                return _solution;
            }
        }

        public static Uc.Properties Configure
        {
            get
            {
                if (_Configure == null)
                {
                    _Configure = new Uc.Properties();
                    const string file = "magickms.cfg";
                    if (!File.Exists(file))
                    {
                        File.Create(file).Close();
                    }
                    _Configure.Load(file);
                }
                return _Configure;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReloadData()
        {
            if (_solution != null)
            {
                DelHotKey();
                _solution = DataModel.ReadSolution(_solution.Hash);
                SetHotKey();
            }
        }

        public void ReloadMenu()
        {
            MuSolution.DropDownItems.Clear();

            LoadMenu();
        }

        /// <summary>
        /// 会话开始
        /// </summary>
        public void SessionStart()
        {
            if (InvokeRequired)
            {
                Invoke(new ChangeMenuStatus(SessionStart));
            }
            else
            {
                MuSolution.Enabled = false;
                MuTarget.Enabled = false;
                MuMethod.Enabled = false;

                MiWork.Enabled = false;
                MiHalt.Enabled = true;
                MiNext.Enabled = false;
                MiStop.Enabled = true;
            }
        }

        /// <summary>
        /// 会话结束
        /// </summary>
        public void SessionClose()
        {
            if (InvokeRequired)
            {
                Invoke(new ChangeMenuStatus(SessionClose));
            }
            else
            {
                MuSolution.Enabled = true;
                MuTarget.Enabled = true;
                MuMethod.Enabled = true;

                MiWork.Enabled = true;
                MiHalt.Enabled = false;
                MiNext.Enabled = false;
                MiStop.Enabled = false;
            }
        }

        public delegate void ChangeMenuStatus();
        #endregion
    }
}
