using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;

using cons;
using cons.io.db.comn;
using cons.io.db.prp;
using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class date_date9999 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/date/index.aspx");
        }

        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.SCRIPTID] = "date9999";

        List<K1V2> guidList = Wrps.GuidDate(Session);
        K1V2 guidItem = guidList[2];
        guidItem.K = "date9999.aspx?sid=" + sid;
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        if (IsPostBack)
        {
            return;
        }

        // 外界参数读取
        if (!StringUtil.isValidate(sid, 16))
        {
            return;
        }

        // 已有数据读取
        LoadData(sid);
    }

    protected void bt_Update_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3100100);
        dba.addParam(PrpCons.P3100104, cb_P3100104.SelectedValue);// 类型
        dba.addParam(PrpCons.P3100105, cb_P3100105.SelectedValue);// 类别
        dba.addParam(PrpCons.P3100106, hd_P3100106.Value);// 文件
        dba.addParam(PrpCons.P3100107, WrpUtil.text2Db(tf_P3100107.Text));// 名称
        dba.addParam(PrpCons.P3100108, WrpUtil.text2Db(ta_P3100108.Text));// 摘要
        dba.addParam(PrpCons.P3100109, EnvCons.SQL_NOW, false);
        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(PrpCons.P3100103, hd_P3100103.Value);
            dba.executeUpdate();

            if (cb_P3100104.SelectedValue != hd_P3100104.Value)
            {
                String path = Server.MapPath(EnvCons.DIR_DAT + "date/");
                if (File.Exists(path + hd_P3100106.Value + '.' + hd_P3100104.Value))
                {
                    File.Move(path + hd_P3100106.Value + '.' + hd_P3100104.Value, path + hd_P3100106.Value + '.' + cb_P3100104.SelectedValue);
                }
            }

            Wrps.ShowMesg(Master, "数据更新成功！");
        }
        else
        {
            dba.addParam(PrpCons.P3100101, 0);
            dba.addParam(PrpCons.P3100102, 0);
            dba.addParam(PrpCons.P3100103, HashUtil.getCurrTimeHex(false));
            dba.addParam(PrpCons.P310010A, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            Wrps.ShowMesg(Master, "数据新增成功！");
        }

        hd_P3100106.Value = "";
        tf_P3100107.Text = "";
        ta_P3100108.Text = "";
    }

    protected void cb_P3100104_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadKind(cb_P3100104.SelectedValue);
        bt_P3100106.Visible = (cb_P3100104.SelectedIndex != 0 || hd_IsUpdate.Value == "1");
    }

    /// <summary>
    /// 数据初始化
    /// </summary>
    /// <param name="sid"></param>
    private void LoadData(String sid)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3100100);
        dba.addWhere(PrpCons.P3100103, sid);

        DataTable dv = dba.executeSelect();
        if (dv == null || dv.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dv.Rows[0];
        String v = row[PrpCons.P3100104].ToString().ToUpper();
        hd_P3100104.Value = v;
        cb_P3100104.SelectedValue = v;
        LoadKind(v);
        cb_P3100105.SelectedValue = row[PrpCons.P3100105].ToString();
        hd_P3100103.Value = sid;
        hd_P3100106.Value = row[PrpCons.P3100106].ToString();
        hl_P3100106.NavigateUrl = "~/date/date0002.aspx?sid=" + sid;
        hl_P3100106.Visible = true;
        bt_P3100106.Visible = true;
        String name = row[PrpCons.P3100107].ToString();
        tf_P3100107.Text = name;
        ta_P3100108.Text = row[PrpCons.P3100108].ToString();

        hd_IsUpdate.Value = "1";
    }

    /// <summary>
    /// 类别初始化
    /// </summary>
    /// <param name="sid"></param>
    private void LoadKind(String sid)
    {
        switch (sid)
        {
            case "D":
                sid = "sctffsfxfxxyrxta";
                break;
            case "T":
                sid = "sctffsfxfxxyrxtb";
                break;
            default:
                sid = "sctffsfxfxxyrxtc";
                break;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C2010100);
        dba.addColumn(ComnCons.C2010103);
        dba.addColumn(ComnCons.C2010105);
        dba.addColumn(ComnCons.C2010106);
        dba.addWhere(ComnCons.C2010104, sid);
        dba.addSort(ComnCons.C2010101, true);
        cb_P3100105.DataTextField = ComnCons.C2010105;
        cb_P3100105.DataValueField = ComnCons.C2010103;
        cb_P3100105.DataSource = dba.executeSelect();
        cb_P3100105.DataBind();
    }

    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P3100106_Click(object sender, EventArgs e)
    {
        String path = Server.MapPath(EnvCons.DIR_DAT + "date/");

        if (hd_IsUpdate.Value == "1")
        {
            if (cb_P3100104.SelectedValue != hd_P3100104.Value)
            {
                File.Delete(path + hd_P3100106.Value + '.' + hd_P3100104.Value);
            }
        }

        if (!StringUtil.isValidate(hd_P3100106.Value, 16))
        {
            hd_P3100106.Value = HashUtil.getCurrTimeHex(false);
        }

        // 文件保存
        if (fu_P3100106.FileName != "" && fu_P3100106.FileContent.Length > 0)
        {
            fu_P3100106.SaveAs(path + hd_P3100106.Value + "." + cb_P3100104.SelectedValue);
        }

        Wrps.ShowMesg(Master, "文件上传成功！");
    }
}
