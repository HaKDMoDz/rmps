<%@ WebHandler Language="C#" Class="inet0031" %>

using System;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;

public class inet0031 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;

        // 输入参数合法性判断
        String sid = rmp.util.WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);
        String url = context.Request[cons.wrp.WrpCons.URI];
        if (!rmp.util.StringUtil.isValidate(sid, 16) || !rmp.util.StringUtil.isValidate(url))
        {
            context.Response.Write("0:0;0");
            context.Response.End();
            return;
        }

        // 执行数据查询
        rmp.io.db.DBAccess dba = new rmp.io.db.DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2019108);
        dba.addColumn(cons.io.db.wrp.WrpCons.W201910C);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, sid);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019103, cons.SysCons.UI_LANGHASH);

        // 返回数据
        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            context.Response.Write("0:0;0");
            context.Response.End();
            return;
        }

        DataRow row = dt.Rows[0];
        String temp = row[cons.io.db.wrp.WrpCons.W201910C].ToString().Trim().Replace("\r", "");//关键分隔信息
        int sp = temp.IndexOf("\n\n");
        String[] site = temp.Substring(0, sp).Trim().Split('\n');//site分隔信息
        String[] link = temp.Substring(sp).Trim().Split('\n');//link分隔信息
        temp = row[cons.io.db.wrp.WrpCons.W2019108].ToString();//搜索引擎路径
        String data = sid;
        if (site.Length == 3)
        {
            data += ':' + readData((temp + site[0]).Replace("{2}", url), site[1], site[2]);
        }
        if (link.Length == 3)
        {
            data += ';' + readData((temp + link[0]).Replace("{2}", url), link[1], link[2]);
        }

        context.Response.Write(data);
        context.Response.End();
    }

    /// <summary>
    /// 读取指定地址返回的页面结果
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fc"></param>
    /// <param name="ec"></param>
    /// <returns></returns>
    private static String readData(String path, String fc, String ec)
    {
        String html = rmp.util.WrpUtil.readHtmlCode(path);

        Regex reg = new Regex("^[\\s\\S]*" + fc);
        if (reg.IsMatch(html))
        {
            html = reg.Replace(html, "");
            reg = new Regex(ec + "[\\s\\S]*$");
            if (reg.IsMatch(html))
            {
                html = reg.Replace(html, "");
                if (!rmp.util.StringUtil.isValidate(html))
                {
                    html = "0";
                }
                return html;
            }
        }

        return "0";
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}