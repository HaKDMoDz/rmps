using System;
using cons.wrp;
using rmp.bean;
using rmp.wrp;

/// <summary>
/// 基于网页形式搜索
/// </summary>
public partial class srch_srch0001 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "全能搜索";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch0001";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        K1V2 guidItem = Wrps.GuidSrch(Session)[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0001.aspx";
        guidItem.V1 = "在线使用";
        guidItem.V2 = "在线使用";

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }
    }
}
