using System;
using System.Web.UI;

using cons.wrp;

public partial class tool_tool1313 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "Javascript代码加密";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1313";

        if (IsPostBack)
        {
            return;
        }
    }
}