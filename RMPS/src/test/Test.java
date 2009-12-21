/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import java.io.File;
import java.io.FileInputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.Node;
import org.dom4j.io.SAXReader;
import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.ConnectionConfiguration;
import org.jivesoftware.smack.MessageListener;
import org.jivesoftware.smack.XMPPConnection;
import org.jivesoftware.smack.packet.Message;
import org.jivesoftware.smackx.filetransfer.FileTransfer;
import org.jivesoftware.smackx.filetransfer.FileTransferManager;
import org.jivesoftware.smackx.filetransfer.OutgoingFileTransfer;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Test
{
    /**
     * @param args
     */
    public static void main(String[] args)
    {
        try
        {
            SAXReader saxr = new SAXReader();
            Document document = saxr.read(new FileInputStream("dat/60000000/irp/50000000.xml"));
            Element element = document.getRootElement();
            for (Object obj1 : element.elements("item[@id='映像']/map"))
            {
                Node node = (Node) obj1;
            }
        }
        catch (Exception ex)
        {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void bb()
    {
        String user = "amon.rg";
        String host = "meebo.org";
        int port = 5222;
        String username = "Amon.CT";
        String password = "!~g_OQ5;";
        ConnectionConfiguration config = new ConnectionConfiguration(host, port);
        config.setCompressionEnabled(true);
        config.setSASLAuthenticationEnabled(true);

        XMPPConnection connection = new XMPPConnection(config);

        try
        {
            connection.connect();

            connection.login(username, password);

            //sendFile(user, getFile(), connection);
            sendTextMessage(user, connection);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        finally
        {
            connection.disconnect();
        }


    }

    public static File getFile()
    {
        File file = new File("D:/test.jpg");
        return file;
    }

//发送文件
    public static void sendFile(String user, File file, XMPPConnection connection) throws Exception
    {
        FileTransferManager manager = new FileTransferManager(connection);
        OutgoingFileTransfer transfer = manager.createOutgoingFileTransfer(user);
        long timeOut = 1000000;
        long sleepMin = 3000;
        long spTime = 0;
        int rs = 0;

        transfer.sendFile(file, "pls re file!");
        rs = transfer.getStatus().compareTo(FileTransfer.Status.complete);
        while (rs != 0)
        {
            rs = transfer.getStatus().compareTo(FileTransfer.Status.complete);
            spTime = spTime + sleepMin;
            if (spTime > timeOut)
            {
                return;
            }
            Thread.sleep(sleepMin);
        }

    }

//发送文本
    public static void sendTextMessage(String user, XMPPConnection connection) throws Exception
    {
        Chat chat = connection.getChatManager().createChat(user, new MessageListener()
        {
            @Override
            public void processMessage(Chat chat, Message message)
            {
                System.out.println("Received message: " + message);
            }
        });
        chat.sendMessage("Hi Test Send Message........!");
    }
}
