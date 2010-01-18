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
package rmp.irp.comn;

import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.util.HttpUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO:
 * <li>使用说明：</li>
 * <br />
 * TODO:
 * </ul>
 * 
 * @author Administrator
 * 
 */
public abstract class AContact implements IContact
{
    protected String code;

    /*
     * (non-Javadoc)
     * 
     * @see com.amonsoft.rmps.irp.b.IContact#getCode()
     */
    @Override
    public String getCode()
    {
        if (code == null)
        {
            try
            {
                code = HttpUtil.request("http://amonsoft.net/user/user0001.ashx?sid=" + getUser(), "GET", "UTF-8", null);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
            if (code == null)
            {
                code = "";
            }
        }
        return code;
    }
}
