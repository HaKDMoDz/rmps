/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I7020000;

import java.net.URL;
import java.util.HashMap;
import java.util.List;
import java.util.regex.Pattern;

import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.sun.syndication.feed.synd.SyndCategory;
import com.sun.syndication.feed.synd.SyndEntry;
import com.sun.syndication.feed.synd.SyndFeed;
import com.sun.syndication.io.SyndFeedInput;
import com.sun.syndication.io.XmlReader;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 在线阅读
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I7020000 implements IService
{
    private static Pattern ckPtn;
    private HashMap<String, String> rssList;

    @Override
    public boolean wInit()
    {
        rssList = new HashMap<String, String>(10);
        rssList.put("", "http://amonsoft.com/blog/feed.php");
        ckPtn = Pattern.compile("^\\*[\\d０１２３４５６７８９]?$");
        LogUtil.log(getName() + " 初始化成功！");
        return true;
    }

    @Override
    public String getCode()
    {
        return "57020000";
    }

    @Override
    public String getName()
    {
        return "RSS Reader";
    }

    @Override
    public String getDescription()
    {
        return "迷你RSS阅读器";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_COMMAND);
        session.send("欢迎使用RSS阅读器！");
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_COMMAND);
        session.send("请以星号（*）起始输入您要查看的RSS频道号码！");
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.trim();
        if (!ckPtn.matcher(tmp).matches())
        {
            doHelp(session, message);
            return;
        }

        // 显示RSS频道菜单列表
        if ("*".equals(tmp))
        {
            listRss(session, message);
            return;
        }

        // 用户选择了一个RSS频道
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        readRss(session, message, rssList.get(""));
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
        // 列表查看状态
        if (Constant.OPERATE_LIST.equals(session.getAttribute(Constant.OPERATE)))
        {
            listRss(session, message);
            return;
        }
        // 内容阅读状态
        if (Constant.OPERATE_READ.equals(session.getAttribute(Constant.OPERATE)))
        {
            listRss(session, message);
            return;
        }
        // 列表编辑状态
        if (Constant.OPERATE_EDIT.equals(session.getAttribute(Constant.OPERATE)))
        {
            readRss(session, message, rssList.get(""));
            return;
        }
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }

    /**
     * 显示RSS列表
     * 
     * @param session
     * @param message
     */
    private void listRss(ISession session, IMessage message)
    {
    }

    /**
     * 读取RSS信息
     * 
     * @param session
     * @param message
     */
    private void readRss(ISession session, IMessage message, String channel)
    {
        try
        {
            IProcess proc = session.getProcess();
            if (proc.getStep() < 0)
            {
                session.send("已是第一页！");
                return;
            }
            if (proc.getStep() >= proc.getMost())
            {
                session.send("已是最后一页！");
                return;
            }

            SyndFeed feed = new SyndFeedInput().build(new XmlReader(new URL(channel)));
            List<?> list = feed.getEntries();
            Object obj = list.get(proc.getStep());
            StringBuffer msg = new StringBuffer();
            if (obj instanceof SyndEntry)
            {
                SyndEntry item = (SyndEntry) obj;
                // 标题、连接地址、标题简介、时间是一个Rss源项最基本的组成部分
                msg.append("标题：").append(item.getTitle()).append(session.newLine());
                msg.append("作者：").append(item.getAuthor()).append(session.newLine());
                msg.append("发布日期：").append(item.getPublishedDate()).append(session.newLine());
                msg.append("类别划分：");
                for (Object obj2 : item.getCategories())
                {
                    if (obj2 instanceof SyndCategory)
                    {
                        msg.append(((SyndCategory) obj2).getName()).append('、');
                    }
                }
                msg.deleteCharAt(msg.length() - 1).append(session.newLine());
                msg.append("内容摘要：").append(item.getDescription().getValue()).append(session.newLine());
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }
}
