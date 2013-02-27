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
using Me.Amon.Util;

namespace Me.Amon
{
    /// <summary>
    /// Pages 的摘要说明
    /// </summary>
    public class Pages : IHttpHandler, IRequiresSessionState
    {
        private const string ROOT = "/我的网站";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;

            // 目标用户判断
            var code = context.Request["c"];
            if (!CharUtil.IsValidateCode(code))
            {
                LoadDef(context);
                response.End();
                return;
            }

            // 加载用户授权
            var user = UserModel.Current(context.Session);
            var page = context.Session["amon_page"] as MPage;
            if (page == null)
            {
                page = new MPage();
                context.Session["amon_page"] = page;
            }
            if (page.Token == null || page.Token.Code != code)
            {
                var token = Web.LoadToken(code, OAuthClient.KUAIPAN);
                if (token == null)
                {
                    LoadDef(context);
                    response.End();
                    return;
                }
                page.Token = token;
            }

            var consumer = OAuthConsumer.KuaipanConsumer();
            var client = new KuaipanClient(consumer, page.Token, true);

            // 加载页面目录
            var type = context.Request["t"];
            if (type == "cat")
            {
                LoadCat(response, client);
                response.End();
                return;
            }

            //if (type == "log")
            //{
            //}

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

            // 加载用户指定页面
            if (!LoadTxt(context, client, file))
            {
                LoadDef(context);
            }
            response.End();
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
            buffer.Append("[{ id:\"0\", pId:\"0\", name:\"我的网站\", t:\"我的网站\", open:true}");
            LoadSub(buffer, client, ROOT, "0");
            buffer.Append("];");
            response.Write(buffer.ToString());
        }

        private void LoadSub(StringBuilder buffer, PcsClient client, string path, string root)
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
                    buffer.Append("id:\"").Append(root).Append('-').Append(id).Append("\",");
                    buffer.Append("pId:\"").Append(root).Append("\",");
                    buffer.Append("name:\"").Append(meta.GetMetaName()).Append("\",");
                    buffer.Append("t:\"").Append(meta.GetMetaName()).Append("\",");
                    buffer.Append("v:\"").Append(path.Substring(ROOT.Length)).Append("\"");
                    if (meta.GetMetaType() == AMeta.META_TYPE_FOLDER)
                    {
                        buffer.Append(",open:true");
                    }
                    buffer.Append("}");
                }
                if (meta.GetMetaType() == AMeta.META_TYPE_FOLDER)
                {
                    LoadSub(buffer, client, meta.GetMeta(), root + "-" + id);
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
            var file = context.Server.MapPath("/docs/Page.htm");
            string page = File.ReadAllText(file);
            context.Response.Write(page);
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
                if (pcsResponse.ContentLength > -1)
                {
                    pcsReader = new StreamReader(pcsResponse.GetResponseStream());

                    int count;
                    char[] buffer = new char[10240];
                    count = pcsReader.Read(buffer, 0, buffer.Length);
                    while (count > 0)
                    {
                        response.Write(buffer, 0, count);
                        count = pcsReader.Read(buffer, 0, buffer.Length);
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
        /// 加载网志
        /// </summary>
        /// <returns></returns>
        private bool LoadHtm()
        {
            return true;
        }

        /// <summary>
        /// 加载代码
        /// </summary>
        /// <returns></returns>
        private bool LoadSrc()
        {
            return true;
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