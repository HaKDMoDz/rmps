using System;
using System.Collections.Generic;
using rmp.bean;
using rmp.wrp;

public partial class srch_srch0103 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "获取代码";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch0103";

        List<K1V2> guidList = Wrps.GuidSrch(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0103.aspx";
        guidItem.V1 = "获取代码";
        guidItem.V2 = "获取代码";

        if (IsPostBack)
        {
            return;
        }

        hd_UserCode.Value = rmp.comn.user.UserInfo.Current(Session).UserCode;
    }
}
