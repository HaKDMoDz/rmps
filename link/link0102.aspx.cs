using System;
using System.Web.UI;
using rmp.comn.user;

/// <summary>
/// 链接详细
/// </summary>
public partial class link_link0102 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "链接查看";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0102";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 5;

        if (IsPostBack)
        {
            return;
        }
    }
}