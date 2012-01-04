/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3090000;

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
 * 
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3090000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3090000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3090000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3090000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 软件配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 用户天气配置 */
    String CFG_CITY = "P3090000.city";
    // ////////////////////////////////////////////////////////////////////////
    // 天气预报图片路径
    // ////////////////////////////////////////////////////////////////////////
    /** 分晓背景 */
    String BG_DAWN = "/prp/aide/P3090000/default/bgd.png";
    /** 白天背景 */
    String BG_DAYLIGHT = "/prp/aide/P3090000/default/bgl.png";
    /** 夜间背景 */
    String BG_NIGHT = "/prp/aide/P3090000/default/bgn.png";
    /** 高亮背景 */
    String BG_HIGHLIGHT = "/prp/aide/P3090000/default/bgh.png";
    /** 天气状况图标 */
    String BG_ICON = "/prp/aide/P3090000/default/{0}";
    // ////////////////////////////////////////////////////////////////////////
    // SOAP配置
    // ////////////////////////////////////////////////////////////////////////
    /** SOAP文档路径 */
    String SOAP_FILE = "/prp/aide/P3090000/soap0001.xml";
    /** SOAP服务路径 */
    String SOAP_POST = "http://www.webxml.com.cn/WebServices/WeatherWebService.asmx";
    /**  */
    String SOAP_HOST = "www.webxml.com.cn";
    /**  */
    String SOAP_TYPE = "text/xml; charset=utf-8";
    /**  */
    String SOAP_ACTION = "http://WebXml.com.cn/getWeatherbyCityName";
    // ////////////////////////////////////////////////////////////////////////
    // 界面配置
    // ////////////////////////////////////////////////////////////////////////
    /** 视图区域高度 */
    int VIEW_HIGH = 67;
    /** 视图区域宽度 */
    int VIEW_WIDH = 132;
}
