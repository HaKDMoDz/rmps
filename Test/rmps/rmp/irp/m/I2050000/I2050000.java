/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2050000;

import java.io.File;
import java.math.BigDecimal;
import java.math.MathContext;
import java.util.HashMap;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.util.CheckUtil;
import rmp.util.EnvUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 度量转换
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I2050000 implements IService
{
    private static HashMap<String, String> prop;
    private static HashMap<String, BigDecimal> decs;
    static String reg = "^[+-]?[0-9]+[.eE]?[0-9]*";
    static int step = 0;

    @Override
    public boolean wInit()
    {
        try
        {
            LogUtil.log("度量转换初始化……");
            prop = new HashMap<String, String>();
            decs = new HashMap<String, BigDecimal>();

            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));

            // 支持单位初始化
            StringBuffer tmp = new StringBuffer();
            String sid;
            Element e1;
            Element e2;
            for (Object t1 : document.selectNodes("/irps/I2050000/item"))
            {
                e1 = (Element) t1;
                sid = e1.attributeValue("id");
                LogUtil.log("正在处理：" + sid);

                // 进制转换
                for (Object t2 : e1.selectNodes("keys/map"))
                {
                    e2 = (Element) t2;
                    prop.put(e2.attributeValue("key"), e2.getText());
                    tmp.append('、').append(e2.attributeValue("key"));
                }

                prop.put(sid, tmp.substring(1));
                tmp.delete(0, tmp.length());

                // 转换单位
                for (Object t2 : e1.selectNodes("unit/map"))
                {
                    e2 = (Element) t2;
                    decs.put(e2.attributeValue("key"), new BigDecimal(e2.getText()));
                }
            }
            LogUtil.log("度量转换初始化成功！");
            return true;
        }
        catch (DocumentException exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    @Override
    public String getCode()
    {
        return "52050000";
    }

    @Override
    public String getName()
    {
        return "度量转换";
    }

    @Override
    public String getDescription()
    {
        return "度量转换";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        session.send("Welcome!");
        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        // 用户原始输入消息
        String txt = message.getContent();
        // 消息字符串转化
        String tmp = txt.trim().toLowerCase();

        // 判断是否指定转换目标
        String[] arr = tmp.split("[=＝]");
        tmp = arr[0];
        if (!CheckUtil.isValidate(tmp))
        {
            session.send("请输入转换来源单位！");
            return;
        }

        // 获取来源单位，并判断输入是否正确
        String uUnit = arr[0].replaceAll(reg, "");
        String tUnit = prop.get(uUnit.toLowerCase());
        if (!CheckUtil.isValidate(tUnit))
        {
            session.send("小木看不懂您输入的是什么单位，请重新输入。");
            return;
        }
        // 判断输入数字的合法性
        tmp = arr[0].replace(uUnit, "");
        if (!Pattern.matches(reg + '$', tmp))
        {
            session.send("小木无法辨认您输入的数字，请重新输入。");
            return;
        }
        BigDecimal dec1 = new BigDecimal(tmp, new MathContext(7)).multiply(decs.get(tUnit));

        // 判断用户是否直接输入结果单位
        HashMap<String, BigDecimal> map;
        if (arr.length != 2)
        {
            map = decs;
        }
        else
        {
            tmp = arr[1];
            if (!CheckUtil.isValidate(arr[1]))
            {
                // 没有输入目标单位的情况下，输出所有单位
                map = decs;
            }
            else
            {
                // 输入目标单位的情况下，判断目标单位的正确性
                uUnit = tmp.replaceAll("[?？]", "").trim();
                tUnit = prop.get(uUnit.toLowerCase());
                if (!CheckUtil.isValidate(tUnit))
                {
                    session.send("公式输入错误，正确的输入格式示例如下：\n1米=?寸");
                    return;
                }

                // 仅保留目标单位
                map = new HashMap<String, BigDecimal>();
                map.put(tmp, decs.get(tUnit));
            }
        }

        StringBuffer msg = new StringBuffer();
        msg.append(arr[0]);

        // 其它单位处理
        if (step != Constant.STEP_WD)
        {
            for (String key : map.keySet())
            {
                BigDecimal dec2 = map.get(key);
                msg.append(session.newLine()).append("=" + dec1.divide(dec2, 7, 0) + uUnit);
            }
            session.send(msg.toString());
            return;
        }

        // 温度特殊处理
        double c;
        double f;
        double k;
        double ra;
        double re;
        if ("摄氏度".equals(tmp))
        {
            c = Double.parseDouble(tmp);
            if (c < -273.15)
            {
                session.send("摄氏度不能低于-273.15。");
                return;
            }
            f = 32 + (c * 9 / 5);
            k = c + 273.15;
            ra = k * 1.8;
            re = c / 1.25;
        }
        else if ("华氏度".equals(tmp))
        {
            f = Double.parseDouble(tmp);
            if (f < -459.666666)
            {
                session.send("华氏度不能低于-459.666666。");
                return;
            }
            c = (f - 32) * 5 / 9;
            k = c + 273.15;
            ra = k * 1.8;
            re = c / 1.25;
        }
        if ("开氏度".equals(tmp))
        {
            k = Double.parseDouble(tmp);
            if (k < 0)
            {
                session.send("开氏度不能低于0。");
                return;
            }
            c = k - 273.15;
            f = 32 + (c * 9 / 5);
            ra = k * 1.8;
            re = c / 1.25;
        }
        if ("兰氏度".equals(tmp))
        {
            ra = Double.parseDouble(tmp);
            if (ra < 0)
            {
                session.send("兰氏度不能低于0。");
                return;
            }
            k = ra / 1.8;
            c = k - 273.15;
            f = 32 + (c * 9 / 5);
            re = c / 1.25;
        }
        if ("列氏度".equals(tmp))
        {
            re = Double.parseDouble(tmp);
            if (re < -218.5199999999)
            {
                session.send("列氏度不能低于-218.5199999999。");
                return;
            }
            c = re * 1.25;
            k = c + 273.15;
            f = 32 + (c * 9 / 5);
            ra = k * 1.8;
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
}
