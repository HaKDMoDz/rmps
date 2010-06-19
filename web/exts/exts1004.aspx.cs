using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

public partial class exts_exts1004 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Whst is MIME Type?";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1004";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts1004.aspx";
        guidItem.V1 = "Whst is MIME Type?";
        guidItem.V2 = "Whst is MIME Type?";

        if (IsPostBack)
        {
            return;
        }
    }
}