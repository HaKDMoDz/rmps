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

public partial class exts_exts0603 : Page
{
    private rmp.comn.user.UserInfo userInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        userInfo = rmp.comn.user.UserInfo.Current(Session);
        if (userInfo.UserRank < cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "应用平台";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0603";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0601.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0600.aspx";
        guidItem.V1 = "应用平台";
        guidItem.V2 = "应用平台";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0603.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        #region 输入限制
        tf_P301F206.MaxLength = cons.io.db.prp.PrpCons.P301F206_SIZE;
        tf_P301F209.MaxLength = cons.io.db.prp.PrpCons.P301F209_SIZE;
        ta_P301F20A.MaxLength = cons.io.db.prp.PrpCons.P301F20A_SIZE;
        ta_P301F20B.MaxLength = cons.io.db.prp.PrpCons.P301F20B_SIZE;
        #endregion

        Util.InitLangData(cb_P301F204, true);

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt, cons.SysCons.UI_LANGHASH);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sid"></param>
    /// <param name="lid"></param>
    private void LoadData(String sid, String opt, String lid)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt) || !StringUtil.isValidateLong(lid))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P301F200);
        dba.addWhere(cons.io.db.prp.PrpCons.P301F203, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P301F204, lid);
        dba.addWhere(cons.io.db.prp.PrpCons.P301F20E, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        cb_P301F202.SelectedValue = "" + row[cons.io.db.prp.PrpCons.P301F202]; // 所属家族
        hd_P301F203.Value = sid; // 平台索引
        cb_P301F204.SelectedValue = "" + row[cons.io.db.prp.PrpCons.P301F204];// 语言索引
        tf_P301F206.Text = "" + row[cons.io.db.prp.PrpCons.P301F206]; // 平台名称
        hd_P301F208.Value = "" + row[cons.io.db.prp.PrpCons.P301F208];// 平台图片
        tf_P301F209.Text = "" + row[cons.io.db.prp.PrpCons.P301F209];// 平台首页
        ta_P301F20A.Text = "" + row[cons.io.db.prp.PrpCons.P301F20A];// 平台说明
        ta_P301F20B.Text = "" + row[cons.io.db.prp.PrpCons.P301F20B];// 附注信息
        hd_P301F20E.Value = opt;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P301F204_SelectedIndexChanged(object sender, EventArgs e)
    {
        tf_P301F206.Text = "";
        hd_P301F208.Value = "";
        tf_P301F209.Text = "";
        ta_P301F20B.Text = "";
        ta_P301F20A.Text = "";
        ta_P301F20B.Text = "";

        LoadData(hd_P301F203.Value, hd_P301F20E.Value, cb_P301F204.SelectedValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P301F208_Click(object sender, EventArgs e)
    {
        aa_AmonAuth.InitData();

        if (!StringUtil.isValidate(fu_P301F208.FileName) || !fu_P301F208.HasFile || fu_P301F208.FileContent.Length < 1)
        {
            return;
        }

        if (!StringUtil.isValidateHash(hd_TempHash.Value))
        {
            hd_TempHash.Value = HashUtil.getCurrTimeHex(true);
        }

        try
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(fu_P301F208.FileContent);
            image.Save(Server.MapPath("~/temp/plat/") + hd_TempHash.Value + ".png", System.Drawing.Imaging.ImageFormat.Png);
            lb_ErrMsg.Text = "平台图片上传成功！";
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "平台图片上传出错：" + exp.Message;
        }

        fu_P301F208.FileContent.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidate(tf_P301F206.Text))
        {
            lb_ErrMsg.Text = "请输入平台名称！";
            tf_P301F206.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }
        #endregion

        if (StringUtil.isValidateHash(hd_TempHash.Value) && !StringUtil.isValidatePath(hd_P301F208.Value))
        {
            hd_P301F208.Value = Exts.NextDocs("plat", HashUtil.getCurrTimeHex(true));
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P301F200);
        dba.addParam(cons.io.db.prp.PrpCons.P301F202, int.Parse(cb_P301F202.SelectedValue));//所属家族
        dba.addParam(cons.io.db.prp.PrpCons.P301F206, WrpUtil.text2Db(tf_P301F206.Text));//平台名称
        //dba.addParam(cons.io.db.prp.PrpCons.P301F207, hd_P301F207.Value);
        dba.addParam(cons.io.db.prp.PrpCons.P301F208, WrpUtil.text2Db(hd_P301F208.Value));//平台图片
        dba.addParam(cons.io.db.prp.PrpCons.P301F209, WrpUtil.text2Db(tf_P301F209.Text));//平台首页
        dba.addParam(cons.io.db.prp.PrpCons.P301F20A, WrpUtil.text2Db(ta_P301F20A.Text));//平台说明
        dba.addParam(cons.io.db.prp.PrpCons.P301F20B, WrpUtil.text2Db(ta_P301F20B.Text));//相关说明
        dba.addParam(cons.io.db.prp.PrpCons.P301F20C, cons.EnvCons.SQL_NOW, false);

        try
        {
            int operate = 0;
            bool isUpdate = StringUtil.isValidateHash(hd_P301F203.Value);
            bool isManage = userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05;
            if (isManage)
            {
                // 更新数据
                if (isUpdate)
                {
                    dba.addWhere(cons.io.db.prp.PrpCons.P301F203, WrpUtil.text2Db(hd_P301F203.Value));
                    dba.addWhere(cons.io.db.prp.PrpCons.P301F204, WrpUtil.text2Db(cb_P301F204.SelectedValue));//语言索引
                    dba.addWhere(cons.io.db.prp.PrpCons.P301F20E, "0", false);

                    dba.executeUpdate();

                    lb_ErrMsg.Text = "数据合并成功！";
                }
                else
                {
                    dba.addParam(cons.io.db.prp.PrpCons.P301F201, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F203, HashUtil.getCurrTimeHex(false));
                    dba.addParam(cons.io.db.prp.PrpCons.P301F204, WrpUtil.text2Db(cb_P301F204.SelectedValue));//语言索引
                    dba.addParam(cons.io.db.prp.PrpCons.P301F20D, cons.EnvCons.SQL_NOW, false);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F20E, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F20F, cons.wrp.WrpCons.OPT_NORMAL);
                    dba.addParam(cons.io.db.prp.PrpCons.P301F210, userInfo.UserCode);

                    dba.executeInsert();

                    lb_ErrMsg.Text = "数据新增成功！";
                }
            }
            // 新增数据
            else
            {
                String P301F203 = isUpdate ? WrpUtil.text2Db(hd_P301F203.Value) : HashUtil.getCurrTimeHex(false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F201, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301F201), false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F203, P301F203);
                dba.addParam(cons.io.db.prp.PrpCons.P301F204, cb_P301F204.SelectedValue);//语言索引
                dba.addParam(cons.io.db.prp.PrpCons.P301F20D, cons.EnvCons.SQL_NOW, false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F20E, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301F20E), false);
                dba.addParam(cons.io.db.prp.PrpCons.P301F20F, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(cons.io.db.prp.PrpCons.P301F210, userInfo.UserCode);

                dba.reset();
                dba.addTable(cons.io.db.prp.PrpCons.P301F200);
                dba.addColumn(cons.io.db.prp.PrpCons.P301F20E);
                dba.addWhere(cons.io.db.prp.PrpCons.P301F203, P301F203);
                dba.addWhere(cons.io.db.prp.PrpCons.P301F210, userInfo.UserCode);
                dba.addSort(cons.io.db.prp.PrpCons.P301F203, false);
                dba.addLimit(1);
                operate = (int)dba.executeSelect().Rows[0][cons.io.db.prp.PrpCons.P301F203];

                lb_ErrMsg.Text = "数据更新成功！";
            }

            // 用户有更新
            if (StringUtil.isValidateHash(hd_TempHash.Value))
            {
                Exts.SaveDocs("~/temp/plat/", hd_TempHash.Value, ".png", hd_P301F208.Value, isManage, operate);
            }
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "平台信息保存出错：" + exp.Message;
        }
    }
}