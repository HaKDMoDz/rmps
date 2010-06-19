using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class math_math1001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "普通模式";
        Session[cons.wrp.WrpCons.SCRIPTID] = "math1001";

        List<K1V2> guidList = Wrps.GuidMath(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/math/math0002.aspx";
        guidItem.V1 = "普通模式";
        guidItem.V2 = "普通模式";

        if (IsPostBack)
        {
            return;
        }
    }
}