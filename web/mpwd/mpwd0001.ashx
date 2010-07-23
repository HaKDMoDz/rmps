<%@ WebHandler Language="C#" Class="mpwd0001" %>

using System;
using System.Web;

/// <summary>
/// 图标文件处理器，用于处理公司徵标、软件图标、文件图标等。
/// </summary>
public class mpwd0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/png";

        // 用户
        String uri = (context.Request[cons.wrp.WrpCons.URI] ?? "").Trim();
        // 版本
        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();
		// IP
		String opt = "";

        String dir = context.Server.MapPath(cons.EnvCons.DIR_DAT);
        context.Response.WriteFile(dir + "mpwd/mpwd0001.png");
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