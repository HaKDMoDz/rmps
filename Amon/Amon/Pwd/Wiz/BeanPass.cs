using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanPass : UserControl, IAttEdit
    {
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private AAtt _Att;

        #region 构造函数
        public BeanPass()
        {
            InitializeComponent();
        }

        public BeanPass(TableLayoutPanel grid)
        {
            _Grid = grid;

            InitializeComponent();

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            _Style = new RowStyle(SizeType.Absolute, 27F);
            Dock = DockStyle.Fill;
        }
        #endregion

        #region 接口实现
        public void InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);

            BackColor = Color.Blue;
        }

        public bool ShowData(AAtt att)
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
            Clipboard.SetText(TbData.Text);
            SafeUtil.dd();
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

        private void BtMod_Click(object sender, EventArgs e)
        {

        }

        private void BtGen_Click(object sender, EventArgs e)
        {

        }

        private void BtOpt_Click(object sender, EventArgs e)
        {

        }
    }
}
