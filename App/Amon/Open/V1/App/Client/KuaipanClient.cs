using System.Collections.Generic;
using System.Text;
using Me.Amon.Open.V1.App.Server;

namespace Me.Amon.Open.V1.App.Client
{
    public class KuaipanClient : OAuthV1Client
    {
        public KuaipanClient(OAuthConsumer consumer)
            : base(consumer)
        {
            _Server = new KuaipanServer();
        }

        protected override void PrepareParams(OAuthPhrases phrases)
        {
            AddParam(OAuthConstants.OAUTH_SIGNATURE_METHOD, "HMAC-SHA1");

            //AddParam(OAuthConstants.OAUTH_NONCE, OAuthUtility.GetOAuthNonce());
            AddParam(OAuthConstants.OAUTH_NONCE, "6Gb4JdQh");
            //AddParam(OAuthConstants.OAUTH_TIMESTAMP, OAuthUtility.GetOAuthTimestamp());
            AddParam(OAuthConstants.OAUTH_TIMESTAMP, "1348192130");
            AddParam(OAuthConstants.OAUTH_CONSUMER_KEY, Consumer.consumer_key);
            AddParam(OAuthConstants.OAUTH_VERSION, "1.0");

            if (phrases == OAuthPhrases.RequestToken)
            {
                return;
            }

            if (Token != null)
            {
                AddParam(OAuthConstants.OAUTH_TOKEN, Token.oauth_token);
            }

            AddParam("path", "/test@kingsoft.com");
            AddParam("root", "kuaipan");
        }

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

        protected override string CreateRequestHeader(OAuthPhrases phrases)
        {
            return null;
        }

        protected override string CreateRequestQuery(OAuthPhrases phrases)
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

        protected override void LoadProfile()
        {
        }

        protected override string GetString(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
