using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class OptWater : UserControl, IOpt
    {
        private Image _Water;

        public OptWater()
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
            int t = (int)SpAlpha.Value;
            int x = 140;
            int y = 140;

            if (t == 0)
            {
                return image;
            }
            if (t == 100)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImage(_Water, x, y, _Water.Width, _Water.Height);
                    g.Save();
                }
                return image;
            }

            using (Graphics g = Graphics.FromImage(image))
            {
                //g.RotateTransform(angle);
                float[][] ptsArray ={
                            new float[] {1, 0, 0, 0, 0},
                            new float[] {0, 1, 0, 0, 0},
                            new float[] {0, 0, 1, 0, 0},
                            new float[] {0, 0, 0, t / 100f, 0}, //注意此处为0.1f图像为强透明
                            new float[] {0, 0, 0, 0, 1}};
                ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
                ImageAttributes imgAttributes = new ImageAttributes();//设置图像的颜色属性
                imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);//画图像
                g.DrawImage(_Water, new Rectangle(x, y, _Water.Width, _Water.Height), 0, 0, _Water.Width, _Water.Height, GraphicsUnit.Pixel, imgAttributes);
                g.Save();
            }
            return image;
        }

        public void Reset()
        {
        }
        #endregion
    }
}
