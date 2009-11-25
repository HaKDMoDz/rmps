/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P30B0000;

import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_SOFT = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P30B0000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P30B0000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P30B0000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P30B0000.description";
    // ////////////////////////////////////////////////////////////////////////
    // SOAP配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** SOAP文档路径 */
    String SOAP_0001_FILE = "soap0001.xml";
    String SOAP_0002_FILE = "soap0002.xml";
    String SOAP_0003_FILE = "soap0003.xml";
    String SOAP_0004_FILE = "soap0004.xml";
    String SOAP_0005_FILE = "soap0005.xml";
    String SOAP_0006_FILE = "soap0006.xml";
    String SOAP_0007_FILE = "soap0007.xml";
    /** SOAP发送路径 */
    String SOAP_POST = "http://www.webxml.com.cn/webservices/DomesticAirline.asmx";
    /** SOAP主机地址 */
    String SOAP_HOST = "www.webxml.com.cn";
    /** SOAP内容类型 */
    String SOAP_TYPE = "text/xml; charset=utf-8";
    /**  */
    String SOAP_0001_ACTION = "http://WebXml.com.cn/getDetailInfoByTrainCode";
    String SOAP_0002_ACTION = "http://WebXml.com.cn/getStationAndTimeByStationName";
    String SOAP_0003_ACTION = "http://WebXml.com.cn/getStationAndTimeByTrainCode";
    String SOAP_0004_ACTION = "http://WebXml.com.cn/getStationAndTimeDataSetByTrainCode";
    String SOAP_0005_ACTION = "http://WebXml.com.cn/getStationName";
    String SOAP_0006_ACTION = "http://WebXml.com.cn/getStationNameDataSet";
    String SOAP_0007_ACTION = "http://WebXml.com.cn/getVersionTime";
}
