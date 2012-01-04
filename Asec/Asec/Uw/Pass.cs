using System.Windows.Forms;

namespace Msec.Uw
{
    public partial class Pass : Form, IForm<string>
    {
        public Pass()
        {
            InitializeComponent();
        }

        public CallBackHandler<string> CallBack { get; set; }

        public void Show(Main main, string data)
        {
            base.Show(main);
        }
    }
}
