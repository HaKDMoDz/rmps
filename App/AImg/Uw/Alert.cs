using System;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }

        public Alert(Icon icon)
        {
            InitializeComponent();

            this.Icon = icon;
        }

        public void Show(IWin32Window owner, string alert)
        {
            TbInfo.Text = alert;
            ShowDialog(owner);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void Alert_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }
    }
}
