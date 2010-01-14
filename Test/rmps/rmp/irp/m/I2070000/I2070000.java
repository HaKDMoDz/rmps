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
            if (!CharUtil.isValidateInteger(tmp))
            {
                doHelp(session, msg);
                session.send(msg.append("请选择您要进行的操作！").append(session.newLine()).toString());
                return;
            }

            pro.setStep(Integer.parseInt(tmp));
            switch (pro.getStep())
            {
                case Constant.STEP_SEARCH:
                    break;
                case Constant.STEP_SELECT:
                    break;
                case Constant.STEP_APPEND:
                    break;
                case Constant.STEP_REMOVE:
                    break;
                default:
                    doHelp(session, msg);
                    session.send(msg.append("请选择您要进行的操作！").append(session.newLine()).toString());
                    break;
            }
            return;
        }

        switch (pro.getStep())
        {
            case Constant.STEP_SEARCH:
                doSearch(session, msg);
                break;
            case Constant.STEP_SELECT:
                doSelect(session, msg);
                break;
            case Constant.STEP_APPEND:
                doAppend(session, msg);
                break;
            case Constant.STEP_REMOVE:
                doRemove(session, msg);
                break;
            default:
                break;
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

    private StringBuffer doSelect(ISession session, StringBuffer message)
    {
        try
        {
            String data = HttpUtil.request(path + CharUtil.format(args, "A0000000", Constant.OPT_SEARCH, ""), "GET", "UTF-8", null);
            Document doc = DocumentHelper.parseText(data);
            if (doc != null)
            {
                message.append("【类别】").append(session.newLine());
                List<K1SV1S> kindList = new ArrayList<K1SV1S>();
                for (Object obj : doc.selectNodes("/amonsoft/kind/item"))
                {
                    Element kind = (Element) obj;
                    kindList.add(new K1SV1S(kind.attributeValue("id"), kind.attributeValue("name")));
                }
                message.append("【链接】").append(session.newLine());
                List<K1SV2S> linkList = new ArrayList<K1SV2S>();
                for (Object obj : doc.selectNodes("/amonsoft/kind/item"))
                {
                    Element link = (Element) obj;
                    linkList.add(new K1SV2S(link.attributeValue("id"), link.attributeValue("name"), link.attributeValue("short")));
                }
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
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
