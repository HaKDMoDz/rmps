using System.Windows.Forms;
using Me.Amon.M;

namespace Me.Amon.Auth.Uc
{
    /// <summary>
    /// 安全口令
    /// </summary>
    public partial class AuthSk : UserControl, IAuthAc
    {
        private AuthAc _AuthAc;
        private AUserModel _UserModel;

        #region 构造函数
        public AuthSk()
        {
            InitializeComponent();
        }

        public AuthSk(AuthAc authAc, AUserModel userModel)
        {
            _AuthAc = authAc;
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoAuthAc()
        {
        }

        public void DoCancel()
        {
            _AuthAc.Close();
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion
    }
}
