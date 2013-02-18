using Newtonsoft.Json;

namespace Me.Amon.Open.V1
{
    public class OAuthTokenV1 : OAuthToken
    {
        public new string oauth_token_secret { get; set; }

        public new string oauth_token { get; set; }

        public bool oauth_callback_confirmed { get; set; }
    }
}
