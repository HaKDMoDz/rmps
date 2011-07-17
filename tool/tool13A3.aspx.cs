using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.soap.P3A30000;
using rmp.util;

/// <summary>
/// 天气预报
/// </summary>
public partial class tool_tool13A3 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "天气预报";
        Session[cons.wrp.WrpCons.SCRIPTID] = "13A3";

        if (IsPostBack)
        {
            return;
        }

        tr_Mini.Visible = false;
        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getSupportProvince();
        cb_ProvList.Items.Add(new ListItem("请选择", ""));
        for (int i = 0, j = ds.Length; i < j; i += 1)
        {
            cb_ProvList.Items.Add(new ListItem(ds[i], ds[i]));
        }

        // 地址栏参数读取
        string sid = Request[WrpCons.SID];
        if (StringUtil.isValidate(sid))
        {
            ds = soap.getWeatherbyCityName(sid);
            tr_Mini.Visible = true;
            viewMini(ds, 5);
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

        WeatherWebService soap = new WeatherWebService();
        String[] ds = soap.getWeatherbyCityName(c);

        tr_Mini.Visible = true;
        viewMini(ds, 5);
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
}