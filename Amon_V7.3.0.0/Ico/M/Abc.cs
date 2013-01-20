using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;

namespace Me.Amon.Ico.M
{
    public class Abc
    {
        public int Dim { get; set; }
        public string Text { get; set; }
        public Bitmap Source { get; set; }
        public Bitmap Thumbs { get; set; }
        public PixelFormat Format { get; set; }

        public void Decode(Bitmap bgImg, IconImage ico)
        {
            Source = ico.Icon.ToBitmap();
            Dim = Source.Width;
            Format = ico.PixelFormat;
            //Text = string.Format("{0}*{0}-{1} {2}", Dim, GetImageFormat(ico.IconImageFormat), GetPixelFormat(ico.PixelFormat));
            Text = string.Format("{0}*{0} {1}", Dim, GetPixelFormat(ico.PixelFormat));
            Thumbs = GetThumbs(bgImg, Source, Dim);
        }

        public void Decode(Bitmap bgImg, Bitmap image, PixelFormat format)
        {
            Source = image;
            Dim = Source.Width;
            Format = format;
            Text = string.Format("{0}*{0} {1}", Dim, GetPixelFormat(format));
            Thumbs = GetThumbs(bgImg, Source, Dim);
        }

        public static Bitmap GetThumbs(Bitmap bgImg, Image image, int dim)
        {
            if (dim > EIco.PREVIEW_ICON_DIM)
            {
                dim = EIco.PREVIEW_ICON_DIM;
            }

            Bitmap bitmap = new Bitmap(bgImg.Width, bgImg.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(bgImg, 0, 0, bgImg.Width, bgImg.Height);
                int w = dim < image.Width ? dim : image.Width;
                int h = dim < image.Height ? dim : image.Height;
                int x = (bgImg.Width - w) >> 1;
                int y = (bgImg.Height - h) >> 1;
                g.DrawImage(image, x, y, w, h);
                g.Save();
            }
            return bitmap;
        }

        public static string GetImageFormat(IconImageFormat format)
        {
            switch (format)
            {
                case IconImageFormat.BMP:
                    return "BMP";
                case IconImageFormat.PNG:
                    return "PNG";
                default:
                    return "";
            }
        }

        public static string GetPixelFormat(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Max:
                    return "Max";
                case PixelFormat.Indexed:
                    return "索引";
                case PixelFormat.Gdi:
                    return "Gdi";
                case PixelFormat.Format16bppRgb555:
                    return "16位 555";
                case PixelFormat.Format16bppRgb565:
                    return "16位 565";
                case PixelFormat.Format24bppRgb:
                    return "24位 RGB";
                case PixelFormat.Format32bppRgb:
                    return "32位 RGB";
                case PixelFormat.Format1bppIndexed:
                    return "1位 索引";
                case PixelFormat.Format4bppIndexed:
                    return "4位 索引";
                case PixelFormat.Format8bppIndexed:
                    return "8位 索引";
                case PixelFormat.Alpha:
                    return "Alpha";
                case PixelFormat.Format16bppArgb1555:
                    return "16位 1555";
                case PixelFormat.PAlpha:
                    return "PAlpha";
                case PixelFormat.Format32bppPArgb:
                    return "32位 PARGB";
                case PixelFormat.Extended:
                    return "";
                case PixelFormat.Format16bppGrayScale:
                    return "16位 灰色";
                case PixelFormat.Format48bppRgb:
                    return "18位 RGB";
                case PixelFormat.Format64bppPArgb:
                    return "64位 PARGB";
                case PixelFormat.Canonical:
                    return "默认";
                case PixelFormat.Format32bppArgb:
                    return "32位 ARGB";
                case PixelFormat.Format64bppArgb:
                    return "64位 ARGB";
                default:
                    return "N/A";
            }
        }
    }
}
