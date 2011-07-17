using System;

public partial class mpwd_mpwd : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        im_AmonLogo.ImageUrl = string.Format("~/_styles/{0}/images/mpwd.png", (Session[cons.wrp.WrpCons.USERSKIN] + "" ?? "0002").Trim().PadLeft(4, '0'));
    }
}
