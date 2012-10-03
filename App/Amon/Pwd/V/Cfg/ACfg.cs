using System;
using System.Windows.Forms;

namespace Me.Amon.Pwd.V.Cfg
{
    public partial class ACfg : Form
    {
        public ACfg()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        #region 事件处理
        private void ACfg_Load(object sender, EventArgs e)
        {
            ucGeneral1.ACfg = this;
            ucSecurity1.ACfg = this;
            ucStorage1.ACfg = this;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (!ucGeneral1.CheckInput())
            {
                return;
            }
            if (!ucSecurity1.CheckInput())
            {
                return;
            }
            if (!ucStorage1.CheckInput())
            {
                return;
            }
        }

        private void BtNo_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
