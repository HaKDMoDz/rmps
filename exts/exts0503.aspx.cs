using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

using Util = rmp.comn.Util;

public partial class exts_exts0503 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "MIME类型";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0503";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0501.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0500.aspx";
        guidItem.V1 = "MIME类型";
        guidItem.V2 = "MIME类型";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0503.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        #region 输入限制
        tf_P301F104.MaxLength = cons.io.db.prp.PrpCons.P301F104_SIZE;
        ta_P301F105.MaxLength = cons.io.db.prp.PrpCons.P301F105_SIZE;
        ta_P301F106.MaxLength = cons.io.db.prp.PrpCons.P301F106_SIZE;
        #endregion

        Util.InitLangData(cb_P301F103, true);

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt, cons.SysCons.UI_LANGHASH);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sid">MIME索引</param>
    /// <param name="opt">操作流水</param>
    /// <param name="lid">语言索引</param>
    private void LoadData(String sid, String opt, String lid)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt) || !StringUtil.isValidateHash(lid))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P301F100);
        dba.addWhere(cons.io.db.prp.PrpCons.P301F102, WrpUtil.text2Db(sid));
        dba.addWhere(cons.io.db.prp.PrpCons.P301F103, WrpUtil.text2Db(lid));
        dba.addWhere(cons.io.db.prp.PrpCons.P301F109, WrpUtil.text2Db(opt), false);

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hd_P301F102.Value = sid;
        tf_P301F104.Text = "" + row[cons.io.db.prp.PrpCons.P301F104];
        ta_P301F105.Text = "" + row[cons.io.db.prp.PrpCons.P301F105];
        ta_P301F106.Text = "" + row[cons.io.db.prp.PrpCons.P301F106];
        hd_P301F108.Value = "" + row[cons.io.db.prp.PrpCons.P301F108];
        hd_P301F109.Value = opt;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P301F103_SelectedIndexChanged(object sender, EventArgs e)
    {
        tf_P301F104.Text = "";
        ta_P301F105.Text = "";
        ta_P301F106.Text = "";

        LoadData(hd_P301F102.Value, hd_P301F109.Value, cb_P301F103.SelectedValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidate(tf_P301F104.Text))
        {
            lb_ErrMsg.Text = "请输入MIME类型名称！";
            tf_P301F104.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }
        String P301F104 = WrpUtil.text2Db(tf_P301F104.Text.Trim());
        #endregion

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P301F100);
        dba.addParam(cons.io.db.prp.PrpCons.P301F104, P301F104);
        dba.addParam(cons.io.db.prp.PrpCons.P301F105, WrpUtil.text2Db(ta_P301F105.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301F106, WrpUtil.text2Db(ta_P301F106.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P301F107, cons.EnvCons.SQL_NOW, false);

        try
        {
            bool isUpdate = StringUtil.isValidateHash(hd_P301F102.Value);

            if (userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05)
            {
                // 更新数据
                if (isUpdate)
                {
                    dba.addWhere(cons.io.db.prp.PrpCons.P301F102, WrpUtil.text2Db(hd_P301F102.Value));
                    dba.addWhere(cons.io.db.prp.PrpCons.P301F103, WrpUtil.text2Db(cb_P301F103.SelectedValue));
                    dba.addWhere(cons.io.db.prp.PrpCons.P301F109, "0", false);

                    dba.executeUpdate();

                    lb_ErrMsg.Text = "数据合并成功！";
                }
                else
                {
                    if (CheckExist(dba, P301F104))
                    {
                        Wrps.ShowMesg(Master, "您要添加的MIME类型已存在！");
                        return;
                    }

                    dba.addParam(cons.io.db.prp.PrpCons.P301F101, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F102, HashUtil.getCurrTimeHex(false));
                    dba.addParam(cons.io.db.prp.PrpCons.P301F103, WrpUtil.text2Db(cb_P301F103.SelectedValue));
                    dba.addParam(cons.io.db.prp.PrpCons.P301F108, cons.EnvCons.SQL_NOW, false);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F109, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F10A, cons.wrp.WrpCons.OPT_NORMAL);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F10B, userInfo.UserCode);

                    dba.executeInsert();

                    lb_ErrMsg.Text = "数据新增成功！";
                }
            }
            // 新增数据
            else
            {
                if (CheckExist(dba, P301F104))
                {
                    Wrps.ShowMesg(Master, "您要添加的MIME类型已存在！");
                    return;
                }

                dba.addParam(cons.io.db.prp.PrpCons.P301F101, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301F101), false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F102, isUpdate ? WrpUtil.text2Db(hd_P301F102.Value) : HashUtil.getCurrTimeHex(false));
                dba.addParam(cons.io.db.prp.PrpCons.P301F103, WrpUtil.text2Db(cb_P301F103.SelectedValue));
                dba.addParam(cons.io.db.prp.PrpCons.P301F108, cons.EnvCons.SQL_NOW, false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F109, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301F109), false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F10A, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(cons.io.db.prp.PrpCons.P301F10B, userInfo.UserCode);

                dba.addWhere(cons.io.db.prp.PrpCons.P301F102, WrpUtil.text2Db(hd_P301F102.Value));
                dba.addWhere(cons.io.db.prp.PrpCons.P301F103, WrpUtil.text2Db(cb_P301F103.SelectedValue));
                dba.executeBackup(cons.io.db.prp.PrpCons.P301F100, cons.io.db.prp.PrpCons.P301F100);

                lb_ErrMsg.Text = "数据更新成功！";
            }
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "MIME信息保存出错：" + exp.Message;
        }
    }

    private bool CheckExist(DBAccess dba, String P301F104)
    {
        DataTable dt = dba.executeSelect(String.Format("SELECT 1 FROM {0} WHERE {1}='{2}'", cons.io.db.prp.PrpCons.P301F100, cons.io.db.prp.PrpCons.P301F104, P301F104));
        bool exist = (dt != null && dt.Rows.Count > 0);
        dt.Dispose();
        return exist;
    }
}