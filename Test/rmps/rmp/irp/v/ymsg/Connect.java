/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.ymsg;

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

    public Connect()
    {
    }

    @Override
    public boolean load()
    {
        user = "Amon_CT";
        pwds = "fPEHrmQs";
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

    @Override
    public String getServer()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public int getPort()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
