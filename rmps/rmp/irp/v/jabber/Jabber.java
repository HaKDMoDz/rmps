/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.jabber;

import rmp.irp.v.xmpp.XMPP;

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
public class Jabber extends XMPP
{
    @Override
    public IConnect getConnect()
    {
        if (connect == null)
        {
            connect = new Connect();
            connect.load();
        }
        return connect;
    }
}
