using System;
namespace Me.Amon.Open.V1.Web.Pcs
{
    public class KuaipanServer : OAuthV1Server
    {
        public const string LIST_META = "http://openapi.kuaipan.cn/1/metadata/{0}{1}";

        public const string SHARE_META = "http://openapi.kuaipan.cn/1/shares/{0}{1}";

        public const string HISTORY = "http://openapi.kuaipan.cn/1/history/{0}{1}";

        public const string CREATE_FOLDER = "http://openapi.kuaipan.cn/1/fileops/create_folder";

        public const string DELETE = "http://openapi.kuaipan.cn/1/fileops/delete";

        public const string MOVETO = "http://openapi.kuaipan.cn/1/fileops/move";

        public const string COPYTO = "http://openapi.kuaipan.cn/1/fileops/copy";

        public const string COPYREF = "http://openapi.kuaipan.cn/1/copy_ref/{0}{1}";

        public const string DOWNLOAD = "http://api-content.dfs.kuaipan.cn/1/fileops/download_file";

        public const string UPLOAD = "http://api-content.dfs.kuaipan.cn/1/fileops/upload_locate";

        public KuaipanServer()
        {
            RequestTokenUrl = "https://openapi.kuaipan.cn/open/requestToken";
            VerifierUrl = "https://www.kuaipan.cn/api.php?ac=open&op=authorise&oauth_token={0}&oauth_callback=" + Uri.EscapeUriString("http://amon.me/Auth/kuaipan.aspx");
            AccessTokenUrl = "https://openapi.kuaipan.cn/open/accessToken";
            ProfileUrl = "http://openapi.kuaipan.cn/1/account_info";
        }
    }
}
