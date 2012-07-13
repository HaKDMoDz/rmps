using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Properties;
using Me.Amon.User;
using Me.Amon.User.Sign;
using Me.Amon.Util;
using Me.Amon.Uw;
using Me.Amon.V;

namespace Me.Amon
{
    public partial class Main : Form
    {
        #region 全局变量
        private static IApp _IApp;
        private static Alert _Alert;
        private static Error _Error;
        private static Input _Input;
        private static Waiting _Waiting;

        private UserModel _UserModel;
        private ILogo _ILogo;
        private Pwd.APwd _APwd;
        private Dictionary<string, IApp> _Apps;

        #region 窗口移动
        private bool _IsMouseDown;
        private Point _MouseOffset;
        #endregion

        #region 窗口视觉
        private int _ArcWidth = 4;
        private int _ArcHeight = 4;
        private Color _StartColor = Color.White;
        private Color _EndColor = Color.Gainsboro;
        private Color _TransColor = Color.Cyan;
        private Image _BgImage;
        private Region _MaxRegion;
        private Region _MinRegion;
        #endregion
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
            return MessageBox.Show(_IApp.Form, message, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static void ShowAbout(IWin32Window owner)
        {
            About about = new About();
            about.ShowDialog(owner);
        }

        public static void ShowWaiting(string message)
        {
            if (_Waiting == null)
            {
                _Waiting = new Waiting();

            }
            BeanUtil.CenterToParent(_Waiting, _IApp.Form);
            _Waiting.Show(_IApp.Form, message);
        }

        public static void ShowAlert(string alert)
        {
            if (_Alert == null)
            {
                _Alert = new Alert();
            }
            BeanUtil.CenterToParent(_Alert, _IApp.Form);
            _Alert.Show(_IApp.Form, alert);
        }

        public static void ShowError(Exception error)
        {
            if (_Error == null)
            {
                _Error = new Error();
            }
            BeanUtil.CenterToParent(_Error, _IApp.Form);
            _Error.Show(_IApp.Form, error);
        }

        public static string ShowInput(string message, string deftext)
        {
            if (_Input == null)
            {
                _Input = new Input();
            }
            BeanUtil.CenterToParent(_Input, _IApp.Form);
            _Input.Show(_IApp.Form, message, deftext);
            return _Input.Message;
        }

        private static StreamWriter _Writer;
        public static void LogInfo(string msg)
        {
            if (_Writer != null)
            {
                _Writer.WriteLine(msg);
                _Writer.Flush();
            }
        }

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

        #region 窗口事件
        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Me.Amon.Properties.Resources.Icon;

            GenBgImage();

            // 窗口位置
            int x = Settings.Default.LocX;
            if (x < 0)
            {
                x = Screen.PrimaryScreen.Bounds.Width - 200;
            }
            int y = Settings.Default.LocY;
            if (y < 0)
            {
                y = 40;
            }
            Location = new Point(x, y);

            // 背景透明
            BackColor = _TransColor;
            TransparencyKey = _TransColor;

            // 托盘图标状态
            int pattern = Settings.Default.Pattern;
            SetTrayVisible((pattern & EApp.PATTERN_TRAY) != 0);

            // 
            MgPlugIns.Checked = Settings.Default.PlugIns;

            // 系统徽标
            ChangeEmotion(Settings.Default.Emotion);
            MgLogo.Checked = (Settings.Default.Emotion == 0);

            // 系统日志
            if (File.Exists(EApp.FILE_LOG))
            {
                _Writer = new StreamWriter(EApp.FILE_LOG, true, Encoding.UTF8, 8);
                _Writer.AutoFlush = true;
            }

            if (_UserModel == null)
            {
                _UserModel = new UserModel();
            }

            ListViewItem item = new ListViewItem { Text = "登录", ImageKey = "" };
            LvApp.Items.Add(item);
            item = new ListViewItem { Text = "注册", ImageKey = "" };
            LvApp.Items.Add(item);

            ChangeAppVisible(false);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IApp != null)
            {
                if (!_IApp.WillExit())
                {
                    e.Cancel = true;
                    return;
                }
                _IApp.SaveData();
            }

            if (_Writer != null)
            {
                _Writer.Close();
            }

            Settings.Default.LocX = Location.X;
            Settings.Default.LocY = Location.Y;
            Settings.Default.Save();
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _MouseOffset = MousePosition;
                _MouseOffset.X = Location.X - _MouseOffset.X;
                _MouseOffset.Y = Location.Y - _MouseOffset.Y;
                _IsMouseDown = true;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsMouseDown)
            {
                return;
            }

            Point pos = MousePosition;
            pos.X += _MouseOffset.X;
            pos.Y += _MouseOffset.Y;

            // 水平停靠
            if (pos.X < 10)
            {
                pos.X = 0;
            }
            else
            {
                int t = SystemInformation.WorkingArea.Width - Width;
                if (pos.X > t - 10)
                {
                    pos.X = t;
                }
            }

            // 垂直停靠
            if (pos.Y < 10)
            {
                pos.Y = 0;
            }
            else
            {
                int t = SystemInformation.WorkingArea.Height - Height;
                if (pos.Y > t - 10)
                {
                    pos.Y = t;
                }
            }
            Location = pos;
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            _IsMouseDown = false;
        }

        private void Main_MouseLeave(object sender, EventArgs e)
        {
            if (MousePosition.X < Location.X
                || MousePosition.Y < Location.Y
                || MousePosition.X > Location.X + Width
                || MousePosition.Y > Location.Y + Height)
            {
                ChangeAppVisible(false);
            }
        }

        private void PbApp_MouseEnter(object sender, EventArgs e)
        {
            ChangeAppVisible(true);
        }

        private void PbApp_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void PbApp_MouseMove(object sender, MouseEventArgs e)
        {
            _ILogo.MouseMove();
        }

        private void PbApp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CmMenu.Show(PbApp, e.Location);
            }
        }

        private void PbApp_DoubleClick(object sender, EventArgs e)
        {
            ShowLast();
        }

        private void LvApp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LvApp_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void LvApp_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void LvApp_DoubleClick(object sender, EventArgs e)
        {
            if (LvApp.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem item = LvApp.SelectedItems[0];
            TApp app = item.Tag as TApp;
            if (app == null)
            {
                return;
            }

            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<string>(ShowLast));
                return;
            }

            if (_IApp.Name != app.Id)
            {
                _IApp.Visible = false;
                ShowIApp(app.Id);
                return;
            }
        }

        private void NiTray_DoubleClick(object sender, EventArgs e)
        {
            ShowLast();
        }
        #endregion

        #region 选单事件
        /// <summary>
        /// 窗口是否置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgTopMost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            MgTopMost.Checked = TopMost;
        }

        /// <summary>
        /// 是否鼠标穿透
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgThrough_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Red)
            {
                BackColor = DefaultBackColor;
            }
            else
            {
                BackColor = Color.Red;
            }
        }

        #region
        private void MgLogo_Click(object sender, EventArgs e)
        {
            Settings.Default.Emotion = 1 - Settings.Default.Emotion;
            ChangeEmotion(Settings.Default.Emotion);
            MgLogo.Checked = (Settings.Default.Emotion == 0);
            Settings.Default.Save();
        }

        private void MgTray_Click(object sender, EventArgs e)
        {
            bool visible = !MgTray.Checked;
            MgTray.Checked = visible;
            SetTrayVisible(visible);

            if (visible)
            {
                Settings.Default.Pattern |= EApp.PATTERN_TRAY;
            }
            else
            {
                Settings.Default.Pattern ^= EApp.PATTERN_TRAY;
            }
            Settings.Default.Save();
        }
        #endregion

        #region 权限相关
        /// <summary>
        /// 在线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignOl_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignOl, new AmonHandler<string>(DoSignOl));
        }

        /// <summary>
        /// 离线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignUl_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignUl, new AmonHandler<string>(ShowAPwd));
        }

        /// <summary>
        /// 脱机注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignPc_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<string>(ShowAPwd));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignIn_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignIn, new AmonHandler<string>(DoSignIn));
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignOf_Click(object sender, EventArgs e)
        {
            SignOf();
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignFp_Click(object sender, EventArgs e)
        {
        }
        #endregion

        private void MiReset_Click(object sender, EventArgs e)
        {
            new Reset(_UserModel).ShowDialog();
        }

        #region
        private void MgInfo_Click(object sender, EventArgs e)
        {
            ShowAbout(this);
        }

        private void MgExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #endregion

        #region 私有函数
        private NotifyIcon NiTray;
        private void SetTrayVisible(bool visible)
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

            MgTray.Checked = visible;
        }

        #region 权限相关
        private SignAc _SignAc;
        private void SignAc(ESignAc signAc, AmonHandler<string> handler)
        {
            if (_SignAc == null || !_SignAc.Visible)
            {
                _SignAc = new SignAc(_UserModel);
                _SignAc.InitOnce();
            }
            _SignAc.CallBackHandler = handler;
            _SignAc.ShowView(signAc);
            _SignAc.Show();
        }

        private SignRc _SignRc;
        private void CheckUser(AmonHandler<string> handler)
        {
            if (!CharUtil.IsValidateCode(_UserModel.Code))
            {
                SignAc(ESignAc.SignIn, handler);
            }
            else
            {
                if (_SignRc == null || !_SignRc.Visible)
                {
                    _SignRc = new SignRc(_UserModel);
                    _SignRc.InitOnce();
                    _SignRc.Show();
                }
                _SignRc.CallBackHandler = handler;
            }
        }

        private void SignOf()
        {
            if (_IApp != null)
            {
                if (!_IApp.WillExit())
                {
                    return;
                }
                _IApp.SaveData();
                _IApp.Dispose();
            }

            _UserModel.CaSignOf();

            MgSignUp.Visible = true;
            MgSignIn.Visible = true;
            MgSignOf.Visible = false;
        }

        private void DoSignIn(string view)
        {
            MgSignIn.Visible = false;
            MgSignUp.Visible = false;
            MgSignOf.Visible = true;

            // 应用列表
            string path = Path.Combine(_UserModel.Home, "App.xml");
            if (!File.Exists(path))
            {
                //LbApp.Visible = false;
                return;
            }

            StreamReader reader = File.OpenText(path);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            TApp app;
            _Apps = new Dictionary<string, IApp>();
            foreach (XmlNode node in doc.SelectNodes("/Amon/Apps/App"))
            {
                app = new TApp();
                app.FromXml(node);
                _Apps[app.Id] = null;

                IlApp.Images.Add(app.Id, BeanUtil.ReadImage(app.Logo, Resources.Logo32));
                LvApp.Items.Add(new ListViewItem { Text = app.Text, ImageKey = app.Id, Tag = app });
            }
            ChangeAppVisible(true);
            return;
        }

        private void DoSignOl(string view)
        {
        }
        #endregion

        private void ShowAPwd(string view)
        {
            if (_APwd == null || _APwd.IsDisposed)
            {
                _APwd = new Pwd.APwd(_UserModel);
            }

            _IApp = _APwd;
            _IApp.Show();
        }

        private void ShowIApp(string app)
        {
            IApp iapp = _Apps[app];
            if (iapp == null || iapp.IsDisposed)
            {
                iapp = GetIApp(app);
                if (iapp == null)
                {
                    return;
                }
                _Apps[app] = iapp;
            }

            iapp.Show();
        }

        public IApp GetIApp(string app)
        {
            switch (app)
            {
                case EApp.IAPP_ASEC_NAME:
                    return new Sec.ASec(_UserModel);
                case EApp.IAPP_ABAR_NAME:
                    return new Bar.ABar(_UserModel);
                case EApp.IAPP_AREN_NAME:
                    return new Ren.ARen(_UserModel);
                case EApp.IAPP_AICO_NAME:
                    return new Ico.AIco(_UserModel);
                case EApp.IAPP_AIMG_NAME:
                    return new Img.AImg(_UserModel);
                case EApp.IAPP_ASPY_NAME:
                    return new Spy.ASpy(_UserModel);
                case EApp.IAPP_ASQL_NAME:
                    return new Sql.ASql(_UserModel);
                default:
                    return null;
            }
        }

        private void ShowLast(string view)
        {
            if (_IApp == null || _IApp.IsDisposed)
            {
                ShowAPwd(EApp.IAPP_APWD);
            }
            else
            {
                _IApp.Visible = true;
            }
        }

        private void ShowLast()
        {
            if (_IApp == null || _IApp.IsDisposed || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<string>(ShowLast));
                return;
            }

            _IApp.Visible = true;
            _IApp.BringToFront();
        }

        private void ChangeAppVisible(bool visible)
        {
            if (MgPlugIns.Checked && visible)
            {
                if (_MaxRegion == null)
                {
                    _MaxRegion = new Region(BeanUtil.CreateRoundedRectanglePath(0, 0, Width, Height, _ArcWidth, _ArcHeight));
                }
                Region = _MaxRegion.Clone();
            }
            else
            {
                if (_MinRegion == null)
                {
                    _MinRegion = new Region(PbApp.Bounds);
                }
                Region = _MinRegion.Clone();
            }
        }

        private void GenBgImage()
        {
            if (_BgImage == null)
            {
                _BgImage = new Bitmap(Width, Height);
                using (Graphics g = Graphics.FromImage(_BgImage))
                {
                    LinearGradientBrush brush = new LinearGradientBrush(Bounds, _StartColor, _EndColor, LinearGradientMode.Vertical);
                    g.FillPath(brush, BeanUtil.CreateRoundedRectanglePath(0, 0, Width, Height, _ArcWidth, _ArcHeight));
                    Pen pen = new Pen(Color.Gray);
                    g.DrawPath(pen, BeanUtil.CreateRoundedRectanglePath(0, 0, Width - 1, Height - 1, _ArcWidth, _ArcHeight));
                    g.Save();
                }
            }
            BackgroundImage = _BgImage;
        }

        private void ChangeEmotion(int emotion)
        {
            if (_ILogo != null)
            {
                _ILogo.DoStop();
            }

            if (emotion == 0)
            {
                _ILogo = new EyeLogo(PbApp, this.components);
            }
            else
            {
                _ILogo = new IcoLogo(PbApp, this.components);
            }
            _ILogo.DoWork();
        }
        #endregion

        private void MgSignUp_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<string>(ShowAPwd));
        }

        private void MgPlugIns_Click(object sender, EventArgs e)
        {

        }
    }
}