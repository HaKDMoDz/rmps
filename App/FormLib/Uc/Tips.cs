using System.Windows.Forms;

namespace Me.Amon.Uc
{
    public partial class Tips : UserControl
    {
        public Tips()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return LlTips.Text;
            }
            set
            {
                LlTips.Text = value;
            }
        }

        private void PbHide_Click(object sender, System.EventArgs e)
        {

        }
    }
}
