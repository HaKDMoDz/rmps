using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using rmp.bean;
using rmp.comn.user;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using Util = rmp.comn.Util;

/// <summary>
/// 描述信息
/// </summary>
public partial class exts_exts0091 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0091";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0090.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0091.aspx";
        guidItem.V1 = "描述信息";
        guidItem.V2 = "描述信息";

        if (IsPostBack)
        {
            return;
        }

        //传入参数读取
        String sid = Request[cons.wrp.WrpCons.SID];
        if (sid == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }
        sid = sid.Trim();
        if (sid == "")
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // 语言选项
        Util.InitLangData(cb_P3010502, false);

        // ====================================================================
        // 下一步按钮属性设置
        // ====================================================================
        bt_LastStep.OnClientClick = "window.location='" + Wrps.CallBack(Session, "") + "';return false;";
        // 新增事件
        if (Request["new"] == "1")
        {
            hd_NextStep.Value = "~/exts/exts0092.aspx?new=1&sid=" + sid;
        }
        //更新事件
        else
        {
            hd_NextStep.Value = "~/exts/exts0001.aspx";

            bt_LastStep.Visible = false;
            bt_NextStep.Visible = false;
            Exts.needQuery(Session, true);
        }

        // 数据更新操作
        LoadData(sid, cons.SysCons.UI_LANGHASH);
    }

    /// <summary>
    /// 语言选项事件处理，读取并判断用户选择的语言是否有数据存在
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P3010502_SelectedIndexChanged(object sender, EventArgs e)
    {
        ta_P3010503.Text = "";
        ta_P3010504.Text = "";

        LoadData(hd_P3010501.Value, cb_P3010502.SelectedValue);
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
    /// 完成按钮事件处理，分以下两种情况处理：
    /// 1、数据更新状态：更新现有数据；
    /// 2、数据新增状态：结束现有数据添加流程，保存数据。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/exts/exts0001.aspx");
    }

    /// <summary>
    /// 保存按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Insert_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010500);
        dba.addParam(cons.io.db.prp.PrpCons.P3010503, WrpUtil.text2Db(ta_P3010503.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010504, WrpUtil.text2Db(ta_P3010504.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010505, cons.EnvCons.SQL_NOW, false);

        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.prp.PrpCons.P3010501, hd_P3010501.Value);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010502, cb_P3010502.SelectedValue);

            dba.executeUpdate();
            Wrps.ShowMesg(Master, "后缀描述更新成功！");
        }
        else
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010501, hd_P3010501.Value);
            dba.addParam(cons.io.db.prp.PrpCons.P3010502, cb_P3010502.SelectedValue);
            dba.addParam(cons.io.db.prp.PrpCons.P3010506, cons.EnvCons.SQL_NOW, false);

            dba.executeInsert();
            Wrps.ShowMesg(Master, "后缀描述添加成功！");

            // 修改状态标记为更新状态，用户可以进行后缀的更新操作
            hd_IsUpdate.Value = "1";
        }

        Util.UpdtLangData(cb_P3010502.SelectedValue);
    }

    /// <summary>
    /// 已有数据读取
    /// </summary>
    /// <param name="sid"></param>
    /// <param name="lid"></param>
    private void LoadData(String sid, String lid)
    {
        // 保存索引及语言信息
        hd_P3010501.Value = sid;
        cb_P3010502.SelectedValue = lid;

        // 数据查询
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010500);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010503);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010504);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010501, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010502, lid);

        // 数据是否存在判断
        DataTable dataList = dba.executeSelect();
        if (dataList.Rows.Count < 1)
        {
            hd_IsUpdate.Value = "";
            return;
        }

        // 已有数据显示，并设置标记为更新状态
        ta_P3010503.Text = dataList.Rows[0][cons.io.db.prp.PrpCons.P3010503].ToString();
        ta_P3010504.Text = dataList.Rows[0][cons.io.db.prp.PrpCons.P3010504].ToString();

        hd_IsUpdate.Value = "1";
        tr_StepGuid.Visible = false;
    }
}