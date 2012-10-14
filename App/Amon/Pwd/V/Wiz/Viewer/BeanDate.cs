using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Viewer
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
            _Style = new RowStyle(SizeType.Absolute, 27F);

            Dock = DockStyle.Fill;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            DtData.GotFocus += new EventHandler(DtData_GotFocus);

            BtNow.Image = viewModel.GetImage("att-date-now");
            _Body.ShowTips(BtNow, "当前时间");
            BtOpt.Image = viewModel.GetImage("att-date-options");
            _Body.ShowTips(BtOpt, "选项");

            BtCopy.Image = viewModel.GetImage("att-copy");
            _Body.ShowTips(BtCopy, "复制");

            InitSpec(DtData);
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

            _Label.Text = _Att.Text;
            string cmd = _Att.GetSpec(DateAtt.SPEC_FORMAT, DateAtt.SPEC_VALUE_NONE);
            if (string.IsNullOrWhiteSpace(cmd))
            {
                DtData.Format = DateTimePickerFormat.Long;
            }
            else
            {
                DtData.Format = DateTimePickerFormat.Custom;
                DtData.CustomFormat = cmd;
            }
            if (CharUtil.IsValidateLong(_Att.Data))
            {
                DtData.Value = DateTime.FromFileTimeUtc(long.Parse(_Att.Data));
            }
            return true;
        }

        public void Cut()
        {
        }

        public void Copy()
        {
            SafeUtil.Copy(DtData.Text);
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
            ShowSpec(BtOpt);
        }

        private void BtCopy_Click(object sender, EventArgs e)
        {
            SafeUtil.Copy(DtData.Text);
            DtData.Focus();
        }
        #endregion
    }
}
