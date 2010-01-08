/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.fetion;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.swing.Timer;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.Node;

import rmp.irp.c.Control;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.util.CharUtil;

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
public class Fetion implements IAccount
{
    private Connect connect;
    /**
     * 会话列表
     */
    private HashMap<String, Session> sessions;
    /**
     * 目录列表
     */
    private List<Catalog> catalogs = new ArrayList<Catalog>();
    /**
     * 人员列表
     */
    private List<IContact> contacts = new ArrayList<IContact>();
    private Timer timer;

    public Fetion()
    {
    }

    @Override
    public void exit()
    {
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IPresence.INIT:
                sessions = new HashMap<String, Session>();
                connect = new Connect(this);
                connect.load();
                timer = new Timer(10000, new ActionListener()
                {
                    @Override
                    public void actionPerformed(ActionEvent arg0)
                    {
                        connect.sendKeepAlive();
                    }
                });
                break;

            case IPresence.SIGN:
                if (connect.login() == Constant.LOGIN_SUCC)
                {
                    connect.initDisplay();
                    connect.initCatalog();
                    timer.start();
                }
                else
                {
                    timer.stop();
                    connect.close();
                }
                break;

            case IPresence.DOWN:
                connect.logout();
                break;

            default:
                break;
        }
    }

    @Override
    public IConnect getConnect()
    {
        return connect;
    }

    @Override
    public IContact getContact(String user)
    {
        for (IContact contact : contacts)
        {
            if (user.equals(contact.getId()))
            {
                return contact;
            }
        }
        return null;
    }

    @Override
    public List<IContact> getContact()
    {
        return contacts;
    }

    /**
     * 联系人列表更新
     * 
     * @param res
     */
    boolean readCatalog(String text)
    {
        if (!CharUtil.isValidate(text))
        {
            return false;
        }

        try
        {
            Document doc = DocumentHelper.parseText(text);
            catalogs.clear();
            Catalog catalog = new Catalog("0", "Not Grouped");
            catalogs.add(catalog);

            Node node = doc.selectSingleNode("/results/contacts");
            if (node == null)
            {
                return false;
            }

            HashMap<String, ICatalog> map = new HashMap<String, ICatalog>();
            map.put(catalog.getId(), catalog);

            Element element;
            for (Object obj : node.selectNodes("buddy-lists/buddy-list"))
            {
                element = (Element) obj;
                catalog = new Catalog(element.attributeValue("id"), element.attributeValue("name"));
                catalogs.add(catalog);
                map.put(catalog.getId(), catalog);
            }

            Contact contact;
            for (Object obj : node.selectNodes("buddies/buddy"))
            {
                element = (Element) obj;
                contact = new Contact();
                contact.setId(element.attributeValue("user-id"));
                contact.setUri(element.attributeValue("uri"));
                contact.setDisplayName(element.attributeValue("local-name"));
                contact.addCatalog(map.get(element.attributeValue("buddy-lists")));
                contacts.add(contact);
            }
            for (Object obj : node.selectNodes("buddies/mobile-buddies"))
            {
                element = (Element) obj;
                contact = new Contact();
                contact.setId(element.attributeValue("user-id"));
                contact.setUri(element.attributeValue("uri"));
                contact.setDisplayName(element.attributeValue("local-name"));
                contact.addCatalog(map.get(element.attributeValue("buddy-lists")));
                contacts.add(contact);
            }
            for (Object obj : node.selectNodes("buddies/blacklist"))
            {
                element = (Element) obj;

                contact = new Contact();
                contact.setId(element.attributeValue("user-id"));
                contact.setUri(element.attributeValue("uri"));
                contact.setDisplayName(element.attributeValue("local-name"));
                contacts.add(contact);
            }

            sendContact();
            sendPresence();
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /**
     * 联系人详细信息更新
     * 
     * @param text
     */
    boolean readContact(String text)
    {
        if (!CharUtil.isValidate(text))
        {
            return false;
        }
        try
        {
            Document doc = DocumentHelper.parseText(text);
            Element e1;
            for (Object o1 : doc.selectNodes("/results/contacts/contact"))
            {
                e1 = (Element) o1;
                String uri = e1.attributeValue("uri");
                LogUtil.log(uri);
                Contact contact;
                for (IContact tmp : contacts)
                {
                    contact = (Contact) tmp;
                    if (uri.equals(contact.getUri()))
                    {
                        Presence presence = new Presence();
                        // presence.setImc(e1.attributeValue("value"));
                        presence.setFsc(e1.attributeValue("status-code"));
                        contact.setPresence(presence);

                        e1 = e1.element("personal");
                        contact.setPersonalMessage(e1.attributeValue("impresa"));// 心情
                        contact.setName(e1.attributeValue("nickname"));
                        contact.setMobile(e1.attributeValue(" mobile-no"));
                        break;
                    }
                }
            }
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    boolean readPresence(String text)
    {
        if (!CharUtil.isValidate(text))
        {
            return false;
        }

        try
        {
            Document doc = DocumentHelper.parseText(text);
            Element ele = (Element) doc.selectSingleNode("/events/event");
            if (!"PresenceChanged".equalsIgnoreCase(ele.attributeValue("type")))
            {
                return false;
            }
            ele = ele.element("presence");

            // 查找用户
            Contact contact = (Contact) getContact(ele.attributeValue("uri"));
            if (contact == null)
            {
                return false;
            }

            // 用户状态
            Presence presence = (Presence) contact.getPresence();
            presence.setImc(ele.element("basic").attributeValue("value"));

            ele = ele.element("personal");
            contact.setName(ele.attributeValue("nickname"));
            contact.setPersonalMessage(ele.attributeValue("impresa"));

            // 状态改变事件
            Control.getInstance().contactPresenceChanged(getSession(contact.getUri()));
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /**
     * 接收消息事件处理
     * 
     * @param text
     * @return
     */
    boolean readMessage(String user, String text)
    {
        LogUtil.log("readMessage:" + text);
        Control.getInstance().instantMessageReceived(getSession(user), new Message(text));
        return true;
    }

    /**
     * 发送联系人信息请求
     */
    private void sendContact()
    {
        // 获取联系人信息获取
        Document doc2 = DocumentHelper.createDocument();
        Element args = doc2.addElement("args");
        args.addElement("contacts").addAttribute("attributes", "provisioning;impresa;mobile-no;nickname;name;portrait-crc;ivr-enabled");

        // 记录联系人URI
        for (IContact tmp : contacts)
        {
            args.addElement("contact").addAttribute("uri", ((Contact) tmp).getUri());
        }

        // 发送联系信息读取请求
        connect.initContact(doc2.asXML());
    }

    /**
     * 发送联系人在线状态请求
     */
    private void sendPresence()
    {
        // 联系人在线状态订阅
        Document doc = DocumentHelper.createDocument();
        Element args = doc.addElement("args");
        Element sub = args.addElement("subscription");
        Element con = sub.addElement("contacts");

        for (IContact tmp : contacts)
        {
            con.addElement("contact").addAttribute("uri", ((Contact) tmp).getUri());
        }

        Element pre = sub.addElement("presence");
        pre.addElement("basic").addAttribute("attributes", "all");
        pre.addElement("personal").addAttribute("attributes", "all");
        pre.addElement("extended").addAttribute("types", "sms;location;listening;ring-back-tone");

        sub = args.addElement("subscription");
        con = sub.addElement("contacts");
        con.addElement("contact").addAttribute("uri", connect.getUri());
        pre = sub.addElement("presence");
        pre.addElement("extended").addAttribute("types", "sms;location;listening;ring-back-tone");
        connect.initPresence(doc.asXML());
    }

    /**
     * 设置昵称
     * 
     * @param text
     */
    void sendNickname(String text)
    {
        connect.setNickname("<args><personal nickname=\"" + text + "\" /></args>");
    }

    private Session getSession(String user)
    {
        Session session = sessions.get(user);
        if (session == null)
        {
            session = new Session();
            sessions.put(user, session);
        }
        return session;
    }
}
