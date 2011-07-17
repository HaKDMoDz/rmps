using System;

public partial class user_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户首页";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0001";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 1;

        if (IsPostBack)
        {
            return;
        }
    }
}