/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3030000.v;

import rmp.face.WBean;
import rmp.prp.aide.P3030000.P3030000;
import rmp.util.CheckUtil;
import rmp.util.MesgUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 编码查询迷你面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel implements WBean
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    private ViewPanel vp_ViewPanel;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public MiniPanel(P3030000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        icb();
        ita();
        itb();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    private void ica()
    {
        pl_UserPanel = new javax.swing.JPanel();
        tf_CharCode = new javax.swing.JTextField();
        bt_CharCode = new javax.swing.JButton();

        tf_CharCode.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_CharCode_Handler(evt);
            }
        });

        bt_CharCode.setMnemonic('Q');
        bt_CharCode.setText("\u67e5\u8be2(Q)");
        bt_CharCode.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_CharCode.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CharCode_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_UserPanel);
        pl_UserPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap().addComponent(tf_CharCode, javax.swing.GroupLayout.DEFAULT_SIZE, 135, Short.MAX_VALUE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_CharCode).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_CharCode).addComponent(tf_CharCode, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))));
    }

    /**
     * 
     */
    private void icb()
    {
        this.setLayout(new java.awt.BorderLayout());

        this.add(pl_UserPanel, java.awt.BorderLayout.NORTH);

        vp_ViewPanel = new ViewPanel();
        vp_ViewPanel.init();
        this.add(vp_ViewPanel, java.awt.BorderLayout.CENTER);
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 
     */
    private void itb()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 按钮查询事件处理
     * 
     * @param evt
     */
    private void bt_CharCode_Handler(java.awt.event.ActionEvent evt)
    {
        queryData();
    }

    /**
     * 文本查询事件处理
     * 
     * @param evt
     */
    private void tf_CharCode_Handler(java.awt.event.ActionEvent evt)
    {
        queryData();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 数据查询
     */
    private void queryData()
    {
        String text = this.tf_CharCode.getText();
        if (!CheckUtil.isValidate(text))
        {
            MesgUtil.showMessageDialog(this, "查询内容不能为空，请重新输入！");
            this.tf_CharCode.requestFocus();
            return;
        }

        // 数据查询
        try
        {
            vp_ViewPanel.setData(text);
        }
        catch (NumberFormatException exp)
        {
            MesgUtil.showMessageDialog(this, exp.getMessage());
            this.tf_CharCode.requestFocus();
            return;
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面构件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 查询按钮 */
    private javax.swing.JButton bt_CharCode;
    /** 用户输入文本框 */
    private javax.swing.JTextField tf_CharCode;
    /**  */
    private javax.swing.JPanel pl_UserPanel;
    /** serialVersionUID */
    private static final long serialVersionUID = -3476520311000133797L;
}
