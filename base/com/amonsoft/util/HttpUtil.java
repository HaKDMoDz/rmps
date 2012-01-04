/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.util;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.ByteArrayOutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.HashMap;

public class HttpUtil
{
    private HttpUtil()
    {
    }

    /**
     * 直接请求网络地址
     * 
     * @param url
     *            页面地址
     * @param method
     *            请求发送方式
     * @param charset
     *            编码方案
     * @return
     * @throws Exception
     */
    public static String request(String url, String method, String charset, HashMap<String, String> params) throws Exception
    {
        HttpURLConnection conn = (HttpURLConnection) (new URL(url.replace(" ", "%20")).openConnection());
        conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
        conn.setUseCaches(true);
        conn.setDoInput(true);
        conn.setDoOutput(true);
        conn.setRequestMethod(method);

        // 参数传递
        if (params != null && params.size() > 0)
        {
            StringBuffer buf = new StringBuffer();
            for (String key : params.keySet())
            {
                buf.append('&').append(key).append('=').append(params.get(key));
            }
            BufferedOutputStream bos = new BufferedOutputStream(conn.getOutputStream());
            bos.write(buf.substring(1).getBytes(charset));
            bos.close();
        }

        // 读取返回结果
        BufferedInputStream bis = new BufferedInputStream(conn.getInputStream());
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        byte[] b = new byte[1024];
        int i = bis.read(b);
        while (i >= 0)
        {
            baos.write(b, 0, i);
            i = bis.read(b);
        }
        return new String(baos.toByteArray(), charset);
    }
}
