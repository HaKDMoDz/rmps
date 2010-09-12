using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.util;

public partial class exts_exts0202 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "软件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0202";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0201.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0200.aspx";
        guidItem.V1 = "软件信息";
        guidItem.V2 = "软件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0202.aspx";
        guidItem.V1 = "数据预览";
        guidItem.V2 = "数据预览";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt);

        ai_P3010204.InitData();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sid"></param>
    private void LoadData(String sid, String opt)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010200);
        dba.addWhere(PrpCons.P3010202, sid);
        dba.addWhere(PrpCons.P301020F, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hl_P3010203.NavigateUrl = "~/exts/exts0102.aspx?sid=" + row[PrpCons.P3010203];
        ai_P3010204.DstIconHash = "" + row[PrpCons.P3010204];
        hl_P3010205.Text = "" + row[PrpCons.P3010205];
        if (rmp.comn.user.UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_02)
        {
            hl_P3010205.NavigateUrl = String.Format("exts0203.aspx?sid={0}&opt={1}", sid, opt);
            hl_P3010205.ToolTip = "点击修改";
        }
        lb_P3010206.Text = "" + row[PrpCons.P3010206];
        hl_P3010207.NavigateUrl = "mailto:" + row[PrpCons.P3010207];
        hl_P3010207.ToolTip = "" + row[PrpCons.P3010207];
        hl_P3010207.Text = "" + row[PrpCons.P3010207];
        hl_P3010208.NavigateUrl = "" + row[PrpCons.P3010208];
        hl_P3010208.Text = "" + row[PrpCons.P3010208];
        hl_P3010208.ToolTip = "" + row[PrpCons.P3010208];
        StringBuilder sb = new StringBuilder();
        foreach (String temp in ("" + row[PrpCons.P3010209]).Trim().Split(',', ';'))
        {
            if (StringUtil.isValidate(temp))
            {
                sb.Append("&nbsp;<a href=\"exts0001.aspx?exts=").Append(temp).Append("\" title=\"点击查看 ").Append(temp).Append(" 的详细信息\">").Append(temp).Append("</a><br />");
            }
        }
        lb_P3010209.Text = sb.Length > 6 ? sb.ToString(0, sb.Length - 6) : sb.ToString();
        hl_P301020A.NavigateUrl = "~/icon/icon0002.ashx?sid=" + row[PrpCons.P301020A];
        lb_P301020B.Text = "" + row[PrpCons.P301020B];
        lb_P301020C.Text = "" + row[PrpCons.P301020C];
        dt.Dispose();
    }
}