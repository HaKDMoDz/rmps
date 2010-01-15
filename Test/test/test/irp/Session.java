/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package test.irp;

import java.io.File;
import java.util.HashMap;

import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;

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
 * @author amon
 * 
 */
public class Session implements ISession
{
    private IProcess process;
    private IMessage message;
    private HashMap<String, Object> attribute;

    public Session()
    {
        attribute = new HashMap<String, Object>();
    }

    @Override
    public IMessage createMessage()
    {
        return null;
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        return null;
    }

    @Override
    public IContact getContact()
    {
        return null;
    }

    @Override
    public void reset()
    {
    }

    @Override
    public void send()
    {
    }

    @Override
    public void send(String message)
    {
        System.out.println(message);
    }

    @Override
    public void send(String message, boolean literal)
    {
        System.out.println(message);
    }

    @Override
    public void send(IMessage message)
    {
        System.out.println(message.getContent());
    }

    @Override
    public void send(IMessage message, boolean literal)
    {
        System.out.println(message.getContent());
    }

    @Override
    public IMessage read()
    {
        return message;
    }

    @Override
    public void save(IMessage message)
    {
        this.message = message;
    }

    @Override
    public void send(File file)
    {
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
