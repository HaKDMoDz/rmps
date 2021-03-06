﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public partial class AttMail : AMail, IAttViewer
    {
        private KeyBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;

        #region 构造函数
        public AttMail()
        {
            InitializeComponent();
        }

        public AttMail(KeyBody body)
        {
            _Body = body;

            InitializeComponent();
        }

        public void InitOnce(TableLayoutPanel grid, ViewModel viewModel)
        {
            _Grid = grid;
            _Style = new RowStyle(SizeType.Absolute, 27F);

            Dock = DockStyle.Fill;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtSend.Image = viewModel.GetImage("att-mail-send");
            _Body.ShowTips(BtSend, "撰写邮件");
            BtCopy.Image = viewModel.GetImage("att-copy");
            _Body.ShowTips(BtCopy, "复制");
            BtFill.Image = viewModel.GetImage("script-fill-16");
            _Body.ShowTips(BtFill, "填充");

            InitSpec(TbData);
        }
        #endregion

        #region 接口实现
        public int InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);

            return 27;
        }

        public bool ShowData(DataModel dataModel, Att att)
        {
            _Att = att;
            if (_Att != null)
            {
                _Label.Text = _Att.Text;
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            TbData.Copy();
        }
        #endregion

        #region 事件处理
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtSend_Click(object sender, EventArgs e)
        {
            OpenMail();
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            SafeUtil.Copy(TbData.Text);
            TbData.Focus();
        }

        private void BtFill_Click(object sender, EventArgs e)
        {
            _Body.FillData(TbData.Text);
        }
        #endregion
    }
}
