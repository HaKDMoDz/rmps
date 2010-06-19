using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using rmp.bean;
using rmp.comn.info;
using rmp.comn.user;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using System.Data;

public partial class user_user0104 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "账户管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0104";

        List<K1V2> guidList = Wrps.GuidUser(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/user/user0104.aspx";
        guidItem.V1 = "账户管理";
        guidItem.V2 = "账户管理";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        #endregion

        tr_ErrMsg.Visible = false;

        if (IsPostBack)
        {
            return;
        }

        var dba = new DBAccess();
        LoadData(dba);
        cb_DataType.DataSource = C2010000.Read(dba, null, "0", cons.comn.info.CodeInfo.C3010000, -1);
        cb_DataType.DataValueField = cons.io.db.comn.info.C2010000.C2010105;
        cb_DataType.DataTextField = cons.io.db.comn.info.C2010000.C2010107;
        cb_DataType.DataBind();
        cb_DataType.Items.Insert(0, new ListItem("--请选择--", ""));
    }

    /// <summary>
    /// 
    /// </summary>
    private void LoadData(DBAccess dba)
    {
        dba.reset();
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
        gv_DataList.DataSource = dba.executeSelect();
        gv_DataList.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    protected static String GetMajor(Object obj)
    {
        if (obj != null)
        {
            switch (int.Parse(obj.ToString()))
            {
                case cons.comn.user.UserInfo.MAJOR_01:
                    return "（一般）";
                case cons.comn.user.UserInfo.MAJOR_02:
                    return "（重要）";
                case cons.comn.user.UserInfo.MAJOR_03:
                    return "（备选）";
                case cons.comn.user.UserInfo.MAJOR_04:
                    return "（首选）";
                default:
                    return "";
            }
        }
        return "";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_DataType_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_DataItem.DataSource = C2010000.Read(new DBAccess(), "", cb_DataType.SelectedValue, cons.comn.info.CodeInfo.C3010000, 0);
        cb_DataItem.DataValueField = cons.io.db.comn.info.C2010000.C2010105;
        cb_DataItem.DataTextField = cons.io.db.comn.info.C2010000.C2010107;
        cb_DataItem.DataBind();
        cb_DataItem.Items.Insert(0, new ListItem("--请选择--", ""));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    /// <param name="sender"></param>
    protected void bt_DropData_Click(object sender, EventArgs e)
    {
        if (!StringUtil.isValidateHash(hd_IsUpdate.Value))
        {
            return;
        }

        var dba = new DBAccess();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
        dba.addWhere(cons.io.db.comn.user.UserCons.C3010503, hd_IsUpdate.Value);
        if (dba.executeDelete() > 0)
        {
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "数据删除成功！";
            LoadData(dba);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String U0000506 = WrpUtil.text2Db(tf_U0000506.Text);
        if (!StringUtil.isValidate(U0000506))
        {
            return;
        }

        bool IsUpdate = StringUtil.isValidateHash(hd_IsUpdate.Value);
        var dba = new DBAccess();

        if (!IsUpdate)
        {
            dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010506, U0000506);
            if (dba.executeSelect().Rows.Count > 0)
            {
                tr_ErrMsg.Visible = true;
                lb_ErrMsg.Text = String.Format("通讯信息 {0} 已存在，请重新输入！", U0000506);
                return;
            }
        }

        dba.reset();
        dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
        dba.addParam(cons.io.db.comn.user.UserCons.C3010501, "0");
        dba.addParam(cons.io.db.comn.user.UserCons.C3010502, cons.comn.user.UserInfo.MAJOR_00.ToString());
        dba.addParam(cons.io.db.comn.user.UserCons.C3010504, UserInfo.Current(Session).UserCode);
        dba.addParam(cons.io.db.comn.user.UserCons.C3010505, cb_DataItem.SelectedValue);
        dba.addParam(cons.io.db.comn.user.UserCons.C3010506, WrpUtil.text2Db(tf_U0000506.Text));
        dba.addParam(cons.io.db.comn.user.UserCons.C3010507, "");
        dba.addParam(cons.io.db.comn.user.UserCons.C3010508, cons.EnvCons.SQL_NOW, false);
        if (IsUpdate)
        {
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010503, hd_IsUpdate.Value);
            dba.executeUpdate();
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "数据更新成功！";
            LoadData(dba);
            return;
        }

        dba.addParam(cons.io.db.comn.user.UserCons.C3010503, HashUtil.getCurrTimeHex(false));
        dba.addParam(cons.io.db.comn.user.UserCons.C3010509, cons.EnvCons.SQL_NOW, false);
        if (dba.executeInsert() == 1)
        {
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "数据新增成功！";
            LoadData(dba);
            tf_U0000506.Text = "";
            tf_U0000507.Text = "";
        }
        else
        {
            tr_ErrMsg.Visible = true;
            lb_ErrMsg.Text = "数据保存失败！";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_DataList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String hash = gv_DataList.SelectedValue as String;
        if (StringUtil.isValidate(hash))
        {
            hd_IsUpdate.Value = hash;
            var dba = new DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010503, hash);
            DataTable dt = dba.executeSelect();
            if (dt.Rows.Count == 1)
            {
                tf_U0000506.Text = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010506].ToString();
                bt_DropData.Visible = true;
                dv_IsCreate.Visible = true;
            }
            else
            {
                tr_ErrMsg.Visible = true;
                lb_ErrMsg.Text = "数据读取出错，请与管理员联系！";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_IsCreate_Click(object sender, EventArgs e)
    {
        dv_IsCreate.Visible = true;
    }
}
