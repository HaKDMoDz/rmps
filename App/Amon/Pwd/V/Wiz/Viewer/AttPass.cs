﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public partial class AttPass : APass, IAttViewer
    {
        private KeyBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;

        #region 构造函数
        public AttPass()
        {
            InitializeComponent();
        }

        public AttPass(KeyBody body, UserModel userModel)
        {
            _Body = body;
            _UserModel = userModel;

            InitializeComponent();
        }

        public void InitOnce(TableLayoutPanel grid, ViewModel viewModel)
        {
            _Grid = grid;
            _ViewModel = viewModel;
            _Style = new RowStyle(SizeType.Absolute, 27F);

            Dock = DockStyle.Fill;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtMod.Image = viewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            _Body.ShowTips(BtMod, TbData.UseSystemPasswordChar ? "显示口令" : "隐藏口令");
            BtCopy.Image = viewModel.GetImage("att-copy");
            _Body.ShowTips(BtCopy, "复制");
            BtFill.Image = viewModel.GetImage("script-fill-16");
            _Body.ShowTips(BtFill, "填充");
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
            _DataModel = dataModel;
            _Att = att;
            if (_Att == null)
            {
                return false;
            }

            _Label.Text = _Att.Text;
            TbData.Text = _Att.Data;
            return true;
        }

        public void Copy()
        {
            SafeUtil.Copy(TbData.Text);
        }
        #endregion

        #region 事件处理
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtMod_Click(object sender, EventArgs e)
        {
            TbData.UseSystemPasswordChar = !TbData.UseSystemPasswordChar;
            BtMod.Image = _ViewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            _Body.ShowTips(BtMod, TbData.UseSystemPasswordChar ? "显示口令" : "隐藏口令");
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
