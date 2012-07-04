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

        #region 接口实现
        public int AppId { get; set; }

        public Form Form { get { return this; } }

        public void ShowTips(Control control, string caption)
        {
            //TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            //LbEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            //LbEcho.Text = message;
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion
    }
}
