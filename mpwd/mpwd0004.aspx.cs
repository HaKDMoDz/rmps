using System;
using System.Web.UI;

public partial class mpwd_mpwd0004 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page≥ı ºªØ
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.SCRIPTID] = "mpwd0004";
    }
}