using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Open.V1.App
{
    public abstract class OAuthV1Client
    {
        #region 全局变量
        protected OAuthV1Server _Server;
        protected List<KeyValuePair<string, string>> _Params;

        public OAuthConsumer Consumer { get; private set; }
        public OAuthTokenV1 Token { get; private set; }
        public string HttpMethod { get; private set; }
        #endregion

        #region 构造函数
        public OAuthV1Client(OAuthConsumer consumer)
        {
            Consumer = consumer;

            HttpMethod = "GET";

            _Params = new List<KeyValuePair<string, string>>();
        }
        #endregion

        #region 公共函数
        public void ResetParams()
        {
            _Params.Clear();
        }

        public void AddParam(string key, string value)
        {
            _Params.Add(new KeyValuePair<string, string>(key, value));
        }

        public void Verfy()
        {
            RequestToken();
            Authorize();
            AccessToken();
            AccountInfo();
        }

        public void RequestToken()
        {
            PrepareParams(OAuthPhrases.RequestToken);
            _Params.Sort(new NameValueComparer());
            AddParam(OAuthConstants.OAUTH_SIGNATURE, Signature(GenerateBaseString(_Server.RequestTokenUrl)));

            CreateRequestHeader(OAuthPhrases.RequestToken);
            string paramz = CreateRequestQuery(OAuthPhrases.RequestToken);
            byte[] result = _Server.MakeHttpRequest("GET", _Server.RequestTokenUrl, null, paramz);
            string t = GetString(result);
        }

        public void Authorize()
        {
        }

        public void AccessToken()
        {
        }

        public void AccountInfo()
        {
        }
        #endregion

        #region 私有函数
        protected abstract void PrepareParams(OAuthPhrases phrases);

        protected abstract string GenerateBaseString(string uri);

        protected string Signature(string baseString)
        {
            string key = string.Format("{0}&{1}", Consumer.consumer_secret, Token != null ? Token.oauth_token_secret ?? "" : "");
            using (HMACSHA1 alg = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = alg.ComputeHash(Encoding.UTF8.GetBytes(baseString));
                return Convert.ToBase64String(data);
            }
        }

        protected abstract string CreateRequestHeader(OAuthPhrases phrases);

        protected abstract string CreateRequestQuery(OAuthPhrases phrases);

        protected void Authorize(string header, string paramz)
        {
        }

        protected abstract void LoadProfile();

        protected virtual string GetString(byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);
        }
        #endregion
    }
}
