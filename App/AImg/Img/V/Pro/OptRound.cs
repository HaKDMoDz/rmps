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
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                g.Clip = new Region(CreateRoundedRectanglePath(0, 0, bmp.Width, bmp.Height, aw, ah));
                g.DrawImage(image, 0, 0, bmp.Width, bmp.Height);
                g.Save();
            }
            return bmp;
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

        private static GraphicsPath CreateRoundedRectanglePath(int x, int y, int w, int h, int aw, int ah)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(x, y, aw * 2, ah * 2, 180, 90);
            roundedRect.AddLine(x + aw, y, x + w - aw * 2, y);
            roundedRect.AddArc(x + w - aw * 2, y, aw * 2, ah * 2, 270, 90);
            roundedRect.AddLine(x + w, y + ah * 2, x + w, y + h - ah * 2);
            roundedRect.AddArc(x + w - aw * 2, y + h - ah * 2, aw * 2, ah * 2, 0, 90);
            roundedRect.AddLine(x + w - aw * 2, y + h, x + aw * 2, y + h);
            roundedRect.AddArc(x, y + h - ah * 2, aw * 2, ah * 2, 90, 90);
            roundedRect.AddLine(x, y + h - ah * 2, x, y + ah * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
