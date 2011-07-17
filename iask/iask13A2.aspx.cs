using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.soap.P3A20000;
using rmp.wrp;

/// <summary>
/// 邮政编码
/// </summary>
public partial class iask_iask13A2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "邮政编码";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask13A2";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask13A2.aspx";
        guidItem.V1 = "邮政编码";
        guidItem.V2 = "邮政编码";

        if (IsPostBack)
        {
            return;
        }

        ChinaZipSearchWebService soap = new ChinaZipSearchWebService();
        String[] ds = soap.getSupportProvince();
        cb_Province.Items.Add(new ListItem("请选择", ""));
        for (int i = 0, j = ds.Length; i < j; i += 1)
        {
            cb_Province.Items.Add(new ListItem(ds[i], ds[i]));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Zip2City_Click(object sender, EventArgs e)
    {
        zip2City();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tf_Zip2City_TextChanged(object sender, EventArgs e)
    {
        zip2City();
    }

    /// <summary>
    /// 
    /// </summary>
    private void zip2City()
    {
        ChinaZipSearchWebService soap = new ChinaZipSearchWebService();
        DataSet ds = soap.getAddressByZipCode(tf_Zip2City.Text, "");
        rp_Zip5City.DataSource = ds;
        rp_Zip5City.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cb_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        String p = cb_Province.SelectedValue;
        if (string.IsNullOrEmpty(p))
        {
            return;
        }

        cb_City.Items.Clear();

        ChinaZipSearchWebService soap = new ChinaZipSearchWebService();
        String[] ds = soap.getSupportCity(p);
        cb_City.Items.Add(new ListItem("请选择", ""));
        for (int i = 0, j = ds.Length; i < j; i += 1)
        {
            cb_City.Items.Add(new ListItem(ds[i], ds[i]));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tf_City2Zip_TextChanged(object sender, EventArgs e)
    {
        city2Zip();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_City2Zip_Click(object sender, EventArgs e)
    {
        city2Zip();
    }

    /// <summary>
    /// 
    /// </summary>
    private void city2Zip()
    {
        String p = cb_Province.SelectedValue;
        if (string.IsNullOrEmpty(p))
        {
            Wrps.ShowMesg(Master, "请选择 “省份/直辖市”！");
            return;
        }

        String c = cb_City.SelectedValue;
        if (string.IsNullOrEmpty(c))
        {
            Wrps.ShowMesg(Master, "请选择 “城市/地区”！");
            return;
        }
        int d = c.IndexOf('（');
        if (d < 0)
        {
            d = c.IndexOf('(');
        }
        if (d > 0)
        {
            c = c.Substring(0, d).Trim();
        }

        String a = tf_City2Zip.Text.Trim();

        ChinaZipSearchWebService soap = new ChinaZipSearchWebService();
        DataSet ds = soap.getZipCodeByAddress(p, c, a, "");
        rp_Zip5City.DataSource = ds;
        rp_Zip5City.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rb_Zip2City_CheckedChanged(object sender, EventArgs e)
    {
        z2c.Visible = true;
        c2z.Visible = false;
        rp_Zip5City.DataSource = null;
        rp_Zip5City.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rb_City2Zip_CheckedChanged(object sender, EventArgs e)
    {
        z2c.Visible = false;
        c2z.Visible = true;
        rp_Zip5City.DataSource = null;
        rp_Zip5City.DataBind();
    }
}