using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class help_help0007 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "安装说明";
        Session[cons.wrp.WrpCons.SCRIPTID] = "help0007";

        List<K1V2> guidList = Wrps.GuidHelp(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = "help0007.aspx";
        guidItem.V1 = "安装说明";
        guidItem.V2 = "安装说明";

        if (IsPostBack)
        {
            return;
        }
    }
}