
namespace Me.Amon.Open.V2.App
{
    public class OAuthV2Server
    {
        public string AuthorizeUrl { get; set; }
        public string AccessTokenUrl { get; set; }

        public string AuthCallbackUrl { get; set; }
        public string CancelAuthCallbackUrl { get; set; }

        public string UserInfoUrl { get; set; }
    }
}
