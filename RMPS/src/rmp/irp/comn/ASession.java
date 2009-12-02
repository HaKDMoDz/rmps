/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import java.util.HashMap;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
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
}
