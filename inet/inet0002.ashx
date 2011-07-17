<%@ WebHandler Language="C#" Class="inet0002" %>

using System.Text;
using System.Web;
using cons.wrp;
using rmp.util;

/// <summary>
/// 数据统计
/// </summary>
public class inet0002 : IHttpHandler
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/javascript";
        context.Response.ContentEncoding = Encoding.UTF8;

        context.Response.Write(WrpUtil.SyncScript + "net_amonsoft_load.Load('http://amonsoft.net/inet/c/NetHelper.css','css');net_amonsoft_load.Load('http://amonsoft.net/inet/inet0001.ashx?sid=" + context.Request[WrpCons.SID] + "','js',net_amonsoft_user);");
        //context.Response.Write(WrpUtil.SyncScript);
        //context.Response.Write(string.Format("net_amonsoft_load.Load('/{0}inet/c/NetHelper.css','css');", cons.EnvCons.PRE_URL));
        //context.Response.Write(string.Format("net_amonsoft_load.Load('/{0}inet/inet0001.ashx?sid={1}','js',net_amonsoft_user);", cons.EnvCons.PRE_URL, context.Request[WrpCons.SID]));
        context.Response.End();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}