using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using System.Data;

public partial class exts_exts0021 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (rmp.comn.user.UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0021";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0020.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0021.aspx";
        guidItem.V1 = "基本信息";
        guidItem.V2 = "基本信息";

        if (IsPostBack)
        {
            return;
        }

        // 国别信息
        rmp.comn.Util.InitStatData(cb_P3010004, cons.SysCons.UI_LANGHASH, true);
        // 文档格式
        InitDocsData();
        // 所属类别
        rmp.comn.Util.InitCat1Data(cb_P301000C, cons.SysCons.UI_LANGHASH, "13010000", true);
        // 特别致谢
        rmp.comn.user.Util.InitUserList(cb_P301000F, false);

        // 数据更新操作
        LoadData();
    }

    private void LoadData()
    {
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();// 后缀索引
        String uri = (Request[cons.wrp.WrpCons.URI] ?? "").Trim();// 软件索引
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();// 软件索引

        if (!StringUtil.isValidate(sid, 32) || !(StringUtil.isValidateHash(uri) || "0" == uri) || !StringUtil.isValidateLong(opt))
        {
            bt_NextStep.Enabled = false;
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010000);
        dba.addWhere(PrpCons.P3010003, WrpUtil.text2Db(sid));
        dba.addWhere(PrpCons.P3010006, uri);
        dba.addWhere(PrpCons.P3010014, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        lb_P3010001.Text = "" + row[cons.io.db.prp.PrpCons.P3010001];// 访问频率
        ab_ArchBits.ArchBits = (int)row[cons.io.db.prp.PrpCons.P3010002]; // CPU 构架
        hd_P3010003.Value = (String)row[cons.io.db.prp.PrpCons.P3010003]; // 后缀索引

        String temp = (String)row[cons.io.db.prp.PrpCons.P3010004];// 国别信息
        cb_P3010004.SelectedValue = temp;
        Exts.InitCorpData(cb_P3010005, temp, true);

        temp = (String)row[cons.io.db.prp.PrpCons.P3010005];// 公司信息
        cb_P3010005.SelectedValue = temp;
        Exts.InitSoftData(cb_P3010006, temp, true);

        temp = (String)row[cons.io.db.prp.PrpCons.P3010006]; // 软件信息
        cb_P3010006.SelectedValue = temp;
        Exts.InitFileData(cb_P3010007, temp, true);
        hd_P3010006.Value = temp; // 已有软件

        cb_P3010007.SelectedValue = (String)row[cons.io.db.prp.PrpCons.P3010007]; // 文件信息
        cb_P3010008.SelectedValue = (String)row[cons.io.db.prp.PrpCons.P3010008]; // 文档格式
        cb_P301000C.SelectedValue = (String)row[cons.io.db.prp.PrpCons.P301000C]; // 所属类别
        pf_PlatForm.PlatForm = (int)row[cons.io.db.prp.PrpCons.P301000D]; // 运行平台
        cb_P301000F.SelectedValue = (String)row[cons.io.db.prp.PrpCons.P301000F]; // 特别致谢
        ta_P3010010.Text = (String)row[cons.io.db.prp.PrpCons.P3010010]; // 附注信息
        lb_P3010011.Text = row[cons.io.db.prp.PrpCons.P3010011].ToString(); // 更新日期
        lb_P3010012.Text = row[cons.io.db.prp.PrpCons.P3010012].ToString(); // 创建日期
        tf_P3010013.Text = (String)row[cons.io.db.prp.PrpCons.P3010013]; // 后缀名称

        tf_P3010013.Enabled = false;
        tr_StepGuid.Visible = false;
        bt_NextStep.Enabled = true;
    }

    /// <summary>
    /// 国别信息选择事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P3010004_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010007.Items.Clear();
        cb_P3010006.Items.Clear();
        cb_P3010005.Items.Clear();

        String hash = cb_P3010004.SelectedValue;
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        Exts.InitCorpData(cb_P3010005, hash, true);
    }

    /// <summary>
    /// 公司信息选择事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P3010005_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010007.Items.Clear();
        cb_P3010006.Items.Clear();

        String hash = cb_P3010005.SelectedValue;
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        Exts.InitSoftData(cb_P3010006, hash, true);
    }

    /// <summary>
    /// 软件信息选择事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P3010006_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010007.Items.Clear();

        String hash = cb_P3010006.SelectedValue;
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        Exts.InitFileData(cb_P3010007, hash, true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        #region 权限认证
        rmp.comn.user.UserInfo ui = rmp.comn.user.UserInfo.Current(Session);
        if (ui.UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            return;
        }
        #endregion

        #region 输入控制
        String P3010013 = tf_P3010013.Text.Trim().TrimStart('.');
        if (!StringUtil.isValidate(P3010013))
        {
            lb_ErrMsg.Text = "请输入一个形如 .abc 的后缀名称！";
            tf_P3010013.Focus();
            return;
        }
        if (P3010013[0] != '.')
        {
            P3010013 = '.' + P3010013;
        }
        String exts = WrpUtil.text2Db(P3010013.Substring(1));
        #endregion

        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010000);
        dba.addParam(PrpCons.P3010002, ab_ArchBits.ArchBits); //处理字长
        dba.addParam(PrpCons.P3010004, cb_P3010004.SelectedValue); //国别信息
        dba.addParam(PrpCons.P3010005, cb_P3010005.SelectedValue); //公司索引
        dba.addParam(PrpCons.P3010006, cb_P3010006.SelectedValue); //软件索引
        dba.addParam(PrpCons.P3010007, cb_P3010007.SelectedValue); //文件索引
        dba.addParam(PrpCons.P3010008, cb_P3010008.SelectedValue); //文档格式
        dba.addParam(PrpCons.P301000C, cb_P301000C.SelectedValue); //类别索引
        dba.addParam(PrpCons.P301000D, pf_PlatForm.PlatForm); //家族平台
        dba.addParam(PrpCons.P301000F, cb_P301000F.SelectedValue); //人员索引
        dba.addParam(PrpCons.P3010010, WrpUtil.text2Db(ta_P3010010.Text)); //附注信息
        dba.addParam(PrpCons.P3010011, cons.EnvCons.SQL_NOW, false); //更新日期

        try
        {
            bool isUpdate = StringUtil.isValidate(hd_P3010003.Value, 32);

            // 管理人员操作
            if (ui.UserRank > cons.comn.user.UserInfo.LEVEL_05)
            {
                // 更新数据
                if (isUpdate)
                {
                    dba.addWhere(PrpCons.P3010003, WrpUtil.text2Db(hd_P3010003.Value)); //后缀索引
                    dba.addWhere(PrpCons.P3010006, WrpUtil.text2Db(hd_P3010006.Value)); //软件索引
                    dba.addWhere(PrpCons.P3010014, "0", false); //操作流水

                    dba.executeUpdate();

                    Exts.needQuery(Session, true);
                    Exts.addRecentUpdate(tf_P3010013.Text);
                }
                // 新增数据
                else
                {
                    // 附注信息、MIME类型、备选软件等索引
                    String hash = HashUtil.getCurrTimeHex(false);

                    dba.addParam(PrpCons.P3010001, 0);
                    dba.addParam(PrpCons.P3010003, HashUtil.digest(exts, false)); //后缀索引
                    dba.addParam(PrpCons.P3010009, hash);
                    dba.addParam(PrpCons.P301000A, hash);
                    dba.addParam(PrpCons.P301000B, hash);
                    dba.addParam(PrpCons.P301000E, hash);
                    dba.addParam(PrpCons.P3010012, cons.EnvCons.SQL_NOW, false);
                    dba.addParam(PrpCons.P3010013, exts);
                    dba.addParam(PrpCons.P3010014, 0);
                    dba.addParam(PrpCons.P3010015, cons.wrp.WrpCons.OPT_NORMAL);
                    dba.addParam(PrpCons.P3010016, ui.UserCode);

                    dba.executeInsert();

                    Exts.addRecentUpdate(tf_P3010013.Text);
                    Response.Redirect("~/exts/exts0091.aspx?new=1&sid=" + hash);
                }
            }
            // 其它情况下，仅执行新增操作，但记录用户的操作记录
            else
            {
                // 附注信息、MIME类型、备选软件等索引
                String hash = HashUtil.getCurrTimeHex(false);
                // 后缀索引
                dba.addParam(PrpCons.P3010003, isUpdate ? WrpUtil.text2Db(hd_P3010003.Value) : HashUtil.digest(exts, false)); //后缀索引
                dba.addParam(PrpCons.P3010009, hash);
                dba.addParam(PrpCons.P301000A, hash);
                dba.addParam(PrpCons.P301000B, hash);
                dba.addParam(PrpCons.P301000E, hash);
                dba.addParam(PrpCons.P3010001, String.Format("IFNULL(MAX({0}), -1) + 1", PrpCons.P3010001), false);
                dba.addParam(PrpCons.P3010012, cons.EnvCons.SQL_NOW, false);
                dba.addParam(PrpCons.P3010013, exts);
                dba.addParam(PrpCons.P3010014, String.Format("IFNULL(MAX({0}), -1) + 1", PrpCons.P3010014), false);
                dba.addParam(PrpCons.P3010015, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(PrpCons.P3010016, ui.UserCode);

                dba.addWhere(PrpCons.P3010003, WrpUtil.text2Db(hd_P3010003.Value)); //后缀索引
                dba.addWhere(PrpCons.P3010006, WrpUtil.text2Db(hd_P3010006.Value)); //软件索引
                dba.executeBackup(PrpCons.P3010000, PrpCons.P3010000);

                Exts.ExtsSize += 1;
                Exts.addRecentUpdate(tf_P3010013.Text);
                Response.Redirect("~/exts/exts0091.aspx?new=1&sid=" + hash);
            }
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "后缀数据保存出错：" + exp.Message;
        }
    }

    /// <summary>
    /// 格式信息初始化
    /// </summary>
    private void InitDocsData()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010400);
        dba.addColumn(PrpCons.P3010402);
        dba.addColumn(PrpCons.P3010405);
        dba.addWhere(PrpCons.P3010403, cons.SysCons.UI_LANGHASH);
        dba.addSort(PrpCons.P3010405);

        cb_P3010008.DataValueField = PrpCons.P3010402;
        cb_P3010008.DataTextField = PrpCons.P3010405;
        cb_P3010008.DataSource = dba.executeSelect();
        cb_P3010008.DataBind();

        cb_P3010008.Items.Insert(0, new ListItem("<未知>", "0"));
    }
}