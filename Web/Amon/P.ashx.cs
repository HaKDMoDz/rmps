using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Xml;
using Me.Amon.Code.Model;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.M;
using Me.Amon.Open.V1.Web.Pcs;

namespace Me.Amon
{
    /// <summary>
    /// Pages 的摘要说明
    /// </summary>
    public class P : IHttpHandler, IRequiresSessionState
    {
        private const string ROOT = "/" + Web.PAGE_NAME;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var type = context.Request["t"];

            OAuthToken token;

            //var c = context.Request["c"];
            //// 间接访问当前地址
            //if (string.IsNullOrWhiteSpace(c))
            //{
            // 加载用户授权
            var user = UserModel.Current(context.Session);
            var page = context.Session[Web.SESSION_META] as MMeta;
            if (page == null || page.Token == null)
            {
                if (type == "cat")
                {
                    context.Response.Write("[{ id:'0', pId:'0', name:'" + Web.PAGE_NAME + "', isParent:true, open:true}]");
                }
                else
                {
                    LoadDef(context);
                }
                context.Response.End();
                return;
            }
            token = page.Token;
            //}
            //// 直接访问当前地址
            //else if (CharUtil.IsValidateCode(c))
            //{
            //    token = Web.LoadToken(c, "kuaipan");
            //}
            //else
            //{
            //    return;
            //}

            var consumer = OAuthConsumer.KuaipanConsumer();
            var client = new KuaipanClient(consumer, token, true);

            // 加载页面目录
            if (type == "cat")
            {
                LoadCat(context.Response, client);
                context.Response.End();
                return;
            }

            // 获取要显示的页面
            var file = context.Request["f"];
            if (string.IsNullOrEmpty(file))
            {
                file = page.Default;
                if (string.IsNullOrWhiteSpace(file))
                {
                    file = LoadCfg(context, client);
                    if (string.IsNullOrWhiteSpace(file))
                    {
                        file = "/index.html";
                    }
                }
                page.Default = file;
            }
            if (file[0] != '/')
            {
                file = '/' + file;
            }

            var ext = (Path.GetExtension(file) ?? "").ToLower();
            if (ext[0] == '.')
            {
                ext = ext.Substring(1);
            }

            bool iok;
            //if (type == "src")
            //{
            switch (ext)
            {
                case "htm":
                case "html":
                    iok = LoadObj(context, client, file, "text/html");
                    break;
                case "txt":
                    iok = LoadTxt(context, client, file);
                    break;
                case "log":
                    iok = LoadTxt(context, client, file);
                    break;
                case "ini":
                    iok = LoadTxt(context, client, file);
                    break;
                case "as3":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushAS3.js\"></script>");
                    break;
                case "cpp":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushCpp.js\"></script>");
                    break;
                case "cs":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushCSharp.js\"></script>");
                    break;
                case "css":
                    if (type == "src")
                    {
                        iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushCss.js\"></script>");
                    }
                    else
                    {
                        iok = LoadObj(context, client, file, "text/css");
                    }
                    break;
                case "java":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushJava.js\"></script>");
                    break;
                case "jfx":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushJavaFX.js\"></script>");
                    break;
                case "js":
                    if (type == "src")
                    {
                        iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushJScript.js\"></script>");
                    }
                    else
                    {
                        iok = LoadObj(context, client, file, "text/javascript");
                    }
                    break;
                case "php":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushPhp.js\"></script>");
                    break;
                case "py":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushPython.js\"></script>");
                    break;
                case "rb":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushRuby.js\"></script>");
                    break;
                case "saas":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushSass.js\"></script>");
                    break;
                case "sql":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushSql.js\"></script>");
                    break;
                case "vb":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushVb.js\"></script>");
                    break;
                case "xml":
                    iok = LoadSrc(context, client, file, ext, "<script type=\"text/javascript\" src=\"/_js/sh/scripts/shBrushXml.js\"></script>");
                    break;
                default:
                    iok = LoadTxt(context, client, file);
                    break;
            }
            //}
            //else
            //{
            //    switch (ext)
            //    {
            //        case "htm":
            //        case "html":
            //            iok = LoadHtm(context, client, file);
            //            break;
            //        case "txt":
            //            iok = LoadTxt(context, client, file);
            //            break;
            //        case "log":
            //            iok = LoadTxt(context, client, file);
            //            break;
            //        case "ini":
            //            iok = LoadTxt(context, client, file);
            //            break;
            //        default:
            //            iok = true;
            //            break;
            //    }
            //}


            // 加载用户指定页面
            if (!iok)
            {
                LoadDef(context);
            }
            context.Response.End();
        }

        #region 目录相关
        /// <summary>
        /// 加载目录信息
        /// </summary>
        /// <param name="response"></param>
        private void LoadCat(HttpResponse response, PcsClient client)
        {
            response.ContentType = "text/javascript";

            StringBuilder buffer = new StringBuilder();
            buffer.Append("[{id:'0', pId:'0', name:'" + Web.PAGE_NAME + "', isParent:true, open:true}");
            LoadSub(buffer, client, ROOT, "0", false);
            buffer.Append("];");
            response.Write(buffer.ToString());
        }

        private void LoadSub(StringBuilder buffer, PcsClient client, string path, string root, bool open)
        {
            var metas = client.ListMeta(path);
            SortCat(metas);

            int id = 0;
            foreach (var meta in metas)
            {
                if (meta.GetMetaName().ToLower() == "amon.me")
                {
                    continue;
                }

                id += 1;

                path = meta.GetMeta();
                if (path != null)
                {
                    buffer.Append(",{");
                    buffer.Append("id:'").Append(root).Append('-').Append(id).Append("',");
                    buffer.Append("pId:'").Append(root).Append("',");
                    buffer.Append("name:'").Append(meta.GetMetaName()).Append("',");
                    if (meta.GetMetaType() == AMeta.META_TYPE_FOLDER)
                    {
                        buffer.Append("isParent:true, open:").Append(open ? "true" : "false");
                    }
                    else
                    {
                        buffer.Append("v:'").Append(path.Substring(ROOT.Length)).Append("'");
                    }
                    buffer.Append("}");
                }
                if (meta.GetMetaType() == AMeta.META_TYPE_FOLDER)
                {
                    LoadSub(buffer, client, meta.GetMeta(), root + "-" + id, false);
                }
            }
        }

        private void SortCat(List<AMeta> metas)
        {
            AMeta meta;
            AMeta temp;
            string name;
            for (int i = 0, j = metas.Count; i < j; i += 1)
            {
                meta = metas[i];
                name = meta.GetMetaName().ToLower();
                for (int m = i + 1; m < j; m += 1)
                {
                    temp = metas[m];
                    if (meta.GetMetaType() < temp.GetMetaType()
                        || (meta.GetMetaType() == temp.GetMetaType() && name.CompareTo(temp.GetMetaName().ToLower()) > 0))
                    {
                        metas[i] = metas[m];
                        metas[m] = meta;
                        meta = metas[i];
                    }
                }
            }
        }
        #endregion

        #region 文件相关
        /// <summary>
        /// 加载用户配置文件
        /// </summary>
        /// <param name="context"></param>
        /// <param name="code"></param>
        private string LoadCfg(HttpContext context, PcsClient client)
        {
            var pcsRequest = client.Download(ROOT + "/Page.Me");

            HttpWebResponse pcsResponse = null;
            try
            {
                string page = "";
                pcsResponse = pcsRequest.GetResponse() as HttpWebResponse;
                if (pcsResponse.ContentLength > -1)
                {
                    XmlDocument xmlReader = new XmlDocument();
                    xmlReader.Load(pcsResponse.GetResponseStream());
                    var node = xmlReader.SelectSingleNode("/Amon");
                    if (node == null || node.Attributes["Ver"].InnerText != "1")
                    {
                        return page;
                    }
                    node = node.SelectSingleNode("Page");
                    if (node == null)
                    {
                        return page;
                    }
                    page = node.Attributes["Default"].InnerText;
                }
                return page;
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                if (pcsResponse != null)
                {
                    pcsResponse.Close();
                }
            }
        }

        /// <summary>
        /// 加载系统默认页面
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private void LoadDef(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write(Web.DefLog());
        }

        /// <summary>
        /// 加载文本
        /// </summary>
        /// <param name="context"></param>
        /// <param name="code"></param>
        private bool LoadTxt(HttpContext context, PcsClient client, string file)
        {
            var response = context.Response;
            response.ContentType = "text/html";

            var pcsRequest = client.Download(ROOT + file);

            HttpWebResponse pcsResponse = null;
            StreamReader pcsReader = null;
            try
            {
                pcsResponse = pcsRequest.GetResponse() as HttpWebResponse;
                long size = pcsResponse.ContentLength;
                if (size > -1)
                {
                    if (size > 2097152)
                    {
                        response.Write("您要查看的文件过大！");
                        return true;
                    }

                    StringBuilder builder = new StringBuilder((int)size + 1024);
                    builder.Append("<!DOCTYPE>");
                    builder.Append("<html>");
                    builder.Append("<head>");
                    //builder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=").Append(pcsResponse.ContentEncoding).Append("\" />");
                    builder.Append("<title>文本文档</title>");
                    builder.Append("<style type=\"text/css\">body{background: #fff;color: #000;font-size: 12px;font-family: 宋体, 新宋体, 微软雅黑, \"Helvetica Neue\" , \"Lucida Grande\" , \"Segoe UI\" , Arial, Helvetica, Verdana, sans-serif;}</style>");
                    builder.Append("</head>");
                    builder.Append("<body>");
                    builder.Append("<pre>");
                    pcsReader = new StreamReader(pcsResponse.GetResponseStream());

                    int cnt;
                    char[] buf = new char[10240];
                    cnt = pcsReader.Read(buf, 0, buf.Length);
                    while (cnt > 0)
                    {
                        DoPrint(builder, buf, cnt);
                        cnt = pcsReader.Read(buf, 0, buf.Length);
                    }

                    builder.Append("</pre>");
                    builder.Append("</body>");
                    builder.Append("</html>");

                    response.Write(builder.ToString());
                }
                return true;
            }
            catch (Exception)
            {
                //response.Write(exp.Message);
                return false;
            }
            finally
            {
                if (pcsReader != null)
                {
                    pcsReader.Close();
                }
                if (pcsResponse != null)
                {
                    pcsResponse.Close();
                }
            }
        }

        /// <summary>
        /// 加载网志
        /// </summary>
        /// <returns></returns>
        private bool LoadObj(HttpContext context, PcsClient client, string file, string type)
        {
            var response = context.Response;
            response.ContentType = type;

            var pcsRequest = client.Download(ROOT + file);

            HttpWebResponse pcsResponse = null;
            StreamReader pcsReader = null;
            try
            {
                pcsResponse = pcsRequest.GetResponse() as HttpWebResponse;
                long size = pcsResponse.ContentLength;
                if (size > -1)
                {
                    pcsReader = new StreamReader(pcsResponse.GetResponseStream());

                    int cnt;
                    char[] buf = new char[10240];
                    cnt = pcsReader.Read(buf, 0, buf.Length);
                    while (cnt > 0)
                    {
                        response.Write(buf, 0, cnt);
                        cnt = pcsReader.Read(buf, 0, buf.Length);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //response.Write(exp.Message);
                return false;
            }
            finally
            {
                if (pcsReader != null)
                {
                    pcsReader.Close();
                }
                if (pcsResponse != null)
                {
                    pcsResponse.Close();
                }
            }
        }

        /// <summary>
        /// 加载代码
        /// </summary>
        /// <returns></returns>
        private bool LoadSrc(HttpContext context, PcsClient client, string file, string ext, string css)
        {
            var response = context.Response;
            response.ContentType = "text/html";

            var pcsRequest = client.Download(ROOT + file);

            HttpWebResponse pcsResponse = null;
            StreamReader pcsReader = null;
            try
            {
                pcsResponse = pcsRequest.GetResponse() as HttpWebResponse;
                long size = pcsResponse.ContentLength;
                if (size > -1)
                {
                    if (size > 2097152)
                    {
                        response.Write("您要查看的文件过大！");
                        return true;
                    }

                    StringBuilder builder = new StringBuilder((int)size + 1024);
                    builder.Append("<!DOCTYPE>");
                    builder.Append("<html>");
                    builder.Append("<head>");
                    //builder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=").Append(pcsResponse.ContentEncoding).Append("\" />");
                    builder.Append("<title>源码文档</title>");
                    builder.Append("<script type=\"text/javascript\" src=\"/_js/sh/scripts/shCore.js\"></script>");
                    builder.Append(css);
                    builder.Append("<link type=\"text/css\" rel=\"stylesheet\" href=\"/_js/sh/styles/shCoreDefault.css\" />");
                    builder.Append("<style type=\"text/css\">body{background: #fff;color: #000;font-size: 12px;font-family: 宋体, 新宋体, 微软雅黑, \"Helvetica Neue\" , \"Lucida Grande\" , \"Segoe UI\" , Arial, Helvetica, Verdana, sans-serif;}</style>");
                    builder.Append("</head>");
                    builder.Append("<body>");
                    builder.Append("<pre class=\"brush:").Append(ext).Append(";toolbar:false;\">");
                    pcsReader = new StreamReader(pcsResponse.GetResponseStream());

                    int cnt;
                    char[] buf = new char[10240];
                    cnt = pcsReader.Read(buf, 0, buf.Length);
                    while (cnt > 0)
                    {
                        DoPrint(builder, buf, cnt);
                        cnt = pcsReader.Read(buf, 0, buf.Length);
                    }

                    builder.Append("</pre>");
                    builder.Append("<script type=\"text/javascript\">SyntaxHighlighter.all();</script>");
                    builder.Append("</body>");
                    builder.Append("</html>");

                    response.Write(builder.ToString());
                }
                return true;
            }
            catch (Exception)
            {
                //response.Write(exp.Message);
                return false;
            }
            finally
            {
                if (pcsReader != null)
                {
                    pcsReader.Close();
                }
                if (pcsResponse != null)
                {
                    pcsResponse.Close();
                }
            }
        }

        private void DoPrint(StringBuilder builder, char[] buf, int cnt)
        {
            char c;
            for (int i = 0; i < cnt; i += 1)
            {
                c = buf[i];
                if (c == '<')
                {
                    builder.Append("&lt;");
                    continue;
                }
                if (c == '>')
                {
                    builder.Append("&gt;");
                    continue;
                }
                builder.Append(c);
            }
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}