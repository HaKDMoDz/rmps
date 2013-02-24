using System;
using Me.Amon.Da.Db;

namespace Me.Amon
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.LOGS0100);
            dba.AddColumn(DBConst.LOGS0104);
            dba.AddColumn(DBConst.LOGS0105);
            dba.AddColumn(DBConst.LOGS0106);
            //dba.AddWhere(DBConst.LOGS0103);
            dba.AddSort(DBConst.LOGS0101, false);
            dba.AddLimit(1);

            var dt = dba.ExecuteSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                LbVer.Text = row[DBConst.LOGS0104] + "&nbsp;" + row[DBConst.LOGS0105];
                LbDsp.Text = row[DBConst.LOGS0106] + "&nbsp;";
            }
        }
    }
}