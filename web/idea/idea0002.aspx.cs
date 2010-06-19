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
/// 所有留言
/// </summary>
public partial class idea_idea0002 : Page
{
    /// <summary>
    /// 当前页索引：从数值1开始
    /// </summary>
    private int pageIndx;

    /// <summary>
    /// 每页显示记录数量
    /// </summary>
    private int pageRows = 10;

    /// <summary>
    /// 记录总页数：从数值1开始
    /// </summary>
    private int pageSize;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 软件索引
        String sid = Request.Params[WrpCons.SID];
        String snm;
        if (string.IsNullOrEmpty(sid))
        {
            sid = "";
            snm = "所有留言";
        }
        else
        {
            sid = sid.Trim();
            snm = Soft.GetSoftName(sid);
        }
        hd_IdeaHash.Value = sid;

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = snm;
        Session[cons.wrp.WrpCons.SCRIPTID] = "idea0002";

        List<K1V2> guidList = Wrps.GuidIdea(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 1;
        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/idea/idea0002.aspx";
        guidItem.V1 = snm;
        guidItem.V2 = snm;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        DBAccess dba = new DBAccess();

        // 符合条件的记录总数
        DataSize(dba, sid);

        // 查询符合条件的数据
        ListData(dba, sid);
    }

    /// <summary>
    /// 上一页事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LastPage_Click(object sender, EventArgs e)
    {
        pageIndx = Int32.Parse(LB_PageIndx.Text);
        pageSize = Int32.Parse(LB_PageSize.Text);

        // 第0页，直接返回
        if (pageIndx == 1)
        {
            return;
        }

        pageIndx -= 1;
        LB_PageIndx.Text = "" + pageIndx;

        // 查询符合条件的数据
        ListData(new DBAccess(), hd_IdeaHash.Value);
    }

    /// <summary>
    /// 下一页事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void NextPage_Click(object sender, EventArgs e)
    {
        pageIndx = Int32.Parse(LB_PageIndx.Text);
        pageSize = Int32.Parse(LB_PageSize.Text);

        // 最后一页，直接返回
        if (pageIndx == pageSize)
        {
            return;
        }

        pageIndx += 1;
        LB_PageIndx.Text = "" + pageIndx;

        // 查询符合条件的数据
        ListData(new DBAccess(), hd_IdeaHash.Value);
    }

    /// <summary>
    /// 计算查询结果分页数量
    /// </summary>
    /// <param name="dba"></param>
    private void DataSize(DBAccess dba, String sid)
    {
        // 关联条件拼接
        String sqlWhere;
        if (sid != "")
        {
            sqlWhere = String.Format(" WHERE {0} = '{1}'", cons.io.db.wrp.WrpCons.IDEADATA_SOFTINDX, sid);
        }
        else
        {
            sqlWhere = String.Format(" WHERE length({0}) > 8", cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX);
        }

        // 数据库操作语句
        String sqlTable = cons.io.db.wrp.WrpCons.WRP_IDEA_IDEADATA;
        String sqlSelect = String.Format("SELECT COUNT({0}) AS {0} FROM {1} {2}", cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX, sqlTable, sqlWhere);

        // 符合条件的记录个数
        DataView dataView = dba.CreateView(sqlTable, sqlSelect);
        String temp = dataView[0][0].ToString();
        dataView.Dispose();

        LB_IdeaSize.Text = temp;
        // 当前页索引
        pageIndx = 1;
        // 总数据页数
        pageSize = (Convert.ToInt32(temp) - 1) / pageRows + 1;
        LB_PageSize.Text = "" + pageSize;
    }

    /// <summary>
    /// 查询指定页面符合条件的数据并显示
    /// </summary>
    private void ListData(DBAccess dba, String sid)
    {
        // 关联条件拼接
        String sqlWhere;
        if (sid != "")
        {
            sqlWhere = String.Format(" WHERE {0} = '{1}'", cons.io.db.wrp.WrpCons.IDEADATA_SOFTINDX, sid);
        }
        else
        {
            sqlWhere = String.Format(" WHERE length({0}) > 8", cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX);
        }

        // 分页链接使能变更
        LB_LastPage.Enabled = (pageIndx != 1);
        LB_NextPage.Enabled = (pageIndx != pageSize);

        // 数据绑定
        String sqlTable = cons.io.db.wrp.WrpCons.WRP_IDEA_IDEADATA;
        String sqlSelect = String.Format("SELECT * FROM {0} {1} ORDER BY {2} DESC", sqlTable, sqlWhere, cons.io.db.wrp.WrpCons.IDEADATA_DATETIME);
        DataView dataView = dba.CreateView(sqlTable, sqlSelect, pageIndx - 1, pageRows);
        LB_PageIndx.Text = "" + pageIndx;

        // 数据绑定
        ideaView.DataSource = dataView;
        ideaView.DataBind();
    }
}