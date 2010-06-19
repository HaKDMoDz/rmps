using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using rmp.bean;
using rmp.comn.user;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

public partial class exts_exts0001 : Page
{
    protected bool bl_User;
    protected bool bl_Root;
    protected DBAccess dba;
    protected DataTable dv_DataView;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "在线查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0001";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0001.aspx";
        guidItem.V1 = "在线查询";
        guidItem.V2 = "在线查询";
        #endregion

        // 用户身份判别
        UserInfo ui = UserInfo.Current(Session);
        bl_User = ui.UserRank > cons.comn.user.UserInfo.LEVEL_01;
        bl_Root = ui.UserRank > cons.comn.user.UserInfo.LEVEL_04;

        if (IsPostBack)
        {
            return;
        }

        // 界面数据处理
        LoadData();
    }

    /// <summary>
    /// 查询按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_ExtsName_Click(object sender, EventArgs e)
    {
        // 记录用户是否使用异步
        Session[cons.wrp.WrpCons.P3010000_AJAX] = ck_ExtsAjax.Checked ? null : "1";

        String extsName;
        if (ck_ExtsFile.Checked)
        {
            // 文件查看
            String filePath = tf_ExtsFile.FileName;
            if (!StringUtil.isValidate(filePath))
            {
                hd_ErrMsg.Value = "您选择的不是一个有效的文件名称！";
                return;
            }
            extsName = Path.GetExtension(filePath);
            if (!StringUtil.isValidate(extsName))
            {
                hd_ErrMsg.Value = "无法获取您选择的文件的后缀信息！";
                return;
            }
            ck_ExtsFile.Checked = false;
        }
        else
        {
            // 手动输入
            extsName = tf_ExtsName.Text;
            if (!StringUtil.isValidate(extsName))
            {
                hd_ErrMsg.Value = "请输入您要查询的文件后缀信息！";
                return;
            }
        }

        // 合法性检测
        extsName = extsName.Trim().TrimStart('.');
        if (extsName == "")
        {
            hd_ErrMsg.Value = "请输入形如“.abc”格式的后缀名称！";
            return;
        }

        ShowExts(extsName, rb_ExtsCase.SelectedValue);
    }

    /// <summary>
    /// 后缀信息读取
    /// </summary>
    /// <param name="extsName"></param>
    /// <param name="extsCase"></param>
    private string ReadExts(String extsName, String extsCase)
    {
        String extsHash;

        switch (extsCase)
        {
            // 大写
            case cons.wrp.exts.ExtsCons.EXTS_CASE_UPPR:
                extsName = extsName.ToUpper();
                extsHash = HashUtil.digest(extsName, false);
                dv_DataView = Exts.srchHash(dba, extsHash, null);
                break;

            //小写
            case cons.wrp.exts.ExtsCons.EXTS_CASE_LOWR:
                extsName = extsName.ToLower();
                extsHash = HashUtil.digest(extsName, false);
                dv_DataView = Exts.srchHash(dba, extsHash, null);
                break;

            //模糊查询
            case cons.wrp.exts.ExtsCons.EXTS_CASE_BLUR:
                extsHash = HashUtil.digest(extsName, false);
                dv_DataView = Exts.srchName(dba, extsName, null);
                break;

            //大小敏感
            default:
                extsCase = cons.wrp.exts.ExtsCons.EXTS_CASE_CASE;
                extsHash = HashUtil.digest(extsName, false);
                dv_DataView = Exts.srchHash(dba, extsHash, null);
                break;
        }

        // 记录用户查询信息
        rb_ExtsCase.SelectedValue = extsCase;
        Exts.saveQuery(Session, extsHash, extsName, extsCase);
        return extsHash;
    }

    /// <summary>
    /// 显示后缀信息
    /// </summary>
    private void ShowExts(String extsName, String extsCase)
    {
        dba = new DBAccess();

        String extsHash = ReadExts(extsName, extsCase);
        Exts.appendHistory(Session, extsName); //查询历史
        hd_DataSize.Value = dv_DataView.Rows.Count.ToString(); //查询结果
        hd_ErrMsg.Value = dv_DataView.Rows.Count == 0 ? "您要查询的后缀数据 “." + extsName + "” 不存在！" : ""; //错误提示
        hl_Favorite.Visible = true; // 收藏本页
        tf_ExtsName.Focus(); //焦点事件

        if (extsHash != null)
        {
            dba.UpdateStep(cons.io.db.prp.PrpCons.P3010000, cons.io.db.prp.PrpCons.P3010003, extsHash, cons.io.db.prp.PrpCons.P3010001, 1);
        }
    }

    /// <summary>
    /// 界面数据加载
    /// </summary>
    private void LoadData()
    {
        ck_ExtsAjax.Checked = ("1" == Request["ajax"]);

        rb_ExtsCase.Items[0].Attributes.Add("accesskey", "R");
        rb_ExtsCase.Items[1].Attributes.Add("accesskey", "H");
        rb_ExtsCase.Items[2].Attributes.Add("accesskey", "U");
        rb_ExtsCase.Items[3].Attributes.Add("accesskey", "L");

        ck_ExtsFile.Attributes.Add("onclick", "chgExts()");

        // 页面参数获得
        String extsName = Request["exts"];
        // 外部传入参数处理
        if (StringUtil.isValidate(extsName))
        {
            extsName = extsName.Trim().TrimStart('.');
            if (extsName == "")
            {
                return;
            }

            ShowExts(extsName, Request["case"]);
            return;
        }

        // 其它页面转来事件处理
        if (Exts.needQuery(Session, false))
        {
            K1V2 extsItem = Exts.readQuery(Session);
            extsName = extsItem.V1;

            ShowExts(extsName, extsItem.V2);
            return;
        }
    }

    /// <summary>
    /// 更新后缀的查询频率
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_UpdtStep_Click(object sender, EventArgs e)
    {
        String softHash = hd_SoftHash.Value;
        if (softHash == null || (softHash.Length != 16 && softHash != "0"))
        {
            return;
        }

        String extsHash = Exts.readQuery(Session).K;
        if (extsHash.Length != 32)
        {
            return;
        }

        try
        {
            dba = new DBAccess();
            dba.UpdateStep(cons.io.db.prp.PrpCons.P3010000, new[] { cons.io.db.prp.PrpCons.P3010003, cons.io.db.prp.PrpCons.P3010006 }, new[] { extsHash, softHash }, cons.io.db.prp.PrpCons.P3010001, int.Parse(hd_StepSize.Value));
            dv_DataView = Exts.srchHash(dba, extsHash, null);
        }
        catch (Exception exp)
        {
            hd_ErrMsg.Value = exp.Message;
        }
    }

    protected void lb_DeltExts_Click(object sender, EventArgs e)
    {
        String softHash = WrpUtil.text2Db(hd_SoftHash.Value);
        if (!StringUtil.isValidate(softHash, 16) && softHash != "0")
        {
            return;
        }

        String extsHash = Exts.readQuery(Session).K;
        if (extsHash.Length != 32)
        {
            return;
        }

        dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010000);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010003, extsHash);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010006, softHash);
        dba.executeDelete();

        Exts.ExtsSize = Exts.ExtsSize - 1;
        dv_DataView = Exts.srchHash(dba, extsHash, null);
    }

    protected static String Info(DataRow row, String opt, String cnt)
    {
        if (row == null)
        {
            return "&nbsp;";
        }
        return rmp.wrp.exts.Exts.ShowDataStatus(row[cons.io.db.comn.user.UserCons.C3010407], row[opt], row[cnt]);
    }

    protected static String Text(DataRow row, String col)
    {
        return Text(row, col, "&nbsp;");
    }

    protected static String Text(DataRow row, String col, String def)
    {
        if (row == null)
        {
            return def;
        }
        col = row[col] + "";
        if (col.Trim() == "")
        {
            return def;
        }
        return WrpUtil.db2Html(col);
    }
}