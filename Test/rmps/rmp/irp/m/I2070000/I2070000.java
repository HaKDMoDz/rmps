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
package rmp.irp.m.I2070000;

import java.util.List;

import rmp.bean.K1SV1S;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 网络导航
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 * 
 */
public class I2070000 implements IService
{

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#wInit()
     */
    @Override
    public boolean wInit()
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getCode()
     */
    @Override
    public String getCode()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getName()
     */
    @Override
    public String getName()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getDescription()
     */
    @Override
    public String getDescription()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getHelpTips()
     */
    @Override
    public List<K1SV1S> getHelpTips()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doHelp(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doInit(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doInit(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doMenu(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doDeal(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doDeal(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doStep(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doExit(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doRoot(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }
}
