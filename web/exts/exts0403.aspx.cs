using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using cons;

public partial class exts_exts0403 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "文档信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0403";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0401.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0400.aspx";
        guidItem.V1 = "文档信息";
        guidItem.V2 = "文档信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0403.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        #region 输入限制
        tf_P3010405.MaxLength = cons.io.db.prp.PrpCons.P3010405_SIZE;
        tf_P3010406.MaxLength = cons.io.db.prp.PrpCons.P3010406_SIZE;
        tf_P3010407.MaxLength = cons.io.db.prp.PrpCons.P3010407_SIZE;
        ta_P3010408.MaxLength = cons.io.db.prp.PrpCons.P3010408_SIZE;
        ta_P3010409.MaxLength = cons.io.db.prp.PrpCons.P3010409_SIZE;
        #endregion

        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        LoadData(sid, opt);
    }

    private void LoadData(String sid, String opt)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010400);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010404);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010405);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010406);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010407);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010408);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010409);
        dba.addColumn(cons.io.db.prp.PrpCons.P301040B);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010402, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010403, cons.SysCons.UI_LANGHASH);

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hd_P3010402.Value = sid;
        hd_P3010404.Value = row[cons.io.db.prp.PrpCons.P3010404].ToString(); //文档路径
        tf_P3010405.Text = row[cons.io.db.prp.PrpCons.P3010405].ToString(); //文档名称
        tf_P3010406.Text = row[cons.io.db.prp.PrpCons.P3010406].ToString(); //发行版本
        tf_P3010407.Text = row[cons.io.db.prp.PrpCons.P3010407].ToString(); //发行日期
        ta_P3010408.Text = row[cons.io.db.prp.PrpCons.P3010408].ToString(); //文档摘要
        ta_P3010409.Text = row[cons.io.db.prp.PrpCons.P3010409].ToString(); //附注信息
        hd_P301040B.Value = row[cons.io.db.prp.PrpCons.P301040B].ToString(); //附注信息
    }

    protected void bt_P3010404_Click(object sender, EventArgs e)
    {
        aa_AmonAuth.InitData();

        if (!StringUtil.isValidate(fu_P3010404.FileName) || !fu_P3010404.HasFile || fu_P3010404.FileContent.Length < 1)
        {
            return;
        }

        if (!StringUtil.isValidateHash(hd_TempHash.Value))
        {
            hd_TempHash.Value = HashUtil.getCurrTimeHex(true);
        }
        if (!StringUtil.isValidatePath(hd_P3010404.Value))
        {
            hd_P3010404.Value = Exts.NextDocs("docs", hd_TempHash.Value);
        }

        try
        {
            fu_P3010404.SaveAs(Server.MapPath("~/temp/docs/") + hd_TempHash.Value + ".aed");
            tf_P3010405.Text = fu_P3010404.FileName;
            lb_ErrMsg.Text = "文档上传成功！";
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "文档上传出错：" + exp.Message;
        }
    }

    protected void bt_Update_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidatePath(hd_P3010404.Value))
        {
            lb_ErrMsg.Text = "请上传格式文档文件！";
            fu_P3010404.Focus();
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
        #endregion

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010400);
        dba.addParam(cons.io.db.prp.PrpCons.P3010404, WrpUtil.text2Db(hd_P3010404.Value));//文档路径
        dba.addParam(cons.io.db.prp.PrpCons.P3010405, WrpUtil.text2Db(tf_P3010405.Text));//文档名称
        dba.addParam(cons.io.db.prp.PrpCons.P3010406, WrpUtil.text2Db(tf_P3010406.Text)); //发行版本
        dba.addParam(cons.io.db.prp.PrpCons.P3010407, WrpUtil.text2Db(tf_P3010407.Text));//发行日期
        dba.addParam(cons.io.db.prp.PrpCons.P3010408, WrpUtil.text2Db(ta_P3010408.Text));//文档摘要
        dba.addParam(cons.io.db.prp.PrpCons.P3010409, WrpUtil.text2Db(ta_P3010409.Text));//附注信息
        dba.addParam(cons.io.db.prp.PrpCons.P301040A, cons.EnvCons.SQL_NOW, false);//更新日期

        try
        {
            int operate = 0;
            bool isUpdate = StringUtil.isValidate(hd_P3010402.Value);
            bool isManage = userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05;

            String P3010402;
            if (isUpdate)
            {
                P3010402 = WrpUtil.text2Db(hd_P3010402.Value);
            }
            else
            {
                P3010402 = HashUtil.getCurrTimeHex(false);
                hd_P3010402.Value = P3010402;
            }

            if (isManage)
            {
                if (isUpdate)
                {
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010402, P3010402);//文档索引
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010403, cons.SysCons.UI_LANGHASH);//语言索引
                    dba.addWhere(cons.io.db.prp.PrpCons.P301040C, "0", false);

                    dba.executeUpdate();

                    lb_ErrMsg.Text = "数据合并成功！";
                }
                else
                {
                    dba.addParam(cons.io.db.prp.PrpCons.P3010401, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010402, P3010402);//文档索引
                    dba.addParam(cons.io.db.prp.PrpCons.P3010403, cons.SysCons.UI_LANGHASH);//语言索引
                    dba.addParam(cons.io.db.prp.PrpCons.P301040B, cons.EnvCons.SQL_NOW, false);//更新日期
                    dba.addParam(cons.io.db.prp.PrpCons.P301040C, 0);
                    dba.addParam(cons.io.db.prp.PrpCons.P301040D, cons.wrp.WrpCons.OPT_NORMAL);
                    dba.addParam(cons.io.db.prp.PrpCons.P301040E, userInfo.UserCode);

                    dba.executeInsert();

                    lb_ErrMsg.Text = "数据新增成功！";
                }
            }
            else
            {
                dba.addParam(cons.io.db.prp.PrpCons.P3010401, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P3010401), false);//文档路径
                dba.addParam(cons.io.db.prp.PrpCons.P3010402, P3010402);//文档索引
                dba.addParam(cons.io.db.prp.PrpCons.P3010403, cons.SysCons.UI_LANGHASH);//语言索引
                dba.addParam(cons.io.db.prp.PrpCons.P301040B, isUpdate ? "'" + hd_P301040B.Value + "'" : cons.EnvCons.SQL_NOW, false);//创建日期
                dba.addParam(cons.io.db.prp.PrpCons.P301040C, String.Format("IFNULL(MAX({0}), -1) + 1", cons.io.db.prp.PrpCons.P301040C), false);
                dba.addParam(cons.io.db.prp.PrpCons.P301040D, isUpdate ? cons.wrp.WrpCons.OPT_UPDATE : cons.wrp.WrpCons.OPT_INSERT);
                dba.addParam(cons.io.db.prp.PrpCons.P301040E, userInfo.UserCode);

                dba.addWhere(cons.io.db.prp.PrpCons.P3010402, P3010402);
                dba.executeBackup(cons.io.db.prp.PrpCons.P3010400, cons.io.db.prp.PrpCons.P3010400);

                dba.reset();
                dba.addTable(cons.io.db.prp.PrpCons.P3010400);
                dba.addColumn(cons.io.db.prp.PrpCons.P301040C);
                dba.addWhere(cons.io.db.prp.PrpCons.P3010402, P3010402);
                dba.addWhere(cons.io.db.prp.PrpCons.P301040E, userInfo.UserCode);
                operate = (int)dba.executeSelect().Rows[0][cons.io.db.prp.PrpCons.P301040C];

                lb_ErrMsg.Text = "数据更新成功！";
            }

            if (StringUtil.isValidateHash(hd_TempHash.Value))
            {
                Exts.SaveDocs(EnvCons.DIR_TMP + "docs/", hd_TempHash.Value, ".aed", hd_P3010404.Value, isManage, operate);
            }
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "文档信息保存出错：" + exp.Message;
        }
    }
}