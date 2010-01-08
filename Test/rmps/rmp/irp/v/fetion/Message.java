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
package rmp.irp.v.fetion;

import rmp.irp.comn.AMessage;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class Message extends AMessage
{
    /**
     * 
     */
    public Message()
    {
    }

    /**
     * @param content
     */
    public Message(String content)
    {
        this.content = content;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.irp.comn.AMessage#getContent()
     */
    @Override
    public String getContent()
    {
        return content;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.irp.comn.AMessage#setContent(java.lang.String)
     */
    @Override
    public void setContent(String content)
    {
        this.content = content;
    }
}
