using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;

using cons.wrp;

using rmp.comn.user;
using rmp.wrp;

/// <summary>
/// 源码查看
/// </summary>
public partial class tool_tool1310 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "源码查看";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1310";

        if (IsPostBack)
        {
            return;
        }

        bool root = UserInfo.Current(Session).UserRank == cons.comn.user.UserInfo.LEVEL_09;
        ta_SrcText.ReadOnly = !root;
        tr_FilePath.Visible = root;
    }

    protected void bt_ViewSrc_Click(object sender, EventArgs e)
    {
        readSrc();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_FilePath_Click(object sender, EventArgs e)
    {
        String file = tf_FilePath.Text;
        if (file == null || file.Trim() == "")
        {
            Wrps.ShowMesg(Master, "文件路径为空，请输入文件路径！");
            tf_FilePath.Focus();
            return;
        }

        String text = ta_SrcText.Text;
        if (string.IsNullOrEmpty(text))
        {
            Wrps.ShowMesg(Master, "文本内容为空，请输入文本内容！");
            tf_FilePath.Focus();
            return;
        }

        //写入文件
        StreamWriter sw = new StreamWriter(Server.MapPath(file), false, Encoding.UTF8);
        sw.Write(text);
        sw.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ck_LineWrap_CheckedChanged(object sender, EventArgs e)
    {
        ta_SrcText.Wrap = ck_LineWrap.Checked;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tf_ViewSrc_TextChanged(object sender, EventArgs e)
    {
        readSrc();
    }

    private void readSrc()
    {
        //获得指定链接的源代码
        String PageUrl = tf_ViewSrc.Text.ToLower();
        if (PageUrl == null || PageUrl.Trim() == "")
        {
            Wrps.ShowMesg(Master, "请输入您要查看的网页地址！");
            return;
        }
        if (!PageUrl.StartsWith("http://"))
        {
            PageUrl = "http://" + PageUrl;
            tf_ViewSrc.Text = PageUrl;
        }
        if (PageUrl.ToLower() == "http://")
        {
            Wrps.ShowMesg(Master, "请输入您要查看的网页地址！");
            return;
        }

        WebRequest request = WebRequest.Create(PageUrl);
        WebResponse response = request.GetResponse();
        Stream resStream = response.GetResponseStream();
        String ct = response.ContentType;
        String te = "utf-8";
        if (ct != null && ct.Trim() != "")
        {
            ct = ct.Trim().ToLower().Replace(" ", "");

            int eq = ct.IndexOf("charset");
            if (eq >= 0)
            {
                te = ct.Substring(eq + 8);
            }
        }
        StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding(te));
        ta_SrcText.Text = sr.ReadToEnd();
        resStream.Close();
        sr.Close();
    }
}