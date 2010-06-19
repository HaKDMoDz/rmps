using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Web.UI.WebControls;
using cons;
using cons.wrp;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 数据编辑
/// </summary>
public partial class card_card9998 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据编辑";
        Session[cons.wrp.WrpCons.SCRIPTID] = "card9998";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidCard(Session).Count;

        if (IsPostBack)
        {
            return;
        }

        LoadData();
    }

    private void LoadData()
    {
        // 系统字体加载
        foreach (FontFamily f in new InstalledFontCollection().Families)
        {
            cb_W204010C.Items.Add(new ListItem(f.Name, f.Name));
        }

        string sid = Request[WrpCons.SID];
        if (!StringUtil.isValidateHash(sid))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2040103, sid);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2040104, "0");

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        cb_W2040102.SelectedValue = row[cons.io.db.wrp.WrpCons.W2040102] + "";
        hd_W2040103.Value = row[cons.io.db.wrp.WrpCons.W2040103] + "";
        tf_W2040106.Text = row[cons.io.db.wrp.WrpCons.W2040106] + "";
        tf_W2040107.Text = row[cons.io.db.wrp.WrpCons.W2040107] + "";
        tf_W2040108.Text = row[cons.io.db.wrp.WrpCons.W2040108] + "";
        tf_W2040109.Text = row[cons.io.db.wrp.WrpCons.W2040109] + "";
        tf_W204010A.Text = row[cons.io.db.wrp.WrpCons.W204010A] + "";
        tf_W204010B.Text = row[cons.io.db.wrp.WrpCons.W204010B] + "";
        cb_W204010C.SelectedValue = row[cons.io.db.wrp.WrpCons.W204010C] + "";
        tf_W204010D.Text = row[cons.io.db.wrp.WrpCons.W204010D] + "";
        tf_W204010E.Text = row[cons.io.db.wrp.WrpCons.W204010E] + "";
        int style = (int)row[cons.io.db.wrp.WrpCons.W204010F];
        ck_Bold.Checked = (style & (int)FontStyle.Bold) != 0;
        ck_Itac.Checked = (style & (int)FontStyle.Italic) != 0;
        ck_Strk.Checked = (style & (int)FontStyle.Strikeout) != 0;
        ck_Line.Checked = (style & (int)FontStyle.Underline) != 0;
        tf_W2040110.Text = row[cons.io.db.wrp.WrpCons.W2040110] + "";
        tf_W2040111.Text = row[cons.io.db.wrp.WrpCons.W2040111] + "";
        hd_IsUpdate.Value = "1";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2040102, cb_W2040102.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W2040105, "0");
        dba.addParam(cons.io.db.wrp.WrpCons.W2040106, WrpUtil.text2Db(tf_W2040106.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2040107, WrpUtil.text2Db(tf_W2040107.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2040108, WrpUtil.text2Db(tf_W2040108.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2040109, WrpUtil.text2Db(tf_W2040109.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W204010A, WrpUtil.text2Db(tf_W204010A.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W204010B, WrpUtil.text2Db(tf_W204010B.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W204010C, cb_W204010C.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W204010D, WrpUtil.text2Db(tf_W204010D.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W204010E, WrpUtil.text2Db(tf_W204010E.Text));
        FontStyle style = FontStyle.Regular;
        if (ck_Bold.Checked)
        {
            style |= FontStyle.Bold;
        }
        if (ck_Itac.Checked)
        {
            style |= FontStyle.Italic;
        }
        if (ck_Strk.Checked)
        {
            style |= FontStyle.Strikeout;
        }
        if (ck_Line.Checked)
        {
            style |= FontStyle.Underline;
        }
        dba.addParam(cons.io.db.wrp.WrpCons.W204010F, (int)style);
        dba.addParam(cons.io.db.wrp.WrpCons.W2040110, WrpUtil.text2Db(tf_W2040110.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2040111, WrpUtil.text2Db(tf_W2040111.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2040112, "");
        dba.addParam(cons.io.db.wrp.WrpCons.W2040113, EnvCons.SQL_NOW, false);

        // 数据更新
        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.wrp.WrpCons.W2040103, hd_W2040103.Value);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2040104, "0");

            dba.executeUpdate();

            Wrps.ShowMesg(Master, "数据更新成功！");
        }
        // 数据新增
        else
        {
            dba.addParam(cons.io.db.wrp.WrpCons.W2040101, 0);
            dba.addParam(cons.io.db.wrp.WrpCons.W2040103, HashUtil.getCurrTimeHex(false));
            dba.addParam(cons.io.db.wrp.WrpCons.W2040104, "0");
            dba.addParam(cons.io.db.wrp.WrpCons.W2040114, EnvCons.SQL_NOW, false);

            dba.executeInsert();

            Wrps.ShowMesg(Master, "数据新增成功！");

            tf_W2040106.Text = "";
            tf_W2040108.Text = "{0}";
            tf_W2040109.Text = "";
            tf_W204010A.Text = "";
            tf_W204010B.Text = "";
            tf_W204010D.Text = "12";
            tf_W204010E.Text = "#000000";
            ck_Bold.Checked = false;
            ck_Itac.Checked = false;
            ck_Strk.Checked = false;
            ck_Line.Checked = false;
            tf_W2040110.Text = "10";
            tf_W2040111.Text = "10";
        }
    }
}
