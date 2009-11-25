/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.v.xmpp;

import rmp.imp._comn.AMessage;

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
    org.jivesoftware.smack.packet.Message message;

    Message(org.jivesoftware.smack.packet.Message message)
    {
        this.message = message;
    }

    @Override
    public String getContent()
    {
        return message.getBody();
    }

    @Override
    public void setContent(String content)
    {
        message.setBody(content);
    }
}
