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
        response.Write("{\"json_data\" : {\"data\" : [{\"data\" : \"A node\",\"metadata\" : { id : 23 },\"children\" : [ \"Child 1\", \"A Child 2\" ]},{\"attr\" : { \"id\" : \"li.node.id1\" },\"data\" : {\"title\" : \"Long format demo\",\"attr\" : { \"href\" : \"#\" }}}]},\"plugins\" : [ \"themes\", \"json_data\", \"ui\" ]}");
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