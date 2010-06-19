using System;
using System.Web.UI;
using cons.wrp;

public partial class tool_tool1304 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "中国农历";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1304";

        if (IsPostBack)
        {
            return;
        }
    }
}