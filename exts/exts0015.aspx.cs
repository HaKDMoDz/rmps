using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

/// <summary>
/// 文件信息
/// </summary>
public partial class exts_exts0015 : Page
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
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0015";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0015.aspx";
        guidItem.V1 = "文件信息";
        guidItem.V2 = "文件信息";

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

        Exts.InitFileData(cb_P3010007, extsBase.P3010006, true);
        cb_P3010007.SelectedValue = extsBase.P3010007;
        bt_SaveData.Enabled = extsBase.IsUpdate;
    }

    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        extsBase.P3010007 = cb_P3010007.SelectedValue;
        Response.Redirect("~/exts/exts0016.aspx");
    }

    /// <summary>
    /// 保存数据按钮事件处理
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
    /// 新增数据按钮操作
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

        hd_P3010304.Value = Exts.NextIcon(hd_UpdtIcon.Value, "file", hd_P3010304.Value);

        String hash = HashUtil.getCurrTimeHex(false);
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010300);
        dba.addParam(cons.io.db.prp.PrpCons.P3010301, 0); //显示排序
        dba.addParam(cons.io.db.prp.PrpCons.P3010302, hash); //文件索引
        dba.addParam(cons.io.db.prp.PrpCons.P3010303, extsBase.P3010006); //软件索引
        dba.addParam(cons.io.db.prp.PrpCons.P3010304, hd_P3010304.Value); //文件图标
        dba.addParam(cons.io.db.prp.PrpCons.P3010305, WrpUtil.text2Db(tf_P3010305.Text)); //签名字符
        dba.addParam(cons.io.db.prp.PrpCons.P3010306, WrpUtil.text2Db(tf_P3010306.Text)); //签名数值
        dba.addParam(cons.io.db.prp.PrpCons.P3010307, tf_P3010307.Text); //偏移位置
        dba.addParam(cons.io.db.prp.PrpCons.P3010308, WrpUtil.text2Db(tf_P3010308.Text)); //加密算法
        dba.addParam(cons.io.db.prp.PrpCons.P3010309, WrpUtil.text2Db(tf_P3010309.Text)); //起始数据
        dba.addParam(cons.io.db.prp.PrpCons.P301030A, WrpUtil.text2Db(tf_P301030A.Text)); //结束数据
        dba.addParam(cons.io.db.prp.PrpCons.P301030B, WrpUtil.text2Db(ta_P301030B.Text)); //文件描述
        dba.addParam(cons.io.db.prp.PrpCons.P301030C, WrpUtil.text2Db(ta_P301030C.Text)); //附注信息
        dba.addParam(cons.io.db.prp.PrpCons.P301030D, cons.EnvCons.SQL_NOW, false); //更新日期
        dba.addParam(cons.io.db.prp.PrpCons.P301030E, cons.EnvCons.SQL_NOW, false); //创建日期
        dba.addParam(cons.io.db.prp.PrpCons.P301030F, 0);
        dba.addParam(cons.io.db.prp.PrpCons.P3010310, cons.wrp.WrpCons.OPT_NORMAL);
        dba.addParam(cons.io.db.prp.PrpCons.P3010311, userInfo.UserCode);

        // 执行数据插入操作
        dba.executeInsert();

        Exts.SaveIcon(hd_UpdtIcon.Value, hd_IconPath.Value, hd_IconHash.Value, hd_P3010304.Value, true, 0);

        // 界面数据初始化
        ib_P3010304.ImageUrl = "file/00030.png";
        tf_P3010305.Text = "";
        tf_P3010306.Text = "";
        tf_P3010307.Text = "0";
        tf_P3010308.Text = "";
        tf_P3010309.Text = "";
        tf_P301030A.Text = "";
        ta_P301030B.Text = "";
        ta_P301030C.Text = "";

        // 重新读取文件列表信息
        cb_P3010007.Items.Clear();
        Exts.InitFileData(cb_P3010007, extsBase.P3010006, true);
        cb_P3010007.SelectedValue = hash;
    }
}