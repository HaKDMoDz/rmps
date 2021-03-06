﻿using System;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd._Key
{
    public partial class DirEditer : UserControl
    {
        private KeyIcon _IcoSeeker;
        private Dir _Item;

        #region 构造函数
        public DirEditer()
        {
            InitializeComponent();
        }

        public DirEditer(KeyIcon icoSeeker)
        {
            _IcoSeeker = icoSeeker;

            InitializeComponent();
        }
        #endregion

        public void Init()
        {
            TbName.MaxLength = DBConst.WICO0104_SIZE;
            TbTips.MaxLength = DBConst.WICO0105_SIZE;
            TbMemo.MaxLength = DBConst.WICO0107_SIZE;

            _IcoSeeker.AcceptButton = BtUpdate;
            _IcoSeeker.CancelButton = BtCancel;
        }

        public void ShowData(Dir item)
        {
            _Item = item;
            TbName.Text = _Item.Text;
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
            _Item.Text = name;
            _Item.Tips = TbTips.Text;
            _IcoSeeker.UpdateDir(_Item);
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _IcoSeeker.Close();
        }
    }
}
