<%@ WebHandler Language="C#" Class="Imgs" %>

using System;
using System.Web;

public class Imgs : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/javascript";
        context.Response.Write("{}");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}