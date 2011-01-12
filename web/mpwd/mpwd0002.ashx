<%@ WebHandler Language="C#" Class="mpwd0002" %>

using System;
using System.Web;

public class mpwd0002 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";

        System.Xml.XmlDocument document = new System.Xml.XmlDocument();
        document.CreateXmlDeclaration("1.0", "UTF-8", "yes");

        System.Xml.XmlElement root = document.CreateElement("amonsoft");
        document.AppendChild(root);

        System.Xml.XmlElement node;

        node = document.CreateElement("code");
        node.InnerText = "130F0000";
        root.AppendChild(node);

        node = document.CreateElement("version");
        node.InnerText = "V3.5.4.6";
        root.AppendChild(node);

        node = document.CreateElement("server");
        System.Xml.XmlAttribute attr = document.CreateAttribute("type");
        attr.InnerText = "http";//ftp,socket
        node.Attributes.Append(attr);
        root.AppendChild(node);

        System.Xml.XmlElement temp = document.CreateElement("url");
        temp.InnerText = "http://magicpwd.com/{path}{file}";
        node.AppendChild(temp);

        node = document.CreateElement("files");
        root.AppendChild(node);
        root = node;

        int rnd = new Random().Next(3);
        for (int i = 0; i < 10; i += 1)
        {
            node = document.CreateElement("file");
            root.AppendChild(node);

            temp = document.CreateElement("name");
            temp.InnerText = "mpwd0001.png";
            node.AppendChild(temp);

            temp = document.CreateElement("version");
            temp.InnerText = "V1.0.0." + i;
            node.AppendChild(temp);

            temp = document.CreateElement("operation");
            temp.InnerText = ((i + rnd) % 3 - 1).ToString();
            node.AppendChild(temp);

            temp = document.CreateElement("remote-path");
            temp.InnerText = "data/mpwd/";
            node.AppendChild(temp);

            temp = document.CreateElement("locale-path");
            temp.InnerText = "temp" + i;
            node.AppendChild(temp);
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
            return true;
        }
    }

}