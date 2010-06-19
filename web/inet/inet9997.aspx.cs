using System;
using System.Web.UI;

using cons.wrp;

using rmp.comn.user;
using rmp.wrp;

public partial class inet_inet9997 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页精灵";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet9997";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidInfo(Session).Count;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }
    }
}