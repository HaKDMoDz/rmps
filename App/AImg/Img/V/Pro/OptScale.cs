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

        public Control Control
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

        public static Image ScaleImage(Image image, int width, int height, bool ratio)
        {
            if (image.Width == width && image.Height == height)
            {
                return image;
            }

            Bitmap bmp = new Bitmap(width, height);
            int x;
            int y;
            if (ratio)
            {
                double rw = (double)width / image.Width;
                double rh = (double)height / image.Height;
                double r = rw <= rh ? rw : rh;
                width = (int)(r * image.Width);
                height = (int)(r * image.Height);

                x = (bmp.Width - width) >> 1;
                y = (bmp.Height - height) >> 1;
            }
            else
            {
                x = 0;
                y = 0;
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawImage(image, x, y, width, height);
                g.Dispose();
            }

            return bmp;
        }
    }
}
