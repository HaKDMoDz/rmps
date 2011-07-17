using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class mpwd_mpwd0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.SCRIPTID] = "mpwd0002";

        if (IsPostBack)
        {
            return;
        }

        String path = Server.MapPath("~/down/data/130F0000.txt");
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
                cell.Attributes.Add("class", "TD_DataItem_TL_N");
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
            //else if (tmp.StartsWith("soft="))
            //{
            //    lb_SoftName.Text = tmp.Substring(5);
            //    lt_SoftName.Text = tmp.Substring(5);
            //}
            //else if (tmp.StartsWith("ver="))
            //{
            //    lb_Ver.Text = tmp.Substring(4);
            //}
            //else if (tmp.StartsWith("env="))
            //{
            //    lb_Env.Text = tmp.Substring(4);
            //}
            tmp = sr.ReadLine();
        }
        sr.Close();
    }
}