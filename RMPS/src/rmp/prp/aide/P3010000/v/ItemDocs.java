/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.v;

import java.util.EventObject;

import rmp.face.WBackCall;
import rmp.prp.aide.P3010000.i.WItem;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class ItemDocs extends javax.swing.JPanel implements WItem, WBackCall
{
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.prp.aide.P3010000.i.WItem#wViewData(java.lang.String)
     */
    @Override
    public void wViewData(String hash)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object,
     *      java.lang.String)
     */
    @Override
    public void wAction(EventObject event, Object object, String property)
    {
    }

    private void ica()
    {
    }

    private void ita()
    {
    }
    /**  */
    private static final long serialVersionUID = -4895198196280721338L;
}
