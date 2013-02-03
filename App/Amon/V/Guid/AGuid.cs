using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Properties;
using Me.Amon.Util;
using Me.Amon.V.Logo;

namespace Me.Amon.V.Guid
{
    public partial class AGuid : UserControl, IAmon
    {
        private Main _Main;
        private Tips _Tips;
        private ILogo _ILogo;

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

        #region 接口实现
        public void InitData()
        {
            // 背景透明
            GenBgImage();
            _Main.FormBorderStyle = FormBorderStyle.None;
            _Main.ShowInTaskbar = false;
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
            _Main.TopMost = true;
            //_Main.Visible = true;

            ChangeEmotion(Settings.Default.Emotion);
            // 系统徽标
            MiMeye.Checked = (Settings.Default.Emotion == CApp.EMOTION_EYE);

            ChangeAppVisible(false);
            MiApps.Checked = Settings.Default.PlugIns;
            //MuApps.Visible = !Settings.Default.PlugIns;
            MuApps.Visible = false;
        }

        public void LoadMenu(List<TApp> apps)
        {
            foreach (TApp app in apps)
            {
                IlApp.Images.Add(app.Id, BeanUtil.ReadImage(app.Logo, Resources.Logo32));
                LvApp.Items.Add(new ListViewItem { Text = app.Text, ToolTipText = app.Text, ImageKey = app.Id, Tag = app });

                ToolStripMenuItem item = new ToolStripMenuItem { Text = app.Text, Tag = app };
                item.Click += new EventHandler(AppItem_Click);
                MuApps.DropDownItems.Add(item);
            }
        }

        public void SaveView()
        {
        }

        public void DeInit()
        {
        }

        public bool WillExit()
        {
            Settings settings = Settings.Default;
            settings.LocX = _Main.Location.X;
            settings.LocY = _Main.Location.Y;
            settings.Save();

            return true;
        }

        public void Close()
        {
        }

        public void ShowBubbleTips(string tips)
        {
            if (_Tips == null)
            {
                _Tips = new Tips();
            }

            var loc = _Main.Location;
            var dim = Screen.PrimaryScreen.WorkingArea.Size;
            if (dim.Height - loc.Y < 300)
            {
                loc.Y -= _Tips.Height;
            }
            else
            {
                loc.Y += 32;
            }
            _Tips.Location = loc;
            _Tips.Visible = true;
            _Tips.ShowTips(tips);
        }

        public void ShowFlicker()
        {
        }

        public void HideFlicker()
        {
        }
        #endregion

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
            if (MousePosition.X < _Main.Location.X
                || MousePosition.Y < _Main.Location.Y
                || MousePosition.X > _Main.Location.X + Width
                || MousePosition.Y > _Main.Location.Y + Height)
            {
                ChangeAppVisible(false);
            }
        }

        private void PbApp_MouseEnter(object sender, EventArgs e)
        {
            if (MiApps.Checked)
            {
                ChangeAppVisible(true);
            }
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
            _Main.ShowDefaultApp();
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
            _Main.ShowIApp(app);
        }

        #region 选单事件
        private void MiReset_Click(object sender, EventArgs e)
        {
            _Main.ShowReset();
        }

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
            if (_Main.BackColor == Color.Red)
            {
                _Main.BackColor = Control.DefaultBackColor;
            }
            else
            {
                _Main.BackColor = Color.Red;
            }
        }

        private void MiApps_Click(object sender, EventArgs e)
        {
            Settings.Default.PlugIns = MiApps.Checked;
            MuApps.Visible = !MiApps.Checked;

            ChangeAppVisible(MiApps.Checked);
            Settings.Default.Save();
        }

        private void MiTray_Click(object sender, EventArgs e)
        {
            _Main.ShowTray();

            ChangeAppVisible(false);

            Settings.Default.Pattern = CApp.PATTERN_TRAY;
            Settings.Default.Save();
        }

        private void MiMeye_Click(object sender, EventArgs e)
        {
            if (MiMeye.Checked)
            {
                ChangeEmotion(CApp.EMOTION_ICO);
                Settings.Default.Emotion = CApp.EMOTION_ICO;
                MiMeye.Checked = false;
            }
            else
            {
                ChangeEmotion(CApp.EMOTION_EYE);
                Settings.Default.Emotion = CApp.EMOTION_EYE;
                MiMeye.Checked = true;
            }
            Settings.Default.Save();
        }

        private void MiSignOf_Click(object sender, EventArgs e)
        {
            if (_Main.SaveData())
            {
                _Main.SignOf();
            }
        }

        private void MiInfo_Click(object sender, EventArgs e)
        {
            if (Main.DefaultApp.App.Visible)
            {
                Main.ShowAbout(Main.DefaultApp.App.Form);
            }
            else
            {
                Main.ShowAbout(_Main);
            }
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            _Main.ExitSystem();
        }
        #endregion
        #endregion

        #region 私有函数
        public void ChangeAppVisible(bool visible)
        {
            if (visible)
            {
                if (_MaxRegion == null)
                {
                    _MaxRegion = new Region(new Rectangle(0, 0, 240, 160));
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

        public void ChangeEmotion(int emotion)
        {
            if (_ILogo != null)
            {
                _ILogo.DoStop();
            }

            if (emotion == CApp.EMOTION_EYE)
            {
                _ILogo = new LogoEye(PbApp, this.components);
            }
            else
            {
                _ILogo = new LogoIco(PbApp, this.components);
            }
            _ILogo.DoWork();
        }

        private void BeginMove()
        {
            _MouseOffset = MousePosition;
            _MouseOffset.X -= _Main.Location.X;
            _MouseOffset.Y -= _Main.Location.Y;
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
            _Main.Location = pos;
        }

        #region 应用相关
        public void AppItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            TApp app = item.Tag as TApp;
            if (app == null)
            {
                return;
            }

            _Main.ShowIApp(app);
        }
        #endregion
        #endregion
    }
}
