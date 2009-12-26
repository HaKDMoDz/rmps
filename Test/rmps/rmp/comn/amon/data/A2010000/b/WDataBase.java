/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.data.A2010000.b;

import rmp.util.StringUtil;
import cons.comn.amon.data.A2010000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class WDataBase
{
    /** JDBC数据库驱动 */
    private String driver = ConstUI.HSQLDB_DRV;
    /** 数据库连接地址 */
    private String url = StringUtil.format(ConstUI.HSQLDB_URL, "1000000/dat/amon");
    /** 数据库访问用户 */
    private String user = "";
    /** 数据库用户口令 */
    private String password = "";

    /**
     * @return the driver
     */
    public String getDriver()
    {
        return driver;
    }

    /**
     * @param driver
     *            the driver to set
     */
    public void setDriver(String driver)
    {
        this.driver = driver;
    }

    /**
     * @return the url
     */
    public String getUrl()
    {
        return url;
    }

    /**
     * @param url
     *            the url to set
     */
    public void setUrl(String url)
    {
        this.url = url;
    }

    /**
     * @return the user
     */
    public String getUser()
    {
        return user;
    }

    /**
     * @param user
     *            the user to set
     */
    public void setUser(String user)
    {
        this.user = user;
    }

    /**
     * @return the password
     */
    public String getPassword()
    {
        return password;
    }

    /**
     * @param password
     *            the password to set
     */
    public void setPassword(String password)
    {
        this.password = password;
    }
}
