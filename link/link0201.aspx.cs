using System;
using System.Web.UI;

using cons.io.db.prp;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;

/// <summary>
/// 类别查询
/// </summary>
public partial class link_link0201 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "类别查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0201";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 5;

        if (IsPostBack)
        {
            return;
        }
    }

    private void LoadData(int idx)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
        dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
        if (hd_P3070A06.Value != "")
        {
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010107, "LIKE", '%' + hd_P3070A06.Value.Replace(" ", "%") + '%', true);
        }
        dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);

        gv_TypeList.DataSource = dba.executeSelect();
        gv_TypeList.PageIndex = idx;
        gv_TypeList.DataBind();
    }

    protected void bt_P3070A06_Click(object sender, EventArgs e)
    {
        hd_P3070A06.Value = WrpUtil.text2Db(tf_P3070A06.Text.Trim());
        LoadData(0);
    }

    protected void gv_TypeList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        LoadData(e.NewPageIndex);
    }
}