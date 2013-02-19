namespace Me.Amon.Open.V1.Web.Pcs
{
    class KuaipanHttpStatus
    {
        /// <summary>
        /// 正常返回
        /// </summary>
        public const int STATUS_200 = 200;
        /// <summary>
        /// 接口执行错误,错误信息可以看msg
        /// </summary>
        public const int STATUS_202 = 202;
        /// <summary>
        /// 参数错误
        /// </summary>
        public const int STATUS_400 = 400;
        /// <summary>
        /// 请求验证错误(时间戳,nonce,签名，token等验证错误)
        /// </summary>
        public const int STATUS_401 = 401;
        /// <summary>
        /// 无权限操作
        /// </summary>
        public const int STATUS_403 = 403;
        /// <summary>
        /// 无此文件
        /// </summary>
        public const int STATUS_404 = 404;
        /// <summary>
        /// 同时操作太多文件
        /// </summary>
        public const int STATUS_406 = 406;
        /// <summary>
        /// 文件太大
        /// </summary>
        public const int STATUS_413 = 413;
        /// <summary>
        /// 服务器内部错误
        /// </summary>
        public const int STATUS_500 = 500;
        /// <summary>
        /// 空间不够
        /// </summary>
        public const int STATUS_507 = 507;
        /// <summary>
        /// 内部错误，服务暂时不可用
        /// </summary>
        public const int STATUS_5XX = 500;
    }
}
