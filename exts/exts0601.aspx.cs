using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;

public partial class exts_exts0601 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "应用平台";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0601";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0601.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0600.aspx";
        guidItem.V1 = "应用平台";
        guidItem.V2 = "应用平台";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0601.aspx";
        guidItem.V1 = "数据查询";
        guidItem.V2 = "数据查询";

        if (IsPostBack)
        {
            return;
        }
    }

    protected void bt_P301F206_Click(object sender, EventArgs e)
    {
        String sqlTable = PrpCons.P301F200;
        String sqlSelect = String.Format("SELECT {1}, {2}, {3} FROM {0} WHERE {3} LIKE '%{4}%' AND {5}='{6}' ORDER BY {7} ASC, {8} DESC",
                                         sqlTable,
                                         PrpCons.P301F202, //所属家族
                                         PrpCons.P301F203, //平台索引
                                         PrpCons.P301F206, tf_P301F206.Text.Replace(" ", "%"), //平台名称
                                         PrpCons.P301F204, cons.SysCons.UI_LANGHASH,
                                         PrpCons.P301F202,
                                         PrpCons.P301F201
            );

        rp_PlatList.DataSource = new DBAccess().CreateView(sqlTable, sqlSelect);
        rp_PlatList.DataBind();
    }

    protected String decodePlat(String key)
    {
        switch (Int32.Parse(key))
        {
            case cons.SysCons.OS_IDX_ALL:
                return "未知";
            case cons.SysCons.OS_IDX_WINDOWS:
                return "Windows系列";
            case cons.SysCons.OS_IDX_MACINTOSH:
                return "Macintosh系列";
            case cons.SysCons.OS_IDX_LINUX:
                return "Linux家族";
            case cons.SysCons.OS_IDX_UNIX:
                return "Unix家族";
            case cons.SysCons.OS_IDX_MOBILE:
                return "移动平台";
            case cons.SysCons.OS_IDX_UNKNOWN:
                return "其它";
            default:
                return "";
        }
    }
}