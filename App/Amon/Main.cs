using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Auth;
using Me.Amon.C;
using Me.Amon.M;
using Me.Amon.Properties;
using Me.Amon.User;
using Me.Amon.Util;
using Me.Amon.Uw;
using Me.Amon.V;

namespace Me.Amon
{
    public partial class Main : Form
    {
        #region 全局变量
        private static Alert _Alert;
        private static Error _Error;
        private static Input _Input;
        private static Waiting _Waiting;

        private UserModel _UserModel;
        private IAmon _Amon;
        #endregion

        #region 构造函数
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region 全局函数
        public static DialogResult ShowConfirm(string message)
        {
            Form window = null;
            return MessageBox.Show(window, message, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static void ShowAbout(IWin32Window owner)
        {
            About about = new About();
            about.ShowDialog(owner);
        }

        public static void ShowAlert(string alert)
        {
            Form window = null;
            if (_Alert == null)
            {
                _Alert = new Alert();
            }
            BeanUtil.CenterToParent(_Alert, window);
            _Alert.Show(window, alert);
        }

        public static void ShowError(Exception error)
        {
            Form window = null;
            if (_Error == null)
            {
                _Error = new Error();
            }
            BeanUtil.CenterToParent(_Error, window);
            _Error.Show(window, error);
        }

        public static string ShowInput(string message, string deftext)
        {
            Form window = null;
            if (_Input == null)
            {
                _Input = new Input();
            }
            BeanUtil.CenterToParent(_Input, window);
            _Input.Show(window, message, deftext);
            return _Input.Message;
        }

        public static void ShowWaiting(string message)
        {
            Form window = null;
            if (_Waiting == null)
            {
                _Waiting = new Waiting();
            }
            BeanUtil.CenterToParent(_Waiting, window);
            _Waiting.Show(window, message);
        }

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
        #endregion

        #region 公共函数
        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }
        #endregion

        #region 窗口事件
        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Me.Amon.Properties.Resources.Icon;

            // 系统日志
            if (File.Exists(CApp.FILE_LOG))
            {
                _Writer = new StreamWriter(CApp.FILE_LOG, true, Encoding.UTF8, 8);
                _Writer.AutoFlush = true;
                _Writer.WriteLine(string.Format("============{0}============", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            _UserModel = new UserModel();

            ShowUser();
        }

        private void NiTray_DoubleClick(object sender, EventArgs e)
        {
            if (Visible)
            {
                BringToFront();
                return;
            }

            AuthCa authCa = new AuthCa(_UserModel);
            authCa.CallBackHandler = new AmonHandler<string>(Dd);
            authCa.InitOnce();
            authCa.ShowDialog();
        }

        private void Dd(string key)
        {
            //Show();
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Visible = true;
            BringToFront();
        }
        #endregion

        #region 私有函数

        #region 权限相关
        private AuthCa _SignRc;
        private void SignRc(ESignAc signAc, AmonHandler<string> handler)
        {
            if (_SignRc == null || !_SignRc.Visible)
            {
                _SignRc = new AuthCa(_UserModel);
                _SignRc.InitOnce();
            }
            //_SignRc.CallBack = handler;
            //_SignRc.ShowView(signAc);
            _SignRc.Show();
        }

        public void CheckUser(AmonHandler<string> handler)
        {
            if (!CharUtil.IsValidateCode(_UserModel.Code))
            {
                SignRc(ESignAc.SignIn, handler);
                return;
            }

            if (_SignRc == null || !_SignRc.Visible)
            {
                _SignRc = new AuthCa(_UserModel);
                _SignRc.InitOnce();
                _SignRc.Show();
            }
            _SignRc.CallBackHandler = handler;
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        public void SignOf()
        {
            _UserModel.CaSignOf();

            ShowUser();
        }

        private void DoSignIn(string view)
        {
            ShowAPwd();

            if (Settings.Default.Pattern == CApp.PATTERN_TRAY)
            {
                ShowTray();
            }
            else
            {
                ShowGuid();
            }

            this.Focus();
        }

        private void DoSignOl(string view)
        {
        }
        #endregion

        private SignAc _User;
        private void ShowUser()
        {
            if (_User == null)
            {
                _User = new SignAc(this, _UserModel);
                //_User.Location = new System.Drawing.Point(0, 0);
                _User.Name = "panel1";
                //_User.Size = new System.Drawing.Size(310, 100);
                _User.TabIndex = 0;

                _User.CallBack = new AmonHandler<string>(DoSignIn);
                _User.InitData();

                Controls.Clear();
                Controls.Add(_User);
            }

            _Amon = _User;
            _Amon.LoadView();
        }

        private Pwd.APwd _APwd;
        private void ShowAPwd()
        {
            if (_APwd == null)
            {
                _APwd = new Pwd.APwd(this, _UserModel);
                _APwd.Dock = DockStyle.Fill;
                _APwd.TabIndex = 0;
                _APwd.InitData();

                Controls.Clear();
                Controls.Add(_APwd);
            }

            _Amon = _APwd;
            _Amon.LoadView();
        }

        public void SaveGuid()
        {
        }

        private AGuid _Guid;
        public void ShowGuid()
        {
            if (_Guid == null)
            {
                _Guid = new AGuid(this);
                //_AGuid.Location = new System.Drawing.Point(0, 0);
                //_Guid.Name = "panel1";
                //_AGuid.Size = new System.Drawing.Size(310, 100);

                //_Guid.CallBack = new AmonHandler<string>(ShowDApp);
                _Guid.InitView(_UserModel);
            }
            _Guid.Show();
            //_Guid.ShowDApp(0);
        }

        public void HideGuid()
        {
            if (_Guid != null)
            {
                _Guid.Visible = false;
            }
        }

        private NotifyIcon _Tray;
        public void ShowTray()
        {
            if (_Tray == null)
            {
                _Tray = new NotifyIcon();
                _Tray.BalloonTipTitle = "阿木密码箱";
                _Tray.Icon = Me.Amon.Properties.Resources.Icon;
                _Tray.Text = "阿木密码箱";
                _Tray.Visible = true;
                _Tray.DoubleClick += new EventHandler(NiTray_DoubleClick);
            }
            _Tray.Visible = true;
        }

        public void HideTray()
        {
            if (_Tray != null)
            {
                _Tray.Visible = false;
            }
        }

        public void ExitSystem()
        {
            if (_Guid != null)
            {
                if (_Guid.WillExit())
                {
                    _Guid.ExitForm();
                }
            }

            if (_Tray != null)
            {
                _Tray.Visible = false;
            }

            if (_Amon != null)
            {
                if (_Amon.WillExit())
                {
                    Close();
                }
            }
        }
        #endregion
    }
}