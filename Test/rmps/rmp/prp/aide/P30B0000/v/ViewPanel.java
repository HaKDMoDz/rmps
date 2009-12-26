/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30B0000.v;

import rmp.prp.aide.P30B0000.m.DataModel;

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
public class ViewPanel extends javax.swing.JPanel
{
    public ViewPanel()
    {
    }

    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    private void ica()
    {
        DataModel dm = new DataModel();
        table.setModel(dm);
        dm.fireTableDataChanged();
    }

    private void ita()
    {
    }

    private javax.swing.JTable table;
}
