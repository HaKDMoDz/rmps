using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class HotKeys : Form
    {
        public HotKeys()
        {
            InitializeComponent();
        }

        public HotKeys(Icon icon, DataTable dataTable)
        {
            InitializeComponent();

            this.Icon = icon;
            DvKeys.DataSource = dataTable;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
