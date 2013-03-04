using System.Collections.Generic;
using System.Text;
using Me.Amon.Http;
using Me.Amon.Open;
using Me.Amon.Open.V1;
using Me.Amon.Open.V1.Web;
using Newtonsoft.Json;

namespace Me.Amon.Code.Open.V1.Web.Pcs
{
    public class DBankClient : OAuthV1Client, PcsClient
    {
        private string _Result;

        #region 构造函数
        public DBankClient(OAuthConsumer consumer, bool isRoot)
            : base(consumer)
        {
        }

        public DBankClient(OAuthConsumer consumer, OAuthToken token, bool isRoot)
            : base(consumer)
        {
        }
        #endregion

        public override string DebugResult
        {
            get { return ""; }
        }

        #region OAuth
        public override bool RequestToken()
        {
            GenOAuthBaseParams(DBankServer.CALL_BACK);
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(_Server.RequestTokenUrl)));

            SortParam();
            byte[] r = _Server.Get(_Server.RequestTokenUrl, GenBaseParams());
            if (r == null || r.Length < 1)
            {
                return false;
            }

            Token = JsonConvert.DeserializeObject<DBankToken>(GetString(r));
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
            GenOAuthBaseParams(DBankServer.CALL_BACK);
            AddParam(OAuthConstants.OAUTH_TOKEN, Token.Token);
            AddParam(OAuthConstants.OAUTH_VERIFIER, "");
            SortParam();
            AddParam(OAuthConstants.OAUTH_SIGNATURE, GenOAuthSignature(GenOAuthBaseString(_Server.AccessTokenUrl)));

            byte[] r = _Server.Get(_Server.AccessTokenUrl, GenBaseParams());
            if (r == null || r.Length < 1)
            {
                return false;
            }

            _Result = GetString(r);
            Token = JsonConvert.DeserializeObject<DBankToken>(_Result);
            ResetParams();

            return true;
        }

        public string Name { get; set; }

        public string Root { get; set; }

        public System.Drawing.Image Icon { get; set; }

        public OAuthPcsAccount Account()
        {
            return null;
        }
        #endregion

        #region PCS
        public List<Amon.Open.M.AMeta> ListMeta(Amon.Open.M.AMeta meta)
        {
            return null;
        }

        public List<Amon.Open.M.AMeta> ListMeta(string path)
        {
            return null;
        }

        public Amon.Open.M.AMeta MetaData(string path)
        {
            return null;
        }

        public string GetPath(string key)
        {
            return "";
        }

        public string ShareMeta(Amon.Open.M.AMeta meta)
        {
            return "";
        }

        public List<Amon.Open.M.AMeta> History(Amon.Open.M.AMeta meta)
        {
            return null;
        }

        public Amon.Open.M.AMeta CreateFolder(string path, string name)
        {
            return null;
        }

        public bool Delete(string path, string meta)
        {
            return true;
        }

        public Amon.Open.M.AMeta Moveto(Amon.Open.M.AMeta meta, string dstPath, string dstName)
        {
            return null;
        }

        public Amon.Open.M.AMeta Copyto(Amon.Open.M.AMeta meta, string dstPath, string dstName)
        {
            return null;
        }

        public Amon.Open.M.AMeta Copyto(string metaRef, string dstPath, string dstName)
        {
            return null;
        }

        public Amon.Open.M.AMetaRef CopyRef(Amon.Open.M.AMeta meta)
        {
            return null;
        }

        public void Thumbnail()
        {
        }

        public string Parent(string path)
        {
            return "";
        }

        public string Combine(string path, string meta)
        {
            return "";
        }

        public string GetFileName(string meta)
        {
            return "";
        }

        public string Display(string path)
        {
            return "";
        }

        public string Upload(string meta)
        {
            return null;
        }

        public System.Net.HttpWebRequest Download(string meta)
        {
            return null;
        }
        #endregion

        #region 私有函数
        private void PrepareParams()
        {
            AddParam(OAuthConstants.OAUTH_SIGNATURE_METHOD, "HMAC-SHA1");

            //AddParam(OAuthConstants.OAUTH_NONCE, KuaipanClient.GetOAuthNonce());
            //AddParam(OAuthConstants.OAUTH_NONCE, "ChcAPp5A");
            //AddParam(OAuthConstants.OAUTH_TIMESTAMP, KuaipanClient.GetOAuthTimestamp());
            //AddParam(OAuthConstants.OAUTH_TIMESTAMP, "1354715324");
            AddParam(OAuthConstants.OAUTH_CONSUMER_KEY, Consumer.consumer_key);
            AddParam(OAuthConstants.OAUTH_VERSION, "1.0");
            AddParam(OAuthConstants.OAUTH_CALLBACK, "http://amon.me/Auth/kuaipan.aspx");
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
                builder.Append('&');
            }

            return builder.ToString(0, builder.Length - 1);
        }
        #endregion
    }
}