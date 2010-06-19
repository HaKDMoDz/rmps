using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

public partial class inet_inet0103 : Page
{
    protected bool isRoot;
    protected bool isUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        isRoot = (randId == cons.comn.user.UserInfo.LEVEL_09);
        isUser = (randId >= cons.comn.user.UserInfo.LEVEL_02);
        if (randId == 0)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "风格配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0103";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0103.aspx";
        guidItem.V1 = "风格配置";
        guidItem.V2 = "风格配置";

        if (IsPostBack)
        {
            return;
        }
    }
}