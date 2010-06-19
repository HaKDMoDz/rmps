using System;
using System.Web.UI;

using cons.io.db.prp;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 类别删除
/// </summary>
public partial class link_link0204 : Page
{
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "删除类别";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0204";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 5;

        if (IsPostBack)
        {
            return;
        }

        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 16))
        {
            Response.Redirect("index.aspx");
            return;
        }

        hd_P3070A05.Value = sid;
    }

    /// <summary>
    /// 删除链接
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Delete_Click(object sender, EventArgs e)
    {
        // 删除链接
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010105, hd_P3070A05.Value);
        dba.executeDelete();

        Wrps.ShowMesg(Master, "链接数据删除成功！");
    }
}