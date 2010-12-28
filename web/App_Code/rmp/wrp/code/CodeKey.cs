using System;

namespace rmp.wrp.code
{
    public class CodeKey
    {
        public const int TYPE_NORMAL = 0;
        public const int TYPE_REGEXP = 1;

        /// <summary>
        /// 关键字索引
        /// </summary>
        public String W2050101;
        /// <summary>
        /// 语言索引
        /// </summary>
        public String W2050102;
        /// <summary>
        /// 所属语言
        /// </summary>
        public CodeCat CodeCat;
        /// <summary>
        /// 所属风格
        /// </summary>
        public String W2050103;
        /// <summary>
        /// 订制风格
        /// </summary>
        public CodeCss CodeCss;
        /// <summary>
        /// 关键字内容
        /// </summary>
        public String W2050104;
        /// <summary>
        /// 关键字链接
        /// </summary>
        public String W2050105;
        /// <summary>
        /// 链接提示
        /// </summary>
        public String W2050106;
        /// <summary>
        /// 是否为表达式
        /// </summary>
        public int W2050107;
        /// <summary>
        /// 关键字备注
        /// </summary>
        public String W2050108;
    }
}
