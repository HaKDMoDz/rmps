using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

using Util = rmp.comn.Util;

public partial class exts_exts0303 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "文件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0303";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0301.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0300.aspx";
        guidItem.V1 = "文件信息";
        guidItem.V2 = "文件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0303.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        #region 输入限制
        tf_P3010305.MaxLength = cons.io.db.prp.PrpCons.P3010305_SIZE;
        tf_P3010306.MaxLength = cons.io.db.prp.PrpCons.P3010306_SIZE;
        tf_P3010308.MaxLength = cons.io.db.prp.PrpCons.P3010308_SIZE;
        tf_P3010309.MaxLength = cons.io.db.prp.PrpCons.P3010309_SIZE;
        tf_P301030A.MaxLength = cons.io.db.prp.PrpCons.P301030A_SIZE;
        ta_P301030B.MaxLength = cons.io.db.prp.PrpCons.P301030B_SIZE;
        ta_P301030C.MaxLength = cons.io.db.prp.PrpCons.P301030C_SIZE;
        #endregion

        Util.InitStatData(cb_C1110100, cons.SysCons.UI_LANGHASH, true);

        cb_P3010100.Items.Add(new ListItem("请选择", ""));

        cb_P3010303.Items.Add(new ListItem("请选择", ""));

        ck_C1110100.Attributes.Add("onclick", "initView()");

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt);

        ai_P3010304.InitData();
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
        dba.addTable(cons.io.db.prp.PrpCons.P3010300);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010302, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P301030F, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hd_P3010302.Value = sid;
        hd_P3010303.Value = "" + row[cons.io.db.prp.PrpCons.P3010303]; //软件索引
        ai_P3010304.DstIconHash = "" + row[cons.io.db.prp.PrpCons.P3010304]; //文件图标
        tf_P3010305.Text = "" + row[cons.io.db.prp.PrpCons.P3010305]; //签名字符
        tf_P3010306.Text = "" + row[cons.io.db.prp.PrpCons.P3010306]; //签名数值
        tf_P3010307.Text = "" + row[cons.io.db.prp.PrpCons.P3010307]; //偏移位置
        tf_P3010308.Text = "" + row[cons.io.db.prp.PrpCons.P3010308]; //加密算法
        tf_P3010309.Text = "" + row[cons.io.db.prp.PrpCons.P3010309]; //起始数据
        tf_P301030A.Text = "" + row[cons.io.db.prp.PrpCons.P301030A]; //结束数据
        ta_P301030B.Text = "" + row[cons.io.db.prp.PrpCons.P301030B]; //文件描述
        ta_P301030C.Text = "" + row[cons.io.db.prp.PrpCons.P301030C]; //附注信息
        hd_P301030E.Value = "" + row[cons.io.db.prp.PrpCons.P301030E];// 创建日期

        //当前操作为更新操作
        ck_C1110100.Checked = false;
        ck_C1110100.Enabled = true;
    }

    protected void cb_C1110100_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010303.Items.Clear();
        cb_P3010100.Items.Clear();

        String hash = cb_C1110100.SelectedValue;
        if (StringUtil.isValidateHash(hash))
        {
            Exts.InitCorpData(cb_P3010100, hash, true);
        }
    }

    protected void cb_P3010100_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010303.Items.Clear();

        String hash = cb_P3010100.SelectedValue;
        if (StringUtil.isValidateHash(hash))
        {
            Exts.InitSoftData(cb_P3010303, hash, true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidate(tf_P3010306.Text))
        {
            lb_ErrMsg.Text = "“数值签名”不能为空！";
            tf_P3010306.Focus();
            return;
        }
        if (!StringUtil.isValidateLong(tf_P3010307.Text))
        {
            lb_ErrMsg.Text = "偏移位置请输入一个有效的非负整数！";
            tf_P3010307.Focus();
            return;
        }
        if (ck_C1110100.Checked && !StringUtil.isValidate(cb_P3010303.SelectedValue))
        {
            lb_ErrMsg.Text = "请选择新的软件信息！";
            cb_P3010303.Focus();
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
        // 软件信息
        String P3010303 = ck_C1110100.Checked ? cb_P3010303.SelectedValue : hd_P3010303.Value;
        #endregion

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010300);
        dba.addParam(cons.io.db.prp.PrpCons.P3010303, P3010303);
        dba.addParam(cons.io.db.prp.PrpCons.P3010304, ai_P3010304.NextIcon());
        dba.addParam(cons.io.db.prp.PrpCons.P3010305, WrpUtil.text2Db(tf_P3010305.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010306, WrpUtil.text2Db(tf_P3010306.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010307, int.Parse(tf_P3010307.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010308, WrpUtil.text2Db(tf_P3010308.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010309, WrpUtil.text2Db(tf_P3010309.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301030A, WrpUtil.text2Db(tf_P301030A.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301030B, WrpUtil.text2Db(ta_P301030B.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301030C, WrpUtil.text2Db(ta_P301030C.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301030D, cons.EnvCons.SQL_NOW, false);

        try
        {
            int operate = 0;
            bool isUpdate = StringUtil.isValidateHash(hd_P3010302.Value);
            bool isManage = userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05;

            if (isManage)
            {
                // 更新数据
                if (isUpdate)
                {
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010302, WrpUtil.text2Db(hd_P3010302.Value));
                    dba.addWhere(cons.io.db.prp.PrpCons.P301030F, "0", false);

                    dba.executeUpdate();

                    lb_ErrMsg.Text = "数据更新成功！";
                }
                else
                {
                    dba.addParam(cons.io.db.prp.PrpCons.P3010301, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010302, HashUtil.getCurrTimeHex(false));
                    dba.addParam(cons.io.db.prp.PrpCons.P301030E, cons.EnvCons.SQL_NOW, false);
                    dba.addParam(cons.io.db.prp.PrpCons.P301030F, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010310, cons.wrp.WrpCons.OPT_NORMAL);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010311, userInfo.UserCode);

                    dba.executeInsert();

                    lb_ErrMsg.Text = "数据新增成功！";
                }
            }
            // 新增数据
            else
            {
                String P3010302 = isUpdate ? WrpUtil.text2Db(hd_P3010302.Value) : HashUtil.getCurrTimeHex(false);
                dba.addParam(cons.io.db.prp.PrpCons.P3010301, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P3010301), false);
                dba.addParam(cons.io.db.prp.PrpCons.P3010302, P3010302);
                dba.addParam(cons.io.db.prp.PrpCons.P301030E, isUpdate ? "'" + hd_P301030E.Value + "'" : cons.EnvCons.SQL_NOW, false);
                dba.addParam(cons.io.db.prp.PrpCons.P301030F, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301030F), false);
                dba.addParam(cons.io.db.prp.PrpCons.P3010310, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(cons.io.db.prp.PrpCons.P3010311, userInfo.UserCode);

                dba.addWhere(cons.io.db.prp.PrpCons.P3010302, P3010302);
                dba.executeBackup(cons.io.db.prp.PrpCons.P3010300, cons.io.db.prp.PrpCons.P3010300);

                // 读取操作流水号
                dba.reset();
                dba.addTable(cons.io.db.prp.PrpCons.P3010300);
                dba.addColumn(cons.io.db.prp.PrpCons.P301030F);
                dba.addWhere(cons.io.db.prp.PrpCons.P3010302, P3010302);
                dba.addWhere(cons.io.db.prp.PrpCons.P3010311, userInfo.UserCode);
                dba.addSort(cons.io.db.prp.PrpCons.P301030F, false);
                dba.addLimit(1);
                operate = (int)(dba.executeSelect().Rows[0][cons.io.db.prp.PrpCons.P301030F]);

                lb_ErrMsg.Text = "数据更新成功！";

                if (!isUpdate)
                {
                    tf_P3010305.Text = "";
                    tf_P3010306.Text = "";
                    tf_P3010307.Text = "0";
                    tf_P3010308.Text = "";
                    tf_P3010309.Text = "";
                    tf_P301030A.Text = "";
                    ta_P301030B.Text = "";
                    ta_P301030C.Text = "";
                }
            }

            ai_P3010304.SaveIcon(isManage, operate);
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "文件信息保存出错：" + exp.Message;
        }
    }
}