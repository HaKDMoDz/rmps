/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
/*
 * 
 */
package rmp.irp.util;

import java.util.regex.Pattern;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author amon
 * 
 */
public class IrpsUtil
{
    /**
     * 数字正则表达式
     */
    private static Pattern szReg = Pattern.compile("^[\\d０１２３４５６７８９]%");
    /**
     * 汉字正则表达式
     */
    private static Pattern hzReg = Pattern.compile("^[\\d０１２３４５６７８９]%");
    /**
     * 拼音正则表达式
     */
    private static Pattern pyReg = Pattern.compile("^[\\d０１２３４５６７８９]%");

    /**
     * 是否为纯数字
     * 
     * @param txt
     * @return
     */
    public static boolean isSZ(String txt)
    {
        return szReg.matcher(txt).matches();
    }

    /**
     * 是否为纯汉字
     * 
     * @param txt
     * @return
     */
    public static boolean isHZ(String txt)
    {
        return hzReg.matcher(txt).matches();
    }

    /**
     * 是否为纯拼音
     * 
     * @param txt
     * @return
     */
    public static boolean isPY(String txt)
    {
        return pyReg.matcher(txt).matches();
    }
}
