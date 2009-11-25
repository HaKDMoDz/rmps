/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.v.aim;

import com.amonsoft.rmps.imp.v.IAccount;
import com.amonsoft.rmps.imp.v.IConnect;
import com.amonsoft.rmps.imp.b.IContact;
import com.amonsoft.rmps.imp.b.IStatus;
import com.wilko.jaim.Buddy;
import com.wilko.jaim.BuddyUpdateTocResponse;
import com.wilko.jaim.ConfigTocResponse;
import com.wilko.jaim.ConnectionLostTocResponse;
import com.wilko.jaim.ErrorTocResponse;
import com.wilko.jaim.EvilTocResponse;
import com.wilko.jaim.GotoTocResponse;
import com.wilko.jaim.Group;
import com.wilko.jaim.IMTocResponse;
import com.wilko.jaim.JaimConnection;
import com.wilko.jaim.JaimEvent;
import com.wilko.jaim.JaimEventListener;
import com.wilko.jaim.LoginCompleteTocResponse;
import com.wilko.jaim.TocResponse;
import com.wilko.jaim.Utils;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Enumeration;
import java.util.Iterator;
import java.util.List;
import rmp.util.Logs;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class AIM implements IAccount, JaimEventListener
{
    private IConnect connect;
    private JaimConnection messenger;

    @Override
    public void exit()
    {
        throw new UnsupportedOperationException("Not supported yet.");
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

                try
                {
                    messenger = new JaimConnection(conn.getServer(), conn.getPort());
                    // Send debugging to standard output
                    //messenger.setDebug(true);
                    messenger.connect();
                    messenger.addEventListener(this);
                    // Must watch at least one buddy or you will not appear on buddy listings
                    messenger.watchBuddy("unknownbuddy1212");
                    messenger.logIn(conn.getUser(), conn.getPwds(), 50000);
                    // Set Deny None
                    messenger.addBlock("");
//                    messenger.setInfo("This buddy is using <a href=\"http://jaimlib.sourceforge.net\">Jaim</a>.");
//                    messenger.setIdle(60);      // Pretend we have been idle for a minute
//                    messenger.setAway("I am away right now");
                }
                catch (Exception exp)
                {
                    Logs.log(exp);
                }
                break;
            case IStatus.DOWN:
                try
                {
                    messenger.disconnect();
                }
                catch (Exception exp)
                {
                    Logs.log(exp);
                }
                break;
            default:
                break;
        }
    }

    @Override
    public IConnect getConnect()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public IContact getContact(String user)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public List<IContact> getContact()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void receiveEvent(JaimEvent event)
    {
        TocResponse response = event.getTocResponse();
        String responseType = response.getResponseType();
        if (BuddyUpdateTocResponse.RESPONSE_TYPE.equalsIgnoreCase(responseType))
        {
            receiveBuddyUpdate((BuddyUpdateTocResponse) response);
            return;
        }
        else if (responseType.equalsIgnoreCase(IMTocResponse.RESPONSE_TYPE))
        {
            receiveIM((IMTocResponse) response);
        }
        else if (responseType.equalsIgnoreCase(EvilTocResponse.RESPONSE_TYPE))
        {
            receiveEvil((EvilTocResponse) response);
        }
        else if (responseType.equalsIgnoreCase(GotoTocResponse.RESPONSE_TYPE))
        {
            receiveGoto((GotoTocResponse) response);
        }
        else if (responseType.equalsIgnoreCase(ConfigTocResponse.RESPONSE_TYPE))
        {
            receiveConfig();
        }
        else if (responseType.equalsIgnoreCase(ErrorTocResponse.RESPONSE_TYPE))
        {
            receiveError((ErrorTocResponse) response);
        }
        else if (responseType.equalsIgnoreCase(LoginCompleteTocResponse.RESPONSE_TYPE))
        {
            System.out.println("Login is complete");
        }
        else if (responseType.equalsIgnoreCase(ConnectionLostTocResponse.RESPONSE_TYPE))
        {
            System.out.println("Connection lost!");
        }
        else
        {
            System.out.println("Unknown TOC Response:" + response.toString());
        }
    }

    private void receiveError(ErrorTocResponse et)
    {
        System.out.println("Error: " + et.getErrorDescription());
    }

    private void receiveIM(IMTocResponse im)
    {
        System.out.println(im.getFrom() + "->" + Utils.stripHTML(im.getMsg()));

        try
        {
            messenger.sendIM(im.getFrom(), "Hello " + im.getFrom(), false);
        }
        catch (IOException e)
        {
        }
    }

    private void receiveBuddyUpdate(BuddyUpdateTocResponse bu)
    {
        System.out.println("Buddy update: " + bu.getBuddy());
        if (bu.isOnline())
        {
            System.out.println("Online");
        }
        else
        {
            System.out.println("Offline");
        }

        if (bu.isAway())
        {
            System.out.println("Away");
        }

        System.out.println("evil: " + bu.getEvil());

        System.out.println("Idle: " + bu.getIdleTime());

        System.out.println("On since " + bu.getSignonTime().toString());
    }

    private void receiveEvil(EvilTocResponse er)
    {
        if (er.isAnonymous())
        {
            System.out.println("We have been warned anonymously!");
        }
        else
        {
            System.out.println("We have been warned by " + er.getEvilBy());
            try
            {
                messenger.sendEvil(er.getEvilBy(), false);     // Let's warn them back
                messenger.addBlock(er.getEvilBy());          // And block them
            }
            catch (Exception e)
            {
                e.printStackTrace();
            }
        }

        System.out.println("New warning level is:" + er.getEvilAmount());
    }

    private void receiveGoto(GotoTocResponse gr)
    {
        System.out.println("Attempting to access " + gr.getURL());
        try
        {
            InputStream is = messenger.getURL(gr.getURL());
            if (is != null)
            {
                InputStreamReader r = new InputStreamReader(is);
                int chr = 0;
                while (chr != -1)
                {
                    chr = r.read();
                    System.out.print((char) chr);
                }

            }
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    private void receiveConfig()
    {
        System.out.println("Config is now valid.");

        try
        {
            Iterator it = messenger.getGroups().iterator();
            while (it.hasNext())
            {
                Group g = (Group) it.next();
                System.out.println("Group: " + g.getName());
                Enumeration e = g.enumerateBuddies();
                while (e.hasMoreElements())
                {
                    Buddy b = (Buddy) e.nextElement();
                    b.setDeny(false);
                    b.setPermit(false);
                    messenger.watchBuddy(b.getName());
                    if (b.getDeny())
                    {
                        messenger.addBlock(b.getName());
                    }
                    if (b.getPermit())
                    {
                        messenger.addPermit(b.getName());
                    }
                }
            }
            messenger.saveConfig();
        }
        catch (Exception je)
        {
            je.printStackTrace();
        }
    }
}
