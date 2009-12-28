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

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;
import org.dom4j.io.XMLWriter;

import rmp.bean.K1SV1S;
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
    private List<HashMap<String, K1SV1S>> maps;

    @Override
    public boolean wInit()
    {
        try
        {
            maps = new ArrayList<HashMap<String, K1SV1S>>();
            maps.add(new HashMap<String, K1SV1S>());
            maps.add(new HashMap<String, K1SV1S>());
            maps.add(new HashMap<String, K1SV1S>());
            maps.add(new HashMap<String, K1SV1S>());

            // 读取省市/地区/县市/乡镇信息
            Element ele;
            HashMap<String, K1SV1S> map;
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            // 省市
            for (Object o1 : document.selectNodes("/irps/I2020000/item[@id='配置']/map"))
            {
                ele = (Element) o1;
                map = maps.get(0);
                map.put(ele.attributeValue("key"), new K1SV1S(ele.attributeValue("id"), ""));

                // 地区
                for (Object o2 : ele.selectNodes("map"))
                {
                    ele = (Element) o2;
                    map = maps.get(1);
                    map.put(ele.attributeValue("key"), new K1SV1S(ele.attributeValue("id"), ""));

                    // 县市
                    for (Object o3 : ele.selectNodes("map"))
                    {
                        ele = (Element) o3;
                        map = maps.get(1);
                        map.put(ele.attributeValue("key"), new K1SV1S(ele.attributeValue("id"), ""));
                        // 乡镇
                        for (Object o4 : ele.selectNodes("map"))
                        {
                            ele = (Element) o4;
                            map = maps.get(1);
                            map.put(ele.attributeValue("key"), new K1SV1S(ele.attributeValue("id"), ""));
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
    public void doInit(ISession arg0, IMessage arg1)
    {
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
        String txt = message.getContent();
        String tmp = txt.trim();
        String t = null;
        for (HashMap<String, K1SV1S> map : maps)
        {
            //t = map.get(tmp);
            if (t != null)
            {
                break;
            }
        }
        if (t == null)
        {
            session.send("无法确认您输入的城市名称！");
            return;
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
