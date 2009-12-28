/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import rmp.Rmps;
import rmp.comn.user.UserInfo;
import rmp.irp.m.I7010000.I7010000;
import test.irp.Message;
import test.irp.Session;

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
public class Test
{
    /**
     * @param args
     */
    public static void main(String[] args)
    {
        test();
    }

    public static void test()
    {
        UserInfo user = new UserInfo("Amon", "Amon");
        user.wInit();
        Rmps.setUser(user);

        Session session = new Session();
        Message message = new Message("118.132.166.12");
        IService s = new I7010000();
        s.wInit();
        s.doInit(session, message);
        s.doDeal(session, message);
    }
}
