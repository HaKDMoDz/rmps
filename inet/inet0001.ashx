<%@ WebHandler Language="C#" Class="inet0001" %>

using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using cons;
using cons.io.db.comn;
using cons.io.db.wrp;
using cons.wrp.inet;

using rmp.io.db;
using rmp.util;
using rmp.wrp.inet;

/// <summary>
/// 代码加载
/// </summary>
public class inet0001 : IHttpHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        // 用户索引
        String id = WrpUtil.text2Db(context.Request["f"]);
        if (id != "")
        {
            LoadHTML(context, id);
            return;
        }

        // 用户输入参数读取
        id = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);
        if (id != "")
        {
            LoadData(context, id);
            return;
        }
    }

    /// <summary>
    /// 用户编码
    /// </summary>
    /// <param name="context"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    private static void LoadData(HttpContext context, String id)
    {
        // HTTP响应头信息设定
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = Encoding.UTF8;

        if (!StringUtil.isValidate(id, 8) && !(StringUtil.isValidate(id, 4) && id[0] == 't'))
        {
            id = cons.comn.user.UserInfo.COMN_CODE;
        }

        // 用户配置数据写入
        String code = Inet.TpltCode.Replace("{$DATA$}", TpltData(id));

        // 回写JavaScript脚本
        context.Response.Write(code);
        context.Response.End();
    }

    private static String TpltData(String id)
    {
        StringBuilder sid = new StringBuilder("var DVID=[");

        // 用户配置模块读取
        DBAccess dba = new DBAccess();
        dba.addTable(WrpCons.W2011100);
        dba.addTable(ComnCons.C2010000);
        dba.addColumn(ComnCons.C2010004);
        dba.addColumn(ComnCons.C2010002);
        dba.addWhere(WrpCons.W2011104, ComnCons.C2010002, false);
        dba.addWhere(WrpCons.W2011102, InetCons.TYPE_USER_KIND);
        dba.addWhere(WrpCons.W2011105, id);
        dba.addSort(ComnCons.C2010002);

        DataTable dataList = dba.executeSelect();
        // 用户给定ID不存在的情况下进行默认处理
        if (dataList.Rows.Count < 1)
        {
            id = cons.comn.user.UserInfo.COMN_CODE;
            dba.reset();

            dba.addTable(WrpCons.W2011100);
            dba.addTable(ComnCons.C2010000);
            dba.addColumn(ComnCons.C2010004);
            dba.addColumn(ComnCons.C2010002);
            dba.addWhere(WrpCons.W2011104, ComnCons.C2010002, false);
            dba.addWhere(WrpCons.W2011102, InetCons.TYPE_USER_KIND);
            dba.addWhere(WrpCons.W2011105, id);
            dba.addSort(ComnCons.C2010002);

            dataList = dba.executeSelect();
        }

        String cid;
        StringBuilder kid = new StringBuilder();
        foreach (DataRow row in dataList.Rows)
        {
            cid = row[ComnCons.C2010002].ToString();
            kid.Append(",'").Append(cid).Append("'");
            sid.Append("['").Append(cid).Append("','").Append(row[ComnCons.C2010004].ToString()).Append("'],");
        }
        if (kid.Length > 0)
        {
            kid.Remove(0, 1);
            sid.Remove(sid.Length - 1, 1);
        }
        sid.Append("];");
        cid = "";

        // 用户配置数据读取
        // 用户偏好类别及各类别数据处理，用于生成符合Javascript语法的数组
        dba.reset();
        dba.addTable(WrpCons.W2019100);
        dba.addTable(WrpCons.W2011100);
        dba.addColumn(WrpCons.W2019104);
        dba.addColumn(WrpCons.W2019102);
        dba.addColumn(WrpCons.W2019105);
        dba.addColumn(WrpCons.W2019106);
        dba.addColumn(WrpCons.W2019107);
        dba.addColumn(WrpCons.W2019109);
        dba.addColumn(WrpCons.W201910A);
        dba.addColumn(WrpCons.W201910B);
        dba.addWhere(WrpCons.W2019104, "IN", "(" + kid + ')', false);
        dba.addWhere(WrpCons.W2011104, WrpCons.W2019102, false);
        dba.addWhere(WrpCons.W2011105, id);
        dba.addSort(WrpCons.W2019104);
        dba.addSort(WrpCons.W2011101, false);

        StringBuilder dat = new StringBuilder("var DVDT={'0':[,");
        int i = 0;
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            if (cid != row[WrpCons.W2019104].ToString())
            {
                cid = row[WrpCons.W2019104].ToString();
                dat.Remove(dat.Length - 1, 1).Append("],").Append(cid).Append(":[");
                i = 0;
            }
            if (i > 10)
            {
                continue;
            }
            dat.Append('[');
            dat.Append("'").Append(row[WrpCons.W2019102].ToString()).Append("',");// 0:ID，网摘标记ID，同时也用作打开窗口的ID
            dat.Append("'").Append(row[WrpCons.W2019105].ToString()).Append("',");// 1:icon，链接图标索引
            dat.Append("'").Append(StringUtil.trim(row[WrpCons.W2019106].ToString(), 5)).Append("',");// 2:text，链接显示文本
            dat.Append("'").Append(row[WrpCons.W2019107].ToString()).Append("',");// 3:tips，链接快捷提示
            dat.Append("'',");
            dat.Append(row[WrpCons.W201910A].ToString()).Append(",");// 5:width，窗口宽度
            dat.Append(row[WrpCons.W201910B].ToString());// 6:height，窗口调度
            dat.Append("],");
            i += 1;
        }
        dat.Remove(dat.Length - 1, 1).Append("]};");

        return sid + "var USER='" + id + "';" + dat;
    }

    /// <summary>
    /// 生成网摘代码
    /// </summary>
    /// <param name="context"></param>
    /// <param name="f">用户代码</param>
    private static void LoadHTML(HttpContext context, String f)
    {
        // HTTP响应头信息设定
        context.Response.ContentType = "text/html";
        context.Response.ContentEncoding = Encoding.UTF8;

        if (!StringUtil.isValidate(f, 8) && !(StringUtil.isValidate(f, 4) && f[0] == 't'))
        {
            f = cons.comn.user.UserInfo.COMN_CODE;
        }

        // 页面传入参数
        string t = context.Request["t"] ?? "";
        string u = context.Request["u"] ?? "";
        string d = context.Request["d"] ?? "";

        // 临时变量
        int ti;
        Regex rx = new Regex("^\\d+$");

        // 显示列参数
        int pc = 2;
        String ts = context.Request["c"] ?? "";
        if (rx.IsMatch(ts))
        {
            pc = int.Parse(ts);
        }

        // 读取宽度参数
        int pw = 400;
        ts = context.Request["w"] ?? "";
        if (rx.IsMatch(ts))
        {
            ti = int.Parse(ts);
            pw = ti;
            ti = ti / 70;
            if (ti < pc)
            {
                pc = ti;
            }
        }

        // 显示行参数
        int pr = 10;
        ts = context.Request["r"] ?? "";
        if (rx.IsMatch(ts))
        {
            pr = int.Parse(ts);
        }

        // 读取调度参数
        int ph = 400;
        ts = context.Request["h"] ?? "";
        if (rx.IsMatch(ts))
        {
            ti = int.Parse(ts);
            ph = ti;
            ti = (ti - 56) / 20;
            if (ti < pr)
            {
                pr = ti;
            }
        }
        ph = pr * 20 + 56;

        // 用户偏好索引
        int i = Inet.GetUserFav(f);

        StringBuilder html = new StringBuilder();
        HtmlHead(html);
        html.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; height: 100%;\">");
        html.Append("<tr>");
        html.Append("<td align=\"center\">");
        html.Append("<div id=\"Net_Amonsoft_NetHelper_Help\" class=\"Net_Amonsoft_NetHelper_Form\" style=\"width:").Append(pw).Append("px;height:").Append(ph).Append("px;text-align:center;\">");
        HtmlBody(html, f, i, pr, pc);
        html.Append("</div>");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("</table>");
        html.Append("<input type=\"hidden\" name=\"hd_I\" id=\"hd_I\" value=\"").Append(i).Append("\"/>");
        html.Append("<input type=\"hidden\" name=\"hd_T\" id=\"hd_T\" value=\"").Append(t).Append("\"/>");
        html.Append("<input type=\"hidden\" name=\"hd_U\" id=\"hd_U\" value=\"").Append(u).Append("\"/>");
        html.Append("<input type=\"hidden\" name=\"hd_D\" id=\"hd_D\" value=\"").Append(d).Append("\"/>");
        html.Append("<input type=\"hidden\" name=\"hd_F\" id=\"hd_F\" value=\"").Append(f).Append("\"/>");
        HtmlFoot(html);
        context.Response.Write(html.ToString());
        context.Response.End();
    }

    private static void HtmlHead(StringBuilder html)
    {
        html.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
        html.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
        html.Append("<head>");
        html.Append("<title>Amon网页精灵</title>");
        html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/>");
        html.Append("<style type=\"text/css\">");
        html.Append("HTML,BODY,FORM");
        html.Append("{");
        html.Append("background-color:#ffffff;");
        html.Append("color: #330000;");
        html.Append("font-family:\"宋体\",simsun,Arial,\"Times New Roman\";");
        html.Append("font-size:9pt;");
        html.Append("margin:0px;");
        html.Append("height:100%;");
        html.Append("}");
        html.Append("</style>");
        html.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/").Append(EnvCons.PRE_URL).Append("inet/c/NetHelper.css\" /></head>");
        html.Append("<body>");
    }

    /// <summary>
    /// 读取网摘内容
    /// </summary>
    /// <param name="html"></param>
    /// <param name="f">用户代码</param>
    /// <param name="i">功能索引</param>
    /// <param name="r">显示行数</param>
    /// <param name="c">显示列数</param>
    private static void HtmlBody(StringBuilder html, String f, int i, int r, int c)
    {
        html.Append("<table id=\"Net_Amonsoft_NetHelper_BODY\" class=\"Net_Amonsoft_NetHelper_BODY\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        html.Append("<tr>");
        html.Append("<th id=\"Net_Amonsoft_NetHelper_HEAD\" align=\"left\" style=\"height: 21px; padding-left: 4px;\">Amon 收藏</th>");
        html.Append("<th id=\"Net_Amonsoft_NetHelper_GUID\" align=\"right\" style=\"height: 21px; padding-left: 4px;\"><a title=\"用户信息\">").Append(rmp.comn.user.Util.GetUserNameByCode(f)).Append("</a></th>");
        html.Append("</tr>");

        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C2010000);
        dba.addTable(WrpCons.W2011100);
        dba.addColumn(ComnCons.C2010002);
        dba.addColumn(ComnCons.C2010004);
        dba.addWhere(ComnCons.C2010002, WrpCons.W2011104, false);
        dba.addWhere(ComnCons.C2010003, "42010000");
        dba.addWhere(WrpCons.W2011105, f);
        dba.addWhere(WrpCons.W2011102, "1");
        dba.addSort(WrpCons.W2011101);
        DataTable kind = dba.executeSelect();

        dba.reset();
        dba.addTable(WrpCons.W2019100);
        dba.addColumn(WrpCons.W2019104);
        dba.addColumn(WrpCons.W2019102);
        dba.addColumn(WrpCons.W2019105);
        dba.addColumn(WrpCons.W2019106);
        dba.addColumn(WrpCons.W2019107);
        dba.addColumn(WrpCons.W2019109);
        dba.addColumn(WrpCons.W201910A);
        dba.addColumn(WrpCons.W201910B);
        dba.addWhere(WrpCons.W2019104, "IN", '(' + HtmlTabs(html, kind, i) + ')', false);
        dba.addSort(WrpCons.W2019101, false);
        DataTable link = dba.executeSelect();
        DataView view = link.DefaultView;

        html.Append("<tr>");
        html.Append("<td colspan=\"2\" align=\"center\">");

        StringBuilder dvid = new StringBuilder("var DVID = new Array(");
        StringBuilder dvnm = new StringBuilder("var DVNM = new Array(");
        int j = 0;
        foreach (DataRow row in kind.Rows)
        {
            switch (row[ComnCons.C2010002].ToString())
            {
                case "iNetHelper_10bms":
                    {
                        dvid.Append("'10bms',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_10bms'";
                        Inet.GenTable(view, html, "10bms", r, c, j == i);
                    }
                    break;
                case "iNetHelper_20rss":
                    {
                        dvid.Append("'20rss',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_20rss'";
                        Inet.GenTable(view, html, "20rss", r, c, j == i);
                    }
                    break;
                case "iNetHelper_30wse":
                    {
                        dvid.Append("'30wse',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_30wse'";
                        Inet.GenTable(view, html, "30wse", r, c, j == i);
                    }
                    break;
                case "iNetHelper_31ssl":
                    {
                        dvid.Append("'31ssl',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_31ssl'";
                        Inet.GenSite(view, html, "31ssl", r, j == i);
                    }
                    break;
                case "iNetHelper_32map":
                    {
                        dvid.Append("'32map',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_32map'";
                        Inet.GenTable(view, html, "32map", r, c, j == i);
                    }
                    break;
                case "iNetHelper_40cal":
                    {
                        dvid.Append("'40cal',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Inet.GenTable(null, html, "40cal", r, c, j == i);
                        break;
                    }
                case "iNetHelper_41dts":
                    {
                        dvid.Append("'41dts',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Inet.GenTable(null, html, "41dts", r, c, j == i);
                        break;
                    }
                case "iNetHelper_50wlt":
                    {
                        dvid.Append("'50wlt',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_50wlt'";
                        Inet.GenTable(view, html, "50wlt", r, c, j == i);
                    }
                    break;
                case "iNetHelper_60wmc":
                    {
                        dvid.Append("'60wmc',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_60wmc'";
                        Inet.GenTable(view, html, "60wmc", r, c, j == i);
                    }
                    break;
                case "iNetHelper_90wmi":
                    {
                        dvid.Append("'90wmi',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        view.RowFilter = WrpCons.W2019104 + "='iNetHelper_90wmi'";
                        Inet.GenTable(view, html, "90wmi", r, c, j == i);
                    }
                    break;
                default:
                    break;
            }
            j += 1;
        }
        dvid.Append("'99def');");
        dvnm.Append("'99def');");

        html.Append("</td>");
        html.Append("</tr>");

        html.Append("<tr id=\"tr_SoftGuid\" runat=\"server\">");
        html.Append("<td align=\"left\" style=\"height: 16px;\">&nbsp;</td>");
        html.Append("<td align=\"right\" style=\"height: 16px;\">");
        html.Append("<a href=\"http://amonsoft.net/\" target=\"_blank\" title=\"Amon软件\">Amonsoft</a>&nbsp;<a href=\"http://amonsoft.net/inet/inet0001.aspx\" target=\"_blank\" onclick=\"return openFull();\" title=\"更多网摘\">更多…</a>&nbsp;");
        html.Append("</td>");
        html.Append("</tr>");
        html.Append("</table>");

        html.Append("<script type=\"text/javascript\">").Append(dvid.ToString()).Append(dvnm.ToString()).Append("</script>");
    }

    private static String HtmlTabs(StringBuilder html, DataTable data, int i)
    {
        html.Append("<tr>");
        html.Append("<td colspan=\"2\" style=\"height: 16px;\">");
        html.Append("<div id=\"Net_Amonsoft_NetHelper_ITAB\">");
        html.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        html.Append("<tr align=\"center\">");

        int j = 0;
        StringBuilder sid = new StringBuilder();
        foreach (DataRow row in data.Rows)
        {
            html.Append("<td id=\"Net_Amonsoft_NetHelper_TAB").Append(j).Append("\" style=\"width:40px;height:16px;\" class=\"Net_Amonsoft_NetHelper_TAB").Append(j == i ? "S" : "D").Append("\" onmouseover=\"tabO(this,").Append(j).Append(")\" onmouseout=\"tabX(this,").Append(j).Append(")\" onmouseup=\"tabS(this,").Append(j).Append(")\">");
            html.Append("<a href=\"\" title=\"").Append(row[ComnCons.C2010004]).Append("\" onclick=\"javascript:return false;\">").Append(row[ComnCons.C2010004]).Append("</a>");
            html.Append("</td>");
            sid.Append('\'').Append(row[ComnCons.C2010002]).Append("',");
            j += 1;
        }

        html.Append("<td>&nbsp;</td>");
        html.Append("</tr>");
        html.Append("</table>");
        html.Append("</div>");
        html.Append("</td>");
        html.Append("</tr>");

        return sid.ToString().TrimEnd(',');
    }

    private static void HtmlFoot(StringBuilder html)
    {
        html.Append("</body>");
        html.Append("</html>");
        html.Append("<script type=\"text/javascript\" src=\"/").Append(EnvCons.PRE_URL).Append("inet/inet0001.js\"></script>");
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}