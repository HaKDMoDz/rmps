using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Me.Amon.Kms.V.Cfg
{
    public partial class About : UserControl, IConfig
    {
        public About()
        {
            InitializeComponent();
        }

        #region IConfig 成员

        public void Init()
        {
            LtName.Text = Application.ProductName;
            LtVersion.Text = Application.ProductVersion;
            LtHomepage.Text = "http://amon.me/mkms";
            TbDesp.Text = "　　妙语连珠是一款开放源代码的自动化应答机器人，您可以根据自己的喜好及使用目的进行个性话的对话训练，支持人、程序、剪贴板、网络消息及其它机器人的会话。";
        }

        public bool Save()
        {
            return true;
        }

        public UserControl UserControl
        {
            get { return this; }
        }

        #endregion

        private void LtHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(LtHomepage.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
