/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp._comn;

import com.amonsoft.rmps.imp.v.IAccount;
import com.amonsoft.rmps.imp.b.IContact;
import java.util.List;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public abstract class AAccount implements IAccount
{
    @Override
    public abstract List<IContact> getContact();

    @Override
    public abstract IContact getContact(String user);
}
