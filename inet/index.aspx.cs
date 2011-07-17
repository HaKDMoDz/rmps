using System;
using System.Data;
using System.Web.UI;
using cons;
using cons.wrp;

using rmp.io.db;

public partial class inet_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页精灵";
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 1;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        // 查询语句
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010104, SysCons.INET_HASH);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010102, ">", "0", true);
        DataTable dataList = dba.executeSelect();

        if (dataList.Rows.Count > 0)
        {
            DataRow row = dataList.Rows[0];

            string tips = row[cons.io.db.comn.ComnCons.C0010106] + "_" + row[cons.io.db.comn.ComnCons.C0010105];

            // 软件图标
            SoftView.ImageUrl = string.Format("~/_images/{0}.png", SysCons.INET_HASH);
            SoftView.ToolTip = tips;

            // 软件介绍
            SoftInfo.Text = String.Format(row[cons.io.db.comn.ComnCons.C0010112].ToString(), "&nbsp;&nbsp;&nbsp;&nbsp;");

            // 发行日期
            PubsTime.Text = row[cons.io.db.comn.ComnCons.C0010107].ToString();

            // 发行版本
            SoftVers.Text = row[cons.io.db.comn.ComnCons.C0010105].ToString();

            // 软件更新
            BugList.Text = String.Format(row[cons.io.db.comn.ComnCons.C0010113].ToString(), "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        }
    }
}