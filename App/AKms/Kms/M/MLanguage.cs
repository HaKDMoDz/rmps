
namespace Me.Amon.Kms.M
{
    public class MLanguage
    {
        /// <summary>
        /// 显示排序 
        /// </summary>
        public int C1010101 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int C1010102 { get; set; }

        /// <summary>
        /// 语言索引 
        /// </summary>
        public string C1010103 { get; set; }

        /// <summary>
        /// 语言代码 
        /// </summary>
        public string C1010104 { get; set; }

        /// <summary>
        /// 国家代码 
        /// </summary>
        public string C1010105 { get; set; }

        /// <summary>
        /// 本语名称 
        /// </summary>
        public string C1010106 { get; set; }

        /// <summary>
        /// 英语名称 
        /// </summary>
        public string C1010107 { get; set; }

        /// <summary>
        /// 语言简介 
        /// </summary>
        public string C1010108 { get; set; }

        /// <summary>
        /// 相关说明 
        /// </summary>
        public string C1010109 { get; set; }

        public override string ToString()
        {
            return C1010106;
        }

        public override int GetHashCode()
        {
            return C1010103.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is MLanguage)
            {
                var lang = obj as MLanguage;
                return C1010103 == lang.C1010103;
            }
            if (obj is string)
            {
                return C1010103 == (string)obj;
            }
            return false;
        }
    }
}
