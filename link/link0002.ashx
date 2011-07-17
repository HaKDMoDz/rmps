<%@ WebHandler Language="C#" Class="link0002" %>

using System;
using System.Web;

using cons.io.db.prp;

using rmp.io.db;
using rmp.util;

/// <summary>
/// 访问频率统计
/// </summary>
public class link0002 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        DBAccess dba = new DBAccess();

        String sid = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);//链接索引
        if (StringUtil.isValidate(sid, 16))
        {
            dba.UpdateStep(PrpCons.P3070100, PrpCons.P3070105, sid, PrpCons.P3070101, 1);
        }

        String uri = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.URI]);//类别索引
        if (StringUtil.isValidate(uri, 16))
        {
            dba.UpdateStep(cons.io.db.comn.info.C2010000.C2010100, cons.io.db.comn.info.C2010000.C2010105, uri, cons.io.db.comn.info.C2010000.C2010101, 1);
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}