/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.gtalk;

import java.io.File;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.util.EnvUtil;

import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Connect implements IConnect
{
    private String user;
    private String pwds;
    private String host;
    private String server;
    private int port;
    private int priority = 10;

    public Connect()
    {
    }

    @Override
    public boolean load()
    {
        try
        {
            final String NAME = "gtalk";
            Document document = new SAXReader().read(new File(EnvUtil.getCfgPath(EnvCons.FOLDER1_IRP, NAME + ".xml")));
            Element element = (Element) document.selectSingleNode("/irps/" + NAME);
            host = ((Element) element.selectSingleNode("map[@key='host']")).getText();
            port = Integer.parseInt(((Element) element.selectSingleNode("map[@key='port']")).getText());
            server = ((Element) element.selectSingleNode("map[@key='server']")).getText();
            priority = Integer.parseInt(((Element) element.selectSingleNode("map[@key='priority']")).getText());
            user = ((Element) element.selectSingleNode("map[@key='user']")).getText();
            pwds = ((Element) element.selectSingleNode("map[@key='pwds']")).getText();
            return true;
        }
        catch (DocumentException exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    @Override
    public String getUser()
    {
        return user;
    }

    @Override
    public String getPwds()
    {
        return pwds;
    }

    @Override
    public String getMail()
    {
        return user;
    }

    /**
     * @return the host
     */
    @Override
    public String getHost()
    {
        return host;
    }

    /**
     * @param host
     *            the host to set
     */
    public void setHost(String host)
    {
        this.host = host;
    }

    /**
     * @return the server
     */
    @Override
    public String getServer()
    {
        return server;
    }

    /**
     * @param server
     *            the server to set
     */
    public void setServer(String server)
    {
        this.server = server;
    }

    /**
     * @return the port
     */
    @Override
    public int getPort()
    {
        return port;
    }

    /**
     * @param port
     *            the port to set
     */
    public void setPort(int port)
    {
        this.port = port;
    }

    /**
     * @return the priority
     */
    public int getPriority()
    {
        return priority;
    }

    /**
     * @param priority
     *            the priority to set
     */
    public void setPriority(int priority)
    {
        this.priority = priority;
    }
}
