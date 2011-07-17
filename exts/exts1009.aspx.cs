using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

public partial class exts_exts1009 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Windows Internet Explorer 8 加速器";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1009";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts1009.aspx";
        guidItem.V1 = "IE加速器";
        guidItem.V2 = "IE加速器";

        if (IsPostBack)
        {
            return;
        }
    }
}