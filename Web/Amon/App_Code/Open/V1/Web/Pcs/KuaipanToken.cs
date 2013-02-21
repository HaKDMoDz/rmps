namespace Me.Amon.Open.V1.Web.Pcs
{
    /// <summary>
    ///KuaipanToken 的摘要说明
    /// </summary>
    public class KuaipanToken : OAuthToken
    {
        public KuaipanToken()
        {
        }

        public string oauth_token;

        public string oauth_token_secret;

        public bool oauth_callback_confirmed;

        public string user_id;

        public string charged_dir;

        public override string Token
        {
            get { return oauth_token; }
            set { oauth_token = value; }
        }

        public override string Secret
        {
            get { return oauth_token_secret; }
            set { oauth_token_secret = value; }
        }

        public override string UserId
        {
            get { return user_id; }
            set { user_id = value; }
        }
    }
}