using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class code_iBookObj_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网络收藏";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iBookObj/index";

        List<K1V2> guidList = Wrps.GuidCode(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/code/iBookObj/index.aspx";
        guidItem.V1 = "网络收藏";
        guidItem.V2 = "网络收藏";

        if (IsPostBack)
        {
            return;
        }
    }
}