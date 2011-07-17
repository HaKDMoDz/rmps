using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.util;

public partial class exts_exts0102 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "公司信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0102";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0101.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0100.aspx";
        guidItem.V1 = "公司信息";
        guidItem.V2 = "公司信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0102.aspx";
        guidItem.V1 = "数据预览";
        guidItem.V2 = "数据预览";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        //传入参数读取
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        String opt = (Request[cons.wrp.WrpCons.OPT] ?? "").Trim();

        //读取数据
        LoadData(sid, opt);

        ai_P3010104.InitData();
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
        dba.addTable(PrpCons.P3010100);
        dba.addWhere(PrpCons.P3010102, sid);
        dba.addWhere(PrpCons.P301010C, opt, false);
        dba.addLimit(1);

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count < 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        hl_P3010103.NavigateUrl = "" + row[PrpCons.P3010103];
        ai_P3010104.DstIconHash = "" + row[PrpCons.P3010104];
        lb_P3010105.Text = "" + row[PrpCons.P3010105];
        lb_P3010106.Text = "" + row[PrpCons.P3010106];
        hl_P3010107.NavigateUrl = "" + row[PrpCons.P3010107];
        hl_P3010107.ToolTip = "" + row[PrpCons.P3010107];
        hl_P3010107.Text = "" + row[PrpCons.P3010107];
        lb_P3010108.Text = "" + row[PrpCons.P3010108];
        lb_P3010109.Text = "" + row[PrpCons.P3010109];
    }
}