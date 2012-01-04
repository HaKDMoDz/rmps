/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.Testsoft.v;

import rmp.face.WBean;
import rmp.prp.aide.Testsoft.Testsoft;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 迷你模式窗口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel implements WBean
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    private Testsoft ms_MainSoft;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     * 
     * @param soft
     */
    public MiniPanel(Testsoft soft)
    {
        this.ms_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        // 布局初始化
        ica();
        // AMON:其它布局初始化以此类推

        // 语言初始化
        ita();
        // AMON:其它语言初始化以此类推

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 布局显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局区域
    // ----------------------------------------------------
    /**
     * 界面布局初始化<br />
     * 其它布局初始化方法命名：icb、icc、icd...以此类推。
     */
    private void ica()
    {
        pl_InfoPanel = new javax.swing.JPanel();
        lb_InfoLabel = new javax.swing.JLabel();

        pl_InfoPanel.setBorder(javax.swing.BorderFactory.createTitledBorder("测试软件"));
        pl_InfoPanel.setLayout(new java.awt.BorderLayout());

        lb_InfoLabel.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_InfoLabel.setText("<html>这是一个测试软件，<br />用于演示Amon个人助理标准插件的开发流程与规范。</html>");
        pl_InfoPanel.add(lb_InfoLabel, java.awt.BorderLayout.CENTER);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(pl_InfoPanel,
                javax.swing.GroupLayout.DEFAULT_SIZE, 180, Short.MAX_VALUE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(pl_InfoPanel,
                javax.swing.GroupLayout.DEFAULT_SIZE, 120, Short.MAX_VALUE).addContainerGap()));
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 界面语言初始化<br />
     * 其它语言初始化方法命名：itb、itc、itd...以此类推。
     */
    private void ita()
    {
    }
    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JLabel lb_InfoLabel;
    private javax.swing.JPanel pl_InfoPanel;
    /** serialVersionUID */
    private static final long serialVersionUID = -3665172775259828381L;
}
