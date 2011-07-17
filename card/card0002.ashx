<%@ WebHandler Language="C#" Class="card0002" %>

using System.Web;

/// <summary>
/// 卡片生成类
/// </summary>
public class card0002 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}