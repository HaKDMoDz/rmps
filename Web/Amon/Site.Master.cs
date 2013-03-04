using System;
using Me.Amon.Da.Db;
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
                LbSignIn.Visible = true;
                LbSignOf.Visible = false;

                LbUser.Visible = false;
                HlUser.Visible = false;
                HlUser.Text = "";
            }
            else
            {
                LbSignIn.Visible = false;
                LbSignOf.Visible = true;

                LbUser.Visible = true;
                HlUser.Visible = true;
                HlUser.Text = userModel.Name;
            }
        }

        protected void LbSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/SignIn.aspx");
        }

        protected void LbSignOf_Click(object sender, EventArgs e)
        {
            UserModel userModel = UserModel.Current(Session);
            if (userModel.Code == Web.USER_DEMO)
            {
                var dba = new DBAccess();
                dba.AddTable(DBConst.C3010A00);
                dba.AddWhere(DBConst.C3010A03, Web.USER_DEMO);
                dba.ExecuteDelete();
            }

            userModel.WpSignOf();

            Response.Redirect("~/Index.aspx");
        }
    }
}