using System;
using System.Collections.Generic;
using cons.wrp;
using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

public partial class srch_srch0100 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户首页";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch0100";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        List<K1V2> guidList = Wrps.GuidInet(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }
    }
}
