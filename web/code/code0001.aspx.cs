using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using rmp.wrp;
using rmp.comn.user;
using rmp.util;
using System.IO;
using rmp.io.db;
using System.Data;
using System.Text.RegularExpressions;
using rmp.bean;

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

        // 年份版权
        lb_CopyYear.Text = DateTime.Now.Year.ToString();

        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            ck_OverRide.Visible = false;
            ck_OverRide.Checked = false;
        }

        String url = Request.Params[cons.wrp.WrpCons.URI] ?? "http://";
        tf_FilePath.Text = url;

        Wrps.GuidEdit(Session)[2].K = cons.EnvCons.PRE_URL + "/edit/edit0002.aspx?uri=" + url;

        LoadData(url);
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
            ta_UserData.Text = WrpUtil.readHtmlCode(url);
        }
        catch (Exception)
        {
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
        DBAccess dba = new DBAccess();
        DataTable dt = dba.executeSelect("select A03 from a where a02='java.ini'");
        Dictionary<String, String> dict = new Dictionary<String, String>();
        String tmp;
        foreach (DataRow row in dt.Rows)
        {
            tmp = row["A03"] as String;
            dict[tmp] = tmp;
        }
        dt.Dispose();

        ta_UserData.Text = Code2Html(dict);
    }
    protected String Code2Html(Dictionary<String, String> srcDict)
    {
        StringBuilder buffer = new StringBuilder();
        buffer.Append("<html>");
        buffer.Append("<head>");
        buffer.Append("<title>").Append("").Append("</title>");
        buffer.Append("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" />");
        buffer.Append("<style type=\"text/css\">");
        buffer.Append("<!--.line_num {color: #666666; background-color: #E8E8E8;}//-->");
        buffer.Append("</style>");
        buffer.Append("</head>");
        buffer.Append("<body>");
        buffer.Append(cb_Format.SelectedValue == "0" ? "<pre style=\"font: 9pt Verdana, Fixedsys, Verdana, Tahoma;\">" : "<div style=\"font: 9pt Verdana, Fixedsys, Verdana, Tahoma;\">");
        String[] text = Regex.Replace(ta_UserData.Text, "[\r\n]", "\n").Split('\n');
        int size = text.Length;
        int cnt = size.ToString().Length;
        for (int i = 0; i < size; i += 1)
        {
            if (ck_ShowLine.Checked)
            {
                enCodeLine(buffer, i, cnt);
            }
            buffer.Append(enCodeHtml(text[i], srcDict)).Append(cb_Format.SelectedValue == "0" ? "\n" : "<br />");
        }
        buffer.Append(cb_Format.SelectedValue == "0" ? "</pre>" : "</div>");
        buffer.Append("</body>");
        buffer.Append("</html>");

        return buffer.ToString();
    }

    private void enCodeLine(StringBuilder buf, int lineNbr, int lineCnt)
    {
        buf.Append("<span class=\"line_num\">");
        buf.Append("<font color=\"#e8e8e8\">");
        String tmp = (lineNbr + 1).ToString();
        for (int i = tmp.Length, j = lineCnt + 2; i < j; i += 1)
        {
            buf.Append("0");
        }
        buf.Append("</font>");
        buf.Append(tmp);
        buf.Append(" </span>");
    }

    private String enCodeHtml(String text, Dictionary<String, String> srcDict)
    {
        bool spf = true;
        // 单引号优先
        if (spf)
        {
            int sp = text.IndexOf('\'');
            if (Regex.IsMatch(text, "'.*?'"))
            {
            }
        }
        bool dpf = true;

        // 双引号优先
        if (dpf)
        {
            if (Regex.IsMatch(text, "\".*?\""))
            {
                Match match = Regex.Match(text, "\".*?\"");
                StringBuilder buf = new StringBuilder();
                int ids = 0;
                int ide;
                String tmp;
                while (match.Success)
                {
                    ide = match.Index;
                    buf.Append(replace(text.Substring(ids, ide - ids), srcDict));
                    tmp = match.Value;
                    buf.Append(tmp);
                    ids = ide + tmp.Length;
                    match = match.NextMatch();
                }
                text = buf.Append(replace(text.Substring(ids, text.Length - ids), srcDict)).ToString();
            }
            else
            {
                text = replace(text, srcDict);
            }
        }

        if (cb_Format.SelectedValue == "1")
        {
            Match match = Regex.Match(text, "^\\s+");
            if (match.Success)
            {
                String tmp = match.Value;
                text = tmp.Replace(" ", "&nbsp;") + text.Substring(tmp.Length);
            }
        }
        return text;
    }

    private String replace(String text, Dictionary<String, String> dict)
    {
        StringBuilder buf = new StringBuilder(text);
        List<I1S1> list = new List<I1S1>();
        Match match = Regex.Match(text, "[$\\w\\d]+");
        while (match.Success)
        {
            list.Add(new I1S1(match.Index, match.Value));
            match = match.NextMatch();
        }

        I1S1 item;
        for (int i = list.Count - 1; i >= 0; i -= 1)
        {
            item = list[i];
            if (dict.ContainsKey(item.V))
            {
                buf.Remove(item.K, item.V.Length).Insert(item.K, getStyle(item.V));
            }
        }
        return buf.ToString();
    }

    private String getStyle(String key)
    {
        return String.Format("<font color=\"#0000C0\">{0}</font>", key);
    }
    #endregion

    #region 共用模块
    #endregion
}