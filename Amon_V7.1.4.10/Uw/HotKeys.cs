using System;
using System.Data;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class HotKeys : Form
    {
        public HotKeys()
        {
            InitializeComponent();
        }

        public HotKeys(DataTable dataTable)
        {
            InitializeComponent();

            DvKeys.DataSource = dataTable;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
