using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd.Bean;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanDate : ADate, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;

        #region 构造函数
        public BeanDate()
        {
            InitializeComponent();
        }

        public BeanDate(BeanBody body)
        {
            _Body = body;

            InitializeComponent();
        }

        public void InitOnce(TableLayoutPanel grid, ViewModel viewModel)
        {
            _Grid = grid;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            _Style = new RowStyle(SizeType.Absolute, 27F);
            Dock = DockStyle.Fill;

            DtData.GotFocus += new EventHandler(DtData_GotFocus);

            BtNow.Image = viewModel.GetImage("att-date-now");
            BtOpt.Image = viewModel.GetImage("att-date-options");
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
            if (_Att == null)
            {
                return false;
            }

            _Label.Text = _Att.Name;
            if (CharUtil.IsValidateLong(_Att.Data))
            {
                DtData.Value = DateTime.FromFileTimeUtc(long.Parse(_Att.Data));
            }
            return true;
        }

        public void Copy()
        {
            if (!string.IsNullOrEmpty(DtData.Text))
            {
                Clipboard.SetText(DtData.Text);
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            string date = DtData.Value.ToFileTimeUtc().ToString();
            if (date != _Att.Data)
            {
                _Att.Data = date;
                _Att.Modified = true;
            }
            return true;
        }
        #endregion

        #region 事件处理
        private void DtData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtNow_Click(object sender, EventArgs e)
        {
            DtData.Value = DateTime.Now;
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            CmMenu.Show(BtOpt, 0, BtOpt.Height);
        }
        #endregion
    }
}
