using System;
using rmp.wrp;
using rmp.bean;
using System.Collections.Generic;
using rmp.io.db;
using System.Data;
using rmp.util;
using System.Text;

public partial class exts_exts0002 : System.Web.UI.Page
{
    private int iconSize = 48;
    private int rowCount = 10;
    private int colCount = 4;

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

        tr_IconList.Visible = false;
    }

    public int IconSize
    {
        get
        {
            return iconSize;
        }
        set
        {
            iconSize = value;
        }
    }

    public int ColCount
    {
        get
        {
            return colCount;
        }
        set
        {
            colCount = value;
        }
    }

    protected void bt_IconName_Click(object sender, EventArgs e)
    {
        String text = WrpUtil.text2Like(tf_IconName.Text);

        DBAccess dba = new DBAccess();
        switch (rb_IconMode.SelectedValue)
        {
            case "corp":
                dba.addTable(cons.io.db.prp.PrpCons.P3010100);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.prp.PrpCons.P3010105, cons.io.db.prp.PrpCons.P3010106, text));
                dba.addSort(cons.io.db.prp.PrpCons.P3010101);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(temp());
                }
                else
                {
                    ViewIcon(temp(), "", "", "");
                }
                break;
            case "soft":
                dba.addTable(cons.io.db.prp.PrpCons.P3010200);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.prp.PrpCons.P3010205, cons.io.db.prp.PrpCons.P3010206, text));
                dba.addSort(cons.io.db.prp.PrpCons.P3010201);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(temp());
                }
                else
                {
                    ViewIcon(temp(), "", "", "");
                }
                break;
            case "file":
                dba.addTable(cons.io.db.prp.PrpCons.P3010300);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.prp.PrpCons.P3010305, cons.io.db.prp.PrpCons.P3010306, text));
                dba.addSort(cons.io.db.prp.PrpCons.P3010301);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(temp());
                }
                else
                {
                    ViewIcon(temp(), "", "", "");
                }
                break;
            case "idio":
                dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
                dba.addWhere(String.Format("{0} LIKE '{2}' OR {1} LIKE '{2}'", cons.io.db.comn.user.UserCons.C3010405, cons.io.db.comn.user.UserCons.C3010407, text));
                dba.addSort(cons.io.db.comn.user.UserCons.C3010400);

                if (hd_ViewMode.Value == "list")
                {
                    ViewList(temp());
                }
                else
                {
                    ViewIcon(temp(), "", "", "");
                }
                break;
            default:
                break;
        }
    }

    protected void ib_ViewList_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

    }

    protected void ib_ViewIcon_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

    }

    private void ViewList(DataTable data)
    {
        StringBuilder buf = new StringBuilder();

        td_IconList.InnerHtml = buf.ToString();
        tr_IconList.Visible = true;
    }

    private void ViewIcon(DataTable list, String uri, String sid, String tip)
    {
        StringBuilder buf = new StringBuilder();

        int row = 0;
        int col = 0;
        int cnt = data.Rows.Count;
        int tmp;
        DataRow item;

        buf.Append("<table width=\"100%\">");
        while (row < rowCount)
        {
            col = 0;
            tmp = colCount < cnt ? colCount : cnt;

            buf.Append("<tr>");
            while (col < tmp)
            {
                item = list[tmp];

                buf.Append("<td align=\"center\">");
                buf.Append("<img width=\"").Append(iconSize).Append("\" height=\"").Append(iconSize).Append("\" class=\"IMG_EXTSICON\" style=\"cursor:pointer;\"");
                buf.Append(" onclick=\"viewIcon('").Append(item[sid]).Append("');\"");
                buf.Append(" alt=\"").Append(item[tip]).Append("\"");
                buf.Append(" src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?uri=").Append(item[uri]).Append("&amp;sid=").Append(item[sid]).Append("\" />");
                buf.Append("</td>");
                col += 1;
            }
            while (col < colCount)
            {
                buf.Append("<td align=\"center\">&nbsp;</td>");
                col += 1;
            }
            buf.Append("</tr>");

            cnt -= colCount;
            row += 1;
        }
        buf.Append("</table>");

        td_IconList.InnerHtml = buf.ToString();
        tr_IconList.Visible = true;
    }

    private DataTable temp()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(cons.io.db.prp.PrpCons.P3010202, typeof(String));
        dt.Columns.Add(cons.io.db.prp.PrpCons.P3010203, typeof(String));
        dt.Columns.Add(cons.io.db.prp.PrpCons.P3010204, typeof(String));
        dt.Columns.Add(cons.io.db.prp.PrpCons.P3010205, typeof(String));
        dt.Columns.Add(cons.io.db.prp.PrpCons.P3010206, typeof(String));

        DataRow row = dt.NewRow();
        row[0] = "1";
        row[1] = "2";
        row[2] = "3";
        row[3] = "中文";
        row[4] = "English";
        dt.Rows.Add(row);

        row = dt.NewRow();
        row[0] = "1";
        row[1] = "2";
        row[2] = "3";
        row[3] = "中文";
        row[4] = "English";
        dt.Rows.Add(row);

        row = dt.NewRow();
        row[0] = "1";
        row[1] = "2";
        row[2] = "3";
        row[3] = "中文";
        row[4] = "English";
        dt.Rows.Add(row);

        return dt;
    }
}
