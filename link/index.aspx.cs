using System;
using System.Data;
using System.Text;
using System.Web.UI;

using cons.io.db.prp;
using cons.wrp.link;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp.link;

public partial class link_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDSIZE] = UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_02 ? 5 : 3;
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";
        Session[cons.wrp.WrpCons.GUIDNAME] = "网络导航";

        if (IsPostBack)
        {
            return;
        }

        LoadData();
    }

    /// <summary>
    /// 页面数据初始化
    /// </summary>
    private void LoadData()
    {
        string uc = UserInfo.Current(Session).UserCode;
        hd_UserCode.Value = uc;
        td_UserLink.InnerHtml = UserLink(uc, 5);
        td_PortLink.InnerHtml = Link.PortLink();
    }

    /// <summary>
    /// 用户偏好链接
    /// </summary>
    /// <param name="col"></param>
    /// <returns></returns>
    private String UserLink(string uc, int col)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3070100);
        dba.addColumn(PrpCons.P3070105);
        dba.addColumn(PrpCons.P3070107);
        dba.addColumn(PrpCons.P3070108);
        dba.addColumn(PrpCons.P3070109);
        dba.addColumn(PrpCons.P307010B);
        dba.addWhere(PrpCons.P3070103, uc);
        dba.addWhere(PrpCons.P3070102, LinkCons.LINK_STAT_NORMAL.ToString());
        dba.addSort(PrpCons.P3070101, false);

        StringBuilder html = new StringBuilder();
        html.Append("<table id=\"TB_LinkUser\" border=\"0\" cellpadding=\"2\" cellspacing=\"0\" width=\"460\" class=\"TB_LinkUser\">");
        int idx = 0;
        int cnt = 0;
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            if (idx == 0)
            {
                html.Append("<tr>");
            }

            String sid = row[PrpCons.P3070105] + "";
            String txt = row[PrpCons.P3070108] + "";
            String tip = row[PrpCons.P307010B] + "";
            String url = row[PrpCons.P3070109] + "";
            html.Append(String.Format("<td id=\"td_{0}\" style=\"width: 92px;\" align=\"center\">", sid));
            html.Append(String.Format("<div id=\"dv_{0}\" class=\"TD_LinkPort_P\" href=\"{1}\" title=\"{2}\" onclick=\"hurl(this,'{0}');\">&nbsp;<img id=\"im_{0}\" src=\"/data/link/{4}.png\" alt=\"{3}\" width=\"16\" height=\"16\" style=\"vertical-align:middle;display:none;\" />&nbsp;</div>", sid, url, tip, txt, row[PrpCons.P3070107]));
            html.Append(String.Format("<a id=\"hl_{0}\" target=\"_blank\" href=\"{1}\" title=\"{2}\" onclick=\"feqs('{3}');\">{4}</a>", sid, url, tip, row[PrpCons.P3070105], StringUtil.FixWidth(txt, 4)));
            html.Append("</td>");

            idx += 1;
            if (idx == col)
            {
                html.Append("</tr>");
                idx = 0;
            }
            cnt += 1;
            if (cnt >= 25)
            {
                break;
            }
        }
        while (idx != 0 && idx < col)
        {
            html.Append("<td style=\"width: 92px;\"><div><img src=\"\" alt=\"\" width=\"16\" height=\"16\" style=\"vertical-align:middle;display:none;\"  /></div></td>");
            idx += 1;
        }
        html.Append("</table>");

        return html.ToString();
    }
}