using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Pcs.M;
using Newtonsoft.Json;

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
            Token = JsonConvert.DeserializeObject<OAuthTokenV1>(t);
            ResetParams();

            return true;
        }

        protected override bool Authorize()
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

        protected override bool AccessToken()
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
            return key;
        }

        public List<CsMeta> ListMeta(CsMeta meta)
        {
            string url = string.Format(KuaipanServer.LIST_META, meta.Path);
            return ListMeta(url);
        }

        public List<CsMeta> ListMeta(string path)
        {
            PrepareParams();
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            string t = GenBaseParams();
            byte[] r = _Server.Get(path, t);
            if (r == null || r.Length < 1)
            {
                return null;
            }

            t = GetString(r);
            return JsonConvert.DeserializeObject<List<CsMeta>>(t);
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

        public bool Moveto(CsMeta meta, string dstMeta)
        {
            PrepareParams();
            AddParam("root", "kuaipan");
            AddParam("from_path", meta.Path);
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

            JsonConvert.DeserializeObject<CsMeta>(t);
            return true;
        }

        public bool Copyto(CsMeta meta, string dstMeta)
        {
            return true;
        }

        public void CopyRef(CsMeta meta)
        {
        }

        public bool BeginWrite(string remoteMeta)
        {
            return true;
        }

        public int Write(byte[] buffer, int offset, int length)
        {
            return 0;
        }

        public bool EndWrite()
        {
            return true;
        }

        public bool BeginRead(string meta)
        {
            return true;
        }

        public int Read(byte[] buffer, int offset, int length)
        {
            return 0;
        }

        public bool EndRead()
        {
            return true;
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

        public string Display(string path)
        {
            return "kuaipan://" + path;
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