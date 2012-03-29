using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanLink : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private Att _Att;

        #region 构造函数
        public BeanLink()
        {
            InitializeComponent();
        }

        public BeanLink(BeanBody body)
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

            BtOpen.Image = viewModel.GetImage("att-link-open");
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

        #region 按钮事件
        private void BtOpen_Click(object sender, EventArgs e)
        {
            string link = TbData.Text.Trim();
            if (string.IsNullOrEmpty(link))
            {
                return;
            }

            if (!Regex.IsMatch(link, "^\\w+://.+", RegexOptions.IgnoreCase))
            {
                link = "http://" + link;
            }

            try
            {
                Process.Start(link);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
        #endregion
        #endregion
    }
}
