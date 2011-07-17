using System;
using cons.io.db.comn;
using rmp.io.db;
using rmp.util;
using cons.io.db.wrp;
using System.Data;

public partial class misc_misc0103 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        LoadCat1();

        string key = Request["key"] ?? "";
        if (!StringUtil.isValidateLong(key) || int.Parse(key) < 1)
        {
            return;
        }
        LoadMisc(key);
    }

    private void LoadMisc(string hash)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(WrpCons.W2060100);
        dba.addWhere(WrpCons.W2060105, hash, false);
        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            return;
        }
        hdHash.Value = dt.Rows[0][WrpCons.W2060105] + "";
        cbCat1List.SelectedValue = dt.Rows[0][WrpCons.W2060106] + "";
        cbCat2List.SelectedValue = dt.Rows[0][WrpCons.W2060107] + "";
        tbHead.Text = dt.Rows[0][WrpCons.W2060108] + "";
        tbBody.Text = dt.Rows[0][WrpCons.W2060109] + "";
    }

    private void LoadCat1()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C2010000);
        dba.addColumn(ComnCons.C2010002);
        dba.addColumn(ComnCons.C2010004);
        dba.addWhere(ComnCons.C2010003, "42060000");
        dba.addSort(ComnCons.C2010001);
        cbCat1List.DataValueField = ComnCons.C2010002;
        cbCat1List.DataTextField = ComnCons.C2010004;
        cbCat1List.DataSource = dba.executeSelect();
        cbCat1List.DataBind();

        cbCat1List.Items.Insert(0, "--请选择--");
    }
    private void LoadCat2(string hash)
    {
        cbCat2List.Items.Clear();
        if (!StringUtil.isValidateHash(hash))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C2010100);
        dba.addColumn(ComnCons.C2010105);
        dba.addColumn(ComnCons.C2010107);
        dba.addWhere(ComnCons.C2010104, "42060000");
        dba.addWhere(ComnCons.C2010106, hash);
        dba.addSort(ComnCons.C2010101);
        cbCat2List.DataValueField = ComnCons.C2010105;
        cbCat2List.DataTextField = ComnCons.C2010107;
        cbCat2List.DataSource = dba.executeSelect();
        cbCat2List.DataBind();
    }
    protected void cbCat1List_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCat2(cbCat1List.SelectedValue);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (!StringUtil.isValidateHash(cbCat1List.SelectedValue))
        {
            lbMesg.Text = "请选择一级类别！";
            return;
        }
        if (!StringUtil.isValidateHash(cbCat2List.SelectedValue))
        {
            lbMesg.Text = "请选择二级类别！";
            return;
        }
        if (string.IsNullOrEmpty(tbBody.Text))
        {
            lbMesg.Text = "请输入内容";
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(WrpCons.W2060100);
        dba.addParam(WrpCons.W2060101, 0);
        dba.addParam(WrpCons.W2060102, 0);
        dba.addParam(WrpCons.W2060103, 0);
        dba.addParam(WrpCons.W2060104, 0);
        dba.addParam(WrpCons.W2060106, cbCat1List.SelectedValue);
        dba.addParam(WrpCons.W2060107, cbCat2List.SelectedValue);
        dba.addParam(WrpCons.W2060108, tbHead.Text);
        dba.addParam(WrpCons.W2060109, tbBody.Text);
        dba.addParam(WrpCons.W206010A, "00000000");
        dba.addParam(WrpCons.W206010B, "NOW()", false);
        if (StringUtil.isValidateLong(hdHash.Value))
        {
            dba.executeUpdate();

            lbMesg.Text = "数据更新成功！";
        }
        else
        {
            dba.addParam(WrpCons.W206010C, "NOW()", false);
            dba.executeInsert();

            lbMesg.Text = "数据新增成功！";

            tbHead.Text = "";
            tbBody.Text = "";
        }
    }
}
