/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3090000.t;

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

import com.amonsoft.util.CharUtil;

import cons.EnvCons;
import cons.SysCons;
import cons.prp.aide.P3090000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 最终工具类
 * <li>使用说明：</li>
 * <br />
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
    /** 查看指定天气状况 */
    private static int theDate = 5;

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
     * String(0)：省份<br />
     * String(1)：城市<br />
     * String(2):城市代码 String(3)：城市图片名称<br />
     * String(4)：最后更新时间<br />
     * String(5)：当天气温<br />
     * String(6)：当天概况<br />
     * String(7)：当天风向和风力<br />
     * String(8)：当天天气趋势开始图片名称<br />
     * String(9)：当天天气趋势结束图片名称<br />
     * String(10)：现在的天气实况<br />
     * String(11)：天气和生活指数<br />
     * String(12)：第二天气温<br />
     * String(13)：第二天概况<br />
     * String(14)：第二天风向和风力<br />
     * String(15)：第二天天气趋势开始图片名称<br />
     * String(16)：第二天天气趋势结束图片名称<br />
     * String(17)：第三天气温<br />
     * String(18)：第三天概况<br />
     * String(19)：第三天风向和风力<br />
     * String(20)：第三天天气趋势开始图片名称<br />
     * String(21)：第三天天气趋势结束图片名称<br />
     * String(22)：城市或地区的介绍<br />
     * 
     * @param city
     *            用户输入的城市名称
     * @return 字符串 用,分割
     * @throws Exception
     */
    public static HashMap<Integer, String> getWeatherByCity(String city) throws Exception
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
        strSoap = CharUtil.format(strSoap, city);

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

    /**
     * @return the theDate
     */
    public static int getTheDate()
    {
        return theDate;
    }

    /**
     * 设置查看天气信息：今天0；明天：1；后天2；其它：0
     * 
     * @param theDate
     *            the theDate to set
     */
    public static void setTheDate(int theDate)
    {
        // 明天
        if (1 == theDate)
        {
            Util.theDate = 12;
            return;
        }
        // 后天
        if (2 == theDate)
        {
            Util.theDate = 17;
            return;
        }
        // 今天
        Util.theDate = 5;
    }
}
