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
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.Socket;
import java.net.URL;
import java.net.URLConnection;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.swing.Timer;

import org.apache.axis.utils.ByteArrayOutputStream;
import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.Node;
import org.dom4j.io.SAXReader;

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
public class Fetion extends Thread implements IAccount
{
    private Connect connect;
    private String sid;
    // private String uri;
    private String sipcProxy;
    // private String ssi_app_sign_in;
    // private String ssi_app_sign_out;
    /**
     * 服务调用序列
     */
    private static int callId;
    /**
     * 保持在线序列
     */
    private static int liveId;
    /**
     * Socket通讯对象
     */
    private static Socket socket;
    /**
     * 数据输入对象
     */
    private DataInputStream dataIs;
    /**
     * 数据输出对象
     */
    private DataOutputStream dataOs;
    /**
     * 目录列表
     */
    private List<Catalog> catalogs = new ArrayList<Catalog>();
    /**
     * 人员列表
     */
    private List<IContact> contacts = new ArrayList<IContact>();
    /**
     * 命令列表
     */
    private HashMap<String, String> commands = new HashMap<String, String>();
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
                connect = new Connect();
                connect.load();
                initConnect();
                timer = new Timer(10000, new ActionListener()
                {
                    @Override
                    public void actionPerformed(ActionEvent arg0)
                    {
                        sendKeepAlive();
                    }
                });
                break;

            case IPresence.SIGN:
                if (login() == Constant.LOGIN_SUCC)
                {
                    start();
                    initDisplay();
                    initCatalog();
                    initContact();
                    timer.start();
                }
                else
                {
                    timer.stop();
                    close();
                }
                break;

            case IPresence.DOWN:
                logout();
                liveId = -1;
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

    private String initSysEncode()
    {
        Document doc = DocumentHelper.createDocument();
        Element config = doc.addElement("config");

        config.addElement("user").addAttribute("mobile-no", connect.getUser());

        Element client = config.addElement("client");
        client.addAttribute("type", "PC");
        client.addAttribute("version", Constant.VER_FETION);
        client.addAttribute("platform", "W5.1");

        config.addElement("servers").addAttribute("version", "0");

        config.addElement("service-no").addAttribute("version", "0");

        config.addElement("parameters").addAttribute("version", "0");

        config.addElement("hints").addAttribute("version", "0");

        config.addElement("http-applications").addAttribute("version", "0");

        return doc.asXML();
    }

    private boolean initSysDecode(Document doc)
    {
        Element ele = (Element) doc.selectSingleNode("/config/servers");

        sipcProxy = ele.selectSingleNode("sipc-proxy").getText();

        // ssi_app_sign_in = ele.selectSingleNode("ssi-app-sign-in").getText();
        //
        // ssi_app_sign_out =
        // ele.selectSingleNode("ssi-app-sign-out").getText();
        return true;
    }

    private boolean initSipDeocde(Document doc)
    {
        Node ele = doc.selectSingleNode("/Root/Users/User");

        sid = ele.selectSingleNode("Sid").getText();

        // uri = ele.selectSingleNode("Uri").getText();
        return true;
    }

    private boolean initConnect()
    {
        URLConnection connection = null;
        try
        {
            // 连接配置服务器
            connection = new URL(connect.getSysCfg()).openConnection();
            connection.setDoOutput(true);
            connection.setRequestProperty("Content-Type", "text/plain");
            connection.setRequestProperty("charset", "utf-8");

            // 向配置服务器发送信息
            OutputStreamWriter osw = new OutputStreamWriter(connection.getOutputStream(), "utf-8");
            osw.write(initSysEncode());
            osw.flush();
            osw.close();

            // 返回数据解析
            initSysDecode(new SAXReader().read(connection.getInputStream()));

            // 连接身份服务器
            connection = new URL(connect.getSipCfg()).openConnection();
            connection.setDoOutput(true);
            connection.setRequestProperty("charset", "utf-8");

            // 向身份服务器发送信息
            osw = new OutputStreamWriter(connection.getOutputStream(), "utf-8");
            osw.write(sid == null ? "CellPhone=" + connect.getUser() : "Sid=" + sid);
            osw.flush();
            osw.close();

            // 读取配置服务器返回数据
            InputStreamReader isr = new InputStreamReader(connection.getInputStream(), "utf-8");
            StringBuffer buf = new StringBuffer();
            char[] tmp = new char[1024];
            int len = isr.read(tmp);
            while (len >= 0)
            {
                buf.append(tmp, 0, len);
                len = isr.read(tmp);
            }
            isr.close();

            // 返回数据解析
            initSipDeocde(DocumentHelper.parseText(buf.toString().replace("xmlns=\"http://tempuri.org/DateExchange.xsd\"", "")));
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /**
     * 初始化个人信息
     */
    private void initDisplay()
    {
        callId += 1;

        Document doc = DocumentHelper.createDocument();
        Element args = doc.addElement("args");
        args.addElement("personal").addAttribute("attributes", "all");
        args.addElement("services").addAttribute("version", "").addAttribute("attributes", "all");
        args.addElement("config").addAttribute("version", "").addAttribute("attributes", "all");
        args.addElement("mobile-device").addAttribute("attributes", "all");

        String data = doc.asXML();
        StringBuffer tmp = new StringBuffer();
        tmp.append("S fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 1 S").append(Constant.ENV_BREAKS);
        tmp.append("N: GetPersonalInfo").append(Constant.ENV_BREAKS);
        tmp.append("L: ").append(data.length()).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        tmp.append(data);

        send(tmp.toString());
        commands.put(Integer.toString(callId), Constant.N_GetPersonalInfo);
    }

    /**
     * 初始化联系人目录
     */
    private void initCatalog()
    {
        callId += 1;

        Document doc = DocumentHelper.createDocument();
        Element args = doc.addElement("args");
        Element contacts = args.addElement("contacts");
        contacts.addElement("buddy-lists");
        contacts.addElement("buddies").addAttribute("attributes", "all");
        contacts.addElement("mobile-buddies").addAttribute("attributes", "all");
        contacts.addElement("chat-friends");
        contacts.addElement("blacklist");

        String data = doc.asXML();
        StringBuffer tmp = new StringBuffer();
        tmp.append("S fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 1 S").append(Constant.ENV_BREAKS);
        tmp.append("N: GetContactList").append(Constant.ENV_BREAKS);
        tmp.append("L: ").append(data.length()).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        tmp.append(data);

        send(tmp.toString());
        commands.put(Integer.toString(callId), Constant.N_GetContactList);
    }

    /**
     * 初始化联系人列表
     */
    private void initContact()
    {
        callId += 1;

        Document doc = DocumentHelper.createDocument();
        Element args = doc.addElement("args");
        args.addElement("contacts").addAttribute("attributes", "provisioning;impresa;mobile-no;nickname;name;portrait-crc;ivr-enabled");

        Contact contact;
        for (IContact tmp : contacts)
        {
            contact = (Contact) tmp;
            args.addElement("contact").addAttribute("uri", contact.getUri());
        }

        String data = doc.asXML();
        StringBuffer tmp = new StringBuffer();
        tmp.append("S fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 1 S").append(Constant.ENV_BREAKS);
        tmp.append("N: GetContactsInfo").append(Constant.ENV_BREAKS);
        tmp.append("L: ").append(data.length()).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        tmp.append(data);

        send(tmp.toString());
        commands.put(Integer.toString(callId), Constant.N_GetContactsInfo);
    }

    private static String digest(String text)
    {
        try
        {
            return CharUtil.toHex(MessageDigest.getInstance("MD5").digest(text.getBytes()));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return "";
        }
    }

    private static String compute(String s1, String s2)
    {
        try
        {
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] k = md.digest(s1.getBytes("utf-8"));
            byte[] s = s2.getBytes("utf-8");
            byte[] t = new byte[k.length + s.length];

            for (int i = 0, j = k.length; i < j; ++i)
            {
                t[i] = k[i];
            }
            for (int i = 0, j = s.length; i < j; ++i)
            {
                t[(k.length + i)] = s[i];
            }
            return CharUtil.toHex(md.digest(t));
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private String response()
    {
        return response(Constant.ENV_BREAKS + Constant.ENV_BREAKS);
    }

    private String response(int len)
    {
        try
        {
            ByteArrayOutputStream bos = new ByteArrayOutputStream(len);
            for (int i = 0; i < len; i += 1)
            {
                bos.write(dataIs.read());
            }
            return new String(bos.toByteArray());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return "Convert to UTF8 Error\n";
        }
    }

    private String response(String end)
    {
        try
        {
            byte[] tmp = end.getBytes();
            ByteArrayOutputStream bos = new ByteArrayOutputStream(4096);
            int p = 0;
            byte b;
            while (true)
            {
                b = dataIs.readByte();
                bos.write(b);
                p = (b == tmp[p]) ? p + 1 : 0;
                if (p == tmp.length)
                {
                    break;
                }
            }
            return bos.toString();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return "Convert to UTF8 Error\n";
        }
    }

    private String SignInnEncode()
    {
        Document doc = DocumentHelper.createDocument();
        Element args = doc.addElement("args");

        Element device = args.addElement("device");
        device.addAttribute("type", "PC");
        device.addAttribute("version", "5");
        device.addAttribute("client-version", Constant.VER_FETION);

        args.addElement("caps").addAttribute("value", "simple-im;im-session;temp-group");

        args.addElement("events").addAttribute("value", "contact;permission;system-message");

        args.addElement("user-info").addAttribute("attributes", "all");

        Element basic = args.addElement("presence").addElement("basic");
        basic.addAttribute("value", "0").addAttribute("desc", "");

        return doc.asXML();
    }

    private int login()
    {
        try
        {
            String[] proxySplit = sipcProxy.split(":");
            socket = new Socket(proxySplit[0], Integer.parseInt(proxySplit[1]));
            dataIs = new DataInputStream(socket.getInputStream());
            dataOs = new DataOutputStream(socket.getOutputStream());
        }
        catch (Exception e1)
        {
            return Constant.LOGIN_CONN_ERROR;
        }

        callId = 3;
        liveId = 3;

        try
        {
            // 第一次握手
            String data = SignInnEncode();
            StringBuffer tmp = new StringBuffer();
            tmp.append("R fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
            tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
            tmp.append("I: 1").append(Constant.ENV_BREAKS).append("Q: 1 R").append(Constant.ENV_BREAKS).append("L: ");
            tmp.append(data.length()).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
            tmp.append(data);
            send(tmp.toString());

            // 第二次握手
            String response = response();
            int i = response.indexOf("nonce");
            if (i < 0)
            {
                return Constant.LOGIN_FAILED;
            }
            i += 7;
            int j = response.indexOf('"', i);
            if (j < i)
            {
                return Constant.LOGIN_FAILED;
            }
            String nonce = response.substring(i, j);

            // 第三次握手
            String m1 = sid + ":fetion.com.cn:" + connect.getPwds();
            String m2 = ":" + nonce + ':' + Constant.CNONCE;
            String h1 = compute(m1, m2);
            m2 = "REGISTER:" + sid;
            String h2 = digest(m2);
            m2 = h1 + ":" + nonce + ":" + h2;

            tmp.delete(0, tmp.length());
            tmp.append("R fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
            tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
            tmp.append("I: 2").append(Constant.ENV_BREAKS);
            tmp.append("Q: 2 R").append(Constant.ENV_BREAKS);
            tmp.append("A: Digest response=\"").append(digest(m2)).append("\",cnonce=\"").append(Constant.CNONCE).append("\"").append(Constant.ENV_BREAKS);
            tmp.append("L: ").append(data.length()).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
            tmp.append(data);
            send(tmp.toString());

            // 登录状态确认
            response = response();
            HashMap<String, String> map = readHead(response);
            String append = map.get("L");
            if (CharUtil.isValidate(append))
            {
                response += response(Integer.parseInt(append));
            }
            // i = response.indexOf("\r\nL: ");
            // if (i > 0)
            // {
            // String append = response.substring(i + 5).trim();
            // append = waitResponse(Integer.parseInt(append)).trim();
            // response = response.trim() + "\r\n\r\n" + append;
            // }
            if (response.indexOf("200") < 0)
            {
                return Constant.LOGIN_FAILED;
            }
        }
        catch (Exception e2)
        {
            return Constant.LOGIN_DATAIO_ERROR;
        }
        LogUtil.log("OK");
        return Constant.LOGIN_SUCC;
    }

    /**
     * 消息头读取
     * 
     * @param text
     * @return
     */
    private HashMap<String, String> readHead(String text)
    {
        HashMap<String, String> map = new HashMap<String, String>();
        String[] arr;
        for (String tmp : text.split(Constant.ENV_BREAKS))
        {
            arr = tmp.split(":");
            if (arr.length == 2)
            {
                map.put(arr[0].trim(), arr[1].trim());
            }
        }
        return map;
    }

    @Override
    public void run()
    {
        while (liveId > 0)
        {
            String resHead = response();
            HashMap<String, String> map = readHead(resHead);
            String append = map.get("L");
            String resBody = null;
            if (CharUtil.isValidate(append))
            {
                resBody = response(Integer.parseInt(append)).trim();
            }

            String action = map.get("I");
            if (CharUtil.isValidate(action) && commands.containsKey(action))
            {
                action = commands.remove(action);
                LogUtil.log("Action:" + action);
                if (Constant.N_GetPersonalInfo.equals(action))
                {
                    readDisplay(resBody);
                }
                else if (Constant.N_GetContactList.equals(action))
                {
                    readCatalog(resBody);
                }
                else if (Constant.N_GetContactsInfo.equals(action))
                {
                    readContact(resBody);
                }
                else if (Constant.N_SubPresence.equals(action))
                {
                    readContact(resBody);
                }
            }
            else if ('M' == resHead.charAt(0))
            {
                replyOK(resHead);
                String fromSip = map.get("F");
                if (!CharUtil.isValidate(fromSip))
                {
                    return;
                }
                Control.getInstance().instantMessageReceived(null, new Message(resBody));
            }
        }
    }

    /**
     * 个人信息更新
     * 
     * @param text
     */
    private void readDisplay(String text)
    {
        if (!CharUtil.isValidate(text))
        {
            return;
        }
        if (text.indexOf("mobile-no=") <= 0)
        {
            return;
        }
        String t = text.substring(text.indexOf("mobile-no=") + 11);
        t = t.substring(0, t.indexOf(34));// 我的手机号码
        t = text.substring(text.indexOf("nickname=") + 10);
        t = t.substring(0, t.indexOf(34));// 我的昵称
    }

    /**
     * 联系人列表更新
     * 
     * @param res
     */
    private void readCatalog(String text)
    {
        if (!CharUtil.isValidate(text))
        {
            return;
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
                return;
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
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 联系人详细信息更新
     * 
     * @param text
     */
    private void readContact(String text)
    {
        if (!CharUtil.isValidate(text))
        {
            return;
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
                        presence.setImc(e1.attributeValue("value"));
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
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    public void close()
    {
        try
        {
            socket.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * @param args
     */
    public void subPresence(String args)
    {
        callId += 1;

        StringBuffer tmp = new StringBuffer();
        tmp.append("SUB fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 1 SUB").append(Constant.ENV_BREAKS);
        tmp.append("N: presence").append(Constant.ENV_BREAKS);
        tmp.append("L: ").append(args.length()).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        tmp.append(args);

        send(tmp.toString());
        commands.put(Integer.toString(callId), Constant.N_SubPresence);
    }

    /**
     * 退出登录
     */
    private void logout()
    {
        StringBuffer tmp = new StringBuffer();
        tmp.append("R fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 1 R").append(Constant.ENV_BREAKS);
        tmp.append("X: 0").append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        send(tmp.toString());
    }

    /**
     * 发送消息
     * 
     * @param message
     */
    private void send(String message)
    {
        LogUtil.log("==============================");
        LogUtil.log("send");
        LogUtil.log(message);
        try
        {
            dataOs.write(message.getBytes("utf-8"));
            dataOs.flush();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * @param to_uri
     *            接收人
     * @param text
     *            消息内容
     * @param forceSMS
     *            是否强制为短信
     */
    public void sendMsg(String to_uri, String text, Boolean forceSMS)
    {
        callId += 1;

        StringBuffer tmp = new StringBuffer();
        tmp.append("M fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 2 M").append(Constant.ENV_BREAKS);
        tmp.append("T: ").append(to_uri).append(Constant.ENV_BREAKS);

        if (!(forceSMS.booleanValue()))
        {
            tmp.append("C: text/plain").append(Constant.ENV_BREAKS);
            tmp.append("K: SaveHistory").append(Constant.ENV_BREAKS);
            tmp.append("N: CatMsg").append(Constant.ENV_BREAKS);
        }
        else
        {
            tmp.append("N: SendCatSMS").append(Constant.ENV_BREAKS);
        }

        tmp.append("L: ").append(text.getBytes().length).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        tmp.append(text);

        send(tmp.toString());
        commands.put(Integer.toString(callId), Constant.N_SendMsg);
    }

    /**
     * 修改显示名称
     * 
     * @param text
     */
    public void setNickname(String text)
    {
        callId += 1;

        StringBuffer tmp = new StringBuffer();
        tmp.append("S fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(callId).append(Constant.ENV_BREAKS);
        tmp.append("Q: 1 S").append(Constant.ENV_BREAKS);
        tmp.append("N: SetPersonalInfo").append(Constant.ENV_BREAKS);
        tmp.append("L: ").append(text.getBytes().length).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        tmp.append(text);
        send(tmp.toString());
        commands.put(Integer.toString(callId), Constant.N_SetPersonalInfo);
    }

    /**
     * 消息收到确认
     * 
     * @param s
     *            已接收消息头
     */
    private void replyOK(String s)
    {
        HashMap<String, String> map = readHead(s);
        String f = map.get("F");
        if (!CharUtil.isValidate(f))
        {
            return;
        }
        String i = map.get("I");
        if (!CharUtil.isValidate(i))
        {
            return;
        }
        String q = map.get("Q");
        if (!CharUtil.isValidate(q))
        {
            return;
        }

        StringBuffer tmp = new StringBuffer();
        tmp.append("SIP-C/2.0 200 OK").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(f).append(Constant.ENV_BREAKS);
        tmp.append("I: ").append(i).append(Constant.ENV_BREAKS);
        tmp.append("Q: ").append(q).append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        send(tmp.toString());
    }

    /**
     * 
     */
    private void sendKeepAlive()
    {
        liveId += 1;

        StringBuffer tmp = new StringBuffer();
        tmp.append("R fetion.com.cn SIP-C/2.0").append(Constant.ENV_BREAKS);
        tmp.append("F: ").append(sid).append(Constant.ENV_BREAKS);
        tmp.append("I: 1").append(Constant.ENV_BREAKS);
        tmp.append("Q: ").append(liveId).append(" R").append(Constant.ENV_BREAKS).append(Constant.ENV_BREAKS);
        send(tmp.toString());
    }
}
