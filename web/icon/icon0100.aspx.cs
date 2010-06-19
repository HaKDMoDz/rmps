using System;
using System.Web.UI;

using cons.wrp;

using rmp.comn.user;
using rmp.util;

public partial class icon_icon0100 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }

        String sid = Request[WrpCons.SID];
        if (sid == null)
        {
            sid = HashUtil.getCurrTimeHex(false);
        }
        else
        {
            sid = sid.Trim();
            if (sid == "" || sid == "0")
            {
                sid = HashUtil.getCurrTimeHex(false);
            }
        }
        hd_IconHash.Value = sid;
        hd_IconPath.Value = Request["dir"];
        cb_TypeList.Attributes.Add("onchange", "showTips();");
    }

    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        string load = Request["load"];
        load = (string.IsNullOrEmpty(load) ? "/data/" + hd_IconPath.Value : "/icon/" + load) + '/';
        Response.Redirect("~/icon/icon010" + cb_TypeList.SelectedValue + ".aspx?sid=" + hd_IconHash.Value + "&dir=" + load);
    }
}