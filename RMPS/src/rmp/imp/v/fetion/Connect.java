/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.v.fetion;

import com.amonsoft.rmps.irp.v.IConnect;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Connect implements IConnect
{
    private String user;
    private String pwds;
    private String version;
    private String sysCfg;
    private String sipCfg;
    private String proxy;

    @Override
    public boolean load()
    {
        user = "13585709149";
        pwds = "ImkfYygyViq3721";
        setVersion("3.5.2540");
        setSysCfg("http://nav.fetion.com.cn/nav/getsystemconfig.aspx");
        setSipCfg("http://nav.m161.com.cn/Getconfig.aspx");
        return true;
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
        throw new UnsupportedOperationException("Not supported yet.");
    }

    /**
     * @return the sysCfg
     */
    public String getSysCfg()
    {
        return sysCfg;
    }

    /**
     * @param sysCfg the sysCfg to set
     */
    public void setSysCfg(String sysCfg)
    {
        this.sysCfg = sysCfg;
    }

    /**
     * @return the sipCfg
     */
    public String getSipCfg()
    {
        return sipCfg;
    }

    /**
     * @param sipCfg the sipCfg to set
     */
    public void setSipCfg(String sipCfg)
    {
        this.sipCfg = sipCfg;
    }

    /**
     * @return the proxy
     */
    public String getProxy()
    {
        return proxy;
    }

    /**
     * @param proxy the proxy to set
     */
    public void setProxy(String proxy)
    {
        this.proxy = proxy;
    }

    /**
     * @return the version
     */
    public String getVersion()
    {
        return version;
    }

    /**
     * @param version the version to set
     */
    public void setVersion(String version)
    {
        this.version = version;
    }
}
