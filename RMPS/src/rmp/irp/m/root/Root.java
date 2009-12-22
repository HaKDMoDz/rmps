/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.root;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.b.IStatus;
import com.amonsoft.util.LogUtil;
import rmp.irp.Irps;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Root implements IService
{
    public Root()
    {
    }

    @Override
    public boolean wInit()
    {
        LogUtil.log(getName() + " 初始化成功！");
        return true;
    }

    @Override
    public String getCode()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getName()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getDescription()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String msg = message.getContent();
        String tmp = msg.toLowerCase();
        if ("exit".equals(tmp))
        {
            session.send("再见……");
            Irps.exit(0);
        }

        if (tmp.indexOf("step ") == 0)
        {
            String[] arr = tmp.toLowerCase().split(" ");
            if (arr.length < 3)
            {
                return;
            }

            tmp = arr[2];
            if ("online".equals(tmp))
            {
                Irps.step(arr[1], IStatus.SIGN);
                return;
            }
            if ("offline".equals(tmp))
            {
                Irps.step(arr[1], IStatus.DOWN);
            }
            return;
        }
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }
}
