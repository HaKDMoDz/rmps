using System;
using System.Web.UI;

using cons.io.db.comn;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

using WrpCons = cons.wrp.WrpCons;

public partial class comn_comn0301 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限检测
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0301";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidUser(Session).Count;

        // 是否页面回传
        if (IsPostBack)
        {
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tf_U0000405_TextChanged(object sender, EventArgs e)
    {
        LoadData(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_U0000405_Click(object sender, EventArgs e)
    {
        LoadData(0);
    }

    /// <summary>
    /// 
    /// </summary>
    private void LoadData(int idx)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010300);
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010402);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010302);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010405);
        dba.addColumn(cons.io.db.comn.user.UserCons.C301040C);
        dba.addColumn(cons.io.db.comn.user.UserCons.C301040D);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010301, cons.io.db.comn.user.UserCons.C3010402, false);
        String key = WrpUtil.text2Db(tf_U0000405.Text);
        if (StringUtil.isValidate(key))
        {
            dba.addWhere(String.Format("{1} LIKE '%{0}%' OR {2} LIKE '%{0}%'", key.Replace(' ', '%'), cons.io.db.comn.user.UserCons.C3010302, cons.io.db.comn.user.UserCons.C3010405));
        }
        dba.addSort(cons.io.db.comn.user.UserCons.C301040D, false);

        gv_UserList.DataSource = dba.executeSelect();
        gv_UserList.PageIndex = idx;
        gv_UserList.DataBind();
    }

    protected void gv_UserList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        LoadData(e.NewPageIndex);
    }
}