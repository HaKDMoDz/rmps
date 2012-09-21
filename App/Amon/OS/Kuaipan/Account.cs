using Me.Amon.OS.Kuaipan;
namespace KApi
{
    /// <summary>
    /// 帐号信息类
    /// </summary>
    public class Account : Oauth
    {
        private OauthCore baseOauth;
        public Account()
        {
            baseOauth = new OauthCore(this.consumer_key, this.consumer_secret);
        }

        public Account(Consumer kconsumer, OauthToken kot)
        {
            this.consumer_key = kconsumer.consumer_key;
            this.consumer_secret = kconsumer.consumer_secret;
            this.oauth_token = kot.oauth_token;
            this.oauth_token_secret = kot.oauth_token_secret;
            baseOauth = new OauthCore(this.consumer_key, this.consumer_secret);
        }
        public string GetAccount()
        {
            return baseOauth.GetAccountInfo(new OauthToken(oauth_token, oauth_token_secret));
        }
    }
}
