<%@ WebHandler Language="C#" Class="soft0001" %>

using System;
using System.Web;

/// <summary>
/// 获取指定标记的软件相关信息
/// SID：软件标记ID
/// </summary>
public class soft0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";

        System.Xml.XmlDocument document = new System.Xml.XmlDocument();
        document.CreateXmlDeclaration("1.0", "UTF-8", "yes");

        System.Xml.XmlElement root = document.CreateElement("amonsoft");
        document.AppendChild(root);

        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (rmp.util.StringUtil.isValidateCode(sid))
        {
            rmp.io.db.DBAccess dba = new rmp.io.db.DBAccess();
            dba.addTable(cons.io.db.comn.ComnCons.C0010100);
            dba.addWhere(cons.io.db.comn.ComnCons.C0010104, rmp.util.WrpUtil.text2Db(sid));
            dba.addSort(cons.io.db.comn.ComnCons.C0010101, false);
            dba.addLimit(1);

            System.Data.DataTable dt = dba.executeSelect();
            if (dt != null && dt.Rows.Count == 1)
            {
                System.Data.DataRow row = dt.Rows[0];
                System.Xml.XmlElement node;

                node = document.CreateElement("code");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010104];
                root.AppendChild(node);

                node = document.CreateElement("name");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010106];
                root.AppendChild(node);

                node = document.CreateElement("version");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010105];
                root.AppendChild(node);

                node = document.CreateElement("strategy");
                node.InnerText = rmp.wrp.soft.Soft.GetStrategy((int)row[cons.io.db.comn.ComnCons.C0010102]);
                root.AppendChild(node);

                node = document.CreateElement("publishDate");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010107];
                root.AppendChild(node);

                node = document.CreateElement("abstract");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010108];
                root.AppendChild(node);

                node = document.CreateElement("logo");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010109];
                root.AppendChild(node);

                node = document.CreateElement("screenshot");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C001010A];
                root.AppendChild(node);

                node = document.CreateElement("homepage");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C001010B];
                root.AppendChild(node);

                node = document.CreateElement("bbs");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C001010C];
                root.AppendChild(node);

                node = document.CreateElement("blog");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C001010D];
                root.AppendChild(node);

                node = document.CreateElement("project");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C001010E];
                root.AppendChild(node);

                node = document.CreateElement("download");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C001010F];
                root.AppendChild(node);

                node = document.CreateElement("online");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010110];
                root.AppendChild(node);

                node = document.CreateElement("webkit");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010111];
                root.AppendChild(node);

                node = document.CreateElement("introduce");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010112];
                root.AppendChild(node);

                node = document.CreateElement("features");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010113];
                root.AppendChild(node);

                node = document.CreateElement("annotation");
                node.InnerText = "" + row[cons.io.db.comn.ComnCons.C0010114];
                root.AppendChild(node);
            }
        }

        System.IO.Stream stream = context.Response.OutputStream;
        document.Save(stream);
        stream.Flush();
        stream.Close();

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