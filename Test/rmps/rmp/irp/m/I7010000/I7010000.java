/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I7010000;

import java.util.ArrayList;
import java.util.List;

import rmp.bean.K1SV1S;
import rmp.bean.K1SV2S;
import rmp.irp.c.Control;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

import cons.irp.ConsEnv;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 科学计算
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I7010000 implements IService
{
    public I7010000()
    {
    }

    @Override
    public boolean wInit()
    {
        LogUtil.log(getName() + " 初始化成功！");
        return true;
    }

    @Override
    public String getCode()
    {
        return "I7010000";
    }

    @Override
    public String getName()
    {
        return "科学计算";
    }

    @Override
    public String getDescription()
    {
        return "科学计算";
    }

    @Override
    public List<K1SV1S> getHelpTips()
    {
        return null;
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doInit(session, msg);
        msg.append(session.newLine());
        doHelp(session, msg);

        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
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
        String key = message.getContent();
        String tmp = key.trim();
        StringBuffer msg = new StringBuffer();
        IProcess pro = session.getProcess();

        try
        {
            if (ConsEnv.KEY_FUNC.equals(tmp))
            {
                if (pro.setFunc(".."))
                {
                    Control.getService(pro.getFunc()).doInit(session, message);
                }
                return;
            }

            List<K1SV2S> list = new ArrayList<K1SV2S>();
            rmp.prp.aide.P3060000.t.Util.calculate(tmp, 8, list);
            for (K1SV2S item : list)
            {
                msg.append("=").append(item.getK()).append(session.newLine());
                msg.append("~~").append(item.getV1()).append("-->").append(item.getV2()).append(session.newLine());
            }
        }
        catch (Exception exp)
        {
            msg.append(exp.getMessage()).append(session.newLine());
        }

        // 设置下一次操作状态
        pro.setType(IProcess.TYPE_CONTENT);
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
        message.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        message.append(CharUtil.format("　　《{0}》服务目前支持四则、代数、三角等运算，并且支持用户自定义运算精度！", getName())).append(session.newLine());
        return message;
    }

    private StringBuffer doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、直接输入您要进行运算的表达式，如：1+{[2.3*(4-5)]^6.7}-8!*sin(cotπ)").append(session.newLine());
        return message;
    }
}
