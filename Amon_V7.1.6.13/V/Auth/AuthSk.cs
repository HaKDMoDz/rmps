using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.V.Auth
{
    /// <summary>
    /// 安全口令
    /// </summary>
    public partial class AuthSk : UserControl, IAuthAc
    {
        private AuthAc _AuthAc;
        private UserModel _UserModel;

        #region 构造函数
        public AuthSk()
        {
            InitializeComponent();
        }

        public AuthSk(AuthAc authAc, UserModel userModel)
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
