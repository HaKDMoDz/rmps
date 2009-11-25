/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

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
     * 数据有效性验证，数据为NULL或者有效长度小于的情况下返回false，其它情况下返回true
     * 
     * @param value 待进行有效性判断的字符串
     * @return 字符串是否为空：true字符串为有效字符串；false字符串为无效字符串
     */
    public static boolean isValidate(String text)
    {
        return (text != null && text.trim().length() > 0);
    }

    /**
     * 数组有效性验证，数组为NULL或者数组长度小于1的情况下返回false，其它情况下返回true
     * 
     * @param value
     * @return
     */
    public static boolean isValidate(String[] value)
    {
        if (value == null || value.length < 1)
        {
            return false;
        }

        return true;
    }

    /**
     * 字符串是否在指定长度之间(含NULL)
     * 
     * @param text
     * @param length
     * @return true字符串长度在指定长度之间
     */
    public static boolean isValidateLength(String text, int length)
    {
        if (text == null)
        {
            return true;
        }
        return text.length() <= length;
    }

    /**
     * 判定指定的字符串长度是否大于指定的长度。
     * 
     * @param text 待判定的字符串
     * @param maxLen 字符串的最大长度限制
     * @return 判定结果：true表示大于指定长度，false表示不大于指定长度
     */
    public static boolean isTooLong(String text, int maxLen)
    {
        if (!CheckUtil.isValidate(text))
        {
            return false;
        }

        return text.length() > maxLen;
    }

    /**
     * @param text
     * @param minLen
     * @param maxLen
     * @return
     */
    public static boolean isValidateLength(String text, int minLen, int maxLen)
    {
        int len = text.length();
        return (minLen <= len) && (len <= maxLen);
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
