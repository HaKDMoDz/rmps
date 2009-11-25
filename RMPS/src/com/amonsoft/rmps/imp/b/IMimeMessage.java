/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.imp.b;

import com.amonsoft.rmps.imp.b.IMessage;
import java.awt.Color;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface IMimeMessage extends IMessage
{
    /**
     * 获取消息内容是否为粗体
     * @return
     */
    boolean isBold();

    /**
     * 设置消息内容是否为粗体
     * @param bold
     */
    void setBold(boolean bold);

    /**
     * 获取消息内容是否为斜体
     * @return
     */
    boolean isItalic();

    /**
     * 设置消息内容是否为斜体
     * @param italic
     */
    void setItalic(boolean italic);

    boolean isRightAlign();

    void setRightAlign(boolean rightAlign);

    boolean isStrikethrough();

    void setStrikethrough(boolean strikethrough);

    boolean isUnderline();

    void setUnderline(boolean underline);

    Color getFontColor();

    void setFontColor(Color color);

    String getFontName();

    void setFontName(String name);
}
