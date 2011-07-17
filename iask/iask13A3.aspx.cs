using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.soap.P3A30000;
using rmp.wrp;

/// <summary>
/// 天气预报
/// </summary>
public partial class iask_iask13A3 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "天气预报";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask13A3";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask13A3.aspx";
        guidItem.V1 = "天气预报";
        guidItem.V2 = "天气预报";

        if (IsPostBack)
        {
            return;
        }

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getSupportProvince();
        cb_ProvList.Items.Add(new ListItem("请选择", ""));
        for (int i = 0, j = ds.Length; i < j; i += 1)
        {
            cb_ProvList.Items.Add(new ListItem(ds[i], ds[i]));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_ProvList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String p = cb_ProvList.SelectedValue;
        if (p == null || p.Trim() == "")
        {
            return;
        }

        cb_CityList.Items.Clear();

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getSupportCity(p);
        cb_CityList.Items.Add(new ListItem("请选择", ""));
        String t;
        int k;
        for (int i = 0, j = ds.Length; i < j; i += 1)
        {
            t = ds[i];
            k = t.IndexOf('（');
            if (k < 0)
            {
                k = t.IndexOf('(');
            }
            if (k > 0)
            {
                t = t.Substring(0, k).Trim();
            }
            cb_CityList.Items.Add(new ListItem(t, t));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_CityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        String c = cb_CityList.SelectedValue;
        if (c == null || c.Trim() == "")
        {
            return;
        }

        tr_Guid.Visible = true;
        tr_Mini.Visible = true;

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getWeatherbyCityName(c);

        viewMini(ds, 5);
        viewFull(ds);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="pre"></param>
    private void viewMini(String[] ds, int pre)
    {
        String t = "http://www.cma.gov.cn/tqyb/img/city/";
        im_T00.ImageUrl = t + ds[3]; //城市图片名称，
        hl_T00.NavigateUrl = t + ds[3];

        t = ds[pre + 1];
        int k = t.IndexOf(' ');
        lb_T00.Text = "日期：" + t.Substring(0, k);
        lb_T05.Text = ds[pre + 0];
        lb_T06.Text = t.Substring(k + 1);
        lb_T07.Text = "风向风力：" + ds[pre + 2];

        t = "/_images/iask13A3/";
        im_T01.ImageUrl = t + ds[pre + 3];
        im_T02.ImageUrl = t + ds[pre + 4];

        t = ds[11];
        int k1 = 0;
        int k2 = t.IndexOf('。', k1);
        lb_T11.Text = t.Substring(k1, k2 - k1) + "…";
        k1 = t.IndexOf('：', k2) - 4;
        k2 = t.IndexOf('。', k1);
        lb_T12.Text = t.Substring(k1, k2 - k1) + "…";
        k1 = t.IndexOf('：', k2) - 4;
        k2 = t.IndexOf('。', k1);
        lb_T13.Text = t.Substring(k1, k2 - k1) + "…";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    private void viewFull(String[] ds)
    {
        int i = 0;

        //概况
        lb_W00.Text = ds[i++]; //省份，
        lb_W01.Text = ds[i++] + '（' + ds[i++] + '）'; //城市，城市代码，
        string t = "http://www.cma.gov.cn/tqyb/img/city/";
        im_W00.ImageUrl = t + ds[i]; //城市图片名称，
        hl_W00.NavigateUrl = t + ds[i++];
        lb_W02.Text = ds[i++]; //最后更新时间

        //今日
        lb_W05.Text = ds[i++]; //气温，
        lb_W06.Text = ds[i++]; //概况，
        lb_W07.Text = ds[i++]; //风向和风力，
        t = "/_images/iask13A3/b_";
        im_W08.ImageUrl = t + ds[i++]; //天气趋势：起始
        im_W09.ImageUrl = t + ds[i++]; //天气趋势：结束
        lb_W10.Text = ds[i++].Replace("；", "；<br /><br />").Replace(";", "；<br /><br />"); //天气实况，
        String c = ds[i++];
        int k = c.LastIndexOf("：");
        while (k > 0)
        {
            k = c.LastIndexOf("。", k);
            if (k > 0)
            {
                c = c.Insert(k + 1, "<br />");
                k = c.LastIndexOf("：", k);
            }
        }
        lb_W11.Text = c; //天气和生活指数

        //明日
        lb_W12.Text = ds[i++]; //气温，
        lb_W13.Text = ds[i++]; //概况，
        lb_W14.Text = ds[i++]; //风向和风力
        im_W15.ImageUrl = t + ds[i++]; //天气趋势：起始
        im_W16.ImageUrl = t + ds[i++]; //天气趋势：结束

        //后日
        lb_W17.Text = ds[i++]; //气温，
        lb_W18.Text = ds[i++]; //概况，
        lb_W19.Text = ds[i++]; //风向和风力
        im_W20.ImageUrl = t + ds[i++]; //天气趋势：起始
        im_W21.ImageUrl = t + ds[i++]; //天气趋势：结束

        lt_W22.Text = ds[i]; //介绍
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_24_Click(object sender, EventArgs e)
    {
        String c = cb_CityList.SelectedValue;
        if (c == null || c.Trim() == "")
        {
            return;
        }

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getWeatherbyCityName(c);

        viewMini(ds, 5);
        viewFull(ds);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_48_Click(object sender, EventArgs e)
    {
        String c = cb_CityList.SelectedValue;
        if (c == null || c.Trim() == "")
        {
            return;
        }

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getWeatherbyCityName(c);

        viewMini(ds, 12);
        viewFull(ds);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_72_Click(object sender, EventArgs e)
    {
        String c = cb_CityList.SelectedValue;
        if (c == null || c.Trim() == "")
        {
            return;
        }

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getWeatherbyCityName(c);

        viewMini(ds, 17);
        viewFull(ds);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_Mini_Click(object sender, EventArgs e)
    {
        tr_Mini.Visible = true;
        tr_Full.Visible = false;
        lb_Mini.Visible = false;
        lb_Full.Visible = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_Full_Click(object sender, EventArgs e)
    {
        tr_Mini.Visible = false;
        tr_Full.Visible = true;
        lb_Mini.Visible = true;
        lb_Full.Visible = false;
    }
}