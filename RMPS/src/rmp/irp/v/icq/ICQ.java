/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.icq;

import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import com.amonsoft.rmps.irp.v.IAccount;

import java.util.List;

import net.kano.joscar.flap.ClientFlapConn;
import net.kano.joscar.flap.FlapPacketEvent;
import net.kano.joscar.flap.FlapPacketListener;
import net.kano.joscar.flap.FlapProcessor;
import net.kano.joscar.flapcmd.DefaultFlapCmdFactory;
import net.kano.joscar.net.ClientConnEvent;
import net.kano.joscar.net.ClientConnListener;
import net.kano.joscar.net.ConnDescriptor;
import net.kano.joscar.net.ConnProcessorExceptionEvent;
import net.kano.joscar.net.ConnProcessorExceptionHandler;
import net.kano.joscar.snac.ClientSnacProcessor;
import net.kano.joscar.snac.FamilyVersionPreprocessor;
import net.kano.joscar.snac.SnacPacketEvent;
import net.kano.joscar.snac.SnacPacketListener;
import net.kano.joscar.snac.SnacResponseEvent;
import net.kano.joscar.snaccmd.DefaultClientFactoryList;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ICQ implements IAccount, ClientConnListener, FlapPacketListener, SnacPacketListener, ConnProcessorExceptionHandler
{
    private IConnect connect;
    private ClientFlapConn messenger;
    protected ClientSnacProcessor processor;

    public ICQ()
    {
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IStatus.INIT:
                break;
            case IStatus.LINE:
                Connect conn = new Connect();
                conn.load();
                connect = conn;

                messenger = new ClientFlapConn(new ConnDescriptor(conn.getServer(), conn.getPort()));
                messenger.addConnListener(this);

                FlapProcessor flap = messenger.getFlapProcessor();
                flap.setFlapCmdFactory(new DefaultFlapCmdFactory());
                flap.addPacketListener(this);
                flap.addExceptionHandler(this);

                processor = new ClientSnacProcessor(flap);
                processor.addPreprocessor(new FamilyVersionPreprocessor());
                processor.getCmdFactoryMgr().setDefaultFactoryList(new DefaultClientFactoryList());
                processor.addPacketListener(this);
                break;
            case IStatus.DOWN:
                break;
            default:
                break;
        }
    }

    @Override
    public void exit()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public List<IContact> getContact()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IContact getContact(String user)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IConnect getConnect()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    protected void handleStateChange(ClientConnEvent e)
    {
    }

    protected void handleSnacResponse(SnacResponseEvent e)
    {
    }

    @Override
    public void stateChanged(ClientConnEvent arg0)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void handleFlapPacket(FlapPacketEvent arg0)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void handleSnacPacket(SnacPacketEvent arg0)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void handleException(ConnProcessorExceptionEvent arg0)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
