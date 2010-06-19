using System;
using System.Web.UI;

using cons.wrp;

public partial class date_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "今日推荐";
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";
    }
}
