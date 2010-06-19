<%@ WebHandler Language="C#" Class="icon0001" %>

using System;
using System.Web;

/// <summary>
/// 图标文件处理器，用于处理公司徵标、软件图标、文件图标等。
/// </summary>
public class icon0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/png";

        // 大小
        String uri = (context.Request[cons.wrp.WrpCons.URI] ?? "").Trim();
        if (!rmp.util.StringUtil.isValidateLong(uri))
        {
            uri = "48";
        }
        uri = Convert.ToString(int.Parse(uri), 16).PadLeft(4, '0');

        // 索引
        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();

        if (!rmp.util.StringUtil.isValidatePath(sid))
        {
            sid = "comn,_NVL";
        }
        sid += ',';

        String dir = context.Server.MapPath(cons.EnvCons.DIR_DAT);
        if (!System.IO.File.Exists(dir + sid.Replace(',', System.IO.Path.DirectorySeparatorChar) + uri + ".png"))
        {
            sid = "comn,_NVL,";
        }

        context.Response.WriteFile(dir + sid.Replace(',', System.IO.Path.DirectorySeparatorChar) + uri + ".png");
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}