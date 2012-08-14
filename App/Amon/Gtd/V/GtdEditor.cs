using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class GtdEditor : Form
    {
        #region 构造函数
        public GtdEditor()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        public MGtd MGtd { get; set; }

        #region 事件处理
        private void GtdEditor_Load(object sender, EventArgs e)
        {
            if (MGtd == null)
            {
                MGtd = new MGtd();
            }
            UcFixTime.MGtd = MGtd;
            UcInterval.MGtd = MGtd;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            IEdit edit = TcGtd.SelectedTab.Controls[0] as IEdit;
            if (edit == null)
            {
                return;
            }

            if (edit.SaveData())
            {
                Close();
            }
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
