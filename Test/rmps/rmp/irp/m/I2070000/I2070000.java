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
import java.util.HashMap;
import java.util.List;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.bean.K1SV1S;
import rmp.bean.K1SV2S;
import rmp.bean.K1SV3S;
import rmp.irp.c.Control;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;
import com.amonsoft.util.HttpUtil;

import cons.EnvCons;
import cons.irp.ConsEnv;

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

        session.setAttribute(getCode() + Constant.SESSION_KINDLIST_K, new ArrayList<K1SV1S>());
        session.setAttribute(getCode() + Constant.SESSION_LINKLIST_K, new ArrayList<K1SV2S>());

        session.getProcess().setType(IProcess.TYPE_NACTION | IProcess.TYPE_CONTENT);
        session.getProcess().setItem(IProcess.ITEM_DEFAULT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
        session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, null);
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
        StringBuffer msg = new StringBuffer(session.newLine());
        doMenu(session, msg);
        session.send(msg.toString());
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.amonsoft.rmps.irp.m.IService#doDeal(com.amonsoft.rmps.irp.b.ISession,
     * com.amonsoft.rmps.irp.b.IMessage)
     */
    @SuppressWarnings("unchecked")
    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.trim();
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();

        // 功能菜单事件
        String menu = (String) session.getAttribute(getCode() + Constant.SESSION_SHOWMENU);
        if (menu != null)
        {
            // 记录用户选择
            if (Constant.SESSION_MENU_SUB.equals(menu))
            {
                // 用户选择进入模式切换
                if ("0".equals(tmp))
                {
                    // 进入搜索模式
                    if (Constant.ITEM_SELECT.equals(pro.getItem()))
                    {
                        pro.setItem(Constant.ITEM_SEARCH);
                        pro.setStep(IProcess.STEP_DEFAULT);
                        session.send(msg.append("请输入您要查询的内容！").append(session.newLine()).toString());
                        session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, null);
                        return;
                    }
                    // 进入目录模式
                    else
                    {
                        doHelp(session, msg);
                        pro.setItem(Constant.ITEM_SELECT);
                        pro.setStep(IProcess.STEP_DEFAULT);
                        session.send(msg.append("请选择您要进行的操作！").append(session.newLine()).toString());
                    }
                    session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, null);
                }
                // 用户选择进入添加类别事件
                else if ("1".equals(tmp))
                {
                    session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, null);
                }
                // 用户选择进入添加链接事件
                else if ("2".equals(tmp))
                {
                    pro.setStep(Constant.STEP_APPEND_LINK);
                    session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, null);
                    session.send(msg.append("请输入链接地址！").append(session.newLine()).toString());
                    return;
                }
                else if (ConsEnv.KEY_FUNC.equals(tmp))
                {
                    if (pro.setFunc(".."))
                    {
                        Control.getService(pro.getFunc()).doInit(session, message);
                    }
                    return;
                }
                // 其它输入，进行当前操作
                pro.setType(IProcess.TYPE_NACTION | IProcess.TYPE_COMMAND | IProcess.TYPE_CONTENT);
                pro.setStep(IProcess.STEP_DEFAULT);
            }
            else if (Constant.SESSION_MENU_MGR.equals(menu))
            {
                // 用户选择进入数据更新模式
                if (Constant.ITEM_UPDATE.equals(pro.getItem()))
                {
                    return;
                }
            }
        }
        // 用户首次进入
        else
        {
            if (IProcess.ITEM_DEFAULT.equals(pro.getItem()))
            {
                // 进入搜索模式
                if ("0".equals(tmp))
                {
                    pro.setItem(Constant.ITEM_SEARCH);
                    pro.setStep(IProcess.STEP_DEFAULT);
                    session.send(msg.append("请输入您的查询条件！").append(session.newLine()).toString());
                    session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, null);
                    return;
                }
                // 返回服务菜单
                if (ConsEnv.KEY_FUNC.equals(tmp))
                {
                    if (pro.setFunc(".."))
                    {
                        Control.getService(pro.getFunc()).doInit(session, message);
                    }
                    return;
                }
                // 容错处理
                if (!"1".equals(tmp))
                {
                    doHelp(session, msg);
                    session.send(msg.toString());
                    return;
                }
                // 进入目录模式
                pro.setItem(Constant.ITEM_SELECT);
                pro.setStep(IProcess.STEP_DEFAULT);
            }
            // 显示操作菜单
            else if (ConsEnv.KEY_MENU.equals(tmp))
            {
                doHelp(session, msg);
                session.send(msg.toString());
                return;
            }
        }

        try
        {
            if (Constant.ITEM_SEARCH.equals(pro.getItem()))
            {
                if (!CharUtil.isValidate(tmp))
                {
                    return;
                }
                String data = HttpUtil.request(path + '?' + CharUtil.format(args, "A0000000", Constant.OPT_SEARCH, tmp), "GET", "UTF-8", null);
                Document doc = DocumentHelper.parseText(data);
                if (doc != null)
                {
                    ArrayList<K1SV3S> itemList = (ArrayList<K1SV3S>) session.getAttribute(getCode() + Constant.SESSION_ITEMLIST_K);
                    if (itemList != null)
                    {
                        itemList.clear();
                    }
                    else
                    {
                        itemList = new ArrayList<K1SV3S>();
                        session.setAttribute(getCode() + Constant.SESSION_ITEMLIST_K, itemList);
                    }
                    Element node;
                    Element kind;
                    Element link;
                    K1SV3S item;
                    for (Object obj : doc.selectNodes("/amonsoft/item"))
                    {
                        node = (Element) obj;
                        kind = node.element("kind");
                        link = node.element("link");
                        item = new K1SV3S();
                        item.setK(kind.attributeValue("id") + ',' + link.attributeValue("id"));
                        item.setV1(kind.attributeValue("name"));
                        item.setV2(link.attributeValue("name"));
                        item.setV3(link.attributeValue("short"));
                        itemList.add(item);
                    }
                }
                doSearch(session, msg);
                session.send(msg.toString());
                return;
            }
            if (Constant.ITEM_SELECT.equals(pro.getItem()))
            {
                tmp = Control.getCommand(tmp);
                // 判断输入字符合法性
                if (!CharUtil.isValidateInteger(tmp))
                {
                    session.send(msg.append("请输入对应的数字选择下级类别！").append(session.newLine()).toString());
                    return;
                }

                // 判断输入数值是否越界
                int idx = pro.getStep() * 10 + Integer.parseInt(tmp);
                List<K1SV1S> kindList = (List<K1SV1S>) session.getAttribute(getCode() + Constant.SESSION_KINDLIST_K);
                String uri = "";
                if (kindList.size() != 0)
                {
                    if (idx < 0 || idx >= kindList.size())
                    {
                        session.send(msg.append("请输入对应的数字选择下级类别！").append(session.newLine()).toString());
                        return;
                    }
                    uri = kindList.get(idx).getK();
                }
                session.setAttribute(getCode() + Constant.SESSION_KINDHASH_K, uri);

                String data = HttpUtil.request(path + '?' + CharUtil.format(args, "A0000000", Constant.OPT_SELECT, uri), "GET", "UTF-8", null);
                Document doc = DocumentHelper.parseText(data);
                if (doc != null)
                {
                    kindList.clear();
                    for (Object obj : doc.selectNodes("/amonsoft/kind/item"))
                    {
                        Element kind = (Element) obj;
                        kindList.add(new K1SV1S(kind.attributeValue("id"), kind.attributeValue("name")));
                    }
                    session.setAttribute(getCode() + Constant.SESSION_KINDLIST_K, kindList);

                    List<K1SV2S> linkList = (List<K1SV2S>) session.getAttribute(getCode() + Constant.SESSION_LINKLIST_K);
                    linkList.clear();
                    for (Object obj : doc.selectNodes("/amonsoft/link/item"))
                    {
                        Element link = (Element) obj;
                        linkList.add(new K1SV2S(link.attributeValue("id"), link.attributeValue("name"), link.attributeValue("short")));
                    }
                    session.setAttribute(getCode() + Constant.SESSION_LINKLIST_K, linkList);

                    pro.setStep(IProcess.STEP_DEFAULT);
                    pro.setMost((kindList.size() + linkList.size()) / 10 + 1);
                }
                doSelect(session, msg);
                Control.appendPage(session, msg);
                session.send(msg.toString());
                return;
            }
            if (Constant.ITEM_APPEND.equals(pro.getItem()))
            {
                if (pro.getStep() == Constant.STEP_APPEND_LINK)
                {
                    if (!CharUtil.isValidateUri(tmp))
                    {
                        session.send(msg.append("您输入的不是一个合适的链接地址，请重新输入！").append(session.newLine()).toString());
                        return;
                    }
                    pro.setStep(Constant.STEP_APPEND_NAME);
                    session.setAttribute(getCode() + Constant.SESSION_LINKPATH_K, tmp);
                    session.send(msg.append("请输入链接名称！").append(session.newLine()).toString());
                    return;
                }
                if (pro.getStep() == Constant.STEP_APPEND_NAME)
                {
                    if (!CharUtil.isValidate(tmp))
                    {
                        session.send(msg.append("请输入链接名称！").append(session.newLine()).toString());
                        return;
                    }
                    session.setAttribute(getCode() + Constant.SESSION_LINKNAME_K, tmp);
                }

                doAppend(session, msg);
                return;
            }
            if (Constant.ITEM_UPDATE.equals(pro.getItem()))
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
        StringBuffer msg = new StringBuffer(session.newLine());
        doSelect(session, msg);
        session.send(msg.toString());
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
        message.append("　　0、快速搜索您的网络收藏；").append(session.newLine());
        message.append("　　1、递进查找您的网络收藏；").append(session.newLine());
        return message;
    }

    private StringBuffer doMenu(ISession session, StringBuffer message)
    {
        String item = session.getProcess().getItem();
        if (Constant.ITEM_SEARCH.equals(item))
        {
            message.append("0、进入目录模式；").append(session.newLine());
            message.append("*、返回服务列表；").append(session.newLine());
            session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, Constant.SESSION_MENU_SUB);
            return message;
        }
        if (Constant.ITEM_SELECT.equals(item))
        {
            message.append("0、进入搜索模式；").append(session.newLine());
            message.append("1、添加链接数据；").append(session.newLine());
            message.append("2、添加类别数据；").append(session.newLine());
            message.append("*、返回服务列表；").append(session.newLine());
            message.append("其它任意键继续当前服务；").append(session.newLine());
            session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, Constant.SESSION_MENU_SUB);
            return message;
        }
        if (Constant.ITEM_UPDATE.equals(""))
        {
            message.append("0、更新链接数据；").append(session.newLine());
            message.append("1、删除链接数据；").append(session.newLine());
            message.append("2、复制链接数据；").append(session.newLine());
            message.append("3、删除链接数据；").append(session.newLine());
            session.setAttribute(getCode() + Constant.SESSION_SHOWMENU, Constant.SESSION_MENU_MGR);
            return message;
        }
        return message;
    }

    private StringBuffer doSearch(ISession session, StringBuffer message)
    {
        try
        {
            ArrayList<?> itemList = (ArrayList<?>) session.getAttribute(getCode() + Constant.SESSION_ITEMLIST_K);
            if (itemList == null)
            {
                return message;
            }
            int i = session.getProcess().getStep();
            // 判断是否为第一页
            if (i <= -1)
            {
                session.send(message.append("已是第一页！").append(session.newLine()).toString());
                return message;
            }
            // 判断是否为最后一页
            if (i >= session.getProcess().getMost())
            {
                session.send(message.append("已是最后一页！").append(session.newLine()).toString());
                return message;
            }
            int s = i * 10;
            int e = s + 10;
            if (e >= itemList.size())
            {
                e = itemList.size();
            }
            i = 0;
            while (s < e)
            {
                K1SV3S item = (K1SV3S) itemList.get(s++);
                message.append(i++).append("、〖").append(item.getV1()).append("〗").append(session.newLine());
                message.append("快捷地址：http://amonsoft.net/?/").append(item.getV2()).append(session.newLine());
                message.append("链接名称：").append(item.getV3()).append(session.newLine());
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

        List<K1SV1S> kind = (List<K1SV1S>) session.getAttribute(getCode() + Constant.SESSION_KINDLIST_K);
        List<K1SV2S> link = (List<K1SV2S>) session.getAttribute(getCode() + Constant.SESSION_LINKLIST_K);
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
                message.append(t++).append('、').append(item.getV1()).append(session.newLine());
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
            String uri = (String) session.getAttribute(getCode() + Constant.SESSION_KINDHASH_K);

            // 生成XML文档
            Document doc = DocumentHelper.createDocument();
            Element root = doc.addElement("amonsoft").addElement("item");

            // 判断是否需要添加类别
            String tmp = (String) session.getAttribute(getCode() + Constant.SESSION_KINDNAME_K);
            if (CharUtil.isValidate(tmp))
            {
                Element kind = root.addElement("kind");
                kind.addAttribute("uri", uri);
                kind.addAttribute("name", tmp);
            }

            // 判断是否需要添加链接
            tmp = (String) session.getAttribute(getCode() + Constant.SESSION_LINKPATH_K);
            if (CharUtil.isValidate(tmp))
            {
                Element link = root.addElement("link");
                link.addAttribute("uri", uri);
                link.addAttribute("name", tmp);
                link.addAttribute("path", (String) session.getAttribute(getCode() + Constant.SESSION_LINKNAME_K));
            }

            // POST参数
            HashMap<String, String> map = new HashMap<String, String>();
            map.put("sid", "A0000000");
            map.put("opt", "a");
            map.put("uri", doc.asXML());

            String data = HttpUtil.request(path, "POST", "utf-8", map);
            System.out.println(data);
            session.getProcess().setStep(Constant.STEP_APPEND_LINK);
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
