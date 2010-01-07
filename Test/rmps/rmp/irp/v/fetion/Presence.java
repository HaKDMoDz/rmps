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
package rmp.irp.v.fetion;

import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.util.CharUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Administrator
 * 
 */
public class Presence implements IPresence
{
    /**
     * 内部状态编码
     */
    private int asc;
    /**
     * 特定IM状态编码
     */
    private String imc;
    /**
     * 用户状态信息
     */
    private String msg;
    /**
     * 飞信特有短信状态
     */
    private int fsc;

    public Presence()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IPresence#getAsc()
     */
    @Override
    public int getAsc()
    {
        return asc;
    }

    /**
     * @param asc
     */
    public void setAsc(int asc)
    {
        this.asc = asc;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IPresence#getImc()
     */
    @Override
    public String getImc()
    {
        return imc;
    }

    /**
     * @param imc
     */
    public void setImc(String imc)
    {
        this.imc = imc;
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IPresence#getMessage()
     */
    @Override
    public String getMessage()
    {
        if (!CharUtil.isValidate(msg))
        {
            if ("400".equals(imc))
            {
                return "Active";
            }
            if ("0".equals(imc))
            {
                return fsc == 200 ? "SMS-Online" : "Offline";
            }
            if ("100".equals(imc))
            {
                return "Away";
            }
            if ("150".equals(imc))
            {
                return "At Lunch";
            }
            if ("300".equals(imc))
            {
                return "Be Right Back";
            }
            if ("500".equals(imc))
            {
                return "In Call";
            }
            if ("600".equals(imc))
            {
                return "Busy";
            }
        }
        return msg;
    }

    /**
     * @param message
     */
    public void setMessage(String message)
    {
        this.msg = message;
    }

    public void setFsc(String fsc)
    {
        this.fsc = Integer.parseInt(fsc);
    }
}
