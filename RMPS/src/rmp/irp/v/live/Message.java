/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import net.sf.jml.message.MsnInstantMessage;
import rmp.irp._comn.AMessage;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Message extends AMessage
{
    MsnInstantMessage message;

    Message(MsnInstantMessage message)
    {
        this.message = message;
    }

    @Override
    public String getContent()
    {
        return message.getContent();
    }

    @Override
    public void setContent(String content)
    {
        message.setContent(content);
    }
}
