using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class exts_exts0002 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "在线查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0002";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0002.aspx";
        guidItem.V1 = "图标查询";
        guidItem.V2 = "图标查询";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        rb_IconMode.SelectedValue = "soft";
        hd_IconSize.Value = "48";
        hd_ColCount.Value = "5";
        hd_RowCount.Value = "10";
        hd_ViewMode.Value = "icon";
        tr_IconList.Visible = false;
    }

    protected void bt_IconName_Click(object sender, EventArgs e)
    {
        if (rb_IconMode.SelectedIndex < 0)
        {
            return;
        }

        String text = (tf_IconName.Text ?? "").Trim();
        if (!StringUtil.isValidate(text))
        {
            return;
        }
        text = WrpUtil.text2Like(text);

        hd_IconMode.Value = rb_IconMode.SelectedValue;
        hd_IconName.Value = text;

        ShowIcon(rb_IconMode.SelectedValue, text, 0);
    }

    protected void ib_ViewIcon_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        hd_ViewMode.Value = "icon";
        hd_IconSize.Value = "48";
        ShowIcon(hd_IconMode.Value, hd_IconName.Value, 0);
    }

    protected void ib_ViewList_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        hd_ViewMode.Value = "list";
        hd_IconSize.Value = "16";
        ShowIcon(hd_IconMode.Value, hd_IconName.Value, 0);
    }

    protected void lb_PrevPage_Click(object sender, EventArgs e)
    {
        String v = hd_PageIndx.Value;
        if (!StringUtil.isValidateLong(v))
        {
            v = "1";
        }
        ShowIcon(hd_IconMode.Value, hd_IconName.Value, int.Parse(v) - 1);
    }

    protected void lb_NextPage_Click(object sender, EventArgs e)
    {
        String v = hd_PageIndx.Value;
        if (!StringUtil.isValidateLong(v))
        {
            v = "-1";
        }
        ShowIcon(hd_IconMode.Value, hd_IconName.Value, int.Parse(v) + 1);
    }

    private void ShowIcon(String mode, String text, int page)
    {
        DBAccess dba = new DBAccess();
        switch (mode)
        {
            case "corp":
                dba.addTable(cons.io.db.prp.PrpCons.P3010100);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.prp.PrpCons.P3010105, cons.io.db.prp.PrpCons.P3010106, text));
                dba.addSort(cons.io.db.prp.PrpCons.P3010101);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(dba.executeSelect(), page, hd_IconSize.Value, "corp", cons.io.db.prp.PrpCons.P3010104, cons.io.db.prp.PrpCons.P3010105, cons.io.db.prp.PrpCons.P301010A);
                }
                else
                {
                    ViewIcon(dba.executeSelect(), page, hd_IconSize.Value, "corp", cons.io.db.prp.PrpCons.P3010104, cons.io.db.prp.PrpCons.P3010105, cons.io.db.prp.PrpCons.P301010A);
                }
                break;
            case "soft":
                dba.addTable(cons.io.db.prp.PrpCons.P3010200);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.prp.PrpCons.P3010205, cons.io.db.prp.PrpCons.P3010206, text));
                dba.addSort(cons.io.db.prp.PrpCons.P3010201);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(dba.executeSelect(), page, hd_IconSize.Value, "soft", cons.io.db.prp.PrpCons.P3010204, cons.io.db.prp.PrpCons.P3010205, cons.io.db.prp.PrpCons.P301020D);
                }
                else
                {
                    ViewIcon(dba.executeSelect(), page, hd_IconSize.Value, "soft", cons.io.db.prp.PrpCons.P3010204, cons.io.db.prp.PrpCons.P3010205, cons.io.db.prp.PrpCons.P301020D);
                }
                break;
            case "file":
                dba.addTable(cons.io.db.prp.PrpCons.P3010300);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.prp.PrpCons.P3010305, cons.io.db.prp.PrpCons.P3010306, text));
                dba.addSort(cons.io.db.prp.PrpCons.P3010301);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(dba.executeSelect(), page, hd_IconSize.Value, "file", cons.io.db.prp.PrpCons.P3010304, cons.io.db.prp.PrpCons.P3010305, cons.io.db.prp.PrpCons.P301030D);
                }
                else
                {
                    ViewIcon(dba.executeSelect(), page, hd_IconSize.Value, "file", cons.io.db.prp.PrpCons.P3010304, cons.io.db.prp.PrpCons.P3010305, cons.io.db.prp.PrpCons.P301030D);
                }
                break;
            case "idio":
                dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.comn.user.UserCons.C3010405, cons.io.db.comn.user.UserCons.C3010407, text));
                dba.addSort(cons.io.db.comn.user.UserCons.C3010400);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(dba.executeSelect(), page, hd_IconSize.Value, "idio", cons.io.db.comn.user.UserCons.C3010408, cons.io.db.comn.user.UserCons.C3010407, cons.io.db.comn.user.UserCons.C3010407);
                }
                else
                {
                    ViewIcon(dba.executeSelect(), page, hd_IconSize.Value, "idio", cons.io.db.comn.user.UserCons.C3010408, cons.io.db.comn.user.UserCons.C3010407, cons.io.db.comn.user.UserCons.C3010407);
                }
                break;
            default:
                break;
        }
        hd_PageIndx.Value = page.ToString();
    }

    private void ViewIcon(DataTable list, int page, String size, String uri, String sid, String tip, String upd)
    {
        // 读取行信息
        String r = hd_RowCount.Value;
        if (!StringUtil.isValidateLong(r))
        {
            r = "10";
        }
        int rowCount = int.Parse(r);
        if (rowCount < 1)
        {
            rowCount = 1;
        }

        // 读取列信息
        String c = hd_ColCount.Value;
        if (!StringUtil.isValidateLong(c))
        {
            c = "5";
        }
        int colCount = int.Parse(c);
        if (colCount < 1)
        {
            colCount = 1;
        }

        StringBuilder buf = new StringBuilder();

        int row = 0;
        int col = 0;
        int cnt = list.Rows.Count;
        int cur = rowCount * colCount * page;
        int tmp;
        if (cur > cnt)
        {
            cur = 0;
        }
        DataRow item;

        buf.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"3\">");
        while (row < rowCount)
        {
            col = 0;
            tmp = cnt - cur;
            if (tmp > colCount)
            {
                tmp = colCount;
            }

            buf.Append("<tr>");
            while (col < tmp)
            {
                item = list.Rows[cur++];

                buf.Append("<td align=\"center\">");
                buf.Append("<img width=\"").Append(size).Append("\" height=\"").Append(size).Append("\" class=\"IMG_EXTSICON\" style=\"cursor:pointer;\"");
                buf.Append(" onclick=\"viewIcon('").Append(item[sid]).Append("');\"");
                buf.Append(" alt=\"").Append(item[tip]).Append("\"");
                buf.Append(" title=\"").Append(item[tip]).Append("，点击查看\"");
                buf.Append(" src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?uri=").Append(size).Append("&amp;sid=").Append(item[sid]).Append("\" />");
                buf.Append("<br />");
                buf.Append(item[tip]);
                buf.Append("</td>");

                col += 1;
            }
            while (col < colCount)
            {
                buf.Append("<td align=\"center\">&nbsp;</td>");
                col += 1;
            }
            buf.Append("</tr>");

            row += 1;
        }
        buf.Append("</table>");

        tmp = (cnt - 1) / (rowCount * colCount);
        lb_PrevPage.Enabled = (page > 0);
        lb_NextPage.Enabled = (page < tmp);
        lb_PageInfo.Text = (page + 1) + "/" + (tmp + 1);

        td_IconList.InnerHtml = buf.ToString();
        tr_IconList.Visible = true;
    }

    private void ViewList(DataTable list, int page, String size, String uri, String sid, String tip, String upd)
    {
        // 读取行信息
        String r = hd_RowCount.Value;
        if (!StringUtil.isValidateLong(r))
        {
            r = "10";
        }
        int rowCount = int.Parse(r);
        if (rowCount < 1)
        {
            rowCount = 1;
        }

        StringBuilder buf = new StringBuilder();

        int row = 0;
        int cnt = list.Rows.Count;
        int cur = rowCount * page;
        if (cur > cnt)
        {
            cur = 0;
        }
        int tmp = cnt - cur;
        if (tmp > rowCount)
        {
            tmp = rowCount;
        }
        DataRow item;

        buf.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"3\">");
        buf.Append("<tr>");
        buf.Append("<td align=\"center\" style=\"width:30px;\">图标</td>");
        buf.Append("<td align=\"center\">名称</td>");
        buf.Append("<td align=\"center\" style=\"width:120px;\">更新</td>");
        buf.Append("</tr>");
        while (row++ < tmp)
        {

            item = list.Rows[cur++];

            buf.Append("<tr>");
            buf.Append("<td align=\"center\">");
            buf.Append("<img width=\"").Append(size).Append("\" height=\"").Append(size).Append("\" class=\"IMG_EXTSICON\" style=\"cursor:pointer;\"");
            buf.Append(" onclick=\"viewIcon('").Append(item[sid]).Append("');\"");
            buf.Append(" alt=\"").Append(item[tip]).Append("\"");
            buf.Append(" title=\"").Append(item[tip]).Append("，点击查看\"");
            buf.Append(" src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?uri=").Append(size).Append("&amp;sid=").Append(item[sid]).Append("\" />");
            buf.Append("</td>");
            buf.Append("<td align=\"left\">");
            buf.Append(item[tip]);
            buf.Append("</td>");
            buf.Append("<td align=\"right\">");
            buf.Append(item[upd]);
            buf.Append("</td>");
            buf.Append("</tr>");
        }
        buf.Append("</table>");

        tmp = (cnt - 1) / rowCount;
        lb_PrevPage.Enabled = (page > 0);
        lb_NextPage.Enabled = (page < tmp);
        lb_PageInfo.Text = (page + 1) + "/" + (tmp + 1);

        td_IconList.InnerHtml = buf.ToString();
        tr_IconList.Visible = true;
    }
}
