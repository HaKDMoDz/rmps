using System;
using System.Web.UI;

public partial class mpwd_mpwd0003 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.SCRIPTID] = "mpwd0003";
    }
}