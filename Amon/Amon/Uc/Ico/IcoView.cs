using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Me.Amon.Util;
using System.Drawing.Imaging;

namespace Me.Amon.Uc.Ico
{
    public partial class IcoView : UserControl
    {
        private IcoEdit _IcoEdit;

        public IcoView()
        {
            InitializeComponent();
        }

        public IcoView(IcoEdit icoEdit)
        {
            _IcoEdit = icoEdit;

            InitializeComponent();
        }

        public void ShowData(string path)
        {
            int i = 1;
            LvIco.Items.Clear();
            IlIco.Images.Clear();
            foreach (string file in Directory.GetFiles(path, "*.png"))
            {
                string key = file.Substring(0, 16);
                IlIco.Images.Add(key, Image.FromFile(file));
                LvIco.Items.Add(new ListViewItem((i++).ToString(), key));
            }
        }

        private void BtChoose_Click(object sender, EventArgs e)
        {
            if (LvIco.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择");
                LvIco.Focus();
                return;
            }

            _IcoEdit.SelectedItem = LvIco.SelectedItems[0];
            _IcoEdit.DialogResult = DialogResult.OK;
            _IcoEdit.Close();
        }

        private void BtAppend_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "PNG文件|*.png";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            if (File.Exists(fd.FileName))
            {
                MessageBox.Show("您选择的文件不存在！");
                return;
            }
            using (Image img = Image.FromFile(fd.FileName))
            {
                Bitmap bmp = new Bitmap(IEnv.ICON_DIM, IEnv.ICON_DIM);
                int w = img.Width;
                int h = img.Height;
                if (w != IEnv.ICON_DIM && h != IEnv.ICON_DIM)
                {
                    double rw = (double)IEnv.ICON_DIM / w;
                    double rh = (double)IEnv.ICON_DIM / h;
                    double r = rw <= rh ? rw : rh;
                    w = (int)(r * w);
                    h = (int)(r * h);

                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(img, (IEnv.ICON_DIM - w) >> 1, (IEnv.ICON_DIM - h) >> 1, w, h);
                    g.Flush();
                    g.Dispose();
                }
                string key = HashUtil.GetCurrTimeHex(true);
                bmp.Save(_IcoEdit.CurrentPath + Path.DirectorySeparatorChar + key + ".png", ImageFormat.Png);
                IlIco.Images.Add(key, img);
                _IcoEdit.SelectedItem = new ListViewItem(LvIco.Items.Count.ToString(), key);
                LvIco.Items.Add(_IcoEdit.SelectedItem);
                LvIco.SelectedItems.Clear();
                _IcoEdit.SelectedItem.Selected = true;
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _IcoEdit.Close();
        }
    }
}
