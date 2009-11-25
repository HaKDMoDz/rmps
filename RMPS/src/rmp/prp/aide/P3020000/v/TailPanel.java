/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.v;

import rmp.prp.aide.P3020000.P3020000;
import rmp.ui.link.WLinkLabel;

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
public class TailPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 应用程序 */
    private P3020000 ms_MainSoft;
    /** 内嵌面板 */
    private javax.swing.JPanel tp_TailPanel;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P3020000 soft, javax.swing.JPanel tailPanel)
    {
        this.ms_MainSoft = soft;
        this.tp_TailPanel = tailPanel;
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

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        ll_LinkLabl = new WLinkLabel();
        ll_LinkLabl.setText("启动窗口");
        tp_TailPanel.setLayout(new java.awt.FlowLayout());
        tp_TailPanel.add(ll_LinkLabl);
        ll_LinkLabl.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                ms_MainSoft.wShowView(P3020000.VIEW_NORM);
            }
        });
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
        ;
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private WLinkLabel ll_LinkLabl;
}
