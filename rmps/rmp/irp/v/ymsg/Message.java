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
package rmp.irp.v.ymsg;

import com.amonsoft.rmps.irp.b.IMessage;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class Message implements IMessage
{
    private String content;

    Message()
    {
    }

    Message(String content)
    {
        if (content != null)
        {
            content = content.replaceAll("<[^>]*>", "").replaceAll(".*?Cm", "");
        }
        this.content = content;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#getContent()
     */
    @Override
    public String getContent()
    {
        return content;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#getContentType()
     */
    @Override
    public String getContentType()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#getEncoding()
     */
    @Override
    public String getEncoding()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#getMessageUID()
     */
    @Override
    public String getMessageUID()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#getRawData()
     */
    @Override
    public byte[] getRawData()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#getSubject()
     */
    @Override
    public String getSubject()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#setContent(java.lang.String)
     */
    @Override
    public void setContent(String content)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#setContentType(java.lang.String)
     */
    @Override
    public void setContentType(String contentType)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#setEncoding(java.lang.String)
     */
    @Override
    public void setEncoding(String encoding)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IMessage#setSubject(java.lang.String)
     */
    @Override
    public void setSubject(String subject)
    {
    }
}
