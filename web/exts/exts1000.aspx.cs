using System;
using System.Web.UI;

public partial class exts_exts1000 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "相关知识";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1000";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        if (IsPostBack)
        {
            return;
        }
    }
}
