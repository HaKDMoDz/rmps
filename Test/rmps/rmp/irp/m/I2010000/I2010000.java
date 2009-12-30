/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2010000;

import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;
import org.dom4j.io.XMLWriter;

import rmp.bean.K1SV1S;
import rmp.bean.K1SV2S;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 天气预报
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I2010000 implements IService
{
    private static List<HashMap<String, K1SV2S>> csList;
    private static HashMap<String, String> pyName;
    private static Pattern csPtn;

    @Override
    public boolean wInit()
    {
        try
        {
            // 拼音：编码匹配
            csList = new ArrayList<HashMap<String, K1SV2S>>();
            csList.add(new HashMap<String, K1SV2S>());
            csList.add(new HashMap<String, K1SV2S>());
            csList.add(new HashMap<String, K1SV2S>());
            // 汉字：拼音匹配
            pyName = new HashMap<String, String>();

            csPtn = Pattern.compile("[a-z']+");

            // 读取省市/地区/县市/乡镇信息
            Element e;
            HashMap<String, K1SV2S> map;
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            // 省市
            for (Object o0 : document.selectNodes("/irps/I2010000/item[@id='配置']/map"))
            {
                e = (Element) o0;
                map = csList.get(0);
                String c0 = e.attributeValue("comment");
                map.put(c0, new K1SV2S(e.attributeValue("id"), "", "0"));
                pyName.put(e.attributeValue("key"), c0);

                // 地区
                for (Object o1 : e.selectNodes("map"))
                {
                    e = (Element) o1;
                    map = csList.get(1);
                    String c1 = e.attributeValue("comment");
                    map.put(c1, new K1SV2S(e.attributeValue("id"), c0, "1"));
                    if (CharUtil.isValidate(c1))
                    {
                        pyName.put(e.attributeValue("key"), c1);
                    }

                    // 县市
                    for (Object o2 : e.selectNodes("map"))
                    {
                        e = (Element) o2;
                        map = csList.get(2);
                        String c2 = e.attributeValue("comment");
                        System.out.println(e.attributeValue("key") + "," + c2);
                        map.put(c2, new K1SV2S(e.attributeValue("id"), c1, "2"));
                        pyName.put(e.attributeValue("key"), c2);
                    }
                }
            }
            return true;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            return false;
        }
    }

    @Override
    public String getCode()
    {
        return "52010000";
    }

    @Override
    public String getName()
    {
        return "天气预报";
    }

    @Override
    public String getDescription()
    {
        return "天气预报";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        msg.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        msg.append(CharUtil.format("　　《{0}》服务目前", getName())).append(session.newLine());
        msg.append("　　您可以通过如下的方式使用此服务：").append(session.newLine());
        msg.append("　　1、直接输入您要查询的城市名称：如上海；").append(session.newLine());
        msg.append("　　2、输入您要查询的城市名称拼音：如shanghai；").append(session.newLine());
        session.send(msg.toString());
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            String txt = message.getContent();
            String tmp = txt.trim();

            boolean isPy = csPtn.matcher(tmp).matches();
            if (isPy)
            {
                tmp = tmp.replaceAll("\\s|sheng|zizhiqu|diqu|qu|xian|shi|xiang|zhen$", "");
            }
            else
            {
                // 查找是否存在用户输入的城市
                tmp = pyName.get(tmp.replaceAll("\\s|省|自治区|地区|区|县|市|乡|镇$", ""));
                if (!CharUtil.isValidate(tmp))
                {
                    session.send("无法确认您输入的城市名称，请重新输入！");
                    return;
                }
            }
            K1SV2S item;
            int i = csList.size() - 1;
            String top = null;
            while (i >= 0)
            {
                item = csList.get(i--).get(tmp);
                if (item != null && CharUtil.isValidate(item.getV1()))
                {
                    top = item.getV1();
                    break;
                }
            }
            if (!CharUtil.isValidate(top))
            {
                top = "china";
            }

            // 获取天气数据
            String data = HttpUtil.request(CharUtil.format("http://flash.weather.com.cn/wmaps/xml/{0}.xml", top), "GET", "utf-8");

            StringBuffer msg = new StringBuffer();
            Document doc = DocumentHelper.parseText(data);
            Element ele = doc.getRootElement();
            ele = (Element) ele.selectSingleNode(CharUtil.format("city[@pyName='{0}']", tmp));
            if (ele != null)
            {
                msg.append("城市：").append(ele.attributeValue("cityname")).append(session.newLine());

                msg.append(session.newLine()).append("【今日概况】").append(session.newLine());
                msg.append("天气：").append(ele.attributeValue("stateDetailed")).append(session.newLine());
                msg.append("温度：").append(ele.attributeValue("tem1")).append("℃～").append(ele.attributeValue("tem2")).append('℃').append(session.newLine());
                msg.append("风力：").append(ele.attributeValue("windState")).append(session.newLine());

                // 判断有无实况信息
                tmp = ele.attributeValue("time");
                if (CharUtil.isValidate(tmp))
                {
                    msg.append(session.newLine()).append("【当前实况】").append(session.newLine());
                    msg.append("更新：").append(tmp).append(session.newLine());
                    msg.append("温度：").append(ele.attributeValue("temNow")).append('℃').append(session.newLine());
                    msg.append("风向：").append(ele.attributeValue("windDir")).append(session.newLine());
                    msg.append("风级：").append(ele.attributeValue("windPower")).append(session.newLine());
                    msg.append("湿度：").append(ele.attributeValue("humidity")).append(session.newLine());
                }
            }
            session.send(msg.toString());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    @Override
    public void doRoot(ISession session, IMessage message)
    {
        try
        {
            // 读取天气代码
            HashMap<String, K1SV1S> city0 = new HashMap<String, K1SV1S>();
            HashMap<String, K1SV1S> city1 = new HashMap<String, K1SV1S>();
            HashMap<String, K1SV1S> city2 = new HashMap<String, K1SV1S>();

            boolean spSign = false;
            String spName = "北京上海天津重庆海南香港澳门台湾";
            final String CODE = "http://flash.weather.com.cn/wmaps/xml/{0}.xml";

            // 省市
            String txt0 = HttpUtil.request(CharUtil.format(CODE, "china"), "GET", "UTF-8");
            Document doc0 = DocumentHelper.parseText(txt0);
            for (Object obj0 : doc0.getRootElement().selectNodes("city"))
            {
                Element ele0 = (Element) obj0;
                txt0 = ele0.attributeValue("pyName");
                String tmp = ele0.attributeValue("quName");
                city0.put(tmp, new K1SV1S(txt0, ele0.attributeValue("url")));
                // 特殊处理
                spSign = spName.indexOf(tmp) < 0;

                // 地区
                String txt1 = HttpUtil.request(CharUtil.format(CODE, txt0), "GET", "UTF-8");
                Document doc1 = DocumentHelper.parseText(txt1);
                for (Object obj1 : doc1.getRootElement().selectNodes("city"))
                {
                    Element ele1 = (Element) obj1;
                    txt1 = ele1.attributeValue("pyName");
                    city1.put(ele1.attributeValue("cityname"), new K1SV1S(txt1, ele1.attributeValue("url")));

                    if (spSign)
                    {
                        // 县市
                        String txt2 = HttpUtil.request(CharUtil.format(CODE, txt1), "GET", "UTF-8");
                        Document doc2 = DocumentHelper.parseText(txt2);
                        for (Object obj2 : doc2.getRootElement().selectNodes("city"))
                        {
                            Element ele2 = (Element) obj2;
                            txt2 = ele2.attributeValue("pyName");
                            city2.put(ele2.attributeValue("cityname"), new K1SV1S(txt2, ele2.attributeValue("url")));
                        }
                    }
                }
            }

            // 读取行政划分
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element ele = (Element) document.selectSingleNode("/irps/I2010000/item[@id='配置']");
            ele.clearContent();

            final String PATH = "http://service.weather.com.cn/plugin/data/city{0}.xml?level={1}";
            String tmp;
            int i = 0;

            // 省市
            txt0 = HttpUtil.request(CharUtil.format(PATH, "", i), "GET", "utf-8");
            for (String tmp0 : txt0.split(","))
            {
                Element ele0 = DocumentHelper.createElement("map");
                tmp = split(ele0, tmp0, city0);
                ele.add(ele0);
                // 特殊处理
                spSign = spName.indexOf(ele0.attributeValue("key")) >= 0;

                // 地区
                i = 1;
                String txt1 = HttpUtil.request(CharUtil.format(PATH, tmp, i), "GET", "utf-8");
                for (String tmp1 : txt1.split(","))
                {
                    Element ele1 = DocumentHelper.createElement("map");
                    tmp = split(ele1, tmp1, spSign ? null : city1);
                    ele0.add(ele1);

                    // 县市
                    i = 2;
                    String txt2 = HttpUtil.request(CharUtil.format(PATH, tmp, i), "GET", "utf-8");
                    for (String tmp2 : txt2.split(","))
                    {
                        Element ele2 = DocumentHelper.createElement("map");
                        tmp = split(ele2, tmp2, spSign ? city1 : city2);
                        ele1.add(ele2);
                    }
                }
            }

            XMLWriter writer = new XMLWriter(new FileOutputStream(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            writer.write(document);
            writer.close();

            StringBuffer msg = new StringBuffer();
            msg.append("数据更新完毕，您可能还需要修改文件中以下几个地方：").append(session.newLine());
            msg.append("<map key=\"北京\">").append(session.newLine());
            msg.append("<map key=\"上海\">").append(session.newLine());
            msg.append("<map key=\"天津\">").append(session.newLine());
            msg.append("<map key=\"重庆\">").append(session.newLine());
            msg.append("以上节点分别添加id和comment属性，以方便天气查询！");
            session.send(msg.toString());
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    private String split(Element ele, String txt, HashMap<String, K1SV1S> map)
    {
        String[] arr = txt.split("\\|");
        String tmp = arr[1];
        ele.addAttribute("key", tmp);
        for (String key : map.keySet())
        {
            if (key != null && key.indexOf(tmp) >= 0)
            {
                K1SV1S kv = map.get(key);
                if (kv != null)
                {
                    ele.addAttribute("id", kv.getV() == null ? "" : kv.getV());
                    ele.addAttribute("comment", kv.getK() == null ? "" : kv.getK());
                }
                map.remove(key);
                break;
            }
        }
        return arr[0];
    }
}
