using Me.Amon.Open.V1.Web;

namespace Me.Amon.Code.Open.V1.Web.Pcs
{
    public class DBankServer : OAuthV1Server
    {
        public const string NSP_APP = "nsp_app";
        public const string NSP_SID = "nsp_sid";
        public const string NSP_CLIENT = "client";
        public const string NSP_KEY = "nsp_key";
        public const string NSP_SVC = "nsp_svc";
        public const string NSP_TS = "nsp_ts";
        public const string NSP_PARAMS = "nsp_params";
        public const string NSP_FMT = "nsp_fmt";
        public const string NSP_TSTR = "nsp_tstr";

        public const string NSP_URL = "http://api.dbank.com/rest.php";

        public const string COMMON_UPLOAD = "/upload/up.php";

        public const string CONSUMER_KEY = "xcWPaz75PSRDOWBM";
        public const string CONSUMER_SECRET = "DU5ZYaCK0cRlsMTj";

        public const string CALL_BACK = "";

        public DBankServer()
        {
            RequestTokenUrl = "http://login.dbank.com/oauth1/request_token";
            VerifierUrl = "http://login.dbank.com/oauth1/authorize?oauth_token={0}";
            AccessTokenUrl = "http://login.dbank.com/oauth1/access_token";
            ProfileUrl = "http://openapi.kuaipan.cn/1/account_info";
        }
    }
}