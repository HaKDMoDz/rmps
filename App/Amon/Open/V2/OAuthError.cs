namespace Me.Amon.OAuth.V2
{
    public class OAuthError
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 错误的内部编号
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误的描述信息
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// 可读的网页URI，带有关于错误的信息，用于为终端用户提供与错误有关的额外信息。
        /// </summary>
        public string ErrorUrl { get; set; }
    }
}
