/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.imp.v;

import com.amonsoft.rmps.imp.b.*;
import com.amonsoft.rmps.imp.*;
import com.amonsoft.rmps.imp.b.IContact;
import java.util.List;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface IAccount
{
    void exit();

    void sign(int status);

    IConnect getConnect();

    IContact getContact(String user);

    List<IContact> getContact();
}
