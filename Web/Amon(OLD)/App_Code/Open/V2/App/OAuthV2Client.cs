using System.Collections.Generic;
using System.Text;

namespace Me.Amon.Open.V2.App
{
    /// <summary>
    /// OAuth2.0授权类
    /// </summary>
    public abstract class OAuthV2Client
    {
        #region 全局变量
        protected OAuthV2Server _Server;
        protected List<KeyValuePair<string, string>> _Params;

        public OAuthConsumer Consumer { get; private set; }
        public OAuthTokenV2 Token { get; private set; }
        public string HttpMethod { get; private set; }
        public bool oAuthVerify { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumer"></param>
        public OAuthV2Client(OAuthConsumer consumer)
        {
            Consumer = consumer;

            HttpMethod = "GET";

            _Params = new List<KeyValuePair<string, string>>();
        }
        #endregion

        #region 参数管理
        public void ResetParams()
        {
            _Params.Clear();
        }

        public void AddParam(string key, string value)
        {
            _Params.Add(new KeyValuePair<string, string>(key, value));
        }

        protected virtual void PrepareParams()
        {
            if (oAuthVerify)
            {
                AddParam("access_token", Token.Token);
            }
            else
            {
                AddParam("source", Consumer.consumer_key);
            }
        }
        #endregion

        public void Verify()
        {
        }

        #region 私有函数
        protected abstract string GenerateAuthorizeUrl();

        protected abstract string GenerateAccessTokenUrl();

        protected abstract void PrepareAccountInfoParam();

        protected abstract string GenerateBaseString(string uri);

        protected abstract string CreateRequestHeader(OAuthPhrases phrases);

        protected abstract string CreateRequestQuery(OAuthPhrases phrases);

        protected abstract void LoadProfile();

        protected virtual string GetString(byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);
        }
        #endregion
    }
}