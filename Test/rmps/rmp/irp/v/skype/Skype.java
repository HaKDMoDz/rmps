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
package rmp.irp.v.skype;

import java.util.ArrayList;
import java.util.List;

import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.skype.ChatMessage;
import com.skype.ChatMessageListener;
import com.skype.Friend;
import com.skype.SkypeException;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * Skype
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 * 
 */
public class Skype implements IAccount, ChatMessageListener
{
    private static List<IContact> contacts;

    @Override
    public void exit()
    {
    }

    @Override
    public void sign(int status)
    {
        try
        {
            switch (status)
            {
                case IPresence.INIT:
                    break;
                case IPresence.LINE:
                    com.skype.Skype.addChatMessageListener(this);
                    break;
                case IPresence.DOWN:
                    break;
                default:
                    break;
            }
        }
        catch (Exception exp)
        {
            exp.printStackTrace();
        }
    }

    @Override
    public IConnect getConnect()
    {
        return null;
    }

    @Override
    public IContact getContact(String user)
    {
        return null;
    }

    @Override
    public List<IContact> getContact()
    {
        if (contacts == null)
        {
            try
            {
                contacts = new ArrayList<IContact>();
                for (Friend contact : com.skype.Skype.getContactList().getAllFriends())
                {
                    contacts.add(new Contact(contact));
                }
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }
        return contacts;
    }

    @Override
    public void chatMessageReceived(ChatMessage arg0) throws SkypeException
    {
    }

    @Override
    public void chatMessageSent(ChatMessage arg0) throws SkypeException
    {
    }
}
