using System;
using System.Collections.Generic;
using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

public partial class srch_srch0102 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        if (randId == 0)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "风格配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch0102";

        List<K1V2> guidList = Wrps.GuidSrch(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0102.aspx";
        guidItem.V1 = "风格配置";
        guidItem.V2 = "风格配置";

        if (IsPostBack)
        {
            return;
        }
    }
}
