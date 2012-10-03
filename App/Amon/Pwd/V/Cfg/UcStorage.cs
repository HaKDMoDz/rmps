using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Cfg
{
    public partial class UcStorage : UserControl
    {
        private UserModel _UserModel;

        public UcStorage()
        {
            InitializeComponent();
        }

        #region 接口实现
        public ACfg ACfg { private get; set; }

        public void InitView(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public bool CheckInput()
        {
            return true;
        }
        #endregion

        #region 事件处理
        #endregion
    }
}
