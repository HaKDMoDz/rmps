using System;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        public void Show(Form owner, Exception error)
        {
            LbInfo.Text = error.Message;
            TbInfo.Text = error.StackTrace;
            ShowDialog(owner);
        }
    }
}
