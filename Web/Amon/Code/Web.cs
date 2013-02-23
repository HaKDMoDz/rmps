using Me.Amon.Da.Db;
using Me.Amon.Open;

namespace Me.Amon
{
    public class Web
    {
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
    }
}