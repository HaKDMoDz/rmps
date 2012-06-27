using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Spy
{
    public partial class ASpy : Form, IApp
    {
        private UserModel _UserModel;

        #region 构造函数
        public ASpy()
        {
            InitializeComponent();
        }

        public ASpy(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get
            {
                return EApp.IAPP_ASPY;
            }
            set
            {
            }
        }

        public Form Form
        {
            get { return this; }
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
