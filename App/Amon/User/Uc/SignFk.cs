﻿using System.Windows.Forms;
using Me.Amon.Auth;
using Me.Amon.M;

namespace Me.Amon.User.Uc
{
    /// <summary>
    /// 找回密码
    /// </summary>
    public partial class SignFk : UserControl, ISignAc
    {
        private SignAc _SignAc;
        private AUserModel _UserModel;

        public SignFk()
        {
            InitializeComponent();
        }

        public SignFk(SignAc signAc, AUserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            //_SignAc.ShowTips(null, "");
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
        }

        public void DoCancel()
        {
            _SignAc.ShowView(ESignAc.SignIn);
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion
    }
}
