using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class inet_inet0199 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "删除配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0199";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0199.aspx";
        guidItem.V1 = "删除配置";
        guidItem.V2 = "删除配置";

        if (IsPostBack)
        {
            return;
        }

        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (StringUtil.isValidate(sid, 16))
        {
            hd_W2019102.Value = sid;
        }
        else
        {
            Response.Redirect("~/index.aspx");
        }
    }

    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();

        // 从元记录表格中删除数据
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, hd_W2019102.Value);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019104, "iNetHelper_90wmi");
        if (dba.executeDelete() == 1)
        {
            // 更新用户配置的偏好数据
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2011100);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2011104, hd_W2019102.Value);
            dba.executeDelete();

            lb_ErrMsg.Text = "数据删除成功！";
        }
    }
}