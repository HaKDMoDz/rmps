using System.Windows.Forms;
using Me.Amon.Img.V.Pro;

namespace Me.Amon.Img
{
    public partial class AImg : Form
    {
        public AImg()
        {
            InitializeComponent();
        }

        private void ShowView()
        {
        }

        private APro _APro;
        private void ShowAPro()
        {
            if (_APro == null)
            {
                _APro = new APro();
                _APro.InitOnce();
                _APro.Dock = DockStyle.Fill;
                Controls.Clear();
                Controls.Add(_APro);
            }
        }

        private void AImg_Load(object sender, System.EventArgs e)
        {
            ShowAPro();
        }
    }
}
