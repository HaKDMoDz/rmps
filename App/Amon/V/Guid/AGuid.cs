using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Properties;
using Me.Amon.Util;

namespace Me.Amon.V.Guid
{
    public partial class AGuid : UserControl
    {
        private Main _Main;
        private UserModel _UserModel;
        private ILogo _ILogo;
        private TApp _TiApp;
        private TApp _TdApp;
        private IApp _DApp;
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

        public void Init(UserModel userModel)
        {
            _UserModel = userModel;

            // 背景透明
            _Main.Visible = false;
            _Main.FormBorderStyle = FormBorderStyle.None;
            _Main.ShowInTaskbar = false;
            GenBgImage();
            _Main.BackColor = _TransColor;
            _Main.TransparencyKey = _TransColor;

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
            _Main.Location = new Point(x, y);
            _Main.Visible = true;

            // 
            MgPlugIns.Checked = Settings.Default.PlugIns;

            // 系统徽标
            MgLogo.Checked = (Settings.Default.Emotion == 0);

            // 托盘图标状态
            //int pattern = Settings.Default.Pattern;
            //SetTrayVisible((pattern & EApp.PATTERN_TRAY) != 0);

            ChangeAppVisible(true);

            LoadIApp();

            ShowDApp(0);
        }

        public AmonHandler<int> CallBack;

        public bool ddd()
        {
            foreach (IApp iapp in _Apps.Values)
            {
                if (iapp != null)
                {
                    if (!iapp.WillExit())
                    {
                        return false;
                    }
                    iapp.SaveData();
                    iapp.Dispose();
                }
            }
            return true;
        }

        #region 事件处理
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
            //ShowLast();
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
        private void MgTopMost_Click(object sender, EventArgs e)
        {
            _Main.TopMost = !_Main.TopMost;
            MgTopMost.Checked = _Main.TopMost;
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
            //ChangeEmotion(Settings.Default.Emotion);
            //MgLogo.Checked = (Settings.Default.Emotion == 0);
            Settings.Default.Save();
        }

        private void MgTray_Click(object sender, EventArgs e)
        {
            bool visible = !MgTray.Checked;
            MgTray.Checked = visible;
            //SetTrayVisible(visible);

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

        private void MgPlugIns_Click(object sender, EventArgs e)
        {

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
            //SignAc(ESignAc.SignOl, new AmonHandler<string>(DoSignOl));
        }

        /// <summary>
        /// 离线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignUl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignUl, new AmonHandler<string>(ShowAPwd));
        }

        /// <summary>
        /// 脱机注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignPc_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignPc, new AmonHandler<string>(ShowAPwd));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignIn_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignIn, new AmonHandler<string>(DoSignIn));
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MgSignOf_Click(object sender, EventArgs e)
        {
            //SignOf();
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
            //ShowAbout(this);
        }

        private void MgExit_Click(object sender, EventArgs e)
        {
            _Main.Close();
        }
        #endregion
        #endregion
        #endregion

        #region 私有函数
        private void ChangeAppVisible(bool visible)
        {
            if (MgPlugIns.Checked && visible)
            {
                if (_MaxRegion == null)
                {
                    _MaxRegion = new Region(Bounds);
                }
                _Main.Region = _MaxRegion.Clone();
            }
            else
            {
                if (_MinRegion == null)
                {
                    _MinRegion = new Region(PbApp.Bounds);
                }
                _Main.Region = _MinRegion.Clone();
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
            foreach (XmlNode node in doc.SelectNodes("/Amon/Apps/App"))
            {
                tApp = new TApp();
                tApp.FromXml(node);
                _Apps[tApp.Id] = null;

                IlApp.Images.Add(tApp.Id, BeanUtil.ReadImage(tApp.Logo, Resources.Logo32));
                LvApp.Items.Add(new ListViewItem { Text = tApp.Text, ImageKey = tApp.Id, Tag = tApp });

                if (tApp.Default)
                {
                    _TdApp = tApp;
                }
            }
        }

        private void ShowDApp(int ptn)
        {
            if (_DApp == null || _DApp.IsDisposed)
            {
                _DApp = GetIApp(_TdApp);
            }
            if (_DApp != null)
            {
                _DApp.Show();
            }
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
            if (app == null)
            {
                return null;
            }

            switch ((app.Id ?? "").ToLower())
            {
                case EApp.IAPP_APWD:
                    app.NeedAuth = true;
                    return new Pwd.APwd(_UserModel);
                case EApp.IAPP_ASEC:
                    return new Sec.ASec(_UserModel);
                case EApp.IAPP_ABAR:
                    return new Bar.ABar(_UserModel);
                case EApp.IAPP_AREN:
                    return new Ren.ARen(_UserModel);
                case EApp.IAPP_AICO:
                    return new Ico.AIco(_UserModel);
                case EApp.IAPP_AIMG:
                    return new Img.AImg(_UserModel);
                case EApp.IAPP_ASPY:
                    return new Spy.ASpy(_UserModel);
                case EApp.IAPP_ASQL:
                    return new Sql.ASql(_UserModel);
                default:
                    return null;
            }
        }
        #endregion
        #endregion
    }
}
