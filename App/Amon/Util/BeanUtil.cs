﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace Me.Amon.Util
{
    public class BeanUtil
    {
        public static Stream Open(string path, string file)
        {
            if (Regex.IsMatch(file, "^[a-zA-z]{2,}:/{2,3}[^\\s]+"))
            {
                return WebRequest.Create(file).GetRequestStream();
            }

            if (!Path.IsPathRooted(file))
            {
                file = Path.Combine(path, file);
            }

            if (File.Exists(file))
            {
                return File.OpenRead(file);
            }

            return null;
        }

        public static GraphicsPath CreateRoundedRectanglePath(int x, int y, int w, int h, int aw, int ah)
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

        #region 窗口位置
        public static void CenterToParent(Form child, Form parent)
        {
            if (parent != null && parent.Visible)
            {
                Point point = parent.Location;
                point.X += (parent.Width - child.Width) >> 1;
                point.Y += (parent.Height - child.Height) >> 1;
                child.Location = point;
            }
            else
            {
                CenterToScreen(child);
            }
        }

        public static void CenterToScreen(Form window)
        {
            Point point = new Point();
            point.X = (SystemInformation.WorkingArea.Width - window.Width) >> 1;
            point.Y = (SystemInformation.WorkingArea.Height - window.Height) >> 1;
            window.Location = point;
        }
        #endregion

        #region 文件复制
        public static void Copy(string src, string dst, bool overwrite, bool copySubDir)
        {
            if (File.Exists(src))
            {
                File.Copy(src, dst, overwrite);
                return;
            }

            if (!Directory.Exists(src))
            {
                return;
            }
            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
            }

            DoCopy(src, dst, overwrite, copySubDir);
        }

        private static void DoCopy(string src, string dst, bool overwrite, bool copySubDir)
        {
            if (copySubDir)
            {
                foreach (string dir in Directory.GetDirectories(src))
                {
                    string tmp = Path.Combine(dst, Path.GetDirectoryName(dir));
                    if (!Directory.Exists(tmp))
                    {
                        Directory.CreateDirectory(tmp);
                    }
                    DoCopy(dir, tmp, overwrite, copySubDir);
                }
            }

            foreach (string file in Directory.GetFiles(src))
            {
                string tmp = Path.Combine(dst, Path.GetFileName(file));
                if (File.Exists(tmp))
                {
                    if (!overwrite)
                    {
                        continue;
                    }
                    File.SetAttributes(tmp, FileAttributes.Normal);
                }
                File.Copy(file, tmp, true);
            }
        }
        #endregion

        #region 图像处理
        private static Image _NaN16;
        public static Image NaN16
        {
            get
            {
                if (_NaN16 == null)
                {
                    _NaN16 = new Bitmap(16, 16);
                }
                return _NaN16;
            }
        }

        private static Image _NaN24;
        public static Image NaN24
        {
            get
            {
                if (_NaN24 == null)
                {
                    _NaN24 = new Bitmap(24, 24);
                }
                return _NaN24;
            }
        }

        private static Image _NaN32;
        public static Image NaN32
        {
            get
            {
                if (_NaN32 == null)
                {
                    _NaN32 = new Bitmap(32, 32);
                }
                return _NaN32;
            }
        }

        public static Image ReadImage(string file, Image defImg)
        {
            if (Regex.IsMatch(file, "^[a-zA-z]{2,}:/{2,3}[^\\s]+"))
            {
                Stream stream = WebRequest.Create(file).GetRequestStream();
                try
                {
                    Image img = Image.FromStream(stream);
                    stream.Close();
                    return img;
                }
                catch (Exception exp)
                {
                    Main.LogInfo(exp.Message);
                    return defImg;
                }
            }

            if (File.Exists(file))
            {
                return Image.FromFile(file);
            }
            return defImg;
        }

        public static Image ReadImage(string path, string file, Image defImg)
        {
            if (Regex.IsMatch(file, "^[a-zA-z]{2,}:/{2,3}[^\\s]+"))
            {
                try
                {
                    Stream stream = WebRequest.Create(file).GetResponse().GetResponseStream();
                    Image img = Image.FromStream(stream);
                    stream.Close();
                    return img;
                }
                catch (Exception exp)
                {
                    Main.LogInfo(exp.Message);
                    return defImg;
                }
            }

            if (!Path.IsPathRooted(file))
            {
                file = Path.Combine(path, file);
            }

            if (!File.Exists(file))
            {
                return defImg;
            }
            return Image.FromFile(file);
        }

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
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(img, x, y, w, h);
            g.Flush();
            g.Dispose();

            return bmp;
        }
        #endregion

        #region 压缩处理
        public static void DoZip(string zipFile, string srcBase, params string[] srcPath)
        {
            if (srcBase == null)
            {
                srcBase = "" + Path.DirectorySeparatorChar;
            }
            if (srcBase[srcBase.Length - 1] != Path.DirectorySeparatorChar)
            {
                srcBase += Path.DirectorySeparatorChar;
            }

            ZipOutputStream oStream = new ZipOutputStream(File.Create(zipFile));
            oStream.SetLevel(6);
            Crc32 crc = new Crc32();

            if (srcPath == null || srcPath.Length < 1)
            {
                DoZipPath(oStream, crc, srcBase, srcBase);
            }
            else
            {
                foreach (string path in srcPath)
                {
                    if (Directory.Exists(path))
                    {
                        DoZipPath(oStream, crc, path, srcBase);
                        continue;
                    }
                    if (File.Exists(path))
                    {
                        DoZipFile(oStream, crc, path, srcBase);
                        continue;
                    }
                }
            }

            oStream.Finish();
            oStream.Close();
        }

        private static void DoZipPath(ZipOutputStream oStream, Crc32 crc, string srcPath, string srcBase)
        {
            foreach (string subPath in Directory.GetDirectories(srcPath))
            {
                DoZipPath(oStream, crc, subPath, srcBase);
            }

            foreach (string file in Directory.GetFiles(srcPath))
            {
                DoZipFile(oStream, crc, file, srcBase);
            }
        }

        private static void DoZipFile(ZipOutputStream oStream, Crc32 crc, string srcFile, string srcBase)
        {
            if (!File.Exists(srcFile))
            {
                return;
            }

            ZipEntry zipEntry = new ZipEntry(srcFile.Replace(srcBase, ""));
            zipEntry.DateTime = DateTime.Now;

            //打开压缩文件   
            FileStream iStream = File.OpenRead(srcFile);
            zipEntry.Size = iStream.Length;
            oStream.PutNextEntry(zipEntry);

            byte[] buf = new byte[4096];
            int len = iStream.Read(buf, 0, buf.Length);
            crc.Reset();
            while (len > 0)
            {
                crc.Update(buf, 0, len);
                oStream.Write(buf, 0, len);
                len = iStream.Read(buf, 0, buf.Length);
            }
            iStream.Close();

            zipEntry.Crc = crc.Value;
        }

        public static void UnZip(string zipFile, string dstPath, string egnore = ".db")
        {
            if (!File.Exists(zipFile))
            {
                return;
            }
            if (!Directory.Exists(dstPath))
            {
                Directory.CreateDirectory(dstPath);
            }

            bool hasEgnore = !string.IsNullOrWhiteSpace(egnore);
            ZipInputStream iStream = new ZipInputStream(File.OpenRead(zipFile));
            while (true)
            {
                ZipEntry zipEntry = iStream.GetNextEntry();
                if (zipEntry == null)
                {
                    break;
                }

                string zipName = zipEntry.Name;
                if (string.IsNullOrEmpty(zipName) || (hasEgnore && zipName.EndsWith(egnore)))
                {
                    continue;
                }

                if (zipEntry.IsDirectory)
                {
                    Directory.CreateDirectory(Path.Combine(dstPath, zipName));
                    continue;
                }
                if (zipEntry.IsFile)
                {
                    //解压文件到指定的目录   
                    FileStream oStream = File.Create(Path.Combine(dstPath, zipEntry.Name));
                    byte[] buf = new byte[4096];
                    int len = iStream.Read(buf, 0, buf.Length);
                    while (len > 0)
                    {
                        oStream.Write(buf, 0, len);
                        len = iStream.Read(buf, 0, buf.Length);
                    }
                    oStream.Close();
                }
            }
            iStream.Close();
        }
        #endregion
    }
}
