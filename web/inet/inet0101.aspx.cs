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

public partial class inet_inet0101 : Page
{
    protected bool isRoot;
    protected bool isUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        if (randId == 0)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }
        isRoot = (randId >= cons.comn.user.UserInfo.LEVEL_06);
        isUser = (randId >= cons.comn.user.UserInfo.LEVEL_02);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "面板配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0101";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0101.aspx";
        guidItem.V1 = "面板配置";
        guidItem.V2 = "面板配置";

        if (IsPostBack)
        {
            return;
        }

        if (isRoot)
        {
            hd_Size.Value = "100";
        }

        DBAccess dba = new DBAccess();
        readFav(dba);
        readAll(dba, SysCons.INET_HASH);
    }

    /// <summary>
    /// 读取偏好数据列表
    /// </summary>
    /// <param name="dba"></param>
    private void readFav(DBAccess dba)
    {
        dba.reset();
        dba.addTable(WrpCons.W2011100);
        dba.addTable(ComnCons.C2010000);
        dba.addColumn(ComnCons.C2010004);
        dba.addColumn(ComnCons.C2010002);
        dba.addWhere(WrpCons.W2011104, ComnCons.C2010002, false);
        dba.addWhere(WrpCons.W2011102, InetCons.TYPE_USER_KIND);
        dba.addWhere(WrpCons.W2011105, UserInfo.Current(Session).UserCode);
        dba.addSort(ComnCons.C2010002);

        lb_Fav.DataTextField = ComnCons.C2010004;
        lb_Fav.DataValueField = ComnCons.C2010002;
        lb_Fav.DataSource = dba.executeSelect();
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
        dba.addTable(ComnCons.C2010000);
        dba.addColumn(ComnCons.C2010004);
        dba.addColumn(ComnCons.C2010002);
        dba.addWhere(ComnCons.C2010003, typeHash);
        dba.addSort(ComnCons.C2010002);

        lb_All.DataTextField = ComnCons.C2010004;
        lb_All.DataValueField = ComnCons.C2010002;
        lb_All.DataSource = dba.executeSelect();
        lb_All.DataBind();
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
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_04 && lb_Fav.Items.Count >= 4)
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
        if (lb_Fav.Items.Count > 1)
        {
            lb_Fav.SelectedIndex = 0;
        }
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
        dba.addTable(WrpCons.W2011100);
        dba.addWhere(WrpCons.W2011102, InetCons.TYPE_USER_KIND);
        dba.addWhere(WrpCons.W2011105, UserInfo.Current(Session).UserCode);
        dba.executeDelete();

        // 循环添加现有数据
        long time = DateTime.Now.ToBinary();
        int idx = 1;
        foreach (ListItem item in lb_Fav.Items)
        {
            dba.executeInsert(String.Format("INSERT INTO {0} VALUES ({1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, {8})",
                                      WrpCons.W2011100,
                                      idx++,
                                      InetCons.TYPE_USER_KIND,
                                      StringUtil.encodeLong(time++, false),
                                      item.Value,
                                      UserInfo.Current(Session).UserCode,
                                      "",
                                      EnvCons.SQL_NOW,
                                      EnvCons.SQL_NOW));
        }
    }

    /// <summary>
    /// 数据项上移
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lb_MoveUp_Click(object sender, EventArgs e)
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
    protected void lb_MoveDn_Click(object sender, EventArgs e)
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
}