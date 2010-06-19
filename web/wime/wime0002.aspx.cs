using System;
using System.Web.UI;
using cons.wrp;
using rmp.bean;
using rmp.wrp;

public partial class wime_wime0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页五笔";
        Session[cons.wrp.WrpCons.SCRIPTID] = "wime0002";

        K1V2 guidItem = Wrps.GuidWime(Session)[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/wime/wime0002.aspx";
        guidItem.V1 = "获取代码";
        guidItem.V2 = "获取代码";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
    }
}