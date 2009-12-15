/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I2010000;

import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;
import java.util.HashMap;

import rmp.util.CheckUtil;
import com.amonsoft.util.LogUtil;

import cons.irp.a.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 天气预报
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class I2010000 implements IService
{
    @Override
    public boolean wInit()
    {
        LogUtil.log(getName() + " 初始化成功！");
        return true;
    }

    @Override
    public String getCode()
    {
        return "52010000";
    }

    @Override
    public String getName()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getDescription()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            String command = message.getContent();
            if (!CheckUtil.isValidate(command))
            {
                command = "上海";
            }

            // 读取天气信息
            HashMap<Integer, String> dataList = rmp.prp.aide.P3090000.t.Util.getWeatherByCity(command);

            // 注册天气图标
//            message.registerEmoticon(ConstUI.P3090000_DAY11, StringUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
//                    dataList.get(8)));
//            message.registerEmoticon(ConstUI.P3090000_DAY12, StringUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
//                    dataList.get(9)));
//            message.registerEmoticon(ConstUI.P3090000_DAY21, StringUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
//                    dataList.get(15)));
//            message.registerEmoticon(ConstUI.P3090000_DAY22, StringUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
//                    dataList.get(16)));
//            message.registerEmoticon(ConstUI.P3090000_DAY31, StringUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
//                    dataList.get(20)));
//            message.registerEmoticon(ConstUI.P3090000_DAY32, StringUtil.format(cons.prp.aide.P3090000.ConstUI.BG_ICON,
//                    dataList.get(21)));

            // 分段发送天气信息
            StringBuffer sb = new StringBuffer("\r\n");
            int idx = 0;
            while (idx < 11)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);

            sb.delete(2, sb.length());
            while (idx < 12)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);

            sb.delete(2, sb.length());
            while (idx < 22)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);

            sb.delete(2, sb.length());
            while (idx < 23)
            {
                sb.append("ImsRobot.getMesg(ConstUI.P3090000_PRE + (idx + 500))");
                sb.append(dataList.get(idx)).append(ConstUI.NEXT_LINE);
                idx += 1;
            }

            // 向用户发送计算结果
            message.setContent(sb.toString());
            session.send(message);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            try
            {
                session.send(exp.getMessage());
            }
            catch (Exception e)
            {
                LogUtil.exception(e);
            }
        }
    }
}
