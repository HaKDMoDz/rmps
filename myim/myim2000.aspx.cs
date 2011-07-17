using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class myim_myim2000 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "国内软件";
        Session[cons.wrp.WrpCons.SCRIPTID] = "myim2000";

        List<K1V2> guidList = Wrps.GuidMyim(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/myim/myim2000.aspx";
        guidItem.V1 = "国内软件";
        guidItem.V2 = "国内软件";

        if (IsPostBack)
        {
            return;
        }
    }
}