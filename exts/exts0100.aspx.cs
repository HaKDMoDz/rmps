using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

/// <summary>
/// 公司信息
/// </summary>
public partial class exts_exts0100 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "公司信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0100";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 3;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0101.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0100.aspx";
        guidItem.V1 = "公司信息";
        guidItem.V2 = "公司信息";

        if (IsPostBack)
        {
            return;
        }
    }
}