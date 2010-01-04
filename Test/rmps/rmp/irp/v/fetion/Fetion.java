/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.fetion;

//import cn.edu.ctgu.ghl.fetion.FetionEvent;
//import cn.edu.ctgu.ghl.fetion.IFetionEventListener;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.Socket;
import java.net.URL;
import java.net.URLConnection;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;

import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;

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
public class Fetion implements IAccount// , IFetionEventListener
{
    private Connect connect;

    public Fetion()
    {
        this.socket = null;
        this.getData = "";
        call_id = 2;
        this.Commands.clear();
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
            case IStatus.INIT:
                connect = new Connect();
                connect.load();

                initF();
                break;
            case IStatus.SIGN:
                System.out.println(login(connect.getProxy(), connect.getPwds()));
                break;
            case IStatus.DOWN:
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

    // @Override
    // public void process(FetionEvent e)
    // {
    // if (e.getFirstLine() != null && e.getFirstLine().startsWith("M") &&
    // e.getBody() != null)
    // {
    // messenger.sendSms2SelfPhone(e.toString());
    // if (e.getBody().trim().startsWith("cmd"))
    // {
    // System.out.println("excute[" + e.getBody().trim().substring(3) + "]");
    // try
    // {
    // Runtime.getRuntime().exec(e.getBody().trim().substring(3));
    // }
    // catch (IOException e1)
    // {
    // // TODO Auto-generated catch block
    // e1.printStackTrace();
    // }
    // }
    // }
    // }

    public static String byteArrayToHexString(byte[] b)
    {
        StringBuffer resultSb = new StringBuffer();
        for (int i = 0; i < b.length; ++i)
        {
            resultSb.append(byteToHexString(b[i]));
        }
        return resultSb.toString();
    }

    private static String byteToHexString(byte b)
    {
        int n = b;
        if (n < 0)
        {
            n = 256 + n;
        }
        int d1 = n / 16;
        int d2 = n % 16;
        return hexDigits[d1] + hexDigits[d2];
    }

    public static String MD5Encode(String origin)
    {
        String resultString = null;
        try
        {
            MessageDigest md = MessageDigest.getInstance("MD5");
            resultString = byteArrayToHexString(md.digest(origin.getBytes("utf-8")));
        }
        catch (Exception ex)
        {
        }
        return resultString;
    }

    public static String computeH1(String s1, String s2)
    {
        String res = null;
        try
        {
            MessageDigest md = MessageDigest.getInstance("MD5");
            byte[] key = md.digest(s1.getBytes("utf-8"));
            byte[] ss = s2.getBytes("utf-8");
            byte[] t = new byte[key.length + ss.length];

            for (int i = 0; i < key.length; ++i)
            {
                t[i] = key[i];
            }
            for (int i = 0; i < ss.length; ++i)
            {
                t[(key.length + i)] = ss[i];
            }
            res = byteArrayToHexString(md.digest(t));
        }
        catch (Exception e)
        {
        }
        return res;
    }

    public void addSendStr(String str)
    {
        System.out.println("Send:\n" + str);
    }

    public void addRecvStr(String str)
    {
        System.out.println("Recv:\n" + str);
    }

    public void addDebugStr(String str)
    {
        System.out.println("Debug:\n" + str);
    }

    public String waitResponse()
    {
        return waitResponse("\r\n\r\n");
    }

    public String waitResponse(int len)
    {
        int recvPos = 0;

        byte[] recvBuf = new byte[len + 1];
        while (recvPos < len)
        {
            int t;
            try
            {
                t = this.dataIn.read();
            }
            catch (Exception e)
            {
                return null;
            }
            recvBuf[(recvPos++)] = (byte) t;
        }
        recvBuf[recvPos] = 0;
        String res;
        try
        {
            res = new String(recvBuf, "utf-8");
        }
        catch (Exception e)
        {
            res = "Convert to UTF8 Error\n";
        }
        return res;
    }

    public String waitResponse(String endStr)
    {
        byte[] recvBuf = new byte[40960];
        int recvPos = 0;
        while (true)
        {
            int t;
            try
            {
                t = this.dataIn.read();
            }
            catch (Exception e)
            {
                return null;
            }
            recvBuf[(recvPos++)] = (byte) t;
            if (recvPos <= endStr.length())
            {
                continue;
            }
            int end = 1;
            for (int i = 0; i < endStr.length(); ++i)
            {
                if (recvBuf[(recvPos - endStr.length() + i)] == endStr.charAt(i))
                {
                    continue;
                }
                end = 0;
                break;
            }
            if (end == 1)
            {
                break;
            }
        }
        recvBuf[recvPos] = 0;
        String res;
        try
        {
            res = new String(recvBuf, "utf-8");
        }
        catch (Exception end)
        {
            res = "Convert to UTF8 Error\n";
        }
        return res;
    }

    public int login(String proxyUri, String pwd)
    {
        String[] proxySplit = proxyUri.split(":");
        try
        {
            this.socket = new Socket(proxySplit[0], Integer.parseInt(proxySplit[1]));

            this.dataIn = new DataInputStream(this.socket.getInputStream());
            this.dataOut = new DataOutputStream(this.socket.getOutputStream());
        }
        catch (Exception e1)
        {
            return 1;
        }
        this.Q1 = 2;
        try
        {
            String args = "<args><device type=\"PC\" version=\"5\" client-version=\"3.5.2540\" /><caps value=\"simple-im;im-session;temp-group\" /><events value=\"contact;permission;system-message\" /><user-info attributes=\"all\" /><presence><basic value=\"0\" desc=\"\" /></presence></args>";
            this.sendData = "R fetion.com.cn SIP-C/2.0\r\n";
            Fetion tmp93_92 = this;
            tmp93_92.sendData = tmp93_92.sendData + "F: " + this.sid + "\r\n";
            Fetion tmp131_130 = this;
            tmp131_130.sendData = tmp131_130.sendData + "I: 1\r\nQ: 1 R\r\nL: " + args.length() + "\r\n\r\n";
            this.sendData += args;
            addSendStr(this.sendData);
            SendData();
            this.getData = waitResponse();
            addRecvStr(this.getData);
            if (this.getData.indexOf("nonce") <= 0)
            {
                addDebugStr("No nonce field");
                return 3;
            }
            String nonce = this.getData.substring(this.getData.indexOf("nonce") + 7);
            nonce = nonce.substring(0, nonce.indexOf(34));

            String cnonce = "7036EA07568E7C4D6D49FD76141062FE";

            String md5Str = this.sid + ":fetion.com.cn:" + pwd;
            String key = MD5Encode(md5Str);
            String debugStr = "key=MD5(\"" + md5Str + "\")=" + key + "\n";
            String md5Str_ = md5Str;
            md5Str = ":" + nonce + ":" + cnonce;
            String H1 = computeH1(md5Str_, md5Str);
            debugStr = debugStr + "H1=MD5(\"" + key + md5Str + "\")=" + H1 + "\n";
            md5Str = "REGISTER:" + this.sid;
            String H2 = MD5Encode(md5Str);
            debugStr = debugStr + "H2=MD5(\"" + md5Str + "\")=" + H2 + "\n";
            md5Str = H1 + ":" + nonce + ":" + H2;
            String response = MD5Encode(md5Str);
            debugStr = debugStr + "response=MD5(\"" + md5Str + "\")=" + response + "\n";
            addDebugStr(debugStr);
            this.sendData = "R fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: 1\r\n" + "Q: 2 R\r\n" + "A: Digest response=\"" + response
                    + "\",cnonce=\"7036EA07568E7C4D6D49FD76141062FE\"\r\n" + "L: " + args.length() + "\r\n\r\n" + args;

            addSendStr(this.sendData);
            SendData();
            this.getData = waitResponse();
            if (this.getData.indexOf("\r\nL: ") > 0)
            {
                String append = this.getData.substring(this.getData.indexOf("\r\nL: ") + 5);
                append = append.substring(0, append.indexOf("\r\n"));
                append = waitResponse(Integer.parseInt(append)).trim();
                this.getData = this.getData.trim() + "\r\n\r\n" + append;
            }
            addRecvStr(this.getData);
            if (this.getData.indexOf("200") <= 0)
            {
                return 3;
            }
        }
        catch (Exception e2)
        {
            return 2;
        }
        return 0;
    }

    public void run()
    {
        while (!(Thread.interrupted()))
        {
            this.getData = waitResponse();
            String append = null;
            if (this.getData.indexOf("\r\nL: ") > 0)
            {
                append = this.getData.substring(this.getData.indexOf("\r\nL: ") + 5);
                append = append.substring(0, append.indexOf("\r\n"));
                append = waitResponse(Integer.parseInt(append)).trim();
                this.getData = this.getData.trim() + "\r\n\r\n" + append;
            }
            addRecvStr(this.getData);
            int command = 0;
            if (this.getData.indexOf("\r\nI: ") > 0)
            {
                String comm = this.getData.substring(this.getData.indexOf("\r\nI: ") + 5);
                comm = comm.substring(0, comm.indexOf("\r\n"));
                command = Integer.parseInt(comm);
            }
            if (command >= 0)
            {
                IDataType element;
                try
                {
                    element = (IDataType) this.Commands.get(command);
                }
                catch (Exception e)
                {
                    element = new IDataType(0);
                }

                switch (element.NType)
                {
                    case 1:
                        // this.mFrame.updatePersonalInfoShow(append);
                        System.out.println(append);
                        break;
                    case 2:
                        // this.mFrame.updateContactsShow(append);
                        System.out.println(append);
                        break;
                    case 3:
                    case 4:
                        // this.mFrame.updateContactsDetail(append);
                        System.out.println(append);
                }

            }
            else
            {
                switch (this.getData.charAt(0))
                {
                    case 'M':
                        // this.mFrame.ProcessMessge(this.getData, append);
                        System.out.println(getData);
                        System.out.println(append);
                        replyM(this.getData);
                }
            }
        }
    }

    public void close()
    {
        try
        {
            this.socket.close();
        }
        catch (Exception e)
        {
        }
    }

    public static String getLine(String s, String p)
    {
        String result = s;
        if (result.indexOf(p) < 0)
        {
            return null;
        }
        result = result.substring(result.indexOf(p));
        result = result.substring(0, result.indexOf("\r\n"));
        return result;
    }

    void addCommand(int id, IDataType e)
    {
        while (this.Commands.size() < id)
        {
            this.Commands.add(null);
        }
        this.Commands.add(id, e);
    }

    public void getPersonalInfo()
    {
        String args = "<args><personal attributes=\"all\" /><services version=\"\" attributes=\"all\" /><config version=\"14\" attributes=\"all\" /><mobile-device attributes=\"all\" /></args>";
        call_id += 1;
        this.sendData = "S fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 1 S\r\n" + "N: GetPersonalInfo\r\n" + "L: " + args.length() + "\r\n\r\n";

        this.sendData += args;
        addSendStr(this.sendData);
        SendData();
        IDataType element = new IDataType(1);
        addCommand(call_id, element);
    }

    public void getContactList()
    {
        String args = "<args><contacts><buddy-lists /><buddies attributes=\"all\" /><mobile-buddies attributes=\"all\" /><chat-friends /><blacklist /></contacts></args>";
        call_id += 1;
        this.sendData = "S fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 1 S\r\n" + "N: GetContactList\r\n" + "L: " + args.length() + "\r\n\r\n";

        this.sendData += args;
        addSendStr(this.sendData);
        SendData();
        IDataType element = new IDataType(2);
        addCommand(call_id, element);
    }

    public void getContactDetail(String args)
    {
        call_id += 1;
        this.sendData = "S fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 1 S\r\n" + "N: GetContactsInfo\r\n" + "L: " + args.length() + "\r\n\r\n";

        this.sendData += args;
        addSendStr(this.sendData);
        SendData();
        IDataType element = new IDataType(3);
        addCommand(call_id, element);
    }

    public void subPresence(String args)
    {
        call_id += 1;
        this.sendData = "SUB fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 1 SUB\r\n" + "N: presence\r\n" + "L: " + args.length() + "\r\n\r\n";

        this.sendData += args;
        addSendStr(this.sendData);
        SendData();
        IDataType element = new IDataType(4);
        addCommand(call_id, element);
    }

    public void sendLogout()
    {
        this.sendData = "R fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 1 R\r\n" + "X: 0\r\n\r\n";

        addSendStr(this.sendData);
        SendData();
    }

    public void SendData()
    {
        byte[] textBytes = null;
        try
        {
            textBytes = this.sendData.getBytes("utf-8");
            this.dataOut.write(textBytes);
            this.dataOut.flush();
        }
        catch (Exception e)
        {
        }
    }

    public void sendMsg(String to_uri, String text, Boolean forceSMS)
    {
        call_id += 1;
        byte[] textBytes;
        try
        {
            textBytes = text.getBytes("utf-8");
        }
        catch (Exception e)
        {
            return;
        }
        this.sendData = "M fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 2 M\r\n" + "T: " + to_uri + "\r\n";

        if (!(forceSMS.booleanValue()))
        {
            this.sendData += "C: text/plain\r\nK: SaveHistory\r\nN: CatMsg\r\n";
        }
        else
        {
            this.sendData += "N: SendCatSMS\r\n";
        }
        Fetion tmp158_157 = this;
        tmp158_157.sendData = tmp158_157.sendData + "L: " + textBytes.length + "\r\n\r\n";
        this.sendData += text;
        try
        {
            textBytes = this.sendData.getBytes("utf-8");
        }
        catch (Exception e)
        {
            return;
        }
        addSendStr(this.sendData);
        SendData();
        IDataType element = new IDataType(5);
        addCommand(call_id, element);
    }

    public void setNickname(String text)
    {
        call_id += 1;
        byte[] textBytes;
        try
        {
            textBytes = text.getBytes("utf-8");
        }
        catch (Exception e)
        {
            return;
        }
        this.sendData = "S fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: " + call_id + "\r\n" + "Q: 1 S\r\n" + "N: SetPersonalInfo\r\n" + "L: " + textBytes.length + "\r\n\r\n";

        this.sendData += text;
        try
        {
            textBytes = this.sendData.getBytes("utf-8");
        }
        catch (Exception e)
        {
            return;
        }
        addSendStr(this.sendData);
        SendData();
        IDataType element = new IDataType(6);
        addCommand(call_id, element);
    }

    public void replyM(String s)
    {
        this.sendData = "SIP-C/2.0 200 OK\r\n";
        String t = getLine(s, "F: ");
        if (t == null)
        {
            return;
        }
        Fetion tmp26_25 = this;
        tmp26_25.sendData = tmp26_25.sendData + t + "\r\n";
        t = getLine(s, "I: ");
        if (t == null)
        {
            return;
        }
        Fetion tmp68_67 = this;
        tmp68_67.sendData = tmp68_67.sendData + t + "\r\n";
        t = getLine(s, "Q: ");
        if (t == null)
        {
            return;
        }
        Fetion tmp110_109 = this;
        tmp110_109.sendData = tmp110_109.sendData + t + "\r\n\r\n";
        addSendStr(this.sendData);
        SendData();
    }

    public void sendKeepAlive()
    {
        this.Q1 += 1;
        this.sendData = "R fetion.com.cn SIP-C/2.0\r\nF: " + this.sid + "\r\n" + "I: 1\r\n" + "Q: " + this.Q1 + " R\r\n\r\n";

        addSendStr(this.sendData);
        SendData();
    }

    private void initF()
    {
        if (connect.getUser().length() == 0)
        {
            LogUtil.log("CellPhone/Fetion ID field should not be empty.");
            return;
        }
        URLConnection connection = null;
        try
        {
            URL getSystemConfigURL = new URL("http://nav.fetion.com.cn/nav/getsystemconfig.aspx");

            connection = getSystemConfigURL.openConnection();
            HttpURLConnection httpconn = (HttpURLConnection) connection;
            connection.setDoOutput(true);
            connection.setRequestProperty("Content-Type", "text/plain");
            connection.setRequestProperty("charset", "utf-8");
            OutputStreamWriter out = new OutputStreamWriter(connection.getOutputStream(), "utf-8");
            out
                    .write("<config><user mobile-no=\"13585709149\" /><client type=\"PC\" version=\"2.1.0.0\" platform=\"W5.1\" /><servers version=\"0\" /><service-no version=\"0\" /><parameters version=\"0\" /><hints version=\"0\" /><http-applications version=\"0\" /></config>");
            out.flush();
            out.close();
            InputStreamReader in;
            try
            {
                in = new InputStreamReader(connection.getInputStream(), "utf-8");
            }
            catch (Exception ex)
            {
                LogUtil.log("Init Web Error:\n");
                in = new InputStreamReader(httpconn.getErrorStream(), "utf-8");
                return;
            }
            char[] data = new char[10240];
            int i = 0;
            int j;
            while (true)
            {
                j = in.read();
                if (j == -1)
                {
                    data[i] = '\0';
                    break;
                }
                data[(i++)] = (char) j;
            }
            in.close();

            String res = new String(data);

            String sipc_proxy = res.substring(res.indexOf("<sipc-proxy>") + 12);
            sipc_proxy = sipc_proxy.substring(0, sipc_proxy.indexOf("</sipc-proxy>")).trim();
            connect.setProxy(sipc_proxy);

            LogUtil.log("sipc-proxy:[" + sipc_proxy + "]\n");
            String ssi_app_sign_in = res.substring(res.indexOf("<ssi-app-sign-in>") + 17);
            ssi_app_sign_in = ssi_app_sign_in.substring(0, ssi_app_sign_in.indexOf("</ssi-app-sign-in>"));
            LogUtil.log("ssi-app-sign-in:[" + ssi_app_sign_in + "]\n");
            String ssi_app_sign_out = res.substring(res.indexOf("<ssi-app-sign-out>") + 18);
            ssi_app_sign_out = ssi_app_sign_out.substring(0, ssi_app_sign_out.indexOf("</ssi-app-sign-out>"));
            LogUtil.log("ssi-app-sign-out:[" + ssi_app_sign_out + "]\n");

            if ((connect.getUser().length() == 11) && (connect.getUser().charAt(0) == '1') && (((connect.getUser().charAt(1) == '3') || (connect.getUser().charAt(1) == '5'))))
            {
                this.sid = null;
            }
            else
            {
                this.sid = connect.getUser();
            }
            connection = null;
            URL getSipURL = new URL("http://nav.m161.com.cn/Getconfig.aspx");
            connection = getSipURL.openConnection();
            httpconn = (HttpURLConnection) connection;
            connection.setDoOutput(true);

            connection.setRequestProperty("charset", "utf-8");
            out = new OutputStreamWriter(connection.getOutputStream(), "utf-8");
            if (this.sid == null)
            {
                out.write("CellPhone=" + connect.getUser());
            }
            else
            {
                out.write("Sid=" + this.sid);
            }
            out.flush();
            out.close();
            try
            {
                in = new InputStreamReader(connection.getInputStream(), "utf-8");
            }
            catch (Exception ex)
            {
                LogUtil.log("Init get sip Web Error:\n");
                in = new InputStreamReader(httpconn.getErrorStream(), "utf-8");
                return;
            }
            i = 0;
            j = 0;
            while (true)
            {
                j = in.read();
                if (j == -1)
                {
                    data[i] = '\0';
                    break;
                }
                data[(i++)] = (char) j;
            }
            in.close();

            res = new String(data);

            this.sid = res.substring(res.indexOf("<Sid>") + 5);
            this.sid = this.sid.substring(0, this.sid.indexOf("</Sid>")).trim();
            LogUtil.log("sid:[" + this.sid + "]\n");
            if (this.sid.length() < 2)
            {
                LogUtil.log("CellPhone/Fetion ID is not exist\n");
                return;
            }
            res = res.substring(res.indexOf("<User>"));
            String uri = res.substring(res.indexOf("<Uri>") + 5);
            uri = uri.substring(0, uri.indexOf("</Uri>")).trim();
            LogUtil.log("uri:[" + uri + "]\n");
        }
        catch (Exception e)
        {
            LogUtil.log("Init Button Excetion:\n" + e.toString() + "\n");
        }
    }

    DataInputStream dataIn;
    DataOutputStream dataOut;
    Socket socket;
    String sendData;
    String getData;
    String sid;
    static final int LOGIN_SUCC = 0;
    static final int LOGIN_CONN_ERROR = 1;
    static final int LOGIN_DATAIO_ERROR = 2;
    static final int LOGIN_FAILED = 3;
    static int call_id;
    ArrayList<IDataType> Commands = new ArrayList<IDataType>();
    ArrayList<IDataType> Commands2 = new ArrayList<IDataType>();
    private static final String[] hexDigits =
    { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
    int Q1 = 2;
}
