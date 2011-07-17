using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

/// <summary>
/// 应用平台
/// </summary>
public partial class exts_exts0600 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "应用平台";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0600";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 3;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0601.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0600.aspx";
        guidItem.V1 = "应用平台";
        guidItem.V2 = "应用平台";

        if (IsPostBack)
        {
            return;
        }
    }
}