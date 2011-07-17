using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

/// <summary>
/// 公司信息
/// </summary>
public partial class exts_exts0013 : Page
{
    private rmp.comn.user.UserInfo userInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        // ====================================================================
        // 用户身份认证
        // ====================================================================
        userInfo = rmp.comn.user.UserInfo.Current(Session);
        if (userInfo.UserRank <= cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0013";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0013.aspx";
        guidItem.V1 = "公司信息";
        guidItem.V2 = "公司信息";

        if (IsPostBack)
        {
            return;
        }

        // 设置默认显示
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        Exts.InitCorpData(cb_P3010005, extsBase.P3010004, true);
        cb_P3010005.SelectedValue = extsBase.P3010005;
        bt_SaveData.Enabled = extsBase.IsUpdate;

        ai_P3010104.InitData();
    }

    /// <summary>
    /// 下一步按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        extsBase.P3010005 = cb_P3010005.SelectedValue;
        Response.Redirect("~/exts/exts0014.aspx");
    }

    /// <summary>
    /// 保存数据按钮事件处理（此事件仅会在更新时出现）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        Exts.SaveBase(extsBase);
        Exts.needQuery(Session, true);
        Response.Redirect("~/exts/exts0001.aspx");
    }

    /// <summary>
    /// 新增数据按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Insert_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        String hash = HashUtil.getCurrTimeHex(false);
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010100);
        dba.addParam(cons.io.db.prp.PrpCons.P3010101, 0); //显示排序
        dba.addParam(cons.io.db.prp.PrpCons.P3010102, hash); //公司索引
        dba.addParam(cons.io.db.prp.PrpCons.P3010103, extsBase.P3010004); //国别信息
        dba.addParam(cons.io.db.prp.PrpCons.P3010104, ai_P3010104.NextIcon()); //公司徽标
        dba.addParam(cons.io.db.prp.PrpCons.P3010105, WrpUtil.text2Db(tf_P3010105.Text)); //本语名称
        dba.addParam(cons.io.db.prp.PrpCons.P3010106, WrpUtil.text2Db(tf_P3010106.Text)); //英语名称
        dba.addParam(cons.io.db.prp.PrpCons.P3010107, WrpUtil.text2Db(tf_P3010107.Text)); //公司网址
        dba.addParam(cons.io.db.prp.PrpCons.P3010108, WrpUtil.text2Db(ta_P3010108.Text)); //公司描述
        dba.addParam(cons.io.db.prp.PrpCons.P3010109, WrpUtil.text2Db(ta_P3010109.Text)); //附注信息
        dba.addParam(cons.io.db.prp.PrpCons.P301010A, cons.EnvCons.SQL_NOW, false); //更新日期
        dba.addParam(cons.io.db.prp.PrpCons.P301010B, cons.EnvCons.SQL_NOW, false); //创建日期
        dba.addParam(cons.io.db.prp.PrpCons.P301010C, 0);
        dba.addParam(cons.io.db.prp.PrpCons.P301010D, cons.wrp.WrpCons.OPT_NORMAL);
        dba.addParam(cons.io.db.prp.PrpCons.P301010E, userInfo.UserCode);

        // 执行数据插入操作
        dba.executeInsert();

        ai_P3010104.SaveIcon(true, 0);

        //界面状态恢复
        ai_P3010104.InitData();
        tf_P3010105.Text = "";
        tf_P3010106.Text = "";
        tf_P3010107.Text = "";
        ta_P3010108.Text = "";
        ta_P3010109.Text = "";

        // 更新国别信息使用频率
        rmp.comn.Util.UpdtStatData(extsBase.P3010004);

        // 更新公司信息列表
        cb_P3010005.Items.Clear();
        Exts.InitCorpData(cb_P3010005, extsBase.P3010004, true);
        cb_P3010005.SelectedValue = hash;
    }
}