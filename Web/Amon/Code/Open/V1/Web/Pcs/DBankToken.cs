using Me.Amon.Open;

namespace Me.Amon.Code.Open.V1.Web.Pcs
{
    public class DBankToken : OAuthToken
    {
        /// <summary>
        /// 未授权的Request Token
        /// </summary>
        public string oauth_token;
        /// <summary>
        /// 对应的Request Token Secret
        /// </summary>
        public string oauth_token_secret;
        /// <summary>
        /// 对oauth_callback的确认信号 (true/false)
        /// </summary>
        public string oauth_callback_confirmed;

        public override string Token
        {
            get
            {
                return oauth_token;
            }
            set
            {
                oauth_token = value;
            }
        }

        public override string Secret
        {
            get
            {
                return oauth_token_secret;
            }
            set
            {
                oauth_token_secret = value;
            }
        }

        public override string UserId
        {
            get
            {
                return oauth_token;
            }
            set
            {
                oauth_token = value;
            }
        }
    }
}