using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Me.Amon.Code.Model;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.M;
using Me.Amon.Open.V1.Web.Pcs;

namespace Me.Amon
{
    /// <summary>
    /// Imgd1 的摘要说明
    /// </summary>
    public class Img : IHttpHandler
    {
        private const string ROOT = "/" + Web.IMGS_NAME;

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
                    context.Response.Write("[{ id:'0', pId:'0', name:'" + Web.PAGE_NAME + "', isParent:true}]");
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

            if (type == "cat")
            {
                LoadCat(context.Response, client);
                context.Response.End();
                return;
            }

            var file = context.Request["f"];
            var ext = (Path.GetExtension(file) ?? "").ToLower();
            if (ext[0] == '.')
            {
                ext = ext.Substring(1);
            }

            if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "gif")
            {
                LoadImg(context, client, file, ext);
                context.Response.End();
                return;
            }
        }

        private void LoadDef(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            var img = Web.DefImg();
            context.Response.OutputStream.Write(img, 0, img.Length);
        }

        private bool LoadCat(HttpResponse response, PcsClient client)
        {
            response.ContentType = "text/javascript";

            StringBuilder buffer = new StringBuilder();
            buffer.Append("[{id:'0', pId:'0', name:'" + Web.PAGE_NAME + "', isParent:true, open:true}");
            LoadSub(buffer, client, ROOT, "0", false);
            buffer.Append("];");
            response.Write(buffer.ToString());
            return true;
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

        private void LoadIco()
        {
        }

        private bool LoadImg(HttpContext context, PcsClient client, string file, string ext)
        {
            var webResponse = context.Response;
            webResponse.ContentType = "image/" + ext;

            var pcsRequest = client.Download(ROOT + file);

            HttpWebResponse pcsResponse = null;
            Stream pcsStream = null;
            Stream webStream = null;
            try
            {
                pcsResponse = pcsRequest.GetResponse() as HttpWebResponse;
                long size = pcsResponse.ContentLength;
                if (size > -1)
                {
                    if (size > 2097152)
                    {
                        webResponse.Write("您要查看的文件过大！");
                        return true;
                    }

                    webStream = webResponse.OutputStream;
                    pcsStream = pcsResponse.GetResponseStream();
                    byte[] buf = new byte[4096];
                    int len = pcsStream.Read(buf, 0, buf.Length);
                    while (len > 0)
                    {
                        webStream.Write(buf, 0, len);
                        len = pcsStream.Read(buf, 0, buf.Length);
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
                if (webStream != null)
                {
                    webStream.Close();
                }
                if (pcsStream != null)
                {
                    pcsStream.Close();
                }
                if (pcsResponse != null)
                {
                    pcsResponse.Close();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}