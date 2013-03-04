﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using Me.Amon.Http;
using Me.Amon.Open.M;
using Me.Amon.Pcs;
using Me.Amon.Pcs.M;
using Newtonsoft.Json;

namespace Me.Amon.Open.V1.Web.Pcs
{
    public class KuaipanClient : OAuthV1Client, PcsClient
    {
        private string _Root;
        private string _Result;

        #region 构造函数
        public KuaipanClient(OAuthConsumer consumer, bool isRoot)
            : base(consumer)
        {
            _Root = isRoot ? "kuaipan" : "app_folder";

            _Server = new KuaipanServer();
        }

        public KuaipanClient(OAuthConsumer consumer, OAuthToken token, bool isRoot)
            : base(consumer)
        {
            _Root = isRoot ? "kuaipan" : "app_folder";

            Token = token;
            _Server = new KuaipanServer();

            Name = "金山快盘";
            Root = "kuaipan:/";
            //Icon = Image.FromFile(@"D:\Temp\i1\Icon.png");
        }
        #endregion

        public override string DebugResult { get { return _Result; } }

        #region 权限认证
        public override bool RequestToken()
        {
            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(_Server.RequestTokenUrl)));

            byte[] r = _Server.Get(_Server.RequestTokenUrl, GenBaseParams());
            if (r == null || r.Length < 1)
            {
                return false;
            }

            Token = JsonConvert.DeserializeObject<KuaipanToken>(GetString(r));
            ResetParams();

            return true;
        }

        public override string GetAuthorizeUrl()
        {
            return string.Format(_Server.VerifierUrl, Token.Token);
        }

        public override bool AccessToken(string verifier)
        {
            if (Token == null)
            {
                return false;
            }
            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(_Server.AccessTokenUrl)));

            byte[] r = _Server.Get(_Server.AccessTokenUrl, GenBaseParams());
            if (r == null || r.Length < 1)
            {
                return false;
            }

            _Result = GetString(r);
            Token = JsonConvert.DeserializeObject<KuaipanToken>(_Result);
            ResetParams();

            return true;
        }
        #endregion

        #region 函数重写
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

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(_Server.ProfileUrl)));

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
            string url = string.Format(KuaipanServer.LIST_META, _Root, meta.GetMetaPath());
            return ListMeta(url);
        }

        public List<AMeta> ListMeta(string path)
        {
            ResetParams();
            path = string.Format(KuaipanServer.LIST_META, _Root, GetPath(path));

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(path)));

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
            path = string.Format(KuaipanServer.LIST_META, _Root, GetPath(path));

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(path)));

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
            string url = string.Format(KuaipanServer.SHARE_META, _Root, meta.GetMetaPath());

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(_Server.RequestTokenUrl)));

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

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("path", Combine(path, name));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("path", Combine(path, meta));
            AddParam("to_recycle", "true");
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("from_path", meta.GetMeta());
            AddParam("to_path", Combine(dstPath, dstName));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("from_path", meta.GetMeta());
            AddParam("to_path", Combine(dstPath, dstName));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("from_copy_ref", metaRef);
            AddParam("to_path", Combine(dstPath, dstName));
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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
            string url = string.Format(KuaipanServer.COPYREF, _Root, meta.GetMeta());

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            return JsonConvert.DeserializeObject<KuaipanMetaRef>(t);
        }

        public string Upload(string path)
        {
            ResetParams();
            string url = KuaipanServer.UPLOAD;

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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
                _Result = uri.stat;
                return null;
            }

            ResetParams();
            url = string.Format("{0}/1/fileops/upload_file", uri.url);

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("overwrite", "true");
            AddParam("path", path);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url, "POST")));

            url += url.IndexOf('?') >= 0 ? '&' : '?';
            url += GenBaseParams();

            return url;
        }

        public HttpWebRequest Download(string meta)
        {
            ResetParams();
            string url = KuaipanServer.DOWNLOAD;

            GenOAuthBaseParams(KuaipanServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam("root", _Root);
            AddParam("path", meta);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(url)));

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
                builder.Append('&');
            }

            return builder.ToString(0, builder.Length - 1);
        }
        #endregion
    }
}