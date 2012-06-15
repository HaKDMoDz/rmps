using System;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Ico;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Key
{
    public partial class PngList : UserControl
    {
        private KeyIcon _KeyIcon;

        #region 构造函数
        public PngList()
        {
            InitializeComponent();
        }

        public PngList(KeyIcon icoEdit)
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
            Main.OpenFileDialog.Filter = EApp.FILE_OPEN_IMG_RES;
            Main.OpenFileDialog.Multiselect = false;
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog(this))
            {
                return;
            }
            if (!File.Exists(Main.OpenFileDialog.FileName))
            {
                MessageBox.Show("您选择的文件不存在！");
                return;
            }

            string exts = Path.GetExtension(Main.OpenFileDialog.FileName).ToLower();
            if (DealPng(Main.OpenFileDialog.FileName, exts))
            {
                return;
            }
            if (DealIco(Main.OpenFileDialog.FileName, exts))
            {
                return;
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _KeyIcon.Close();
        }
        #endregion

        #region 私有函数
        private bool DealPng(string file, string exts)
        {
            if (!(exts == ".png" || exts == ".jpg" || exts == ".jpe" || exts == ".jpeg" || exts == ".jfif"
                || exts == ".bmp" || exts == ".dib" || exts == ".rle"))
            {
                return false;
            }

            using (Image img = Image.FromFile(file))
            {
                string key = HashUtil.UtcTimeInHex();
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
            return true;
        }

        private bool DealIco(string file, string exts)
        {
            SingleIcon sIcon;
            if (!(exts == ".ico" || exts == ".icl" || exts == ".dll" || exts == ".exe"
                || exts == ".ocx" || exts == ".cpl" || exts == ".src"))
            {
                return false;
            }

            MultiIcon mIcon = new MultiIcon();
            mIcon.Load(file);
            if (mIcon.Count < 1)
            {
                return false;
            }

            if (mIcon.Count == 1)
            {
                sIcon = mIcon[0];
            }
            else
            {
                IcoList dlg = new IcoList(mIcon);
                if (DialogResult.OK != dlg.ShowDialog(this))
                {
                    return false;
                }
                sIcon = dlg.SelectedIcon;
            }

            string key = HashUtil.UtcTimeInHex();
            int[] dim = { 16, 24, 32 };
            Image img;
            foreach (int t in dim)
            {
                img = AIco.GetBitmap(sIcon, t);
                img.Save(Path.Combine(_KeyIcon.HomeDir, key + "." + t), ImageFormat.Png);

                if (_KeyIcon.IcoSize == t)
                {
                    IlIco.Images.Add(key, img);

                    LvIco.SelectedItems.Clear();
                    var item = new ListViewItem((LvIco.Items.Count + 1).ToString(), key);
                    LvIco.Items.Add(item);
                    item.Selected = true;
                }
            }
            return true;
        }
        #endregion
    }
}
