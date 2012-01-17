using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Me.Amon.User;

namespace Me.Amon
{
    public partial class Main : Form
    {
        #region 构造函数
        public Main()
        {
            InitializeComponent();
        }

        public void Init()
        {
            _ScreenW = Screen.PrimaryScreen.Bounds.Width;
            _ScreenH = Screen.PrimaryScreen.Bounds.Height;

            ChangeStyle('r');

            GenImage();

            BgWorker.Interval = 30;
            BgWorker.Start();
        }
        #endregion

        private void BtPwd_Click(object sender, System.EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #region 眼睛动画
        /// <summary>
        /// 瞳仁
        /// </summary>
        private int _AlienRadius;
        private int _AlienCenterX;
        private int _AlienCenterY;
        /// <summary>
        /// 瞳孔
        /// </summary>
        private int _PupilRadius;
        private int _PupilCenterX;
        private int _PupilCenterY;
        /// <summary>
        /// 
        /// </summary>
        private int _ScreenW;
        private int _ScreenH;

        private Image _BufImage;
        private Image _SrcImage;
        private Image _PupilImg;
        private Brush _BgBrush;
        private Rectangle _Rect1;
        private Rectangle _Rect2;
        private Brush _LgBrush1;
        private Brush _LgBrush2;

        private Point _MouseOffset;
        private bool _IsMouseDown;

        private void ChangeStyle(char style)
        {
            if (_BufImage == null)
            {
                _BufImage = new Bitmap(32, 32);
            }

            if (_BgBrush == null)
            {
                _BgBrush = new SolidBrush(Color.DarkGray);
            }

            if (style == 'l')
            {
                _SrcImage = Image.FromFile("Skin\\Default\\eyel.png");

                _AlienRadius = 14;
                _AlienCenterX = 26;
                _AlienCenterY = 21;

                _PupilRadius = 8;
                _PupilCenterX = _AlienCenterX;
                _PupilCenterY = _AlienCenterY;

                if (_PupilImg == null)
                {
                    _PupilImg = new Bitmap(_PupilRadius << 1, _PupilRadius << 1);
                }

                _Rect1 = new Rectangle(5, 10, 20, 15);
                _LgBrush1 = new LinearGradientBrush(_Rect1, Color.FromArgb(160, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.Horizontal);

                _Rect2 = new Rectangle(14, 10, 12, 12);
                _LgBrush2 = new LinearGradientBrush(_Rect2, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.ForwardDiagonal);

                using (Graphics g = Graphics.FromImage(_PupilImg))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    g.Clear(Color.FromArgb(0, 0, 0, 0));
                    g.FillEllipse(new SolidBrush(Color.Black), 0, 0, _PupilImg.Width, _PupilImg.Height);

                    Rectangle rect = new Rectangle(2, 2, _PupilRadius, _PupilRadius);
                    Brush brush = new LinearGradientBrush(rect, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.ForwardDiagonal);
                    g.FillEllipse(brush, rect);
                }
                return;
            }
            else
            {
                _SrcImage = Image.FromFile("Skin\\Default\\eyer.png");

                _AlienRadius = 10;
                _AlienCenterX = 14;
                _AlienCenterY = 14;

                _PupilRadius = 5;
                _PupilCenterX = _AlienCenterX;
                _PupilCenterY = _AlienCenterY;

                if (_PupilImg == null)
                {
                    _PupilImg = new Bitmap(_PupilRadius << 1, _PupilRadius << 1);
                }

                _Rect1 = new Rectangle(23, 10, 20, 15);
                _LgBrush1 = new LinearGradientBrush(_Rect1, Color.FromArgb(0, 255, 255, 255), Color.FromArgb(160, 255, 255, 255), LinearGradientMode.Horizontal);

                _Rect2 = new Rectangle(22, 10, 12, 12);
                _LgBrush2 = new LinearGradientBrush(_Rect2, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.BackwardDiagonal);

                using (Graphics g = Graphics.FromImage(_PupilImg))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;

                    g.Clear(Color.FromArgb(0, 0, 0, 0));
                    g.FillEllipse(new SolidBrush(Color.Black), 0, 0, _PupilImg.Width, _PupilImg.Height);

                    Rectangle rect = new Rectangle(_PupilRadius - 2, 2, _PupilRadius, _PupilRadius);
                    Brush brush = new LinearGradientBrush(rect, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.BackwardDiagonal);
                    g.FillEllipse(brush, rect);
                }
            }
        }

        private void BgWorker_Tick(object sender, System.EventArgs e)
        {
            if (!_IsMouseDown)
            {
                DoSpy(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void DoSpy(int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }
            else if (x > _ScreenW)
            {
                x = _ScreenW;
            }
            if (y < 0)
            {
                y = 0;
            }
            else if (y > _ScreenH)
            {
                y = _ScreenH;
            }

            int cx = Location.X + _AlienCenterX;
            int cy = Location.Y + _AlienCenterY;

            int mw = x - cx;//象限水平鼠标距离
            int mh = y - cy;//象限垂直鼠标距离
            int sw = mw < 0 ? cx : (_ScreenW - cx);//象限屏幕宽度
            int sh = mh < 0 ? cy : (_ScreenH - cy);//象限屏幕高度
            int dr = _AlienRadius - _PupilRadius;//可绘制半径
            double rw = (double)mw / sw;
            double rh = (double)mh / sh;
            double rr = Math.Sqrt(rw * rw + rh * rh);//比例半径
            if (rr == 0)
            {
                rr = 1;
            }

            double dw = 1.0;//绽放比例
            double dh = 1.0;
            _PupilCenterX = (int)(dr * dw * rw / rr) + _AlienCenterX;
            _PupilCenterY = (int)(dr * dh * rh / rr) + _AlienCenterY;

            GenImage();
        }

        private void GenImage()
        {
            using (Graphics g = Graphics.FromImage(_BufImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                //g.TextRenderingHint = TextRenderingHint.AntiAlias;

                Style0(g);

                g.Flush();
            }
            pictureBox1.Image = _BufImage;
        }

        private void Style0(Graphics g)
        {
            g.FillRectangle(_BgBrush, 0, 0, 48, 48);
            g.DrawImage(_SrcImage, 0, 0);

            //g.FillEllipse(_LgBrush1, _Rect1);
            //g.FillEllipse(_LgBrush2, _Rect2);

            int x = _PupilCenterX - _PupilRadius;
            int y = _PupilCenterY - _PupilRadius;
            int r = _PupilRadius << 1;
            g.FillEllipse(_BgBrush, x, y, r, r);
            g.DrawImage(_PupilImg, x, y);
        }

        private void Style2(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 48, 48);

            Rectangle rect1 = new Rectangle(0, 0, 24, 48);
            LinearGradientBrush brush1 = new LinearGradientBrush(rect1, Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 255, 255, 255), LinearGradientMode.Vertical);
            g.FillEllipse(brush1, rect1);
            rect1 = new Rectangle(3, 3, 18, 42);
            brush1 = new LinearGradientBrush(rect1, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 206, 206, 206), LinearGradientMode.Vertical);
            g.FillEllipse(brush1, rect1);

            Rectangle rect2 = new Rectangle(24, 0, 24, 48);
            LinearGradientBrush brush2 = new LinearGradientBrush(rect2, Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 255, 255, 255), LinearGradientMode.Vertical);
            g.FillEllipse(brush2, rect2);
            rect2 = new Rectangle(27, 3, 18, 42);
            brush2 = new LinearGradientBrush(rect2, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 206, 206, 206), LinearGradientMode.Vertical);
            g.FillEllipse(brush2, rect2);
        }
        #endregion

        #region 窗口事件
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _MouseOffset = new Point(-e.X, -e.Y);
                _IsMouseDown = true;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(_MouseOffset.X, _MouseOffset.Y);
                if (mousePos.X < 10)
                {
                    mousePos.X = 0;
                }
                else
                {
                    int t = SystemInformation.WorkingArea.Width - Width;
                    if (mousePos.X > t - 10)
                    {
                        mousePos.X = t;
                    }
                }
                if (mousePos.Y < 10)
                {
                    mousePos.Y = 0;
                }
                else
                {
                    int t = SystemInformation.WorkingArea.Height - Height;
                    if (mousePos.Y > t - 10)
                    {
                        mousePos.Y = t;
                    }
                }
                Location = mousePos;
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _IsMouseDown = false;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //HOOK.StopHook();
        }
        #endregion

        #region 菜单事件
        private void MiTopMost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void MiTrayIco_Click(object sender, EventArgs e)
        {
            NiTray.Visible = !NiTray.Visible;
        }

        private void MiPwd_Click(object sender, EventArgs e)
        {
            ShowAPwd();
        }

        private void MiSec_Click(object sender, EventArgs e)
        {
            ShowASec();
        }

        private void MIExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有函数
        private void ShowAPwd()
        {
        }

        private void ShowASec()
        {
        }
        #endregion
    }
}