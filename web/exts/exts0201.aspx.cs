using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class exts_exts0201 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "软件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0201";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0201.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0200.aspx";
        guidItem.V1 = "软件信息";
        guidItem.V2 = "软件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0201.aspx";
        guidItem.V1 = "数据查询";
        guidItem.V2 = "数据查询";
        #endregion

        if (IsPostBack)
        {
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P3010205_Click(object sender, EventArgs e)
    {
        SoftView();
    }

    private void SoftView()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010200);
        dba.addTable(cons.io.db.prp.PrpCons.P3010100);
        dba.addTable(cons.io.db.comn.user.UserCons.C3010400);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010105);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010205);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010202);
        dba.addColumn(cons.io.db.prp.PrpCons.P301020F);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010210);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010211);
        dba.addColumn(cons.io.db.comn.user.UserCons.C3010407);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010203, cons.io.db.prp.PrpCons.P3010102, false);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010211, cons.io.db.comn.user.UserCons.C3010402, false);
        String softName = (tf_P3010205.Text ?? "").Trim();
        if (softName != "")
        {

            softName = Regex.Replace(WrpUtil.text2Db(softName), "[\\s%_]+", "%");
            if (softName != "%")
            {
                dba.addWhere(cons.io.db.prp.PrpCons.P3010205, "LIKE", '%' + softName + '%', true);
            }
        }
        dba.addSort(cons.io.db.prp.PrpCons.P3010105);
        dba.addSort(cons.io.db.prp.PrpCons.P3010205);
        dba.addSort(cons.io.db.prp.PrpCons.P301020F, false);

        rp_SoftList.DataSource = dba.executeSelect();
        rp_SoftList.DataBind();
    }
}