using System;
using System.Text.RegularExpressions;
using System.Web.UI;

using cons.wrp;

using rmp.wrp;

/// <summary>
/// IP查询
/// </summary>
public partial class tool_tool130C : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "ＩＰ查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "130C";

        if (IsPostBack)
        {
            return;
        }

        string ip = Request[WrpCons.SID] ?? "";
        if (!new Regex("^[.:\\w]+$").IsMatch(ip))
        {
            ip = Request.UserHostAddress;
        }
        tf_IpText.Text = ip;
        lb_IpInfo.Text = rmp.wrp.card.Card.IpLoc(ip);
        tf_IpText.Focus();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_IpText_Click(object sender, EventArgs e)
    {
        String ip = tf_IpText.Text;
        if (ip == null || ip.Trim() == "")
        {
            Wrps.ShowMesg(Master, "请输入您要查询的IP地址！");
            tf_IpText.Focus();
            return;
        }

        lb_IpInfo.Text = rmp.wrp.card.Card.IpLoc(ip);
    }
}