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

        // 用户编码
        String usn = "";
        // 当前版本
        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        // 网络地址
        String uri = (context.Request[cons.wrp.WrpCons.URI] ?? "").Trim();
        // 操作系统
        String opt = (context.Request[cons.wrp.WrpCons.OPT] ?? "").Trim();
        String uip = context.Request.UserHostAddress;
        String upc = context.Request.UserHostName;

        System.IO.StreamWriter writer = System.IO.File.AppendText(context.Server.MapPath("~/mpwd/mpwd.txt"));
        writer.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", sid, uri, uip, opt, upc, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        writer.Flush();
        writer.Close();

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