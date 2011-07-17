using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

public partial class exts_exts1007 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "后缀解析定制搜索代码！";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1007";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts1007.aspx";
        guidItem.V1 = "后缀解析定制搜索代码！";
        guidItem.V2 = "后缀解析定制搜索代码！";

        if (IsPostBack)
        {
            return;
        }
    }
}