using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd
{
    public partial class WGtd : Form, IApp
    {
        private UserModel _UserModel;

        #region 构造函数
        public WGtd()
        {
            InitializeComponent();
        }

        public WGtd(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId { get; set; }

        public Form Form { get { return this; } }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            SblEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            SblEcho.Text = message;
        }

        public bool CanExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void WGtd_Load(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
