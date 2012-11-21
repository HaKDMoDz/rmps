 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Me.Amon.Pcs;
using Me.Amon.Pcs.M;
using Newtonsoft.Json;

namespace Me.Amon.Open.V1.App.Pcs
{
    public class KuaipanClient : OAuthV1Client, PcsClient
    {
        private Dictionary<long, KVItem> _Items;

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
            _Params.Sort(new NameValueComparer());
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
            UI.Auth auth = new UI.Auth(url);
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
            _Params.Sort(new NameValueComparer());
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
        protected override string GenerateBaseString(string uri)
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
            return string.Format("{0}&{1}&{2}", HttpMethod, Uri.EscapeDataString(uri), temp);
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
            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.ProfileUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(_Server.ProfileUrl, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            var a = JsonConvert.DeserializeObject<KuaipanAccount>(t);
            ResetParams();

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
                    return key;
            }
        }

        public List<AMeta> ListMeta(AMeta meta)
        {
            string url = string.Format(KuaipanServer.LIST_META, meta.GetMetaPath());
            return ListMeta(url);
        }

        public List<AMeta> ListMeta(string path)
        {
            path = KuaipanServer.LIST_META + GetPath(path);

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(path)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(path, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            var meta = JsonConvert.DeserializeObject<KuaipanMeta>(t);
            ResetParams();
            return meta.SubMetas();
        }

        public string ShareMeta(AMeta meta)
        {
            string url = string.Format(KuaipanServer.SHARE_META, meta.GetMetaPath());

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            // Jason
            ResetParams();

            return "";
        }

        public List<AMeta> History(AMeta meta)
        {
            return null;
        }

        public AMeta CreateFolder(string path, string name)
        {
            string url = KuaipanServer.CREATE_FOLDER;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("path", Combine(path, name));
            _Params.Sort(new NameValueComparer());
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
            ResetParams();

            return meta;
        }

        public bool Delete(string path, string meta)
        {
            string url = KuaipanServer.DELETE;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("path", Combine(path, meta));
            AddParam("to_recycle", "true");
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason
            ResetParams();

            return true;
        }

        public bool Moveto(AMeta meta, string name)
        {
            string url = KuaipanServer.MOVETO;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("from_path", Combine(meta.GetMetaPath(), meta.GetMetaName()));
            AddParam("to_path", Combine(meta.GetMetaPath(), name));
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(url, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            //JsonConvert.DeserializeObject<CsMeta>(t);
            meta.SetMetaName(name);
            ResetParams();

            return true;
        }

        public bool Copyto(AMeta meta, string dstMeta)
        {
            ResetParams();

            return true;
        }

        public void CopyRef(AMeta meta)
        {
            ResetParams();

        }

        #region 上传
        public bool BeginUpload(long key, string remoteMeta)
        {
            //http.ServicePoint.Expect100Continue = false;
            //http.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            return true;
        }

        public void Write(long key, byte[] buffer, int offset, int length)
        {
        }

        public void EndUpload(long key)
        {
        }
        #endregion

        #region 下载
        public long BeginDownload(long key, string meta, long range)
        {
            string url = KuaipanServer.DOWNLOAD;

            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            AddParam("root", KuaipanServer.ROOT_NAME);
            AddParam("path", meta);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(url)));

            string t = GenBaseParams();
            url += url.IndexOf("?") >= 0 ? '&' : '?';
            url += t;

            var reqeust = (HttpWebRequest)WebRequest.Create(url);
            reqeust.Method = "GET";
            if (range > 0)
            {
                reqeust.AddRange(range); //设置Range值
            }

            HttpWebResponse response = null;
            try
            {
                response = reqeust.GetResponse() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    return -1;
                }
            }
            catch (Exception exp)
            {
                return -1;
            }

            var stream = response.GetResponseStream();
            try
            {
                Monitor.Enter(_Items);
                _Items[key] = new KVItem { Response = response, Stream = stream };
            }
            finally
            {
                Monitor.Exit(_Items);
            }
            return response.ContentLength;
        }

        public int Read(long key, byte[] buffer, int offset, int length)
        {
            return _Items[key].Stream.Read(buffer, offset, length);
        }

        public void EndDownload(long key)
        {
            var item = _Items[key];
            if (item == null)
            {
                return;
            }

            try
            {
                Monitor.Enter(_Items);
                item.Stream.Close();
                item.Response.Close();
                _Items.Remove(key);
            }
            finally
            {
                Monitor.Exit(_Items);
            }
        }
        #endregion

        public void Thumbnail()
        {
        }

        public string Parent(string path)
        {
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
            //AddParam(OAuthConstants.OAUTH_NONCE, "6Gb4JdQh");
            AddParam(OAuthConstants.OAUTH_TIMESTAMP, KuaipanClient.GetOAuthTimestamp());
            //AddParam(OAuthConstants.OAUTH_TIMESTAMP, "1348192130");
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
                builder.Append(Uri.EscapeDataString(item.Key));
                builder.Append('=');
                builder.Append(Uri.EscapeDataString(item.Value));
                builder.Append('&');
            }

            return builder.ToString(0, builder.Length - 1);
        }
        #endregion
    }
}