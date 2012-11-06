using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Me.Amon.Pcs.M;

namespace Me.Amon.Open.V1.App.Pcs
{
    public class KuaipanClient : OAuthV1Client, OAuthPcs
    {
        #region 构造函数
        public KuaipanClient(OAuthConsumer consumer)
            : base(consumer)
        {
            _Server = new KuaipanServer();
        }
        #endregion

        #region 权限认证
        protected override bool RequestToken()
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
            // Jason
            return true;
        }

        protected override bool Authorize()
        {
            return true;
        }

        protected override bool AccessToken()
        {
            PrepareParams();
            if (Token == null)
            {
                return false;
            }
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(_Server.AccessTokenUrl, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason
            return true;
        }

        protected override bool AccountInfo()
        {
            PrepareParams();
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(_Server.ProfileUrl, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason
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

                builder.Append(OAuthUtility.UrlEncode(item.Key));
                builder.Append('=');
                builder.Append(OAuthUtility.UrlEncode(item.Value));
                builder.Append('&');
            }

            string temp = OAuthUtility.UrlEncode(builder.ToString(0, builder.Length - 1));
            return string.Format("{0}&{1}&{2}", HttpMethod, OAuthUtility.UrlEncode(uri), temp);
        }

        protected override string GetString(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer);
        }
        #endregion

        #region 业务函数
        public Image Icon
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public List<CsMeta> ListMeta(CsMeta meta)
        {
            string url = string.Format(KuaipanServer.LIST_META, meta.Path);

            PrepareParams();
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
            return null;
        }

        public List<CsMeta> ListMeta(string key)
        {
            return null;
        }

        public string ShareMeta(CsMeta meta)
        {
            string url = string.Format(KuaipanServer.SHARE_META, meta.Path);

            PrepareParams();
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
            return "";
        }

        public List<CsMeta> History(CsMeta meta)
        {
            return null;
        }

        public bool CreateFolder(CsMeta meta)
        {
            PrepareParams();
            AddParam("root", "kuaipan");
            AddParam("path", meta.Path);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(KuaipanServer.CREATE_FOLDER, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason
            return true;
        }

        public bool Delete(string meta)
        {
            PrepareParams();
            AddParam("root", "kuaipan");
            AddParam("path", meta);
            AddParam("to_recycle", "true");
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(KuaipanServer.CREATE_FOLDER, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason
            return true;
        }

        public bool Moveto(string srcMeta, string dstMeta)
        {
            PrepareParams();
            AddParam("root", "kuaipan");
            AddParam("from_path", srcMeta);
            AddParam("to_path", dstMeta);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(KuaipanServer.CREATE_FOLDER, t);
            if (r == null || r.Length < 1)
            {
                return false;
            }

            t = GetString(r);
            // Jason
            return true;
        }

        public bool Copyto(string srcMeta, string dstMeta)
        {
            return true;
        }

        public void CopyRef(CsMeta meta)
        {
        }

        public void Upload(string nativeFile, string remotePath)
        {
            throw new System.NotImplementedException();
        }

        public void Download(string remoteMeta, string nativePath)
        {
            throw new System.NotImplementedException();
        }

        public void Thumbnail()
        {
            throw new System.NotImplementedException();
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
            if (path[path.Length - 1] != '/')
            {
                path += '/';
            }
            return path + meta;
        }
        #endregion

        #region 私有函数
        private void PrepareParams()
        {
            AddParam(OAuthConstants.OAUTH_SIGNATURE_METHOD, "HMAC-SHA1");

            AddParam(OAuthConstants.OAUTH_NONCE, OAuthUtility.GetOAuthNonce());
            //AddParam(OAuthConstants.OAUTH_NONCE, "6Gb4JdQh");
            AddParam(OAuthConstants.OAUTH_TIMESTAMP, OAuthUtility.GetOAuthTimestamp());
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
                builder.Append(OAuthUtility.UrlEncode(item.Key));
                builder.Append('=');
                builder.Append(OAuthUtility.UrlEncode(item.Value));
                builder.Append('&');
            }

            return builder.ToString(0, builder.Length - 1);
        }
        #endregion
    }
}