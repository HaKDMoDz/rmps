using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Open.V1.Web
{
    public abstract class OAuthV1Client : OAuthClient
    {
        #region 全局变量
        public OAuthConsumer Consumer { get; private set; }
        public OAuthTokenV1 Token { get; protected set; }

        protected OAuthV1Server _Server;
        protected List<KeyValuePair<string, string>> _Params;

        private NameValueComparer _Comparer;
        #endregion

        #region 构造函数
        public OAuthV1Client(OAuthConsumer consumer)
        {
            Consumer = consumer;

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
            var pair = new KeyValuePair<string, string>(key, value);
            _Params.Remove(pair);
            _Params.Add(pair);
        }

        public void SortParam()
        {
            if (_Comparer == null)
            {
                _Comparer = new NameValueComparer();
            }
            _Params.Sort(_Comparer);
        }
        #endregion

        #region 私有函数
        protected abstract string GenerateBaseString(string uri, string method = "GET");

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

        protected virtual byte[] GetBytes(string text)
        {
            return Encoding.Default.GetBytes(text);
        }
        #endregion
    }
}
