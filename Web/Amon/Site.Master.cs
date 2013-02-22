using System;
using Me.Amon.Model;

namespace Me.Amon
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            if (userModel.Rank < IUser.LEVEL_02)
            {
                HlSignIn.Visible = true;
                HlSignUp.Visible = true;
                LbSignOf.Visible = false;

                LbUser.Visible = false;
                HlUser.Visible = false;
                HlUser.Text = "";
            }
            else
            {
                HlSignIn.Visible = false;
                HlSignUp.Visible = false;
                LbSignOf.Visible = true;

                LbUser.Visible = true;
                HlUser.Visible = true;
                HlUser.Text = userModel.Name;
            }
        }

        protected void LbSignOf_Click(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            userModel.WpSignOf();
            Response.Redirect("~/Index.aspx");
        }
    }
}