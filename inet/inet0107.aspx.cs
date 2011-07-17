using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class inet_inet0107 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Mozilla Firefox 扩展";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0107";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0107.aspx";
        guidItem.V1 = "火狐扩展";
        guidItem.V2 = "火狐扩展";

        if (IsPostBack)
        {
            return;
        }
    }
}