using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class inet_inet0197 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "查看配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0197";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0197.aspx";
        guidItem.V1 = "查看配置";
        guidItem.V2 = "查看配置";

        if (IsPostBack)
        {
            return;
        }

        // 读取指定的数据信息
        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (StringUtil.isValidate(sid, 16))
        {
            LoadData(sid);
        }
        else
        {
            Response.Redirect("~/index.aspx");
        }
    }

    /// <summary>
    /// 数据更新，读取已有数据
    /// </summary>
    /// <param name="sid"></param>
    private void LoadData(String sid)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addColumn("*");
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, sid);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019104, "iNetHelper_90wmi");

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            hd_W2019102.Value = row[cons.io.db.wrp.WrpCons.W2019102].ToString();
            im_W2019105.ImageUrl = "~/inet/i/" + row[cons.io.db.wrp.WrpCons.W2019105] + ".gif";
            lb_W2019106.Text = row[cons.io.db.wrp.WrpCons.W2019106].ToString();
            lb_W2019107.Text = row[cons.io.db.wrp.WrpCons.W2019107].ToString();
            lb_W2019108.Text = row[cons.io.db.wrp.WrpCons.W2019108].ToString();
            lb_W201910C.Text = row[cons.io.db.wrp.WrpCons.W201910C].ToString();
        }
    }
}