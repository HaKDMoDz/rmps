using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
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

        private AUserModel _UserModel;
        private IAmon _Amon;
        private List<TApp> _Apps;
        private TApp _TApp;
        #endregion

        #region 构造函数
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region 全局函数
        public static TApp DefaultApp
        {
            get;
            private set;
        }

        public static TApp CurrentApp
        {
            get;
            private set;
        }

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
                _Alert = new Alert(Me.Amon.Properties.Resources.Icon);
            }
            BeanUtil.CenterToParent(_Alert, window);
            _Alert.Show(window, alert);
        }

        public static void ShowError(Exception error)
        {
            Form window = null;
            if (_Error == null)
            {
                _Error = new Error(Me.Amon.Properties.Resources.Icon);
            }
            BeanUtil.CenterToParent(_Error, window);
            _Error.Show(window, error);
        }

        public static string ShowInput(string message, string deftext)
        {
            Form window = null;
            if (_Input == null)
            {
                _Input = new Input(Me.Amon.Properties.Resources.Icon);
            }
            BeanUtil.CenterToParent(_Input, window);
            _Input.Show(window, message, deftext);
            return _Input.DialogResult == DialogResult.OK ? _Input.Message : null;
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
            //if (_Writer != null)
            //{
            //    _Writer.WriteLine(msg);
            //    _Writer.Flush();
            //}
            System.Diagnostics.Debug.WriteLine(msg);
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

        public static DialogResult ShowOpenFileDialog(IWin32Window owner, string filter, string file, string folder, bool multi)
        {
            OpenFileDialog.Filter = filter;
            OpenFileDialog.FileName = file;
            OpenFileDialog.InitialDirectory = folder;
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

        public void ShowDefaultApp()
        {
            if (DefaultApp == null)
            {
                return;
            }

            ShowIApp(DefaultApp);
        }

        public void ShowCurrentApp()
        {
            if (CurrentApp == null)
            {
                return;
            }

            ShowIApp(CurrentApp);
        }

        public void ShowReset()
        {
            new Reset(_UserModel).ShowDialog();
        }
        #endregion

        #region 窗口事件
        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Me.Amon.Properties.Resources.Icon;

            //_UserModel = new Pwd.M.UserModel();
            _UserModel = new Pcs.M.UserModel();
            _UserModel.Init();

            // 系统日志
            string logFile = Path.Combine(_UserModel.SysHome, CApp.FILE_LOG);
            if (File.Exists(logFile))
            {
                _Writer = new StreamWriter(logFile, true, Encoding.UTF8);
                _Writer.AutoFlush = true;
                _Writer.WriteLine(string.Format("============{0}============", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            ShowUser();
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
            Activate();
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
            DefaultApp = new TApp { Id = "WPwd", Type = "app", NeedAuth = true };
            Pcs.WPcs wPwd = new Pcs.WPcs(this, _UserModel);
            //Pwd.WPwd wPwd = new Pwd.WPwd(this, _UserModel);
            wPwd.Show();
            wPwd.Init();
            DefaultApp.App = wPwd;
            //DefaultApp.App.Show();

            Visible = false;

            if (Settings.Default.Pattern == CApp.PATTERN_TRAY)
            {
                ShowTray();
            }
            else
            {
                ShowGuid();
            }

            if (DefaultApp.App != null)
            {
                DefaultApp.App.Focus();
            }

            LoadApps();
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
        }

        #region 应用相关
        public void SaveGuid()
        {
        }

        private AGuid _Guid;
        public void ShowGuid()
        {
            if (_Guid == null)
            {
                _Guid = new AGuid(this);
                _Guid.Location = new System.Drawing.Point(0, 0);
                //_Guid.Name = "panel1";

                //_Guid.CallBack = new AmonHandler<string>(ShowDApp);
                _Guid.InitData();

                this.Controls.Clear();
                this.Controls.Add(_Guid);
                this.Size = _Guid.Size;
            }

            //_Guid.ShowDApp(0);
            _Amon = _Guid;

            if (_Tray != null)
            {
                _Tray.Visible = false;
            }
            this.Visible = true;
        }

        /// <summary>
        /// 应用加载
        /// </summary>
        private void LoadApps()
        {
            _Apps = new List<TApp>();

            string path = Path.Combine(_UserModel.DatHome, "App.xml");
            if (!File.Exists(path))
            {
                return;
            }

            StreamReader reader = File.OpenText(path);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            TApp tApp;
            foreach (XmlNode node in doc.SelectNodes("/Amon/Apps/App"))
            {
                tApp = new TApp();
                tApp.FromXml(node);
                if (!tApp.IsDefault)
                {
                    _Apps.Add(tApp);
                }
            }

            _Amon.LoadMenu(_Apps);
        }

        private ATray _Tray;
        public void ShowTray()
        {
            if (_Tray == null)
            {
                _Tray = new ATray(this);
                _Tray.InitData();
                //_Tray.Init(_Apps);
            }
            _Amon = _Tray;

            _Tray.Visible = true;
            this.Visible = false;
        }

        public bool SaveData()
        {
            foreach (TApp tapp in _Apps)
            {
                if (tapp == null)
                {
                    continue;
                }
                IApp iapp = tapp.App;
                if (iapp == null)
                {
                    continue;
                }

                if (!iapp.CanExit())
                {
                    return false;
                }
                iapp.SaveData();
                iapp.Dispose();
            }
            return true;
        }

        public void ShowIApp(TApp tApp)
        {
            if (tApp == null)
            {
                return;
            }

            IApp iApp = tApp.App;
            if (iApp != null && iApp.Visible)
            {
                iApp.Activate();
                return;
            }

            _TApp = tApp;
            if (!tApp.NeedAuth)
            {
                DoShowIApp("");
                return;
            }

            CheckUser(new AmonHandler<string>(DoShowIApp));
        }

        private void DoShowIApp(string vm)
        {
            IApp iApp = _TApp.App;
            if (iApp == null || iApp.IsDisposed)
            {
                iApp = _TApp.CreateApp(_UserModel);
                if (iApp == null)
                {
                    return;
                }

                iApp.Show();
                return;
            }

            if (iApp.Visible)
            {
                iApp.Activate();
            }
            else
            {
                iApp.Visible = true;
            }
        }
        #endregion

        public void ExitSystem()
        {
            if (CurrentApp != null)
            {
                if (CurrentApp.App.CanExit())
                {
                    CurrentApp.App.Dispose();
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