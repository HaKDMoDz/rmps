/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
/*
 * 
 */
package rmp.irp.m.I8010000;

import java.security.MessageDigest;
import java.util.HashMap;

import rmp.irp.util.IrpsUtil;
import rmp.util.LogUtil;
import test.irp.Control;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 消息摘要
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author amon
 * 
 */
public class I8010000 implements IService
{
    private HashMap<String, String> hash;

    @Override
    public boolean wInit()
    {
        java.security.Security.addProvider(new cryptix.jce.provider.CryptixCrypto());
        hash = new HashMap<String, String>();
        hash.put("0", "MD2");
        hash.put("1", "MD4");
        hash.put("2", "MD5");
        hash.put("3", "RIPEMD-128");
        hash.put("4", "RIPEMD-160");
        hash.put("5", "SHA-0");
        hash.put("6", "SHA-1");
        hash.put("7", "SHA-256");
        hash.put("8", "SHA-384");
        hash.put("9", "SHA-512");
        hash.put("10", "Tiger");
        return true;
    }

    @Override
    public String getCode()
    {
        return "58010000";
    }

    @Override
    public String getName()
    {
        return "消息摘要";
    }

    @Override
    public String getDescription()
    {
        return "消息摘要";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doInit(session, msg);
        doHelp(session, msg);
        doMenu(session, msg);

        session.getProcess().setType(IProcess.TYPE_CONTENT);
        session.getProcess().setStep(1);
        session.send(msg.toString());
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doHelp(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        MessageDigest md = (MessageDigest) session.getAttribute(getCode() + "_t");
        StringBuffer msg = new StringBuffer();
        if (md != null)
        {
            msg.append("您上一次数据摘要结果为：").append(session.newLine());
            msg.append(CharUtil.toHex(md.digest())).append(session.newLine());
            msg.append(session.newLine());
        }

        doMenu(session, msg);

        session.getProcess().setType(IProcess.TYPE_COMMAND);
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            // 用户输入文本
            String txt = message.getContent();
            String tmp = txt.trim();
            StringBuffer msg = new StringBuffer();

            IProcess proc = session.getProcess();
            if (proc.getStep() == 1)
            {
                if (!IrpsUtil.isSZ(tmp))
                {
                    msg.append("您输入的不是的数字！").append(session.newLine());
                    doMenu(session, msg);
                    session.send(msg.toString());
                    return;
                }

                tmp = hash.get(tmp);
                if (!CharUtil.isValidate(tmp))
                {
                    msg.append("您输入的不是一个有效的数字！").append(session.newLine());
                    doMenu(session, msg);
                    session.send(msg.toString());
                    return;
                }

                // 判断用户输入合法性
                tmp = hash.get(tmp);
                if (!CharUtil.isValidate(tmp))
                {
                    doInit(session, message);
                    return;
                }

                // 生成摘要对象
                session.setAttribute(getCode() + "_s", MessageDigest.getInstance(tmp, "CryptixCrypto"));
                // 清除上一次摘要对象
                session.setAttribute(getCode() + "_t", null);
                proc.setType(IProcess.TYPE_CONTENT);
                return;
            }

            // 进行摘要计算
            MessageDigest md;
            if ("*".equals(Control.getCommand(tmp)))
            {
                md = (MessageDigest) session.getAttribute(getCode() + "_t");
                msg.append(CharUtil.format("{0}摘要结果为：", hash.get(proc.getItem()))).append(session.newLine());
                msg.append(CharUtil.toHex(md.digest())).append(session.newLine());
            }
            else
            {
                md = (MessageDigest) session.getAttribute(getCode() + "_s");
                md.update(txt.getBytes());
                session.setAttribute(getCode() + "_t", md);
                md = (MessageDigest) md.clone();
            }
            msg.append("已有信息摘要结果：").append(session.newLine());
            msg.append(CharUtil.toHex(md.digest()));
            msg.append(session.newLine());
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
    }

    private void doInit(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        message.append(CharUtil.format("　　《{0}》服务支持目前较为常用的多个商用摘要算法，如MD5、SHA-1、SHA-256、SHA-512、RIPEMD-128、Tiger等！", getName())).append(session.newLine());
    }

    private void doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、选择您要使用的消息摘要算法；").append(session.newLine());
        message.append("　　2、输入您要进行摘要处理的数据，可以连续输入；").append(session.newLine());
    }

    private void doMenu(ISession session, StringBuffer message)
    {
        for (int i = 0; i < 10; i += 1)
        {
            message.append(i).append('、').append(hash.get("" + i)).append(session.newLine());
        }
        message.append("请输入对应的数字选择您要使用的摘要算法：").append(session.newLine());
    }

    private void doStep(ISession session, StringBuffer message)
    {
        message.append("1、修改摘要算法；").append(session.newLine());
        message.append("2、输入消息数据；").append(session.newLine());
    }
}
