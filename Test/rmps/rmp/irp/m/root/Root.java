/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.root;

import rmp.irp.Irps;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
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
        return "";
    }

    @Override
    public String getName()
    {
        return "";
    }

    @Override
    public String getDescription()
    {
        return "";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.toLowerCase();
        if ("exit".equals(tmp))
        {
            session.send("再见……");
            Irps.exit(0);
            return;
        }
        if ("52010000".equals(tmp))
        {
            return;
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
                Irps.step(arr[1], IPresence.SIGN);
                return;
            }
            if ("offline".equals(tmp))
            {
                Irps.step(arr[1], IPresence.DOWN);
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

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }
}
