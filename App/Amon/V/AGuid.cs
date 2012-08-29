using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.C;
using Me.Amon.M;
using Me.Amon.Properties;
using Me.Amon.Util;
using Me.Amon.V.Uc;

namespace Me.Amon.V
{
    public partial class AGuid : Form
    {
        private Main _Main;
        private UserModel _UserModel;
        private ILogo _ILogo;
        private TApp _TiApp;
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

        #region 构造函数
        public AGuid()
        {
            InitializeComponent();
        }

        public AGuid(Main main)
        {
            _Main = main;

            InitializeComponent();
        }
        #endregion

        public void InitView(UserModel userModel)
        {
            _UserModel = userModel;

            // 背景透明
            GenBgImage();
            BackColor = _TransColor;
            TransparencyKey = _TransColor;

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
            TopMost = true;

            // 
            MiPlugIns.Checked = Settings.Default.PlugIns;
            MiApps.Visible = !Settings.Default.PlugIns;
            MiSep0.Visible = !Settings.Default.PlugIns;

            // 系统徽标
            MiLogo.Checked = (Settings.Default.Emotion == 0);

            ChangeEmotion(Settings.Default.Emotion);
            ChangeAppVisible(false);

            LoadIApp();
        }

        public bool WillExit()
        {
            Settings settings = Settings.Default;
            settings.LocX = Location.X;
            settings.LocY = Location.Y;
            settings.Save();

            return true;
        }

        public bool ExitForm()
        {
            return true;
        }

        public AmonHandler<int> CallBack;

        #region 事件处理
        private void AGuid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            BeginMove();
        }

        private void AGuid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsMouseDown)
            {
                return;
            }

            DoMove();
        }

        private void AGuid_MouseUp(object sender, MouseEventArgs e)
        {
            _IsMouseDown = false;
        }

        private void AGuid_MouseLeave(object sender, EventArgs e)
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
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            BeginMove();
        }

        private void PbApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_IsMouseDown)
            {
                _ILogo.MouseMove();
                return;
            }

            DoMove();
        }

        private void PbApp_MouseUp(object sender, MouseEventArgs e)
        {
            _IsMouseDown = false;

            if (e.Button == MouseButtons.Right)
            {
                CmMenu.Show(PbApp, e.Location);
            }
        }

        private void PbApp_DoubleClick(object sender, EventArgs e)
        {
            if (!_Main.Visible)
            {
                _Main.Visible = true;
            }
            _Main.BringToFront();
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
            _TiApp = item.Tag as TApp;
            if (_TiApp == null)
            {
                return;
            }

            IApp app = _Apps[_TiApp.Id];
            if (app == null || app.IsDisposed)
            {
                app = GetIApp(_TiApp);
                _Apps[_TiApp.Id] = app;
                app.Show();
                //_Main.CheckUser(new AmonHandler<int>(ShowIApp));
                return;
            }

            if (!app.Visible)
            {
                app.Visible = true;
            }
            app.BringToFront();
        }

        #region 选单事件
        /// <summary>
        /// 窗口是否置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiTopMost_Click(object sender, EventArgs e)
        {
            _Main.TopMost = !_Main.TopMost;
            MiTopMost.Checked = _Main.TopMost;
        }

        /// <summary>
        /// 是否鼠标穿透
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiThrough_Click(object sender, EventArgs e)
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
        private void MiLogo_Click(object sender, EventArgs e)
        {
            Settings.Default.Emotion = 1 - Settings.Default.Emotion;
            ChangeEmotion(Settings.Default.Emotion);
            MiLogo.Checked = (Settings.Default.Emotion == 0);
            Settings.Default.Save();
        }

        private void MiTray_Click(object sender, EventArgs e)
        {
            bool visible = !MiTray.Checked;
            MiTray.Checked = visible;

            if (visible)
            {
                _Main.ShowTray();
                Settings.Default.Pattern |= CApp.PATTERN_TRAY;
            }
            else
            {
                _Main.HideTray();
                Settings.Default.Pattern ^= CApp.PATTERN_TRAY;
            }
            Settings.Default.Save();
        }

        private void MiPlugIns_Click(object sender, EventArgs e)
        {
            Settings.Default.PlugIns = MiPlugIns.Checked;
            MiApps.Visible = !MiPlugIns.Checked;
            MiSep0.Visible = !MiPlugIns.Checked;

            ChangeAppVisible(MiPlugIns.Checked);
        }
        #endregion

        #region 权限相关
        /// <summary>
        /// 在线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignOl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignOl, new AmonHandler<string>(DoSignOl));
        }

        /// <summary>
        /// 离线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignUl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignUl, new AmonHandler<string>(ShowAPwd));
        }

        /// <summary>
        /// 脱机注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignPc_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignPc, new AmonHandler<string>(ShowAPwd));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignIn_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignIn, new AmonHandler<string>(DoSignIn));
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignOf_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                _Main.SignOf();
            }
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignFp_Click(object sender, EventArgs e)
        {
        }
        #endregion

        private void MiReset_Click(object sender, EventArgs e)
        {
            new Reset(_UserModel).ShowDialog();
        }

        #region
        private void MiInfo_Click(object sender, EventArgs e)
        {
            Main.ShowAbout(_Main);
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            _Main.ExitSystem();
        }
        #endregion
        #endregion
        #endregion

        #region 私有函数
        private void ChangeAppVisible(bool visible)
        {
            if (MiPlugIns.Checked && visible)
            {
                if (_MaxRegion == null)
                {
                    _MaxRegion = new Region(new Rectangle(0, 0, 340, 140));
                }
                this.Region = _MaxRegion.Clone();
            }
            else
            {
                if (_MinRegion == null)
                {
                    _MinRegion = new Region(PbApp.Bounds);
                }
                this.Region = _MinRegion.Clone();
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
                _ILogo = new LogoEye(PbApp, this.components);
            }
            else
            {
                _ILogo = new LogoIco(PbApp, this.components);
            }
            _ILogo.DoWork();
        }

        private bool SaveData()
        {
            foreach (IApp iapp in _Apps.Values)
            {
                if (iapp == null)
                {
                    continue;
                }

                if (!iapp.WillExit())
                {
                    return false;
                }
                iapp.SaveData();
                iapp.Dispose();
            }
            return true;
        }

        private void BeginMove()
        {
            _MouseOffset = MousePosition;
            _MouseOffset.X -= Location.X;
            _MouseOffset.Y -= Location.Y;
            _IsMouseDown = true;
        }

        private void DoMove()
        {
            Point pos = MousePosition;
            pos.X -= _MouseOffset.X;
            pos.Y -= _MouseOffset.Y;

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

        #region 应用相关
        /// <summary>
        /// 应用加载
        /// </summary>
        private void LoadIApp()
        {
            _Apps = new Dictionary<string, IApp>();

            string path = Path.Combine(_UserModel.Home, "App.xml");
            if (!File.Exists(path))
            {
                return;
            }

            StreamReader reader = File.OpenText(path);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            TApp tApp;
            ToolStripMenuItem item;
            foreach (XmlNode node in doc.SelectNodes("/Amon/Apps/App"))
            {
                tApp = new TApp();
                tApp.FromXml(node);

                _Apps[tApp.Id] = null;

                IlApp.Images.Add(tApp.Id, BeanUtil.ReadImage(tApp.Logo, Resources.Logo32));
                LvApp.Items.Add(new ListViewItem { Text = tApp.Text, ToolTipText = tApp.Text, ImageKey = tApp.Id, Tag = tApp });

                item = new ToolStripMenuItem { Text = tApp.Text, Tag = tApp };
                item.Click += new EventHandler(AppItem_Click);
                MiApps.DropDownItems.Add(item);
            }
        }

        public void AppItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            _TiApp = item.Tag as TApp;
            if (_TiApp == null)
            {
                return;
            }
            ShowIApp(0);
        }

        private void ShowIApp(int ptn)
        {
            if (_TiApp == null)
            {
                return;
            }

            IApp iapp = _Apps[_TiApp.Id];
            if (iapp == null || iapp.IsDisposed)
            {
                iapp = GetIApp(_TiApp);
                if (iapp == null)
                {
                    return;
                }
                _Apps[_TiApp.Id] = iapp;
            }

            if (iapp != null)
            {
                iapp.Show();
            }
        }

        public IApp GetIApp(TApp app)
        {
            Main.LogInfo("创建新实例：" + app.Id);

            if (app == null)
            {
                return null;
            }

            switch ((app.Id ?? "").ToLower())
            {
                case CApp.IAPP_ABAR:
                    return new Bar.ABar(_UserModel);
                case CApp.IAPP_AREN:
                    return new Ren.ARen(_UserModel);
                case CApp.IAPP_AICO:
                    return new Ico.AIco(_UserModel);
                case CApp.IAPP_AIMG:
                    return new Img.AImg(_UserModel);
                case CApp.IAPP_ASPY:
                    return new Spy.ASpy(_UserModel);
                default:
                    return null;
            }
        }
        #endregion
        #endregion
    }
}
