using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Me.Amon.Properties;

namespace Me.Amon.V.Logo
{
    public class LogoEye : ILogo
    {
        #region 全局变量
        private PictureBox _PBox;
        private Timer _Timer;

        /// <summary>
        /// 屏幕
        /// </summary>
        private int _ScreenW;
        private int _ScreenH;
        /// <summary>
        /// 瞳仁
        /// </summary>
        private Rectangle _AlienRect;
        private int _AlienRadius;
        private int _AlienCenterX;
        private int _AlienCenterY;
        /// <summary>
        /// 瞳孔
        /// </summary>
        private Image _PupilImg;
        private int _PupilRadius;
        private int _PupilCenterX;
        private int _PupilCenterY;
        /// <summary>
        /// 成像
        /// </summary>
        private Image _BufImage;
        private Brush _BufBrush;
        private Image _TmpImage;
        private Brush _TmpBrush;
        private Rectangle _BRect;
        private Rectangle _LRect;
        private Rectangle _RRect;
        #endregion

        public LogoEye(PictureBox pBox, IContainer container)
        {
            _PBox = pBox;
            _Timer = new Timer(container);
        }

        #region 接口实现
        public void DoWork()
        {
            _ScreenW = Screen.PrimaryScreen.Bounds.Width;
            _ScreenH = Screen.PrimaryScreen.Bounds.Height;

            _AlienRadius = 11;
            _AlienCenterX = 12;
            _AlienCenterY = 12;
            int x = _AlienRadius << 1;
            _AlienRect = new Rectangle(0, 0, x, x);

            _PupilImg = Resources.Pupil;
            _PupilRadius = 6;
            _PupilCenterX = _AlienRadius;
            _PupilCenterY = _AlienRadius;

            _BufImage = new Bitmap(_PBox.Width, _PBox.Height);
            _BRect = new Rectangle(0, 0, _PBox.Width, _PBox.Height);
            _BufBrush = new LinearGradientBrush(_BRect, Color.FromArgb(96, 96, 96), Color.FromArgb(0, 0, 0), LinearGradientMode.Vertical);

            _TmpImage = new Bitmap(x, x);
            _TmpBrush = new SolidBrush(Color.White);

            x = (_BufImage.Width - _TmpImage.Width) / 3;
            int y = (_BufImage.Height - _TmpImage.Height) >> 1;
            _LRect = new Rectangle(x, y, _AlienRadius, _TmpImage.Height);
            _RRect = new Rectangle(x + _AlienRadius + x, y, _AlienRadius, _TmpImage.Height);

            GenImage(_PupilCenterX, _PupilCenterY);

            _Timer.Interval = 200;
            _Timer.Tick += new EventHandler(Timer_Tick);
            _Timer.Start();
        }

        public void MouseMove()
        {
        }

        public void KeyPress()
        {
        }

        public void DoStop()
        {
            _Timer.Stop();
        }
        #endregion

        #region 眼睛动画
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            DoSpy(Cursor.Position.X, Cursor.Position.Y);
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

            // 眼睛中心坐标
            Point p = _PBox.PointToScreen(_PBox.Location);
            int cx = p.X + _AlienCenterX;
            int cy = p.Y + _AlienCenterY;

            int mw = x - cx;//象限水平鼠标距离
            int mh = y - cy;//象限垂直鼠标距离
            int sw = mw < 0 ? cx : (_ScreenW - cx);//象限屏幕宽度
            if (sw < 1)
            {
                sw = 1;
            }
            int sh = mh < 0 ? cy : (_ScreenH - cy);//象限屏幕高度
            if (sh < 1)
            {
                sh = 1;
            }
            int dr = _AlienRadius - _PupilRadius;//可绘制半径
            double rw = (double)mw / sw;
            double rh = (double)mh / sh;
            double rr = Math.Sqrt(rw * rw + rh * rh);//比例半径
            if (rr == 0)
            {
                rr = 1;
            }

            x = (int)(dr * rw / rr) + _PupilCenterX;
            y = (int)(dr * rh / rr) + _PupilCenterY;

            GenImage(x, y);
        }

        private void GenImage(int x, int y)
        {
            using (Graphics g1 = Graphics.FromImage(_BufImage))
            {
                g1.SmoothingMode = SmoothingMode.HighQuality;
                //g1.TextRenderingHint = TextRenderingHint.AntiAlias;

                using (Graphics g2 = Graphics.FromImage(_TmpImage))
                {
                    g2.SmoothingMode = SmoothingMode.HighQuality;
                    //g2.TextRenderingHint = TextRenderingHint.AntiAlias;

                    g2.FillRectangle(_BufBrush, _AlienRect);
                    g2.FillEllipse(_TmpBrush, _AlienRect);

                    g2.DrawImage(_PupilImg, x - _PupilRadius, y - _PupilRadius, _PupilImg.Width, _PupilImg.Height);

                    g2.Flush();
                }

                //g1.Clear(Color.FromArgb(0, 0, 0, 0));
                g1.FillRectangle(_BufBrush, _BRect);
                //g1.DrawImage(Resources.Alien, 0, 0);
                g1.DrawImage(_TmpImage, _LRect);
                g1.DrawImage(_TmpImage, _RRect);

                g1.Flush();
            }
            _PBox.Image = _BufImage;
        }
        #endregion
    }
}
