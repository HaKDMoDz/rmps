using System.Windows.Forms;

namespace Me.Amon.V.Guid
{
    public partial class Tips : Form
    {
        public Tips()
        {
            InitializeComponent();
        }

        public void ShowTips(string tips)
        {
        }

        public void AddClickEvent(System.EventHandler handler)
        {
            if (handler != null)
            {
                PbImg.Click += handler;
            }
        }
    }
}
