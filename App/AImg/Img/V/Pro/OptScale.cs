using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class OptScale : UserControl, IOpt
    {
        public OptScale()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init()
        {
        }

        public new Control Control
        {
            get { return this; }
        }

        public Image Deal(Image image)
        {
            return image;
        }

        public void Reset()
        {
        }
        #endregion

        public static Image ScaleImage(Image img, int dim, bool ratio)
        {
            if (img.Width == dim && img.Height == dim)
            {
                return img;
            }

            Bitmap bmp = new Bitmap(dim, dim);
            int w = img.Width;
            int h = img.Height;
            int x;
            int y;
            if (ratio)
            {
                double rw = (double)dim / w;
                double rh = (double)dim / h;
                double r = rw <= rh ? rw : rh;
                w = (int)(r * w);
                h = (int)(r * h);

                x = (dim - w) >> 1;
                y = (dim - h) >> 1;
            }
            else
            {
                x = 0;
                y = 0;
            }

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(img, x, y, w, h);
            g.Flush();
            g.Dispose();

            return bmp;
        }
    }
}
