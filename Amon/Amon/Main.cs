using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Me.Amon.Properties;
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
            _ScreenW = SystemInformation.WorkingArea.Width;
            _ScreenH = SystemInformation.WorkingArea.Height;

            int x = Settings.Default.LocX;
            if (x < 0)
            {
                x = _ScreenW >> 1;
            }
            int y = Settings.Default.LocY;
            if (y < 0)
            {
                y = 0;
            }
            Location = new Point(x, y);
            ClientSize = new Size(88, 28);

            ChangeStyle();

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
        private Image _TmpImage;
        private Image _PupilImg;
        private Brush _BgBrush;
        private Rectangle _Rect1;
        private Rectangle _Rect2;
        private Brush _LgBrush1;
        private Brush _LgBrush2;

        private Point _MouseOffset;
        private bool _IsMouseDown;

        private void ChangeStyle()
        {
            _AlienRadius = 10;
            _AlienCenterX = 12;
            _AlienCenterY = 12;

            _PupilRadius = 6;
            _PupilCenterX = _AlienCenterX;
            _PupilCenterY = _AlienCenterY;

            _BufImage = new Bitmap(32, 32);
            _TmpImage = new Bitmap(20, 20);

            _BgBrush = new SolidBrush(Color.Black);

            _Rect1 = new Rectangle(0, 0, 20, 20);
            _LgBrush1 = new SolidBrush(Color.White);

            _Rect2 = new Rectangle(0, 0, 20, 20);
            _LgBrush2 = new SolidBrush(Color.White);

            _PupilImg = Resources.Pupil;
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
                g.SmoothingMode = SmoothingMode.HighQuality;
                //g.TextRenderingHint = TextRenderingHint.AntiAlias;

                Style0(g);

                g.Flush();
            }
            pictureBox1.Image = _BufImage;
        }

        private void Style0(Graphics g)
        {
            g.FillRectangle(_BgBrush, 0, 0, 32, 32);

            using (Graphics g1 = Graphics.FromImage(_TmpImage))
            {
                g1.SmoothingMode = SmoothingMode.HighQuality;

                g1.FillRectangle(_BgBrush, 0, 0, _TmpImage.Width, _TmpImage.Height);
                g1.FillEllipse(_LgBrush1, _Rect1);

                int x = _PupilCenterX - _PupilRadius;
                int y = _PupilCenterY - _PupilRadius;
                int r = _PupilRadius << 1;
                g1.DrawImage(_PupilImg, x, y, _PupilImg.Width, _PupilImg.Height);

                g1.Flush();
            }

            g.FillEllipse(new SolidBrush(Color.Black), _Rect1);
            g.FillEllipse(new SolidBrush(Color.White), _Rect2);

            //g.FillEllipse(_BgBrush, x, y, r, r);
            g.DrawImage(_TmpImage, 2, 1, 8, 20);
            g.DrawImage(_TmpImage, 14, 1, 8, 20);
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
            Settings.Default.LocX = Location.X;
            Settings.Default.LocY = Location.Y;
            Settings.Default.Save();
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

        private void MiExit_Click(object sender, EventArgs e)
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