using System.Drawing;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Me.Amon.Ico;
using Me.Amon.Util;

namespace Me.Amon.Ico
{
    public partial class IclEditor : UserControl, IIco
    {
        private AIco _AIco;
        private MultiIcon _MIcon;

        #region 构造函数
        public IclEditor()
        {
            InitializeComponent();
        }

        public IclEditor(AIco aico)
        {
            _AIco = aico;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            _MIcon = new MultiIcon();
        }

        public void OpenFile(string file)
        {
            _MIcon.Clear();
            _MIcon.Load(file);

            LvIcl.Items.Clear();
            IlIcl.Images.Clear();

            Image bmp;
            foreach (SingleIcon sIcon in _MIcon)
            {
                bmp = GetBitmap(sIcon);
                IlIcl.Images.Add(sIcon.Name, bmp);
                LvIcl.Items.Add(new ListViewItem { ImageKey = sIcon.Name, Name = sIcon.Name, Text = sIcon.Name });
            }
        }
        #endregion

        #region 事件处理
        private void LvIcl_DoubleClick(object sender, System.EventArgs e)
        {
            if (LvIcl.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem item = LvIcl.SelectedItems[0];
            SingleIcon sIcon = _MIcon[item.Name];
            if (sIcon == null)
            {
                return;
            }
            _AIco.AddTab(item.Text, sIcon);
        }
        #endregion

        #region 私有函数
        private Image GetBitmap(SingleIcon sIcon)
        {
            Image bmp = sIcon.Icon.ToBitmap();
            if (bmp.Width != 32)
            {
                bmp = BeanUtil.ScaleImage(bmp, 32, true);
            }
            return bmp;
        }
        #endregion
    }
}
