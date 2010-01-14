/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import com.skype.Chat;
import com.skype.ChatMessage;
import com.skype.ChatMessageAdapter;
import com.skype.ContactList;
import com.skype.Friend;
import com.skype.Group;
import com.skype.Skype;
import com.skype.SkypeException;
import com.skype.User;

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
        ContactList list = Skype.getContactList();
        for (Friend f : list.getAllFriends())
        {
            System.out.println(f);
        }
        for (Group f : list.getAllGroups())
        {
            System.out.println(f);
        }
        for (Group f : list.getAllSystemGroups())
        {
            System.out.println(f);
        }
        // displayUsers("MFX");
    }

    public static void startListening() throws SkypeException
    {

        Skype.setDeamon(false);

        Skype.addChatMessageListener(new ChatMessageAdapter()
        {
            public void chatMessageReceived(ChatMessage received) throws SkypeException
            {
                // displayUsers(received);
                // autoAnswering(received, "I love this game", "huaran78", null,
                // "ÎÒÌß²»ÁË³¤ÍÈ£¡", 1, 1);
                // autoAnswering(received, "I love this game", "shangcm2006",
                // "Ë­ÄÜ°Ñ³¤ÍÈÌßÁË£¿", "ÎÒÌß²»ÁË³¤ÍÈ£¡", 1, 1);
                autoAnswering(received, "这是乱码 ", null, null, "Test", 20, 3);
            }
        });

    }

    public static void sendTo(String title, String msg, int len, int cnt) throws SkypeException
    {
        Chat[] chats = Skype.getAllActiveChats();
        for (int i = 0; i < chats.length; i++)
        {
            System.out.println(chats[i].getWindowTitle());
            if (chats[i].getWindowTitle().equals(title))
            {
                send(chats[i], msg, len, cnt);
                break;
            }
        }
    }

    public static void displayUsers(String title) throws SkypeException
    {
        Chat[] chats = Skype.getAllActiveChats();
        for (int i = 0; i < chats.length; i++)
        {
            System.out.println(chats[i].getWindowTitle());
            if (chats[i].getWindowTitle().equals(title))
            {

                System.out.println("title: " + chats[i].getWindowTitle());
                User[] users = chats[i].getAllActiveMembers();
                for (int j = 0; j < users.length; j++)
                {
                    System.out.println(users[j].getFullName() + "=" + users[j].getId());
                }
                break;
            }
        }
    }

    private static void autoAnswering(ChatMessage received, String title, String id, String content, String msg, int len, int cnt) throws SkypeException
    {

        Chat chat = received.getChat();

        if (!chat.getWindowTitle().equals(title))
        {
            System.out.println("ignore title: " + chat.getWindowTitle());
            return;
        }

        if (content != null && !received.getSender().getId().equals(id))
        {
            System.out.println("ignore id: " + received.getSender());
            return;
        }

        if (content != null && !received.getContent().equals(content))
        {
            System.out.println("ignore content: " + received.getContent());
            return;
        }

        send(chat, msg, len, cnt);

    }

    private static void send(Chat chat, String msg, int len, int cnt) throws SkypeException
    {
        for (int i = 1; i <= len * cnt; i++)
        {
            StringBuffer sb = new StringBuffer();
            int x = i % (len * 2);
            int l = 0;

            if (x < len)
            {
                l = x;
            }
            else
            {
                l = (len * 2) - x;
            }

            for (int j = 0; j < l; j++)
            {
                sb.append(msg);
            }

            chat.send(sb.toString());
        }

        System.out.println("Send OK!");
    }
}
