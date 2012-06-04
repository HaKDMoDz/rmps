using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Pwd;
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

        public AmonHandler<Png> CallBackHandler { get; set; }

        private void BtAppend_Click(object sender, EventArgs e)
        {

        }

        private void BtSelect_Click(object sender, EventArgs e)
        {
            if (LvPng.SelectedItems.Count < 1)
            {
                Main.ShowAlert("请选择一个图标！");
                LvPng.Focus();
                return;
            }

            if (CallBackHandler != null)
            {
                var item = LvPng.SelectedItems[0];
                CallBackHandler.Invoke(new Png { Path = _HomeDir, File = item.ImageKey, LargeImage = IlPng.Images[item.ImageKey] });
            }
            Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LvPng_DoubleClick(object sender, EventArgs e)
        {
            if (LvPng.SelectedItems.Count != 1)
            {
                return;
            }

            if (CallBackHandler != null)
            {
                var item = LvPng.SelectedItems[0];
                CallBackHandler.Invoke(new Png { Path = _HomeDir, File = item.ImageKey, LargeImage = IlPng.Images[item.ImageKey] });
            }
            Close();
        }
    }
}
