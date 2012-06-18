using System;
using System.Windows.Forms;

namespace Me.Amon.Pwd.Bean
{
    public partial class FindBar : UserControl
    {
        public FindBar()
        {
            InitializeComponent();
        }

        public APwd APwd { get; set; }

        private void TbFind_TextChanged(object sender, EventArgs e)
        {
            if (APwd != null)
            {
                APwd.FindKey(TbFind.Text);
            }
        }

        private void BtFind_Click(object sender, EventArgs e)
        {
            if (APwd != null)
            {
                APwd.FindKey(TbFind.Text);
            }
        }
    }
}
