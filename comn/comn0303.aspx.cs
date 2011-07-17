using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using rmp.comn.user;
using rmp.io.db;
using rmp.util;
using rmp.wrp;


public partial class comn_comn0303 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限检测
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户更新";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0303";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidUser(Session).Count;
        #endregion

        // 是否页面回传
        if (IsPostBack)
        {
            return;
        }

        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        LoadData(sid);
    }

    private void LoadData(String sid)
    {
        if (!StringUtil.isValidateHash(sid))
        {
            return;
        }

        // 已有权限列表绑定
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010F00);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010F03);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010F04);
        dba.addSort(cons.io.db.comn.user.UserCons.C3010F01);
        cb_UserRank.DataValueField = cons.io.db.comn.user.UserCons.C3010F03;
        cb_UserRank.DataTextField = cons.io.db.comn.user.UserCons.C3010F04;
        cb_UserRank.DataSource = dba.executeSelect();
        cb_UserRank.DataBind();

        // 读取用户名称
        dba.reset();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010405);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, sid);
        DataTable dt = dba.executeSelect();
        if (dt != null && dt.Rows.Count == 1)
        {
            lb_UserName.Text = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010405] + "";
        }

        // 读取用户权限信息
        dba.reset();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010200);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010203);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010202, sid);
        dt = dba.executeSelect();
        if (dt != null && dt.Rows.Count == 1)
        {
            hd_UserRank.Value = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010203] + "";
            cb_UserRank.SelectedValue = hd_UserRank.Value;
        }

        // 用户口令信息
        //dba.reset();
        //dba.addTable(cons.io.db.comn.user.UserCons.C3010600);
        //dba.addColumn(cons.io.db.comn.user.UserCons.C3010603);
        //dba.addWhere(cons.io.db.comn.user.UserCons.C3010602, sid);
        //dt = dba.executeSelect();
        //if (dt != null && dt.Rows.Count == 1)
        //{
        //    tf_UserPwds.Text = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010603] + "";
        //}
        hd_UserHash.Value = sid;
    }

    /// <summary>
    /// 自动生成口令
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ib_UserPwds_Click(object sender, ImageClickEventArgs e)
    {
        tf_UserPwds.Text = "Test123";
    }

    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        if (cb_UserRank.SelectedValue != hd_UserRank.Value)
        {
            dba.addTable(cons.io.db.comn.user.UserCons.C3010200);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010203, cb_UserRank.SelectedValue);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010202, hd_UserHash.Value);
            dba.executeUpdate();
            dba.reset();
        }

        if (tf_UserPwds.Text != "")
        {
            dba.addTable(cons.io.db.comn.user.UserCons.C3010600);
            dba.addParam(cons.io.db.comn.user.UserCons.C3010603, StringUtil.EncodeBytes(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(tf_UserPwds.Text)), false));
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010602, hd_UserHash.Value);
            dba.executeUpdate();
            dba.reset();
        }

        Wrps.ShowMesg(Master, "用户信息修改成功！");
    }
}