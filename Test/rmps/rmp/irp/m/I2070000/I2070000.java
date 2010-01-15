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
package rmp.irp.m.I2070000;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.bean.K1SV1S;
import rmp.bean.K1SV2S;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 网络导航
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 * 
 */
public class I2070000 implements IService
{
    private static String path;
    private static String args;

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#wInit()
     */
    @Override
    public boolean wInit()
    {
        try
        {
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element root = (Element) document.selectSingleNode("/irps/" + getCode());
            Element element = (Element) root.selectSingleNode("item[@id='配置']/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) root.selectSingleNode("item[@id='配置']/map[@key='args']");
            if (element != null)
            {
                args = element.getText();
            }
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getCode()
     */
    @Override
    public String getCode()
    {
        return "I2070000";
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getName()
     */
    @Override
    public String getName()
    {
        return "网络导航";
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getDescription()
     */
    @Override
    public String getDescription()
    {
        return "网络导航";
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.m.IService#getHelpTips()
     */
    @Override
    public List<K1SV1S> getHelpTips()
    {
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doHelp(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doInit(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer(session.newLine());
        doInit(session, msg);
        doHelp(session, msg.append(session.newLine()));
        msg.append(session.newLine()).append("请输入对应的数字选择您要进行的功能。").append(session.newLine());

        session.getProcess().setType(IProcess.TYPE_CONTENT);
        session.getProcess().setItem(IProcess.ITEM_DEFAULT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doMenu(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doDeal(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.trim();
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();

        // 功能选择事件
        if (IProcess.STEP_DEFAULT == pro.getStep())
        {
            if (!pro.setItem(tmp))
            {
                doHelp(session, msg);
                session.send(msg.append("请选择您要进行的操作！").append(session.newLine()).toString());
                return;
            }

            if (Constant.ITEM_SEARCH.equals(pro.getItem()))
            {
                return;
            }
            if (Constant.ITEM_APPEND.equals(pro.getItem()))
            {
                return;
            }
            if (Constant.ITEM_REMOVE.equals(pro.getItem()))
            {
                return;
            }
            if (!Constant.ITEM_SELECT.equals(pro.getItem()))
            {
                doHelp(session, msg);
                session.send(msg.append("请选择您要进行的操作！").append(session.newLine()).toString());
                return;
            }
        }

        try
        {
            if (Constant.ITEM_SEARCH.equals(pro.getItem()))
            {
                doSearch(session, msg);
                return;
            }
            if (Constant.ITEM_SELECT.equals(pro.getItem()))
            {
                String data = HttpUtil.request(path + '?' + CharUtil.format(args, "A0000000", Constant.OPT_SELECT, ""), "GET", "UTF-8", null);
                Document doc = DocumentHelper.parseText(data);
                if (doc != null)
                {
                    List<K1SV1S> kindList = new ArrayList<K1SV1S>();
                    for (Object obj : doc.selectNodes("/amonsoft/kind/item"))
                    {
                        Element kind = (Element) obj;
                        kindList.add(new K1SV1S(kind.attributeValue("id"), kind.attributeValue("name")));
                    }
                    session.setAttribute(getCode() + Constant.SESSION_KINDLIST, kindList);

                    List<K1SV2S> linkList = new ArrayList<K1SV2S>();
                    for (Object obj : doc.selectNodes("/amonsoft/link/item"))
                    {
                        Element link = (Element) obj;
                        linkList.add(new K1SV2S(link.attributeValue("id"), link.attributeValue("name"), link.attributeValue("short")));
                    }
                    session.setAttribute(getCode() + Constant.SESSION_LINKLIST, linkList);
                }
                doSelect(session, msg);
                return;
            }
            if (Constant.ITEM_APPEND.equals(pro.getItem()))
            {
                doAppend(session, msg);
                return;
            }
            if (Constant.ITEM_REMOVE.equals(pro.getItem()))
            {
                doRemove(session, msg);
                return;
            }

            doHelp(session, msg);
            session.send(msg.append("请选择您要进行的操作！").append(session.newLine()).toString());
            return;
        }
        catch (Exception exp)
        {
            session.send(msg.append(exp.getMessage()).append(session.newLine()).toString());
        }
        session.send(msg.toString());
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doStep(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doExit(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doRoot(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }

    private StringBuffer doInit(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        message.append(CharUtil.format("　　《{0}》服务目前支持网址收藏及短域名服务！", getName())).append(session.newLine());
        return message;
    }

    private StringBuffer doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、快速搜索您的网络收藏；").append(session.newLine());
        message.append("　　2、递进查找您的网络收藏；").append(session.newLine());
        message.append("　　3、添加或修改您的网络收藏；").append(session.newLine());
        return message;
    }

    private StringBuffer doSearch(ISession session, StringBuffer message)
    {
        try
        {
            String data = HttpUtil.request(path + CharUtil.format(args, "A0000000", Constant.OPT_SEARCH, ""), "GET", "UTF-8", null);
            Document doc = DocumentHelper.parseText(data);
            if (doc != null)
            {

            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return message;
    }

    @SuppressWarnings("unchecked")
    private StringBuffer doSelect(ISession session, StringBuffer message)
    {
        IProcess pro = session.getProcess();
        int step = pro.getStep();
        if (step > pro.getStep())
        {
            return message;
        }

        List<K1SV1S> kind = (List<K1SV1S>) session.getAttribute(getCode() + Constant.SESSION_KINDLIST);
        List<K1SV2S> link = (List<K1SV2S>) session.getAttribute(getCode() + Constant.SESSION_LINKLIST);
        int l1 = kind.size();
        int l2 = link.size();
        int s1 = step * 10;
        int e1 = s1 + 10;
        int s2 = e1 - l1;
        int e2 = s2;
        if (e1 > l1)
        {
            e1 = l1;
        }
        if (e2 > l2)
        {
            e2 = l2;
        }

        // 仅显示类别
        if (s1 < e1)
        {
            int t = 0;
            message.append(CharUtil.format("【类别】（{0}）", l1)).append(session.newLine());
            K1SV1S item;
            while (s1 < e1)
            {
                item = kind.get(s1++);
                message.append(t++).append('、').append(item.getV()).append(session.newLine());
            }
        }
        if (s2 > 0 && s2 < e2)
        {
            message.append(CharUtil.format("【链接】（{0}）", l2)).append(session.newLine());
            K1SV2S item;
            while (s2 < e2)
            {
                item = link.get(s2++);
                message.append(item.getV1()).append(item.getV2()).append(session.newLine());
            }
        }
        return message;
    }

    private StringBuffer doAppend(ISession session, StringBuffer message)
    {
        try
        {
            HttpUtil.request(path + CharUtil.format(args, "A0000000", Constant.OPT_SEARCH, ""), "POST", "UTF-8", null);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return message;
    }

    private StringBuffer doRemove(ISession session, StringBuffer message)
    {
        try
        {
            HttpUtil.request(path + CharUtil.format(args, "A0000000", Constant.OPT_SEARCH, ""), "POST", "UTF-8", null);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return message;
    }
}
