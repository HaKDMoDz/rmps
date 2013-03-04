using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Open.V1.Web
{
    public abstract class OAuthV1Client : OAuthClient
    {
        public abstract string DebugResult { get; }

        #region 全局变量
        public OAuthConsumer Consumer { get; private set; }
        public OAuthToken Token { get; protected set; }

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
        #region OAuth 相关
        /// <summary>
        /// OAuth Base String
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        protected virtual string GenOAuthBaseString(string uri, string method = "GET")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(method).Append('&');
            builder.Append(Uri.EscapeDataString(uri)).Append('&');

            foreach (KeyValuePair<string, string> item in _Params)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    continue;
                }

                builder.Append(Uri.EscapeDataString(item.Key));
                builder.Append("%3D");
                builder.Append(Uri.EscapeDataString(item.Value));
                builder.Append("%26");
            }

            return builder.ToString(0, builder.Length - 3);
        }

        /// <summary>
        /// OAuth Base Params
        /// </summary>
        /// <param name="callBack"></param>
        /// <returns></returns>
        protected virtual void GenOAuthBaseParams(string callBack = "")
        {
            AddParam(OAuthConstants.OAUTH_CONSUMER_KEY, Consumer.consumer_key);
            AddParam(OAuthConstants.OAUTH_SIGNATURE_METHOD, "HMAC-SHA1");
            AddParam(OAuthConstants.OAUTH_TIMESTAMP, GetOAuthTimestamp());
            AddParam(OAuthConstants.OAUTH_NONCE, GetOAuthNonce());
            if (!string.IsNullOrEmpty(callBack))
            {
                AddParam(OAuthConstants.OAUTH_CALLBACK, callBack);
            }
            AddParam(OAuthConstants.OAUTH_VERSION, "1.0");
        }

        /// <summary>
        /// OAuth Signature
        /// </summary>
        /// <param name="baseString"></param>
        /// <returns></returns>
        protected virtual string GenOAuthSignature(string baseString)
        {
            string key = string.Format("{0}&{1}", Consumer.consumer_secret, Token != null ? Token.Secret ?? "" : "");
            using (HMACSHA1 alg = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
            {
                byte[] data = alg.ComputeHash(Encoding.UTF8.GetBytes(baseString));
                return Convert.ToBase64String(data);
            }
        }
        #endregion

        #region 字符相关
        protected virtual string GetString(byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);
        }

        protected virtual byte[] GetBytes(string text)
        {
            return Encoding.Default.GetBytes(text);
        }
        #endregion
        #endregion
    }
}
