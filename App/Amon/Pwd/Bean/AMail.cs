using System;
using System.Diagnostics;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Bean
{
    public partial class AMail : UserControl
    {
        protected Att _Att;
        private TextBox _Box;
        private ToolStripMenuItem _LastItem;

        #region 构造函数
        public AMail()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        protected void InitSpec(TextBox box)
        {
            _Box = box;

            EventHandler handler = new EventHandler(MiEmail_Click);
            char split = ';';

            MiDefault.Tag = "";
            MiDefault.Click += handler;

            MiWork.Tag = "" + split + "";
            MiWork.Click += handler;
            MiHome.Tag = "" + split + "";
            MiHome.Click += handler;
            MiCompany.Tag = "" + split + "";
            MiCompany.Click += handler;
            MiPhone.Tag = "" + split + "";
            MiPhone.Click += handler;
            MiOther.Tag = "" + split + "";
            MiOther.Click += handler;
        }

        protected void ShowSpec(Control ctl)
        {
        }

        protected void OpenMail()
        {
            string mail = _Box.Text.Trim();
            if (string.IsNullOrEmpty(mail))
            {
                return;
            }
            if (!CharUtil.IsValidateMail(mail))
            {
                MessageBox.Show("无效的邮件地址！");
                _Box.Focus();
                return;
            }

            try
            {
                Process.Start("mailto:" + _Box.Text);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
        #endregion

        #region 事件处理
        private void MiEmail_Click(object sender, EventArgs e)
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
