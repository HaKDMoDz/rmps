<%@ WebHandler Language="C#" Class="wime0002" %>

using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using cons.wrp;
using rmp.io.db;
using rmp.util;
using rmp.wrp.wime;

public class wime0002 : IHttpHandler
{

    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = Encoding.UTF8;

        // 编码信息
        string code = WrpUtil.text2Db(context.Request["c"]);
        if (!StringUtil.isValidate(code))
        {
            context.Response.Write("");
            context.Response.End();
            return;
        }
        code += '%';

        // 字库信息
        string type = context.Request["t"] ?? "";
        Regex reg = new Regex("^\\d+$");
        if (!reg.IsMatch(type))
        {
            context.Response.Write("");
            context.Response.End();
            return;
        }

        // 用户信息
        string user = WrpUtil.text2Db(context.Request["u"]);
        if (StringUtil.isValidate(user, 8))
        {
            user = "OR W2020104='" + user + '\'';
        }

        // 查询数据库
        const string SQL =
@"SELECT W2020105,W2020106
    FROM W2020100
   WHERE W2020102={0}
     AND W2020105 LIKE '{1}'
     AND (W2020104='42020000' {2})
   ORDER BY W2020105
   LIMIT 20";
        StringBuilder text = new StringBuilder();
        string last = "";
        int i = 0;
        foreach (DataRow row in new DBAccess().executeSelect(string.Format(SQL, type, code, user)).Rows)
        {
            code = row["w2020105"].ToString();
            if (last != code)
            {
                i += 1;
                if (i > 4)
                {
                    break;
                }

                text.Append(code);
                last = code;
            }
            else
            {
                text.Append(' ');
            }
            text.Append(row["w2020106"].ToString());
        }

        context.Response.Write(text.Length > 0 ? text.ToString() : "");
        context.Response.End();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}