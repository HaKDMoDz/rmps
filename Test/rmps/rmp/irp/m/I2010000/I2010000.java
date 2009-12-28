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

import rmp.bean.K1SV2S;
import rmp.util.EnvUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;
import com.amonsoft.util.LogUtil;

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
    private static List<HashMap<String, K1SV2S>> maps;
    private static Pattern csPtn;

    @Override
    public boolean wInit()
    {
        try
        {
            maps = new ArrayList<HashMap<String, K1SV2S>>();
            maps.add(new HashMap<String, K1SV2S>());
            maps.add(new HashMap<String, K1SV2S>());
            maps.add(new HashMap<String, K1SV2S>());
            maps.add(new HashMap<String, K1SV2S>());

            csPtn = Pattern.compile("[a-z']+");

            // 读取省市/地区/县市/乡镇信息
            Element ele;
            String id0;
            String id1;
            String id2;
            HashMap<String, K1SV2S> map;
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            // 省市
            for (Object o0 : document.selectNodes("/irps/I2020000/item[@id='配置']/map"))
            {
                ele = (Element) o0;
                map = maps.get(0);
                id0 = ele.attributeValue("key");
                map.put(id0, new K1SV2S(ele.attributeValue("id"), "", "0"));

                // 地区
                for (Object o1 : ele.selectNodes("map"))
                {
                    ele = (Element) o1;
                    map = maps.get(1);
                    id1 = ele.attributeValue("key");
                    map.put(id1, new K1SV2S(ele.attributeValue("id"), id0, "1"));

                    // 县市
                    for (Object o2 : ele.selectNodes("map"))
                    {
                        ele = (Element) o2;
                        map = maps.get(1);
                        id2 = ele.attributeValue("key");
                        map.put(id2, new K1SV2S(ele.attributeValue("id"), id1, "2"));
                        // 乡镇
                        for (Object o3 : ele.selectNodes("map"))
                        {
                            ele = (Element) o3;
                            map = maps.get(1);
                            map.put(ele.attributeValue("key"), new K1SV2S(ele.attributeValue("id"), id2, "3"));
                        }
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
            if (!isPy)
            {
                // 查找是否存在用户输入的城市
                K1SV2S t = null;
                int i = -1;
                for (HashMap<String, K1SV2S> map : maps)
                {
                    t = map.get(tmp);
                    if (t != null)
                    {
                        break;
                    }
                    i += 1;
                }
                if (t == null)
                {
                    session.send("无法确认您输入的城市名称！");
                    return;
                }

                // 获取上一级城市信息
                HashMap<String, K1SV2S> map = maps.get(i);
                t = map.get(t.getV1());
            }

            // 获取天气数据
            String data = HttpUtil.request(CharUtil.format("http://flash.weather.com.cn/wmaps/xml/{0}.xml", ""), "GET", "utf-8");

            StringBuffer msg = new StringBuffer();
            Document doc = DocumentHelper.parseText(data);
            Element ele = doc.getRootElement();
            ele = (Element) ele.selectSingleNode(CharUtil.format("city[@{0}='{1}']", isPy ? "pyName" : "cityname", tmp));
            if (ele != null)
            {
                msg.append("今天概况：");
                msg.append("天气：").append(ele.attributeValue("stateDetailed")).append(session.newLine());
                msg.append("温度：").append(ele.attributeValue("tem1")).append('～').append(ele.attributeValue("tem2")).append(session.newLine());
                msg.append("风力：").append(ele.attributeValue("windState")).append(session.newLine());

                msg.append("当前实况：");
                msg.append("更新：").append(ele.attributeValue("time")).append(session.newLine());
                msg.append("温度：").append(ele.attributeValue("temNow")).append(session.newLine());
                msg.append("风向：").append(ele.attributeValue("windDir")).append(session.newLine());
                msg.append("风级：").append(ele.attributeValue("windPower")).append(session.newLine());
                msg.append("湿度：").append(ele.attributeValue("humidity")).append(session.newLine());
            }
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
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element ele = (Element) document.selectSingleNode("/irps/I2020000/item[@id='配置']");
            ele.clearContent();

            final String PATH = "http://service.weather.com.cn/plugin/data/city{0}.xml?level={1}";
            String tmp;
            int i = 0;

            // 省市
            Element ele0;
            Element ele1;
            Element ele2;
            Element ele3;
            String txt0 = HttpUtil.request(CharUtil.format(PATH, "", i), "GET", "utf-8");
            for (String tmp0 : txt0.split(","))
            {
                ele0 = DocumentHelper.createElement("map");
                tmp = split(ele, tmp0);
                ele.add(ele0);

                // 地区
                i = 1;
                String txt1 = HttpUtil.request(CharUtil.format(PATH, tmp, i), "GET", "utf-8");
                for (String tmp1 : txt1.split(","))
                {
                    ele1 = DocumentHelper.createElement("map");
                    tmp = split(ele1, tmp1);
                    ele0.add(ele1);

                    // 县市
                    i = 2;
                    String txt2 = HttpUtil.request(CharUtil.format(PATH, tmp, i), "GET", "utf-8");
                    for (String tmp2 : txt2.split(","))
                    {
                        ele2 = DocumentHelper.createElement("map");
                        tmp = split(ele2, tmp2);
                        ele1.add(ele2);

                        // 乡镇
                        i = 3;
                        String txt3 = HttpUtil.request(CharUtil.format(PATH, tmp, i), "GET", "utf-8");
                        for (String tmp3 : txt3.split(","))
                        {
                            ele3 = DocumentHelper.createElement("map");
                            split(ele3, tmp3);
                            ele2.add(ele3);
                        }
                    }
                }
            }

            XMLWriter writer = new XMLWriter(new FileOutputStream(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            writer.write(document);
            writer.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    private String split(Element ele, String txt)
    {
        String[] arr = txt.split("\\|");
        ele.addAttribute("id", arr[0]);
        ele.addAttribute("key", arr[1]);
        return arr[0];
    }
}
