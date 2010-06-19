using System;
using System.IO;
using rmp.comn.user;
using rmp.wrp;

public partial class comn_comn0501 : System.Web.UI.Page
{
    protected String[] fileList = { };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "文件下载";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0501";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidComn(Session).Count;

        if (IsPostBack)
        {
            return;
        }

        LoadData();
    }

    private void LoadData()
    {
        fileList = Directory.GetFiles(Server.MapPath("~/comn/amon/"));
    }
}
