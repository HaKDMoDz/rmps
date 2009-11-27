/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import java.awt.Color;
import net.sf.jml.message.MsnInstantMessage;
import rmp.irp._comn.AMimeMessage;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MimeMessage extends AMimeMessage
{
    MsnInstantMessage message;

    @Override
    public boolean isBold()
    {
        return message.isBold();
    }

    @Override
    public void setBold(boolean bold)
    {
        message.setBold(bold);
    }

    @Override
    public boolean isItalic()
    {
        return message.isItalic();
    }

    @Override
    public void setItalic(boolean italic)
    {
        message.setItalic(italic);
    }

    @Override
    public boolean isRightAlign()
    {
        return message.isRightAlign();
    }

    @Override
    public void setRightAlign(boolean rightAlign)
    {
        message.setRightAlign(rightAlign);
    }

    @Override
    public boolean isStrikethrough()
    {
        return message.isStrikethrough();
    }

    @Override
    public void setStrikethrough(boolean strikethrough)
    {
        message.setStrikethrough(strikethrough);
    }

    @Override
    public boolean isUnderline()
    {
        return message.isUnderline();
    }

    @Override
    public void setUnderline(boolean underline)
    {
        message.setUnderline(underline);
    }

    @Override
    public Color getFontColor()
    {
        return new Color(message.getFontRGBColor());
    }

    @Override
    public void setFontColor(Color color)
    {
        message.setFontRGBColor(color.getRGB());
    }

    @Override
    public String getFontName()
    {
        return message.getFontName();
    }

    @Override
    public void setFontName(String name)
    {
        message.setFontName(name);
    }
}
