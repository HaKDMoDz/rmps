﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Http;
using Me.Amon.Pcs;
using Me.Amon.Pcs.M;
using Newtonsoft.Json;

namespace Me.Amon.Open.V1.App.Pcs
{
    public class KuaipanClient : OAuthV1Client, PcsClient
    {
        #region 构造函数
        public KuaipanClient(OAuthConsumer consumer)
            : base(consumer)
        {
            _Server = new KuaipanServer();
        }

        public KuaipanClient(OAuthConsumer consumer, OAuthTokenV1 token)
            : base(consumer)
        {
            Token = token;
            _Server = new KuaipanServer();

            Name = "金山快盘";
            Root = "kuaipan:/";
            //Icon = Image.FromFile(@"D:\Temp\i1\Icon.png");
        }
        #endregion

        #region 权限认证
        public override bool RequestToken()
        {
            PrepareParams();
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(_Server.RequestTokenUrl, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            Token = JsonConvert.DeserializeObject<OAuthTokenV1>(t);
            ResetParams();

            return true;
        }

        public override bool Authorize()
        {
            string url = string.Format(_Server.VerifierUrl, Token.oauth_token);
            UI.OAuth auth = new UI.OAuth(url);
            if (DialogResult.OK != auth.ShowDialog())
            {
                return false;
            }
            //Token.oauth_token = auth.Token;
            return true;
        }

        public override string GetAuthorizeUrl()
        {
            return string.Format(_Server.VerifierUrl, Token.oauth_token);
        }

        public override bool AccessToken()
        {
            PrepareParams();
            if (Token == null)
            {
                return false;
            }
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.AccessTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(_Server.AccessTokenUrl, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            Token = JsonConvert.DeserializeObject<OAuthTokenV1>(t);
            ResetParams();

            return true;
        }
        #endregion

        #region 函数重写
        protected override string GenerateBaseString(string uri, string method = "GET")
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in _Params)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    continue;
                }

                builder.Append(Uri.EscapeDataString(item.Key));
                builder.Append('=');
                builder.Append(Uri.EscapeDataString(item.Value));
                builder.Append('&');
            }

            string temp = Uri.EscapeDataString(builder.ToString(0, builder.Length - 1));
            return string.Format("{0}&{1}&{2}", method, Uri.EscapeDataString(uri), temp);
        }

        protected override string GetString(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer);
        }
        #endregion

        #region 业务函数
        public string Name { get; set; }

        public string Root { get; set; }

        public Image Icon { get; set; }

        public OAuthPcsAccount Account()
        {
            ResetParams();

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.ProfileUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(_Server.ProfileUrl, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            var a = JsonConvert.DeserializeObject<KuaipanAccount>(t);

            return a;
        }

        public string GetPath(string key)
        {
            switch (key)
            {
                case CPcs.PATH_LIB_DOCUMENTS:
                    return key;
                case CPcs.PATH_LIB_AUDIOS:
                    return key;
                case CPcs.PATH_LIB_PICTURES:
                    return key;
                case CPcs.PATH_LIB_VIDEOS:
                    return key;
                case CPcs.PATH_ALL:
                    return "/";
                case CPcs.PATH_BIN:
                    return key;
                default:
                    return Uri.EscapeUriString(key);
            }
        }

        public List<AMeta> ListMeta(AMeta meta)
        {
            string url = string.Format(KuaipanServer.LIST_META, KuaipanServer.ROOT_NAME, meta.GetMetaPath());
            return ListMeta(url);
        }

        public List<AMeta> ListMeta(string path)
        {
            ResetParams();
            path = string.Format(KuaipanServer.LIST_META, KuaipanServer.ROOT_NAME, GetPath(path));

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(path)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(path, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            var meta = JsonConvert.DeserializeObject<KuaipanMeta>(t);
            return meta.SubMetas();
        }

        public AMeta MetaData(string path)
        {
            ResetParams();
            path = string.Format(KuaipanServer.LIST_META, KuaipanServer.ROOT_NAME, GetPath(path));

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(path)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(path, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            return JsonConvert.DeserializeObject<KuaipanMeta>(t);
        }

        public string ShareMeta(AMeta meta)
        {
            ResetParams();
            string url = string.Format(KuaipanServer.SHARE_META, KuaipanServer.ROOT_NAME, meta.GetMetaPath());

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            // Jason

            return "";
        }

        public List<AMeta> History(AMeta meta)
        {
            return null;
        }

        public AMeta CreateFolder(string path, string name)
        {
            ResetParams();
            string url = KuaipanServer.CREATE_FOLDER;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("path", Combine(path, name));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            KuaipanMeta meta = JsonConvert.DeserializeObject<KuaipanMeta>(t);
            meta.name = name;
            meta.path = path;
            meta.type = "folder";

            return meta;
        }

        public bool Delete(string path, string meta)
        {
            ResetParams();
            string url = KuaipanServer.DELETE;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("path", Combine(path, meta));
            AddParam("to_recycle", "true");
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason

            return true;
        }

        public AMeta Moveto(AMeta meta, string dstPath, string dstName)
        {
            ResetParams();
            string url = KuaipanServer.MOVETO;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("from_path", meta.GetMeta());
            AddParam("to_path", Combine(dstPath, dstName));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            //t = GetString(r);
            //JsonConvert.DeserializeObject<CsMeta>(t);
            KuaipanMeta m1 = meta as KuaipanMeta;
            m1.path = dstPath;
            m1.name = dstName;
            return m1;
        }

        public AMeta Copyto(AMeta meta, string dstPath, string dstName)
        {
            ResetParams();
            string url = KuaipanServer.COPYTO;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("from_path", meta.GetMeta());
            AddParam("to_path", Combine(dstPath, dstName));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            KuaipanMeta m1 = meta as KuaipanMeta;
            KuaipanMeta m2 = JsonConvert.DeserializeObject<KuaipanMeta>(t);
            m2.root = m1.root;
            m2.path = dstPath;
            m2.name = dstName;
            m2.hash = m1.hash;
            m2.type = m1.type;
            m2.size = m1.size;
            m2.create_time = m1.create_time;
            m2.modify_time = m1.modify_time;
            return m2;
        }

        public AMeta Copyto(string metaRef, string dstPath, string dstName)
        {
            ResetParams();
            string url = KuaipanServer.COPYTO;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("from_copy_ref", metaRef);
            AddParam("to_path", Combine(dstPath, dstName));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            KuaipanMeta temp = JsonConvert.DeserializeObject<KuaipanMeta>(t);
            return temp;
        }

        public AMetaRef CopyRef(AMeta meta)
        {
            ResetParams();
            string url = string.Format(KuaipanServer.COPYREF, KuaipanServer.ROOT_NAME, meta.GetMeta());

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            return JsonConvert.DeserializeObject<KuaipanMetaRef>(t);
        }

        public TaskInfo NewUploadTask()
        {
            return new KuaipanUpload(this);
        }

        public string BeginUpload(TaskInfo info)
        {
            lock (_Params)
            {
                ResetParams();
                string url = KuaipanServer.UPLOAD;

                PrepareParams();
                AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
                SortParam();
                AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

                string t = GenBaseParams();
                byte[] r = _Server.Get(url, t);
                if (r == null || r.Length < 1)
                {
                    return null;
                }

                t = GetString(r);
                KuaipanMetaUrl uri = JsonConvert.DeserializeObject<KuaipanMetaUrl>(t);
                if (uri.stat != "OK")
                {
                    info.Message = uri.stat;
                    return null;
                }
                return uri.url;
            }
        }

        public string ChangeUploadUrl(string url, string path)
        {
            lock (_Params)
            {
                ResetParams();
                url = string.Format("{0}/1/fileops/upload_file", url);

                PrepareParams();
                AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
                AddParam("root", KuaipanServer.ROOT_NAME);
                AddParam("overwrite", "true");
                AddParam("path", path);
                SortParam();
                AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url, "POST")));

                url += url.IndexOf('?') >= 0 ? '&' : '?';
                url += GenBaseParams();

                return url;
            }
        }

        public TaskInfo NewDownloadTask()
        {
            return new KuaipanDownload(this);
        }

        public HttpWebRequest BeginDownload(KuaipanDownload task)
        {
            lock (_Params)
            {
                ResetParams();
                string url = KuaipanServer.DOWNLOAD;

                PrepareParams();
                AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
                AddParam("root", KuaipanServer.ROOT_NAME);
                AddParam("path", task.Meta);
                SortParam();
                AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

                string t = GenBaseParams();
                url += url.IndexOf("?") >= 0 ? '&' : '?';
                url += t;

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = new CookieContainer();
                request.Method = "GET";
                request.UserAgent = "User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.AllowWriteStreamBuffering = false;
                return request;
            }
        }

        public void Thumbnail()
        {
        }

        public string Parent(string path)
        {
            if (path == "/")
            {
                return path;
            }

            int idx = path.Length - 1;
            if (path[idx] == '/')
            {
                idx -= 1;
            }
            idx = path.LastIndexOf('/', idx);
            if (idx < 1)
            {
                return "/";
            }
            return path.Substring(0, idx);
        }

        public string Combine(string path, string meta)
        {
            if (path == CPcs.PATH_ALL)
            {
                path = "/";
            }

            if (path[path.Length - 1] != '/')
            {
                path += '/';
            }
            return path + meta;
        }

        public string GetFileName(string meta)
        {
            return System.IO.Path.GetFileName(meta);
        }

        public string Display(string path)
        {
            return "kuaipan://" + path;
        }
        #endregion

        #region 私有函数
        private void PrepareParams()
        {
            AddParam(OAuthConstants.OAUTH_SIGNATURE_METHOD, "HMAC-SHA1");

            AddParam(OAuthConstants.OAUTH_NONCE, KuaipanClient.GetOAuthNonce());
            //AddParam(OAuthConstants.OAUTH_NONCE, "ChcAPp5A");
            AddParam(OAuthConstants.OAUTH_TIMESTAMP, KuaipanClient.GetOAuthTimestamp());
            //AddParam(OAuthConstants.OAUTH_TIMESTAMP, "1354715324");
            AddParam(OAuthConstants.OAUTH_CONSUMER_KEY, Consumer.consumer_key);
            AddParam(OAuthConstants.OAUTH_VERSION, "1.0");

            //AddParam("path", "/test@kingsoft.com");
            //AddParam("root", "kuaipan");
        }

        private string GenBaseParams()
        {
            if (_Params.Count < 1)
            {
                return "";
            }

            StringBuilder builder = new StringBuilder();

            foreach (KeyValuePair<string, string> item in _Params)
            {
                builder.Append(HttpUtil.Escape(item.Key));
                builder.Append('=');
                builder.Append(HttpUtil.Escape(item.Value));
                //builder.Append(item.Value);
                builder.Append('&');
            }

            return builder.ToString(0, builder.Length - 1);
        }
        #endregion
    }
}