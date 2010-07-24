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
        rb_ExtsCase.Items[0].Attributes.Add("accesskey", "R");
        rb_ExtsCase.Items[1].Attributes.Add("accesskey", "H");
        rb_ExtsCase.Items[2].Attributes.Add("accesskey", "U");
        rb_ExtsCase.Items[3].Attributes.Add("accesskey", "L");
        rb_ExtsCase.SelectedValue = (Session[cons.wrp.WrpCons.P3010000_CASE] ?? "1").ToString().Trim();
        ck_ExtsAjax.Checked = ("1" == (Session[cons.wrp.WrpCons.P3010000_AJAX] ?? "1").ToString().Trim());
        lb_AmonInfo.Text = Exts.ExtsSize.ToString();
    }
}
