using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V.Dlg
{
    public partial class PcsViewer : Form
    {
        public PcsViewer()
        {
            InitializeComponent();
        }

        public PcsViewer(List<AMeta> files)
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;

            foreach (var file in files)
            {
                LbFile.Items.Add(file);
            }
        }

        public AMeta SelectedMeta { get; set; }

        #region 事件处理
        private void BtOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
