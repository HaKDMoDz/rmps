using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.io.db.comn;
using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.util;
using System.Text.RegularExpressions;

public partial class exts_exts0101 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "公司信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0101";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0101.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0100.aspx";
        guidItem.V1 = "公司信息";
        guidItem.V2 = "公司信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0101.aspx";
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
    protected void bt_P3010105_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010100);
        dba.addTable(ComnCons.C1110100);
        dba.addColumn(ComnCons.C1110104);
        dba.addColumn(PrpCons.P3010105);
        dba.addColumn(PrpCons.P301010A);
        dba.addColumn(PrpCons.P3010102);
        dba.addColumn(cons.io.db.prp.PrpCons.P301010C);
        dba.addWhere(PrpCons.P3010103, ComnCons.C1110102, false);
        dba.addWhere(ComnCons.C1110103, cons.SysCons.UI_LANGHASH);

        String corpName = (tf_P3010105.Text ?? "").Trim();
        if (corpName != "")
        {
            dba.addWhere(PrpCons.P3010105, "LIKE", WrpUtil.text2Like(corpName), true);
        }
        dba.addSort(ComnCons.C1110104);
        dba.addSort(PrpCons.P3010105);

        rp_SoftList.DataSource = dba.executeSelect();
        rp_SoftList.DataBind();
    }
}