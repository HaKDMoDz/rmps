namespace Me.Amon.Open.V2.Enums
{
    class ErrorCode
    {
        /// <summary>
        /// 重定向地址不匹配
        /// </summary>
        public const int REDIRECT_URI_MISMATCH = 21322;
        /// <summary>
        /// 请求不合法
        /// </summary>
        public const int INVALID_REQUEST = 21323;
        /// <summary>
        /// client_id或client_secret参数无效
        /// </summary>
        public const int INVALID_CLIENT = 21324;
        /// <summary>
        /// 提供的Access Grant是无效的、过期的或已撤销的
        /// </summary>
        public const int INVALID_GRANT = 21325;
        /// <summary>
        /// 客户端没有权限
        /// </summary>
        public const int UNAUTHORIZED_CLIENT = 21326;
        /// <summary>
        /// token过期
        /// </summary>
        public const int EXPIRED_TOKEN = 21327;
        /// <summary>
        /// 不支持的 GrantType
        /// </summary>
        public const int UNSUPPORTED_GRANT_TYPE = 21328;
        /// <summary>
        /// 不支持的 ResponseType
        /// </summary>
        public const int UNSUPPORTED_RESPONSE_TYPE = 21329;
        /// <summary>
        /// 用户或授权服务器拒绝授予数据访问权限
        /// </summary>
        public const int ACCESS_DENIED = 21330;
        /// <summary>
        /// 服务暂时无法访问
        /// </summary>
        public const int TEMPORARILY_UNAVAILABLE = 21331;
    }
}
