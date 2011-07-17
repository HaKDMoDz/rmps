using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class iask_iask1313 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Javascript代码加密器";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask1313";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask1313.aspx";
        guidItem.V1 = "Javascript代码加密器";
        guidItem.V2 = "Javascript代码加密器";

        if (IsPostBack)
        {
            return;
        }
    }
}