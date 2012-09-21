using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Kms.V
{
    public partial class MagicPtn : Form
    {
        public MagicPtn()
        {
            InitializeComponent();
        }

        public MagicPtn(UserControl control)
        {
            InitializeComponent();

            SetControl(control);
        }

        #region 图标资源
        /// <summary>
        /// 关闭按钮
        /// </summary>
        private static Image _exitD;
        private static Image _exitE;
        private static Image _exitP;

        /// <summary>
        /// 隐藏按钮
        /// </summary>
        private static Image _hideD;
        private static Image _hideE;
        private static Image _hideP;

        /// <summary>
        /// 选项按钮
        /// </summary>
        private static Image _menuD;
        private static Image _menuE;
        private static Image _menuP;

        /// <summary>
        /// 顶部背景
        /// </summary>
        private static Image bgTl;
        private static Image bgTm;
        private static Image bgTr;

        /// <summary>
        /// 中部背景
        /// </summary>
        private static Image bgMl;
        private static Image bgMm;
        private static Image bgMr;

        /// <summary>
        /// 底部背景
        /// </summary>
        private static Image bgBl;
        private static Image bgBm;
        private static Image bgBr;

        private static bool _Loaded;

        public void LoadRes()
        {
            if (_Loaded)
            {
                return;
            }

            const string skin = "Gray";
            string path = string.Format(@"png\{0}\bgtl.png", skin);
            if (File.Exists(path))
            {
                bgTl = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\bgtm.png", skin);
            if (File.Exists(path))
            {
                bgTm = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\bgtr.png", skin);
            if (File.Exists(path))
            {
                bgTr = Image.FromFile(path);
            }

            path = string.Format(@"png\{0}\bgml.png", skin);
            if (File.Exists(path))
            {
                bgMl = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\bgmm.png", skin);
            if (File.Exists(path))
            {
                bgMm = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\bgmr.png", skin);
            if (File.Exists(path))
            {
                bgMr = Image.FromFile(path);
            }

            path = string.Format(@"png\{0}\bgbl.png", skin);
            if (File.Exists(path))
            {
                bgBl = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\bgbm.png", skin);
            if (File.Exists(path))
            {
                bgBm = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\bgbr.png", skin);
            if (File.Exists(path))
            {
                bgBr = Image.FromFile(path);
            }

            path = string.Format(@"png\{0}\exitd.png", skin);
            if (File.Exists(path))
            {
                _exitD = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\exite.png", skin);
            if (File.Exists(path))
            {
                _exitE = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\exitp.png", skin);
            if (File.Exists(path))
            {
                _exitP = Image.FromFile(path);
            }

            path = string.Format(@"png\{0}\hided.png", skin);
            if (File.Exists(path))
            {
                _hideD = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\hidee.png", skin);
            if (File.Exists(path))
            {
                _hideE = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\hidep.png", skin);
            if (File.Exists(path))
            {
                _hideP = Image.FromFile(path);
            }

            path = string.Format(@"png\{0}\menud.png", skin);
            if (File.Exists(path))
            {
                _menuD = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\menue.png", skin);
            if (File.Exists(path))
            {
                _menuE = Image.FromFile(path);
            }
            path = string.Format(@"png\{0}\menup.png", skin);
            if (File.Exists(path))
            {
                _menuP = Image.FromFile(path);
            }

            _Loaded = true;
        }
        #endregion

        #region 重载方法
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                LbText.Text = value;
            }
        }
        #endregion

        #region 窗口控制
        #region Exit按钮
        public bool ExitButtonVisible
        {
            get { return PbExit.Visible; }
            set { PbExit.Visible = value; }
        }

        public string ExitButtonToolTip
        {
            set
            {
                TpTips.SetToolTip(PbExit, value);
            }
        }

        public EventHandler ExitButtonHandler
        {
            set { PbExit.Click += value; }
        }

        public void InitExitButton(Image d, Image e, Image p)
        {
            exitD = d;
            exitE = e;
            exitP = p;
        }
        #endregion

        #region Hide按钮
        public bool HideButtonVisible
        {
            get { return PbHide.Visible; }
            set { PbHide.Visible = value; }
        }

        public string HideButtonToolTip
        {
            set
            {
                TpTips.SetToolTip(PbHide, value);
            }
        }

        public EventHandler HideButtonHandler
        {
            set { PbHide.Click += value; }
        }

        public void InitHideButton(Image d, Image e, Image p)
        {
            hideD = d;
            hideE = e;
            hideP = p;
        }
        #endregion

        #region Menu按钮
        public bool MenuButtonVisible
        {
            get { return PbMenu.Visible; }
            set { PbMenu.Visible = value; }
        }

        public string MenuButtonToolTip
        {
            set
            {
                TpTips.SetToolTip(PbMenu, value);
            }
        }

        public EventHandler MenuButtonHandler
        {
            set { PbMenu.Click += value; }
        }

        public void InitMenuButton(Image d, Image e, Image p)
        {
            menuD = d;
            menuE = e;
            menuP = p;
        }
        #endregion
        #endregion

        #region 公共方法
        public UserControl Control
        {
            set
            {
                SetControl(value);
            }
        }

        public void SetToolTip(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void UseDefaultAction()
        {
            LoadRes();

            InitExitButton(_exitD, _exitE, _exitP);
            ExitButtonVisible = true;
            ExitButtonHandler = PbExit_Click;

            InitHideButton(_hideD, _hideE, _hideP);
            HideButtonVisible = true;
            HideButtonHandler = PbHide_Click;

            InitMenuButton(_menuD, _menuE, _menuP);
            MenuButtonVisible = false;
            MenuButtonHandler = PbMenu_Click;
        }
        #endregion

        #region 私有方法
        private void SetControl(UserControl control)
        {
            Width = control.Width + 10;
            Height = control.Height + 33;
            TpPanel.Controls.Add(control, 0, 1);
            control.Dock = DockStyle.Fill;
            TpPanel.SetColumnSpan(control, 4);
            control.Margin = new Padding(5, 0, 5, 6);
            control.Name = "UserControl";
            control.TabIndex = 4;
        }

        private Image _formBg;
        private void ReDraw()
        {
            _formBg = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(_formBg);

            // 左上角
            int x = 0;
            int y = 0;
            g.DrawImage(bgTl, x, y);

            // 上中部
            x = bgTl.Width;
            int w = Width - bgTr.Width;
            HlDraw(g, bgTm, x, y, w);

            // 右上角
            x = w;
            g.DrawImage(bgTr, x, y);

            // 左中部
            x = 0;
            y = bgTl.Height;
            int h = Height - bgBl.Height;
            VlDraw(g, bgMl, x, y, h);

            // 窗体
            x = bgMl.Width;
            y = bgTm.Height;
            w = Width - bgMr.Width;
            MaDraw(g, bgMm, x, y, w, h);

            // 右中部
            x = w;
            y = bgTr.Height;
            VlDraw(g, bgMr, x, y, h);

            // 左下角
            x = 0;
            y = Height - bgBl.Height;
            g.DrawImage(bgBl, x, y);

            // 下中部
            x += bgBl.Width;
            y = Height - bgBm.Height;
            w = Width - bgBr.Width;
            HlDraw(g, bgBm, x, y, w);

            // 右下角
            x = w;
            y = Height - bgBr.Height;
            g.DrawImage(bgBr, x, y);
        }

        private static void VlDraw(Graphics g, Image img, int x, int y, int h)
        {
            while (y < h)
            {
                g.DrawImage(img, x, y);
                y += img.Height;
            }
        }

        private static void HlDraw(Graphics g, Image img, int x, int y, int w)
        {
            while (x < w)
            {
                g.DrawImage(img, x, y);
                x += img.Width;
            }
        }
        private static void MaDraw(Graphics g, Image img, int x, int y, int w, int h)
        {
            int t = x;
            while (y < h)
            {
                while (x < w)
                {
                    g.DrawImage(img, x, y);
                    x += img.Width;
                }
                x = t;
                y += img.Height;
            }
        }
        #endregion

        #region 窗体事件

        private Image exitD;
        private Image exitE;
        private Image exitP;
        private Image hideD;
        private Image hideE;
        private Image hideP;
        private Image menuD;
        private Image menuE;
        private Image menuP;
        /// <summary>
        /// 窗体加载完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MagicPtn_Load(object sender, EventArgs e)
        {
            PbExit.BackgroundImage = exitD;
            PbHide.BackgroundImage = hideD;
            PbMenu.BackgroundImage = menuD;

            ReDraw();
        }

        /// <summary>
        /// 窗体背景重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MagicPtn_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_formBg, 0, 0);
        }

        private void MagicPtn_Resize(object sender, EventArgs e)
        {
            //Region = CharUtil.ReShape(0, 0, Width, Height, 6, true);
        }
        #endregion

        #region 窗体按钮

        #region Menu按钮
        private void PbMenu_MouseEnter(object sender, EventArgs e)
        {
            if (menuE != null)
            {
                PbMenu.BackgroundImage = menuE;
            }
        }

        private void PbMenu_MouseLeave(object sender, EventArgs e)
        {
            if (menuE != null)
            {
                PbMenu.BackgroundImage = menuD;
            }
        }

        private void PbMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (menuP != null)
            {
                PbMenu.BackgroundImage = menuP;
            }
        }

        private void PbMenu_MouseUp(object sender, MouseEventArgs e)
        {
            if (menuE != null)
            {
                PbMenu.BackgroundImage = menuE;
            }
        }
        #endregion

        #region Hide按钮
        private void PbHide_MouseEnter(object sender, EventArgs e)
        {
            if (hideE != null)
            {
                PbHide.BackgroundImage = hideE;
            }
        }

        private void PbHide_MouseLeave(object sender, EventArgs e)
        {
            if (hideE != null)
            {
                PbHide.BackgroundImage = hideD;
            }
        }

        private void PbHide_MouseDown(object sender, MouseEventArgs e)
        {
            if (hideP != null)
            {
                PbHide.BackgroundImage = hideP;
            }
        }

        private void PbHide_MouseUp(object sender, MouseEventArgs e)
        {
            if (_hideE != null)
            {
                PbHide.BackgroundImage = hideE;
            }
        }
        #endregion

        #region Exit按钮
        private void PbExit_MouseEnter(object sender, EventArgs e)
        {
            if (exitE != null)
            {
                PbExit.BackgroundImage = exitE;
            }
        }

        private void PbExit_MouseLeave(object sender, EventArgs e)
        {
            if (exitE != null)
            {
                PbExit.BackgroundImage = exitD;
            }
        }

        private void PbExit_MouseDown(object sender, MouseEventArgs e)
        {
            if (exitP != null)
            {
                PbExit.BackgroundImage = exitP;
            }
        }

        private void PbExit_MouseUp(object sender, MouseEventArgs e)
        {
            if (exitE != null)
            {
                PbExit.BackgroundImage = exitE;
            }
        }
        #endregion

        private void PbMenu_Click(object sender, EventArgs e)
        {
        }

        private void PbHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PbExit_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        #endregion

        #region 窗口移动事件
        private Point _mouseOffset;
        private Rectangle _screenSize;
        private bool _isMouseDown;
        private const int GAPS = 10;
        /// <summary>
        /// 窗口移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinFormMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseDown)
            {
                return;
            }

            var mousePos = MousePosition;
            mousePos.Offset(_mouseOffset);

            const int x1 = 0;
            int x2 = _screenSize.Width - Width;
            if (mousePos.X - GAPS <= x1 && mousePos.X + GAPS >= x1)
            {
                mousePos.X = x1;
            }
            else if (mousePos.X - GAPS <= x2 && mousePos.X + GAPS >= x2)
            {
                mousePos.X = x2;
            }

            const int y1 = 0;
            int y2 = _screenSize.Height - Height;
            if (mousePos.Y - GAPS <= y1 && mousePos.Y + GAPS >= y1)
            {
                mousePos.Y = y1;
            }
            else if (mousePos.Y - GAPS <= y2 && mousePos.Y + GAPS >= y2)
            {
                mousePos.Y = y2;
            }

            Location = mousePos;
        }

        /// <summary>
        /// 鼠标放松事件，用于窗口最后定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinFormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _mouseOffset = new Point(-e.X, -e.Y);
            _screenSize = Screen.PrimaryScreen.WorkingArea;
            _isMouseDown = true;
        }

        /// <summary>
        /// 鼠标压下事件，用于窗口移动判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinFormMouseUp(object sender, MouseEventArgs e)
        {
            //修改鼠标状态isMouseDown的值
            //确保只有鼠标左键按下并移动时，才移动窗体
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = false;
            }
        }
        #endregion
    }
}
