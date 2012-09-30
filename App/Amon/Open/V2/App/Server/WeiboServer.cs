
namespace Me.Amon.Open.V2.App.Server
{
    public class WeiboServer : OAuthV2Server
    {
        public WeiboServer()
        {
            AuthorizeUrl = "https://api.weibo.com/oauth2/authorize";
            AccessTokenUrl = "https://api.weibo.com/oauth2/access_token";

            AuthCallbackUrl = "http://amon.me/oAuth/weiboa.php";
            CancelAuthCallbackUrl = "http://amon.me/oAuth/weiboc.php";

            UserInfoUrl = "https://api.weibo.com/2/users/show.json";
        }
    }
}
