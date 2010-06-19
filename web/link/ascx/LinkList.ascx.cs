using System;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;
using cons.wrp.link;
using rmp.io.db;
using rmp.comn.user;

public partial class link_ascx_LinkList : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        DataTable dt = (DataTable)Session[cons.wrp.WrpCons.P3070000_TYPE + UserInfo.Current(Session).UserCode];
        if (dt == null)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010102, LinkCons.LINK_STAT_NORMAL.ToString());
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010106, LinkCons.LINK_USER_HASH);
            dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);
            dt = dba.executeSelect();
            Session[cons.wrp.WrpCons.P3070000_TYPE] = dt;
        }

        rp_TypeList.DataSource = dt;
        rp_TypeList.DataBind();
    }
}