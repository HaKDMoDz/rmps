/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.icq;

import com.amonsoft.rmps.irp.v.IConnect;

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
    private int port;
    private String server;

    @Override
    public boolean load()
    {
        this.user = "477730617";// 554448785
        this.pwds = "2PResMaI";// vjSY9EUY
        server = "login.oscar.aol.com";
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
        return "AmonCT@icqmail.com";
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
}
