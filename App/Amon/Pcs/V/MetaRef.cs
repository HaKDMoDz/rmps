using System;
using System.Windows.Forms;

namespace Me.Amon.Pcs.V
{
    public partial class MetaRef : Form
    {
        public MetaRef()
        {
            InitializeComponent();
        }

        public MetaRef(string uri)
        {
            InitializeComponent();

            TbUri.Text = uri;
        }

        private void BnCopy_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
