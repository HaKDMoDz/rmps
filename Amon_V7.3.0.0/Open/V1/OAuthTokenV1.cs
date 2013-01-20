using Newtonsoft.Json;

namespace Me.Amon.Open.V1
{
    public class OAuthTokenV1 : OAuthToken
    {
        public string oauth_token_secret { get; set; }

        public string oauth_token { get; set; }

        public bool oauth_callback_confirmed { get; set; }
    }
}
