<%@ WebHandler Language="C#" Class="Page" %>

using System;
using System.Web;

public class Page : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var type = context.Request["t"];
        if (type == "cat")
        {
            LoadCat(context.Response);
            return;
        }

        var file = context.Request["f"];
        if (!string.IsNullOrEmpty(file))
        {
            LoadLog(context.Response);
            return;
        }

        context.Response.ContentType = "text/html";
        context.Response.Write("<html><head><title>您好！</title></head><body>Hello World!</body></html>");
    }

    private void LoadCat(HttpResponse response)
    {
        response.ContentType = "text/javascript";
        response.Write("[{name:\"test1\", open:true, children:[{name:\"test1_1\"}, {name:\"test1_2\"}]},{name:\"test2\", open:true, children:[{name:\"test2_1\"}, {name:\"test2_2\"}]}];");
        response.End();
    }

    private void LoadLog(HttpResponse response)
    {
        response.ContentType = "text/html";
        response.Write("<html><head><title>Hello World</title></head><body>Hello World!</body></html>");
        response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}