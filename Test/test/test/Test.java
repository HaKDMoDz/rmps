/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package test;

import java.security.MessageDigest;
import java.util.HashMap;

import rmp.Rmps;
import rmp.comn.user.UserInfo;
import rmp.irp.m.I2010000.I2010000;
import rmp.irp.v.fetion.Fetion;
import test.irp.Message;
import test.irp.Session;

import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

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
        try
        {
            Fetion jf = new Fetion();
            jf.sign(IPresence.INIT);
            jf.sign(IPresence.SIGN);
        }
        catch (Exception exp)
        {
            System.out.println(exp);
        }
    }

    public static void test()
    {
        UserInfo user = new UserInfo("Amon", "Amon");
        user.wInit();
        Rmps.setUser(user);

        Session session = new Session();
        Message message = new Message("118.132.166.12");
        IService s = new I2010000();
        s.wInit();
        s.doInit(session, message);
        s.doRoot(session, message);
    }

    public static void sign()
    {
        try
        {
            HashMap<String, String> params = new HashMap<String, String>();
            params.put("VER", "1.1");
            params.put("CMD", "Login");
            String time = Long.toString(System.currentTimeMillis());
            params.put("SEQ", time.substring(time.length() - 5));
            params.put("UIN", "107618109");
            params.put("PS", CharUtil.toHex(MessageDigest.getInstance("MD5").digest("bIxSTULX1Yl9".getBytes())));
            params.put("M5", "1");
            params.put("LC", "9326B87B234E7235");
            // String data = HttpUtil.request("http://tqq.tencent.com:8000",
            // "POST", "gb2312", params);
            String data = HttpUtil.request("http://219.133.60.211:8000", "POST", "gb2312", params);
            System.out.println(data);
            // VER=1.1&CMD=Login&SEQ=17923&UIN=107618109&RES=0&RS=0&HI=60&LI=300&COMP=NOKIA8F3A18D6E27
            // VER=1.1&CMD=Login&SEQ=31126&UIN=107618109&RES=0&RS=0&HI=60&LI=300&COMP=NOKIA8F3A18D6E27
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public static void list()
    {
        try
        {
            HashMap<String, String> params = new HashMap<String, String>();
            params.put("VER", "1.1");// QQ协议的版本
            params.put("CMD", "Login");// 协议的命令，包括有Login（登录）、List（好友列表）
            String time = Long.toString(System.currentTimeMillis());
            params.put("SEQ", time.substring(time.length() - 7));// 防止重复发送标记
            params.put("UIN", "107618109");// 用户QQ号
            params.put("SN", "160");// 
            params.put("UN", "0");// 
            // String data = HttpUtil.request("http://tqq.tencent.com:8000",
            // "POST", "gb2312", params);
            String data = HttpUtil.request("http://119.147.11.76:8000", "POST", "gb2312", params);
            System.out.println(data);
            // VER=1.1&CMD=Login&SEQ=17923&UIN=107618109&RES=0&RS=0&HI=60&LI=300&COMP=NOKIA8F3A18D6E27
            // VER=1.1&CMD=Login&SEQ=31126&UIN=107618109&RES=0&RS=0&HI=60&LI=300&COMP=NOKIA8F3A18D6E27
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
