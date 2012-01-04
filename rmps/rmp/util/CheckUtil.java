/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import com.amonsoft.util.CharUtil;

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
public final class CheckUtil
{
    /**
     * 对象非空
     * 
     * @param obj
     * @return true对象不为NULL
     */
    public static boolean isNotNull(Object obj)
    {
        return obj != null;
    }

    /**
     * 判定指定的字符串长度是否大于指定的长度。
     * 
     * @param text
     *            待判定的字符串
     * @param maxLen
     *            字符串的最大长度限制
     * @return 判定结果：true表示大于指定长度，false表示不大于指定长度
     */
    public static boolean isTooLong(String text, int maxLen)
    {
        if (!CharUtil.isValidate(text))
        {
            return false;
        }

        return text.length() > maxLen;
    }

    /**
     * 字符串是否为符合格式的邮件信息
     * 
     * @param text
     * @return
     */
    public static boolean isValidateMail(String text)
    {
        if (text == null)
        {
            return false;
        }

        int ai = text.indexOf('@');
        int di = text.lastIndexOf('.');
        return (0 < ai) && (ai < di);
    }

    /**
     * @param text
     * @return
     */
    public static boolean isValidateUrl(String text)
    {
        return true;
    }
}
