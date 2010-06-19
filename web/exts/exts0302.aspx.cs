using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

public partial class exts_exts0302 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "文件信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0302";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0301.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0300.aspx";
        guidItem.V1 = "文件信息";
        guidItem.V2 = "文件信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0302.aspx";
        guidItem.V1 = "数据预览";
        guidItem.V2 = "数据预览";

        if (IsPostBack)
        {
            return;
        }

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt);

        ai_P3010304.InitData();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sid"></param>
    private void LoadData(String sid, String opt)
    {
        if (!StringUtil.isValidateHash(sid) || !StringUtil.isValidateLong(opt))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010300);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010302, sid);
        dba.addWhere(cons.io.db.prp.PrpCons.P301030F, opt, false);

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count < 1)
        {
            return;
        }
        DataRow row = dt.Rows[0];
        hl_P3010303.NavigateUrl = "~/exts/exts0202.aspx?sid=" + row[cons.io.db.prp.PrpCons.P3010303];
        ai_P3010304.DstIconHash = "" + row[cons.io.db.prp.PrpCons.P3010304];
        lb_P3010305.Text = "" + row[cons.io.db.prp.PrpCons.P3010305];
        lb_P3010306.Text = "" + row[cons.io.db.prp.PrpCons.P3010306];
        lb_P3010307.Text = "" + row[cons.io.db.prp.PrpCons.P3010307];
        lb_P3010308.Text = "" + row[cons.io.db.prp.PrpCons.P3010308];
        lb_P3010309.Text = "" + row[cons.io.db.prp.PrpCons.P3010309];
        lb_P301030A.Text = "" + row[cons.io.db.prp.PrpCons.P301030A];
        lb_P301030C.Text = "" + row[cons.io.db.prp.PrpCons.P301030C];
        dt.Dispose();
    }
}