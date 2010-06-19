using System;
using System.Data;
using System.Text;
using System.Web.UI;

using cons.io.db.prp;
using cons.wrp.link;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;

public partial class link_link0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDSIZE] = UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_02 ? 5 : 3;
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0001";
        Session[cons.wrp.WrpCons.GUIDNAME] = "我的导航";

        if (IsPostBack)
        {
            return;
        }

        // 管理链接可见控制
        UserInfo ui = UserInfo.Current(Session);
        tr_Manager.Visible = ui.UserRank >= cons.comn.user.UserInfo.LEVEL_02;

        String tid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.URI]);// 上级类别ID
        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);// 当前类别ID
        if (!StringUtil.isValidate(sid, 16))
        {
            sid = LinkCons.LINK_HASH + ui.UserCode;
        }

        // 是否显示系统用户
        //bool sys = Request[cons.wrp.WrpCons.OPT] == "1";
        //ck_A0000000.Checked = sys;
        //ck_A0000000.Attributes.Add("onclick", "sysAction();");

        String uid = UserInfo.Current(Session).UserCode;
        //dv_TopType.InnerHtml = readTopType(tid, uid, sys);
        //dv_SubType.InnerHtml = readSubType(sid, uid, sys);
        //dv_CurLink.InnerHtml = readCurLink(sid, uid, 5, sys);

        hd_TOP.Value = tid;
        hd_SID.Value = sid;
        hd_UID.Value = uid;
    }

    /// <summary>
    /// 读取指定类别索引下的所有顶级类别，用于左侧显示
    /// </summary>
    /// <param name="tid">上级类别ID</param>
    /// <param name="uid">用户代码</param>
    /// <param name="sys"></param>
    public String readTopType(String tid, String uid, bool sys)
    {
        tid = WrpUtil.text2Db(tid);
        uid = WrpUtil.text2Db(uid);

        StringBuilder datBuf = new StringBuilder();
        datBuf.Append("<table border=\"0\" cellpadding=\"3\" cellspacing=\"2\" class=\"TB_TopType\" width=\"100%\">");

        // 指定上级类别的类别信息读取
        bool tok = StringUtil.isValidate(tid, 16);
        if (tok && StringUtil.isValidate(uid, 8))
        {
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010104);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
            dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
            if (sys && uid != cons.comn.user.UserInfo.COMN_CODE)
            {
                dba.addWhere(String.Format("{0}='{1}' OR {0}='{2}'", cons.io.db.comn.info.C2010000.C2010104, uid, cons.comn.user.UserInfo.COMN_CODE));
                dba.addSort(cons.io.db.comn.info.C2010000.C2010104, false);
            }
            else
            {
                dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, uid);
            }
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010106, tid);
            dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);

            DataTable dataList = dba.executeSelect();
            if (dataList != null)
            {
                foreach (DataRow row in dataList.Rows)
                {
                    datBuf.Append("<tr>");
                    datBuf.Append("<td align=\"center\" class=\"TD_").Append(GetStyle(row[cons.io.db.comn.info.C2010000.C2010104])).Append("TopType_D\" id=\"tt_").Append(row[cons.io.db.comn.info.C2010000.C2010105].ToString()).Append("\">");
                    AppendTopType(datBuf, row, uid);
                    datBuf.Append("</td>");
                    datBuf.Append("</tr>");
                }
            }
        }

        // 默认类别
        datBuf.Append("<tr>");
        datBuf.Append("<td align=\"center\" class=\"TD_TopType_H\" id=\"tt_").Append(tid).Append("\">");
        if (tok)
        {
            datBuf.Append("<a href=\"link0001.aspx\" title=\"返回上一级目录\" onclick=\"return preAction('").Append(tid).Append("','").Append(uid).Append("');\">上级类型</a>");
        }
        else
        {
            datBuf.Append("<a href=\"link0001.aspx\" title=\"我的导航\">我的导航</a>");
        }
        datBuf.Append("</td>");
        datBuf.Append("</tr>");

        datBuf.Append("</table>");
        return datBuf.ToString();
    }

    /// <summary>
    /// 读取指定类别索引下的所有下级类别，用于右侧显示
    /// </summary>
    /// <param name="sid">当前类型ID</param>
    /// <param name="uid">用户代码</param>
    /// <param name="sys">是否显示系统数据</param>
    /// <returns></returns>
    public String readSubType(String sid, String uid, bool sys)
    {
        sid = WrpUtil.text2Db(sid);
        uid = WrpUtil.text2Db(uid);
        if (!StringUtil.isValidate(sid, 16) || !StringUtil.isValidate(uid, 8))
        {
            return "";
        }

        StringBuilder datBuf = new StringBuilder();
        datBuf.Append("<table border=\"0\" cellpadding=\"3\" cellspacing=\"0\" class=\"TB_SubType\" width=\"100%\">");
        datBuf.Append("<tr><td class=\"TD_SubType_H\" align=\"left\" colspan=\"6\"><img src=\"/_images/type.png\" alt=\"\" style=\"vertical-align:middle;\" />&nbsp;下级类别</td></tr>");

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010104);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
        dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
        if (sys && uid != cons.comn.user.UserInfo.COMN_CODE)
        {
            dba.addWhere(String.Format("{0}='{1}' OR {0}='{2}'", cons.io.db.comn.info.C2010000.C2010104, uid, cons.comn.user.UserInfo.COMN_CODE));
            dba.addSort(cons.io.db.comn.info.C2010000.C2010104, false);
        }
        else
        {
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, uid);
        }
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010106, sid);
        dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);

        // 显示5列
        const int col = 5;

        DataTable dataList = dba.executeSelect();
        if (dataList != null && dataList.Rows.Count > 0)
        {
            datBuf.Append("<tr>");
            int tmp = 0;
            foreach (DataRow row in dataList.Rows)
            {
                if (tmp++ >= col)
                {
                    datBuf.Append("</tr>");
                    datBuf.Append("<tr>");
                    tmp = 1;
                }
                datBuf.Append("<td align=\"center\" style=\"width:76px;\" class=\"TD_").Append(GetStyle(row[cons.io.db.comn.info.C2010000.C2010104])).Append("SubType\">");
                AppendSubType(datBuf, row, uid);
                datBuf.Append("</td>");
            }
            while (tmp++ < col)
            {
                datBuf.Append("<td>");
                AppendNull(datBuf);
                datBuf.Append("</td>");
            }
            datBuf.Append("</tr>");
        }
        datBuf.Append("</table>");
        return datBuf.ToString();
    }

    /// <summary>
    /// 读取指定类别索引下的所有链接数据
    /// </summary>
    /// <param name="sid">类型索引</param>
    /// <param name="col">显示列数</param>
    /// <param name="uid">用户代码</param>
    /// <param name="sys">是否显示系统数据</param>
    public String readCurLink(String sid, String uid, int col, bool sys)
    {
        sid = WrpUtil.text2Db(sid);
        uid = WrpUtil.text2Db(uid);
        if (!StringUtil.isValidate(sid, 16) || !StringUtil.isValidate(uid, 8))
        {
            return "";
        }

        StringBuilder datBuf = new StringBuilder();
        datBuf.Append("<table border=\"0\" cellpadding=\"3\" cellspacing=\"0\" class=\"TB_CurLink\" width=\"100%\">");
        datBuf.Append("<tr><td class=\"TD_CurLink_H\" align=\"left\" colspan=\"").Append(col).Append("\"><img src=\"/_images/link.png\" alt=\"\" style=\"vertical-align:middle;\" />&nbsp;链接数据</td></tr>");
        datBuf.Append("<tr>");

        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3070100);
        dba.addTable(PrpCons.P3070200);
        if (sys && uid != cons.comn.user.UserInfo.COMN_CODE)
        {
            dba.addWhere(String.Format("{0}='{1}' OR {0}='{2}'", PrpCons.P3070103, uid, cons.comn.user.UserInfo.COMN_CODE));
            dba.addSort(PrpCons.P3070103, false);
        }
        else
        {
            dba.addWhere(PrpCons.P3070103, uid);
        }
        dba.addWhere(PrpCons.P3070105, PrpCons.P3070202, false);
        dba.addWhere(PrpCons.P3070203, sid);
        dba.addSort(PrpCons.P3070101, false);

        var dataList = dba.executeSelect();
        if (dataList != null && dataList.Rows.Count > 0)
        {
            var tmp = 0;
            foreach (DataRow row in dataList.Rows)
            {
                if (tmp++ >= col)
                {
                    datBuf.Append("</tr>");
                    datBuf.Append("<tr>");
                    tmp = 1;
                }
                datBuf.Append("<td align=\"center\" style=\"width:20%;\">");
                AppendNextLink(datBuf, row);
                datBuf.Append("</td>");
            }
            while (tmp++ < col)
            {
                datBuf.Append("<td>");
                AppendNull(datBuf);
                datBuf.Append("</td>");
            }
            datBuf.Append("</tr>");
        }
        datBuf.Append("</table>");

        return datBuf.ToString();
    }

    /// <summary>
    /// 读取上一级类别的索引
    /// </summary>
    /// <param name="sid"></param>
    /// <param name="uid"></param>
    /// <param name="uri"></param>
    /// <returns></returns>
    public String readPreType(String sid, String uid, bool uri)
    {
        sid = WrpUtil.text2Db(sid);
        uid = WrpUtil.text2Db(uid);
        if (!StringUtil.isValidate(sid, 16) || !StringUtil.isValidate(uid, 8))
        {
            return "";
        }

        var dba = new DBAccess();
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010106);
        if (uri && uid != cons.comn.user.UserInfo.COMN_CODE)
        {
            dba.addWhere(String.Format("{0}='{1}' OR {0}='{2}'", cons.io.db.comn.info.C2010000.C2010104, uid, cons.comn.user.UserInfo.COMN_CODE));
        }
        else
        {
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, uid);
        }
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010105, sid);

        var dt = dba.executeSelect();
        return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0][cons.io.db.comn.info.C2010000.C2010106].ToString() : "";
    }

    /// <summary>
    /// 类别访问频率统计
    /// </summary>
    /// <param name="sid"></param>
    public void updtTypeSeqs(String sid)
    {
        sid = WrpUtil.text2Db(sid);
        if (StringUtil.isValidate(sid, 16))
        {
            new DBAccess().UpdateStep(cons.io.db.comn.info.C2010000.C2010100, cons.io.db.comn.info.C2010000.C2010105, sid, cons.io.db.comn.info.C2010000.C2010101, 1);
        }
    }

    /// <summary>
    /// 链接数据频率统计
    /// </summary>
    /// <param name="sid"></param>
    public void updtLinkSeqs(String sid)
    {
        sid = WrpUtil.text2Db(sid);
        if (StringUtil.isValidate(sid, 16))
        {
            new DBAccess().UpdateStep(PrpCons.P3070100, PrpCons.P3070105, sid, PrpCons.P3070101, 1);
        }
    }

    /// <summary>
    /// 拼接空白字符
    /// </summary>
    /// <param name="buf"></param>
    private static void AppendNull(StringBuilder buf)
    {
        buf.Append("&nbsp;");
    }

    /// <summary>
    /// 拼接顶级类型链接
    /// </summary>
    /// <param name="buf"></param>
    /// <param name="row"></param>
    /// <param name="uid"></param>
    private static void AppendTopType(StringBuilder buf, DataRow row, String uid)
    {
        buf.Append("<a href=\"link0001.aspx?sid=").Append(row[cons.io.db.comn.info.C2010000.C2010105].ToString());
        buf.Append("\" title=\"").Append(row[cons.io.db.comn.info.C2010000.C201010A].ToString()).Append("\" onclick=\"return topAction('");
        buf.Append(row[cons.io.db.comn.info.C2010000.C2010105].ToString()).Append("','").Append(uid).Append("');\">").Append(row[cons.io.db.comn.info.C2010000.C2010107].ToString());
        buf.Append("</a>");
    }

    /// <summary>
    /// 拼接二级类别链接
    /// </summary>
    /// <param name="buf"></param>
    /// <param name="row"></param>
    /// <param name="uid"></param>
    private static void AppendSubType(StringBuilder buf, DataRow row, String uid)
    {
        buf.Append("<a href=\"link0001.aspx?sid=").Append(row[cons.io.db.comn.info.C2010000.C2010105].ToString()).Append("\" title=\"");
        buf.Append(row[cons.io.db.comn.info.C2010000.C201010A].ToString()).Append("\" onclick=\"return subAction('").Append(row[cons.io.db.comn.info.C2010000.C2010105].ToString()).Append("','").Append(uid).Append("');\">");
        buf.Append(row[cons.io.db.comn.info.C2010000.C2010107].ToString()).Append("</a>");
    }

    /// <summary>
    /// 拼接数据链接
    /// </summary>
    /// <param name="buf"></param>
    /// <param name="row"></param>
    private static void AppendNextLink(StringBuilder buf, DataRow row)
    {
        buf.Append("<a target=\"_blank\" href=\"").Append(row[PrpCons.P3070109].ToString()).Append("\" title=\"");
        buf.Append(row[PrpCons.P3070108].ToString()).Append("\" onclick=\"return openLink('");
        buf.Append(row[PrpCons.P3070105].ToString()).Append("');\">").Append(StringUtil.trim(row[PrpCons.P3070107].ToString(), 4));
        buf.Append("</a>");
    }

    /// <summary>
    /// 获得显示风格
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static char GetStyle(object obj)
    {
        return obj + "" == cons.comn.user.UserInfo.COMN_CODE ? 'S' : 'U';
    }
}