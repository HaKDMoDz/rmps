using Me.Amon.Kms.Enums;

namespace Me.Amon.Kms.M
{
    public class MSentence
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int P3100101 { get; set; }
        /// <summary>
        /// 所属类型
        /// </summary>
        public EStyle P3100102 { get; set; }
        /// <summary>
        /// 资源索引
        /// </summary>
        public string P3100103 { get; set; }
        /// <summary>
        /// 语言索引
        /// </summary>
        public string P3100104 { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string P3100105 { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string P3100106 { get; set; }

        public override string ToString()
        {
            return P3100105;
        }
    }
}
