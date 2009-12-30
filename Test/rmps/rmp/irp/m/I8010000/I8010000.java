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
        session.send("请选择您要使用的摘要算法：");
        session.getProcess().setType(IProcess.TYPE_COMMAND);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        MessageDigest md = (MessageDigest) session.getAttribute(getCode() + "_t");
        StringBuffer msg = new StringBuffer();
        if (md != null)
        {
            msg.append("您上一次数据摘要结果为：").append(session.newLine());
            msg.append(CharUtil.toHex(md.digest()));
        }
        msg.append("请选择您要使用的摘要算法，要返回上一层请输入星号：");
        session.getProcess().setType(IProcess.TYPE_COMMAND);
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            // 用户输入文本
            String txt = message.getContent();
            String tmp = txt.trim();

            IProcess proc = session.getProcess();
            if (proc.getType() == IProcess.TYPE_COMMAND)
            {
                if (!proc.setItem(tmp))
                {
                    doInit(session, message);
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
            StringBuffer msg = new StringBuffer();
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
}
