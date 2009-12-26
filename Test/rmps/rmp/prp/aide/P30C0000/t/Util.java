/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30C0000.t;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.net.URL;
import java.net.URLConnection;
import java.util.HashMap;

import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import rmp.face.WBackCall;
import rmp.util.FileUtil;
import rmp.util.StringUtil;
import cons.EnvCons;
import cons.SysCons;
import cons.prp.aide.P30C0000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public final class Util
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 调用此模型并且需要回馈的对象 */
    private static HashMap<String, WBackCall> hm_PropList;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    private Util()
    {
    }

    /**
     * 注册回馈对象引用
     * 
     * @param key
     * @param backCall
     */
    public static void register(String key, WBackCall backCall)
    {
        if (hm_PropList == null)
        {
            hm_PropList = new HashMap<String, WBackCall>();
        }
        hm_PropList.put(key, backCall);
    }

    /**
     * 指定回馈对象信息回馈
     * 
     * @param key
     */
    public static void firePropertyChanged(String key)
    {
        if (hm_PropList != null)
        {
            WBackCall backCall = hm_PropList.get(key);
            if (backCall != null)
            {
                backCall.wAction(null, null, null);
            }
        }
    }

    /**
     * 对服务器端返回的XML进行解析<br />
     * 返回结果说明：<br />
     * String(0)：IP地址<br />
     * String(1)：查询结果或提示信息<br />
     * 
     * @param city
     *            用户输入的城市名称
     * @return 字符串 用,分割
     * @throws Exception
     */
    public static HashMap<Integer, String> getCountryCityByIp(String city) throws Exception
    {
        HashMap<Integer, String> data = new HashMap<Integer, String>();

        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);
        InputStream is = getSoapInputStream(city);
        Document doc = dbf.newDocumentBuilder().parse(is);
        NodeList nl = doc.getElementsByTagName("string");

        Node node;
        for (int i = 0, j = nl.getLength(); i < j; i += 1)
        {
            // 取第i个节点
            node = nl.item(i);
            // 节点是否为空
            if (nl == null)
            {
                continue;
            }
            // 取节点的含值子节点
            node = node.getFirstChild();
            // 节点是否为空
            if (node == null)
            {
                continue;
            }
            // 节点是否有值
            if (node.getNodeValue() == null)
            {
                break;
            }
            // 记录节点值
            data.put(i, node.getNodeValue());
        }

        is.close();

        return data;
    }

    /**
     * 用户把SOAP请求发送给服务器端，并返回服务器点返回的输入流
     * 
     * @param city
     *            用户输入的城市名称
     * @return 服务器端返回的输入流，供客户端读取
     * @throws Exception
     */
    private static InputStream getSoapInputStream(String city) throws Exception
    {
        String strSoap = getSoapRequest(EnvCons.FOLDER0_TPLT + ConstUI.SOAP_FILE);
        strSoap = StringUtil.format(strSoap, city);

        URL url = new URL(ConstUI.SOAP_POST);
        URLConnection conn = url.openConnection();
        conn.setUseCaches(false);
        conn.setDoInput(true);
        conn.setDoOutput(true);

        conn.setRequestProperty("Host", ConstUI.SOAP_HOST);
        conn.setRequestProperty("Content-Type", ConstUI.SOAP_TYPE);
        conn.setRequestProperty("Content-Length", Integer.toString(strSoap.length()));
        conn.setRequestProperty("SOAPAction", ConstUI.SOAP_ACTION);

        OutputStreamWriter osw = new OutputStreamWriter(conn.getOutputStream(), SysCons.FILE_ENCODING);
        osw.write(strSoap);
        osw.flush();
        osw.close();

        return conn.getInputStream();
    }

    /**
     * 获取SOAP的请求头，并替换其中的标志符号为用户输入的城市
     * 
     * @param city
     *            用户输入的城市名称
     * @return 客户将要发送给服务器的SOAP请求
     * @throws Exception
     */
    private static String getSoapRequest(String filePath) throws Exception
    {
        BufferedReader br = FileUtil.getReader(filePath, SysCons.FILE_ENCODING);
        StringBuffer sb = new StringBuffer();
        String t = br.readLine();
        while (t != null)
        {
            sb.append(t);
            t = br.readLine();
        }
        return sb.toString();
    }
}
