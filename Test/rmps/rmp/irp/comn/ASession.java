/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import java.util.HashMap;

import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IProcess;
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
public abstract class ASession implements ISession
{
    private IProcess process;
    private HashMap<String, Object> attribute;

    public ASession()
    {
        attribute = new HashMap<String, Object>();
    }

    @Override
    public void setAttribute(String key, Object obj)
    {
        attribute.put(key, obj);
    }

    @Override
    public Object getAttribute(String key)
    {
        return attribute.get(key);
    }

    @Override
    public String newLine()
    {
        return "\n";
    }

    @Override
    public IProcess getProcess()
    {
        if (process == null)
        {
            process = new Process();
        }
        return process;
    }

    /**
     * 添加路径信息
     * 
     * @param session
     * @param message
     * @return
     */
    protected static StringBuffer appendPath(ISession session, StringBuffer message)
    {
        IProcess process = session.getProcess();
        message.append("您当前的操作：/").append(process.getFunc()).append('（');
        IService service = Control.getService(process.getFunc());
        if (service != null)
        {
            message.append(service.getName());
        }
        message.append("）：");
        message.append(session.newLine()).append("------------------------------");
        message.append(session.newLine()).append(session.newLine());
        return message;
    }

    /**
     * 添加版权信息
     * 
     * @param session
     * @param message
     * @return
     */
    protected static StringBuffer appendCopy(ISession session, StringBuffer message)
    {
        if (message.lastIndexOf(session.newLine()) != message.length() - session.newLine().length())
        {
            message.append(session.newLine());
        }
        message.append(session.newLine()).append("------------------------------");
        message.append(session.newLine()).append("© Amonsoft @ http://amonsoft.com/");
        return message;
    }
}
