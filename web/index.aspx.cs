using System;
using System.Text.RegularExpressions;
using System.Web.UI;

public partial class index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // 后缀解析快捷访问
        if (Regex.IsMatch(Request.RawUrl, "/index\\.aspx\\?\\..+$"))
        {
            Server.Transfer("~/exts/exts0001.aspx?exts=" + Request.RawUrl.Substring(12));
            return;
        }

        // 网络导航快捷访问
        if (Regex.IsMatch(Request.RawUrl, "/index\\.aspx\\?/[0-9A-Za-z_-]{1,8}$"))
        {
            String uri = rmp.wrp.link.Link.Read(Request.RawUrl.Substring(12));
            if (rmp.util.StringUtil.isValidate(uri))
            {
                Response.Redirect(uri);
            }
            new rmp.io.db.DBAccess().UpdateStep(cons.io.db.prp.PrpCons.P3070100, cons.io.db.prp.PrpCons.P3070104, uri, cons.io.db.prp.PrpCons.P3070101, 1);
            return;
        }

        // 计算助理快捷访问
        if (Regex.IsMatch(Request.RawUrl, "/index\\.aspx\\?=.+$"))
        {
            Server.Transfer("~/math/math0001.aspx?math=" + Request.RawUrl.Substring(13));
            return;
        }

        if (!SiteGuid())
        {
            LoadData();
        }
    }

    /// <summary>
    /// 网址导航
    /// </summary>
    private bool SiteGuid()
    {
        // 用户访问路径标识获取
        String authority = Request.Url.Authority;
        if (!string.IsNullOrEmpty(authority))
        {
            authority = authority.ToLower();

            foreach (String key in rmp.wrp.Wrps.SiteList.Keys)
            {
                if (authority.IndexOf(key) >= 0)
                {
                    String uri = rmp.wrp.Wrps.SiteList[key];
                    if (uri.StartsWith("exec:"))
                    {
                        uri = uri.Substring(5);
                        Regex regex = new Regex("^\\d{4}:");
                        if (regex.IsMatch(uri))
                        {
                            rmp.wrp.Wrps.SetStyles(Session, regex.Match(uri).Value.Substring(0, 4));
                            Server.Transfer(regex.Replace(uri, ""));
                        }
                        return true;
                    }
                    if (uri.StartsWith("send:"))
                    {
                        Response.Redirect(uri);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// 初始数据加载
    /// </summary>
    private void LoadData()
    {
        // 年份版权
        lb_CopyYear.Text = DateTime.Now.Year.ToString();
    }
}
