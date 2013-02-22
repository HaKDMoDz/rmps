
namespace Me.Amon.Open.V2.Enums
{
    /// <summary>
    /// Token验证返回值
    /// </summary>
    public enum TokenResult
    {
        /// <summary>
        /// 正常
        /// </summary>
        Success,
        /// <summary>
        /// Token已过期
        /// </summary>
        TokenExpired,
        /// <summary>
        /// Token已被占用
        /// </summary>
        TokenUsed,
        /// <summary>
        /// Token已被回收
        /// </summary>
        TokenRevoked,
        /// <summary>
        /// Token被拒绝
        /// </summary>
        TokenRejected,
        /// <summary>
        /// 其他问题
        /// </summary>
        Other
    }
}
