using System;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.V.Auth
{
    public partial class AuthUl : UserControl, IAuthAc
    {
        private AuthAc _AuthAc;
        private UserModel _UserModel;

        #region 构造函数
        public AuthUl()
        {
            InitializeComponent();
        }

        public AuthUl(AuthAc authAc, UserModel userModel)
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
        }

        public void ShowMenu(Control control, int x, int y)
        {
            CmMenu.Show(control, x, y);
        }
        #endregion

        #region 事件处理
        private void MiAuthOl_Click(object sender, EventArgs e)
        {
            _AuthAc.ShowView(EAuthAc.AuthOl);
        }

        private void MiAuthPc_Click(object sender, EventArgs e)
        {
            _AuthAc.ShowView(EAuthAc.AuthPc);
        }
        #endregion
    }
}
