/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2050000;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import java.math.BigDecimal;
import java.util.HashMap;
import java.util.regex.Pattern;
import rmp.util.CheckUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 度量转换
 * <li>使用说明：</li>
 * <br />
 * </ul>
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
        return true;
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
    public void doInit(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String msg = message.getContent();

        if (!CheckUtil.isValidate(msg))
        {
            return;
        }
        String txt = msg.trim().toLowerCase();

        String[] tplt = txt.split("[=＝]");

        String temp = tplt[0];
        if (!CheckUtil.isValidate(temp))
        {
            session.send("请输入要来源单位！");
            return;
        }

        // 获取来源单位，并判断输入是否正确
        String uUnit = tplt[0].replaceAll(reg, "");
        String tUnit = prop.get(uUnit.toLowerCase());
        if (!CheckUtil.isValidate(tUnit))
        {
            session.send("小木看不懂您输入的是什么单位，请重新输入。");
            return;
        }
        // 判断输入数字的合法性
        temp = tplt[0].replace(uUnit, "");
        if (!Pattern.matches(reg + '$', temp))
        {
            session.send("小木无法辨认您输入的数字，请重新输入。");
            return;
        }
        BigDecimal dec1 = new BigDecimal(temp).multiply(decs.get(tUnit));

        // 判断用户是否直接输入结果单位
        HashMap<String, BigDecimal> map;
        if (tplt.length != 2)
        {
            map = decs;
        }
        else
        {
            temp = tplt[1];
            if (!CheckUtil.isValidate(tplt[1]))
            {
                // 没有输入目标单位的情况下，输出所有单位
                map = decs;
            }
            else
            {
                // 输入目标单位的情况下，判断目标单位的正确性
                uUnit = temp.replaceAll("[?？]", "").trim();
                tUnit = prop.get(uUnit.toLowerCase());
                if (!CheckUtil.isValidate(tUnit))
                {
                    session.send("公式输入错误，正确的输入格式示例如下：\n1米=?寸");
                    return;
                }

                // 仅保留目标单位
                map = new HashMap<String, BigDecimal>();
                map.put(temp, decs.get(tUnit));
            }
        }

        session.send(tplt[0]);
        if (step != Constant.STEP_WD)
        {
            for (String key : map.keySet())
            {
                BigDecimal dec2 = map.get(key);
                session.send("=" + dec1.divide(dec2) + uUnit);
            }
            return;
        }

        // 温度
        double c;
        double f;
        double k;
        double ra;
        double re;
        if ("摄氏度".equals(temp))
        {
            c = Double.parseDouble(temp);
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
        else if ("华氏度".equals(temp))
        {
            f = Double.parseDouble(temp);
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
        if ("开氏度".equals(temp))
        {
            k = Double.parseDouble(temp);
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
        if ("兰氏度".equals(temp))
        {
            ra = Double.parseDouble(temp);
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
        if ("列氏度".equals(temp))
        {
            re = Double.parseDouble(temp);
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
}
