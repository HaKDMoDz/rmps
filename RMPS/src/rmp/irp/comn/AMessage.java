/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import com.amonsoft.rmps.irp.b.IMessage;
import java.io.UnsupportedEncodingException;
import java.nio.charset.Charset;
import com.amonsoft.util.LogUtil;
import rmp.util.Util;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public abstract class AMessage implements IMessage
{
    private String content;
    private String contentType;
    private String encoding;
    private String messageUID;
    private byte[] rawData;
    private String subject;

    protected AMessage()
    {
    }

    protected AMessage(String content, String contentType, String encoding, String subject)
    {
        this.contentType = contentType;
        this.subject = subject;

        setEncoding(encoding);
        setContent(content);

        this.messageUID = createMessageUID();
    }

    protected AMessage(String content, String contentType, String encoding, String subject, String messageUID)
    {
        this.contentType = contentType;
        this.subject = subject;

        setEncoding(encoding);
        setContent(content);

        this.messageUID = messageUID;
    }

    /**
     * @return the content
     */
    @Override
    public String getContent()
    {
        return content;
    }

    /**
     * @param content the content to set
     */
    @Override
    public void setContent(String content)
    {
        if (!Util.equals(this.content, content))
        {
            this.content = content;
            this.rawData = null;
        }
    }

    /**
     * @return the contentType
     */
    @Override
    public String getContentType()
    {
        return contentType;
    }

    /**
     * @param contentType the contentType to set
     */
    @Override
    public void setContentType(String contentType)
    {
        this.contentType = contentType;
    }

    /**
     * @return the encoding
     */
    @Override
    public String getEncoding()
    {
        return encoding;
    }

    /**
     * @param encoding the encoding to set
     */
    @Override
    public void setEncoding(String encoding)
    {
        if (!Util.equals(this.encoding, encoding))
        {
            this.encoding = encoding;
            this.rawData = null;
        }
    }

    /**
     * @return the messageUID
     */
    @Override
    public String getMessageUID()
    {
        return messageUID;
    }

    protected String createMessageUID()
    {
        return String.valueOf(System.currentTimeMillis()) + String.valueOf(hashCode());
    }

    /**
     * @return the rawData
     */
    @Override
    public byte[] getRawData()
    {
        if (rawData == null)
        {
            boolean useDefaultEncoding = true;
            if (encoding != null)
            {
                try
                {
                    rawData = content.getBytes(encoding);
                    useDefaultEncoding = false;
                }
                catch (UnsupportedEncodingException exp)
                {
                    LogUtil.exception(exp);
                }
            }
            if (useDefaultEncoding)
            {
                setEncoding(Charset.defaultCharset().name());
                rawData = content.getBytes();
            }
        }
        return rawData;
    }

    /**
     * @param rawData the rawData to set
     */
    public void setRawData(byte[] rawData)
    {
        this.rawData = rawData;
    }

    /**
     * @return the subject
     */
    @Override
    public String getSubject()
    {
        return subject;
    }

    /**
     * @param subject the subject to set
     */
    @Override
    public void setSubject(String subject)
    {
        this.subject = subject;
    }
}
