using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;
using Util = rmp.comn.Util;

/// <summary>
/// 备选软件
/// </summary>
public partial class exts_exts0093 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0093";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0090.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0093.aspx";
        guidItem.V1 = "备选软件";
        guidItem.V2 = "备选软件";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        ta_P3010706.MaxLength = cons.io.db.prp.PrpCons.P3010706_SIZE;
        tf_P3010704.MaxLength = cons.io.db.prp.PrpCons.P3010704_SIZE;

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (!StringUtil.isValidate(sid))
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        tr_FindWays0.Visible = true;
        tr_FindWays1.Visible = false;
        tr_FindWays2.Visible = false;

        // 国别信息
        Util.InitStatData(cb_C1110100, cons.SysCons.UI_LANGHASH, true);

        // ====================================================================
        // 下一步按钮属性设置
        // ====================================================================
        bt_LastStep.OnClientClick = "window.location='/exts/exts0092.aspx?new=1&sid=" + sid + "';return false;";
        // 新增事件
        if (Request["new"] == "1")
        {
            hd_NextStep.Value = "~/exts/exts0094.aspx?new=1&sid=" + sid;
        }
        //更新事件
        else
        {
            hd_NextStep.Value = "~/exts/exts0001.aspx";

            bt_LastStep.Visible = false;
            bt_NextStep.Visible = false;
            Exts.needQuery(Session, true);
        }

        LoadData(sid);
    }

    private void LoadData(String sid)
    {
        hd_P3010703.Value = sid;

        DBAccess dba = new DBAccess();
        dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}", cons.io.db.prp.PrpCons.P3010700, cons.io.db.prp.PrpCons.P3010200, cons.io.db.prp.PrpCons.P3010704, cons.io.db.prp.PrpCons.P3010202));
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010205);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010701);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010702);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010704);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010705);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010709);
        dba.addColumn(cons.io.db.prp.PrpCons.P301070A);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
        dba.addWhere(cons.io.db.prp.PrpCons.P301070B, cons.io.db.comn.user.UserCons.C3010402, false);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010703, WrpUtil.text2Db(sid));
        dba.addSort(cons.io.db.prp.PrpCons.P3010702, false);
        dba.addSort(cons.io.db.prp.PrpCons.P3010701, false);

        DataTable dt = dba.executeSelect();
        StringBuilder P3010701 = new StringBuilder();
        StringBuilder P3010704 = new StringBuilder();
        foreach (DataRow row in dt.Rows)
        {
            P3010701.Append(row[cons.io.db.prp.PrpCons.P3010701]).Append(',');
            P3010704.Append(row[cons.io.db.prp.PrpCons.P3010704]).Append(',');
        }
        if (P3010701.Length > 0)
        {
            hd_P3010701.Value = P3010701.ToString(0, P3010701.Length - 1);
            hd_P3010704.Value = P3010704.ToString(0, P3010704.Length - 1);
        }

        rp_P3010704.DataSource = dt;
        rp_P3010704.DataBind();
    }

    protected String GetPlatform(Object obj)
    {
        StringBuilder buf = new StringBuilder();
        if (obj is int)
        {
            int ay = (int)obj;
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay == cons.SysCons.OS_IDX_ALL) ? "ALL" : "DEF").Append("&opt=16\" title=\"平台通用\" alt=\"平台通用\" width=\"16\" height=\"16\" />");
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay & cons.SysCons.OS_IDX_WINDOWS) != 0 ? "WIN" : "DEF").Append("&opt=16\" title=\"Windows平台\" alt=\"Windows平台\" width=\"16\" height=\"16\" />");
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay & cons.SysCons.OS_IDX_MACINTOSH) != 0 ? "MAC" : "DEF").Append("&opt=16\" title=\"Macintosh平台\" alt=\"Macintosh平台\" width=\"16\" height=\"16\" />");
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay & cons.SysCons.OS_IDX_LINUX) != 0 ? "LNX" : "DEF").Append("&opt=16\" title=\"Linux平台\" alt=\"Linux平台\" width=\"16\" height=\"16\" />");
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay & cons.SysCons.OS_IDX_UNIX) != 0 ? "UNX" : "DEF").Append("&opt=16\" title=\"Unix平台\" alt=\"Unix平台\" width=\"16\" height=\"16\" />");
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay & cons.SysCons.OS_IDX_MOBILE) != 0 ? "MBL" : "DEF").Append("&opt=16\" title=\"移动平台\" alt=\"移动平台\" width=\"16\" height=\"16\" />");
            buf.Append("<img src=\"").Append(cons.EnvCons.PRE_URL).Append("/icon/icon0001.ashx?sid=comn,_").Append((ay & cons.SysCons.OS_IDX_UNKNOWN) != 0 ? "SPC" : "DEF").Append("&opt=16\" title=\"其它平台\" alt=\"其它平台\" width=\"16\" height=\"16\" />");
        }
        return buf.ToString();
    }

    /// <summary>
    /// 搜索单选按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rb_Search_CheckedChanged(object sender, EventArgs e)
    {
        tr_FindWays0.Visible = true;
        tr_FindWays1.Visible = false;
        tr_FindWays2.Visible = false;
    }

    /// <summary>
    /// 手动单选按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rb_Manual_CheckedChanged(object sender, EventArgs e)
    {
        tr_FindWays0.Visible = false;
        tr_FindWays1.Visible = true;
        tr_FindWays2.Visible = true;
    }

    /// <summary>
    /// 软件查询按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P3010704_Click(object sender, EventArgs e)
    {
        cb_P3010704.Items.Clear();

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010200);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010202); //软件索引
        dba.addColumn(cons.io.db.prp.PrpCons.P3010205); //软件名称
        dba.addWhere(cons.io.db.prp.PrpCons.P3010205, "LIKE", '%' + Regex.Replace(WrpUtil.text2Db(tf_P3010704.Text), @"[\s%_]+", "%") + '%', true);
        dba.addSort(cons.io.db.prp.PrpCons.P3010201, false);

        cb_P3010704.DataSource = dba.executeSelect();
        cb_P3010704.DataTextField = cons.io.db.prp.PrpCons.P3010205;
        cb_P3010704.DataValueField = cons.io.db.prp.PrpCons.P3010202;
        cb_P3010704.DataBind();
    }

    /// <summary>
    /// 国别信息下拉列表选择事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_C1110100_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010704.Items.Clear();
        cb_P3010100.Items.Clear();

        String hash = cb_C1110100.SelectedValue;
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        Exts.InitCorpData(cb_P3010100, hash, true);
    }

    /// <summary>
    /// 公司信息下拉列表选择事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_P3010100_SelectedIndexChanged(object sender, EventArgs e)
    {
        cb_P3010704.Items.Clear();

        String hash = cb_P3010100.SelectedValue;
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        Exts.InitSoftData(cb_P3010704, hash, true);
    }

    /// <summary>
    /// 下一步按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect(hd_NextStep.Value);
    }

    /// <summary>
    /// 删除按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ib_Delete_Click(object sender, ImageClickEventArgs e)
    {
        String P3010704 = WrpUtil.text2Db(((ImageButton)sender).CommandArgument);
        if (!StringUtil.isValidateHash(P3010704))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010700);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010703, WrpUtil.text2Db(hd_P3010703.Value));
        dba.addWhere(cons.io.db.prp.PrpCons.P3010704, P3010704);


        if (userInfo.UserRank > cons.comn.user.UserInfo.LEVEL_05)
        {
            dba.executeDelete();
        }
        else
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010709, String.Format("{0}+1", cons.io.db.prp.PrpCons.P3010709), false);
            dba.addParam(cons.io.db.prp.PrpCons.P301070A, cons.wrp.WrpCons.OPT_DELETE);
            dba.addParam(cons.io.db.prp.PrpCons.P301070B, userInfo.UserCode);
            dba.executeUpdate();
        }

        LoadData(hd_P3010703.Value);

        lb_ErrMsg.Text = "备选软件删除成功！";

        ck_R.Checked = true;
        ck_W.Checked = false;
        ck_X.Checked = false;
        ta_P3010706.Text = "";
    }

    /// <summary>
    /// 保存按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Insert_Click(object sender, EventArgs e)
    {
        if (!StringUtil.isValidateHash(cb_P3010704.SelectedValue))
        {
            lb_ErrMsg.Text = "请选择您要添加的备选软件！";
            cb_P3010704.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }

        String P3010705 = "-";
        P3010705 += ck_R.Checked ? "r" : "-";
        P3010705 += ck_W.Checked ? "w" : "-";
        P3010705 += ck_X.Checked ? "x" : "-";

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010700);
        dba.addParam(cons.io.db.prp.PrpCons.P3010702, pf_PlatForm.PlatForm);
        dba.addParam(cons.io.db.prp.PrpCons.P3010705, P3010705);
        dba.addParam(cons.io.db.prp.PrpCons.P3010706, WrpUtil.text2Db(ta_P3010706.Text));
        dba.addParam(cons.io.db.prp.PrpCons.P3010707, cons.EnvCons.SQL_NOW, false);
        dba.addParam(cons.io.db.prp.PrpCons.P301070A, cons.wrp.WrpCons.OPT_INSERT);
        dba.addParam(cons.io.db.prp.PrpCons.P301070B, userInfo.UserCode);

        // 数据新增
        if (hd_IsUpdate.Value == "1")
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010709, String.Format("{0}+1", cons.io.db.prp.PrpCons.P3010709), false);

            dba.addWhere(cons.io.db.prp.PrpCons.P3010703, WrpUtil.text2Db(hd_P3010703.Value));
            dba.addWhere(cons.io.db.prp.PrpCons.P3010704, WrpUtil.text2Db(cb_P3010704.SelectedValue));

            dba.executeUpdate();

            lb_ErrMsg.Text = "备选软件更新成功！";
        }
        else
        {
            dba.addParam(cons.io.db.prp.PrpCons.P3010701, 0);
            dba.addParam(cons.io.db.prp.PrpCons.P3010703, hd_P3010703.Value);
            dba.addParam(cons.io.db.prp.PrpCons.P3010704, cb_P3010704.SelectedValue);
            dba.addParam(cons.io.db.prp.PrpCons.P3010708, cons.EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.prp.PrpCons.P3010709, 0);

            dba.executeInsert();

            lb_ErrMsg.Text = "备选软件添加成功！";
        }

        LoadData(hd_P3010703.Value);

        ck_R.Checked = true;
        ck_W.Checked = false;
        ck_X.Checked = false;
        ta_P3010706.Text = "";
        hd_IsUpdate.Value = "0";
    }

    /// <summary>
    /// 完成按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String[] P3010701 = hd_P3010701.Value.Split(',');
        String[] P3010704 = hd_P3010704.Value.Split(',');
        String P3010703 = WrpUtil.text2Db(hd_P3010703.Value);
        if (P3010701 != null && P3010701.Length > 0 && P3010701.Length == P3010704.Length && StringUtil.isValidateHash(P3010703))
        {
            DBAccess dba = new DBAccess();
            for (int i = 0; i < P3010701.Length; i += 1)
            {
                if (Regex.IsMatch(P3010701[i], @"^\d+$"))
                {
                    dba.addTable(cons.io.db.prp.PrpCons.P3010700);
                    dba.addParam(cons.io.db.prp.PrpCons.P3010701, P3010701[i]);
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010703, P3010703);
                    dba.addWhere(cons.io.db.prp.PrpCons.P3010704, WrpUtil.text2Db(P3010704[i]));
                    dba.executeUpdate();
                    dba.reset();
                }
            }
        }

        LoadData(hd_P3010703.Value);

        lb_ErrMsg.Text = "数据更新成功！";

        aa_AmonAuth.InitData();
    }
}