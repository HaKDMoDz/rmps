using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;

namespace Me.Amon.User
{
    /// <summary>
    /// 屏幕加锁
    /// </summary>
    public partial class AuthAc : Form
    {
        private UserModel _UserModel;

        public AuthAc()
        {
            InitializeComponent();
        }

        public AuthAc(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

    }
}
