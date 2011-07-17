using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

/// <summary>
/// 图标管理
/// </summary>
public partial class exts_exts0A00 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0A00";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 4;

        if (IsPostBack)
        {
            return;
        }
    }
}