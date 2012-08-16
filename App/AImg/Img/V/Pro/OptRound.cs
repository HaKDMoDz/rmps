using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class OptRound : UserControl, IOpt
    {
        public OptRound()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init()
        {
        }

        public Control Control
        {
            get { return this; }
        }

        public Image Deal(Image image)
        {
            if (image == null)
            {
                return image;
            }
            int aw = (int)SpWidth.Value;
            int ah = (int)SpHeight.Value;
            if (aw < 1 || ah < 1)
            {
                return image;
            }

            Brush brush = new SolidBrush(CkColor.Checked ? Color.Transparent : PbColor.BackColor);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                GraphicsPath path = CreateRoundRectanglePath(0, 0, image.Width, image.Height, 5, 5, Corner.TopLeft);
                g.FillPath(brush, path);
                g.Save();
            }
            return image;
        }

        public void Reset()
        {
        }
        #endregion

        #region 事件处理
        private void PbColor_Click(object sender, EventArgs e)
        {
            if (CkColor.Checked)
            {
                return;
            }
            ColorDialog cd = new ColorDialog();
            cd.Color = PbColor.BackColor;
            if (DialogResult.OK != cd.ShowDialog())
            {
                return;
            }
            PbColor.BackColor = cd.Color;
        }

        private void CkColor_CheckedChanged(object sender, EventArgs e)
        {
            PbColor.Enabled = !CkColor.Checked;
        }
        #endregion

        private static GraphicsPath CreateRoundRectanglePath(int x, int y, int w, int h, int width, int height, Corner rrPosition)
        {
            int aw = width << 1;
            int ah = height << 1;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            switch (rrPosition)
            {
                case Corner.TopLeft:
                    {
                        x -= 1;
                        y -= 1;
                        path.AddLine(x, y, x, y + height);
                        path.AddArc(x, y, aw, ah, 180, 90);
                        break;
                    }
                case Corner.TopRight:
                    {
                        y -= 1;
                        path.AddLine(x + w, y, x + w - width, y);
                        path.AddArc(w - aw, y, aw, ah, 270, 90);
                        break;
                    }
                case Corner.BottomLeft:
                    {
                        x -= 1;
                        path.AddLine(x, y + h, x + width, y + h);
                        path.AddArc(x, y + h - aw, aw, ah, 90, 90);
                        break;
                    }
                case Corner.BottomRight:
                    {
                        path.AddLine(x + w, y + h, x + w, y + h - height);
                        path.AddArc(x + w - aw, y + h - aw, aw, ah, 0, 90);
                        break;
                    }
            }
            path.CloseFigure();
            return path;
        }
    }
}
