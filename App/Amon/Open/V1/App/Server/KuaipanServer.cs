
namespace Me.Amon.Open.V1.App.Server
{
    public class KuaipanServer : OAuthV1Server
    {
        public KuaipanServer()
        {
            RequestTokenUrl = "https://openapi.kuaipan.cn/open/requestToken";
            VerifierUrl = "https://www.kuaipan.cn/api.php?ac=open&op=authorise&oauth_token={0}";
            AccessTokenUrl = "https://openapi.kuaipan.cn/open/accessToken";
            ProfileUrl = "http://openapi.kuaipan.cn/1/account_info";
        }
    }
}
