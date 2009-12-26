/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import java.util.List;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.v.IAccount;

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
public abstract class AAccount implements IAccount
{
    @Override
    public abstract List<IContact> getContact();

    @Override
    public abstract IContact getContact(String user);
}
