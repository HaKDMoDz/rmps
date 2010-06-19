using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.wrp;

/// <summary>
/// 流量统计
/// </summary>
public partial class inet_inet0104 : Page
{
    protected bool isRoot;
    protected bool isUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        isRoot = (randId == cons.comn.user.UserInfo.LEVEL_09);
        isUser = (randId >= cons.comn.user.UserInfo.LEVEL_02);
        if (!isUser)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "流量统计";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0104";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0104.aspx";
        guidItem.V1 = "流量统计";
        guidItem.V2 = "流量统计";

        // 页面回传事件
        if (IsPostBack)
        {
            return;
        }

        // 数据显示初始化
        DateTime now = DateTime.Now;
        LoadData(UserInfo.Current(Session).UserCode, now.ToString("yyyy-MM-dd"), 0);
        ib_StatView.ImageUrl = "/inet/inet0104.ashx?sid=" + UserInfo.Current(Session).UserCode;

        rb_DaysView.Items[0].Value = now.ToString("yyyy-MM-dd");
        rb_DaysView.Items[1].Value = now.AddDays(-1).ToString("yyyy-MM-dd");
        rb_DaysView.Items[2].Value = now.AddDays(-2).ToString("yyyy-MM-dd");

        // 管理员登录，则显示管理组件
        if (isRoot)
        {
            cb_UserList.Visible = true;
            Util.InitUserCodeList(cb_UserList, true);
            cb_UserList.SelectedValue = UserInfo.Current(Session).UserCode;
        }

        // 数据清理
        DoClean();
    }

    /// <summary>
    /// 日流量数据查询
    /// </summary>
    /// <param name="sid"></param>
    /// <param name="now"></param>
    /// <param name="idx"></param>
    private void LoadData(String sid, String now, int idx)
    {
        DBAccess dba = new DBAccess();

        dba.addTable(cons.io.db.wrp.WrpCons.W2012100);
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addColumn("DATE_FORMAT(" + cons.io.db.wrp.WrpCons.W2012103 + ", '%T')", cons.io.db.wrp.WrpCons.W2012103);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2012104);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019105);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019106);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019107);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2012105);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2012106);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2012107);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2012108);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2012109);
        dba.addColumn(cons.io.db.wrp.WrpCons.W201210A);
        dba.addColumn(cons.io.db.wrp.WrpCons.W201210B);
        if (sid != "00000001")
        {
            dba.addWhere(cons.io.db.wrp.WrpCons.W2012102, sid);
        }
        dba.addWhere(cons.io.db.wrp.WrpCons.W2012104, cons.io.db.wrp.WrpCons.W2019102, false);
        dba.addWhere("DATE_FORMAT(" + cons.io.db.wrp.WrpCons.W2012103 + ", '%Y-%m-%d')", "=", now, true);
        dba.addSort(cons.io.db.wrp.WrpCons.W2012103, false);

        DataTable dataList = dba.executeSelect();
        lb_ErrMsg.Visible = dataList.Rows.Count < 1;
        lb_PVCount.Text = dataList.Rows.Count.ToString();
        gv_StatList.DataSource = dataList;
        gv_StatList.PageIndex = idx;
        gv_StatList.DataBind();
    }

    /// <summary>
    /// 指定日期数据查看
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rb_DaysView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank == cons.comn.user.UserInfo.LEVEL_09)
        {
            LoadData(cb_UserList.SelectedValue, rb_DaysView.SelectedValue, 0);
        }
        else
        {
            LoadData(UserInfo.Current(Session).UserCode, rb_DaysView.SelectedValue, 0);
        }
    }

    /// <summary>
    /// 切换显示用户事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData(cb_UserList.SelectedValue, rb_DaysView.SelectedValue, 0);
        ib_StatView.ImageUrl = "/inet/inet0104.ashx?sid=" + cb_UserList.SelectedValue;
    }

    /// <summary>
    /// 分页事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_StatList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (UserInfo.Current(Session).UserRank == cons.comn.user.UserInfo.LEVEL_09)
        {
            LoadData(cb_UserList.SelectedValue, rb_DaysView.SelectedValue, e.NewPageIndex);
        }
        else
        {
            LoadData(UserInfo.Current(Session).UserCode, rb_DaysView.SelectedValue, e.NewPageIndex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="link"></param>
    /// <returns></returns>
    protected static String Trim(Object obj, bool link)
    {
        StringBuilder text = new StringBuilder();
        String tmp = obj != null ? obj.ToString().Trim() : "&nbsp;";
        if (tmp.Length < 1)
        {
            text.Append("&nbsp;");
        }
        else if (tmp.Length > 10)
        {
            text.Append("<a title=\"").Append(tmp).Append("\"");
            if (link)
            {
                text.Append(" href=\"").Append(tmp).Append("\"").Append(" target=\"_blank\"");
            }
            text.Append(">").Append(tmp.Substring(0, 7)).Append("...</a>");
        }
        else
        {
            text.Append(tmp);
        }

        return text.ToString();
    }

    /// <summary>
    /// 统计信息清理
    /// </summary>
    private void DoClean()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2012100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2012103, "<", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd"), true);
        dba.executeDelete();
    }
}