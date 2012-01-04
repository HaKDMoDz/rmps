/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P30F0000;

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
    String VER_CODE = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P30F0000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P30F0000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P30F0000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P30F0000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 用户配置标记
    // ////////////////////////////////////////////////////////////////////////
    String CFG_USER = "P30F0000.user";
    /** 软件配置数据 */
    String CFG_INFO = "P30F0000.info";
    // ////////////////////////////////////////////////////////////////////////
    // 用户配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 组件名称 */
    String[] RECORD_PROP_NAME =
    {
        "info", "text", "pwds", "link", "mail", "area", "date", "meta"
    };
    /** 信息 */
    int RECORD_TYPE_INFO = 0;
    /** 文本 */
    int RECORD_TYPE_TEXT = RECORD_TYPE_INFO + 1;
    /** 密码 */
    int RECORD_TYPE_PWDS = RECORD_TYPE_TEXT + 1;
    /** 链接 */
    int RECORD_TYPE_LINK = RECORD_TYPE_PWDS + 1;
    /** 邮件 */
    int RECORD_TYPE_MAIL = RECORD_TYPE_LINK + 1;
    /** 说明 */
    int RECORD_TYPE_AREA = RECORD_TYPE_MAIL + 1;
    /** 时间 */
    int RECORD_TYPE_DATE = RECORD_TYPE_AREA + 1;
    /** 名称 */
    int RECORD_TYPE_META = RECORD_TYPE_DATE + 1;
    /** 单个数据块大小 */
    int RECORD_DATA_SIZE = 2048;
    /**  */
    int FIXED_ROW_NUM = 2;
    /** 口令状态：新建 */
    String PWDS_STAT_0 = "0";
    /** 口令状态：使用中 */
    String PWDS_STAT_1 = "1";
    /** 口令状态：未使用 */
    String PWDS_STAT_2 = "2";
    /** 口令状态：已删除 */
    String PWDS_STAT_3 = "3";
    /** 散列算法 */
    String NAME_DIGEST = "SHA-512";
    /** 加密算法 */
    String NAME_CIPHER = "AES";
    /** 同一元素键值区分标记 */
    String SP_KV = "\b";
    /** 不同元素间隔区分标记 */
    String SP_EE = "\f";
    String ROOT_HASH = "sctfxrczgcywxezs";
    String SP_LS = "<";
    String SP_RS = ">";
    // ////////////////////////////////////////////////////////////////////////
    // 系统图标
    // ////////////////////////////////////////////////////////////////////////
    /** 查询 */
    String ICON_P30F0001 = "P30F0001.png";
    /** 向上移动 */
    String ICON_P30F0002 = "P30F0002.png";
    /** 向下移动 */
    String ICON_P30F0003 = "P30F0003.png";
    /** 复制 */
    String ICON_P30F0012 = "P30F0012.png";
    char CHAR_P30F0012 = 'C';
    /** 更新 */
    String ICON_P30F0013 = "P30F0013.png";
    char CHAR_P30F0013 = 'U';
    /** 删除 */
    String ICON_P30F0014 = "P30F0014.png";
    char CHAR_P30F0014 = 'D';
    /** 隐藏口令 */
    String ICON_P30F0021 = "P30F0021.png";
    char CHAR_P30F0021 = 'V';
    /** 显示口令 */
    String ICON_P30F0022 = "P30F0022.png";
    /** 生成口令 */
    String ICON_P30F0023 = "P30F0023.png";
    char CHAR_P30F0023 = 'G';
    /** 口令配置 */
    String ICON_P30F0024 = "P30F0024.png";
    char CHAR_P30F0024 = 'K';
    /** 打开链接 */
    String ICON_P30F0031 = "P30F0031.png";
    char CHAR_P30F0031 = 'B';
    /** 发送邮件 */
    String ICON_P30F0041 = "P30F0041.png";
    char CHAR_P30F0041 = 'E';
    // ////////////////////////////////////////////////////////////////////////
    // 口令空间
    // ////////////////////////////////////////////////////////////////////////
    String SETS_NUMBER = "0";
    String SETS_LOWER = "1";
    String SETS_UPPER = "2";
    String SETS_SPECIAL = "3";
    String SETS_LETTER = "4";
    String SETS_NUMBER_LETTER = "5";
    String SETS_ASCII_CHARACTER = "6";
}
