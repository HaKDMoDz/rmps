using System;
using Me.Amon.Da.Db;

namespace Amon
{
    public partial class About : System.Web.UI.Page
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

            Repeater1.DataSource = dba.ExecuteSelect();
            Repeater1.DataBind();
        }
    }
}
