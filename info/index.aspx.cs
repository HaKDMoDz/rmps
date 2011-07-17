using System;
using System.Web.UI;

using cons.wrp;

using rmp.wrp;

public partial class info_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "关于作者";
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidInfo(Session).Count;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }
    }
}