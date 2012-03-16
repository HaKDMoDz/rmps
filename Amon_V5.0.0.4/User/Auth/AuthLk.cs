using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.User.Auth
{
    public partial class AuthLk : UserControl, IAuthAc
    {
        private AuthAc _AuthAc;
        private UserModel _UserModel;

        #region 构造函数
        public AuthLk()
        {
            InitializeComponent();
        }

        public AuthLk(AuthAc authAc, UserModel userModel)
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
            #region 已有口令
            string oldPass = TbOldPass.Text;
            if (string.IsNullOrEmpty(oldPass))
            {
                _AuthAc.ShowAlert("请输入已有口令！");
                TbOldPass.Focus();
                return;
            }
            TbOldPass.Text = "";
            #endregion

            #region 新口令
            string newPass = TbNewPass1.Text;
            if (string.IsNullOrEmpty(newPass))
            {
                _AuthAc.ShowAlert("请输入新口令！");
                TbNewPass1.Focus();
                return;
            }

            if (newPass.Length < 4)
            {
                _AuthAc.ShowAlert("登录口令不能少于4个字符！");
                TbNewPass1.Text = "";
                TbNewPass2.Text = "";
                TbNewPass1.Focus();
                return;
            }

            if (newPass != TbNewPass2.Text)
            {
                TbNewPass2.Text = "";
                _AuthAc.ShowAlert("您两次输入的口令不一致！");
                TbNewPass1.Focus();
                return;
            }
            TbNewPass1.Text = "";
            TbNewPass2.Text = "";
            #endregion

            if (!_UserModel.CaAuthLk(oldPass, newPass))
            {
                _AuthAc.ShowAlert("锁屏口令修改失败，请重试！");
                TbOldPass.Focus();
            }
            else
            {
                _AuthAc.Close();
            }

            oldPass = null;
            newPass = null;
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
