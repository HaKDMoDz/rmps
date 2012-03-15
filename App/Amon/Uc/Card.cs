using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Util;
using MessagingToolkit.Barcode;
using MessagingToolkit.Barcode.QRCode.Decoder;

namespace Me.Amon.Uc
{
    public class Card
    {

        private SafeModel _SafeModel;

        public Card(SafeModel gridMdl)
        {
            this._SafeModel = gridMdl;
        }

        public string ExportHtm(string src, string dst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(src);

            XmlNode node = doc.SelectSingleNode("/magicpwd/card/template-res");
            string text;
            if (node != null)
            {
                text = node.InnerText;
                if (CharUtil.IsValidate(text))
                {
                    File.Copy(text, Path.Combine(dst, Path.GetFileName(text)));
                }
            }

            node = doc.SelectSingleNode("/magicpwd/card/template-uri");
            if (node == null)
            {
                return null;
            }
            text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return null;
            }

            return _Text(text, dst, ".htm");
        }

        public string ExportTxt(string src, string dst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(src);
            XmlNode node = doc.SelectSingleNode("/magicpwd/card/template-uri");
            if (node == null)
            {
                return null;
            }
            string text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return null;
            }

            return _Text(text, dst, ".txt");
        }

        public string ExportPng(string src, string dst)
        {
            Stream stream = File.OpenRead(src);
            string text = _Trim(stream);
            stream.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);
            return _Draw(doc, dst);
        }

        public string ExportSvg(string src, string dst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(src);
            XmlNode node = doc.SelectSingleNode("/magicpwd/card/template-uri");
            if (node == null)
            {
                return null;
            }
            string text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return null;
            }

            return _Text(text, dst, ".svg");
        }

        public string ExportVcf(string src, string dst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(src);
            XmlNode node = doc.SelectSingleNode("/magicpwd/card/template-uri");
            if (node == null)
            {
                return null;
            }
            string text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return null;
            }

            return _Text(text, dst, ".vcf");
        }

        public string ExportQrc(string src, string dst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(src);
            XmlNode node = doc.SelectSingleNode("/magicpwd/card/template-uri");
            if (node == null)
            {
                return null;
            }
            string text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return null;
            }

            FileStream stream = File.OpenRead(src);
            text = _Trim(stream);
            stream.Close();

            try
            {
                BarcodeEncoder barcodeEncoder = new BarcodeEncoder();
                barcodeEncoder.CharacterSet = "UTF-8";
                barcodeEncoder.ErrorCorrectionLevel = ErrorCorrectionLevel.L;
                barcodeEncoder.ForeColor = Color.Black;
                barcodeEncoder.BackColor = Color.White;
                barcodeEncoder.QuietZone = 1;
                barcodeEncoder.Width = 230;
                barcodeEncoder.Height = 230;
                Image img = barcodeEncoder.Encode(BarcodeFormat.QRCode, "");

                AAtt item = _SafeModel.GetAtt(AAtt.PWDS_HEAD_META);
                dst = Path.Combine(dst, item.Name + ".png");

                img.Save(dst, ImageFormat.Png);
                return dst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ExportAll(string src, string dst)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(src);

            XmlNode node = doc.SelectSingleNode("/magicpwd/card/template-res");
            String text;
            if (node != null)
            {
                text = node.InnerText;
                if (CharUtil.IsValidate(text))
                {
                    File.Copy(text, Path.Combine(dst, Path.GetFileName(text)));
                }
            }

            node = doc.SelectSingleNode("/magicpwd/card/template-uri");
            if (node == null)
            {
                return null;
            }
            text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return null;
            }

            int si = text.LastIndexOf('/');
            int di = text.LastIndexOf('.');
            String ext = "";
            if (di > si)
            {
                ext = text.Substring(di);
            }
            return _Text(text, dst, ext);
        }

        private string _Trim(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);

            StringBuilder buffer = new StringBuilder();
            char[] buf = new char[1024];
            int len = reader.Read(buf, 0, buf.Length);
            while (len > 0)
            {
                buffer.Append(buf, 0, len);
                len = reader.Read(buf, 0, buf.Length);
            }

            reader.Close();
            stream.Close();

            //AAtt item;
            //for (int i = AAtt.HEAD_SIZE, j = _SafeModel.Count; i < j; i += 1)
            //{
            //    item = _SafeModel.GetAtt(i);
            //    buffer.Replace('#' + item.Name + '#', item.Data);
            //}

            return buffer.ToString();
        }

        private string _Text(string src, string dst, string ext)
        {
            FileStream stream = File.OpenRead(src);
            string text = _Trim(stream);
            stream.Close();

            AAtt item = _SafeModel.GetAtt(AAtt.PWDS_HEAD_META);
            dst = Path.Combine(dst, item.Name + ext);

            stream = File.Exists(dst) ? File.OpenWrite(dst) : File.Create(dst);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            writer.Close();
            stream.Close();

            return dst;
        }

        private string _Draw(XmlDocument doc, string dst)
        {
            int w = 400;
            int h = 240;
            Color c = Color.Transparent;
            String p = "";
            String s = "";
            XmlNode node = doc.SelectSingleNode("/magicpwd/card/base");
            if (node != null)
            {
                w = ReadInt(node, "width", w);
                h = ReadInt(node, "height", h);
                c = ReadColor(node, "background-color", Color.Transparent);
                p = ReadString(node, "background-image", "");
                s = ReadString(node, "background-image-style", "stretch").ToLower();
            }

            Image image = new Bitmap(w, h);
            Graphics g2d = Graphics.FromImage(image);
            g2d.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g2d.SmoothingMode = SmoothingMode.HighQuality;

            if (c != Color.Transparent)
            {
                g2d.FillRectangle(new SolidBrush(c), 0, 0, w, h);
            }

            if (CharUtil.IsValidate(p))
            {
                Image img = BeanUtil.ReadImage(p, null);
                if (img != null)
                {
                    if ("stretch" == s)
                    {
                        g2d.DrawImage(img, 0, 0, w, h);
                    }
                    else if ("scale" == s)
                    {
                        int w1 = img.Width;
                        int h1 = img.Height;
                        double dw = w / (double)w1;
                        double dh = h / (double)h1;
                        double d = dw < dh ? dw : dh;
                        w1 = (int)(w1 * d);
                        h1 = (int)(h1 * d);
                        g2d.DrawImage(img, (w - w1) >> 1, (h - h1) >> 1, w1, h1);
                    }
                    else if ("fixed" == s)
                    {
                        int w1 = img.Width;
                        int h1 = img.Height;
                        g2d.DrawImage(img, (w - w1) >> 1, (h - h1) >> 1, w1, h1);
                    }
                    else if ("repeat" == s)
                    {
                        int w1 = img.Width;
                        int h1 = img.Height;
                        for (int y1 = 0; y1 < h; y1 += h1)
                        {
                            for (int x1 = 0; x1 < w; x1 += w1)
                            {
                                g2d.DrawImage(img, x1, y1, w1, h1);
                            }
                        }
                    }
                }
            }

            string text;
            XmlNodeList list = doc.SelectNodes("/magicpwd/card/draw");
            if (list != null)
            {
                for (int i = 0, j = list.Count; i < j; i += 1)
                {
                    node = list[i];
                    text = ReadString(node, "method", "").ToLower();
                    if (!CharUtil.IsValidate(text))
                    {
                        continue;
                    }
                    if ("text" == text)
                    {
                        DrawString(node, g2d);
                        continue;
                    }
                    if ("image" == text)
                    {
                        DrawImage(node, g2d);
                        continue;
                    }
                    if ("line" == text)
                    {
                        DrawLine(node, g2d);
                        continue;
                    }
                    if ("rect" == text)
                    {
                        DrawRect(node, g2d);
                        continue;
                    }
                    if ("round-rect" == text)
                    {
                        DrawRoundRect(node, g2d);
                        continue;
                    }
                    if ("arc" == text)
                    {
                        drawArc(node, g2d);
                        continue;
                    }
                    if ("polygon" == text)
                    {
                        drawPolygon(node, g2d);
                        continue;
                    }
                }
            }

            //AAtt item = _SafeModel.GetAtt(AAtt.PWDS_HEAD_META);
            //dst = Path.Combine(dst, item.Name + ".png");
            dst = Path.Combine(dst, "a.png");
            image.Save(dst, ImageFormat.Png);

            return dst;
        }

        internal static void DrawString(XmlNode node, Graphics g)
        {
            if (node == null)
            {
                return;
            }
            String text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return;
            }

            Font f = ReadFont(node);
            Brush b = ReadBrush(node);
            int x = ReadInt(node, "x", 0);
            int y = ReadInt(node, "y", 0);
            g.DrawString(text, f, b, x, y);
        }

        internal static void DrawImage(XmlNode node, Graphics g)
        {
            if (node == null)
            {
                return;
            }
            String text = node.InnerText;
            if (!CharUtil.IsValidate(text))
            {
                return;
            }

            Image img = BeanUtil.ReadImage(text, null);
            if (img != null)
            {
                int x = ReadInt(node, "x", 0);
                int y = ReadInt(node, "y", 0);
                int w = ReadInt(node, "width", img.Width);
                int h = ReadInt(node, "height", img.Height);
                g.DrawImage(img, x, y, w, h);
            }
        }

        internal static void DrawLine(XmlNode node, Graphics g)
        {
            if (node == null)
            {
                return;
            }

            Brush b = ReadBrush(node);
            Pen p = new Pen(b, ReadInt(node, "width", 1));
            int x1 = ReadInt(node, "x1", 0);
            int y1 = ReadInt(node, "y1", 0);
            int x2 = ReadInt(node, "x2", 0);
            int y2 = ReadInt(node, "y2", 0);
            g.DrawLine(p, x1, y1, x2, y2);
        }

        internal static void DrawRect(XmlNode node, Graphics g)
        {
            if (node == null)
            {
                return;
            }

            int x = ReadInt(node, "x", 0);
            int y = ReadInt(node, "y", 0);
            int w = ReadInt(node, "width", 2);
            int h = ReadInt(node, "height", 2);
            Color c = ReadColor(node, "color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g.FillRectangle(new SolidBrush(c), x, y, w, h);
            }

            c = ReadColor(node, "border-color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g.DrawRectangle(new Pen(c, ReadInt(node, "border-width", 1)), x, y, w, h);
            }
        }

        internal static void DrawRoundRect(XmlNode node, Graphics g)
        {
            if (node == null)
            {
                return;
            }

            int x = ReadInt(node, "x", 0);
            int y = ReadInt(node, "y", 0);
            int w = ReadInt(node, "width", 2);
            int h = ReadInt(node, "height", 2);
            int aw = ReadInt(node, "arc-width", 1);
            int ah = ReadInt(node, "arc-height", 1);
            Color c = ReadColor(node, "color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g.FillPath(new SolidBrush(c), CreateRoundedRectanglePath(x, y, w, h, aw, ah));
            }

            c = ReadColor(node, "border-color", Color.Black);
            g.DrawPath(new Pen(c, ReadInt(node, "border-width", 1)), CreateRoundedRectanglePath(x, y, w, h, aw, ah));
        }

        internal static GraphicsPath CreateRoundedRectanglePath(int x, int y, int w, int h, int aw, int ah)
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

        internal static void drawArc(XmlNode node, Graphics g2d)
        {
            if (node == null)
            {
                return;
            }

            int x = ReadInt(node, "x", 0);
            int y = ReadInt(node, "y", 0);
            int w = ReadInt(node, "width", 2);
            int h = ReadInt(node, "height", 2);
            int sa = ReadInt(node, "start-angle", 1);
            int aa = ReadInt(node, "arc-angle", 1);
            Color c = ReadColor(node, "color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g2d.FillPie(new SolidBrush(c), x, y, w, h, sa, aa);
            }

            c = ReadColor(node, "border-color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g2d.DrawArc(new Pen(c, ReadInt(node, "border-width", 1)), x, y, w, h, sa, aa);
            }
        }

        internal static void drawPolygon(XmlNode node, Graphics g2d)
        {
            if (node == null)
            {
                return;
            }

            String sx = ReadString(node, "x-array", "");
            String sy = ReadString(node, "y-array", "");
            if (!CharUtil.IsValidate(sx) || !CharUtil.IsValidate(sy))
            {
                return;
            }

            String[] ax = Regex.Split(sx, "[^\\d]");
            String[] ay = Regex.Split(sy, "[^\\d]");
            if (ax == null || ay == null || ax.Length < 1 || ax.Length != ay.Length)
            {
                return;
            }

            Point[] p = new Point[ax.Length];
            for (int i = 0; i < ax.Length; i += 1)
            {
                p[i] = new Point(int.Parse(ax[i]), int.Parse(ay[i]));
            }

            Color c = ReadColor(node, "color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g2d.FillPolygon(new SolidBrush(c), p);
            }

            c = ReadColor(node, "border-color", Color.Transparent);
            if (c != Color.Transparent)
            {
                g2d.DrawPolygon(new Pen(c, ReadInt(node, "border-width", 1)), p);
            }
        }

        internal static int ReadInt(XmlNode node, string prop, int dval)
        {
            int v = dval;
            if (node != null)
            {
                XmlAttribute attr = node.Attributes[prop];
                if (attr != null)
                {
                    prop = (attr.Value ?? "").Trim();
                    if (Regex.IsMatch(prop, "^\\d+$"))
                    {
                        v = int.Parse(prop);
                    }
                }
            }
            return v;
        }

        internal static String ReadString(XmlNode node, string prop, string dval)
        {
            String t = dval;
            if (node != null)
            {
                XmlAttribute attr = node.Attributes[prop];
                if (attr != null)
                {
                    prop = attr.Value;
                    if (CharUtil.IsValidate(prop))
                    {
                        t = prop;
                    }
                }
            }
            return t;
        }

        internal static Color ReadColor(XmlNode node, String prop, Color dval)
        {
            Color t = dval;
            if (node != null)
            {
                XmlAttribute attr = node.Attributes[prop];
                if (attr != null)
                {
                    prop = (attr.Value ?? "").ToLower();
                    if (Regex.IsMatch(prop, "^[#]?[0123456789abcdef]{6,8}$"))
                    {
                        if (prop[0] == '#')
                        {
                            prop = prop.Substring(1);
                        }
                        if (prop.Length < 8)
                        {
                            prop = prop.PadLeft(8, 'f');
                        }
                        t = Color.FromArgb(Convert.ToInt32(prop, 16));
                    }
                }
            }
            return t;
        }

        internal static Brush ReadBrush(XmlNode node)
        {
            return new SolidBrush(ReadColor(node, "color", Color.Black));
        }

        internal static Font ReadFont(XmlNode node)
        {
            int tmp = ReadInt(node, "font-style", 0);
            FontStyle style = (FontStyle)tmp;
            return new Font(ReadString(node, "font-name", "Dialog"), ReadInt(node, "font-size", 12), style);
        }
    }
}
