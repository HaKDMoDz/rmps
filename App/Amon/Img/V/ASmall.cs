using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Img.V
{
    public partial class ASmall : UserControl, IImg
    {
        #region 全局变量
        private UserModel _UserModel;
        private string _HomeDir;
        private int _IcoSize;
        #endregion

        #region 构造函数
        public ASmall()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
        }

        public Control Control
        {
            get
            {
                return this;
            }
        }

        public void OpenFile(string file)
        {
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
        #endregion

        public AmonHandler<Png> CallBackHandler { get; set; }

        #region 事件处理
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
        }
        #endregion
    }
}
