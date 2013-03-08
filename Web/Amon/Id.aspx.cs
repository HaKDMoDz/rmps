using System;
using Me.Amon.Model;

namespace Me.Amon
{
    public partial class Id : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            DvHome.Visible = UserModel.Current(Session).Code != "A0000000";
        }
    }
}