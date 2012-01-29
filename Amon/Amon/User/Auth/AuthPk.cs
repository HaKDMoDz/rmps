using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.User.Auth
{
    /// <summary>
    /// 登录口令
    /// </summary>
    public partial class AuthPk : UserControl, IAuthAc
    {
        private SignRc _SignRc;
        private UserModel _UserModel;

        public AuthPk()
        {
            InitializeComponent();
        }

        public AuthPk(SignRc signRc, UserModel userModel)
        {
            InitializeComponent();
        }


        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
            _UserModel.SignPk("", "");
        }

        public void DoCancel()
        {
        }
    }
}
