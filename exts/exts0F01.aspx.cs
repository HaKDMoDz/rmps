using System;
using System.Web.UI;

using cons.io.db.prp;

using rmp.io.db;
using rmp.util;

public partial class exts_exts0F01 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 16))
        {
            return;
        }

        // 数据类别
        String uri = Request[cons.wrp.WrpCons.URI];
        if (String.IsNullOrEmpty(uri))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        switch (uri)
        {
            case "mime":
                ReadMime(dba, sid);
                break;
            case "asoc":
                ReadAsoc(dba, sid);
                break;
            default:
                break;
        }
    }

    private void ReadMime(DBAccess dba, String sid)
    {
        dba.reset();
        dba.addTable(PrpCons.P3010600);
        dba.addTable(PrpCons.P301F100);
        dba.addColumn(PrpCons.P3010601, "s");
        dba.addColumn(PrpCons.P301F104);
        dba.addWhere(PrpCons.P3010602, sid);
        dba.addWhere(PrpCons.P3010603, PrpCons.P301F102, false);
        dba.addWhere(PrpCons.P301F103, cons.SysCons.UI_LANGHASH);
    }

    private void ReadAsoc(DBAccess dba, String sid)
    {
        dba.reset();
        dba.addTable(PrpCons.P3010700);
        dba.addColumn(PrpCons.P3010701);
        dba.addWhere(PrpCons.P3010703);
    }
}