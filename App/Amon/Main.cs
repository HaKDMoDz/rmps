using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Properties;
using Me.Amon.Util;
using Me.Amon.Uw;
using Me.Amon.V;
using Me.Amon.V.Auth;
using Me.Amon.V.Guid;
using Me.Amon.V.Sign;

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

        private NotifyIcon NiTray;
        public void SetTrayVisible(bool visible)
        {
            if (!visible)
            {
                if (NiTray != null)
                {
                    NiTray.Visible = false;
                }
            }
            else
            {
                if (NiTray == null)
                {
                    NiTray = new NotifyIcon();
                    NiTray.BalloonTipTitle = "阿木导航";
                    NiTray.Icon = Me.Amon.Properties.Resources.Icon;
                    NiTray.Text = "阿木导航";
                    NiTray.Visible = true;
                    NiTray.DoubleClick += new EventHandler(NiTray_DoubleClick);
                }
                NiTray.Visible = visible;
            }

            //MgTray.Checked = visible;
        }
        #endregion

        #region 窗口事件
        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Me.Amon.Properties.Resources.Icon;

            // 系统日志
            if (File.Exists(EApp.FILE_LOG))
            {
                _Writer = new StreamWriter(EApp.FILE_LOG, true, Encoding.UTF8, 8);
                _Writer.AutoFlush = true;
                _Writer.WriteLine(string.Format("============{0}============", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            _UserModel = new UserModel();

            ShowSign();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Writer != null)
            {
                _Writer.Close();
            }

            Settings.Default.LocX = Location.X;
            Settings.Default.LocY = Location.Y;
            Settings.Default.Save();
        }

        private void NiTray_DoubleClick(object sender, EventArgs e)
        {
            //ShowLast();
        }
        #endregion

        #region 私有函数

        #region 权限相关
        private SignAc _SignAc;
        private void SignAc(ESignAc signAc, AmonHandler<string> handler)
        {
            if (_SignAc == null || !_SignAc.Visible)
            {
                _SignAc = new SignAc(this);
                _SignAc.Init(_UserModel);
            }
            _SignAc.CallBack = handler;
            _SignAc.ShowView(signAc);
            _SignAc.Show();
        }

        private SignRc _SignRc;
        public void CheckUser(AmonHandler<string> handler)
        {
            if (!CharUtil.IsValidateCode(_UserModel.Code))
            {
                SignAc(ESignAc.SignIn, handler);
                return;
            }

            if (_SignRc == null || !_SignRc.Visible)
            {
                _SignRc = new SignRc(_UserModel);
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

            ShowSign();
        }

        private void DoSignIn(string view)
        {
            ShowGuid();
        }

        private void DoSignOl(string view)
        {
        }
        #endregion

        private SignAc _Sign;
        private void ShowSign()
        {
            if (_Sign == null)
            {
                _Sign = new SignAc(this);
                //_AAuth.Location = new System.Drawing.Point(0, 0);
                _Sign.Name = "panel1";
                //_AAuth.Size = new System.Drawing.Size(310, 100);
                _Sign.TabIndex = 0;

                _Sign.CallBack = new AmonHandler<string>(DoSignIn);
            }
            _Sign.Init(_UserModel);

            Controls.Clear();
            Controls.Add(_Sign);
        }

        private AGuid _Guid;
        private void ShowGuid()
        {
            if (_Guid == null)
            {
                _Guid = new AGuid(this);
                //_AGuid.Location = new System.Drawing.Point(0, 0);
                _Guid.Name = "panel1";
                //_AGuid.Size = new System.Drawing.Size(310, 100);
                _Guid.TabIndex = 0;

                //_Guid.CallBack = new AmonHandler<string>(ShowDApp);
            }
            _Guid.Init(_UserModel);

            Controls.Clear();
            Controls.Add(_Guid);
        }
        #endregion
    }
}