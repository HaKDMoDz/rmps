/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30B0000.t;

import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.net.URL;
import java.net.URLConnection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import rmp.face.WBackCall;
import rmp.util.SoapUtil;
import cons.EnvCons;
import cons.SysCons;
import cons.prp.aide.P30B0000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 最终工具类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public final class Util
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 调用此模型并且需要回馈的对象 */
    private static HashMap<String, WBackCall> hm_PropList;

    /**
     * 
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
    public static void firePropertyChanged(String key, String value)
    {
        if (hm_PropList != null)
        {
            WBackCall backCall = hm_PropList.get(key);
            if (backCall != null)
            {
                backCall.wAction(null, value, null);
            }
        }
    }

    /**
     * 对服务器端返回的XML进行解析<br />
     * 返回结果说明：<br />
     * 
     * @return 字符串 用,分割
     * @throws Exception
     */
    public static List<HashMap<String, String>> getDetailInfoByTrainCode(String code) throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0001_FILE, ConstUI.SOAP_0001_ACTION, code);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        List<HashMap<String, String>> dataList = SoapUtil.domParse2Table(doc.getElementsByTagName("getDetailInfo"));

        is.close();

        return dataList;
    }

    /**
     * 通过发车站和到达站查询火车时刻表<br />
     * TrainCode:车次<br />
     * FirstStation:始发站<br />
     * LastStation:终点站<br />
     * StartStation:发车站<br />
     * StartTime:发车时间<br />
     * ArriveStation:到达站<br />
     * ArriveTime:到达时间<br />
     * KM:里程(KM)<br />
     * UseDate:历时<br />
     * 
     * @param s 发车站<br />
     * @param e 到达站（支持第一个字匹配模糊查询），空字符串默认发车站上海和到达站北京
     * @return
     * @throws Exception
     */
    public static List<HashMap<String, String>> getStationAndTimeByStationName(String s, String e) throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0002_FILE, ConstUI.SOAP_0002_ACTION, s, e);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        List<HashMap<String, String>> dataList = SoapUtil.domParse2Table(doc.getElementsByTagName("getStationAndTime"));

        is.close();

        return dataList;
    }

    /**
     * 通过火车车次查询火车时刻表<br />
     * String(0)=车次<br />
     * String(1)=始发站<br />
     * String(2)=终点站<br />
     * String(3)=发车站<br />
     * String (4)=发车时间<br />
     * String(5)=到达站<br />
     * String(6)=到达时间<br />
     * String(7)=里程(KM)<br />
     * String(8)=历时<br />
     * String(9)=空字符串(备用)<br />
     * 
     * @param code 车次代号字符串，空字符串默认上海到北京D32次
     * @return
     * @throws Exception
     */
    public static Map<Integer, String> getStationAndTimeByTrainCode(String code) throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0003_FILE, ConstUI.SOAP_0003_ACTION, code);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        Map<Integer, String> dataList = SoapUtil.domParse2Array(doc.getElementsByTagName("ArrayOfString"));

        is.close();

        return dataList;
    }

    /**
     * 通过火车车次查询本火车时刻表 TrainCode:车次<br />
     * FirstStation:始发站<br />
     * LastStation:终点站<br />
     * StartStation:发车站<br />
     * StartTime:发车时间<br />
     * ArriveStation:到达站<br />
     * ArriveTime:到达时间<br />
     * KM:里程(KM)<br />
     * UseDate:历时<br />
     * 
     * @param code 车次代号字符串，空字符串默认上海到北京D32次
     * @return
     * @throws Exception
     */
    public static List<HashMap<String, String>> getStationAndTimeDataSetByTrainCode(String code) throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0004_FILE, ConstUI.SOAP_0004_ACTION, code);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        List<HashMap<String, String>> dataList = SoapUtil.domParse2Table(doc.getElementsByTagName("getStationAndTime"));

        is.close();

        return dataList;
    }

    /**
     * 获得本火车时刻表Web Services的全部始发站名称
     * 
     * @return
     * @throws Exception
     */
    public static Map<Integer, String> getStationName() throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0005_FILE, ConstUI.SOAP_0005_ACTION);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        Map<Integer, String> dataList = SoapUtil.domParse2Array(doc.getElementsByTagName("ArrayOfString"));

        is.close();

        return dataList;
    }

    /**
     * @return
     * @throws Exception
     */
    public static List<HashMap<String, String>> getStationNameDataSet() throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0006_FILE, ConstUI.SOAP_0006_ACTION);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        List<HashMap<String, String>> dataList = SoapUtil.domParse2Table(doc.getElementsByTagName("getStationAndTime"));

        is.close();

        return dataList;
    }

    /**
     * 获得本火车时刻表Web Services的数据库版本更新时间
     * 
     * @return
     */
    public static String getVersionTime() throws Exception
    {
        // 得到DOM解析器的工厂实例
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(true);

        // 把要解析的XML文档转化为输入流，以便DOM解析器解析它
        InputStream is = getSoapInputStream(ConstUI.SOAP_0007_FILE, ConstUI.SOAP_0007_ACTION);

        // 解析XML文档的输入流，得到一个Document
        Document doc = dbf.newDocumentBuilder().parse(is);

        Element root = doc.getDocumentElement();

        String ver = root.getFirstChild().getNodeValue();

        is.close();

        return ver;
    }

    /**
     * 用户把SOAP请求发送给服务器端，并返回服务器点返回的输入流
     * 
     * @param uid 当前用户标记
     * @param sttCity 出发城市（中文城市名称或缩写、空则默认：上海）
     * @param endCity 抵达城市（中文城市名称或缩写、空则默认：北京）
     * @param theDate 出发日期（String 格式：yyyy-MM-dd，如：2007-07-02，空则默认当天）
     * @return 服务器端返回的输入流，供客户端读取
     * @throws Exception
     */
    private static InputStream getSoapInputStream(String soapName, String soapAction, String... soapArgs)
            throws Exception
    {
        String strSoap = SoapUtil.getSoapRequest(EnvCons.PATH_P30B0000, soapName, soapArgs);

        URL url = new URL(ConstUI.SOAP_POST);
        URLConnection conn = url.openConnection();
        conn.setUseCaches(false);
        conn.setDoInput(true);
        conn.setDoOutput(true);

        conn.setRequestProperty("Content-Length", Integer.toString(strSoap.length()));
        conn.setRequestProperty("Content-Type", ConstUI.SOAP_TYPE);
        conn.setRequestProperty("SOAPAction", soapAction);

        OutputStreamWriter osw = new OutputStreamWriter(conn.getOutputStream(), SysCons.FILE_ENCODING);
        osw.write(strSoap);
        osw.flush();
        osw.close();

        return conn.getInputStream();
    }
}
