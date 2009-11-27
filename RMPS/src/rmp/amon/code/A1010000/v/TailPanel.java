/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.code.A1010000.v;

import rmp.amon.code.A1010000.A1010000;
import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.ui.link.WLinkLabel;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 代码安全内嵌面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class TailPanel
{
    private IPrpPlus soft;
    private javax.swing.JPanel tailPanel;

    /**
     * @param tailPanel
     */
    public TailPanel(IPrpPlus soft, javax.swing.JPanel tailPanel)
    {
        this.soft = soft;
        this.tailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ica();

        ita();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        ll_LinkLabl = new WLinkLabel();
        ll_LinkLabl.setText("启动窗口");
        tailPanel.setLayout(new java.awt.FlowLayout());
        tailPanel.add(ll_LinkLabl);
        ll_LinkLabl.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                soft.wShowView(A1010000.VIEW_MAIN);
            }
        });
    }

    /**
     * 
     */
    private void ita()
    {
    }
    private WLinkLabel ll_LinkLabl;
}
