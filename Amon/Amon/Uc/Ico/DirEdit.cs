using System;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Uc.Ico
{
    public partial class DirEdit : UserControl
    {
        private IcoEdit _IcoEdit;
        private Dir _Item;

        public DirEdit()
        {
            InitializeComponent();
        }

        public DirEdit(IcoEdit icoEdit)
        {
            _IcoEdit = icoEdit;

            InitializeComponent();
        }

        public void Init()
        {
            TbName.MaxLength = IDat.AICO0104_SIZE;
            TbTips.MaxLength = IDat.AICO0105_SIZE;
            TbMemo.MaxLength = IDat.AICO0107_SIZE;

            _IcoEdit.AcceptButton = BtUpdate;
            _IcoEdit.CancelButton = BtCancel;
        }

        public void ShowData(Dir item)
        {
            _Item = item;
            TbName.Text = _Item.Name;
            TbTips.Text = _Item.Tips;
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            string name = TbName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                TbName.Focus();
                return;
            }
            _Item.Name = name;
            _Item.Tips = TbTips.Text;
            _IcoEdit.UpdateDir(_Item);
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _IcoEdit.Close();
        }
    }
}
