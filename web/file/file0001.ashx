<%@ WebHandler Language="C#" Class="file0001" %>

using System;
using System.Web;

public class file0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // 索引
        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (!rmp.util.StringUtil.isValidatePath(sid))
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("您传入的参数不正确！");
            context.Response.End();
        }

        String dir = context.Server.MapPath(cons.EnvCons.DIR_DAT);
        if (!System.IO.File.Exists(dir + sid.Replace(',', System.IO.Path.DirectorySeparatorChar) + ".aed"))
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("您要查看的文件路径不存在！");
            context.Response.End();
        }

        context.Response.ContentType = "application/octet-stream";
        context.Response.WriteFile(dir + sid.Replace(',', System.IO.Path.DirectorySeparatorChar) + ".aed");
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