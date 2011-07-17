using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;
using rmp.wrp.exts;

public partial class exts_exts9999 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts9999";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 4;

        if (IsPostBack)
        {
            return;
        }
    }

    protected void lb_AmonInfo_Click(object sender, EventArgs e)
    {
        Exts.CountExts();
    }
}