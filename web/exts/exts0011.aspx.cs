using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

/// <summary>
/// 后缀名称
/// </summary>
public partial class exts_exts0011 : Page
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
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0011";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0011.aspx";
        guidItem.V1 = "后缀名称";
        guidItem.V2 = "后缀名称";

        if (IsPostBack)
        {
            return;
        }

        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // 数据更新时，不允许用户修改后缀名称
        if (extsBase.IsUpdate)
        {
            tf_P3010013.Text = extsBase.P3010013;
            tf_P3010013.Enabled = false;
        }
    }

    /// <summary>
    /// 下一步事件处理
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

        if (!extsBase.IsUpdate)
        {
            extsBase.P3010013 = tf_P3010013.Text;
            extsBase.P3010003 = HashUtil.digest(tf_P3010013.Text.Substring(1), false);
        }
        Response.Redirect("~/exts/exts0012.aspx");
    }
}