using System.Windows.Forms;
using Me.Amon.User;

namespace Me.Amon
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtPwd_Click(object sender, System.EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
