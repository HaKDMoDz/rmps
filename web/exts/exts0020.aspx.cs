using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

public partial class exts_exts0020 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ====================================================================
        // 用户身份认证
        // ====================================================================
        if (UserInfo.Current(Session).UserRank <= cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0020";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0020.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0020.aspx";
        guidItem.V1 = "快捷模式";
        guidItem.V2 = "快捷模式";

        if (IsPostBack)
        {
            return;
        }

        String sid = Request[cons.wrp.WrpCons.SID];
        if (StringUtil.isValidate(sid))
        {
            hd_SoftHash.Value = sid;
            sid = '?' + cons.wrp.WrpCons.SID + '=' + sid;
        }
        hl_GModel.NavigateUrl = "~/exts/exts0010.aspx" + sid;
    }

    /// <summary>
    /// 下一步按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        // 保存Bean对象到Session
        Bean extsBase = new Bean();
        Session.Add(cons.wrp.WrpCons.P3010000_BEAN, extsBase);

        String sid = hd_SoftHash.Value;

        // 判断Session的有效性
        K1V2 extsItem = Exts.readQuery(Session);
        if (extsItem == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // 已有数据查询
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010000);
        dba.addColumn("*");
        dba.addWhere(PrpCons.P3010003, extsItem.K);
        dba.addWhere(PrpCons.P3010006, sid);

        // 查询结果判断
        DataTable dv = dba.executeSelect();
        if (dv != null && dv.Rows.Count > 0)
        {
            DataRow row = dv.Rows[0];
            extsBase.P3010002 = Int32.Parse(row[PrpCons.P3010002].ToString()); // 处理字长
            extsBase.P3010003 = row[PrpCons.P3010003].ToString(); // 后缀索引
            extsBase.P3010004 = row[PrpCons.P3010004].ToString(); // 国别信息
            extsBase.P3010005 = row[PrpCons.P3010005].ToString(); // 公司信息
            extsBase.P3010006 = row[PrpCons.P3010006].ToString(); // 软件信息
            extsBase.P3010007 = row[PrpCons.P3010007].ToString(); // 文件信息
            extsBase.P3010008 = row[PrpCons.P3010008].ToString(); // 文档格式
            extsBase.P3010009 = row[PrpCons.P3010009].ToString();
            extsBase.P301000A = row[PrpCons.P301000A].ToString();
            extsBase.P301000B = row[PrpCons.P301000B].ToString();
            extsBase.P301000C = row[PrpCons.P301000C].ToString();
            extsBase.P301000D = Int32.Parse(row[PrpCons.P301000D].ToString());
            extsBase.P301000E = row[PrpCons.P301000E].ToString();
            extsBase.P301000F = row[PrpCons.P301000F].ToString();
            extsBase.P3010010 = row[PrpCons.P3010010].ToString();
            extsBase.P3010013 = '.' + row[PrpCons.P3010013].ToString();

            // 设置更新状态标记
            extsBase.SoftHash = extsBase.P3010006;
            extsBase.IsUpdate = true;
        }

        Response.Redirect("~/exts/exts0021.aspx");
    }
}