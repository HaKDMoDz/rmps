using System;
using System.Collections.Generic;
using rmp.bean;
using rmp.wrp;

public partial class srch_srch1001 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "使用说明";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch1001";

        List<K1V2> guidList = Wrps.GuidSrch(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch1001.aspx";
        guidItem.V1 = "使用说明";
        guidItem.V2 = "使用说明";

        if (IsPostBack)
        {
            return;
        }
    }
}
