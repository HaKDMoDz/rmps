using System;
using System.Windows.Forms;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V
{
    public partial class FavMgr : Form
    {
        private DataModel _DataModel;

        public FavMgr()
        {
            InitializeComponent();
        }

        public FavMgr(DataModel dataModel)
        {
            InitializeComponent();

            Icon = Me.Amon.Properties.Resources.Icon;
        }

        private void BnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
