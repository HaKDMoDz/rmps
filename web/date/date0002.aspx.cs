using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.wrp;

using WrpCons = cons.wrp.WrpCons;

public partial class date_date0002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        String sid = Request[WrpCons.SID];
        if (sid == null || sid.Trim() == "")
        {
            return;
        }

        String name = LoadData(sid);

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX]= 2;
        Session[cons.wrp.WrpCons.GUIDNAME]= name;
        Session[cons.wrp.WrpCons.SCRIPTID]= "date0002";

        List<K1V2> guidList = Wrps.GuidDate(Session);
        K1V2 guidItem = guidList[2];
        guidItem.K = "date0002.aspx?sid=" + sid;
        guidItem.V1 = name;
        guidItem.V2 = name;

        hl_MyIdea.NavigateUrl = "/idea/idea0001.aspx?sid=" + sid;
        if (UserInfo.Current(Session).UserRank == cons.comn.user.UserInfo.LEVEL_09)
        {
            guidItem = guidList[3];
            guidItem.K = "date9999.aspx?sid=" + sid;
            guidItem.V1 = name;
            guidItem.V2 = name;
            hl_Update.NavigateUrl = "~/date/date9999.aspx?sid=" + sid;
            hl_Update.Visible = true;
        }
    }

    protected void ib_P3100101_Click(object sender, ImageClickEventArgs e)
    {
        new DBAccess().UpdateStep(PrpCons.P3100100, PrpCons.P3100103, hd_P3100103.Value, PrpCons.P3100101, 1);
        lb_P3100101.Text = "" + (Int32.Parse(lb_P3100101.Text) + 1);
    }

    protected void ib_P3100102_Click(object sender, ImageClickEventArgs e)
    {
        new DBAccess().UpdateStep(PrpCons.P3100100, PrpCons.P3100103, hd_P3100103.Value, PrpCons.P3100102, 1);
        lb_P3100102.Text = "" + (Int32.Parse(lb_P3100102.Text) + 1);
    }

    private String LoadData(String sid)
    {
        String sqlTable = PrpCons.P3100100;
        String sqlSelect = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                         PrpCons.P3100101,
                                         PrpCons.P3100102,
                                         PrpCons.P3100106,
                                         PrpCons.P3100104,
                                         PrpCons.P3100107,
                                         PrpCons.P3100108,
                                         PrpCons.P3100109
            );
        DataView dv = new DBAccess().CreateView(sqlTable, String.Format("SELECT {1} FROM {0} WHERE {2}='{3}'", sqlTable, sqlSelect, PrpCons.P3100103, sid));
        if (dv.Count < 1)
        {
            return "";
        }
        DataRowView row = dv[0];
        lb_P3100101.Text = row[PrpCons.P3100101].ToString();
        lb_P3100102.Text = row[PrpCons.P3100102].ToString();
        hd_P3100103.Value = sid;
        hd_FlashObj.Value = row[PrpCons.P3100106] + "." + row[PrpCons.P3100104];
        String name = row[PrpCons.P3100107].ToString();
        lb_P3100108.Text = row[PrpCons.P3100108].ToString();

        dv.Dispose();
        return name;
    }
}