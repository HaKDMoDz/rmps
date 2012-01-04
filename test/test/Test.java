/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import java.io.Console;

import rmp.Rmps;
import rmp.comn.user.UserInfo;
import rmp.irp.m.I2070000.I2070000;
import test.irp.Message;
import test.irp.Session;

import com.amonsoft.rmps.irp.m.IService;
import com.skype.SkypeException;

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
public class Test
{

    public static void main(String[] args) throws Exception
    {
        test();
    }

    public static void test() throws SkypeException
    {
        UserInfo user = new UserInfo("Amon", "Amon");
        user.wInit();
        Rmps.setUser(user);

        Session session = new Session();
        Message message = new Message("hi");
        IService s = new I2070000();
        s.wInit();
        s.doInit(session, message);
        s.doDeal(session, message);
        Console console = System.console();
        if (console != null)
        {
            String line = console.readLine();
            while (!"exit".equals(line))
            {
                message.setContent(line);
                s.doDeal(session, message);
                line = console.readLine();
            }
        }
    }
}
