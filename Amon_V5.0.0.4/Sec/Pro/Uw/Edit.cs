using System.Windows.Forms;

namespace Me.Amon.Sec.Pro.Uw
{
    public partial class Edit : Form, IForm<string>
    {
        public Edit()
        {
            InitializeComponent();
        }

        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            TbText.Text = data;
            base.Show(asec);
        }

        private void BtOk_Click(object sender, System.EventArgs e)
        {
            if (CallBack != null)
            {
                CallBack.Invoke(TbText.Text);
            }
            Close();
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
