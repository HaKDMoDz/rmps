using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

/// <summary>
/// 运行平台
/// </summary>
public partial class exts_exts0094 : Page
{
    private rmp.comn.user.UserInfo userInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        // ====================================================================
        // 用户身份认证
        // ====================================================================
        userInfo = rmp.comn.user.UserInfo.Current(Session);
        if (userInfo.UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0094";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0090.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0094.aspx";
        guidItem.V1 = "运行平台";
        guidItem.V2 = "运行平台";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        ta_P3010804.MaxLength = cons.io.db.prp.PrpCons.P3010804_SIZE;

        // ====================================================================
        // 传入参数读取
        // ====================================================================
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (!StringUtil.isValidateHash(sid))
        {
            Response.Redirect("~/exts/exts0010.aspx");
            return;
        }

        // ====================================================================
        // 下一步按钮属性设置
        // ====================================================================
        bt_LastStep.OnClientClick = "window.location='/exts/exts0093.aspx?new=1&sid=" + sid + "';return false;";
        // 新增事件
        if (Request["new"] == "1")
        {
            hd_NextStep.Value = "~/exts/exts0001.aspx";
        }
        // 更新事件
        else
        {
            hd_NextStep.Value = "~/exts/exts0001.aspx";

            bt_LastStep.Visible = false;
            bt_NextStep.Visible = false;
            Exts.needQuery(Session, true);
        }
        hd_P3010802.Value = sid;

        // ====================================================================
        // 数据初始化
        // ====================================================================
        InitData(cons.SysCons.UI_LANGHASH);
        LoadData(sid, cons.SysCons.UI_LANGHASH);
    }

    private void InitData(String lid)
    {
        DBAccess dba = new DBAccess();

        dba.addTable(cons.io.db.prp.PrpCons.P301F200);
        dba.addColumn(cons.io.db.prp.PrpCons.P301F203);
        dba.addColumn(cons.io.db.prp.PrpCons.P301F206);
        dba.addWhere(cons.io.db.prp.PrpCons.P301F204, lid);
        dba.addSort(cons.io.db.prp.PrpCons.P301F206);

        cb_P3010803.DataValueField = cons.io.db.prp.PrpCons.P301F203;
        cb_P3010803.DataTextField = cons.io.db.prp.PrpCons.P301F206;
        cb_P3010803.DataSource = dba.executeSelect();
        cb_P3010803.DataBind();
    }

    /// <summary>
    /// 数据初始化显示
    /// </summary>
    /// <param name="sid"></param>
    /// <param name="lid"></param>
    private void LoadData(String sid, String lid)
    {
        DBAccess dba = new DBAccess();

        dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010800, cons.io.db.prp.PrpCons.P301F200, cons.io.db.prp.PrpCons.P3010803, cons.io.db.prp.PrpCons.P301F203));
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010801);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010803);
        dba.addColumn(cons.io.db.prp.PrpCons.P301F206);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010807);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010808);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010809, cons.io.db.comn.user.UserCons.C3010402, false);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010802, WrpUtil.text2Db(sid));
        dba.addWhere(cons.io.db.prp.PrpCons.P301F204, lid);
        dba.addSort(cons.io.db.prp.PrpCons.P301F206, false);

        DataTable dt = dba.executeSelect();

        StringBuilder P3010801 = new StringBuilder();
        StringBuilder P3010803 = new StringBuilder();

        foreach (DataRow row in dt.Rows)
        {
            P3010801.Append(row[cons.io.db.prp.PrpCons.P3010801]).Append(',');
            P3010803.Append(row[cons.io.db.prp.PrpCons.P3010803]).Append(',');
        }
        if (P3010801.Length > 0)
        {
            hd_P3010801.Value = P3010801.ToString(0, P3010801.Length - 1);
            hd_P3010803.Value = P3010803.ToString(0, P3010803.Length - 1);
        }

        rp_P3010803.DataSource = dt;
        rp_P3010803.DataBind();

        tr_StepGuid.Visible = false;
    }

    /// <summary>
    /// 下一步按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect(hd_NextStep.Value);
    }

    /// <summary>
    /// 删除按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ib_Delete_Click(object sender, ImageClickEventArgs e)
    {
        String P3010803 = WrpUtil.text2Db(((ImageButton)sender).CommandArgument);
        if (!StringUtil.isValidateHash(P3010803))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010800);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010802, WrpUtil.text2Db(hd_P3010802.Value));
        dba.addWhere(cons.io.db.prp.PrpCons.P3010803, P3010803);

        if (userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05)
        {
            dba.executeDelete();
        }
        else
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010807, String.Format("{0}+1", cons.io.db.prp.PrpCons.P3010807), false);
            dba.addParam(cons.io.db.prp.PrpCons.P3010808, cons.wrp.WrpCons.OPT_DELETE);
            dba.addParam(cons.io.db.prp.PrpCons.P3010809, userInfo.UserCode);
            dba.executeUpdate();
        }

        LoadData(hd_P3010802.Value, cons.SysCons.UI_LANGHASH);

        lb_ErrMsg.Text = "操作平台删除成功！";
    }

    /// <summary>
    /// 保存按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Insert_Click(object sender, EventArgs e)
    {
        if (!StringUtil.isValidateHash(cb_P3010803.SelectedValue))
        {
            lb_ErrMsg.Text = "请选择您要添加的操作平台！";
            cb_P3010803.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010800);
        dba.addParam(cons.io.db.prp.PrpCons.P3010804, WrpUtil.text2Db(ta_P3010804.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010805, cons.EnvCons.SQL_NOW, false);
        dba.addParam(cons.io.db.prp.PrpCons.P3010808, cons.wrp.WrpCons.OPT_INSERT);
        dba.addParam(cons.io.db.prp.PrpCons.P3010809, userInfo.UserCode);

        if (hd_IsUpdate.Value == "1")
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010807, String.Format("{0}+1", cons.io.db.prp.PrpCons.P3010807), false);

            dba.addWhere(cons.io.db.prp.PrpCons.P3010802, WrpUtil.text2Db(hd_P3010802.Value));
            dba.addWhere(cons.io.db.prp.PrpCons.P3010803, WrpUtil.text2Db(cb_P3010803.SelectedValue));

            dba.executeUpdate();

            lb_ErrMsg.Text = "运行平台更新成功！";
        }
        else
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010801, 0);
            dba.addParam(cons.io.db.prp.PrpCons.P3010802, WrpUtil.text2Db(hd_P3010802.Value));
            dba.addParam(cons.io.db.prp.PrpCons.P3010803, WrpUtil.text2Db(cb_P3010803.SelectedValue));
            dba.addParam(cons.io.db.prp.PrpCons.P3010806, cons.EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.prp.PrpCons.P3010807, 0);

            dba.executeInsert();

            lb_ErrMsg.Text = "运行平台添加成功！";
        }

        LoadData(hd_P3010802.Value, cons.SysCons.UI_LANGHASH);

        ta_P3010804.Text = "";
        hd_IsUpdate.Value = "0";
    }

    /// <summary>
    /// 完成按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String[] P3010801 = hd_P3010801.Value.Split(',');
        String[] P3010803 = hd_P3010803.Value.Split(',');
        String P3010802 = WrpUtil.text2Db(hd_P3010802.Value);
        if (P3010801 != null && P3010801.Length > 0 && P3010801.Length == P3010803.Length && StringUtil.isValidateHash(P3010802))
        {
            DBAccess dba = new DBAccess();
            for (int i = 0; i < P3010801.Length; i += 1)
            {
                if (Regex.IsMatch(P3010801[i], @"^\d+$"))
                {
                    dba.addTable(cons.io.db.prp.PrpCons.P3010800);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010801, P3010801[i]);
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010802, P3010802);
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010803, WrpUtil.text2Db(P3010803[i]));
                    dba.executeUpdate();
                    dba.reset();
                }
            }
        }

        LoadData(hd_P3010802.Value, cons.SysCons.UI_LANGHASH);
        lb_ErrMsg.Text = "数据更新成功！";
        aa_AmonAuth.InitData();
    }
}