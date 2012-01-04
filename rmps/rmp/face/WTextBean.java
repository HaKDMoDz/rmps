/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.face;

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
public interface WTextBean extends WBean
{
    /**
     * 设置构件的显示文本信息，并根据是否为Hash索引值决定是否查寻对应的语言资源
     * 
     * @param text
     *            要设置的字符串数据
     * @param isHash
     *            当前字符串是否为Hash索引值：true是；false不是。
     */
    void setWText(String text, boolean isHash);
}
