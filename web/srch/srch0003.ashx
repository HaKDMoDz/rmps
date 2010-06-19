<%@ WebHandler Language="C#" Class="srch0003" %>

using System.Web;
using rmp.io.db;
using rmp.util;

/// <summary>
/// 搜索引擎频率统计
/// </summary>
public class srch0003 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // 搜索引擎ID
        string sid = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);
        // 登录用户代码
        string uri = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.URI]);

        if (StringUtil.isValidate(sid, 16) && StringUtil.isValidate(uri, 8))
        {
            DBAccess dba = new DBAccess();

            // 搜索引擎频率更新
            dba.UpdateStep(cons.io.db.wrp.WrpCons.W2039100, cons.io.db.wrp.WrpCons.W2039102, sid, cons.io.db.wrp.WrpCons.W2039101, 1);

            // 用户配置数据更新
            dba.UpdateStep(cons.io.db.wrp.WrpCons.W2031100,
                new string[] { cons.io.db.wrp.WrpCons.W2031104, cons.io.db.wrp.WrpCons.W2031105 },
                new string[] { sid, uri },
                cons.io.db.wrp.WrpCons.W2031101, 1);
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}