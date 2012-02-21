using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Uw.Ico
{
    public partial class IcoView : UserControl
    {
        private IcoEditor _IcoEdit;

        #region 构造函数
        public IcoView()
        {
            InitializeComponent();
        }

        public IcoView(IcoEditor icoEdit)
        {
            _IcoEdit = icoEdit;

            InitializeComponent();
        }

        public void Init()
        {
            _IcoEdit.AcceptButton = BtChoose;
            _IcoEdit.CancelButton = BtCancel;
        }
        #endregion

        #region 事件处理
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
                string key = HashUtil.UtcTimeInHex(true);
                bmp.Save(_IcoEdit.CurrentPath + key + ".png", ImageFormat.Png);
                IlIco.Images.Add(key, img);
                _IcoEdit.SelectedItem = new ListViewItem((LvIco.Items.Count + 1).ToString(), key);
                LvIco.Items.Add(_IcoEdit.SelectedItem);
                LvIco.SelectedItems.Clear();
                _IcoEdit.SelectedItem.Selected = true;
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _IcoEdit.Close();
        }
        #endregion

        #region 公共函数
        public void ShowData(string path)
        {
            int i = 1;
            LvIco.Items.Clear();
            IlIco.Images.Clear();
            IlIco.Images.Add(BeanUtil.NaN32);
            int index;
            string name;
            foreach (string file in Directory.GetFiles(path, "*.png"))
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
                IlIco.Images.Add(name, LoadImage(file));
                LvIco.Items.Add(new ListViewItem((i++).ToString(), name));
            }
        }
        #endregion

        private Image LoadImage(string file)
        {
            if (!File.Exists(file))
            {
                return BeanUtil.NaN32;
            }
            using (Stream stream = File.OpenRead(file))
            {
                return Image.FromStream(stream);
            }
        }
    }
}
