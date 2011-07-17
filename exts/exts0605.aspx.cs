using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;

public partial class exts_exts0605 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "应用平台";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0605";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 3;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0601.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0605.aspx";
        guidItem.V1 = "应用平台";
        guidItem.V2 = "应用平台";

        if (IsPostBack)
        {
            return;
        }

        LoadData(0);
    }

    private void LoadData(int idx)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P301F200);
        dba.addColumn(PrpCons.P301F203); //平台索引
        dba.addColumn(PrpCons.P301F206); //平台名称
        dba.addColumn(PrpCons.P301F207); //平台图标
        dba.addColumn(PrpCons.P301F208); //运行截图
        dba.addColumn(PrpCons.P301F209); //平台首页
        dba.addWhere(PrpCons.P301F202, "" + cons.SysCons.OS_IDX_LINUX); //所属家族
        dba.addWhere(PrpCons.P301F204, cons.SysCons.UI_LANGHASH); //语言选项
        dba.addSort(PrpCons.P301F206, true);
        gv_PlatList.DataSource = dba.executeSelect();
        gv_PlatList.PageIndex = idx;
        gv_PlatList.DataBind();
    }

    protected String ReadLink(String url)
    {
        url = url.Trim();
        return String.Format("<a href=\"{0}\" target=\"_blank\" title=\"访问站点：{0}\">{1}</a>", url, url.Length > 32 ? url.Substring(0, 29) + "..." : url);
    }

    protected void gv_PlatList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        LoadData(e.NewPageIndex);
    }
}