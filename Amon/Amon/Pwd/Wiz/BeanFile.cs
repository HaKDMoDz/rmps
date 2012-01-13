using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanFile : UserControl, IAttEdit
    {
        private TableLayoutPanel _Grid;
        private Label _Label;
        private AAtt _Att;

        #region 构造函数
        public BeanFile()
        {
            InitializeComponent();
        }

        public BeanFile(TableLayoutPanel grid)
        {
            _Grid = grid;
            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            InitializeComponent();
            Dock = DockStyle.Fill;
        }
        #endregion

        #region 接口实现
        public void InitView(int row)
        {
            _Grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);
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

        private void BtView_Click(object sender, EventArgs e)
        {

        }

        private void BtOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
