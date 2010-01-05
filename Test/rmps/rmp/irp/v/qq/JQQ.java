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
package rmp.irp.v.qq;

import java.security.MessageDigest;
import java.util.HashMap;

import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class JQQ
{
    private IConnect connect;

    public JQQ(IConnect connect)
    {
        this.connect = connect;
    }

    public boolean signIn()
    {
        try
        {
            HashMap<String, String> params = new HashMap<String, String>();
            params.put("VER", "1.1");// QQ协议的版本
            params.put("CMD", "Login");// 协议的命令，包括有Login（登录）、List（好友列表）
            String time = Long.toString(System.currentTimeMillis());
            params.put("SEQ", time.substring(time.length() - 7));// 防止重复发送标记
            params.put("UIN", connect.getUser());// 用户QQ号
            params.put("PS", CharUtil.toHex(MessageDigest.getInstance("MD5").digest(connect.getPwds().getBytes())));// MD5加密后的密码
            params.put("M5", "1");// 固定，使用MD5算法
            params.put("LC", "9326B87B234E7235");// 登录平台
            String data = HttpUtil.request(connect.getHost() + ":" + connect.getPort(), "POST", "gb2312", params);

            // 返回结果
            // VER=1.1
            // &CMD=Login
            // &SEQ=18140
            // &UIN=107618109
            // &RES=0
            // &RS=0，登录状态，为0表示登录成功，为1表示失败，同时返回RA（失败原因）
            // &HI=60
            // &LI=300
            // &COMP=NOKIA8F3A18D6E27
            if (!CharUtil.isValidate(data))
            {
                return false;
            }

            System.out.println();

            params.clear();
            String[] args;
            for (String item : data.split("&"))
            {
                args = item.split("=");
                params.put(args[0], args[1]);
            }
            return "0".equals(params.get("RES"));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return true;
    }

    public void list()
    {
        try
        {
            HashMap<String, String> params = new HashMap<String, String>();
            params.put("VER", "1.1");// QQ协议的版本
            params.put("CMD", "Login");// 协议的命令，包括有Login（登录）、List（好友列表）
            String time = Long.toString(System.currentTimeMillis());
            params.put("SEQ", time.substring(time.length() - 7));// 防止重复发送标记
            params.put("UIN", connect.getUser());// 用户QQ号
            params.put("TN", "160");// 
            params.put("UN", "0");// 
            String data = HttpUtil.request(connect.getHost() + ":" + connect.getPort(), "POST", "gb2312", params);
            System.out.println(data);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }
}
