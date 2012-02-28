using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Uw
{
    public partial class PngSeeker : Form
    {
        private UserModel _UserModel;
        private string _HomeDir;
        private int _IcoSize;

        public PngSeeker()
        {
            InitializeComponent();
        }

        public PngSeeker(UserModel userModel, string homeDir)
        {
            _UserModel = userModel;
            _HomeDir = homeDir;

            InitializeComponent();
        }

        public void InitOnce(int icoSize)
        {
            _IcoSize = icoSize;
            IlPng.ImageSize = new Size(icoSize, icoSize);

            int i = 1;
            LvPng.Items.Clear();
            IlPng.Images.Add(BeanUtil.NaN32);
            int index;
            string name;
            foreach (string file in Directory.GetFiles(_HomeDir, "*.png"))
            {
                index = file.LastIndexOf(Path.DirectorySeparatorChar);
                if (index == file.Length - 1)
                {
                    continue;
                }
                name = file.Substring(index + 1);
                index = name.IndexOf('.');
                if (index != 16)
                {
                    continue;
                }
                name = name.Substring(0, 16);
                IlPng.Images.Add(name, BeanUtil.ReadImage(file, BeanUtil.NaN32));
                LvPng.Items.Add(new ListViewItem((i++).ToString(), name));
            }
        }

        public AmonHandler<Img> CallBackHandler { get; set; }

        private void BtAppend_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "PNG文件|*.png|JPG文件|*.jpg|BMP文件|*.bmp";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            if (!File.Exists(fd.FileName))
            {
                MessageBox.Show("您选择的文件不存在！");
                return;
            }
            string name = Path.GetFileName(fd.FileName).ToLower();
            if (!name.EndsWith(".png") && !name.EndsWith(".jpg") && !name.EndsWith(".bmp"))
            {
                return;
            }
            using (Image img = Image.FromFile(fd.FileName))
            {
                int size = _IcoSize;

                Bitmap bmp = new Bitmap(size, size);
                int w = img.Width;
                int h = img.Height;
                if (w != size && h != size)
                {
                    double rw = (double)size / w;
                    double rh = (double)size / h;
                    double r = rw <= rh ? rw : rh;
                    w = (int)(r * w);
                    h = (int)(r * h);

                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(img, (size - w) >> 1, (size - h) >> 1, w, h);
                    g.Flush();
                    g.Dispose();
                }
                string key = HashUtil.UtcTimeInHex(true);
                bmp.Save(_HomeDir + key + ".png", ImageFormat.Png);
                IlPng.Images.Add(key, img);
                var item = new ListViewItem((LvPng.Items.Count + 1).ToString(), key);
                LvPng.Items.Add(item);
                LvPng.SelectedItems.Clear();
                item.Selected = true;
            }
        }

        private void BtSelect_Click(object sender, EventArgs e)
        {
            if (LvPng.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择");
                LvPng.Focus();
                return;
            }

            if (CallBackHandler != null)
            {
                var item = LvPng.SelectedItems[0];
                CallBackHandler.Invoke(new Img { Key = item.ImageKey, Small = IlPng.Images[item.ImageKey] });
            }
            Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
