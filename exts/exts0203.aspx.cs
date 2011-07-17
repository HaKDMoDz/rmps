using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using Util = rmp.comn.Util;

public partial class exts_exts0203 : Page
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
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "软件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0203";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0201.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0200.aspx";
        guidItem.V1 = "软件信息";
        guidItem.V2 = "软件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0203.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        #region 输入限制
        tf_P3010205.MaxLength = cons.io.db.prp.PrpCons.P3010205_SIZE;
        tf_P3010206.MaxLength = cons.io.db.prp.PrpCons.P3010206_SIZE;
        tf_P3010207.MaxLength = cons.io.db.prp.PrpCons.P3010207_SIZE;
        tf_P3010208.MaxLength = cons.io.db.prp.PrpCons.P3010208_SIZE;
        tf_P3010209.MaxLength = cons.io.db.prp.PrpCons.P3010209_SIZE;
        ta_P301020B.MaxLength = cons.io.db.prp.PrpCons.P301020B_SIZE;
        ta_P301020C.MaxLength = cons.io.db.prp.PrpCons.P301020C_SIZE;
        #endregion

        // ====================================================================
        // 国别信息
        // ====================================================================
        Util.InitStatData(cb_C1110100, SysCons.UI_LANGHASH, true);

        cb_P3010203.Items.Add(new ListItem("请选择", ""));

        ck_C1110100.Attributes.Add("onclick", "initView()");
        ck_P3010209.Attributes.Add("onclick", "changeAsoc()");

        // 回传页面
        hd_NextStep.Value = (Request[cons.wrp.WrpCons.URI] ?? "").Trim();

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt);

        ai_P3010204.InitData();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sid"></param>
    private void LoadData(String sid, String opt)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010200);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010202, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P301020F, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hd_P3010202.Value = sid;
        hd_P3010203.Value = "" + row[cons.io.db.prp.PrpCons.P3010203]; // 公司信息
        cb_P3010203.SelectedValue = "" + row[cons.io.db.prp.PrpCons.P3010203]; //公司名称
        ai_P3010204.DstIconHash = "" + row[cons.io.db.prp.PrpCons.P3010204]; // 软件图标
        tf_P3010205.Text = "" + row[cons.io.db.prp.PrpCons.P3010205]; //软件名称
        tf_P3010206.Text = "" + row[cons.io.db.prp.PrpCons.P3010206]; //英文名称
        tf_P3010207.Text = "" + row[cons.io.db.prp.PrpCons.P3010207]; //联系邮件
        tf_P3010208.Text = "" + row[cons.io.db.prp.PrpCons.P3010208]; //链接地址
        foreach (String t in ("" + row[cons.io.db.prp.PrpCons.P3010209]).Trim().Split(',', ' ', ';'))
        {
            if (!StringUtil.isValidate(t))
            {
                continue;
            }
            String exts = t.StartsWith(".") ? t : '.' + t;
            ls_P3010209.Items.Add(new ListItem(exts, exts));
        } //兼容后缀
        af_P301020A.DstFileHash = "" + row[cons.io.db.prp.PrpCons.P301020A]; // 运行截图
        ta_P301020B.Text = "" + row[cons.io.db.prp.PrpCons.P301020B]; //软件描述
        ta_P301020C.Text = "" + row[cons.io.db.prp.PrpCons.P301020C]; //附注信息

        //当前操作为更新操作
        ck_C1110100.Checked = false;
        ck_C1110100.Enabled = true;
        tb_P3010209.Visible = true;
    }

    /// <summary>
    /// 国别信息列表事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_C1110100_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010203.Items.Clear();

        String hash = cb_C1110100.SelectedValue;
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        Exts.InitCorpData(cb_P3010203, cb_C1110100.SelectedValue, true);
    }

    /// <summary>
    /// 追加兼容后缀
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Append_Click(object sender, EventArgs e)
    {
        String ext = (tf_P3010209.Text ?? "").Trim().TrimStart('.');
        if (!StringUtil.isValidate(ext))
        {
            return;
        }
        ext = '.' + ext;

        bool has = false;
        // 判断是否已经存在同名后缀
        foreach (ListItem item in ls_P3010209.Items)
        {
            if (item.Text == ext)
            {
                has = true;
                break;
            }
        }

        // 不存在同名后缀则添加
        if (!has)
        {
            ls_P3010209.Items.Add(new ListItem(ext, ext));
        }

        // 更新后缀的备选软件信息
        if (ck_P3010209.Checked)
        {
            UpdtAsoc(ext);
        }

        ls_P3010209.SelectedValue = ext;
        tf_P3010209.Text = "";
        tf_P3010209.Focus();
    }

    /// <summary>
    /// 添加备选软件
    /// </summary>
    /// <param name="exts"></param>
    private void UpdtAsoc(String exts)
    {
        exts = WrpUtil.text2Db(exts);

        DBAccess dba = new DBAccess();
        // 查询后缀数据是否存在
        dba.addTable(cons.io.db.prp.PrpCons.P3010000);
        dba.addColumn(cons.io.db.prp.PrpCons.P301000B);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010013, exts.Substring(1));

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        // 执行权限
        String P3010705 = "-";
        P3010705 += ck_R.Checked ? "r" : "-";
        P3010705 += ck_W.Checked ? "w" : "-";
        P3010705 += ck_X.Checked ? "x" : "-";

        bool isUpdate;
        foreach (DataRow row in dt.Rows)
        {
            String P301000B = "" + row[cons.io.db.prp.PrpCons.P301000B];

            // 查询是否存在相同软件
            dba.reset();
            dba.addTable(cons.io.db.prp.PrpCons.P3010700);
            dba.addColumn(cons.io.db.prp.PrpCons.P3010704);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010703, P301000B);
            dba.addWhere(cons.io.db.prp.PrpCons.P3010704, hd_P3010202.Value);

            DataTable tempList = dba.executeSelect();
            isUpdate = (tempList != null && tempList.Rows.Count > 0);

            // 新增备选软件
            dba.reset();
            dba.addTable(cons.io.db.prp.PrpCons.P3010700);
            dba.addParam(cons.io.db.prp.PrpCons.P3010702, pf_PlatForm.PlatForm);
            dba.addParam(cons.io.db.prp.PrpCons.P3010705, P3010705);
            dba.addParam(cons.io.db.prp.PrpCons.P3010706, "");
            dba.addParam(cons.io.db.prp.PrpCons.P3010707, EnvCons.SQL_NOW, false);
            if (isUpdate)
            {
                dba.addWhere(cons.io.db.prp.PrpCons.P3010703, P301000B);
                dba.addWhere(cons.io.db.prp.PrpCons.P3010704, hd_P3010202.Value);
                dba.executeUpdate();
            }
            else
            {
                dba.addParam(cons.io.db.prp.PrpCons.P3010703, P301000B);
                dba.addParam(cons.io.db.prp.PrpCons.P3010704, hd_P3010202.Value);
                dba.addParam(cons.io.db.prp.PrpCons.P3010701, 0);
                dba.addParam(cons.io.db.prp.PrpCons.P3010708, EnvCons.SQL_NOW, false);
                dba.executeInsert();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Delete_Click(object sender, EventArgs e)
    {
        ListItem item = ls_P3010209.SelectedItem;
        if (item == null)
        {
            return;
        }
        ls_P3010209.Items.Remove(item);

        // 删除后缀的备选软件信息
        if (ck_P3010209.Checked)
        {
            DeltAsoc(item.Value);
        }
    }

    /// <summary>
    /// 删除备选软件
    /// </summary>
    private void DeltAsoc(String exts)
    {
        exts = WrpUtil.text2Db(exts);

        DBAccess dba = new DBAccess();
        // 查询后缀数据是否存在
        dba.addTable(cons.io.db.prp.PrpCons.P3010000);
        dba.addColumn(cons.io.db.prp.PrpCons.P301000B);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010013, exts.Substring(1));

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        String P301000B = "" + dt.Rows[0][cons.io.db.prp.PrpCons.P301000B];

        dba.reset();
        dba.addTable(cons.io.db.prp.PrpCons.P3010700);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010703, P301000B);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010704, hd_P3010202.Value);
        dba.executeDelete();
    }

    /// <summary>
    /// 数据保存按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidate(tf_P3010205.Text))
        {
            lb_ErrMsg.Text = "“软件名称”不能为空！";
            tf_P3010205.Focus();
            return;
        }
        if (ck_C1110100.Checked && !StringUtil.isValidate(cb_P3010203.Text))
        {
            lb_ErrMsg.Text = "请选择新的公司！";
            cb_P3010203.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }
        #endregion

        #region 其它处理
        // 兼容后缀
        StringBuilder sb = new StringBuilder();
        foreach (ListItem item in ls_P3010209.Items)
        {
            sb.Append(item.Value).Append(";");
        }
        // 公司信息
        String P3010203 = ck_C1110100.Checked ? cb_P3010203.SelectedValue : hd_P3010203.Value;
        #endregion

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010200);
        dba.addParam(cons.io.db.prp.PrpCons.P3010203, P3010203);
        dba.addParam(cons.io.db.prp.PrpCons.P3010204, ai_P3010204.NextIcon());
        dba.addParam(cons.io.db.prp.PrpCons.P3010205, WrpUtil.text2Db(tf_P3010205.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010206, WrpUtil.text2Db(tf_P3010206.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010207, WrpUtil.text2Db(tf_P3010207.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010208, WrpUtil.text2Db(tf_P3010208.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010209, WrpUtil.text2Db(sb.ToString()));
        dba.addParam(cons.io.db.prp.PrpCons.P301020A, af_P301020A.NextFile());
        dba.addParam(cons.io.db.prp.PrpCons.P301020B, WrpUtil.text2Db(ta_P301020B.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301020C, WrpUtil.text2Db(ta_P301020C.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301020D, EnvCons.SQL_NOW, false);

        try
        {
            long operate = 0;
            bool isUpdate = StringUtil.isValidate(hd_P3010202.Value);
            bool isManage = userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05;

            // 管理人员操作
            if (isManage && isUpdate)
            {
                operate = 0;
                dba.addWhere(cons.io.db.prp.PrpCons.P3010202, WrpUtil.text2Db(hd_P3010202.Value));// 软件索引
                dba.addWhere(cons.io.db.prp.PrpCons.P301020F, "0", false);// 操作流水

                dba.executeUpdate();

                lb_ErrMsg.Text = "数据合并成功！";
            }
            else
            {
                operate = rmp.wrp.Wrps.NextStep(cons.io.db.prp.PrpCons.P301020F);

                dba.addParam(cons.io.db.prp.PrpCons.P3010201, 0);
                dba.addParam(cons.io.db.prp.PrpCons.P3010202, HashUtil.getCurrTimeHex(false));
                dba.addParam(cons.io.db.prp.PrpCons.P301020E, EnvCons.SQL_NOW, false);
                dba.addParam(cons.io.db.prp.PrpCons.P301020F, operate);
                dba.addParam(cons.io.db.prp.PrpCons.P3010210, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(cons.io.db.prp.PrpCons.P3010211, userInfo.UserCode);

                dba.executeInsert();

                lb_ErrMsg.Text = isUpdate ? "数据更新成功！" : "数据新增成功！";
            }

            // 软件图标
            ai_P3010204.SaveIcon(isManage, operate);
            // 软件截图
            af_P301020A.SaveFile(isManage, operate);
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "软件信息保存出错：" + exp.Message;
        }
    }

    private void LoadDefault()
    {
        hd_NextStep.Value = "";
        hd_Operate.Value = "";
        hd_P3010202.Value = "";
        hd_P3010203.Value = "";
        tf_P3010205.Text = "";
        tf_P3010206.Text = "";
        tf_P3010207.Text = "";
        tf_P3010208.Text = "";
        tf_P3010209.Text = "";
        ta_P301020B.Text = "";
        ta_P301020C.Text = "";
        ai_P3010204.DstIconHash = "";
        af_P301020A.DstFileHash = "";
    }
}