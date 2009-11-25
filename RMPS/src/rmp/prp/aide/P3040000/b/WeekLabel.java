/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.b;

import javax.swing.JLabel;

import cons.prp.aide.P3040000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class WeekLabel extends JLabel
{
    /**
     * 
     */
    public WeekLabel()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        this.setOpaque(true);
        this.setHorizontalAlignment(CENTER);
        this.setBackground(ConstUI.H_B_COLOR);

        return true;
    }
    /** serialVersionUID */
    private static final long serialVersionUID = 7475561024725110543L;
}
