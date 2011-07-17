using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

public partial class exts_exts1005 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "浏览器内置搜索！";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1005";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts1005.aspx";
        guidItem.V1 = "浏览器内置搜索！";
        guidItem.V2 = "浏览器内置搜索！";

        if (IsPostBack)
        {
            return;
        }
    }
}