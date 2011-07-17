using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class myim_myim1006 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Pidgin";
        Session[cons.wrp.WrpCons.SCRIPTID] = "myim1006";

        List<K1V2> guidList = Wrps.GuidMyim(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/myim/myim1000.aspx";
        guidItem.V1 = "国外软件";
        guidItem.V2 = "国外软件";

        guidList = Wrps.GuidMyim(Session);
        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/myim/myim1006.aspx";
        guidItem.V1 = "Pidgin";
        guidItem.V2 = "Pidgin";

        if (IsPostBack)
        {
            return;
        }
    }
}