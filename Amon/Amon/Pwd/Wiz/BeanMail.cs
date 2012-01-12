using System;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanMail : UserControl, IRecEdit
    {
        private TableLayoutPanel _Grid;
        private Label _Label;

        public BeanMail()
        {
            InitializeComponent();
        }

        public BeanMail(TableLayoutPanel grid)
        {
            _Grid = grid;
            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region 接口实现
        public void InitView(int row)
        {
            _Grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);
        }

        public bool ShowData(Model.AAtt att)
        {
            return true;
        }

        public void Copy()
        {
        }

        public bool Save()
        {
            return true;
        }
        #endregion

        private void BtSend_Click(object sender, EventArgs e)
        {

        }
    }
}
