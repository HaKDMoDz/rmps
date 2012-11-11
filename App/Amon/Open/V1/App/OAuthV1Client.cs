using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Open.V1.App
{
    public abstract class OAuthV1Client : OAuthClient
    {
        #region 全局变量
        protected OAuthV1Server _Server;
        protected List<KeyValuePair<string, string>> _Params;

        public OAuthConsumer Consumer { get; private set; }
        public OAuthTokenV1 Token { get; protected set; }
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

        #region 接口实现
        public bool Verify()
        {
            if (!RequestToken())
            {
                return false;
            }
            if (!Authorize())
            {
                return false;
            }
            if (!AccessToken())
            {
                return false;
            }
            return true;
        }

        public abstract bool RequestToken();

        public abstract string AuthorizeUrl { get; }

        public abstract bool AccessToken();
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
        #endregion

        #region 权限认证
        public abstract bool Authorize();
        #endregion

        #region 私有函数
        protected abstract string GenerateBaseString(string uri);

        protected virtual string Signature(string baseString)
        {
            string key = string.Format("{0}&{1}", Consumer.consumer_secret, Token != null ? Token.oauth_token_secret ?? "" : "");
            using (HMACSHA1 alg = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = alg.ComputeHash(Encoding.UTF8.GetBytes(baseString));
                return Convert.ToBase64String(data);
            }
        }

        protected virtual string GetString(byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);
        }
        #endregion
    }
}
