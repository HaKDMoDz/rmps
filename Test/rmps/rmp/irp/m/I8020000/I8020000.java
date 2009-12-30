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
package rmp.irp.m.I8020000;

import java.util.HashMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 正则运算
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author amon
 * 
 */
public class I8020000 implements IService
{
    private HashMap<String, String> hash;

    @Override
    public boolean wInit()
    {
        hash = new HashMap<String, String>(4);
        hash.put("0", Constant.METHOD_TEST);
        // hash.put("1", Constant.METHOD_MATCH);
        hash.put("1", Constant.METHOD_SPLIT);
        hash.put("2", Constant.METHOD_SEARCH);
        hash.put("3", Constant.METHOD_REPLACE);
        return true;
    }

    @Override
    public String getCode()
    {
        return "58020000";
    }

    @Override
    public String getName()
    {
        return "正则运算";
    }

    @Override
    public String getDescription()
    {
        return "正则运算";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doInit(session, msg);

        session.send(msg.toString());
        session.getProcess().setType(IProcess.TYPE_NACTION | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(1);
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
        StringBuffer msg = new StringBuffer();
        doMenu(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.trim();

        IProcess proc = session.getProcess();
        // 功能选择
        if (proc.getStep() == IProcess.STEP_DEFAULT)
        {
            if ("1".equals(tmp))
            {
                proc.setStep(3);
            }
            else if ("2".equals(tmp))
            {
                proc.setStep(2);
            }
            else if ("3".equals(tmp))
            {
                proc.setStep(1);
            }
            else if ("*".equals(tmp))
            {
                proc.setType(IProcess.TYPE_KEYCODE);
            }
            return;
        }
        // 输入表达式
        if (proc.getStep() == 1)
        {
            if (!CharUtil.isValidate(txt))
            {
                session.send("表达式不能为空，请重新输入！");
                return;
            }
            session.setAttribute(getCode() + "_r", txt);

            // 判断字符串
            if (session.getAttribute(getCode() + "_t") == null)
            {
                session.send("请输入您要验证的字符串，或*号返回服务选择菜单！");
                proc.setStep(2);
            }
            else
            {
                showData(session);
            }
            return;
        }
        // 输入字符串
        if (proc.getStep() == 2)
        {
            if (!CharUtil.isValidate(txt))
            {
                session.send("字符串不能为空，请重新输入！");
                return;
            }
            session.setAttribute(getCode() + "_t", txt);

            // 判断运算符
            if (session.getAttribute(getCode() + "_p") == null)
            {
                StringBuffer msg = new StringBuffer();
                msg.append("请选择您要执行的的验证方法，或*号返回服务选择菜单！").append(session.newLine());
                for (String key : hash.keySet())
                {
                    msg.append(key).append("、").append(hash.get(key)).append(session.newLine());
                }
                session.send(msg.toString());
                proc.setStep(3);
            }
            else
            {
                showData(session);
            }
            return;
        }
        // 选择运算符
        if (proc.getStep() == 3)
        {
            if (!CharUtil.isValidate(tmp))
            {
                session.send("请选择您要执行的验证方法！");
                return;
            }
            session.setAttribute(getCode() + "_p", tmp);
            showData(session);
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
    }

    private void showData(ISession session)
    {
        StringBuffer message = new StringBuffer();
        String r = (String) session.getAttribute(getCode() + "_r");// 表达式
        String t = (String) session.getAttribute(getCode() + "_t");// 字符串
        String m = hash.get((String) session.getAttribute(getCode() + "_p"));// 运算符
        if (Constant.METHOD_TEST.equals(m))
        {
            message.append(Constant.METHOD_TEST).append("()运行结果：").append(Pattern.matches(r, t));
        }
        else if (Constant.METHOD_MATCH.equals(m))
        {
        }
        else if (Constant.METHOD_SPLIT.equals(m))
        {
            message.append(Constant.METHOD_SPLIT).append("()运行结果：").append(session.newLine());
            for (String s : t.split(r))
            {
                message.append(s).append(session.newLine());
            }
        }
        else if (Constant.METHOD_SEARCH.equals(m))
        {
            message.append(Constant.METHOD_SEARCH).append("()运行结果：").append(session.newLine());
            Matcher p = Pattern.compile(r).matcher(t);
            while (p.find())
            {
                message.append(p.group()).append(session.newLine());
            }
        }
        else if (Constant.METHOD_REPLACE.equals(m))
        {
            message.append(Constant.METHOD_REPLACE).append("()运行结果：").append(t.replaceAll(r, ""));
        }
        message.append(session.newLine());
        message.append("请选择您要进行的操作：").append(session.newLine());
        message.append("1、输入新的验证字符串；").append(session.newLine());
        message.append("2、选择其它验证方法；").append(session.newLine());
        message.append("3、更新正则表达式；").append(session.newLine());
        message.append("*、返回服务切换菜单；").append(session.newLine());
        session.send(message.toString());
        session.getProcess().setStep(0);
    }

    private void doInit(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        message.append(CharUtil.format("　　《{0}》服务支持目前较为常用的多个商用摘要算法，如MD5、SHA-1、SHA-256、SHA-512、RIPEMD-128、Tiger等！", getName())).append(session.newLine());
    }

    private void doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、输入正则表达式；").append(session.newLine());
        message.append("　　2、选择正则验证方法；").append(session.newLine());
        message.append("　　3、输入要验证的字符串；").append(session.newLine());
        message.append("　　有关正则表达式的详细信息，请访问：http://www.regexlab.com/zh/regref.htm");
    }

    private void doMenu(ISession session, StringBuffer message)
    {
        int c = hash.size();
        if (c > 10)
        {
            c = 10;
        }
        for (int i = 0; i < c; i += 1)
        {
            message.append(i).append('、').append(hash.get("" + i)).append(session.newLine());
        }
    }
}
