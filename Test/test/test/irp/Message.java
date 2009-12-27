package test.irp;

import rmp.irp.comn.AMessage;

public class Message extends AMessage
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
}
