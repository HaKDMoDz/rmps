using System.Collections.Generic;

namespace com.magickms
{
    public class MSolution
    {
        /// <summary>
        /// 索引
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 前置功能
        /// </summary>
        public List<MFunction> PreFunction { get; set; }
        /// <summary>
        /// 后置功能
        /// </summary>
        public List<MFunction> SufFunction { get; set; }
        /// <summary>
        /// 可选文本
        /// </summary>
        public List<string> TxtList { get; set; }
        /// <summary>
        /// 交互目标
        /// </summary>
        public ETarget Target { get; set; }
        /// <summary>
        /// 交互方式
        /// </summary>
        public EAnswer Answer { get; set; }
        /// <summary>
        /// 语言标签
        /// </summary>
        public List<string> TagIds { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
    }
}
