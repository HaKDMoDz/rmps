using System.Windows.Forms;

namespace Msec.Uw
{
    public partial class Text : Form, IForm<string>
    {
        public Text()
        {
            InitializeComponent();
        }

        public CallBackHandler<string> CallBack { get; set; }

        public void Show(Main main, string data)
        {
            TbText.Text = data;
            base.Show(main);
        }

        private void BtOk_Click(object sender, System.EventArgs e)
        {
            if (CallBack != null)
            {
                CallBack.Invoke(TbText.Text);
            }
            Close();
        }
    }
}
