using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

public partial class user_user0003 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_01)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "口令修改";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0003";

        List<K1V2> guidList = Wrps.GuidUser(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/user/user0003.aspx";
        guidItem.V1 = "口令修改";
        guidItem.V2 = "口令修改";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        #endregion

        if (IsPostBack)
        {
            return;
        }
    }
}