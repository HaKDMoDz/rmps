<%@ WebHandler Language="C#" Class="s" %>

using System;
using System.Web;

public class s : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}