using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class user_user0002 : Page
{
    private rmp.comn.user.UserInfo userInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        userInfo = rmp.comn.user.UserInfo.Current(Session);
        if (userInfo.UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "信息更新";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0002";

        List<K1V2> guidList = Wrps.GuidUser(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/user/user0002.aspx";
        guidItem.V1 = "信息更新";
        guidItem.V2 = "信息更新";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        #endregion

        if (IsPostBack)
        {
            return;
        }

        LoadData();

        ai_C3010408.InitData();
    }

    private void LoadData()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, userInfo.UserCode);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }
        DataRow row = dt.Rows[0];
        tf_C3010406.Text = "" + row[cons.io.db.comn.user.UserCons.C3010406];
        tf_C3010407.Text = "" + row[cons.io.db.comn.user.UserCons.C3010407];
        tf_C3010409.Text = "" + row[cons.io.db.comn.user.UserCons.C3010409];
        ta_C301040A.Text = "" + row[cons.io.db.comn.user.UserCons.C301040A];
        ai_C3010408.DstIconHash = "" + row[cons.io.db.comn.user.UserCons.C3010408];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidate(tf_C3010406.Text))
        {
            lb_ErrMsg.Text = "请输入电子邮件！";
            tf_C3010406.Focus();
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(tf_C3010406.Text, @"^\w+[\w\.]*@\w+(\.[\w\.]+)+$"))
        {
            lb_ErrMsg.Text = tf_C3010406.Text + " 不是有效的邮件地址！";
            tf_C3010406.Focus();
            return;
        }
        if (!StringUtil.isValidate(tf_C3010407.Text))
        {
            lb_ErrMsg.Text = "请输入昵称！";
            tf_C3010407.Focus();
            return;
        }
        #endregion

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010406, WrpUtil.text2Db(tf_C3010406.Text));
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, "!=", userInfo.UserCode, true);
        DataTable dt = dba.executeSelect();
        if (dt != null && dt.Rows.Count > 0)
        {
            lb_ErrMsg.Text = "邮件地址 " + tf_C3010406.Text + " 已存在，请重新输入！";
            tf_C3010406.Focus();
            return;
        }

        dba.reset();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addParam(cons.io.db.comn.user.UserCons.C3010402, userInfo.UserCode);
        dba.addParam(cons.io.db.comn.user.UserCons.C3010406, WrpUtil.text2Db(tf_C3010406.Text));
        dba.addParam(cons.io.db.comn.user.UserCons.C3010407, WrpUtil.text2Db(tf_C3010407.Text));
        dba.addParam(cons.io.db.comn.user.UserCons.C3010408, ai_C3010408.NextIcon());
        dba.addParam(cons.io.db.comn.user.UserCons.C3010409, WrpUtil.text2Db(tf_C3010409.Text));
        dba.addParam(cons.io.db.comn.user.UserCons.C301040A, WrpUtil.text2Db(ta_C301040A.Text));
        dba.addParam(cons.io.db.comn.user.UserCons.C301040C, cons.EnvCons.SQL_NOW, false);

        try
        {
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010402, userInfo.UserCode);
            dba.executeUpdate();
            ai_C3010408.SaveIcon(true, 0);

            lb_ErrMsg.Text = "用户信息保存成功！";
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "用户信息保存错误：" + exp.Message;
        }
    }
}
