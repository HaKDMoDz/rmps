using System;
using System.Collections;
using System.IO;
using System.Web.UI;
using cons.wrp;
using rmp.comn.user;
using rmp.util;

/// <summary>
/// 图标（ICO）文件上传
/// </summary>
public partial class icon_icon0102 : Page
{
    protected const int COL_SIZE = 5;
    protected const String DIR_PATH = "svg/";
    protected const int ROW_SIZE = 6;
    protected ArrayList iconList = new ArrayList();

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

        hd_IconHash.Value = Request[WrpCons.SID];

        String[] file = Directory.GetFiles(Server.MapPath(DIR_PATH), "*.svg");
        int indx = 0;
        while (indx < file.Length)
        {
            iconList.Add(Path.GetFileName(file[indx++]));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_FileUpld_Click(object sender, EventArgs e)
    {
        String cName = fu_FileUpld.FileName;
        if (cName == null || cName.Trim() == "")
        {
            return;
        }

        Stream stream = fu_FileUpld.FileContent;
        if (stream == null || stream.Length < 1)
        {
            return;
        }

        // 所有文件均保存到icon目录下
        cName = Path.GetFileName(cName);
        if (!cName.ToLower().EndsWith(".svg"))
        {
            return;
        }

        cName = HashUtil.getCurrTimeHex(false) + ".svg";
        String sPath = Server.MapPath(DIR_PATH + cName);
        fu_FileUpld.SaveAs(sPath);
        iconList.Add(cName);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ListIcon()
    {
    }
}