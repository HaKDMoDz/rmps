using System.Text;
using Me.Amon.Open.V2.App.Server;

namespace Me.Amon.Open.V2.App.Client
{
    public class WeiboClient : OAuthV2Client
    {
        public WeiboClient(OAuthConsumer consumer) :
            base(consumer)
        {
            _Server = new WeiboServer();
        }

        protected override string GenerateAuthorizeUrl()
        {
            ResetParams();

            AddParam("client_id", Consumer.consumer_key);
            AddParam("redirect_uri", _Server.AuthCallbackUrl);
            //AddParam("response_type", "code");
            //AddParam("state", "");
            //AddParam("display", "default");
            //AddParam("forcelogin", "false");
            //AddParam("language", "");

            return GenerateBaseString(_Server.AuthorizeUrl);
        }

        protected override string GenerateAccessTokenUrl()
        {
            AddParam("client_id", Consumer.consumer_key);
            AddParam("client_secret", Consumer.consumer_secret);
            AddParam("grant_type", Consumer.consumer_secret);
            AddParam("code", Token.Token);
            AddParam("redirect_uri", _Server.AuthCallbackUrl);

            return GenerateBaseString(_Server.AccessTokenUrl);
        }

        protected override void PrepareAccountInfoParam()
        {
            AddParam("uid", _Server.AuthCallbackUrl);
        }

        protected override string GenerateBaseString(string uri)
        {
            var builder = new StringBuilder();
            foreach (var item in _Params)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    continue;
                }

                builder.Append(item.Key);
                builder.Append('=');
                builder.Append(item.Value);
                builder.Append('&');
            }
            uri += uri.IndexOf('?') > 0 ? '&' : '?';
            return uri + builder.ToString();
        }

        protected override string CreateRequestHeader(OAuthPhrases phrases)
        {
            return "";
        }

        protected override string CreateRequestQuery(OAuthPhrases phrases)
        {
            return "";
        }

        protected override void LoadProfile()
        {
            ResetParams();
            AddParam("", Token.Token);
        }
    }
}
