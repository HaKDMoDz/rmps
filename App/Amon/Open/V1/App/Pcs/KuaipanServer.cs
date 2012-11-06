namespace Me.Amon.Open.V1.App.Pcs
{
    public class KuaipanServer : OAuthV1Server
    {
        public const string LIST_META = "http://openapi.kuaipan.cn/1/metadata/kuaipan";

        public const string SHARE_META = "http://openapi.kuaipan.cn/1/shares/kuaipan";

        public const string HISTORY = "http://openapi.kuaipan.cn/1/history/kuaipan";

        public const string CREATE_FOLDER = "http://openapi.kuaipan.cn/1/fileops/create_folder";

        public const string DELETE = "http://openapi.kuaipan.cn/1/fileops/delete";

        public const string MOVETO = "http://openapi.kuaipan.cn/1/fileops/move";

        public const string COPYTO = "http://openapi.kuaipan.cn/1/fileops/copy";

        public KuaipanServer()
        {
            RequestTokenUrl = "https://openapi.kuaipan.cn/open/requestToken";
            VerifierUrl = "https://www.kuaipan.cn/api.php?ac=open&op=authorise&oauth_token={0}";
            AccessTokenUrl = "https://openapi.kuaipan.cn/open/accessToken";
            ProfileUrl = "http://openapi.kuaipan.cn/1/account_info";
        }
    }
}
