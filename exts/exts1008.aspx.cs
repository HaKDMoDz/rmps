using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

public partial class exts_exts1008 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Customize your search code!";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1008";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts1008";
        guidItem.V1 = "Customize your search code!";
        guidItem.V2 = "Customize your search code!";

        if (IsPostBack)
        {
            return;
        }
    }
}