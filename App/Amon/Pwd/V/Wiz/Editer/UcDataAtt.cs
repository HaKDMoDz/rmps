﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class UcDataAtt : AData, IAttEditer
    {
        private KeyBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;

        #region 构造函数
        public UcDataAtt()
        {
            InitializeComponent();
        }

        public UcDataAtt(KeyBody body)
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

            BtOpt.Image = viewModel.GetImage("att-data-options");
            _Body.ShowTips(BtOpt, "选项");

            //BtFill.Image = viewModel.GetImage("att-copy");
            //_Body.ShowTips(BtFill, "复制");script-fill-16
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

        public void Cut()
        {
            TbData.Cut();
        }

        public void Copy(CopyType type)
        {
            if (type == CopyType.Data)
            {
                if (!string.IsNullOrEmpty(TbData.Text))
                {
                    Clipboard.SetText(TbData.Text);
                }
                return;
            }

            if (type == CopyType.Selected)
            {
                TbData.Copy();
            }
        }

        public void Paste()
        {
            TbData.Paste();
        }

        public void Clear()
        {
            TbData.Clear();
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }
            return true;
        }
        #endregion

        #region 事件处理
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            ShowSpec(BtOpt);
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            SafeUtil.Copy(TbData.Text);
            TbData.Focus();
        }

        private void BtFill_Click(object sender, EventArgs e)
        {
            _Body.FillData(TbData.Text);
            TbData.Focus();
        }
        #endregion
    }
}
