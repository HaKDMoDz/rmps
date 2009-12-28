/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30A0000.t;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import rmp.util.FileUtil;

import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;
import cons.SysCons;
import cons.prp.aide.P30A0000.ConstUI;

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
    /**
     * 
     */
    private Util()
    {
    }

    /**
     * 对服务器端返回的XML进行解析<br />
     * 返回结果说明：<br />
     * String(0)：省份<br />
     * String(1)：城市<br />
     * String(2):城市代码 String(3)：城市图片名称<br />
     * String(4)：最后更新时间<br />
     * String(5)：当天的气温<br />
     * String(6)：概况<br />
     * String(7)：风向和风力<br />
     * String(8)：天气趋势开始图片名称<br />
     * String(9)：天气趋势结束图片名称<br />
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
     * @param sttCity
     *            出发城市（中文城市名称或缩写、空则默认：上海）
     * @param endCity
     *            抵达城市（中文城市名称或缩写、空则默认：北京）
     * @param theDate
     *            出发日期（String 格式：yyyy-MM-dd，如：2007-07-02，空则默认当天）
     * @return 字符串 用,分割
     * @throws Exception
     */
    public static List<HashMap<String, String>> getDomesticAirlinesTime(String sttCity, String endCity, String theDate) throws Exception
    {
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);
        InputStream is = getSoapInputStream(sttCity, endCity, theDate);
        Document doc = dbf.newDocumentBuilder().parse(is);
        NodeList nl1 = doc.getElementsByTagName("AirlinesTime");

        if (nl1 == null || nl1.getLength() < 1)
        {
            return new ArrayList<HashMap<String, String>>(0);
        }

        int itemSize = nl1.getLength();
        List<HashMap<String, String>> dataList = new ArrayList<HashMap<String, String>>(itemSize);

        Node node;
        NodeList nl2;
        HashMap<String, String> item;
        String name;
        for (int i = 0; i < itemSize; i += 1)
        {
            // 取第i个节点
            node = nl1.item(i);
            // 节点是否为空
            if (node == null)
            {
                continue;
            }

            node.getFirstChild().getUserData("Week");

            nl2 = node.getChildNodes();
            item = new HashMap<String, String>();
            for (int m = 0, n = nl2.getLength(); m < n; m += 1)
            {
                // 取第m个节点
                node = nl2.item(m);
                // 节点是否为空
                if (node == null)
                {
                    continue;
                }
                name = node.getNodeName();

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
                item.put(name, node.getNodeValue());
            }

            dataList.add(item);
        }

        is.close();

        LogUtil.log("航班信息获取成功！");

        return dataList;
    }

    /**
     * 用户把SOAP请求发送给服务器端，并返回服务器点返回的输入流
     * 
     * @param sttCity
     *            出发城市（中文城市名称或缩写、空则默认：上海）
     * @param endCity
     *            抵达城市（中文城市名称或缩写、空则默认：北京）
     * @param theDate
     *            出发日期（String 格式：yyyy-MM-dd，如：2007-07-02，空则默认当天）
     * @return 服务器端返回的输入流，供客户端读取
     * @throws Exception
     */
    private static InputStream getSoapInputStream(String sttCity, String endCity, String theDate) throws Exception
    {
        String strSoap = getSoapRequest(EnvCons.FOLDER0_TPLT + ConstUI.SOAP_FILE);
        strSoap = CharUtil.format(strSoap, sttCity, endCity, theDate);

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
