using System;
using System.Web.UI;

using cons.io.db.wrp;

using rmp.io.db;
using rmp.comn.user;

public partial class idea_idea9998 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }

        // 操作模式
        String so = Request.Params["o"];
        String si;
        // 编辑
        if ("e" == so)
        {
            si = Request.Params["e"];
            editData(si);
        }
        // 删除
        else if ("d" == so)
        {
            si = Request.Params["d"];
            deltData(si);
            Response.Redirect("idea9999.aspx");
        }
    }

    private void editData(String id)
    {
    }

    private void deltData(String id)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(WrpCons.WRP_IDEA_IDEADATA);
        dba.addWhere(WrpCons.IDEADATA_IDEAINDX, id);
        dba.executeDelete();
    }
}