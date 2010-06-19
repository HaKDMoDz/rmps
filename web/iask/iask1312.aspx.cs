using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class iask_iask1312 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Open代码生成器";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask1312";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask1312.aspx";
        guidItem.V1 = "Open代码生成器";
        guidItem.V2 = "Open代码生成器";

        if (IsPostBack)
        {
            return;
        }
    }
}