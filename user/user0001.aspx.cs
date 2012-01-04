using System;

using rmp.comn.user;
using rmp.io.db;

/// <summary>
/// 用户首页
/// </summary>
public partial class user_user0001 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_01)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户首页";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0001";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 1;
        #endregion

        if (IsPostBack)
        {
            return;
        }

        LoadData();
    }

    private void LoadData()
    {
        var ui = UserInfo.Current(Session);
        lb_UserName.Text = ui.UserName;
        lb_UserCode.Text = ui.UserCode;
        lb_UserMail.Text = ui.UserMail;
        lb_UserRank.Text = ui.UserRole;

        var dba = new DBAccess();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010501);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010502);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010503);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010505);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010506);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010504, UserInfo.Current(Session).UserCode);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010502, cons.comn.user.UserInfo.MAJOR_00.ToString());
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, cons.comn.info.CodeInfo.C3010000);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010505, cons.io.db.comn.info.C2010000.C2010105, false);
        dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);
        dba.addSort(cons.io.db.comn.user.UserCons.C3010501, false);
        rp_Accounts.DataSource = dba.executeSelect();
        rp_Accounts.DataBind();
    }
}
