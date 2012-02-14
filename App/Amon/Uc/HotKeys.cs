using System;
using System.Data;
using System.Windows.Forms;

namespace Me.Amon.Uc
{
    public partial class HotKeys : Form
    {
        public HotKeys()
        {
            InitializeComponent();
        }

        private DataTable _KeyList;
        public DataTable KeyList
        {
            get
            {
                return _KeyList;
            }
            set
            {
                _KeyList = value;
                DvKeys.DataSource = _KeyList;
            }
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
