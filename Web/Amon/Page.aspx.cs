using System;
using System.Text.RegularExpressions;
using Me.Amon.Code.Model;
using Me.Amon.Da.Db;
using Me.Amon.Open.V1.Web.Pcs;

namespace Me.Amon
{
    public partial class Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            // 获取参数
            var user = (Page.RouteData.Values["user"] as string) ?? Request["user"];
            if (user == null || Regex.IsMatch(user, "^\\w{4,}$"))
            {
                user = "Demo";
            }

            MPage page = new MPage();
            Session["amon_page"] = page;

            // 加载配置
            var dba = new DBAccess();
            dba.AddTable(DBConst.C3010400);
            dba.AddTable(DBConst.C3010A00);
            dba.AddColumn(DBConst.C3010A03);
            dba.AddColumn(DBConst.C3010A04);
            dba.AddColumn(DBConst.C3010A06);
            dba.AddColumn(DBConst.C3010A07);
            dba.AddColumn(DBConst.C3010A08);
            dba.AddColumn(DBConst.C3010A09);
            dba.AddWhere(DBConst.C3010402, DBConst.C3010A03, false);
            dba.AddWhere(DBConst.C3010405, user);

            var dt = dba.ExecuteSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                KuaipanToken token = new KuaipanToken();
                token.Code = row[DBConst.C3010A03] + "";
                token.Token = row[DBConst.C3010A08] + "";
                token.Secret = row[DBConst.C3010A09] + "";
                HdCode.Value = token.Code;
                page.Token = token;
            }

            // 应用参数
            DvList.Style.Add("width", "220px");
            DvIdea.Style.Add("width", "300px");
            DvPage.Style.Add("margin", "0px 0px 0px 246px");
            DvIdea.Style.Add("display", "none");
        }
    }
}