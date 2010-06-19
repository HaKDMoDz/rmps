using System;
using System.Collections;
using System.IO;
using System.Web.UI;

using cons.wrp;

using rmp.comn.user;
using rmp.util;

/// <summary>
/// 选择已有图像文件
/// </summary>
public partial class icon_icon0104 : Page
{
    protected const int COL_SIZE = 5;
    protected const int ROW_SIZE = 6;
    protected String iconHash;
    protected ArrayList iconList = new ArrayList();
    protected String iconPath;

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

        iconPath = Request["dir"];
        if (!StringUtil.isValidate(iconPath))
        {
            Response.Redirect("~/index.aspx");
            return;
        }
        if (!iconPath.EndsWith("/"))
        {
            iconPath += '/';
        }
        iconHash = Request[WrpCons.SID];

        hd_IconPath.Value = iconPath;
        hd_IconHash.Value = iconHash;

        Header.Title = "选择已有文件";
        lb_NoteInfo.Text = "服务器文件路径：" + iconPath;

        iconList.Clear();

        String[] file = Directory.GetFiles(Server.MapPath(iconPath.StartsWith("/") ? '~' + iconPath : iconPath), "*0030.png");
        int size = file.Length;
        int indx = 0;
        while (indx < size)
        {
            iconList.Add(Path.GetFileName(file[indx++]));
        }
    }
}