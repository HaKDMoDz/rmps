
namespace com.magickms
{
    public class MFunction
    {
        /// <summary>
        /// 执行顺序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 执行动作
        /// </summary>
        public EAction Action { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string Param { get; set; }
    }
}
