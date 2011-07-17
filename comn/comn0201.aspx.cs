using System;
using System.Data;

using rmp.comn.user;
using rmp.io.db;
using rmp.util;

public partial class comn_comn0201 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "共用资源管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "comn0201";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        gv_SoftList.DataSource = rmp.comn.root.C0000000.Load(new DBAccess(), null, null);
        gv_SoftList.DataBind();

        tf_C2010107.MaxLength = cons.io.db.comn.info.C2010000.C2010107_SIZE;
        tf_C2010108.MaxLength = cons.io.db.comn.info.C2010000.C2010108_SIZE;
        tf_C2010109.MaxLength = cons.io.db.comn.info.C2010000.C2010109_SIZE;
        ta_C201010A.MaxLength = cons.io.db.comn.info.C2010000.C201010A_SIZE;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_InfoData_Click(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_SoftList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String code = gv_SoftList.SelectedValue as String;
        if (StringUtil.isValidateCode(code))
        {
            gv_InfoData.DataSource = rmp.comn.info.C2010000.Read(new DBAccess(), null, "0", code, -1);
            gv_InfoData.DataBind();

            gv_SoftList.Visible = false;
            gv_InfoData.Visible = true;
            lb_IsCreate.Visible = true;
            hd_SoftCode.Value = code;
            hd_C2010106.Value = "0";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_InfoData_SelectedIndexChanged(object sender, EventArgs e)
    {
        String hash = gv_InfoData.SelectedValue as String;
        if (StringUtil.isValidateHash(hash))
        {
            gv_InfoData.DataSource = rmp.comn.info.C2010000.Read(new DBAccess(), null, hash, hd_SoftCode.Value, -1);
            gv_InfoData.DataBind();
            hd_C2010106.Value = hash;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_InfoData_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        String hash = gv_InfoData.SelectedValue as String;
        if (StringUtil.isValidateHash(hash))
        {
            hd_IsUpdate.Value = hash;
            DataTable dt = rmp.comn.info.C2010000.Read(new DBAccess(), hash, null, cons.comn.info.CodeInfo.C3010000, -1);
            if (dt.Rows.Count != 1)
            {
                DataRow row = dt.Rows[0];
                tf_C2010101.Text = row[cons.io.db.comn.info.C2010000.C2010101].ToString();
                tf_C2010107.Text = row[cons.io.db.comn.info.C2010000.C2010107].ToString();
                tf_C2010108.Text = row[cons.io.db.comn.info.C2010000.C2010108].ToString();
                tf_C2010109.Text = row[cons.io.db.comn.info.C2010000.C2010109].ToString();
                ta_C201010A.Text = row[cons.io.db.comn.info.C2010000.C201010A].ToString();
                lb_C201010B.Text = row[cons.io.db.comn.info.C2010000.C201010B].ToString();
                dv_Update.Visible = true;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_InfoData_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        String hash = rmp.comn.info.C2010000.Save(dba, hd_IsUpdate.Value,
                                                    hd_SoftCode.Value,
                                                    hd_C2010106.Value,
                                                    tf_C2010107.Text,
                                                    tf_C2010108.Text,
                                                    tf_C2010109.Text,
                                                    ta_C201010A.Text,
                                                    0);
        if (StringUtil.isValidateHash(hash))
        {
            tf_C2010101.Text = "0";
            tf_C2010107.Text = "";
            tf_C2010108.Text = "";
            tf_C2010109.Text = "";
            ta_C201010A.Text = "";
            lb_C201010B.Text = "";

            gv_InfoData.DataSource = rmp.comn.info.C2010000.Read(dba, null, hd_C2010106.Value, hd_SoftCode.Value, -1);
            gv_InfoData.DataBind();

            if (StringUtil.isValidateHash(hd_IsUpdate.Value))
            {
                dv_Update.Visible = false;
            }
        }
        else
        {
            rmp.wrp.Wrps.ShowMesg(this.Master, "数据保存错误！");
        }
    }

    protected void lb_SoftList_Click(object sender, EventArgs e)
    {
        gv_SoftList.Visible = true;
        gv_InfoData.Visible = false;
        lb_IsCreate.Visible = false;
        hd_C2010106.Value = "0";
    }

    protected void lb_IsCreate_Click(object sender, EventArgs e)
    {
        tf_C2010101.Text = "0";
        tf_C2010107.Text = "";
        tf_C2010108.Text = "";
        tf_C2010109.Text = "";
        ta_C201010A.Text = "";
        hd_IsUpdate.Value = "0";
        dv_Update.Visible = true;
    }
}
