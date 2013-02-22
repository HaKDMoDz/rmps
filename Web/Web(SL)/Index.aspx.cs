using System;
using Me.Amon.Model;

namespace Me.Amon
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            bool visible = userModel.Rank < IUser.LEVEL_02;
            HlSignIn.Visible = visible;
            HlSignUp.Visible = visible;
        }
    }
}