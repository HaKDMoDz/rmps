using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class code_iGridObj_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDSIZE] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "iGridObj";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iGridObj/index";

        List<K1V2> guidList = Wrps.GuidCode(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 1;
        K1V2 guidItem = guidList[1];
        guidItem.K = "";
        guidItem.V1 = "";
        guidItem.V2 = "";

        if (IsPostBack)
        {
            return;
        }
    }
}