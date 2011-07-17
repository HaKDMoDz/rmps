using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

public partial class exts_exts001D : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ====================================================================
        // 用户身份认证
        // ====================================================================
        if (UserInfo.Current(Session).UserRank <= cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts001D";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts001D.aspx";
        guidItem.V1 = "文档信息";
        guidItem.V2 = "文档信息";
    }
}