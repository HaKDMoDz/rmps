using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons;
using cons.io.db.comn;
using cons.io.db.wrp;
using cons.wrp.inet;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class inet_inet0102 : Page
{
    protected bool isRoot;
    protected bool isUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        isRoot = (randId == cons.comn.user.UserInfo.LEVEL_09);
        isUser = (randId >= cons.comn.user.UserInfo.LEVEL_02);
        if (randId == 0)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0102";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0102.aspx";
        guidItem.V1 = "数据配置";
        guidItem.V2 = "数据配置";

        if (IsPostBack)
        {
            return;
        }

        // 类别列表数据初始化
        DBAccess dba = new DBAccess();
        dba.addTable(WrpCons.W2011100);
        dba.addTable(ComnCons.C2010000);
        dba.addColumn(ComnCons.C2010004);
        dba.addColumn(ComnCons.C2010002);
        dba.addWhere(WrpCons.W2011104, ComnCons.C2010002, false);
        dba.addWhere(WrpCons.W2011102, InetCons.TYPE_USER_KIND);
        dba.addWhere(WrpCons.W2011105, UserInfo.Current(Session).UserCode);
        dba.addSort(ComnCons.C2010002);

        cb_W2010203.DataSource = dba.executeSelect();
        cb_W2010203.DataTextField = ComnCons.C2010004;
        cb_W2010203.DataValueField = ComnCons.C2010002;
        cb_W2010203.DataBind();
        cb_W2010203.Items.Insert(0, new ListItem("请选择", ""));

        // 是否管理人返回
        String sid = Request[cons.wrp.WrpCons.SID];
        if (StringUtil.isValidate(sid, 16))
        {
            readFav(dba, sid);
            readAll(dba, sid);

            cb_W2010203.SelectedValue = sid;
            bt_Save.Visible = true;
        }
    }

    /// <summary>
    /// 读取指定类别的数据，并列表显示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_ListData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();

        readFav(dba, cb_W2010203.SelectedValue);
        readAll(dba, cb_W2010203.SelectedValue);

        bt_Save.Visible = true;
    }

    /// <summary>
    /// 读取偏好数据列表
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="typeHash"></param>
    private void readFav(DBAccess dba, String typeHash)
    {
        dba.reset();
        dba.addTable("W2011100 LEFT JOIN W2019100 ON W2011104=W2019102");
        dba.addColumn(WrpCons.W2011103);
        dba.addColumn(WrpCons.W2019102);
        dba.addColumn(WrpCons.W2019105);
        dba.addColumn(WrpCons.W2019106);
        dba.addColumn(WrpCons.W2019107);
        dba.addWhere(WrpCons.W2019104, typeHash);
        dba.addWhere(WrpCons.W2011105, UserInfo.Current(Session).UserCode);
        dba.addSort(WrpCons.W2011101, false);

        lb_Fav.DataSource = dba.executeSelect();
        lb_Fav.DataTextField = WrpCons.W2019106;
        lb_Fav.DataValueField = WrpCons.W2019102;
        lb_Fav.DataBind();
    }

    /// <summary>
    /// 读取可用数据列表
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="typeHash"></param>
    private void readAll(DBAccess dba, String typeHash)
    {
        dba.reset();
        dba.addTable(WrpCons.W2019100);
        dba.addColumn(WrpCons.W2019101);
        dba.addColumn(WrpCons.W2019102);
        dba.addColumn(WrpCons.W2019103);
        dba.addColumn(WrpCons.W2019104);
        dba.addColumn(WrpCons.W2019105);
        dba.addColumn(WrpCons.W2019106);
        dba.addColumn(WrpCons.W2019107);
        dba.addColumn(WrpCons.W2019108);
        dba.addColumn(WrpCons.W2019109);
        dba.addColumn(WrpCons.W201910A);
        dba.addColumn(WrpCons.W201910B);
        dba.addColumn(WrpCons.W201910C);
        dba.addWhere(WrpCons.W2019104, typeHash);
        dba.addSort(WrpCons.W2019101, false);

        lb_All.DataSource = dba.executeSelect();
        lb_All.DataTextField = WrpCons.W2019106;
        lb_All.DataValueField = WrpCons.W2019102;
        lb_All.DataBind();
    }

    /// <summary>
    /// 添加所有
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_AddAll_Click(object sender, EventArgs e)
    {
        if (lb_All.Items.Count < 1)
        {
            return;
        }

        foreach (ListItem item in lb_All.Items)
        {
            lb_Fav.Items.Add(item);
        }
        lb_Fav.SelectedIndex = lb_Fav.Items.Count - 1;
    }

    /// <summary>
    /// 添加选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_AddOne_Click(object sender, EventArgs e)
    {
        if (lb_All.SelectedValue == null || lb_All.SelectedIndex < 0)
        {
            return;
        }

        lb_Fav.Items.Add(lb_All.SelectedItem);
        lb_Fav.SelectedIndex = lb_Fav.Items.Count - 1;
    }

    /// <summary>
    /// 移除选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_DelOne_Click(object sender, EventArgs e)
    {
        if (lb_Fav.SelectedValue == null || lb_Fav.SelectedIndex < 0)
        {
            return;
        }

        lb_Fav.Items.RemoveAt(lb_Fav.SelectedIndex);
    }

    /// <summary>
    /// 移除所有
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_DelAll_Click(object sender, EventArgs e)
    {
        lb_Fav.Items.Clear();
    }

    /// <summary>
    /// 数据项上移
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void hl_MoveUp_Click(object sender, EventArgs e)
    {
        int idx = lb_Fav.SelectedIndex - 1;
        if (idx <= -1)
        {
            return;
        }

        ListItem item = lb_Fav.SelectedItem;
        lb_Fav.Items.RemoveAt(lb_Fav.SelectedIndex);
        lb_Fav.Items.Insert(idx, item);
    }

    /// <summary>
    /// 数据项下移
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void hl_MoveDn_Click(object sender, EventArgs e)
    {
        int idx = lb_Fav.SelectedIndex + 1;
        if (idx >= lb_Fav.Items.Count)
        {
            return;
        }

        ListItem item = lb_Fav.SelectedItem;
        lb_Fav.Items.RemoveAt(lb_Fav.SelectedIndex);
        lb_Fav.Items.Insert(idx, item);
    }

    /// <summary>
    /// 保存偏好设定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Save_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();

        // 删除已有类别下的数据
        String sqlUpdate = String.Format("DELETE FROM {0} WHERE {1} IN (SELECT {2} FROM {3} WHERE {4}='{5}' AND {6}='{7}')",
                                         WrpCons.W2011100,
                                         WrpCons.W2011104,
                                         WrpCons.W2019102,
                                         WrpCons.W2019100,
                                         WrpCons.W2019104, cb_W2010203.SelectedValue,
                                         WrpCons.W2011105, UserInfo.Current(Session).UserCode);
        dba.UpdateData(sqlUpdate);

        // 循环添加现有数据
        long time = DateTime.Now.ToBinary();
        int idx = lb_Fav.Items.Count;
        foreach (ListItem item in lb_Fav.Items)
        {
            sqlUpdate = String.Format("INSERT INTO {0} VALUES ({1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, {8})",
                                      WrpCons.W2011100,
                                      idx--,
                                      InetCons.TYPE_USER_DATA,
                                      StringUtil.encodeLong(time++, false),
                                      item.Value,
                                      UserInfo.Current(Session).UserCode,
                                      "",
                                      EnvCons.SQL_NOW,
                                      EnvCons.SQL_NOW);

            dba.UpdateData(sqlUpdate);
        }
    }
}