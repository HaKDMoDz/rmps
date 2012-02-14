using System.Windows.Forms;

namespace Me.Amon.Gtd
{
    public partial class AGtd : Form, IApp
    {
        public AGtd()
        {
            InitializeComponent();
        }

        public void InitOnce()
        {
        }

        public int AppId { get; set; }

        public Form Form { get { return this; } }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
    }
}
