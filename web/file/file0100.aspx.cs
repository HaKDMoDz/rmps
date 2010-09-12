using System;
using rmp.util;
using rmp.comn.user;

public partial class file_file0100 : System.Web.UI.Page
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

        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (StringUtil.isValidateHash(sid))
        {
            hd_FileHash.Value = sid;
        }
        hd_FilePath.Value = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();
    }

    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/file/file010" + cb_TypeList.SelectedValue + ".aspx?sid=" + hd_FileHash.Value + "&opt=" + hd_FilePath.Value);
    }
}
