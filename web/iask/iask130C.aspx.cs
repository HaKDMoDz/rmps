using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.util;
using rmp.wrp;

/// <summary>
/// IP查询
/// </summary>
public partial class iask_iask130C : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "ＩＰ查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask130C";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask130C.aspx";
        guidItem.V1 = "ＩＰ查询";
        guidItem.V2 = "ＩＰ查询";

        tf_IpText.Text = Request.UserHostAddress;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_IpText_Click(object sender, EventArgs e)
    {
        lb_IpInfo.Text = IpSearch(tf_IpText.Text);
        tf_IpText.Focus();
    }

    public String IpSearch(String ip)
    {
        if (!StringUtil.isValidate(ip))
        {
            return "请输入您要查询的IP地址！";
        }
        return rmp.wrp.card.Card.IpLoc(ip);
    }
}