<%@ WebHandler Language="C#" Class="link0001" %>

using System;
using System.Data;
using System.Text;
using System.Web;
using System.Xml;
using cons.io.db.comn.info;
using cons.io.db.prp;

using rmp.io.db;
using rmp.util;
using rmp.wrp.link;

public class link0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // XML 文档对象
        var doc = new XmlDocument();
        doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", "yes"));

        // XML 文档根节点
        XmlElement root = doc.CreateElement("amonsoft");
        doc.AppendChild(root);

        // 用户编码
        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim().ToUpper();
        if (!StringUtil.isValidateCode(sid))
        {
            sid = cons.comn.user.UserInfo.COMN_CODE;
        }

        // 操作方式
        String opt = (context.Request[cons.wrp.WrpCons.OPT] ?? "").Trim().ToLower();

        // 查询参数
        String uri = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.URI]).Trim();

        var dba = new DBAccess();

        switch (opt)
        {
            case "l":
                // list:根据级别列表查看
                ListKind(dba, sid, uri, doc, root);
                ListItem(dba, sid, uri, doc, root);
                break;
            case "q":
                // query:根据输入条件查询
                if (StringUtil.isValidate(uri))
                {
                    ReadItem(dba, sid, uri, doc, root);
                }
                break;
            case "d":
                // info:链接详细信息
                Detail(dba, sid, uri, doc, root);
                break;
            case "r":
                // remove:删除链接数据
                Remove(dba, sid, uri, doc, root);
                break;
            case "a":
                // append:添加链接数据
                Append(dba, sid, uri, doc, root);
                break;
            default:
                break;
        }

        context.Response.ContentType = "text/xml";
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.Write(doc.InnerXml);
        context.Response.End();
    }

    /// <summary>
    /// 根据上级类别索引，显示所有下级列表
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid"></param>
    /// <param name="uri"></param>
    /// <param name="doc"></param>
    /// <param name="top"></param>
    private static void ListKind(DBAccess dba, String sid, String uri, XmlDocument doc, XmlNode top)
    {
        dba.addTable(C2010000.C2010100);
        dba.addColumn(C2010000.C2010105);
        dba.addColumn(C2010000.C2010107);
        dba.addColumn(C2010000.C2010108);
        dba.addColumn(C2010000.C2010109);
        dba.addColumn(C2010000.C201010A);
        dba.addWhere(C2010000.C2010104, sid);
        dba.addWhere(C2010000.C2010106, StringUtil.isValidateHash(uri) ? uri : "13070000" + sid);
        dba.addWhere(C2010000.C2010102, "0");
        dba.addSort(C2010000.C2010101, false);

        XmlElement node = doc.CreateElement("kind");
        top.AppendChild(node);

        DataTable dt = dba.executeSelect();
        XmlElement item;
        foreach (DataRow row in dt.Rows)
        {
            item = doc.CreateElement("item");
            item.SetAttribute("id", row[C2010000.C2010105].ToString());
            item.SetAttribute("name", row[C2010000.C2010107].ToString());
            item.SetAttribute("tips", row[C2010000.C2010108].ToString());
            item.SetAttribute("value", row[C2010000.C2010109].ToString());
            item.SetAttribute("remark", row[C2010000.C201010A].ToString());
            node.AppendChild(item);
        }

        dba.reset();
    }

    /// <summary>
    /// 读取指定类别下的所有链接数据
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid">用户代码</param>
    /// <param name="uri">链接类别</param>
    /// <param name="doc"></param>
    /// <param name="top"></param>
    private static void ListItem(DBAccess dba, String sid, String uri, XmlDocument doc, XmlNode top)
    {
        dba.addTable(PrpCons.P3070100);
        dba.addTable(PrpCons.P3070200);
        dba.addColumn(PrpCons.P3070104);
        dba.addColumn(PrpCons.P3070105);
        dba.addColumn(PrpCons.P3070107);
        dba.addColumn(PrpCons.P3070108);
        dba.addColumn(PrpCons.P3070109);
        dba.addColumn(PrpCons.P3070205);
        dba.addWhere(PrpCons.P3070202, sid);
        dba.addWhere(PrpCons.P3070105, PrpCons.P3070204, false);
        dba.addWhere(PrpCons.P3070203, uri);
        dba.addSort(PrpCons.P3070101, false);

        XmlElement node = doc.CreateElement("link");
        top.AppendChild(node);

        XmlElement item;
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            item = doc.CreateElement("item");
            item.SetAttribute("id", row[PrpCons.P3070105].ToString());
            item.SetAttribute("logo", row[PrpCons.P3070107].ToString());
            item.SetAttribute("name", row[PrpCons.P3070205].ToString());
            item.SetAttribute("title", row[PrpCons.P3070108].ToString());
            item.SetAttribute("path", row[PrpCons.P3070109].ToString());
            item.SetAttribute("short", row[PrpCons.P3070104].ToString());
            node.AppendChild(item);
        }

        dba.reset();
    }

    /// <summary>
    /// 获取用户搜索结果
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid">用户代码</param>
    /// <param name="uri">查询条件</param>
    /// <param name="doc"></param>
    /// <param name="top"></param>
    private static void ReadItem(DBAccess dba, String sid, String uri, XmlDocument doc, XmlNode top)
    {
        dba.addTable(PrpCons.P3070100);
        dba.addTable(PrpCons.P3070200);
        dba.addTable(C2010000.C2010100);
        dba.addColumn(C2010000.C2010105);
        dba.addColumn(C2010000.C2010107);
        dba.addColumn(C2010000.C2010108);
        dba.addColumn(C2010000.C2010109);
        dba.addColumn(C2010000.C201010A);
        dba.addColumn(PrpCons.P3070104);
        dba.addColumn(PrpCons.P3070105);
        dba.addColumn(PrpCons.P3070107);
        dba.addColumn(PrpCons.P3070108);
        dba.addColumn(PrpCons.P3070109);
        dba.addColumn(PrpCons.P3070205);
        dba.addWhere(PrpCons.P3070105, PrpCons.P3070204, false);
        dba.addWhere(PrpCons.P3070203, C2010000.C2010105, false);
        if (sid != cons.comn.user.UserInfo.COMN_CODE)
        {
            dba.addWhere(String.Format("({0}='{1}' OR {0}='{2}')", PrpCons.P3070202, sid, cons.comn.user.UserInfo.COMN_CODE));
        }
        else
        {
            dba.addWhere(PrpCons.P3070202, sid);
        }
        uri = new System.Text.RegularExpressions.Regex("\\s+").Replace(uri, "%");
        dba.addWhere(String.Format("{1} LIKE '{0}' OR {2} LIKE '{0}' OR {3} LIKE '{0}' OR {4} LIKE '{0}'", '%' + uri + '%',
            PrpCons.P3070205, PrpCons.P3070108, PrpCons.P3070109, PrpCons.P307010C));
        dba.addSort(PrpCons.P3070201, false);

        XmlElement node;
        XmlElement item;
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            node = doc.CreateElement("item");
            top.AppendChild(node);

            item = doc.CreateElement("kind");
            item.SetAttribute("id", row[C2010000.C2010105].ToString());
            item.SetAttribute("name", row[C2010000.C2010107].ToString());
            item.SetAttribute("tips", row[C2010000.C2010108].ToString());
            item.SetAttribute("value", row[C2010000.C2010109].ToString());
            item.SetAttribute("remark", row[C2010000.C201010A].ToString());
            node.AppendChild(item);

            item = doc.CreateElement("link");
            item.SetAttribute("id", row[PrpCons.P3070105].ToString());
            item.SetAttribute("logo", row[PrpCons.P3070107].ToString());
            item.SetAttribute("name", row[PrpCons.P3070205].ToString());
            item.SetAttribute("title", row[PrpCons.P3070108].ToString());
            item.SetAttribute("path", row[PrpCons.P3070109].ToString());
            item.SetAttribute("short", row[PrpCons.P3070104].ToString());
            node.AppendChild(item);
        }

        dba.reset();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid"></param>
    /// <param name="uri"></param>
    /// <param name="doc"></param>
    /// <param name="top"></param>
    private static void Detail(DBAccess dba, String sid, String uri, XmlDocument doc, XmlNode top)
    {
        if (StringUtil.isValidateHash(uri))
        {
            return;
        }
        dba.reset();
        dba.addTable(cons.io.db.prp.PrpCons.P3070100);
        dba.addTable(cons.io.db.prp.PrpCons.P3070200);
        dba.addWhere(cons.io.db.prp.PrpCons.P3070105, uri);
        dba.addWhere(cons.io.db.prp.PrpCons.P3070105, cons.io.db.prp.PrpCons.P3070204, false);
        dba.addWhere(cons.io.db.prp.PrpCons.P3070202, sid);

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            return;
        }
        DataRow row = dt.Rows[0];
        System.Xml.XmlElement node = doc.CreateElement("item");
        node.SetAttribute("feq", row[cons.io.db.prp.PrpCons.P3070201].ToString());
        node.SetAttribute("id", row[cons.io.db.prp.PrpCons.P3070204].ToString());
        node.SetAttribute("name", row[cons.io.db.prp.PrpCons.P3070205].ToString());
        node.SetAttribute("short", row[cons.io.db.prp.PrpCons.P3070104].ToString());
        node.SetAttribute("logo", row[cons.io.db.prp.PrpCons.P3070107].ToString());
        node.SetAttribute("title", row[cons.io.db.prp.PrpCons.P3070108].ToString());
        node.SetAttribute("uri", row[cons.io.db.prp.PrpCons.P3070109].ToString());
        node.SetAttribute("keywords", row[cons.io.db.prp.PrpCons.P307010A].ToString());
        node.SetAttribute("description", row[cons.io.db.prp.PrpCons.P307010B].ToString());
        node.SetAttribute("remark", row[cons.io.db.prp.PrpCons.P3070206].ToString());
        node.SetAttribute("update-date", row[cons.io.db.prp.PrpCons.P3070207].ToString());
        node.SetAttribute("create-date", row[cons.io.db.prp.PrpCons.P3070208].ToString());
        top.AppendChild(node);
    }

    /// <summary>
    /// 删除链接数据
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid">用户代码</param>
    /// <param name="uri">XML格式类别及链接数据</param>
    /// <param name="doc"></param>
    /// <param name="top"></param>
    private static void Remove(DBAccess dba, String sid, String uri, XmlDocument doc, XmlNode top)
    {
        var xml = new XmlDocument();
        xml.LoadXml(uri);

        XmlElement item;
        XmlNodeList list = xml.SelectNodes("/amonsoft/item");
        if (list == null)
        {
            item = doc.CreateElement("error");
            item.InnerText = "数据格式错误！";
            top.AppendChild(item);
            return;
        }

        String type;
        String hash;
        foreach (XmlNode node in list)
        {
            type = node.Attributes["kind"].InnerText;
            hash = node.Attributes["link"].InnerText;
            if (StringUtil.isValidateHash(type) || StringUtil.isValidateHash(hash))
            {
                item = doc.CreateElement("error");
                item.SetAttribute("kind", type);
                item.SetAttribute("link", hash);
                top.AppendChild(item);
                continue;
            }

            dba.addTable(PrpCons.P3070200);
            dba.addWhere(PrpCons.P3070202, sid);
            dba.addWhere(PrpCons.P3070203, type);
            dba.addWhere(PrpCons.P3070204, hash);
            dba.executeInsert();
            dba.reset();

            item = doc.CreateElement("sucess");
            item.SetAttribute("kind", type);
            item.SetAttribute("link", hash);
            top.AppendChild(item);
        }
    }

    /// <summary>
    /// 添加用户数据
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="sid">用户代码</param>
    /// <param name="uri">XML格式类别及链接数据</param>
    /// <param name="doc"></param>
    /// <param name="top"></param>
    private static void Append(DBAccess dba, String sid, String uri, XmlDocument doc, XmlNode top)
    {
        var xml = new XmlDocument();
        xml.LoadXml(uri);

        XmlElement item;
        XmlNodeList list = xml.SelectNodes("/amonsoft/item");
        if (list == null)
        {
            item = doc.CreateElement("error");
            item.InnerText = "数据格式错误！";
            top.AppendChild(item);
            return;
        }
        try
        {
            XmlElement failure = doc.CreateElement("failure");
            XmlElement success = doc.CreateElement("success");
            foreach (XmlNode node in list)
            {
                // 类别索引
                String kind = cons.wrp.link.LinkCons.LINK_USER_HASH;
                item = node.SelectSingleNode("kind") as XmlElement;
                if (item != null)
                {
                    kind = item.GetAttribute("id");// 用户指定类别索引
                    uri = item.GetAttribute("uri");// 上级类别索引
                    if (!StringUtil.isValidateHash(uri))
                    {
                        uri = cons.wrp.link.LinkCons.LINK_HASH + sid;
                    }
                    String name = item.GetAttribute("name");// 类别名称
                    String tips = item.GetAttribute("tips");// 类别提示
                    String value = item.GetAttribute("value");// 类别键值
                    String desc = item.GetAttribute("remark");// 类别说明
                    kind = rmp.comn.info.C2010000.Save(dba, kind, sid, uri, name, tips, value, desc, 0);

                    item = doc.CreateElement("kind");
                    item.SetAttribute("name", name);
                    // 类别添加错误
                    if (!StringUtil.isValidateHash(kind))
                    {
                        item.SetAttribute("status", "failure");
                        item.SetAttribute("message", "类别添加失败！");
                        failure.AppendChild(item);
                        continue;
                    }
                    item.SetAttribute("status", "success");
                    item.SetAttribute("message", "类别添加成功！");
                    success.AppendChild(item);
                }
                item = node.SelectSingleNode("link") as XmlElement;
                if (item != null)
                {
                    String link = item.GetAttribute("id");// 用户指定链接索引
                    uri = item.GetAttribute("uri");// 链接类别
                    if (!StringUtil.isValidateHash(uri))
                    {
                        uri = kind;
                    }
                    String name = item.GetAttribute("name");// 链接名称
                    String path = item.GetAttribute("path");// 链接路径
                    String desc = item.GetAttribute("remark");// 链接说明
                    String temp = Link.Save(dba, "13070000", null, path, desc, false);

                    item = doc.CreateElement("link");
                    item.SetAttribute("name", name);
                    // 链接添加错误
                    if (!StringUtil.isValidateHash(temp))
                    {
                        item.SetAttribute("status", "failure");
                        item.SetAttribute("message", "链接添加失败！");
                        failure.AppendChild(item);
                        continue;
                    }

                    if (StringUtil.isValidateHash(link))
                    {
                        // 更新已有数据
                        dba.reset();
                        dba.addTable(PrpCons.P3070200);
                        dba.addParam(PrpCons.P3070204, temp);
                        dba.addParam(PrpCons.P3070207, cons.EnvCons.SQL_NOW, false);
                        dba.addWhere(PrpCons.P3070202, sid);
                        dba.addWhere(PrpCons.P3070203, uri);
                        dba.addWhere(PrpCons.P3070204, link);

                        item.SetAttribute("status", "success");
                        item.SetAttribute("message", "链接更新成功：" + dba.executeUpdate());
                        success.AppendChild(item);
                    }
                    else
                    {
                        // 添加分类链接
                        link = temp;
                        dba.reset();
                        dba.addTable(PrpCons.P3070200);
                        dba.addParam(PrpCons.P3070205, WrpUtil.text2Db(name));
                        dba.addParam(PrpCons.P3070206, WrpUtil.text2Db(desc));
                        dba.addParam(PrpCons.P3070207, cons.EnvCons.SQL_NOW, false);
                        dba.addWhere(PrpCons.P3070202, sid);
                        dba.addWhere(PrpCons.P3070203, uri);
                        dba.addWhere(PrpCons.P3070204, link);
                        if (dba.executeSelect().Rows.Count > 0)
                        {
                            item.SetAttribute("status", "success");
                            item.SetAttribute("message", "链接更新成功：" + dba.executeUpdate());
                            success.AppendChild(item);
                        }
                        else
                        {
                            dba.addParam(PrpCons.P3070201, 0);
                            dba.addParam(PrpCons.P3070202, sid);
                            dba.addParam(PrpCons.P3070203, uri);
                            dba.addParam(PrpCons.P3070204, link);
                            dba.addParam(PrpCons.P3070208, cons.EnvCons.SQL_NOW, false);

                            item.SetAttribute("status", "success");
                            item.SetAttribute("message", "链接新增成功：" + dba.executeInsert());
                            success.AppendChild(item);
                        }
                    }
                }
            }
            top.AppendChild(success);
            top.AppendChild(failure);
        }
        catch (Exception exp)
        {
            item = doc.CreateElement("error");
            item.InnerText = exp.Message;
            top.AppendChild(item);
        }
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}