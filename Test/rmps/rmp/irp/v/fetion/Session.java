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

import java.io.File;

import rmp.irp.comn.ASession;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;

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
     * @see
     * com.amonsoft.rmps.irp.b.ISession#send(com.amonsoft.rmps.irp.b.IMimeMessage
     * )
     */
    @Override
    public void send(IMimeMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.b.ISession#send(com.amonsoft.rmps.irp.b.IMimeMessage
     * , boolean)
     */
    @Override
    public void send(IMimeMessage message, boolean literal)
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
