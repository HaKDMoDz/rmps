using System.Web;
using Me.Amon.Da.Db;

namespace Me.Amon
{
    /// <summary>
    /// Card1 的摘要说明
    /// </summary>
    public class C : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/javascript";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}