using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class GtdEditor : Form
    {
        private MGtd _MGtd;

        #region 构造函数
        public GtdEditor()
        {
            InitializeComponent();
        }

        public GtdEditor(MGtd gtd)
        {
            _MGtd = gtd;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 事件处理
        private void GtdEditor_Load(object sender, EventArgs e)
        {

        }

        private void BtOk_Click(object sender, EventArgs e)
        {

        }

        private void BtNo_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
