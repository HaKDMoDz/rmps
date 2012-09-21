using System.Windows.Forms;
using Me.Amon.C;

namespace Me.Amon.Uc
{
    public partial class GtdTips : UserControl
    {
        public GtdTips()
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

        public VoidHandler CallBack { get; set; }

        private void PbHide_Click(object sender, System.EventArgs e)
        {
            if (CallBack != null)
            {
                CallBack();
            }
        }
    }
}
