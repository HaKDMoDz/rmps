using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;

public partial class exts_exts0301 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
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
        String sqlTable = PrpCons.P3010300;
        String sqlSelect = String.Format("SELECT {4}, {5}, {6}, {7} FROM {0}, {1} WHERE {2}={3}",
                                         sqlTable, PrpCons.P3010200,
                                         PrpCons.P3010303, PrpCons.P3010202,
                                         PrpCons.P3010205, PrpCons.P3010306,
                                         PrpCons.P3010305, PrpCons.P3010302);

        String fileSign = tf_P3010306.Text.Trim();
        if (fileSign != "")
        {
            fileSign = '%' + fileSign.Replace("'", "\\'").Replace(' ', '%') + '%';
            sqlSelect += String.Format(" AND {0} LIKE '{1}'", PrpCons.P3010306, fileSign);
        }
        sqlSelect += String.Format(" ORDER BY {0}, {1}", PrpCons.P3010205, PrpCons.P3010306);

        DataView dv = new DBAccess().CreateView(sqlTable, sqlSelect);
        rp_FileList.DataSource = dv;
        rp_FileList.DataBind();
    }

    protected void lb_NullFile_Click(object sender, EventArgs e)
    {
        String sqlTable = PrpCons.P3010300;
        String sqlSelect = String.Format("SELECT {4}, {5}, {6}, {7} FROM {0}, {1} WHERE {2}={3}",
                                         sqlTable, PrpCons.P3010200,
                                         PrpCons.P3010303, PrpCons.P3010202,
                                         PrpCons.P3010205, PrpCons.P3010306,
                                         PrpCons.P3010305, PrpCons.P3010302);

        sqlSelect += " AND P3010302 NOT IN (SELECT DISTINCT(P3010006) FROM P3010000)";
    }
}