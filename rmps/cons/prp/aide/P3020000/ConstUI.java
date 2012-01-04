/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3020000;

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
 * 
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3020000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3020000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3020000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3020000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 匹配：所有匹配 * */
    char EXPS_MAT_ALL = '*';
    /** 匹配：单个匹配 ? */
    char EXPS_MAT_ONE = '?';
    /** 变量：大写变量 \ */
    char EXPS_VAR_UPP = '\\';
    /** 变量：小写变量 / */
    char EXPS_VAR_LOW = '/';
    /** 变量：数值变量 : */
    char EXPS_VAR_NUM = ':';
    /** 控制：大写控制 < */
    char EXPS_CTR_UPP = '<';
    /** 控制：小写控制 > */
    char EXPS_CTR_LOW = '>';
    /** 控制：字符查找 | */
    char EXPS_CTR_FND = '|';
    /** 选项：变量取值区间，其值必需成对出现 */
    char EXPS_OPT_PMS = '"';
    /** 临时文件命名公式 */
    String FILE_NAME_TEMP = "_Amon__{0}__Soft_";
}
