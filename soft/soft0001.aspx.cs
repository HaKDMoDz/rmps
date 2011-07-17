using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.wrp.soft;
using rmp.util;

/// <summary>
/// 软件详细信息
/// </summary>
public partial class soft_soft0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 软件ID
        String sid = Request[cons.wrp.WrpCons.SID];
        if (sid == null || sid.Trim() == "")
        {
            Response.Redirect("~/soft/index.aspx");
            return;
        }
        String name = Soft.GetSoftName(sid);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = name;
        Session[cons.wrp.WrpCons.SCRIPTID] = "soft0001";

        // Guid List设置
        List<K1V2> guidList = Wrps.GuidSoft(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 1;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/soft/soft0001.aspx?sid=" + sid;
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

        // 查询语句
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010104, sid);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010102, ">", "0", true);

        // 查询结果
        DataTable dataList = dba.executeSelect();
        if (dataList != null && dataList.Rows.Count > 0)
        {
            DataRow row = dataList.Rows[0];

            string tips = row[cons.io.db.comn.ComnCons.C0010106] + "_" + row[cons.io.db.comn.ComnCons.C0010105];

            // 软件图标
            SoftView.ImageUrl = "/_images/" + sid + "U.png";
            SoftView.ToolTip = tips;

            // 界面预览
            SoftJnlp.NavigateUrl = row[cons.io.db.comn.ComnCons.C0010110].ToString();
            SoftJnlp.ToolTip = "在线启动软件";

            // 软件下载
            SoftDown.NavigateUrl = row[cons.io.db.comn.ComnCons.C001010F].ToString();
            SoftDown.ToolTip = tips;

            // 软件介绍
            SoftInfo.Text = WrpUtil.db2Html(row[cons.io.db.comn.ComnCons.C0010112].ToString());

            // 发行日期
            PubsTime.Text = row[cons.io.db.comn.ComnCons.C0010107].ToString();

            // 发行版本
            SoftVers.Text = row[cons.io.db.comn.ComnCons.C0010105].ToString();

            // 软件更新
            BugList.Text = WrpUtil.db2Html(row[cons.io.db.comn.ComnCons.C0010113].ToString());
        }
    }
}