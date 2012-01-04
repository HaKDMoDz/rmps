using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using me.amon.db;

public partial class cipher_cat : System.Web.UI.Page
{
    private int imgSize = 16;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        IbCa.ImageUrl = "~/img/add" + imgSize + ".png";
        IbCa.Width = imgSize;
        IbCa.Height = imgSize;

        IbCs.ImageUrl = "~/img/save" + imgSize + ".png";
        IbCs.Width = imgSize;
        IbCs.Height = imgSize;

        for (int i = 8; i > 0; i -= 1)
        {
            CbCs.Items.Add(new ListItem(i + "位", "" + i));
        }

        LoadData();
    }

    private void LoadData()
    {
        CbCl.Items.Add(new ListItem("请选择", "0"));
        DBAccess dba = new DBAccess();
        dba.addTable("cipher_code");
        dba.addSort("name");
        DataTable dt = dba.executeSelect();
        foreach (DataRow dr in dt.Rows)
        {
            CbCl.Items.Add(new ListItem("" + dr["name"], "" + dr["id"]));
        }
    }

    #region 用户事件
    /// <summary>
    /// 追加码表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void IbCa_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Session["charKey"] = "";
        CbCl.SelectedIndex = 0;
        TbCt.Text = "";
        TaCc.Text = "";
    }

    /// <summary>
    /// 更新码表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void IbCs_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        string title = TbCt.Text.Trim();
        if (string.IsNullOrEmpty(title))
        {
            LbErr2.Text = "请输入字符集名称！";
            return;
        }

        string text = TaCc.Text;
        if (text.Length < 1)
        {
            LbErr2.Text = "请输入一个或多个字符！";
            return;
        }

        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char c in text.ToCharArray())
        {
            if (dict.ContainsKey(c))
            {
                LbErr2.Text = "您输出了一个或多个重复的字符！";
                return;
            }
            dict[c] = 1;
        }

        string id = Session["charKey"] as string;
        DBAccess dba = new DBAccess();
        dba.addTable("cipher_code");
        dba.addParam("name", title);
        dba.addParam("size", CbCs.SelectedValue);
        dba.addParam("text", text);
        if (Regex.IsMatch(id, "^[\\dA-F]{16}$"))
        {
            dba.addWhere("id", id);
            dba.executeUpdate();
            LbErr2.Text = "数据更新成功！";
        }
        else
        {
            id = Convert.ToString(DateTime.Now.ToBinary(), 16).PadLeft(16, '0');
            Session["charKey"] = id;
            dba.addParam("id", id);
            dba.addParam("create_time", "now()", false);
            dba.executeInsert();
            LbErr2.Text = "数据添加成功！";

            CbCl.Items.Add(new ListItem(title, id));
            TbCt.Text = "";
            TaCc.Text = "";
        }
    }

    /// <summary>
    /// 选择码表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CbCl_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem item = CbCl.SelectedItem;
        if (item == null)
        {
            return;
        }
        string id = (item.Value ?? "").Trim().ToUpper();
        if (!Regex.IsMatch(id, "^[\\dA-F]{16}$"))
        {
            return;
        }
        DBAccess dba = new DBAccess();
        dba.addTable("cipher_code");
        dba.addColumn("name");
        dba.addColumn("size");
        dba.addColumn("text");
        dba.addWhere("id", id);
        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            return;
        }
        DataRow dr = dt.Rows[0];
        TbCt.Text = "" + dr["name"];
        CbCs.SelectedValue = "" + dr["size"];
        TaCc.Text = "" + dr["text"];

        Session["charKey"] = id;
        Session["charSet"] = TaCc.Text;
    }
    #endregion
}
