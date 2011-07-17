<%@ WebHandler Language="C#" Class="wime0001" %>

using System.Text;
using System.Web;
using rmp.util;
using rmp.wrp.wime;

public class wime0001 : IHttpHandler
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        // MIME及编码设置
        context.Response.ContentType = "text/javascript";
        context.Response.ContentEncoding = Encoding.UTF8;

        // 输出代码到客户端
        context.Response.Write(Wime.TpltWime);
        context.Response.End();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}