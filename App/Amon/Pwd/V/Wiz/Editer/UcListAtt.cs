﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class UcListAtt : AList, IAttEditer
    {
        private KeyBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;

        #region 构造函数
        public UcListAtt()
        {
            InitializeComponent();
        }

        public UcListAtt(KeyBody body)
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

            CbData.GotFocus += new EventHandler(CbData_GotFocus);

            InitSpec();
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
                CbData.SelectedItem = _Att.Data;
            }
            return true;
        }

        public void Cut()
        {
        }

        public void Copy(CopyType type)
        {
        }

        public void Paste()
        {
        }

        public void Clear()
        {
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            //if (CbData.SelectedValue == null)
            //{
            //    return false;
            //}
            //if (CbData.SelectedValue.ToString() != _Att.Data)
            //{
            //    _Att.Data = CbData.SelectedValue.ToString();
            //    _Att.Modified = true;
            //}
            return true;
        }
        #endregion

        #region 事件处理
        private void CbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtFill_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
