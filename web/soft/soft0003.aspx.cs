using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.wrp.soft;

/// <summary>
/// 软件在线使用
/// </summary>
public partial class soft_soft0003 : Page
{
    private const String NO_APPLET = "<div align=\"left\">"
         + "Applet无法运行，可能原因如下："
         + "<ul>"
         + "<li>您的浏览器目前不支持Applet小程序，建议您使用其它浏览器（如Firefox、Internet Explorer等）访问此网页；</li>"
         + "<li>您的机器尚未安装SUN Java运行环境，请到 <a href=\"http://www.java.com/\" target=\"_blank\">http://www.java.com/</a> 下载最新版运行环境安装后重新尝试。</li>"
         + "</ul>"
         + "</div>";

    protected void Page_Load(object sender, EventArgs e)
    {
        // 软件ID
        String sid = Request.Params[WrpCons.SID];
        if (sid == null || sid.Trim() == "")
        {
            Response.Redirect("~/soft/index.aspx");
            return;
        }
        String name = Soft.GetSoftName(sid);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "在线使用";
        Session[cons.wrp.WrpCons.SCRIPTID] = "soft0003";

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

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010104, sid);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010102, "1");

        DataTable dataList = dba.executeSelect();
        if (dataList != null && dataList.Rows.Count > 0)
        {
            DataRow row = dataList.Rows[0];
            hl_VersJnlp.NavigateUrl = row[cons.io.db.comn.ComnCons.C0010110].ToString();
            hl_VersDown.NavigateUrl = row[cons.io.db.comn.ComnCons.C001010F].ToString();
            String applet = row[cons.io.db.comn.ComnCons.C0010111].ToString();
            int dotIdx = applet.LastIndexOf("</");
            if (dotIdx > 0)
            {
                lt_VersCode.Text = applet.Insert(dotIdx, NO_APPLET);
            }
        }
    }
}