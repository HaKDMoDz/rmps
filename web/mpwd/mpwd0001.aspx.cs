using System;
using System.Web.UI;

using rmp.io.db;

public partial class mpwd_mpwd0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.SCRIPTID] = "mpwd0001";

        if (IsPostBack)
        {
            return;
        }

        // SQL语句封装
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010A00);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010A04, "130F0000");
        dba.addSort(cons.io.db.comn.ComnCons.C0010A05, false);

        // 数据查询与梆定
        VersList.DataSource = dba.executeSelect();
        VersList.DataBind();
    }
}