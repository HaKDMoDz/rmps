/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3060000;

import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "1.2.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3060000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3060000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3060000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3060000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 操作符优先级标记
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 0 级运算
    // ----------------------------------------------------
    /** 左大括号 */
    String OPR_LLB_EXP = "{";
    int OPR_LLB_INT = 0;
    /** 左中括号 */
    String OPR_MLB_EXP = "[";
    int OPR_MLB_INT = 1;
    /** 左小括号 */
    String OPR_SLB_EXP = "(";
    int OPR_SLB_INT = 2;
    // ----------------------------------------------------
    // 1 级运算
    // ----------------------------------------------------
    /** 加 */
    String OPR_ADD_EXP = "+";
    int OPR_ADD_INT = 3;
    /** 减 */
    String OPR_SUB_EXP = "-";
    int OPR_SUB_INT = 3;
    // ----------------------------------------------------
    // 2 级运算
    // ----------------------------------------------------
    /** 乘 */
    String OPR_MUL_EXP = "*";
    int OPR_MUL_INT = 4;
    /** 除 */
    String OPR_DIV_EXP = "/";
    int OPR_DIV_INT = 4;
    // ----------------------------------------------------
    // 3 级运算
    // ----------------------------------------------------
    /** 取模 */
    String OPR_MOD_EXP = "%";
    int OPR_MOD_INT = 5;
    /** 次幂 */
    String OPR_POW_EXP = "^";
    int OPR_POW_INT = 5;
    /** 方根 */
    String OPR_ROT_EXP = "√";
    int OPR_ROT_INT = 5;
    /** 阶乘 */
    String OPR_FAC_EXP = "!";
    int OPR_FAC_INT = 5;
    /** 正弦 */
    String OPR_SIN_EXP = "sin";
    int OPR_SIN_INT = 5;
    /** 余弦 */
    String OPR_COS_EXP = "cos";
    int OPR_COS_INT = 5;
    /** 正切 */
    String OPR_TAN_EXP = "tan";
    int OPR_TAN_INT = 5;
    /** 正割 */
    String OPR_SEC_EXP = "sec";
    int OPR_SEC_INT = 5;
    /** 余割 */
    String OPR_CSC_EXP = "csc";
    int OPR_CSC_INT = 5;
    /** 余切 */
    String OPR_COT_EXP = "cot";
    int OPR_COT_INT = 5;
    /** 10的对数 */
    String OPR_LOG_EXP = "log";
    int OPR_LOG_INT = 5;
    /** 自然对数 */
    String OPR_LNE_EXP = "ln";
    int OPR_LNE_INT = 5;
    /** 右大括号 */
    String OPR_LRB_EXP = "}";
    int OPR_LRB_INT = 7;
    /** 右中括号 */
    String OPR_MRB_EXP = "]";
    int OPR_MRB_INT = 8;
    /** 右小括号 */
    String OPR_SRB_EXP = ")";
    int OPR_SRB_INT = 9;
    /** 等号 */
    String OPR_EQU_EXP = "=";
    // ////////////////////////////////////////////////////////////////////////
    // 数据输入区域
    // ////////////////////////////////////////////////////////////////////////
    /** 0 */
    String NUM_0 = "0";
    /** 1 */
    String NUM_1 = "1";
    /** 2 */
    String NUM_2 = "2";
    /** 3 */
    String NUM_3 = "3";
    /** 4 */
    String NUM_4 = "4";
    /** 5 */
    String NUM_5 = "5";
    /** 6 */
    String NUM_6 = "6";
    /** 7 */
    String NUM_7 = "7";
    /** 8 */
    String NUM_8 = "8";
    /** 9 */
    String NUM_9 = "9";
    /** . */
    String NUM_D = ".";
    /** e */
    String NUM_E = "e";
    /** pi */
    String NUM_P = "π";
    // ////////////////////////////////////////////////////////////////////////
    // 结果显示区域
    // ////////////////////////////////////////////////////////////////////////
    /** HTML标记 */
    String TAG_HTML = "<html>{0}</html>";
    /** FONT标记 */
    String TAG_FONT = "<font color=\"#FF0000\">{0}</font>";
    /**  */
    String TAG_STEP = "= ";
}
