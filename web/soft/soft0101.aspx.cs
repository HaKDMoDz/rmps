using System;
using System.Collections.Generic;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 软件查询
/// </summary>
public partial class soft_soft0101 : System.Web.UI.Page
{
    protected String nextPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "软件查询";
        Session[cons.wrp.WrpCons.SCRIPTID] = "soft0101";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        // Guid List设置
        List<K1V2> guidList = Wrps.GuidSoft(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = String.Format("/{0}soft/soft0101.aspx", cons.EnvCons.PRE_URL);
        guidItem.V1 = "软件查询";
        guidItem.V2 = "软件查询";

        guidItem = guidList[2];
        guidItem.K = String.Format("/{0}soft/soft0103.aspx", cons.EnvCons.PRE_URL);
        guidItem.V1 = "新增数据";
        guidItem.V2 = "新增数据";

        nextPage = rmp.comn.user.UserInfo.Current(Session).UserRank > cons.comn.user.UserInfo.LEVEL_02 ? "soft0103.aspx" : "soft0102.aspx";

        if (IsPostBack)
        {
            return;
        }
    }

    /// <summary>
    /// 执行查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_C0010100_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addColumn(cons.io.db.comn.ComnCons.C0010103);
        dba.addColumn(cons.io.db.comn.ComnCons.C0010104);
        dba.addColumn(cons.io.db.comn.ComnCons.C0010106);
        dba.addColumn(cons.io.db.comn.ComnCons.C0010108);

        String text = tf_C0010100.Text.Trim();
        if (!String.IsNullOrEmpty(text))
        {
            text = '%' + WrpUtil.text2Db(tf_C0010100.Text).Replace(' ', '%') + '%';
            dba.addWhere(String.Format("{1} LIKE '{0}' OR {2} LIKE '{0}' OR {3} LIKE '{0}' OR {4} LIKE '{0}'", text, cons.io.db.comn.ComnCons.C0010104, cons.io.db.comn.ComnCons.C0010106, cons.io.db.comn.ComnCons.C0010112, cons.io.db.comn.ComnCons.C0010113));
        }
        dba.addWhere(String.Format("{0} NOT LIKE '_7'", cons.io.db.comn.ComnCons.C0010102));
        dba.addSort(cons.io.db.comn.ComnCons.C0010104);

        rp_SoftList.DataSource = dba.executeSelect();
        rp_SoftList.DataBind();
    }
}
