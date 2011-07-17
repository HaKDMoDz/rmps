using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.io.db.prp;
using cons.wrp.exts;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

/// <summary>
/// 文档信息
/// </summary>
public partial class exts_exts0016 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ====================================================================
        // 用户身份认证
        // ====================================================================
        if (UserInfo.Current(Session).UserRank <= cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0016";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0016.aspx";
        guidItem.V1 = "文档信息";
        guidItem.V2 = "文档信息";

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

        LoadData();

        cb_P3010008.SelectedValue = extsBase.P3010008;
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

        extsBase.P3010008 = cb_P3010008.SelectedValue;
        Response.Redirect("~/exts/exts0017.aspx");
    }

    /// <summary>
    /// 文档上传按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P3010404_Click(object sender, EventArgs e)
    {
        tf_P3010405.Text = fu_P3010404.FileName;

        String path = Server.MapPath("docs");
        String P3010404 = hd_P3010404.Value;
        if (!string.IsNullOrEmpty(P3010404))
        {
            File.Delete(path + P3010404);
            P3010404 = P3010404.Substring(0, 16);
        }
        else
        {
            P3010404 = HashUtil.getCurrTimeHex(false);
        }

        P3010404 += Path.GetExtension(fu_P3010404.FileName);
        fu_P3010404.SaveAs(path + P3010404);

        hd_P3010404.Value = P3010404;
    }

    /// <summary>
    /// 保存按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Insert_Click(object sender, EventArgs e)
    {
        String hash = HashUtil.getCurrTimeHex(false);

        DBAccess dba = new DBAccess();

        dba.addTable(PrpCons.P3010400);
        dba.addParam(PrpCons.P3010401, 0);
        dba.addParam(PrpCons.P3010402, hash); //文档索引
        dba.addParam(PrpCons.P3010403, cons.SysCons.UI_LANGHASH); //语言索引
        dba.addParam(PrpCons.P3010404, hd_P3010404.Value); //文档路径
        dba.addParam(PrpCons.P3010405, WrpUtil.text2Db(tf_P3010405.Text)); //文档名称
        dba.addParam(PrpCons.P3010406, WrpUtil.text2Db(tf_P3010406.Text)); //发行版本
        dba.addParam(PrpCons.P3010407, WrpUtil.text2Db(tf_P3010407.Text)); //发行日期
        dba.addParam(PrpCons.P3010408, WrpUtil.text2Db(ta_P3010408.Text)); //文档摘要
        dba.addParam(PrpCons.P3010409, WrpUtil.text2Db(ta_P3010409.Text)); //附注信息
        dba.addParam(PrpCons.P301040A, cons.EnvCons.SQL_NOW, false); //更新日期
        dba.addParam(PrpCons.P301040B, cons.EnvCons.SQL_NOW, false); //更新日期

        dba.executeInsert();

        LoadData();

        cb_P3010008.SelectedValue = hash;
        tf_P3010405.Text = "";
        tf_P3010406.Text = "";
        tf_P3010407.Text = "";
        ta_P3010408.Text = "";
        ta_P3010409.Text = "";
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
    /// 数据初始化
    /// </summary>
    private void LoadData()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010400);
        dba.addColumn(PrpCons.P3010402);
        dba.addColumn(PrpCons.P3010405);
        dba.addWhere(PrpCons.P3010403, cons.SysCons.UI_LANGHASH);
        dba.addSort(PrpCons.P3010405);

        cb_P3010008.DataSource = dba.executeSelect();
        cb_P3010008.DataTextField = PrpCons.P3010405;
        cb_P3010008.DataValueField = PrpCons.P3010402;
        cb_P3010008.DataBind();
        cb_P3010008.Items.Insert(0, new ListItem("（未知）", "0"));
    }
}