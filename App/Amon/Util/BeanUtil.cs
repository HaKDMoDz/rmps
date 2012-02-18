using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using Me.Amon.Uc;

namespace Me.Amon.Util
{
    public class BeanUtil
    {
        public static IApp IApp { get; set; }

        public static void Clear(ComboBox cBox)
        {
            if (cBox.Items.Count < 1)
            {
                return;
            }
            int idx = cBox.SelectedIndex;
            for (int i = cBox.Items.Count - 1; i > 0; i -= 1)
            {
                cBox.Items.RemoveAt(i);
            }
            if (idx != 0)
            {
                cBox.SelectedIndex = 0;
            }
        }

        public static void Clear(ComboBox cBox, Item[] items)
        {
            int idx = cBox.SelectedIndex;
            for (int i = cBox.Items.Count - 1; i > 1; i -= 1)
            {
                cBox.Items.RemoveAt(i);
            }
            cBox.Items.AddRange(items);
            if (idx != 0)
            {
                cBox.SelectedIndex = 0;
            }
        }

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

        public static Image ReadImage(string file, Image defImg)
        {
            if (!File.Exists(file))
            {
                return defImg;
            }
            using (Stream stream = File.OpenRead(file))
            {
                return Image.FromStream(stream);
            }
        }

        public static void DoZip(string srcPath, string zipFile)
        {
            Crc32 crc = new Crc32();
            ZipOutputStream oStream = new ZipOutputStream(File.Create(zipFile));
            oStream.SetLevel(6);

            foreach (string file in Directory.GetFiles(srcPath))
            {
                if (File.Exists(file))
                {
                    continue;
                }

                ZipEntry zipEntry = new ZipEntry(file);
                zipEntry.DateTime = DateTime.Now;

                //打开压缩文件   
                FileStream iStream = File.OpenRead(file);
                zipEntry.Size = iStream.Length;
                oStream.PutNextEntry(zipEntry);

                byte[] buf = new byte[4096];
                int len = iStream.Read(buf, 0, buf.Length);
                crc.Reset();
                while (len > 0)
                {
                    crc.Update(buf);
                    oStream.Write(buf, 0, buf.Length);
                    len = iStream.Read(buf, 0, buf.Length);
                }
                iStream.Close();

                zipEntry.Crc = crc.Value;
            }

            oStream.Finish();
            oStream.Close();
        }

        public static void UnZip(string zipFile, string dstPath)
        {
            if (!File.Exists(zipFile))
            {
                return;
            }
            if (!Directory.Exists(dstPath))
            {
                Directory.CreateDirectory(dstPath);
            }

            ZipInputStream iStream = new ZipInputStream(File.OpenRead(zipFile));
            while (true)
            {
                ZipEntry zipEntry = iStream.GetNextEntry();
                if (zipEntry == null)
                {
                    break;
                }

                string zipName = zipEntry.Name;
                if (string.IsNullOrEmpty(zipName))
                {
                    continue;
                }

                if (zipEntry.IsDirectory)
                {
                    Directory.CreateDirectory(dstPath + zipName);
                    continue;
                }
                if (zipEntry.IsFile)
                {
                    //解压文件到指定的目录   
                    FileStream oStream = File.Create(dstPath + zipEntry.Name);
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
    }
}
