using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

/// <summary>
/// MIME类型
/// </summary>
public partial class exts_exts0500 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "MIME类型";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0500";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 3;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0501.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0500.aspx";
        guidItem.V1 = "MIME类型";
        guidItem.V2 = "MIME类型";

        if (IsPostBack)
        {
            return;
        }
    }
}