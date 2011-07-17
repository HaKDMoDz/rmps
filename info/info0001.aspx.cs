using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class info_info0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "联系作者";
        Session[cons.wrp.WrpCons.SCRIPTID] = "info0001";

        List<K1V2> guidList = Wrps.GuidInfo(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 item = guidList[1];
        item.K = cons.EnvCons.PRE_URL + "/info/info0001.aspx";
        item.V1 = "联系作者";
        item.V2 = "联系作者";

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        String host = String.Format("{0}://{1}/", Request.Url.Scheme, Request.Url.Authority);
        hl_Host.Text = host;
        hl_Host.NavigateUrl = host;
    }
}