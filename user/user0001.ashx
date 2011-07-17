<%@ WebHandler Language="C#" Class="user0001" %>

using System;
using System.Web;

public class user0001 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        String sid = context.Request[cons.wrp.WrpCons.SID];
        String code = "";
        if (rmp.util.StringUtil.isValidate(sid))
        {
            var dba = new rmp.io.db.DBAccess();
            dba.addTable(cons.io.db.comn.user.UserCons.C3010500);
            dba.addColumn(cons.io.db.comn.user.UserCons.C3010504);
            dba.addWhere(cons.io.db.comn.user.UserCons.C3010506, rmp.util.WrpUtil.text2Db(sid));
            System.Data.DataTable dt = dba.executeSelect();
            if (dt.Rows.Count == 1)
            {
                code = dt.Rows[0][cons.io.db.comn.user.UserCons.C3010504].ToString();
            }
        }
        context.Response.Write(code);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}