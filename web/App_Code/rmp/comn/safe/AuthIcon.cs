using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace rmp.comn.safe
{
    /// <summary>
    ///GenValImage 的摘要说明
    /// </summary>
    public class AuthIcon
    {
        /// <summary>
        /// 验证码中字符个数
        /// </summary>
        private int codeNum = 4; //默认字符个数为5
        /// <summary>
        /// 干扰线条
        /// </summary>
        private int lineNum = 10;// 默认线条个数为10
        /// <summary>
        /// 字号
        /// </summary>
        private int fontSize = 20;
        /// <summary>
        /// 图片宽度
        /// </summary>
        private int width = 80;
        /// <summary>
        /// 图片高度
        /// </summary>
        private int height = 20;
        /// <summary>
        /// 验证码
        /// </summary>
        private String authCode;
        /// <summary>
        /// 扭曲图像
        /// </summary>
        private bool twistImg;
        /// <summary>
        /// 字体名称
        /// </summary>
        private List<String> fontFamily = new List<string>();

        /// <summary>
        /// 无参构造
        /// </summary>
        public AuthIcon()
        {
            init();
        }

        /// <summary>
        /// 带有生成字符个数的构造
        /// </summary>
        /// <param name="codeNum">验证码中包含随机字符的个数</param>
        public AuthIcon(int codeNum)
        {
            this.CodeNum = codeNum;
            init();
        }

        /// <summary>
        /// 带有验证码图片宽度和高度的构造
        /// </summary>
        /// <param name="width">验证码图片宽度</param>
        /// <param name="height">验证码图片高度</param>
        public AuthIcon(int width, int height)
        {
            this.width = width;
            this.height = height;
            init();
        }

        /// <summary>
        /// 带有生成字符个数，验证码图片宽度和高度的构造
        /// </summary>
        /// <param name="codeNum">验证码中包含随机字符的个数</param>
        /// <param name="width">验证码图片宽度</param>
        /// <param name="height">验证码图片高度</param>
        public AuthIcon(int codeNum, int width, int height)
        {
            this.CodeNum = codeNum;
            this.width = width;
            this.height = height;
            init();
        }

        private void init()
        {
            //定义一个含10种字体的数组
            fontFamily.Add("Arial");
            fontFamily.Add("Verdana");
            fontFamily.Add("Comic Sans MS");
            fontFamily.Add("Impact");
            fontFamily.Add("Haettenschweiler");
            fontFamily.Add("Lucida Sans Unicode");
            fontFamily.Add("Garamond");
            fontFamily.Add("Courier New");
            fontFamily.Add("Book Antiqua");
            fontFamily.Add("Arial Narrow");
        }

        /// <summary>
        /// 由随机字符串，随即颜色背景，和随机线条产生的Image
        /// </summary>
        /// <returns>Image</returns>
        public Image GetAuthIcon()//返回 Image
        {
            Image image;
            try
            {
                //由给定的需要生成字符串中字符个数 CodeNum， 图片宽度 Width 和高度 Height 确定字号 FontSize，
                //确保不因字号过大而不能全部显示在图片上
                int fontWidth = width / codeNum;
                int fontHeight = (int)Math.Round(height / 1.5);
                //字号取二者中小者，以确保所有字符能够显示，并且字符的下半部分也能显示
                fontSize = (fontWidth <= fontHeight ? fontWidth : fontHeight);
                int charGaps = (width - fontSize * (CodeNum + 1)) / CodeNum;
                //int space = (int)Math.Round((double)((width - fontSize * (CodeNum + 2)) / CodeNum));

                //创建位图对象
                Bitmap bitMap = new Bitmap(width + FontSize, height);
                //根据上面创建的位图对象创建绘图图面
                Graphics gph = Graphics.FromImage(bitMap);

                //设定验证码图片背景色
                gph.Clear(GetNoiseColor(200));

                Random random = new Random();

                //产生随机干扰线条
                for (int i = 0; i < lineNum; i++)
                {
                    Pen backPen = new Pen(GetNoiseColor(100), 2);
                    gph.DrawBezier(backPen, random.Next(width), random.Next(height), random.Next(width), random.Next(height), random.Next(width), random.Next(height), random.Next(width), random.Next(height));
                    //gph.DrawLine(backPen, random.Next(width), random.Next(height), random.Next(width), random.Next(height));
                }

                SolidBrush sb = new SolidBrush(GetNoiseColor(0));

                //通过循环,绘制每个字符,
                int x = fontSize;
                //int y = (int)Math.Round((double)((height - fontSize) / 3));
                int y = (height - fontSize) / 8;
                for (int i = 0; i < authCode.Length; i++)
                {
                    //每次循环绘制一个字符,设置字体格式,画笔颜色,字符相对画布的X坐标,字符相对画布的Y坐标
                    Font textFont = new Font(fontFamily[random.Next(fontFamily.Count)], fontSize, FontStyle.Bold);//字体随机,字号大小,加粗
                    gph.DrawString(authCode[i].ToString(), textFont, sb, x, y);
                    x += fontSize + charGaps;
                }
                //扭曲图片
                if (twistImg)
                {
                    bitMap = TwistImage(bitMap, true, random.Next(3, 5), random.Next(3));
                }

                //创建内存流
                MemoryStream memStream = new MemoryStream();
                bitMap.Save(memStream, ImageFormat.Jpeg);
                gph.Dispose();
                bitMap.Dispose();

                image = Image.FromStream(memStream);
            }
            catch (Exception)
            {
                image = new Bitmap(width, height);
            }

            return image;
        }

        /// <summary>
        /// 验证字符序列
        /// </summary>
        public String AuthCode
        {
            get
            {
                return authCode;
            }
            set
            {
                authCode = value;
            }
        }

        /// <summary>
        /// 产生一种 R,G,B 均大于 colorBase 随机颜色，以确保颜色不会过深
        /// </summary>
        /// <returns>背景色</returns>
        private Color GetNoiseColor(int colorBase)
        {
            if (colorBase > 200)
            {
                colorBase = 0;
            }
            Random random = new Random();
            //确保 R,G,B 均大于 colorBase，这样才能保证背景色较浅
            return Color.FromArgb(random.Next(56) + colorBase, random.Next(56) + colorBase, random.Next(56) + colorBase);
        }

        /// <summary>
        /// 扭曲图片
        /// </summary>
        /// <param name="srcBmp"></param>
        /// <param name="bXDir"></param>
        /// <param name="dMultValue"></param>
        /// <param name="dPhase"></param>
        /// <returns></returns>
        private Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            int leftMargin = 0;
            int rightMargin = 0;
            int topMargin = 0;
            int bottomMargin = 0;
            //float PI = 3.14159265358979f;
            float PI2 = 6.28318530717959f;
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            double dBaseAxisLen = bXDir ? Convert.ToDouble(destBmp.Height) : Convert.ToDouble(destBmp.Width);
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? PI2 * Convert.ToDouble(j) / dBaseAxisLen : PI2 * Convert.ToDouble(i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    //取得当前点的颜色        
                    int nOldX = 0;
                    int nOldY = 0;
                    nOldX = bXDir ? i + Convert.ToInt32(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + Convert.ToInt32(dy * dMultValue);
                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= leftMargin && nOldX < destBmp.Width - rightMargin && nOldY >= bottomMargin && nOldY < destBmp.Height - topMargin)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }

        /// <summary>
        /// 判断验证码是否正确
        /// </summary>
        /// <param name="inputValCode">待判断的验证码</param>
        /// <returns>正确返回 true,错误返回 false</returns>
        public bool IsRight(string inputValCode)
        {
            if (AuthCode.ToUpper().Equals(inputValCode.ToUpper()))//无论输入大小写都转换为大些判断
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 读取或设置字符个数
        /// </summary>
        public int CodeNum
        {
            get
            {
                return codeNum;
            }
            set
            {
                codeNum = value;
                if (codeNum < 1)
                {
                    codeNum = 3;
                }
            }
        }

        /// <summary>
        /// 获取字体大小
        /// </summary>
        public int FontSize
        {
            get
            {
                return fontSize;
            }
        }

        /// <summary>
        /// 图片宽度
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                this.width = value;
                if (width < 20)
                {
                    width = 80;
                }
            }
        }

        /// <summary>
        /// 图片高度
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                this.height = value;
                if (height < 20)
                {
                    height = 20;
                }
            }
        }

        public bool TwistImg
        {
            get
            {
                return twistImg;
            }
            set
            {
                twistImg = value;
            }
        }
    }
}