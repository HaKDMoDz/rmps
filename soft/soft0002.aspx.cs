using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.wrp.soft;

/// <summary>
/// 软件历史版本
/// </summary>
public partial class soft_soft0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 参数读取
        String sid = Request[WrpCons.SID];
        if (sid == null || sid.Trim() == "")
        {
            Response.Redirect("~/soft/index.aspx");
            return;
        }
        String name = Soft.GetSoftName(sid);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "历史版本";
        Session[cons.wrp.WrpCons.SCRIPTID] = "soft0002";

        // Guid List设置
        List<K1V2> guidList = Wrps.GuidSoft(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 1;
        K1V2 guidItem = guidList[1];
        guidItem.V1 = name;
        guidItem.V2 = name;
        guidList[2].K = cons.EnvCons.PRE_URL + "/soft/soft0002.aspx?sid=" + sid;
        guidList[3].K = cons.EnvCons.PRE_URL + "/soft/soft0003.aspx?sid=" + sid;
        guidList[4].K = cons.EnvCons.PRE_URL + "/down/down0001.aspx?sid=" + sid;
        guidList[5].K = cons.EnvCons.PRE_URL + "/soft/soft9999.aspx?sid=" + sid;

        if (IsPostBack)
        {
            return;
        }

        // SQL语句封装
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010104, sid);
        dba.addSort(cons.io.db.comn.ComnCons.C0010105, false);

        // 数据查询与梆定
        VersList.DataSource = dba.executeSelect();
        VersList.DataBind();
    }
}