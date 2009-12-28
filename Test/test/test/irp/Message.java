package test.irp;

import com.amonsoft.rmps.irp.b.IMessage;

public class Message implements IMessage
{
    private String message;

    public Message(String msg)
    {
        message = msg;
    }

    @Override
    public String getContent()
    {
        return message;
    }

    @Override
    public void setContent(String content)
    {
        message = content;
    }

    @Override
    public String getContentType()
    {
        return "";
    }

    @Override
    public String getEncoding()
    {
        return "";
    }

    @Override
    public String getMessageUID()
    {
        return "";
    }

    @Override
    public byte[] getRawData()
    {
        return "".getBytes();
    }

    @Override
    public String getSubject()
    {
        return "";
    }

    @Override
    public void setContentType(String contentType)
    {
    }

    @Override
    public void setEncoding(String encoding)
    {
    }

    @Override
    public void setSubject(String subject)
    {
    }
}
