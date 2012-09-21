using System;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        public Error(Icon icon)
        {
            InitializeComponent();

            this.Icon = icon;
        }

        public void Show(Form owner, Exception error)
        {
            LbInfo.Text = error.Message;
            TbInfo.Text = error.StackTrace;
            ShowDialog(owner);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
