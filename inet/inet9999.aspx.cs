using System;
using System.Web.UI;

using cons;
using cons.wrp;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 元数据删除
/// </summary>
public partial class inet_inet9999 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        // 数据索引
        String sid = WrpUtil.text2Db(Request["sid"]);
        if (!StringUtil.isValidate(sid, 16))
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // 类别信息
        String type = WrpUtil.text2Db(Request["sth"]);
        if (!StringUtil.isValidate(type, 16))
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页精灵";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet9999";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidInfo(Session).Count;

        hd_W2019102.Value = sid;
        hd_W2019104.Value = type;
        LoadData(sid, type);
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();

        // 更新用户配置的偏好数据
        dba.addTable(cons.io.db.wrp.WrpCons.W2011100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2011104, lb_Replace.SelectedValue);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2011104, hd_W2019102.Value);
        dba.executeUpdate();

        // 从元记录表格中删除数据
        dba.reset();
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, hd_W2019102.Value);
        dba.executeDelete();

        lb_ErrMsg.Text = "数据删除成功！";
    }

    /// <summary>
    /// 数据更新，读取已有数据
    /// </summary>
    private void LoadData(String sid, String typeHash)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019101);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019102);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019103);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019104);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019105);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019106);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019107);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019108);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019109);
        dba.addColumn(cons.io.db.wrp.WrpCons.W201910A);
        dba.addColumn(cons.io.db.wrp.WrpCons.W201910B);
        dba.addColumn(cons.io.db.wrp.WrpCons.W201910C);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019104, typeHash);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019103, SysCons.UI_LANGHASH);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, "!=", sid, true);
        dba.addSort(cons.io.db.wrp.WrpCons.W2019101, false);

        lb_Replace.DataSource = dba.executeSelect();
        lb_Replace.DataTextField = cons.io.db.wrp.WrpCons.W2019106;
        lb_Replace.DataValueField = cons.io.db.wrp.WrpCons.W2019102;
        lb_Replace.DataBind();
    }
}