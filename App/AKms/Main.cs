using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Api.Enums;
using Me.Amon.Api.User32;
using Me.Amon.Kms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Robot;
using Me.Amon.Kms.Target;
using Me.Amon.Kms.Target.App;
using Me.Amon.Kms.Target.Img;
using Me.Amon.Kms.Target.Kms;
using Me.Amon.Kms.Target.Man;
using Me.Amon.Kms.Target.Net;
using Me.Amon.Kms.Target.Scb;
using Me.Amon.Kms.V.Cfg;
using Me.Amon.Properties;
using Me.Amon.Util;
using Me.Amon.Uw;

namespace Me.Amon
{
    public partial class Main : Form
    {
        private UserModel _UserModel;

        #region 全局变量
        private static Alert _Alert;
        private static Error _Error;
        private static Input _Input;
        private static Waiting _Waiting;

        private readonly IRobot _Robot;

        private ManWindow _ManTarget;
        //private AppTarget _AppTarget;
        //private ScbTarget _ScbTarget;

        /// <summary>
        /// 方案管理菜单
        /// </summary>
        private ToolStripMenuItem _EditSolutionItem;
        /// <summary>
        /// 当前选择菜单
        /// </summary>
        private ToolStripMenuItem _LastSolutionItem;
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public Main()
        {
            InitializeComponent();

            ShowView(Settings.Default.TrayIcon);

            _Robot = new KmsRobot(_UserModel.DataModel);
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
            RegHotKey();
        }

        private void AKms_FormClosing(object sender, FormClosingEventArgs e)
        {
            DelHotKey();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_HOTKEY)
            {
                int t = m.WParam.ToInt32();
                if (t == DO_WORK)
                {
                    DoWork();
                }
                else if (t == DO_HALT)
                {
                    DoHalt();
                }
                else if (t == DO_NEXT)
                {
                    DoNext();
                }
                else if (t == DO_STOP)
                {
                    DoStop();
                }
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
            var handler = new EventHandler(MiTarget_Click);
            var item = new ToolStripMenuItem { Name = "人", Text = "人" };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            item = new ToolStripMenuItem { Name = "程序", Text = "程序" };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            item = new ToolStripMenuItem { Name = "剪贴板", Text = "剪贴板" };
            item.Click += handler;
            MuTarget.DropDownItems.Add(item);

            //item = new ToolStripMenuItem { Name = "", Text = "" };
            //item.Click += handler;
            //MuTarget.DropDownItems.Add(item);
        }

        private void LoadMenu()
        {
            if (_EditSolutionItem == null)
            {
                _EditSolutionItem = new ToolStripMenuItem();
                _EditSolutionItem.Click += SlnEdit_Click;
                _EditSolutionItem.Name = "0";
                //_slnItem.Size = new System.Drawing.Size(152, 22);
                _EditSolutionItem.Text = "管理(&M)";
            }
            MuSolution.DropDownItems.Add(_EditSolutionItem);

            List<MSolution> list = _UserModel.DataModel.ListSolution();
            if (list.Count > 0)
            {
                //ToolStripSeparator MiSol0 = new ToolStripSeparator();
                //MiSol0.Name = "MiSol0";
                //MiSol0.Size = new System.Drawing.Size(149, 6);
                MuSolution.DropDownItems.Add(new ToolStripSeparator());
            }

            ToolStripMenuItem item;
            string hash = _UserModel.Solution != null ? _UserModel.Solution.Id : "";
            var handler = new EventHandler(SlnItem_Click);
            foreach (MSolution sol in list)
            {
                item = new ToolStripMenuItem();
                item.Click += handler;
                if (hash == sol.Id)
                {
                    item.Checked = true;
                    _LastSolutionItem = item;
                }
                item.Name = sol.Id;
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
            if (_UserModel.Solution == null)
            {
                MessageBox.Show(this, "请先选择一个会话方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_ManTarget == null)
            {
                _ManTarget = new ManWindow(this, _UserModel.DataModel);
            }
            _ManTarget.Start();
        }
        #endregion

        #region 全局函数
        public static DialogResult ShowConfirm(string message)
        {
            Form window = null;
            return MessageBox.Show(window, message, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static void ShowAlert(IWin32Window owner, string alert)
        {
            if (_Alert == null)
            {
                _Alert = new Alert(Me.Amon.Properties.Resources.Icon);
            }
            _Alert.Show(owner, alert);
        }

        public static void ShowError(IWin32Window owner, Exception error)
        {
            if (_Error == null)
            {
                _Error = new Error(Me.Amon.Properties.Resources.Icon);
            }
            _Error.Show(owner, error);
        }

        public static string ShowInput(IWin32Window owner, string message, string deftext)
        {
            if (_Input == null)
            {
                _Input = new Input(Me.Amon.Properties.Resources.Icon);
            }
            _Input.Show(owner, message, deftext);
            return _Input.DialogResult == DialogResult.OK ? _Input.Message : null;
        }

        public static void ShowWaiting(IWin32Window owner, string message)
        {
            if (_Waiting == null)
            {
                _Waiting = new Waiting();
            }
            _Waiting.Show(owner, message);
        }
        #endregion

        #region 文件打开对话框
        private static OpenFileDialog _FdOpen;
        public static OpenFileDialog OpenFileDialog
        {
            get
            {
                if (_FdOpen == null)
                {
                    _FdOpen = new OpenFileDialog();
                }
                return _FdOpen;
            }
        }

        public static DialogResult ShowOpenFileDialog(string filter, string file, bool multi)
        {
            OpenFileDialog.Filter = filter;
            OpenFileDialog.FileName = file;
            OpenFileDialog.Multiselect = multi;
            return OpenFileDialog.ShowDialog();
        }

        public static DialogResult ShowOpenFileDialog(IWin32Window owner, string filter, string file, bool multi)
        {
            OpenFileDialog.Filter = filter;
            OpenFileDialog.FileName = file;
            OpenFileDialog.Multiselect = multi;
            return OpenFileDialog.ShowDialog(owner);
        }
        #endregion

        #region 文件保存对话框
        private static SaveFileDialog _FdSave;
        public static SaveFileDialog SaveFileDialog
        {
            get
            {
                if (_FdSave == null)
                {
                    _FdSave = new SaveFileDialog();
                }
                return _FdSave;
            }
        }

        public static DialogResult ShowSaveFileDialog(string filter, string file)
        {
            SaveFileDialog.Filter = filter;
            SaveFileDialog.FileName = file;
            return SaveFileDialog.ShowDialog();
        }

        public static DialogResult ShowSaveFileDialog(IWin32Window owner, string filter, string file)
        {
            SaveFileDialog.Filter = filter;
            SaveFileDialog.FileName = file;
            return SaveFileDialog.ShowDialog(owner);
        }
        #endregion

        #region 日志记录
        private static StreamWriter _Writer;
        public static void LogInfo(string msg)
        {
            if (_Writer != null)
            {
                _Writer.WriteLine(msg);
                _Writer.Flush();
            }
        }
        #endregion

        #region 快捷键
        private int DO_WORK;
        private int DO_HALT;
        private int DO_NEXT;
        private int DO_STOP;
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

        private void RegHotKey()
        {
            if (_UserModel.Solution == null)
            {
                return;
            }

            if (DO_WORK < 1)
            {
                DO_WORK = Handle.ToInt32() + 1;
                DO_HALT = DO_WORK + 1;
                DO_NEXT = DO_HALT + 1;
                DO_STOP = DO_NEXT + 1;
            }

            RegHotKey(DO_WORK, _UserModel.Solution.WorkKey);
            RegHotKey(DO_HALT, _UserModel.Solution.HaltKey);
            RegHotKey(DO_NEXT, _UserModel.Solution.NextKey);
            RegHotKey(DO_STOP, _UserModel.Solution.StopKey);
        }

        private void DelHotKey()
        {
            if (_UserModel.Solution == null)
            {
                return;
            }
            User32API.UnregisterHotKey(Handle, DO_WORK);
            User32API.UnregisterHotKey(Handle, DO_HALT);
            User32API.UnregisterHotKey(Handle, DO_NEXT);
            User32API.UnregisterHotKey(Handle, DO_STOP);
        }
        #endregion

        #region 机器人控制
        private void DoWork()
        {
            if (_Robot.Running)
            {
                return;
            }

            if (_UserModel.Solution == null)
            {
                ShowAlert(null, "请选择会话方案！");
                return;
            }

            ITarget target = GetTarget(_UserModel.Solution.Target);
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

            if (_UserModel.Solution == null)
            {
                ShowAlert(null, "请选择会话方案！");
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

            if (_UserModel.Solution == null)
            {
                ShowAlert(null, "请选择会话方案！");
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

            if (_UserModel.Solution == null)
            {
                ShowAlert(null, "请选择会话方案！");
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
            new AKms(this, _UserModel, _UserModel.DataModel).ShowDialog();
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

            if (_LastSolutionItem != null)
            {
                _LastSolutionItem.Checked = false;
            }
            DelHotKey();

            DelHotKey();
            _UserModel.ReloadData(hash);
            RegHotKey();

            _LastSolutionItem = item;
            _LastSolutionItem.Checked = true;
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
            _Robot.Method = _UserModel.Solution.Method;

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

        private ITarget GetTarget(ETarget target)
        {
            switch (target)
            {
                case ETarget.Man:
                    return new ManTarget();
                case ETarget.App:
                    return new AppTarget(_UserModel);
                case ETarget.Scb:
                    return new ScbTarget();
                case ETarget.Net:
                    return new NetTarget();
                case ETarget.Kms:
                    return new KmsTarget();
                case ETarget.Img:
                    return new ImgTarget();
                default:
                    return null;
            }
        }
    }
}
