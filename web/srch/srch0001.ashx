<%@ WebHandler Language="C#" Class="srch0001" %>

using System;
using System.Data;
using System.Text;
using System.Web;

using cons.io.db.comn;
using cons.io.db.wrp;

using rmp.io.db;
using rmp.util;
using rmp.wrp.srch;

/// <summary>
/// 用户JS加载
/// </summary>
public class srch0001 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = Encoding.UTF8;

        // 用户代码
        string sid = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 8))
        {
            sid = cons.comn.user.UserInfo.COMN_CODE;
        }

        // 加载用户偏好类别
        DBAccess dba = new DBAccess();
        DataTable dt = LoadKind(dba, sid);
        if (dt == null || dt.Rows.Count < 1)
        {
            sid = cons.comn.user.UserInfo.COMN_CODE;
            dba.reset();
            dt = LoadKind(dba, sid);
        }

        // 处理用户类别
        StringBuilder kind = new StringBuilder();
        // 格式：var DVID={'hash':['logo','name','tips'],...}
        kind.Append("var DVID={'user':['dz','定制搜索','用户定制搜索']");
        foreach (DataRow row in dt.Rows)
        {
            kind.Append(",'").Append(row[ComnCons.C2010002]).Append("':['").Append(row[ComnCons.C2010006]).Append("','").Append(row[ComnCons.C2010004]).Append("','").Append(row[ComnCons.C2010005]).Append("']");
        }
        kind.Append("};");

        // 加载用户偏好链接
        dba.reset();
        DataView dv = LoadData(dba, sid);
        StringBuilder link = new StringBuilder();
        link.Append("var DVDT={'amon':{}");
        String temp;
        foreach (DataRowView row1 in dv)
        {
            if (row1[WrpCons.W2039104] + "" != "0")
            {
                break;
            }

            temp = row1[WrpCons.W2039102] + "";
            link.Append(",'").Append(temp).Append("':{");
            AppendLink(link, row1);

            dv.RowFilter = String.Format("{0}='{1}'", WrpCons.W2039104, temp);
            foreach (DataRowView row2 in dv)
            {
                AppendLink(link.Append(','), row2);
            }
            link.Append("}");
        }
        link.Append("};");

        // 写出到客户端
        context.Response.Write(Srch.TpltCode.Replace("{$DATA$}", kind + "var USER='" + sid + "';" + link));
        context.Response.End();
    }

    /// <summary>
    /// 读取用户配置类别信息
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid"></param>
    /// <returns></returns>
    private static DataTable LoadKind(DBAccess dba, string sid)
    {
        dba.addTable(ComnCons.C2010000);
        dba.addTable(WrpCons.W2031100);
        dba.addColumn(ComnCons.C2010002);
        dba.addColumn(ComnCons.C2010004);
        dba.addColumn(ComnCons.C2010005);
        dba.addColumn(ComnCons.C2010006);
        dba.addWhere(ComnCons.C2010002, WrpCons.W2031104, false);
        dba.addWhere(WrpCons.W2031105, sid);
        dba.addSort(WrpCons.W2031101, false);
        return dba.executeSelect();
    }

    /// <summary>
    /// 读取用户配置数据信息
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid"></param>
    /// <returns></returns>
    private static DataView LoadData(DBAccess dba, string sid)
    {
        dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3}",
               WrpCons.W2039100, WrpCons.W2031100,
               WrpCons.W2039102, WrpCons.W2031104));// 用户偏好配置

        dba.addColumn(WrpCons.W2039102);//元素索引
        dba.addColumn(WrpCons.W2039104);//从属门户
        dba.addColumn(WrpCons.W2039105);//类别索引
        dba.addColumn(WrpCons.W2039106);//显示图标
        dba.addColumn(WrpCons.W2039107);//显示文本
        dba.addColumn(WrpCons.W2039108);//功能名称
        dba.addColumn(WrpCons.W2039109);//快捷提示
        dba.addColumn(WrpCons.W203910A);//链接地址
        dba.addColumn(WrpCons.W203910B);//转换方案
        dba.addColumn(WrpCons.W203910C);//窗口模式
        dba.addColumn(WrpCons.W2031103);//用户偏好
        dba.addWhere(WrpCons.W2031105, sid);// 用户偏好
        dba.addSort(WrpCons.W2039104);// 从属门户
        dba.addSort(WrpCons.W2039101, false);// 显示排序

        return dba.executeSelect().DefaultView;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="link"></param>
    /// <param name="view"></param>
    private static void AppendLink(StringBuilder link, DataRowView view)
    {
        link.Append('\'').Append(view[WrpCons.W2039102]).Append("':['");// 功能索引
        link.Append(view[WrpCons.W2039105]).Append("','");// 0:类别索引
        link.Append(view[WrpCons.W2039106]).Append("','");// 1:功能图标
        link.Append(view[WrpCons.W2039107]).Append("','");// 2:显示文本
        link.Append(view[WrpCons.W2039108]).Append("','");// 3:功能名称
        link.Append(view[WrpCons.W2039109]).Append("','");// 4:快捷提示
        link.Append(view[WrpCons.W203910A]).Append("','");// 5:链接地址
        link.Append(view[WrpCons.W203910B]).Append("','");// 6:转换方案
        link.Append(view[WrpCons.W203910C]).Append("']");// 7:窗口模式
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}