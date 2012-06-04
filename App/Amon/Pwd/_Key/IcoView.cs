using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Key
{
    public partial class IcoView : UserControl
    {
        private KeyIcon _KeyIcon;

        #region 构造函数
        public IcoView()
        {
            InitializeComponent();
        }

        public IcoView(KeyIcon icoEdit)
        {
            _KeyIcon = icoEdit;

            InitializeComponent();
        }

        public void InitOnce()
        {
            IlIco.ImageSize = new Size(_KeyIcon.IcoSize, _KeyIcon.IcoSize);

            _KeyIcon.AcceptButton = BtChoose;
            _KeyIcon.CancelButton = BtCancel;
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
            foreach (string file in Directory.GetFiles(path, '*' + EApp.IMG_KEY_LIST_EXT))
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
                IlIco.Images.Add(name, BeanUtil.ReadImage(file, BeanUtil.NaN32));
                LvIco.Items.Add(new ListViewItem((i++).ToString(), name));
            }
        }
        #endregion

        #region 事件处理
        private void BtChoose_Click(object sender, EventArgs e)
        {
            if (LvIco.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择一个图标！");
                LvIco.Focus();
                return;
            }

            _KeyIcon.CallBack(new Png { File = LvIco.SelectedItems[0].ImageKey });
        }

        private void BtAppend_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = EApp.FILE_OPEN_IMG_ICO;
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            if (!File.Exists(fd.FileName))
            {
                MessageBox.Show("您选择的文件不存在！");
                return;
            }

            string exts = Path.GetExtension(fd.FileName).ToLower();
            if (exts == ".png" || exts == ".jpg" || exts == ".jpe" || exts == ".jpeg" || exts == ".jfif"
                || exts == ".bmp" || exts == ".dib" || exts == ".rle")
            {
                using (Image img = Image.FromFile(fd.FileName))
                {
                    string key = HashUtil.UtcTimeInHex(true);
                    int[] dim = { 16, 24, 32 };

                    Image tmp;
                    foreach (int t in dim)
                    {
                        tmp = BeanUtil.ScaleImage(img, t, true);
                        tmp.Save(Path.Combine(_KeyIcon.HomeDir, key + "." + t), ImageFormat.Png);
                        if (_KeyIcon.IcoSize == t)
                        {
                            IlIco.Images.Add(key, tmp);

                            LvIco.SelectedItems.Clear();
                            var item = new ListViewItem((LvIco.Items.Count + 1).ToString(), key);
                            LvIco.Items.Add(item);
                            item.Selected = true;
                        }
                    }
                }
                return;
            }

            if (exts == ".ico")
            {
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _KeyIcon.Close();
        }
        #endregion
    }
}
