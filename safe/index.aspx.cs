using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using me.amon.db;
using me.amon.util;

public partial class cipher_Index : System.Web.UI.Page
{
    #region 全局常量
    private int imgSize = 16;
    #endregion

    #region 页面加载
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        CbMc.Items.Add(new ListItem("请选择", "0"));
        CbMc.Items.Add(new ListItem("消息摘要", "digest"));
        CbMc.Items.Add(new ListItem("数据混淆", "confuse"));
        CbMc.Items.Add(new ListItem("私钥加密", "private"));
        CbMc.Items.Add(new ListItem("公钥加密", "public"));
        CbMc.Items.Add(new ListItem("数字签名", "digital"));

        Match match = Regex.Match(Request.RawUrl, "/index\\.aspx\\?c\\w+$");
        if (match.Success)
        {
            LoadData(match.Value.Substring("/index.aspx?c".Length));
        }
        else
        {
            HdMd.Value = "0";
            BtOp.Text = "生成(G)";
            BtOp.AccessKey = "G";
            Session["charKey"] = "";
        }
    }

    private void LoadData(string code)
    {
        DBAccess dba = new DBAccess();
        dba.addTable("cipher_text");
        dba.addWhere("code", code);
        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            return;
        }
        DataRow dr = dt.Rows[0];

        Session["category"] = dr["cat"];
        Session["function"] = dr["fun"];
        Session["keySize"] = dr["keysize"];
        Session["charKey"] = dr["charset"];
        Session["salt"] = me.amon.Safe.Hex2Bytes("" + dr["salt"]);
        Session["iv"] = me.amon.Safe.Hex2Bytes("" + dr["iv"]);
        TaSt.Text = "" + dr["text"];

        HdMd.Value = "1";
        BtOp.Text = "返回(H)";
        BtOp.AccessKey = "H";
        TaSt.ReadOnly = true;
        DvMo.Visible = false;
    }
    #endregion
}
