using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanCall : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private Att _Att;

        #region 构造函数
        public BeanCall()
        {
            InitializeComponent();
        }

        public BeanCall(BeanBody body)
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

            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtOpt.Image = viewModel.GetImage("att-call-options");
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
                _Label.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            if (!string.IsNullOrEmpty(TbData.Text))
            {
                Clipboard.SetText(TbData.Text);
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            string call = TbData.Text.Trim();
            if (call.Length > 0 && !CharUtil.IsValidateCall(call))
            {
                MessageBox.Show("无效的电话号码！");
                TbData.Focus();
                return false;
            }

            if (call != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }
            return true;
        }
        #endregion

        #region 事件处理
        #region 按钮事件
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }
        #endregion
        #endregion
    }
}
