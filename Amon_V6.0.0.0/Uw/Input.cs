using System;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        public void Show(Form owner, string message, string deftext)
        {
            LbTips.Text = message;
            TbText.Text = deftext;
            TbText.Focus();
            ShowDialog(owner);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbText.Text))
            {
                DialogResult = DialogResult.OK;
                Visible = false;
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Visible = false;
        }

        private void Input_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Visible = false;
            //e.Cancel = false;
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
