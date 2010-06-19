using System;
using System.Web.UI;

using cons.io.db.prp;
using cons.wrp.link;

using rmp.io.db;

using WrpCons = cons.wrp.WrpCons;

public partial class link_link0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "友情链接";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0002";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        if (IsPostBack)
        {
            return;
        }

        readDataList(LinkCons.LINK_SITE_HASH);
    }

    /// <summary>
    /// 读取指定类别索引下的所有链接数据
    /// </summary>
    /// <param name="typeIndx"></param>
    private void readDataList(String typeIndx)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3070100);
        dba.addWhere(PrpCons.P3070104, typeIndx);
        dba.addSort(PrpCons.P3070101, false);

        dl_DataList.DataSource = dba.executeSelect();
        dl_DataList.DataBind();
    }
}