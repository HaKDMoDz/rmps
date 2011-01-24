using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using rmp.bean;
using rmp.comn.user;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.code;

public partial class code_code0001 : Page
{
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页源码查看";
        Session[cons.wrp.WrpCons.SCRIPTID] = "code0001";

        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidEdit(Session).Count;

        if (IsPostBack)
        {
            return;
        }

        LoadData();
    }
    private void LoadData()
    {
        // 年份版权
        lb_CopyYear.Text = DateTime.Now.Year.ToString();
        im_AmonLogo.ImageUrl = "~/logo/code/logo.png";

        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            ck_OverRide.Visible = false;
            ck_OverRide.Checked = false;
        }

        rb_EditCode.Checked = true;
        ck_ShowLineNbr.Checked = true;
        ck_ShowLinkUri.Checked = true;
        cb_TagStyle.SelectedValue = UserOpt.TAG_STYLE_DIV;

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2050300);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2050301);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2050311);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2050302);
        dba.addSort(cons.io.db.wrp.WrpCons.W2050302, true);
        cb_Language.DataTextField = cons.io.db.wrp.WrpCons.W2050302;
        cb_Language.DataValueField = cons.io.db.wrp.WrpCons.W2050311;
        cb_Language.DataSource = dba.executeSelect();
        cb_Language.DataBind();
        cb_Language.Items.Insert(0, "--请选择--");

        String url = Request.Params[cons.wrp.WrpCons.URI] ?? "http://";
        if (!url.StartsWith("http://"))
        {
            url = "http://" + url;
        }
        tf_FilePath.Text = url;

        //获得指定链接的源代码
        if (url != "http://")
        {
            try
            {
                ta_UserData.Text = WrpUtil.readHtmlCode(url);
            }
            catch (Exception)
            {
            }
        }
    }
    #endregion

    #region 源码查看
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

        Wrps.GuidEdit(Session)[2].K = cons.EnvCons.PRE_URL + "/edit/edit0002.aspx?uri=" + filePath;
        readOuter(filePath);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_LineWrap_CheckedChanged(object sender, EventArgs e)
    {
        ta_UserData.Wrap = ck_LineWrap.Checked;
    }

    private void readInner(String url)
    {
        String filePath = Server.MapPath(url);
        if (!File.Exists(filePath))
        {
            hd_ErrMsg.Value = "请输入一个合法的链接地址，必需以“http://（站外）”或“~/（站内）”开头。";
            return;
        }

        ta_UserData.Text = File.ReadAllText(filePath, Encoding.UTF8);
    }

    /// <summary>
    /// 读取外部URL
    /// </summary>
    /// <param name="filePath"></param>
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
            ta_UserData.Text = WrpUtil.readHtmlCode(filePath);
        }
        catch (Exception)
        {
            hd_ErrMsg.Value = "请输入一个合法的链接地址，如：“http://amonsoft.cn/”。";
        }
    }
    #endregion

    #region 在线编辑

    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String htmlText = ta_UserData.Text;
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
    #endregion

    #region 代码转换
    protected void bt_EditCode_Click(object sender, EventArgs e)
    {
        UserOpt userOpt = new UserOpt();
        userOpt.Language = "";
        userOpt.ShowLineNbr = ck_ShowLineNbr.Checked;
        userOpt.InLineStyle = ck_InLineStyle.Checked;
        userOpt.ShowLinkUri = ck_ShowLinkUri.Checked;
        userOpt.TagStyle = cb_TagStyle.SelectedValue;
        GenHtml genHtml = new GenHtml(ta_UserData.Text, userOpt);
        ta_UserData.Text = genHtml.ToHtml();
    }
    #endregion

    #region 共用模块
    #endregion
}