using System;

namespace cons
{
    /// <summary>
    /// SysCons 的摘要说明
    /// </summary>
    public class SysCons
    {
        public const String UI_SRCHHOME_HASH = "sctfzgewbfxcqszc";
        public const String UI_SRCHHOME_NAME = "搜索引擎";

        public const String UI_SRCHPAGE_HASH = "sctfzgesqagtaxgf";
        public const String UI_SRCHPAGE_NAME = "搜索引擎（结果）";


        /** 界面默认使用语言：简体中文 */
        public const String UI_LANGHASH = "qqqqqaadedvccyfg";
        public const String UI_LANGNAME = "中文（简体）";

        /** 默认Hash字段字符长度 */
        public const int DBCD_HASH_SIZE = 16;

        /** 默认链接字段字符长度 */
        public const int DBCD_LINK_SIZE = 1024;

        /** 默认附注字段字符长度 */
        public const int DBCD_DESP_SIZE = 2048;

        /** 未知 */
        public const int BITS_IDX_00 = 0x10000000;
        /** 1位 */
        public const int BITS_IDX_01 = 0x00000001;
        /** 2位 */
        public const int BITS_IDX_02 = 0x00000010;
        /** 4位 */
        public const int BITS_IDX_04 = 0x00000100;
        /** 8位 */
        public const int BITS_IDX_08 = 0x00001000;
        /** 16位 */
        public const int BITS_IDX_16 = 0x00010000;
        /** 32位 */
        public const int BITS_IDX_32 = 0x00100000;
        /** 64位 */
        public const int BITS_IDX_64 = 0x01000000;

        /** 所有平台 */
        public const int OS_IDX_ALL = 0x00000000;

        /** Linux平台 */
        public const int OS_IDX_LINUX = 0x00100000;

        /** Mac平台 */
        public const int OS_IDX_MACINTOSH = 0x00200000;

        /** Windows平台 */
        public const int OS_IDX_WINDOWS = 0x00400000;

        /** Uinx平台 */
        public const int OS_IDX_UNIX = 0x00800000;

        /** 未知平台（其它平台） */
        public const int OS_IDX_UNKNOWN = 0x00080000;

        /** 移动平台 */
        public const int OS_IDX_MOBILE = 0x00040000;

        /// <summary>
        /// 网页精灵
        /// </summary>
        public const string INET_HASH = "42010000";
        /// <summary>
        /// 网页五笔
        /// </summary>
        public const string WIME_HASH = "42020000";
        /// <summary>
        /// 全能搜索
        /// </summary>
        public const string SRCH_HASH = "42030000";
        /// <summary>
        /// Amon卡片
        /// </summary>
        public const string CARD_HASH = "42040000";
    }
}