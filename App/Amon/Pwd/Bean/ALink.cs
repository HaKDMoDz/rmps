using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Me.Amon.Pwd.Bean
{
    public partial class ALink : UserControl
    {
        protected Att _Att;
        private TextBox _Box;
        private ToolStripMenuItem _LastItem;

        #region 构造函数
        public ALink()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        protected void InitSpec(TextBox box)
        {
            _Box = box;
        }

        protected void ShowSpec(Control ctl)
        {
        }

        protected void OpenLink()
        {
            string link = _Box.Text.Trim();
            if (string.IsNullOrEmpty(link))
            {
                return;
            }

            if (!Regex.IsMatch(link, "^\\w+://.+", RegexOptions.IgnoreCase))
            {
                link = "http://" + link;
            }

            try
            {
                Process.Start(link);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
        #endregion

        #region 事件处理
        private void MiMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            string tag = item.Tag as string;
            if (string.IsNullOrWhiteSpace(tag))
            {
                return;
            }


            if (_LastItem != null)
            {
                _LastItem.Checked = false;
            }
            _LastItem = item;
            _LastItem.Checked = true;
        }
        #endregion
    }
}
