<%@ WebHandler Language="C#" Class="Page" %>

using System;
using System.Web;

public class Page : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        context.Response.Write("<html><head><title>Hello World</title></head><body>Hello World!</body></html>");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}