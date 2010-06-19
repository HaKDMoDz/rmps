using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class exts_exts0602 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "应用平台";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0602";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0601.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0600.aspx";
        guidItem.V1 = "应用平台";
        guidItem.V2 = "应用平台";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0602.aspx";
        guidItem.V1 = "数据预览";
        guidItem.V2 = "数据预览";

        if (IsPostBack)
        {
            return;
        }

        String sid = Request[cons.wrp.WrpCons.SID];
        if (sid == null)
        {
            return;
        }
        sid = sid.Trim();
        if (sid == "")
        {
            return;
        }

        LoadData(sid);
    }

    private void LoadData(String sid)
    {
        String sqlTable = PrpCons.P301F200;
        String sqlSelect = String.Format("SELECT * FROM {0} WHERE {1} = '{2}' AND {3} = '{4}'",
                                         sqlTable,
                                         PrpCons.P301F203, sid,
                                         PrpCons.P301F204, cons.SysCons.UI_LANGHASH);

        DataView dv = new DBAccess().CreateView(sqlTable, sqlSelect);
        if (dv.Count < 1)
        {
            return;
        }

        DataRowView row = dv[0];
        decodePlat(row[PrpCons.P301F202].ToString());
        lb_P301F206.Text = row[PrpCons.P301F206].ToString();
        im_P301F207.ImageUrl = "plat" + "l_" + row[PrpCons.P301F207] + ".png";
        hl_P301F208.NavigateUrl = "plat" + "r_" + row[PrpCons.P301F208] + ".png";
        hl_P301F209.Text = row[PrpCons.P301F209].ToString();
        hl_P301F209.NavigateUrl = row[PrpCons.P301F209].ToString();
        lb_P301F20A.Text = WrpUtil.db2Html(row[PrpCons.P301F20A].ToString());
        lb_P301F20B.Text = WrpUtil.db2Html(row[PrpCons.P301F20B].ToString());

        dv.Dispose();
    }

    private void decodePlat(String key)
    {
        switch (Int32.Parse(key))
        {
            case cons.SysCons.OS_IDX_ALL:
                lb_P301F202.Text = "未知";
                break;
            case cons.SysCons.OS_IDX_WINDOWS:
                lb_P301F202.Text = "Windows系列";
                break;
            case cons.SysCons.OS_IDX_MACINTOSH:
                lb_P301F202.Text = "Macintosh系列";
                break;
            case cons.SysCons.OS_IDX_LINUX:
                lb_P301F202.Text = "Linux家族";
                break;
            case cons.SysCons.OS_IDX_UNIX:
                lb_P301F202.Text = "Unix家族";
                break;
            case cons.SysCons.OS_IDX_MOBILE:
                lb_P301F202.Text = "移动平台";
                break;
            case cons.SysCons.OS_IDX_UNKNOWN:
                lb_P301F202.Text = "其它";
                break;
            default:
                break;
        }
    }
}