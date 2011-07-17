using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.soap.P3A10000;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 节目预告
/// </summary>
public partial class tool_tool13A1 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "节目预告";
        Session[cons.wrp.WrpCons.SCRIPTID] = "13A1";

        if (IsPostBack)
        {
            return;
        }

        DateTime now = DateTime.Now;
        tf_CurrDate.Text = now.Year + "-" + StringUtil.lpad(now.Month + "", 2, "0") + "-" + now.Day;
        readArea();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_AreaList_SelectedIndexChanged(object sender, EventArgs e)
    {
        readStation();
        cb_ChnlList.Items.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_StatList_SelectedIndexChanged(object sender, EventArgs e)
    {
        readChannel();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_ChnlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        readProgram();
    }

    /// <summary>
    /// 
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
    /// 
    /// </summary>
    private void readStation()
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
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "找不到您所选择的省市或者类别的电视台信息，请重新选择！");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void readChannel()
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
    private void readProgram()
    {
        String date = tf_CurrDate.Text ?? "";
        String chnl = cb_ChnlList.SelectedValue;
        if (chnl == null || chnl.Trim() == "")
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
}