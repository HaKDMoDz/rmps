using System;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Da;

namespace Me.Amon.Uw.Ico
{
    public partial class DirEdit : UserControl
    {
        private IcoSeeker _IcoSeeker;
        private Dir _Item;

        public DirEdit()
        {
            InitializeComponent();
        }

        public DirEdit(IcoSeeker icoSeeker)
        {
            _IcoSeeker = icoSeeker;

            InitializeComponent();
        }

        public void Init()
        {
            TbName.MaxLength = DBConst.AICO0104_SIZE;
            TbTips.MaxLength = DBConst.AICO0105_SIZE;
            TbMemo.MaxLength = DBConst.AICO0107_SIZE;

            _IcoSeeker.AcceptButton = BtUpdate;
            _IcoSeeker.CancelButton = BtCancel;
        }

        public void ShowData(Dir item)
        {
            _Item = item;
            TbName.Text = _Item.Name;
            TbTips.Text = _Item.Tips;
            TbMemo.Text = _Item.Memo;
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
            _IcoSeeker.UpdateDir(_Item);
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _IcoSeeker.Close();
        }
    }
}
