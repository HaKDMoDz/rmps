using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.wrp;

public partial class exts_exts0304 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank <= cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "文件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0304";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0301.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0300.aspx";
        guidItem.V1 = "文件信息";
        guidItem.V2 = "文件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0304.aspx";
        guidItem.V1 = "数据删除";
        guidItem.V2 = "数据删除";

        if (IsPostBack)
        {
            return;
        }

        String sid = Request[cons.wrp.WrpCons.SID];
        if (sid == null)
        {
            Response.Redirect("exts0301.aspx");
            return;
        }
        sid = sid.Trim();
        if (sid == "")
        {
            Response.Redirect("exts0301.aspx");
            return;
        }

        hd_FileHash.Value = sid;
    }

    protected void bt_Delete_Click(object sender, EventArgs e)
    {
        // 修改后缀数据的文件信息为默认
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010000);
        dba.addParam(PrpCons.P3010007, "0");
        dba.addWhere(PrpCons.P3010007, hd_FileHash.Value);
        dba.executeUpdate();

        //sqlTable = PrpCons.P3010200;
        //sqlUpdate = String.Format("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}'",
        //    sqlTable,
        //    PrpCons.P3010203, "0",
        //    PrpCons.P3010203, hd_FileHash.Value);
        //dba.UpdateData(sqlTable, sqlUpdate);

        // 删除文件信息
        dba.reset();
        dba.addTable(PrpCons.P3010300);
        dba.addWhere(PrpCons.P3010302, hd_FileHash.Value);
        dba.executeDelete();

        Response.Redirect("exts0301.aspx");
    }
}