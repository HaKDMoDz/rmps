using System.Windows.Forms;
using Me.Amon.User;

namespace Me.Amon
{
    public partial class Main : Form
    {
        private int _MRadio;
        private int _Radio;
        private int _CenterX;
        private int _CenterY;
        private int _ScreenX;
        private int _ScreenY;
        private int _ScreenW;
        private int _ScreenH;

        public Main()
        {
            InitializeComponent();
        }

        public void Init()
        {
            _Radio = 24;
            _CenterX = _Radio;
            _CenterY = _Radio;
            _ScreenX = Location.X + _Radio;
            _ScreenY = Location.Y + _Radio;
            _ScreenW = Screen.PrimaryScreen.Bounds.Width;
            _ScreenH = Screen.PrimaryScreen.Bounds.Height;
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
        }
    }
}
