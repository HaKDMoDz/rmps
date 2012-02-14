using System;
using Me.Amon.Model;

namespace Me.Amon
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            if (userModel.Rank < IUser.LEVEL_02)
            {
                HlSignIn.Visible = true;
                LbUser.Visible = false;
                LbSignIn.Visible = false;
            }
            else
            {
                HlSignIn.Visible = false;
                LbSignIn.Visible = true;
                LbUser.Visible = true;
                LbUser.Text = "欢迎您：" + userModel.Name + "！";
            }
        }

        protected void LbSignIn_Click(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            userModel.WpSignOf();
            Response.Redirect("~/Index.aspx");
        }
    }
}
