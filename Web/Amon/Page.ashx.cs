using System.IO;
using System.Web;
using Me.Amon.Da.Db;
using Me.Amon.Open;

namespace Me.Amon
{
    /// <summary>
    /// Pages 的摘要说明
    /// </summary>
    public class Pages : IHttpHandler
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
                LoadLog(context, "");
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

        private void LoadLog(HttpContext context, string code)
        {
            var response = context.Response;
            response.ContentType = "text/html";
            var token = LoadToken(code, OAuthClient.KUAIPAN);
            if (token == null)
            {
                response.Write(LoadDefault(context));
                response.End();
                return;
            }

            //var consumer = OAuthConsumer.KuaipanConsumer();
            //var client = new KuaipanClient(consumer, token, true);

            //client.Download("", null);
            response.Write("<html><head><title>Hello World</title></head><body>Hello World!</body></html>");
            response.End();
        }

        private string LoadDefault(HttpContext context)
        {
            var file = context.Server.MapPath("/docs/Page.htm");
            string page = File.ReadAllText(file);
            return page;
        }

        private OAuthToken LoadToken(string code, string type)
        {
            var dba = new DBAccess();

            // 登录用户验证
            dba.ReInit();
            dba.AddTable(DBConst.C3010A00);
            dba.AddColumn(DBConst.C3010A06);
            dba.AddColumn(DBConst.C3010A07);
            dba.AddColumn(DBConst.C3010A08);
            dba.AddColumn(DBConst.C3010A09);
            dba.AddWhere(DBConst.C3010A03, code);
            dba.AddWhere(DBConst.C3010A04, type);
            dba.AddSort(DBConst.C3010A01, false);

            var dt = dba.ExecuteSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return null;
            }

            var row = dt.Rows[0];
            var token = new Me.Amon.Open.V1.Web.Pcs.KuaipanToken();
            token.Token = row[DBConst.C3010A08] + "";
            token.Secret = row[DBConst.C3010A09] + "";
            token.UserId = row[DBConst.C3010A05] + "";

            return token;
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