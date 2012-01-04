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
package rmp.irp.v.skype;

import java.io.File;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;

import rmp.irp.comn.ASession;

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
 * @author Amon
 * 
 */
public class Session extends ASession
{
    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#createMessage()
     */
    @Override
    public IMessage createMessage()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#createMimeMessage()
     */
    @Override
    public IMimeMessage createMimeMessage()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#getContact()
     */
    @Override
    public IContact getContact()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#reset()
     */
    @Override
    public void reset()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#send()
     */
    @Override
    public void send()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#send(java.lang.String)
     */
    @Override
    public void send(String message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#send(java.lang.String, boolean)
     */
    @Override
    public void send(String message, boolean literal)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.b.ISession#send(com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void send(IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.b.ISession#send(com.amonsoft.rmps.irp.b.IMessage,
     * boolean)
     */
    @Override
    public void send(IMessage message, boolean literal)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.ISession#send(java.io.File)
     */
    @Override
    public void send(File file)
    {
    }
}
