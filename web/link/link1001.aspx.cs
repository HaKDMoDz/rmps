using System;
using System.Web.UI;

using cons.io.db.prp;
using cons.wrp.link;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;

using WrpCons = cons.wrp.WrpCons;

public partial class link_link1001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "友情链接";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link1001";
        Session[cons.wrp.WrpCons.GUIDSIZE] = UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_02 ? 5 : 3;

        if (IsPostBack)
        {
            return;
        }

        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 16))
        {
            sid = LinkCons.LINK_SITE_HASH;
        }
        readDataList(sid);
    }

    /// <summary>
    /// 读取指定类别索引下的所有链接数据
    /// </summary>
    /// <param name="typeIndx"></param>
    private void readDataList(String typeIndx)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3070100);
        dba.addTable(PrpCons.P3070200);
        dba.addWhere(PrpCons.P3070105, PrpCons.P3070202, false);
        dba.addWhere(PrpCons.P3070203, typeIndx);
        dba.addSort(PrpCons.P3070101, false);

        dl_DataList.DataSource = dba.executeSelect();
        dl_DataList.DataBind();
    }
}
