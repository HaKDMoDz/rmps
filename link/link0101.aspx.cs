using System;
using System.Web.UI;

using cons.io.db.prp;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;

/// <summary>
/// 链接查询
/// </summary>
public partial class link_link0101 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "链接查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0101";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 5;

        if (IsPostBack)
        {
            return;
        }
    }

    private void LoadData(int idx)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3070100);
        dba.addColumn(PrpCons.P3070105);
        dba.addColumn(PrpCons.P3070107);
        dba.addColumn(PrpCons.P3070108);
        dba.addColumn(PrpCons.P3070109);
        dba.addWhere(PrpCons.P3070103, UserInfo.Current(Session).UserCode);
        if (hd_P3070107.Value != "")
        {
            dba.addWhere(String.Format("{1} LIKE '{0}' OR {2} LIKE '{0}'", '%' + hd_P3070107.Value.Replace(" ", "%") + '%', PrpCons.P3070107, PrpCons.P3070108));
        }
        dba.addSort(PrpCons.P3070101, false);

        gv_LinkList.DataSource = dba.executeSelect();
        gv_LinkList.PageIndex = idx;
        gv_LinkList.DataBind();
    }

    protected void bt_P3070107_Click(object sender, EventArgs e)
    {
        hd_P3070107.Value = WrpUtil.text2Db(tf_P3070107.Text.Trim());
        LoadData(0);
    }

    protected void gv_LinkList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        LoadData(e.NewPageIndex);
    }
}