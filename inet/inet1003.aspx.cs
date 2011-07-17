using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class inet_inet1003 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "什么是网络收藏";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet1003";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet1000.aspx";
        guidItem.V1 = "相关知识";
        guidItem.V2 = "相关知识";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet1003.aspx";
        guidItem.V1 = "什么是网络收藏";
        guidItem.V2 = "什么是网络收藏";

        if (IsPostBack)
        {
            return;
        }
    }
}