using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class myim_myim0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "什么是即时通讯？";
        Session[cons.wrp.WrpCons.SCRIPTID] = "myim0002";

        List<K1V2> guidList = Wrps.GuidMyim(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/myim/myim0002.aspx";
        guidItem.V1 = "什么是即时通讯？";
        guidItem.V2 = "什么是即时通讯？";

        if (IsPostBack)
        {
            return;
        }
    }
}