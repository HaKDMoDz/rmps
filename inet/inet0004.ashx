<%@ WebHandler Language="C#" Class="inet0004" %>

using System.Web;

public class inet0004 : IHttpHandler
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        context.Response.Write("<HTML><HEAD><TITLE>A Really Basic Document-HTML Code Tutorial</TITLE></HEAD><body>This is a really basic document.<p></p><p></p></body></HTML>");
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}