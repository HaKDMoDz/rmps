using System;
using rmp.comn.user;
using rmp.wrp;

public partial class comn_comn0502 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "文件上传";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0502";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidComn(Session).Count;

        if (IsPostBack)
        {
            return;
        }
    }

    protected void bt_SaveFile_Click(object sender, EventArgs e)
    {
        String fileName = fu_SaveFile.FileName;
        if (fileName == null || fileName.Trim() == "" || fu_SaveFile.FileContent.Length < 1)
        {
            Wrps.ShowMesg(Master, "请选择您要上传的文件。");
            return;
        }

        fu_SaveFile.SaveAs(Server.MapPath("~/comn/amon/" + fu_SaveFile.FileName + ".pdf"));
    }
}
