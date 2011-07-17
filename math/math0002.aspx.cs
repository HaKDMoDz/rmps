using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class math_math0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "一般模式";
        Session[cons.wrp.WrpCons.SCRIPTID] = "math0002";

        List<K1V2> guidList = Wrps.GuidMath(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/math/math0002.aspx";
        guidItem.V1 = "一般模式";
        guidItem.V2 = "一般模式";

        if (IsPostBack)
        {
            return;
        }
    }
}