using System.IO;
using System.Web;

namespace Me.Amon
{
    /// <summary>
    /// l 的摘要说明
    /// </summary>
    public class l : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            string file = context.Server.MapPath("~/ALot/ALot.xml");
            using (StreamReader reader = File.OpenText(file))
            {
                context.Response.Write(reader.ReadToEnd());
                reader.Close();
            }
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