using System;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Me.Amon.Ico;

namespace Me.Amon.Pwd._Key
{
    /// <summary>
    /// 资源图标浏览器
    /// </summary>
    public partial class ResViewer : Form
    {
        private MultiIcon _MIcon;

        #region 构造函数
        public ResViewer()
        {
            InitializeComponent();
        }

        public ResViewer(MultiIcon mIcon)
        {
            _MIcon = mIcon;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;

            if (_MIcon != null)
            {
                foreach (SingleIcon sIcon in mIcon)
                {
                    IlIco.Images.Add(sIcon.Name, AIco.GetBitmap(sIcon, 32));
                    LvIco.Items.Add(new ListViewItem { Text = sIcon.Name, ImageIndex = LvIco.Items.Count });
                }
            }
        }
        #endregion

        public SingleIcon SelectedIcon
        {
            get;
            private set;
        }

        #region 事件处理
        private void LvIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoSelect();
        }

        private void BnOk_Click(object sender, EventArgs e)
        {
            DoSelect();
        }

        private void BnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有函数
        private void DoSelect()
        {
            if (_MIcon != null)
            {
                if (LvIco.SelectedItems.Count < 1)
                {
                    return;
                }
                ListViewItem item = LvIco.SelectedItems[0];
                if (item.Index > -1 && item.Index < _MIcon.Count)
                {
                    SelectedIcon = _MIcon[item.Index];
                }

                DialogResult = DialogResult.OK;
            }

            Close();
        }
        #endregion
    }
}
