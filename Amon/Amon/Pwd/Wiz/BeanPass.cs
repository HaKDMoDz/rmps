using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanPass : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private AAtt _Att;

        #region 构造函数
        public BeanPass()
        {
            InitializeComponent();
        }

        public BeanPass(BeanBody body, TableLayoutPanel grid)
        {
            _Body = body;
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
            SafeUtil.Copy(TbData.Text);
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

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtMod_Click(object sender, EventArgs e)
        {
            if (TbData.PasswordChar != '*')
            {
                TbData.PasswordChar = '*';
            }
            else
            {
                TbData.PasswordChar = '\0';
            }
        }

        private void BtGen_Click(object sender, EventArgs e)
        {
            TbData.Text = new string(CharUtil.GenerateUserChar());
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            CmMenu.Show(BtOpt, 0, BtOpt.Height);
        }

        #region 菜单事件
        private void MiCharLen0_Click(object sender, EventArgs e)
        {

        }

        private void MiCharLen1_Click(object sender, EventArgs e)
        {

        }

        private void MiCharLen2_Click(object sender, EventArgs e)
        {

        }

        private void MiCharLen3_Click(object sender, EventArgs e)
        {

        }

        private void MiCharLen4_Click(object sender, EventArgs e)
        {

        }

        private void MiCharLen5_Click(object sender, EventArgs e)
        {

        }

        private void MiCharLen6_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet0_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet1_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet2_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet3_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet4_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet5_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet6_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSetO_Click(object sender, EventArgs e)
        {

        }

        private void MiRepeatable_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
