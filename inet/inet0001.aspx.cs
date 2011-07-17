using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.io.db.comn;
using cons.io.db.wrp;

using rmp.io.db;
using rmp.util;

/// <summary>
/// 网页精灵服务器端高级页面
/// 接收参数信息：
/// f：默认调用用户
/// t：来源页面标题
/// u：来源页面路径
/// d：来源页面选择文本
/// i：是否为内嵌页面
/// w：显示宽度
/// c：显示列数
/// h：显示高度
/// r：显示行数
/// </summary>
public partial class inet_inet0001 : Page
{
    /// <summary>
    /// 界面布局参数
    /// </summary>
    protected int PAGE_WIDH = 400;
    protected int PAGE_HIGH = 400;
    protected int PAGE_ROWS = 10;
    protected int PAGE_COLS = 2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // 页面传入参数
        hd_T.Value = Request["t"] ?? "";
        hd_U.Value = Request["u"] ?? "";
        hd_D.Value = Request["d"] ?? "";

        // 临时变量
        int ti;
        Regex rx = new Regex("^\\d+$");

        // 读取宽度参数
        String ts = Request["w"] ?? "";
        if (rx.IsMatch(ts))
        {
            ti = int.Parse(ts);
            PAGE_WIDH = ti;
            ti = ti / 70;
            if (ti < PAGE_COLS)
            {
                PAGE_COLS = ti;
            }
        }

        // 显示列参数
        ts = Request["c"] ?? "";
        if (rx.IsMatch(ts))
        {
            PAGE_COLS = int.Parse(ts);
        }

        // 读取调度参数
        ts = Request["h"] ?? "";
        if (rx.IsMatch(ts))
        {
            ti = int.Parse(ts);
            PAGE_HIGH = ti;
            ti = (ti - 56) / 20;
            if (ti < PAGE_ROWS)
            {
                PAGE_ROWS = ti;
            }
        }

        // 显示行参数
        ts = Request["r"] ?? "";
        if (rx.IsMatch(ts))
        {
            PAGE_ROWS = int.Parse(ts);
        }
        PAGE_HIGH = PAGE_ROWS * 20 + 56;

        LoadData();
    }

    /// <summary>
    /// 数据读取
    /// </summary>
    private void LoadData()
    {
        // 用户配置信息（用户ID）
        String f = WrpUtil.text2Db(Request["f"]);
        if (!StringUtil.isValidate(f, 8))
        {
            if (f.Length != 4 || f[0] != 't')
            {
                f = "tnet";
            }
        }
        hd_F.Value = f;
        // 是否为内嵌页面
        if (Request["i"] == "1")
        {
            tr_SoftGuid.Visible = true;
            tr_PageGuid.Visible = false;
            Net_Amonsoft_NetHelper_GUID.InnerHtml = "<a title=\"用户信息\">" + rmp.comn.user.Util.GetUserNameByCode(f) + "</a>";
        }
        else
        {
            tr_SoftGuid.Visible = false;
            tr_PageGuid.Visible = true;
            Net_Amonsoft_NetHelper_GUID.InnerHtml = "<a href=\"/\" title=\"访问网站首页\" target=\"_blank\">网站首页</a>";
        }

        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C2010000);
        dba.addTable(WrpCons.W2011100);
        dba.addColumn(ComnCons.C2010002);
        dba.addColumn(ComnCons.C2010004);
        dba.addWhere(ComnCons.C2010002, WrpCons.W2011104, false);
        dba.addWhere(ComnCons.C2010003, "42010000");
        dba.addWhere(WrpCons.W2011105, f);
        dba.addWhere(WrpCons.W2011102, "1");
        dba.addSort(WrpCons.W2011101);
        DataTable kindList = dba.executeSelect();

        Net_Amonsoft_NetHelper_TABS_TD.DataSource = kindList;
        Net_Amonsoft_NetHelper_TABS_TD.DataBind();

        StringBuilder dvid = new StringBuilder("var DVID = new Array(");
        StringBuilder dvnm = new StringBuilder("var DVNM = new Array(");
        foreach (DataRow row in kindList.Rows)
        {
            switch (row[ComnCons.C2010002].ToString())
            {
                case "iNetHelper_10bms":
                    {
                        dvid.Append("'10bms',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_10bms_TB.RepeatColumns = PAGE_COLS;
                        bmsPageData(dba, 0);
                    }
                    break;
                case "iNetHelper_20rss":
                    {
                        dvid.Append("'20rss',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_20rss_TB.RepeatColumns = PAGE_COLS;
                        rssPageData(dba, 0);
                    }
                    break;
                case "iNetHelper_30wse":
                    {
                        dvid.Append("'30wse',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_30wse_TB.RepeatColumns = PAGE_COLS;
                        wsePageData(dba, 0);
                    }
                    break;
                case "iNetHelper_31ssl":
                    {
                        dvid.Append("'31ssl',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        sslPageData(dba, 0);
                    }
                    break;
                case "iNetHelper_32map":
                    {
                        dvid.Append("'32map',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_32map_TB.RepeatColumns = PAGE_COLS;
                        mapPageData(dba, 0);
                    }
                    break;
                case "iNetHelper_40cal":
                    {
                        dvid.Append("'40cal',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        break;
                    }
                case "iNetHelper_41dts":
                    {
                        dvid.Append("'41dts',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        break;
                    }
                case "iNetHelper_50wlt":
                    {
                        dvid.Append("'50wlt',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_50wlt_TB.RepeatColumns = PAGE_COLS;
                        wltPageData(dba, 0);
                    }
                    break;
                case "iNetHelper_60wmc":
                    {
                        dvid.Append("'60wmc',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_60wmc_TB.RepeatColumns = PAGE_COLS;
                        wmcPageData(dba, 0);
                    }
                    break;
                case "iNetHelper_90wmi":
                    {
                        dvid.Append("'90wmi',");
                        dvnm.Append("'").Append(row[ComnCons.C2010004].ToString()).Append("', ");
                        Net_Amonsoft_NetHelper_90wmi_TB.RepeatColumns = PAGE_COLS;
                        wmiPageData(dba, 0);
                    }
                    break;
                default:
                    break;
            }
        }
        dvid.Append("'99def');");
        dvnm.Append("'99def');");
        lt_Script.Text = "<script type=\"text/javascript\">" + dvid + dvnm + "</script>";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_10bms_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_10bms_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        bmsPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_10bms_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_10bms_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        bmsPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_20rss_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_20rss_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        rssPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_20rss_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_20rss_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        rssPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_30wse_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_30wse_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wsePageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_30wse_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_30wse_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wsePageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_31ssl_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_31ssl_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        sslPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_31ssl_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_31ssl_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        sslPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 地图：上一面按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_32map_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_32map_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        mapPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 地图：下一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_32map_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_32map_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        mapPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 日历上一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_41dts_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_41dts_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmiPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 日历下一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_41dts_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_41dts_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmiPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 时间上一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_40cal_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_40cal_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmiPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 时间下一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_40cal_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_40cal_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmiPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 翻译上一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_50wlt_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_50wlt_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wltPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 翻译下一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_50wlt_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_50wlt_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wltPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 邮件上一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_60wmc_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_60wmc_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmcPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 邮件下一页按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_60wmc_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_60wmc_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmcPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_90wmi_LP_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_90wmi_HC.Value) - 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmiPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Net_Amonsoft_NetHelper_90wmi_LN_Click(object sender, EventArgs e)
    {
        int pageIndx;
        try
        {
            pageIndx = int.Parse(Net_Amonsoft_NetHelper_90wmi_HC.Value) + 1;
        }
        catch (Exception)
        {
            pageIndx = 0;
        }

        wmiPageData(new DBAccess(), pageIndx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="kindHash"></param>
    /// <param name="pageIndx"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    private static PagedDataSource PageData(DBAccess dba, String kindHash, int pageIndx, int pageSize)
    {
        dba.reset();
        dba.addTable(WrpCons.W2019100);
        dba.addColumn(WrpCons.W2019104);
        dba.addColumn(WrpCons.W2019102);
        dba.addColumn(WrpCons.W2019105);
        dba.addColumn(WrpCons.W2019106);
        dba.addColumn(WrpCons.W2019107);
        dba.addColumn(WrpCons.W2019109);
        dba.addColumn(WrpCons.W201910A);
        dba.addColumn(WrpCons.W201910B);
        dba.addWhere(WrpCons.W2019104, kindHash);
        dba.addSort(WrpCons.W2019101, false);

        PagedDataSource pageData = new PagedDataSource();
        pageData.DataSource = dba.executeSelect().DefaultView;
        pageData.AllowPaging = true;
        pageData.PageSize = pageSize;
        pageData.CurrentPageIndex = pageIndx;
        return pageData;
    }

    /// <summary>
    /// 网摘
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void bmsPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_10bms", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_10bms_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_10bms_TB.DataBind();

        Net_Amonsoft_NetHelper_10bms_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_10bms_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_10bms_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_10bms_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 阅读
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void rssPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_20rss", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_20rss_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_20rss_TB.DataBind();

        Net_Amonsoft_NetHelper_20rss_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_20rss_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_20rss_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_20rss_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void wsePageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_30wse", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_30wse_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_30wse_TB.DataBind();

        Net_Amonsoft_NetHelper_30wse_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_30wse_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_30wse_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_30wse_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 收录
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void sslPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_31ssl", pageIndx, PAGE_ROWS);

        Net_Amonsoft_NetHelper_31ssl_RP.DataSource = pds;
        Net_Amonsoft_NetHelper_31ssl_RP.DataBind();

        Net_Amonsoft_NetHelper_31ssl_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_31ssl_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_31ssl_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_31ssl_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 地图
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void mapPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_32map", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_32map_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_32map_TB.DataBind();

        Net_Amonsoft_NetHelper_32map_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_32map_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_32map_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_32map_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 翻译
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void wltPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_50wlt", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_50wlt_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_50wlt_TB.DataBind();

        Net_Amonsoft_NetHelper_50wlt_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_50wlt_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_50wlt_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_50wlt_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 邮件
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void wmcPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_60wmc", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_60wmc_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_60wmc_TB.DataBind();

        Net_Amonsoft_NetHelper_60wmc_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_60wmc_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_60wmc_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_60wmc_LT.Text = pageIndx + "/" + pds.PageCount;
    }

    /// <summary>
    /// 关于
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="pageIndx"></param>
    private void wmiPageData(DBAccess dba, int pageIndx)
    {
        PagedDataSource pds = PageData(dba, "iNetHelper_90wmi", pageIndx, PAGE_COLS * PAGE_ROWS);

        Net_Amonsoft_NetHelper_90wmi_TB.DataSource = pds;
        Net_Amonsoft_NetHelper_90wmi_TB.DataBind();

        Net_Amonsoft_NetHelper_90wmi_HC.Value = "" + pageIndx++;
        Net_Amonsoft_NetHelper_90wmi_LP.Enabled = (pageIndx != 1);
        Net_Amonsoft_NetHelper_90wmi_LN.Enabled = (pds.PageCount != pageIndx);
        Net_Amonsoft_NetHelper_90wmi_LT.Text = pageIndx + "/" + pds.PageCount;
    }
}
