using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

using Util = rmp.comn.Util;

public partial class exts_exts0103 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "公司信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0103";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0101.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0100.aspx";
        guidItem.V1 = "公司信息";
        guidItem.V2 = "公司信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0103.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        #region 输入限制
        tf_P3010105.MaxLength = cons.io.db.prp.PrpCons.P3010105_SIZE;
        tf_P3010106.MaxLength = cons.io.db.prp.PrpCons.P3010106_SIZE;
        tf_P3010107.MaxLength = cons.io.db.prp.PrpCons.P3010107_SIZE;
        ta_P3010108.MaxLength = cons.io.db.prp.PrpCons.P3010108_SIZE;
        ta_P3010109.MaxLength = cons.io.db.prp.PrpCons.P3010109_SIZE;
        #endregion

        // ====================================================================
        // 语言选项
        // ====================================================================
        Util.InitStatData(cb_P3010103, cons.SysCons.UI_LANGHASH, true);

        // 回传页面
        hd_NextStep.Value = (Request[cons.wrp.WrpCons.URI] ?? "").Trim();

        // 传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt);

        ai_P3010104.InitData();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sid">公司索引</param>
    /// <param name="opt">操作流水</param>
    private void LoadData(String sid, String opt)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010100);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010102, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P301010C, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hd_P3010102.Value = sid;
        cb_P3010103.SelectedValue = "" + row[cons.io.db.prp.PrpCons.P3010103]; //国别信息
        ai_P3010104.DstIconHash = "" + row[cons.io.db.prp.PrpCons.P3010104]; //公司图标
        tf_P3010105.Text = "" + row[cons.io.db.prp.PrpCons.P3010105]; //本语名称
        tf_P3010106.Text = "" + row[cons.io.db.prp.PrpCons.P3010106]; //英语名称
        tf_P3010107.Text = "" + row[cons.io.db.prp.PrpCons.P3010107]; //公司网址
        ta_P3010108.Text = "" + row[cons.io.db.prp.PrpCons.P3010108]; //公司描述
        ta_P3010109.Text = "" + row[cons.io.db.prp.PrpCons.P3010109]; //附注信息
        hd_P301010B.Value = "" + row[cons.io.db.prp.PrpCons.P301010B]; //创建日期
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        String P3010103 = cb_P3010103.SelectedValue;
        if (!StringUtil.isValidateHash(P3010103))
        {
            Wrps.ShowMesg(this.Master, "请选择国别信息！");
            cb_P3010103.Focus();
            return;
        }
        String P3010105 = WrpUtil.text2Db(tf_P3010105.Text);
        if (!StringUtil.isValidate(P3010105))
        {
            Wrps.ShowMesg(this.Master, "“中文名称”不能为空！");
            tf_P3010105.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }
        #endregion

        // 数据对应
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010100);
        dba.addParam(cons.io.db.prp.PrpCons.P3010103, P3010103);
        dba.addParam(cons.io.db.prp.PrpCons.P3010104, ai_P3010104.NextIcon());
        dba.addParam(cons.io.db.prp.PrpCons.P3010105, P3010105);
        dba.addParam(cons.io.db.prp.PrpCons.P3010106, WrpUtil.text2Db(tf_P3010106.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010107, WrpUtil.text2Db(tf_P3010107.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010108, WrpUtil.text2Db(ta_P3010108.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010109, WrpUtil.text2Db(ta_P3010109.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301010A, cons.EnvCons.SQL_NOW, false);

        try
        {
            int operate = 0;
            bool isUpdate = StringUtil.isValidateHash(hd_P3010102.Value);
            bool isManage = userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05;

            // 系统管理人员操作
            if (isManage)
            {
                // 数据更新
                if (isUpdate)
                {
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010102, WrpUtil.text2Db(hd_P3010102.Value));
                    dba.addWhere(cons.io.db.prp.PrpCons.P301010C, "0", false); //操作流水

                    dba.executeUpdate();

                    lb_ErrMsg.Text = "数据合并成功！";
                }
                // 新增数据
                else
                {
                    dba.addParam(cons.io.db.prp.PrpCons.P3010101, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010102, HashUtil.getCurrTimeHex(false));
                    dba.addParam(cons.io.db.prp.PrpCons.P301010B, cons.EnvCons.SQL_NOW, false);
                    dba.addParam(cons.io.db.prp.PrpCons.P301010C, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P301010D, cons.wrp.WrpCons.OPT_NORMAL);
                    dba.addParam(cons.io.db.prp.PrpCons.P301010E, userInfo.UserCode);

                    dba.executeInsert();

                    lb_ErrMsg.Text = "新增数据成功！";
                }
            }
            // 网络用户编辑数据
            else
            {
                String P3010102 = isUpdate ? WrpUtil.text2Db(hd_P3010102.Value) : HashUtil.getCurrTimeHex(false);
                dba.addParam(cons.io.db.prp.PrpCons.P3010101, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P3010101), false);
                dba.addParam(cons.io.db.prp.PrpCons.P3010102, P3010102);
                dba.addParam(cons.io.db.prp.PrpCons.P301010B, isUpdate ? "'" + hd_P301010B.Value + "'" : cons.EnvCons.SQL_NOW, false);
                dba.addParam(cons.io.db.prp.PrpCons.P301010C, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301010C), false);
                dba.addParam(cons.io.db.prp.PrpCons.P301010D, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(cons.io.db.prp.PrpCons.P301010E, userInfo.UserCode);

                dba.addWhere(cons.io.db.prp.PrpCons.P3010102, P3010102);
                dba.executeBackup(cons.io.db.prp.PrpCons.P3010100, cons.io.db.prp.PrpCons.P3010100);

                // 读取操作流水号
                dba.reset();
                dba.addTable(cons.io.db.prp.PrpCons.P3010100);
                dba.addColumn(cons.io.db.prp.PrpCons.P301010C);
                dba.addWhere(cons.io.db.prp.PrpCons.P3010102, P3010102);
                dba.addWhere(cons.io.db.prp.PrpCons.P301010E, userInfo.UserCode);
                dba.addSort(cons.io.db.prp.PrpCons.P301010C, false);
                dba.addLimit(1);
                operate = (int)(dba.executeSelect().Rows[0][cons.io.db.prp.PrpCons.P301010C]);

                lb_ErrMsg.Text = "数据更新成功！";
            }

            ai_P3010104.SaveIcon(isManage, operate);
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "公司数据保存出错：" + exp.Message;
        }

        // 更新国别频率
        Util.UpdtStatData(cb_P3010103.SelectedValue);
    }
}