using System.IO;
using System.Web;
using Me.Amon.Da.Db;
using Me.Amon.Open;

namespace Me.Amon
{
    public class Web
    {
        public const string PAGE_NAME = "我的网志";
        public const string CARD_NAME = "我的卡片";
        public const string IMGS_NAME = "我的图册";
        public const string BOOK_NAME = "我的阅读";

        public const string SESSION_META = "amon_meta";
        public const string USER_DEMO = "A0000010";

        public static OAuthToken LoadToken(string code, string type)
        {
            var dba = new DBAccess();

            // 登录用户验证
            dba.ReInit();
            dba.AddTable(DBConst.C3010A00);
            dba.AddColumn(DBConst.C3010A05);
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
            token.Code = code;
            token.Token = row[DBConst.C3010A08] + "";
            token.Secret = row[DBConst.C3010A09] + "";
            token.UserId = row[DBConst.C3010A05] + "";

            return token;
        }

        private static byte[] _DefImg;
        public static byte[] DefImg()
        {
            if (_DefImg == null)
            {
                var file = HttpContext.Current.Server.MapPath("~/docs/Imgd.png");
                if (File.Exists(file))
                {
                    _DefImg = File.ReadAllBytes(file);
                }
                else
                {
                    _DefImg = new byte[1];
                }
            }
            return _DefImg;
        }

        private static string _DefLog;
        public static string DefLog()
        {
            if (_DefLog == null)
            {
                var file = HttpContext.Current.Server.MapPath("~/docs/Page.htm");
                if (File.Exists(file))
                {
                    _DefLog = File.ReadAllText(file);
                }
                else
                {
                    _DefLog = "<html><head><title>爱梦</title></head><body>-_-</body></html>";
                }
            }
            return _DefLog;
        }
    }
}