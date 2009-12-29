/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

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

    public Connect()
    {
    }

    @Override
    public boolean load()
    {
        try
        {
            final String NAME = "live";
            Document document = new SAXReader().read(new File(EnvUtil.getCfgPath(EnvCons.FOLDER1_IRP, NAME + ".xml")));
            Element element = (Element) document.selectSingleNode("/irps/" + NAME);
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
        return "";
    }

    /**
     * @param host
     *            the host to set
     */
    public void setHost(String host)
    {
    }

    @Override
    public String getServer()
    {
        return "";
    }

    @Override
    public int getPort()
    {
        return 0;
    }
}
