using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.soap.P3A10000;
using rmp.wrp;

/// <summary>
/// 节目预告
/// </summary>
public partial class iask_iask13A1 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "节目预告";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask13A1";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask13A1.aspx";
        guidItem.V1 = "节目预告";
        guidItem.V2 = "节目预告";

        if (IsPostBack)
        {
            return;
        }

        cb_AreaList.Attributes.Add("onchange", "return readArea();");
        cb_StatList.Attributes.Add("onchange", "return readStat();");
        cb_ChnlList.Attributes.Add("onchange", "return readChnl();");

        tf_CurrDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        readArea();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_AreaList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String area = cb_AreaList.SelectedValue;
        if (area == null || area.Trim() == "")
        {
            Wrps.ShowMesg(Master, "请选择您要查看的电台所在省市或者类别！");
            return;
        }

        try
        {
            ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
            DataSet ds = soap.getTVstationDataSet(Int32.Parse(area));
            cb_StatList.DataSource = ds;
            cb_StatList.DataTextField = "tvStationName";
            cb_StatList.DataValueField = "tvStationID";
            cb_StatList.DataBind();
            cb_StatList.Items.Insert(0, new ListItem("请选择", ""));

            cb_ChnlList.Items.Clear();
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "找不到您所选择的省市或者类别的电视台信息，请重新选择！");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_StatList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String stat = cb_StatList.SelectedValue;
        if (stat == null || stat.Trim() == "")
        {
            Wrps.ShowMesg(Master, "请选择您要查看的电台！");
            return;
        }

        try
        {
            ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
            DataSet ds = soap.getTVchannelDataSet(Int32.Parse(stat));
            cb_ChnlList.DataSource = ds;
            cb_ChnlList.DataTextField = "tvChannel";
            cb_ChnlList.DataValueField = "tvChannelID";
            cb_ChnlList.DataBind();
            cb_ChnlList.Items.Insert(0, new ListItem("请选择", ""));
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "找不到您所选择的电台信息，请重新选择！");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_ChnlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String date = tf_CurrDate.Text ?? "";
        String chnl = cb_ChnlList.SelectedValue;
        if (string.IsNullOrEmpty(chnl))
        {
            Wrps.ShowMesg(Master, "请选择您要查看的频道！");
            return;
        }

        try
        {
            ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
            DataSet ds = soap.getTVprogramDateSet(Int32.Parse(chnl), date, "");
            rp_ProgList.DataSource = ds;
            rp_ProgList.DataBind();
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "找不到您所选择的频道信息，请重新选择！");
        }
    }

    /// <summary>
    /// 读取地区信息
    /// </summary>
    private void readArea()
    {
        ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
        DataSet ds = soap.getAreaDataSet();
        cb_AreaList.DataSource = ds;
        cb_AreaList.DataTextField = "Area";
        cb_AreaList.DataValueField = "areaID";
        cb_AreaList.DataBind();
        cb_AreaList.Items.Insert(0, new ListItem("请选择", ""));
    }

    /// <summary>
    /// 读取电台信息
    /// </summary>
    public string readStation(string area)
    {
        ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
        DataSet ds = soap.getTVstationDataSet(Int32.Parse(area));
        if (ds == null || ds.Tables.Count < 1)
        {
            return "";
        }
        DataTable dt = ds.Tables[0];
        StringBuilder sb = new StringBuilder();
        foreach (DataRow row in dt.Rows)
        {
            sb.Append(row["tvStationName"] + "," + row["tvStationID"]).Append(';');
        }
        return sb.ToString();
    }

    /// <summary>
    /// 读取频道信息
    /// </summary>
    public string readChannel(string stat)
    {
        ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
        DataSet ds = soap.getTVchannelDataSet(Int32.Parse(stat));
        if (ds == null || ds.Tables.Count < 1)
        {
            return "";
        }
        DataTable dt = ds.Tables[0];
        StringBuilder sb = new StringBuilder();
        foreach (DataRow row in dt.Rows)
        {
            sb.Append(row["tvChannel"] + "," + row["tvChannelID"]).Append(';');
        }
        return sb.ToString();
    }

    /// <summary>
    /// 读取节目信息
    /// </summary>
    public string readProgram(string chnl, string date)
    {
        ChinaTVprogramWebService soap = new ChinaTVprogramWebService();
        DataSet ds = soap.getTVprogramDateSet(Int32.Parse(chnl), date, "");
        if (ds == null || ds.Tables.Count < 1)
        {
            return "";
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("<table width=\"90%\" class=\"TB_DataList_TL\" border=\"0\" cellpadding=\"2\" cellspacing=\"0\">");
        sb.Append("<tr>");
        sb.Append("<td class=\"TD_DataHead_TL_L\" align=\"center\" style=\"width: 15%;\">播出时间</td>");
        sb.Append("<td class=\"TD_DataHead_TL_L\" align=\"center\" style=\"width: 35%;\">节目信息</td>");
        sb.Append("<td class=\"TD_DataHead_TL_L\" align=\"center\" style=\"width: 50%;\">电台信息</td>");
        sb.Append("</tr>");

        DataTable dt = ds.Tables[0];
        foreach (DataRow row in dt.Rows)
        {
            sb.Append("<tr>");
            sb.Append("<td class=\"TD_DataItem_TL_L\" align=\"center\" style=\"width: 15%;\">" + row["playTime"] + "</td>");
            sb.Append("<td class=\"TD_DataItem_TL_L\" align=\"center\" style=\"width: 35%;\">" + row["tvProgram"] + "</td>");
            sb.Append("<td class=\"TD_DataItem_TL_L\" align=\"center\" style=\"width: 50%;\">" + row["tvStationInfo"] + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        return sb.ToString();
    }
}