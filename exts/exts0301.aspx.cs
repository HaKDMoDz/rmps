using System;
using System.Collections.Generic;
using System.Web.UI;
using cons.io.db.prp;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class exts_exts0301 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "文件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0301";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0301.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0300.aspx";
        guidItem.V1 = "文件信息";
        guidItem.V2 = "文件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0301.aspx";
        guidItem.V1 = "数据查询";
        guidItem.V2 = "数据查询";
        #endregion

        if (IsPostBack)
        {
            return;
        }
    }

    protected void bt_P3010306_Click(object sender, EventArgs e)
    {
        FileView();
    }

    private void FileView()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010300);
        dba.addTable(PrpCons.P3010200);
        dba.addColumn(PrpCons.P3010205);
        dba.addColumn(PrpCons.P3010306);
        dba.addColumn(PrpCons.P3010305);
        dba.addColumn(PrpCons.P3010302);
        dba.addWhere(PrpCons.P3010303, PrpCons.P3010202, false);

        String fileSign = (tf_P3010306.Text ?? "").Trim();
        if (fileSign != "")
        {
            dba.addWhere(PrpCons.P3010306, "LIKE", WrpUtil.text2Like(fileSign), true);
        }

        dba.addSort(PrpCons.P3010205, true);
        dba.addSort(PrpCons.P3010306, true);

        rp_FileList.DataSource = dba.executeSelect();
        rp_FileList.DataBind();
    }

    protected void lb_NullFile_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010300);
        dba.addTable(PrpCons.P3010200);
        dba.addColumn(PrpCons.P3010205);
        dba.addColumn(PrpCons.P3010306);
        dba.addColumn(PrpCons.P3010305);
        dba.addColumn(PrpCons.P3010302);
        dba.addWhere(PrpCons.P3010303, PrpCons.P3010202, false);
        dba.addWhere(PrpCons.P3010302, "NOT IN", "(SELECT DISTINCT(P3010006) FROM P3010000)", false);

        rp_FileList.DataSource = dba.executeSelect();
        rp_FileList.DataBind();
    }
}