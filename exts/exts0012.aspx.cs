using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;
using rmp.wrp.exts;

using Util = rmp.comn.Util;

/// <summary>
/// 国别信息
/// </summary>
public partial class exts_exts0012 : Page
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
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0012";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0012.aspx";
        guidItem.V1 = "国别信息";
        guidItem.V2 = "国别信息";

        if (IsPostBack)
        {
            return;
        }

        // 设置默认显示
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        Util.InitStatData(cb_P3010004, cons.SysCons.UI_LANGHASH, true);
        cb_P3010004.SelectedValue = extsBase.P3010004;
        bt_SaveData.Enabled = extsBase.IsUpdate;
    }

    /// <summary>
    /// 下一步按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        extsBase.P3010004 = cb_P3010004.SelectedValue;
        Response.Redirect("~/exts/exts0013.aspx");
    }

    /// <summary>
    /// 保存数据按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        Exts.SaveBase(extsBase);
        Exts.needQuery(Session, true);
        Response.Redirect("~/exts/exts0001.aspx");
    }
}