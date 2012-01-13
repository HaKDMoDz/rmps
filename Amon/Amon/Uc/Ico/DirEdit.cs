using System;
using System.Windows.Forms;

namespace Me.Amon.Uc.Ico
{
    public partial class DirEdit : UserControl
    {
        private IcoEdit _IcoEdit;
        private Item _Item;

        public DirEdit()
        {
            InitializeComponent();
        }

        public DirEdit(IcoEdit icoEdit)
        {
            _IcoEdit = icoEdit;

            InitializeComponent();
        }

        public void ShowData(Item item)
        {
            _Item = item;
            TbName.Text = _Item.V;
            TbTips.Text = _Item.D;
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            string name = TbName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                TbName.Focus();
                return;
            }
            _Item.V = name;
            _Item.D = TbTips.Text;
            _IcoEdit.UpdateDir(_Item);
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _IcoEdit.Close();
        }
    }
}
