using System;
using System.IO;
using System.Text;
using System.Web.UI;

using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class edit_edit0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "在线网页编辑";
        Session[cons.wrp.WrpCons.SCRIPTID] = "edit0002";

        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidEdit(Session).Count;

        if (IsPostBack)
        {
            return;
        }

        int width = 480;
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            ck_OverRide.Visible = false;
            ck_OverRide.Checked = false;
            width = 580;
        }

        String url = Request.Params[cons.wrp.WrpCons.URI] ?? "http://";
        tf_FilePath.Text = url;
        tf_FilePath.Width = width;

        Wrps.GuidEdit(Session)[1].K = cons.EnvCons.PRE_URL + "/edit/edit0001.aspx?uri=" + url;

        LoadData(url);
    }

    protected void bt_OpenData_Click(object sender, EventArgs e)
    {
        String filePath = tf_FilePath.Text.ToLower();
        if (filePath.Trim() == "")
        {
            hd_ErrMsg.Value = "请输入您要查看的网页地址！";
            return;
        }

        if (filePath.StartsWith("~/"))
        {
            if (UserInfo.Current(Session).UserRank == cons.comn.user.UserInfo.LEVEL_09)
            {
                readInner(filePath);
                return;
            }

            hd_ErrMsg.Value = "请输入一个合法的链接地址，如：“http://amonsoft.cn/”。";
            return;
        }

        Wrps.GuidEdit(Session)[1].K = cons.EnvCons.PRE_URL + "/edit/edit0001.aspx?uri=" + filePath;
        readOuter(filePath);
    }

    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String htmlText = hd_UserData.Value;
        if (string.IsNullOrEmpty(htmlText))
        {
            return;
        }

        String fileExts = tf_FilePath.Text.ToLower();
        if (fileExts.StartsWith("http://"))
        {
            fileExts = ".html";
        }
        else
        {
            fileExts = Path.GetExtension(fileExts);
            if (string.IsNullOrEmpty(fileExts))
            {
                fileExts = ".html";
            }
        }
        String filePath = Server.MapPath(ck_OverRide.Checked ? tf_FilePath.Text : "~/edit/file/" + UserInfo.Current(Session).UserCode + fileExts);
        File.WriteAllText(filePath, htmlText, Encoding.UTF8);

        if (!ck_OverRide.Checked)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "text/html";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".html");
            Response.WriteFile(filePath);
            Response.End();
        }
    }

    private void readInner(String url)
    {
        String filePath = Server.MapPath(url);
        if (!File.Exists(filePath))
        {
            hd_ErrMsg.Value = "请输入一个合法的链接地址，必需以“http://（站外）”或“~/（站内）”开头。";
            return;
        }

        hd_UserData.Value = File.ReadAllText(filePath, Encoding.UTF8);
    }

    private void readOuter(String filePath)
    {
        //获得指定链接的源代码
        if (filePath == "http://")
        {
            hd_ErrMsg.Value = "请输入您要查看的网页地址！";
            return;
        }
        if (!filePath.StartsWith("http://"))
        {
            filePath = "http://" + filePath;
        }

        try
        {
            hd_UserData.Value = WrpUtil.readHtmlCode(filePath);
        }
        catch (Exception)
        {
            hd_ErrMsg.Value = "请输入一个合法的链接地址，如：“http://amonsoft.cn/”。";
        }
    }

    private void LoadData(String url)
    {
        //获得指定链接的源代码
        if (url == "http://")
        {
            return;
        }
        if (!url.StartsWith("http://"))
        {
            url = "http://" + url;
        }

        try
        {
            hd_UserData.Value = WrpUtil.readHtmlCode(url);
        }
        catch (Exception)
        {
        }
    }
}