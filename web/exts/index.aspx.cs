using System;
using System.Web.UI;

using rmp.bean;
using rmp.wrp.exts;
using rmp.wrp.soft;

public partial class exts_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        String ver = "";
        foreach (K1V3 item in Soft.GetSoftList())
        {
            if ("13010000" == item.K)
            {
                ver = item.V2;
                break;
            }
        }
        Session[cons.wrp.WrpCons.GUIDNAME] = "后缀解析 " + ver;
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        if (IsPostBack)
        {
            return;
        }

        // Index Page初始化
        lb_AmonInfo.Text = Exts.ExtsSize.ToString();
    }
}
