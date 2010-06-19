using System;
using System.Collections.Generic;
using System.Web.UI;

using cons;
using cons.wrp;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

using Util = rmp.comn.Util;

public partial class inet_inet0105 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "获取代码";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0105";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0105.aspx";
        guidItem.V1 = "获取代码";
        guidItem.V2 = "获取代码";

        if (IsPostBack)
        {
            return;
        }

        hd_UserCode.Value = UserInfo.Current(Session).UserCode;

        cb_LinkType.Attributes.Add("onchange", "viewText(this, '', false);");
        cb_ListType.Attributes.Add("onchange", "viewText(this, '', false);");

        Util.InitCat1Data(cb_LinkType, SysCons.UI_LANGHASH, "42010000", false);
        Util.InitCat1Data(cb_ListType, SysCons.UI_LANGHASH, "42010000", false);
    }
}