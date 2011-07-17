using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class info_info0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "交换链接";
        Session[cons.wrp.WrpCons.SCRIPTID] = "info0002";

        List<K1V2> guidList = Wrps.GuidInfo(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 item = guidList[1];
        item.K = cons.EnvCons.PRE_URL + "/info/info0002.aspx";
        item.V1 = "交换链接";
        item.V2 = "交换链接";

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }
    }
}