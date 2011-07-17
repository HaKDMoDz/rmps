using System;
using System.Web.UI;
using rmp.comn.user;
using rmp.wrp;

public partial class comn_comn0302 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限检测
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 5;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户查看";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0302";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidUser(Session).Count;
        #endregion

        // 是否页面回传
        if (IsPostBack)
        {
            return;
        }
    }
}