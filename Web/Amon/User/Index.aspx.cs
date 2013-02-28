using System;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.V1.Web;
using Me.Amon.Open.V1.Web.Pcs;

namespace Me.Amon.User
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserModel.Current(Session);
            if (user.Rank < IUser.LEVEL_01)
            {
                Response.Redirect("~/Index.aspx");
                return;
            }

            DvLoad.Visible = (user.Token == null);
            LbUserName.Text = user.Name;
            HlUserPage.NavigateUrl = "/w/" + user.Name;
            HlUserCard.NavigateUrl = "/c/" + user.Name;
            HlUserImgs.NavigateUrl = "/p/" + user.Name;

            if (IsPostBack)
            {
                return;
            }
        }

        protected void LbAuth_Click(object sender, EventArgs e)
        {
        }
    }
}