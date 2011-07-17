using System;
using System.Web.UI;

using cons.io.db.comn;

using rmp.io.db;

public partial class soft_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Amon软件";
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 1;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        // SQL语句封装
        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C0010100);
        dba.addWhere(ComnCons.C0010102, "26");
        dba.addSort(ComnCons.C0010104);

        // 数据查询与梆定
        SoftList.DataSource = dba.executeSelect();
        SoftList.DataBind();
    }
}