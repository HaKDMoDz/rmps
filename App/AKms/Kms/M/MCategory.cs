
namespace Me.Amon.Kms.M
{
    public class MCategory
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int C2010201 { get; set; }
        /// <summary>
        /// 类别级别
        /// </summary>
        public int C2010202 { get; set; }
        /// <summary>
        /// 类别索引
        /// </summary>
        public string C2010203 { get; set; }
        /// <summary>
        /// 一级索引
        /// </summary>
        public string C2010204 { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string C2010205 { get; set; }
        /// <summary>
        /// 类别提示
        /// </summary>
        public string C2010206 { get; set; }
        /// <summary>
        /// 类别图标
        /// </summary>
        public string C2010207 { get; set; }
        /// <summary>
        /// 类别键值
        /// </summary>
        public string C2010208 { get; set; }
        /// <summary>
        /// 类别描述
        /// </summary>
        public string C2010209 { get; set; }

        public override string ToString()
        {
            return C2010205;
        }

        public override bool Equals(object obj)
        {
            if (obj is MCategory)
            {
                var cat = obj as MCategory;
                return C2010203 == cat.C2010203;
            }
            if (obj is string)
            {
                return C2010203 == (string)obj;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return C2010203.GetHashCode();
        }
    }
}
