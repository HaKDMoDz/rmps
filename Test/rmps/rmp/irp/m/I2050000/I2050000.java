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
import java.util.List;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.bean.K1SV1S;
import rmp.irp.c.Control;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

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
    private static HashMap<String, HashMap<String, String>> prop;
    private static HashMap<String, HashMap<String, BigDecimal>> decs;
    private static String reg = "^[+-]?[0-9]+[.eE]?[0-9]*";

    @Override
    public boolean wInit()
    {
        try
        {
            LogUtil.log("度量转换初始化……");
            prop = new HashMap<String, HashMap<String, String>>();
            decs = new HashMap<String, HashMap<String, BigDecimal>>();

            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element root = (Element) document.selectSingleNode("/irps/" + getCode());

            // 支持单位初始化
            StringBuffer tmp = new StringBuffer();
            String sid;
            Element e1;
            Element e2;
            HashMap<String, String> k;
            HashMap<String, BigDecimal> u;
            for (Object t1 : root.selectNodes("item"))
            {
                e1 = (Element) t1;
                sid = e1.attributeValue("id");
                LogUtil.log("正在处理：" + sid);

                // 进制转换
                k = new HashMap<String, String>();
                for (Object t2 : e1.selectNodes("keys/map"))
                {
                    e2 = (Element) t2;
                    k.put(e2.attributeValue("key"), e2.getText());
                    tmp.append('、').append(e2.attributeValue("key"));
                }

                k.put(sid, tmp.substring(1));
                tmp.delete(0, tmp.length());
                prop.put(sid, k);

                // 转换单位
                u = new HashMap<String, BigDecimal>();
                for (Object t2 : e1.selectNodes("unit/map"))
                {
                    e2 = (Element) t2;
                    u.put(e2.attributeValue("key"), new BigDecimal(e2.getText()));
                }
                decs.put(sid, u);
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
        return "I2050000";
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
    public List<K1SV1S> getHelpTips()
    {
        return null;
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        doInit(session, msg);
        doHelp(session, msg.append(session.newLine()));

        session.getProcess().setType(IProcess.TYPE_CONTENT);
        session.getProcess().setItem(IProcess.ITEM_DEFAULT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        IProcess pro = session.getProcess();
        if (IProcess.ITEM_DEFAULT.equals(pro.getItem()))
        {
            StringBuffer msg = new StringBuffer(session.newLine());
            doMenu(session, msg);

            pro.setItem(Constant.ITEM_SUBMENU);
            session.send(msg.toString());
            return;
        }

        if (pro.setFunc(".."))
        {
            Control.getService(pro.getFunc()).doInit(session, message);
        }
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        doHelp(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        // 用户原始输入消息
        String txt = message.getContent();
        // 消息字符串转化
        String tmp = txt.trim().toLowerCase();
        StringBuffer msg = new StringBuffer(session.newLine());
        // IProcess pro = session.getProcess();

        // 判断是否指定转换目标
        String[] arr = tmp.split("[=＝]");
        tmp = arr[0];
        if (!CharUtil.isValidate(tmp))
        {
            session.send(msg.append("请输入转换来源单位！").append(session.newLine()).toString());
            return;
        }

        // 获取来源单位，并判断输入是否正确
        HashMap<String, String> k = null;
        HashMap<String, BigDecimal> u = null;
        String uUnit = arr[0].replaceAll(reg, "");// 用户输入度量单位
        String tUnit = null;// 参与计算度量单位
        boolean isWD = false;
        tmp = uUnit.toLowerCase();
        for (String t : prop.keySet())
        {
            k = prop.get(t);
            tUnit = k.get(tmp);
            if (CharUtil.isValidate(tUnit))
            {
                u = decs.get(t);
                isWD = "温度".equals(t);
                break;
            }
        }
        if (u == null)
        {
            session.send(msg.append("小木看不懂您输入的是什么单位，请重新输入。").append(session.newLine()).toString());
            return;
        }

        // 判断输入数字的合法性
        tmp = arr[0].replace(uUnit, "");// 获取用户输入数据
        if (!Pattern.matches(reg + '$', tmp))
        {
            session.send(msg.append("小木无法辨认您输入的数字，请重新输入。").append(session.newLine()).toString());
            return;
        }
        // 度量转换
        BigDecimal dec1 = new BigDecimal(tmp, new MathContext(7));
        if (!isWD)
        {
            dec1 = dec1.multiply(u.get(tUnit));
        }

        // 判断用户是否直接输入结果单位
        HashMap<String, BigDecimal> map;
        if (arr.length != 2)
        {
            // 没有输入结果单位的情况下，输出所有转换结果
            map = u;
        }
        else
        {
            tmp = arr[1];
            if (!CharUtil.isValidate(arr[1]))
            {
                // 没有输入目标单位的情况下，输出所有单位
                map = u;
            }
            else
            {
                // 输入目标单位的情况下，判断目标单位的正确性
                tmp = tmp.replaceAll("[?？]", "").trim();
                // uUnit= tmp.replaceAll("[?？]", "").trim();
                tUnit = k.get(tmp.toLowerCase());
                if (!CharUtil.isValidate(tUnit))
                {
                    if (CharUtil.isValidate(tmp))
                    {
                        session.send(msg.append(CharUtil.format("小木暂时还不知道{0}是什么度量单位，请确认您输入的是否正确？", tmp)).append(session.newLine()).toString());
                    }
                    else
                    {
                        session.send(msg.append("公式输入错误，正确的输入格式示例如下：\n1米=?寸").append(session.newLine()).toString());
                    }
                    return;
                }

                // 仅保留目标单位
                map = new HashMap<String, BigDecimal>();
                map.put(tmp, u.get(tUnit));
            }
        }

        msg.append(arr[0]);

        // 其它单位处理
        if (!isWD)
        {
            for (String key : map.keySet())
            {
                BigDecimal dec2 = map.get(key);
                msg.append(session.newLine()).append("=" + dec1.divide(dec2, 7, 0).toString().replaceAll("\\.?0*$", "") + key);
            }
            session.send(msg.toString());
            return;
        }

        // 温度特殊处理
        double dc = 0;
        double df = 0;
        double dk = 0;
        double ra = 0;
        double re = 0;
        tmp = arr[0].replace(uUnit, "");
        uUnit = k.get(uUnit);
        if ("摄氏度".equals(uUnit))
        {
            dc = Double.parseDouble(tmp);
            if (dc < -273.15)
            {
                session.send(msg.append("摄氏度不能低于-273.15。").append(session.newLine()).toString());
                return;
            }
            df = 32 + (dc * 9 / 5);
            dk = dc + 273.15;
            ra = dk * 1.8;
            re = dc / 1.25;
        }
        else if ("华氏度".equals(uUnit))
        {
            df = Double.parseDouble(tmp);
            if (df < -459.666666)
            {
                session.send(msg.append("华氏度不能低于-459.666666。").append(session.newLine()).toString());
                return;
            }
            dc = (df - 32) * 5 / 9;
            dk = dc + 273.15;
            ra = dk * 1.8;
            re = dc / 1.25;
        }
        else if ("开氏度".equals(uUnit))
        {
            dk = Double.parseDouble(tmp);
            if (dk < 0)
            {
                session.send(msg.append("开氏度不能低于0。").append(session.newLine()).toString());
                return;
            }
            dc = dk - 273.15;
            df = 32 + (dc * 9 / 5);
            ra = dk * 1.8;
            re = dc / 1.25;
        }
        else if ("兰氏度".equals(uUnit))
        {
            ra = Double.parseDouble(tmp);
            if (ra < 0)
            {
                session.send(msg.append("兰氏度不能低于0。").append(session.newLine()).toString());
                return;
            }
            dk = ra / 1.8;
            dc = dk - 273.15;
            df = 32 + (dc * 9 / 5);
            re = dc / 1.25;
        }
        else if ("列氏度".equals(uUnit))
        {
            re = Double.parseDouble(tmp);
            if (re < -218.5199999999)
            {
                session.send(msg.append("列氏度不能低于-218.5199999999。").append(session.newLine()).toString());
                return;
            }
            dc = re * 1.25;
            dk = dc + 273.15;
            df = 32 + (dc * 9 / 5);
            ra = dk * 1.8;
        }
        if (map.get(tUnit) != null)
        {
            msg.append(session.newLine()).append("=" + dc + "");
        }
        msg.append(session.newLine()).append("=" + dk + "");
        msg.append(session.newLine()).append("=" + df + "");
        msg.append(session.newLine()).append("=" + ra + "");
        msg.append(session.newLine()).append("=" + re + "");
        session.send(msg.toString());
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
    }

    private StringBuffer doInit(ISession session, StringBuffer message)
    {
        message.append("欢迎使用《度量转换》服务！").append(session.newLine());
        message.append("　　度量转换目前支持长度、面积、体积、重量、能量、压力、温度等单位的转换。").append(session.newLine());
        return message;
    }

    private StringBuffer doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、直接输入数字及单位：如1米；").append(session.newLine());
        message.append("　　2、数字与待转换单位=?目标转换单位：如1米=?寸；").append(session.newLine());
        return message;
    }

    private void doMenu(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("0、继续使用《{0}》服务；", getName())).append(session.newLine());
        message.append("*、返回上级服务选单；").append(session.newLine());
        message.append("请输入对应的数字选择您要使用的验证方法：").append(session.newLine());
    }
}
