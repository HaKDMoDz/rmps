using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class help_help0003 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "开源方案";
        Session[cons.wrp.WrpCons.SCRIPTID] = "help0003";

        List<K1V2> guidList = Wrps.GuidHelp(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = "help0003.aspx";
        guidItem.V1 = "开源方案";
        guidItem.V2 = "开源方案";

        if (IsPostBack)
        {
            return;
        }
    }
}