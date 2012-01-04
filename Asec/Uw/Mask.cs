using System.Windows.Forms;

namespace Msec.Uw
{
    public partial class Mask : Form, IForm<Item>
    {
        public Mask()
        {
            InitializeComponent();
        }

        public CallBackHandler<Item> CallBack { get; set; }

        public void Show(Main main, Item data)
        {
            base.Show(main);
        }

        private void BtOk_Click(object sender, System.EventArgs e)
        {

        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {

        }
    }
}
