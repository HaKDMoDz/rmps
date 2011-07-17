using System;

public partial class mpwd_mpwd0101 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.SCRIPTID] = "mpwd0101";

        if (IsPostBack)
        {
            return;
        }
    }
}
