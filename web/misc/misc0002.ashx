<%@ WebHandler Language="C#" Class="misc0002" %>

using System;
using System.Web;

public class misc0002 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request["idBox"] ?? "";
        if (!System.Text.RegularExpressions.Regex.IsMatch(id, "^\\d+$"))
        {
            return;
        }

        string rate = context.Request["rate"];
        if (!System.Text.RegularExpressions.Regex.IsMatch(rate, "^\\d+$"))
        {
            return;
        }

        rmp.io.db.DBAccess dba = new rmp.io.db.DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2060100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2060102, "=", cons.io.db.wrp.WrpCons.W2060102 + "+" + rate, false);
        dba.addParam(cons.io.db.wrp.WrpCons.W2060103, "=", cons.io.db.wrp.WrpCons.W2060103 + "+1", false);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2060105, id, false);
        bool ok = (1 == dba.executeUpdate());

        rmp.wrp.misc.Misc.GetMisc().W2060102 += int.Parse(rate);
        rmp.wrp.misc.Misc.GetMisc().W2060103 += 1;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}