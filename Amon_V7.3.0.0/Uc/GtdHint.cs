using System;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Uc
{
    public partial class GtdHint : UserControl
    {
        private SafeModel _SafeModel;

        public GtdHint()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return TbTips.Text;
            }
            set
            {
                TbTips.Text = value;
            }
        }

        public EventHandler Handler { get; set; }

        private void PbHide_Click(object sender, EventArgs e)
        {
            if (Handler != null)
            {
                Handler.Invoke(sender, e);
            }
        }
    }
}
