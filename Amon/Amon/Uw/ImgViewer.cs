using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Uw
{
    public partial class ImgViewer : Form
    {
        #region 全局变量
        private Image _SrcImage;
        private Image _TmpImage;
        private Image _DstImage;
        private Brush _GroundBrush;
        /// <summary>
        /// 是否绘制路径网格
        /// </summary>
        private bool _MoveTip;
        private Pen _MoveTipPen;
        /// <summary>
        /// 是否绘制选择网格
        /// </summary>
        private bool _Choosed;
        private Pen _ChoosedPen;
        #endregion

        #region 构造函数
        public ImgViewer()
        {
            InitializeComponent();
        }

        public void Init(string file)
        {
            _SrcImage = BeanUtil.ReadImage(file, null);
            if (_SrcImage == null)
            {
                _SrcImage = new Bitmap(48, 48);
            }

            _TmpImage = new Bitmap(_SrcImage.Width, _SrcImage.Height);
            _DstImage = new Bitmap(_SrcImage.Width, _SrcImage.Height);
            _GroundBrush = new SolidBrush(Color.White);
            _MoveTipPen = new Pen(Color.FromArgb(128, 255, 0, 0), 1.0f);
            _ChoosedPen = new Pen(Color.FromArgb(128, 0, 255, 0), 2.0f);

            PbImg.Width = _SrcImage.Width;
            PbImg.Height = _SrcImage.Height;
            PbImg.Location = new Point((PlImg.Width - _SrcImage.Width) >> 1, (PlImg.Height - _SrcImage.Height) >> 1);

            ReDraw();
        }
        #endregion

        #region 事件处理
        private void ImgViewer_Resize(object sender, EventArgs e)
        {
            PbImg.Location = new Point((PlImg.Width - PbImg.Width) >> 1, (PlImg.Height - PbImg.Height) >> 1);
        }

        private void PbImg_MouseMove(object sender, MouseEventArgs e)
        {
            DoDraw(e.Location.X, e.Location.Y);
        }

        private void PbImg_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_Choosed)
            {
                return;
            }

            Point p = e.Location;
            using (Graphics g = Graphics.FromImage(_TmpImage))
            {
                g.DrawLine(_ChoosedPen, 0, p.Y, _DstImage.Width, p.Y);
                g.DrawLine(_ChoosedPen, p.X, 0, p.X, _DstImage.Height);
            }

            DoDraw(p.X, p.Y);
        }

        private void BtCursor_Click(object sender, EventArgs e)
        {
            _MoveTip = !_MoveTip;
        }

        private void BtGrid_Click(object sender, EventArgs e)
        {
            _Choosed = !_Choosed;
        }

        private void BtEraser_Click(object sender, EventArgs e)
        {
            ReDraw();
        }
        #endregion

        #region 私有函数
        private void ReDraw()
        {
            using (Graphics g = Graphics.FromImage(_TmpImage))
            {
                g.FillRectangle(_GroundBrush, 0, 0, _DstImage.Width, _DstImage.Height);

                g.DrawImage(_SrcImage, 0, 0);
            }

            DoDraw(_DstImage.Width >> 1, _DstImage.Height >> 1);
        }

        private void DoDraw(int x, int y)
        {
            using (Graphics g = Graphics.FromImage(_DstImage))
            {
                g.FillRectangle(_GroundBrush, 0, 0, _DstImage.Width, _DstImage.Height);

                g.DrawImage(_TmpImage, 0, 0);

                if (_MoveTip)
                {
                    g.DrawLine(_MoveTipPen, 0, y, _DstImage.Width, y);
                    g.DrawLine(_MoveTipPen, x, 0, x, _DstImage.Height);
                }
            }

            PbImg.Image = _DstImage;
        }
        #endregion
    }
}
