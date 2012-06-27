using System;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void Show(Form owner, string message, string deftext)
        {
            LbTips.Text = message;
            TbText.Text = deftext;
            ShowDialog(owner);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbText.Text))
            {
                TbText.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Visible = false;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Visible = false;
        }

        public string Message
        {
            get
            {
                return TbText.Text;
            }
        }
    }
}
