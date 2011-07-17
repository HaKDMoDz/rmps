using System;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.wrp.soft;

public partial class down_down0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        String sid = Request[WrpCons.SID];
        if (string.IsNullOrEmpty(sid))
        {
            sid = "130F0000";
        }

        ArrayList list = Soft.GetSoftList();
        K1V3 kv;
        for (int i = 0; i < list.Count; i += 1)
        {
            kv = (K1V3) list[i];
            if (kv.K == sid)
            {
                lb_SoftName.Text = "&nbsp;&nbsp;" + kv.V1 + "&nbsp;" + kv.V2 + "<br />&nbsp;&nbsp;Build&nbsp;" + kv.V3 + "<br />";
                lt_SoftName.Text = kv.V1;
                break;
            }
        }

        LoadData(sid);
    }

    private void LoadData(String sid)
    {
        String path = Server.MapPath("data/" + sid + ".txt");
        if (!File.Exists(path))
        {
            return;
        }

        StreamReader sr = File.OpenText(path);
        String tmp = sr.ReadLine();
        HtmlTableRow rows;
        HtmlTableCell cell;
        HyperLink link = null;
        while (tmp != null)
        {
            tmp = tmp.Trim();
            if (tmp.StartsWith("text="))
            {
                link = new HyperLink();
                link.Target = "_blank";
                link.Text = tmp.Substring(5);

                cell = new HtmlTableCell();
                cell.Align = "left";
                cell.Attributes.Add("class", "TD_DataItem_TL_L");
                cell.Controls.Add(link);

                rows = new HtmlTableRow();
                rows.Cells.Add(cell);
                tb_DownList.Rows.Add(rows);
            }
            else if (tmp.StartsWith("link="))
            {
                link.NavigateUrl = tmp.Substring(5);
            }
            else if (tmp.StartsWith("tips="))
            {
                link.ToolTip = tmp.Substring(5);
            }
            else if (tmp.StartsWith("soft="))
            {
                lb_SoftName.Text = tmp.Substring(5);
                lt_SoftName.Text = tmp.Substring(5);
            }
            else if (tmp.StartsWith("ver="))
            {
                lb_Ver.Text = tmp.Substring(4);
            }
            else if (tmp.StartsWith("env="))
            {
                lb_Env.Text = tmp.Substring(4);
            }
            tmp = sr.ReadLine();
        }
        sr.Close();
    }
}