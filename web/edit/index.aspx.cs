using System;
using System.Web.UI;

public partial class edit_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Server.Transfer("~/edit/edit0001.aspx");

        /*/ Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX]= 0;
        Session[cons.wrp.WrpCons.GUIDNAME]= "网页源码查看";
        Session[cons.wrp.WrpCons.SCRIPTID]= "index";

        Session[cons.wrp.WrpCons.GUIDSIZE]= 1;

        if (IsPostBack)
        {
            return;
        }*/
    }
}