namespace Me.Amon.OS.Kuaipan
{
    public class KConst
    {
        public const string CONSUMER_KEY = "xcfJGOUw2MU0PCmI";
        public const string CONSUMER_SECRET = "Z5um4A2NsfjhGaRy";

        public const string URI_BASE = "http://openapi.kuaipan.cn/1/";
        public const string URI_REQUEST_TOKEN = "https://openapi.kuaipan.cn/open/requestToken";
        public const string URI_ACCESS_TOKEN = "https://openapi.kuaipan.cn/open/accessToken";
        public const string URI_ACCOUNT_INFO = URI_BASE + "account_info";
        public const string URI_METADATA = URI_BASE + "metadata/app_folder/";
        public const string URI_OAUTH_CALLBACK = "http://{0}/gettoken.aspx";
        public const string URI_UPLOAD_LOCATE = "http://api-content.dfs.kuaipan.cn/1/fileops/upload_locate";
        public const string URI_DOWNLOAD = "http://api-content.dfs.kuaipan.cn/1/fileops/download_file";
        public const string URI_CREATE_FOLDER = URI_BASE + "fileops/create_folder";
        public const string URI_DELETE_FOLDERORFILE = URI_BASE + "/fileops/delete";
        public const string URI_MOVE_FOLDER = URI_BASE + "fileops/move";
        public const string URI_THUMBNAIL = "http://conv.kuaipan.cn/{0}/fileops/thumbnail";
    }
}
