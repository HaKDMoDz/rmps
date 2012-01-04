namespace Msec
{
    public class IData
    {
        /// <summary>
        /// 数据散列
        /// </summary>
        public const string OPT_DIGEST = "digest";
        /// <summary>
        /// 随机口令
        /// </summary>
        public const string OPT_RANDKEY = "randkey";
        /// <summary>
        /// 掩码转换
        /// </summary>
        public const string OPT_WRAPPER = "wrapper";
        /// <summary>
        /// 混淆处理
        /// </summary>
        public const string OPT_CONFUSE = "confuse";
        /// <summary>
        /// 对称块加密
        /// </summary>
        public const string OPT_SCRYPTO = "scrypto";
        /// <summary>
        /// 对称流加密
        /// </summary>
        public const string OPT_SSTREAM = "sstream";
        /// <summary>
        /// 非对称加密
        /// </summary>
        public const string OPT_ACRYPTO = "acrypto";
        /// <summary>
        /// 文图转换
        /// </summary>
        public const string OPT_TXT2IMG = "txt2img";

        public const string KEY_ENC = "enc";
        public const string KEY_DEC = "dec";

        public const string DIR_ENC = "enc";
        public const string DIR_DEC = "dec";

        public const int BUF_SIZE = 1024;
    }
}