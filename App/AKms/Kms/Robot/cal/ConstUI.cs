using System;

namespace Me.Amon.Kms.Robot.cal
{
    /// <summary>
    /// ConstUI 的摘要说明
    /// </summary>
    public class ConstUI
    {
        private ConstUI()
        {
        }

        // ////////////////////////////////////////////////////////////////////////
        // 语言配置标记
        // ////////////////////////////////////////////////////////////////////////
        /** 软件语言资源标记 */
        public const String RES_NAME = "P3060000";
        /** 软件标题语言资源标记 */
        public const String RES_TITLE = "P3060000.title";
        /** 软件描述信息语言资源标记 */
        public const String RES_DESCRIPTION = "P3060000.description";

        // ////////////////////////////////////////////////////////////////////////
        // 操作符优先级标记
        // ////////////////////////////////////////////////////////////////////////
        // ----------------------------------------------------
        // 0 级运算
        // ----------------------------------------------------
        /** 左大括号 */
        public const String OPR_LLB_EXP = "{";
        public const int OPR_LLB_INT = 0;
        /** 左中括号 */
        public const String OPR_MLB_EXP = "[";
        public const int OPR_MLB_INT = 1;
        /** 左小括号 */
        public const String OPR_SLB_EXP = "(";
        public const int OPR_SLB_INT = 2;

        // ----------------------------------------------------
        // 1 级运算
        // ----------------------------------------------------
        /** 加 */
        public const String OPR_ADD_EXP = "+";
        public const int OPR_ADD_INT = 3;
        /** 减 */
        public const String OPR_SUB_EXP = "-";
        public const int OPR_SUB_INT = 3;

        // ----------------------------------------------------
        // 2 级运算
        // ----------------------------------------------------
        /** 乘 */
        public const String OPR_MUL_EXP = "*";
        public const int OPR_MUL_INT = 4;
        /** 除 */
        public const String OPR_DIV_EXP = "/";
        public const int OPR_DIV_INT = 4;

        // ----------------------------------------------------
        // 3 级运算
        // ----------------------------------------------------
        /** 取模 */
        public const String OPR_MOD_EXP = "%";
        public const int OPR_MOD_INT = 5;

        /** 次幂 */
        public const String OPR_POW_EXP = "^";
        public const int OPR_POW_INT = 5;
        /** 方根 */
        public const String OPR_ROT_EXP = "√";
        public const int OPR_ROT_INT = 5;

        /** 阶乘 */
        public const String OPR_FAC_EXP = "!";
        public const int OPR_FAC_INT = 5;

        /** 正弦 */
        public const String OPR_SIN_EXP = "sin";
        public const int OPR_SIN_INT = 5;
        /** 余弦 */
        public const String OPR_COS_EXP = "cos";
        public const int OPR_COS_INT = 5;
        /** 正切 */
        public const String OPR_TAN_EXP = "tan";
        public const int OPR_TAN_INT = 5;

        /** 正割 */
        public const String OPR_SEC_EXP = "sec";
        public const int OPR_SEC_INT = 5;
        /** 余割 */
        public const String OPR_CSC_EXP = "csc";
        public const int OPR_CSC_INT = 5;
        /** 余切 */
        public const String OPR_COT_EXP = "cot";
        public const int OPR_COT_INT = 5;

        /** 10的对数 */
        public const String OPR_LOG_EXP = "log";
        public const int OPR_LOG_INT = 5;
        /** 自然对数 */
        public const String OPR_LNE_EXP = "ln";
        public const int OPR_LNE_INT = 5;

        /** 右大括号 */
        public const String OPR_LRB_EXP = "}";
        public const int OPR_LRB_INT = 7;
        /** 右中括号 */
        public const String OPR_MRB_EXP = "]";
        public const int OPR_MRB_INT = 8;
        /** 右小括号 */
        public const String OPR_SRB_EXP = ")";
        public const int OPR_SRB_INT = 9;

        /** 等号 */
        public const String OPR_EQU_EXP = "=";

        // ////////////////////////////////////////////////////////////////////////
        // 数据输入区域
        // ////////////////////////////////////////////////////////////////////////
        /** 0 */
        public const String NUM_0 = "0";
        /** 1 */
        public const String NUM_1 = "1";
        /** 2 */
        public const String NUM_2 = "2";
        /** 3 */
        public const String NUM_3 = "3";
        /** 4 */
        public const String NUM_4 = "4";
        /** 5 */
        public const String NUM_5 = "5";
        /** 6 */
        public const String NUM_6 = "6";
        /** 7 */
        public const String NUM_7 = "7";
        /** 8 */
        public const String NUM_8 = "8";
        /** 9 */
        public const String NUM_9 = "9";
        /** . */
        public const String NUM_D = ".";
        /** e */
        public const String NUM_E = "e";
        /** pi */
        public const String NUM_P = "π";

        // ////////////////////////////////////////////////////////////////////////
        // 结果显示区域
        // ////////////////////////////////////////////////////////////////////////
        /** HTML标记 */
        public const String TAG_HTML = "<html>{0}</html>";
        /** FONT标记 */
        public const String TAG_FONT = "<font color=\"#FF0000\">{0}</font>";
        /**  */
        public const String TAG_STEP = "= ";
    }
}