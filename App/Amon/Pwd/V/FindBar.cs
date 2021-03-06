﻿using System;
using System.Windows.Forms;

namespace Me.Amon.Pwd.V
{
    public partial class FindBar : UserControl, IFindBar
    {
        #region 构造函数
        public FindBar()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public IKeyList KeyList { get; set; }

        public new bool Focus()
        {
            return TbFind.Focus();
        }
        #endregion

        #region 事件处理
        private void TbFind_TextChanged(object sender, EventArgs e)
        {
            if (KeyList != null)
            {
                KeyList.FindKeys(TbFind.Text);
            }
        }

        private void BtFind_Click(object sender, EventArgs e)
        {
            if (KeyList != null)
            {
                KeyList.FindKeys(TbFind.Text);
            }
        }
        #endregion
    }
}
