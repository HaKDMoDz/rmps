using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp;
using rmp.wrp.date;

using WrpCons = cons.wrp.WrpCons;

public partial class date_date0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        String sid = Request[WrpCons.SID];
        if (string.IsNullOrEmpty(sid))
        {
            Response.Redirect("~/date/index.aspx");
            return;
        }

        String name = Date.DateName(sid);
        Session.Add(WrpCons.SID_DATE, sid);
        Session.Add(WrpCons.SNM_DATE, name);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = name;
        Session[cons.wrp.WrpCons.SCRIPTID] = "date0001";

        List<K1V2> guidList = Wrps.GuidDate(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/date/date0001.aspx?sid=" + sid;
        guidItem.V1 = name;
        guidItem.V2 = name;

        readList(sid);
    }

    private void readList(String kindHash)
    {
        String sqlTable = PrpCons.P3100100;
        String sqlSelect = String.Format("SELECT {1}, {2}, {3} FROM {0} WHERE {4}='{5}' ORDER BY {6} DESC",
                                         sqlTable,
                                         PrpCons.P3100103,
                                         PrpCons.P3100107,
                                         PrpCons.P3100108,
                                         PrpCons.P3100105, kindHash,
                                         PrpCons.P3100101
            );
        dl_DateList.DataSource = new DBAccess().CreateView(sqlTable, sqlSelect);
        dl_DateList.DataBind();
    }
}