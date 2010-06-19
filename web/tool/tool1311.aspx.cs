using System;
using System.Web.UI;

using cons.wrp;

public partial class tool_tool1311 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "正则运算";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1311";

        if (IsPostBack)
        {
            return;
        }
    }
}