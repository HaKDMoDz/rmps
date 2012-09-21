using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Waiting : Form
    {
        public Waiting()
        {
            InitializeComponent();
        }

        public void Show(IWin32Window owner, string message)
        {
            LbMsg.Text = message;
            ShowDialog(owner);
        }
    }
}
