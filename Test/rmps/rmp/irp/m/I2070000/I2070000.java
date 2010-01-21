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
import java.util.regex.Pattern;

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
        doMenu(session, msg.append(session.newLine()));
        // msg.append(session.newLine()).append("请输入对应的数字选择您要进行的功能。").append(session.newLine());

        session.getProcess().setType(IProcess.TYPE_NACTION | IProcess.TYPE_CONTENT);
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
    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.trim();
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();
        Profiles fav = (Profiles) session.getAttribute(getCode() + Constant.SESSION_PROFILES);

        try
        {
            // 功能菜单事件
            if (Constant.MENU_NONE != fav.showMenu)
            {
                tmp = Control.getCommand(tmp);
                if (tmp != null)
                {
                    // 显示服务列表菜单
                    if (ConsEnv.KEY_FUNC.equals(tmp))
                    {
                        if (pro.setFunc(".."))
                        {
                            Control.getService(pro.getFunc()).doInit(session, message);
                        }
                        return;
                    }

                    if (doDeal(session, msg, pro, fav, tmp))
                    {
                        session.send(msg.toString());
                        return;
                    }
                }
                tmp = txt.trim();
                fav.showMenu = Constant.MENU_NONE;
            }

            if (Constant.ITEM_SEARCH.equals(pro.getItem()))
            {
                // 执行数据查询
                if (doSearch(session, msg, pro, fav, tmp))
                {
                    doSearch(session, msg);
                }
                session.send(msg.toString());
                return;
            }
            if (Constant.ITEM_SELECT.equals(pro.getItem()))
            {
                // 数据新增
                if (Constant.EDIT_APPEND_LINK == fav.dataEdit)
                {
                    if (doAppend(session, msg, pro, fav, tmp))
                    {
                        doAppend(session, msg);
                    }
                    session.send(msg.toString());
                    return;
                }
                // 数据删除
                if (Constant.EDIT_DELETE == fav.dataEdit)
                {
                    doRemove(session, msg);
                    return;
                }
                // 数据查看
                if (Constant.EDIT_DETAIL == fav.dataEdit)
                {
                    if (doDetail(session, msg, pro, fav, tmp))
                    {
                        doDetail(session, msg);
                    }
                    session.send(msg.toString());
                    return;
                }

                tmp = Control.getCommand(tmp);
                if (tmp != null)
                {
                    if (Pattern.matches("\\.\\./?", tmp))
                    {
                        tmp = fav.pathList.pop();
                    }
                    else
                    {
                        session.send(msg.append("请输入对应的数字选择下级类别！").append(session.newLine()).toString());
                        return;
                    }
                }
                if (doSelect(session, msg, pro, fav, tmp))
                {
                    doSelect(session, msg);
                    Control.appendPage(session, msg);
                }
                session.send(msg.toString());
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
        Profiles fav = (Profiles) session.getAttribute(getCode() + Constant.SESSION_PROFILES);
        if (fav == null)
        {
            fav = new Profiles();
            session.setAttribute(getCode() + Constant.SESSION_PROFILES, fav);
        }
        String item = session.getProcess().getItem();
        if (IProcess.ITEM_DEFAULT.equals(item))
        {
            message.append("请输入对应的数字选择您要进行的功能。").append(session.newLine());
            message.append("0、搜索模式；").append(session.newLine());
            message.append("1、目录模式；").append(session.newLine());
            message.append("*、返回服务列表；").append(session.newLine());
            fav.showMenu = Constant.MENU_MODE;
            return message;
        }
        if (Constant.ITEM_SEARCH.equals(item))
        {
            message.append("0、进入目录模式；").append(session.newLine());
            message.append("*、返回服务列表；").append(session.newLine());
            fav.showMenu = Constant.MENU_SRCH;
            return message;
        }
        if (Constant.ITEM_SELECT.equals(item))
        {
            message.append("0、进入搜索模式；").append(session.newLine());
            message.append("1、添加链接数据；").append(session.newLine());
            message.append("2、添加类别数据；").append(session.newLine());
            message.append("*、返回服务列表；").append(session.newLine());
            message.append("其它任意键继续当前服务；").append(session.newLine());
            fav.showMenu = Constant.MENU_LIST;
            return message;
        }
        if (Constant.EDIT_DETAIL == fav.dataEdit)
        {
            message.append("0、更新链接数据；").append(session.newLine());
            message.append("1、删除链接数据；").append(session.newLine());
            message.append("2、管理链接数据；").append(session.newLine());
            message.append("*、返回服务列表；").append(session.newLine());
            message.append("其它任意键继续当前服务；").append(session.newLine());
            fav.showMenu = Constant.MENU_EIDT;
            return message;
        }
        return message;
    }

    private boolean doDeal(ISession session, StringBuffer message, IProcess pro, Profiles fav, String tmp) throws Exception
    {
        // 当前显示为模式切换菜单
        if (Constant.MENU_MODE == fav.showMenu)
        {
            // 进入搜索模式
            if ("0".equals(tmp))
            {
                pro.setItem(Constant.ITEM_SEARCH);
                pro.setStep(IProcess.STEP_DEFAULT);
                if (fav.itemList != null)
                {
                    fav.itemList.clear();
                }
                fav.showMenu = Constant.MENU_NONE;
                message.append("请输入您要查询的内容！").append(session.newLine());
                return true;
            }
            // 进入目录模式
            if ("1".equals(tmp))
            {
                pro.setItem(Constant.ITEM_SELECT);
                pro.setStep(IProcess.STEP_DEFAULT);
                fav.showMenu = Constant.MENU_NONE;
                doSelect(session, message);
                return true;
            }

            // 其它输入，进行当前操作
            return false;
        }
        if (Constant.MENU_SRCH == fav.showMenu)
        {
            if ("0".equals(tmp))
            {
                pro.setItem(Constant.ITEM_SELECT);
                pro.setStep(IProcess.STEP_DEFAULT);
                fav.showMenu = Constant.MENU_NONE;
                if (fav.kindList == null && doSelect(session, message, pro, fav, tmp))
                {
                    doSelect(session, message);
                }
                return true;
            }
            // 其它输入，进行当前操作
            return false;
        }
        // 当前显示为数据列表菜单
        if (Constant.MENU_LIST == fav.showMenu)
        {
            if ("0".equals(tmp))
            {
                pro.setItem(Constant.ITEM_SEARCH);
                pro.setStep(IProcess.STEP_DEFAULT);
                fav.itemList.clear();
                fav.showMenu = Constant.MENU_NONE;
                message.append("请输入您要查询的内容！").append(session.newLine());
                return true;
            }
            // 用户选择进入添加类别事件
            if ("1".equals(tmp))
            {
                fav.dataEdit = Constant.EDIT_APPEND_KIND;
            }
            // 用户选择进入添加链接事件
            else if ("2".equals(tmp))
            {
                fav.dataEdit = Constant.EDIT_APPEND_LINK;
                message.append("请输入链接地址！").append(session.newLine());
                fav.showMenu = Constant.MENU_NONE;
                return true;
            }

            // 其它输入，进行当前操作
            return false;
        }
        // 当前显示为详细信息菜单
        if (Constant.MENU_EIDT == fav.showMenu)
        {
            // 用户选择进入数据更新模式
            if (Constant.EDIT_UPDATE == fav.dataEdit)
            {
                return true;
            }
            // 其它输入，进行当前操作
            return false;
        }
        return false;
    }

    private boolean doSearch(ISession session, StringBuffer message, IProcess pro, Profiles fav, String tmp) throws Exception
    {
        // 输入数据为空检测
        if (!CharUtil.isValidate(tmp))
        {
            return false;
        }

        String data = HttpUtil.request(path + '?' + CharUtil.format(args, session.getContact().getCode(), Constant.OPT_SEARCH, tmp), "GET", "UTF-8", null);
        Document doc = DocumentHelper.parseText(data);
        if (doc != null)
        {
            if (fav.itemList != null)
            {
                fav.itemList.clear();
            }
            else
            {
                fav.itemList = new ArrayList<K1SV3S>();
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
                fav.itemList.add(item);
            }

            pro.setStep(IProcess.STEP_DEFAULT);
            pro.setMost(fav.itemList.size() / 10 + 1);
        }
        return true;
    }

    private StringBuffer doSearch(ISession session, StringBuffer message)
    {
        try
        {
            IProcess pro = session.getProcess();
            Profiles fav = (Profiles) session.getAttribute(getCode() + Constant.SESSION_PROFILES);
            if (fav.itemList == null)
            {
                return message;
            }
            int i = pro.getStep();
            // 判断是否为第一页
            if (i <= -1)
            {
                session.send(message.append("已是第一页！").append(session.newLine()).toString());
                return message;
            }
            // 判断是否为最后一页
            if (i >= pro.getMost())
            {
                session.send(message.append("已是最后一页！").append(session.newLine()).toString());
                return message;
            }
            int s = i * 10;
            int e = s + 10;
            if (e >= fav.itemList.size())
            {
                e = fav.itemList.size();
            }
            i = 0;
            while (s < e)
            {
                K1SV3S item = (K1SV3S) fav.itemList.get(s++);
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

    /**
     * 目录模式：数据输入合法性判断
     * 
     * @param session
     * @param message
     * @param pro
     * @param fav
     * @param tmp
     * @return
     * @throws Exception
     */
    private boolean doSelect(ISession session, StringBuffer message, IProcess pro, Profiles fav, String tmp) throws Exception
    {
        // 判断输入数值是否越界
        String uri = "";
        if (fav.kindList != null)
        {
            // 判断输入字符合法性
            if (!CharUtil.isValidateInteger(tmp))
            {
                message.append("请输入对应的数字选择下级类别！").append(session.newLine());
                return false;
            }

            int idx = pro.getStep() * 10 + Integer.parseInt(tmp);
            if (idx < 0 || idx >= fav.kindList.size())
            {
                message.append("请输入对应的数字选择下级类别！").append(session.newLine());
                return false;
            }
            uri = fav.kindList.get(idx).getK();
        }
        fav.pathList.push(uri);

        String data = HttpUtil.request(path + '?' + CharUtil.format(args, session.getContact().getCode(), Constant.OPT_SELECT, uri), "GET", "UTF-8", null);
        Document doc = DocumentHelper.parseText(data);
        if (doc != null)
        {
            // 读取类别信息
            if (fav.kindList == null)
            {
                fav.kindList = new ArrayList<K1SV1S>();
            }
            else
            {
                fav.kindList.clear();
            }

            for (Object obj : doc.selectNodes("/amonsoft/kind/item"))
            {
                Element kind = (Element) obj;
                fav.kindList.add(new K1SV1S(kind.attributeValue("id"), kind.attributeValue("name")));
            }

            // 读取链接信息
            if (fav.linkList == null)
            {
                fav.linkList = new ArrayList<K1SV2S>();
            }
            else
            {
                fav.linkList.clear();
            }
            for (Object obj : doc.selectNodes("/amonsoft/link/item"))
            {
                Element link = (Element) obj;
                fav.linkList.add(new K1SV2S(link.attributeValue("id"), link.attributeValue("name"), link.attributeValue("short")));
            }

            pro.setStep(IProcess.STEP_DEFAULT);
            pro.setMost((fav.kindList.size() + fav.linkList.size()) / 10 + 1);
        }
        return true;
    }

    private StringBuffer doSelect(ISession session, StringBuffer message)
    {
        IProcess pro = session.getProcess();
        Profiles fav = (Profiles) session.getAttribute(getCode() + Constant.SESSION_PROFILES);
        int step = pro.getStep();
        if (step > pro.getStep())
        {
            return message;
        }

        int l1 = fav.kindList.size();
        int l2 = fav.linkList.size();
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
                item = fav.kindList.get(s1++);
                message.append(t++).append('、').append(item.getV1()).append(session.newLine());
            }
        }
        if (s2 > 0 && s2 < e2)
        {
            message.append(CharUtil.format("【链接】（{0}）", l2)).append(session.newLine());
            K1SV2S item;
            while (s2 < e2)
            {
                item = fav.linkList.get(s2++);
                message.append(item.getV1()).append(item.getV2()).append(session.newLine());
            }
        }
        return message.append("请输入对应的数字选择您要进行的操作！");
    }

    private boolean doDetail(ISession session, StringBuffer message, IProcess pro, Profiles fav, String tmp) throws Exception
    {
        String uri = "";
        String data = HttpUtil.request(path + '?' + CharUtil.format(args, session.getContact().getCode(), Constant.OPT_DETAIL, uri), "GET", "UTF-8", null);
        return true;
    }

    private StringBuffer doDetail(ISession session, StringBuffer message)
    {
        return message;
    }

    private boolean doAppend(ISession session, StringBuffer message, IProcess pro, Profiles fav, String tmp)
    {
        if (session.getProcess().getStep() == Constant.STEP_APPEND_LINK)
        {
            if (!CharUtil.isValidateUri(tmp))
            {
                message.append("您输入的不是一个合适的链接地址，请重新输入！").append(session.newLine());
                return false;
            }
            pro.setStep(Constant.STEP_APPEND_NAME);
            session.setAttribute(getCode() + Constant.SESSION_LINKPATH_K, tmp);
            message.append("请输入链接名称！").append(session.newLine());
            return false;
        }
        if (pro.getStep() == Constant.STEP_APPEND_NAME)
        {
            if (!CharUtil.isValidate(tmp))
            {
                message.append("请输入链接名称！").append(session.newLine());
                return false;
            }
            session.setAttribute(getCode() + Constant.SESSION_LINKNAME_K, tmp);
        }
        return true;
    }

    private StringBuffer doAppend(ISession session, StringBuffer message)
    {
        try
        {
            Profiles fav = (Profiles) session.getAttribute(getCode() + Constant.SESSION_PROFILES);
            String uri = fav.pathList.peek();

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
            map.put("sid", session.getContact().getCode());
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
            HttpUtil.request(path + CharUtil.format(args, session.getContact().getCode(), Constant.OPT_SEARCH, ""), "POST", "UTF-8", null);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return message;
    }
}
