using System;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.V1.Web;
using Me.Amon.Open.V1.Web.Pcs;

public partial class User_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserModel.Current(Session).Rank < IUser.LEVEL_01)
        {
            //Response.Redirect("~/Index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }
    }

    protected void LbAuth_Click(object sender, EventArgs e)
    {
    }
}