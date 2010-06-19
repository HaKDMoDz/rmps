using System;
using System.Web.UI;

using cons.wrp;

using rmp.wrp;
using rmp.io.db;
using cons.io.db.comn;
using System.Data;
using rmp.wrp.date;
using rmp.util;

public partial class Templates_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Amon软件";
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";

        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidSoft(Session).Count - 1;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C0010100);

        long now = DateTime.UtcNow.ToBinary();
        DataTable dataTable = dba.executeSelect();
        foreach (DataRow row in dataTable.Rows)
        {
            String id = row[ComnCons.C0010103].ToString();
            if (StringUtil.isValidateHash(id))
            {
                continue;
            }

            DateTime create = (DateTime)row[ComnCons.C0010116];

            dba.reset();
            dba.addTable(ComnCons.C0010100);
            dba.addParam(ComnCons.C0010103, StringUtil.encodeLong(now++, false));
            dba.addWhere(ComnCons.C0010103, id);
            dba.executeUpdate();
        }
    }
}