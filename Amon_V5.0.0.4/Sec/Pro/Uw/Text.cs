using System.Windows.Forms;

namespace Me.Amon.Sec.Pro.Uw
{
    public partial class Text : Form, IForm<string>
    {
        public Text()
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
    }
}
