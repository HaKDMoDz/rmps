/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3030000.v;

import javax.swing.JPanel;

import rmp.bean.CellRender;
import rmp.face.WBean;
import rmp.prp.aide.P3030000.P3030000;
import rmp.prp.aide.P3030000.m.CodeData;
import rmp.util.BeanUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P3030000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class NormPanel extends javax.swing.JPanel implements WBean
{
    /**  */
    private CodeData tm_DataList;

    /**
     * @param soft
     */
    public NormPanel(P3030000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        tm_DataList = new CodeData();

        ica();
        ita();

        tb_DataList.setDefaultRenderer(String.class, new CellRender());
        this.tf_SttField.requestFocus();
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 查询界面初始化
     */
    private void ica()
    {
        JPanel modePanel1 = icb();
        JPanel userPanel1 = icc();
        JPanel viewPanel1 = icd();

        javax.swing.JScrollPane sp2 = new javax.swing.JScrollPane();

        tb_DataList = new javax.swing.JTable();
        tb_DataList.setModel(tm_DataList);
        sp2.setViewportView(tb_DataList);

        bt_Query = new javax.swing.JButton();
        bt_Query.setMnemonic('Q');
        bt_Query.setText("查询(Q)");
        bt_Query.setToolTipText("查询");
        bt_Query.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_Query.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Query_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(modePanel1,
                javax.swing.GroupLayout.DEFAULT_SIZE, 440, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(sp2,
                javax.swing.GroupLayout.DEFAULT_SIZE, 349, Short.MAX_VALUE).addComponent(userPanel1,
                javax.swing.GroupLayout.DEFAULT_SIZE, 349, Short.MAX_VALUE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(bt_Query).addComponent(viewPanel1, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(modePanel1,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(userPanel1,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_Query)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(viewPanel1,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(sp2, javax.swing.GroupLayout.DEFAULT_SIZE,
                208, Short.MAX_VALUE)).addContainerGap()));
    }

    /**
     * 查询模式界面初始化
     * 
     * @return
     */
    private JPanel icb()
    {
        JPanel modePanel = new JPanel();

        javax.swing.ButtonGroup bg_UserMode = new javax.swing.ButtonGroup();
        rb_CharMode = new javax.swing.JRadioButton();
        rb_CodeMode = new javax.swing.JRadioButton();

        modePanel.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 5, 0));

        bg_UserMode.add(rb_CharMode);
        rb_CharMode.setMnemonic('C');
        rb_CharMode.setSelected(true);
        rb_CharMode.setText("字符查询(C)");
        rb_CharMode.setToolTipText("字符查询");
        rb_CharMode.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_CharMode.setMargin(new java.awt.Insets(0, 0, 0, 0));
        rb_CharMode.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_CharMode_Handler(evt);
            }
        });
        modePanel.add(rb_CharMode);

        bg_UserMode.add(rb_CodeMode);
        rb_CodeMode.setMnemonic('N');
        rb_CodeMode.setText("数值查询(N)");
        rb_CodeMode.setToolTipText("数值查询");
        rb_CodeMode.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        rb_CodeMode.setMargin(new java.awt.Insets(0, 0, 0, 0));
        rb_CodeMode.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_CodeMode_Handler(evt);
            }
        });
        modePanel.add(rb_CodeMode);

        return modePanel;
    }

    /**
     * 用户交互界面初始化
     * 
     * @return
     */
    private JPanel icc()
    {
        JPanel userPanel = new JPanel();
        userPanel.setLayout(new java.awt.GridBagLayout());

        // 起始交互面板
        pl_SttPanel = new JPanel();
        pl_SttPanel.setLayout(new java.awt.GridBagLayout());
        java.awt.GridBagConstraints bgca = new java.awt.GridBagConstraints();
        bgca.fill = java.awt.GridBagConstraints.HORIZONTAL;
        bgca.weightx = 0.5;
        bgca.insets = new java.awt.Insets(0, 0, 0, 5);
        userPanel.add(pl_SttPanel, bgca);

        lb_SttLabel = new javax.swing.JLabel();
        lb_SttLabel.setText("起始(S)");
        lb_SttLabel.setDisplayedMnemonic('S');
        pl_SttPanel.add(lb_SttLabel, new java.awt.GridBagConstraints());

        java.awt.GridBagConstraints gbcs = new java.awt.GridBagConstraints();
        gbcs.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbcs.weightx = 1.0;
        tf_SttField = new javax.swing.JTextField();
        lb_SttLabel.setLabelFor(tf_SttField);
        tf_SttField.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_SttField_Handler(evt);
            }
        });
        pl_SttPanel.add(tf_SttField, gbcs);

        // 结束交互面板
        pl_EndPanel = new JPanel();
        pl_EndPanel.setLayout(new java.awt.GridBagLayout());
        java.awt.GridBagConstraints bgcb = new java.awt.GridBagConstraints();
        bgcb.fill = java.awt.GridBagConstraints.HORIZONTAL;
        bgcb.weightx = 0.5;
        bgcb.insets = new java.awt.Insets(0, 5, 0, 0);
        userPanel.add(pl_EndPanel, bgcb);

        lb_EndLabel = new javax.swing.JLabel();
        lb_EndLabel.setText("结束(E)");
        lb_EndLabel.setDisplayedMnemonic('E');
        pl_EndPanel.add(lb_EndLabel, new java.awt.GridBagConstraints());

        java.awt.GridBagConstraints gbce = new java.awt.GridBagConstraints();
        gbce.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbce.weightx = 1.0;
        tf_EndField = new javax.swing.JTextField();
        lb_EndLabel.setLabelFor(tf_EndField);
        tf_EndField.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_EndField_Handler(evt);
            }
        });
        pl_EndPanel.add(tf_EndField, gbce);

        pl_EndPanel.setVisible(false);
        return userPanel;
    }

    /**
     * 显示控制界面初始化
     * 
     * @return
     */
    private JPanel icd()
    {
        JPanel viewPanel = new JPanel();

        ck_ColumnCH = new javax.swing.JCheckBox();
        ck_ColumnCH.setMnemonic('H');
        ck_ColumnCH.setSelected(true);
        ck_ColumnCH.setText("\u5b57\u7b26(H)");
        ck_ColumnCH.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_ColumnCH.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_ColumnCH.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ck_ColumnCH_Handler(evt);
            }
        });

        ck_Column16 = new javax.swing.JCheckBox();
        ck_Column16.setMnemonic('X');
        ck_Column16.setSelected(true);
        ck_Column16.setText("16\u8fdb\u5236(X)");
        ck_Column16.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Column16.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_Column16.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ck_Column16_Handler(evt);
            }
        });

        ck_Column10 = new javax.swing.JCheckBox();
        ck_Column10.setSelected(true);
        ck_Column10.setText("10\u8fdb\u5236");
        ck_Column10.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Column10.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_Column10.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ck_Column10_Handler(evt);
            }
        });

        ck_Column08 = new javax.swing.JCheckBox();
        ck_Column08.setMnemonic('O');
        ck_Column08.setText("8\u8fdb\u5236(O)");
        ck_Column08.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Column08.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_Column08.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ck_Column08_Handler(evt);
            }
        });

        ck_Column02 = new javax.swing.JCheckBox();
        ck_Column02.setMnemonic('B');
        ck_Column02.setText("2\u8fdb\u5236(B)");
        ck_Column02.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Column02.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_Column02.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ck_Column02_Handler(evt);
            }
        });

        javax.swing.JSeparator sp1 = new javax.swing.JSeparator();

        ck_FixedSize = new javax.swing.JCheckBox();
        ck_FixedSize.setText("\u586b\u5145(F)");
        ck_FixedSize.setToolTipText("\u5de6\u90e8\u586b\u5145\u5b57\u7b260\u4ee5\u5b9a\u957f\u663e\u793a");
        ck_FixedSize.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_FixedSize.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_FixedSize.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                ck_FixedSize_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(viewPanel);
        viewPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(ck_ColumnCH).addComponent(ck_Column16).addComponent(ck_Column10).addComponent(ck_Column08).addComponent(
                ck_Column02).addComponent(ck_FixedSize).addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE,
                71, Short.MAX_VALUE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(ck_ColumnCH).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(ck_Column16).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(ck_Column10).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(ck_Column08).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(ck_Column02).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(sp1,
                javax.swing.GroupLayout.PREFERRED_SIZE, 10, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(ck_FixedSize)));

        return viewPanel;
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
        // 字符查询
        BeanUtil.setWText(rb_CharMode, P3030000.getMesg(LangRes.RBTN_TEXT_CHARMODE));
        BeanUtil.setWTips(rb_CharMode, P3030000.getMesg(LangRes.RBTN_TIPS_CHARMODE));

        // 数值查询
        BeanUtil.setWText(rb_CodeMode, P3030000.getMesg(LangRes.RBTN_TEXT_CODEMODE));
        BeanUtil.setWTips(rb_CodeMode, P3030000.getMesg(LangRes.RBTN_TIPS_CODEMODE));

        // 起始标签
        BeanUtil.setWText(lb_SttLabel, P3030000.getMesg(LangRes.LABL_TEXT_STT_LABEL));
        BeanUtil.setWTips(lb_SttLabel, P3030000.getMesg(LangRes.LABL_TIPS_STT_LABEL));

        BeanUtil.setWText(tf_SttField, P3030000.getMesg(LangRes.FILD_TEXT_STTFIELD));
        BeanUtil.setWTips(tf_SttField, P3030000.getMesg(LangRes.FILD_TIPS_STTFIELD1));

        // 结束标签
        BeanUtil.setWText(lb_EndLabel, P3030000.getMesg(LangRes.LABL_TEXT_END_LABEL));
        BeanUtil.setWTips(lb_EndLabel, P3030000.getMesg(LangRes.LABL_TIPS_END_LABEL));

        BeanUtil.setWText(tf_EndField, P3030000.getMesg(LangRes.FILD_TEXT_ENDFIELD));
        BeanUtil.setWTips(tf_EndField, P3030000.getMesg(LangRes.FILD_TIPS_ENDFIELD));

        // 查询按钮
        BeanUtil.setWText(bt_Query, P3030000.getMesg(LangRes.BUTN_TEXT_QUERY));
        BeanUtil.setWTips(bt_Query, P3030000.getMesg(LangRes.BUTN_TIPS_QUERY));

        // 字符
        BeanUtil.setWText(ck_ColumnCH, P3030000.getMesg(LangRes.CHCK_TEXT_COLUMNCH));
        BeanUtil.setWTips(ck_ColumnCH, P3030000.getMesg(LangRes.CHCK_TIPS_COLUMNCH));

        // 16进制
        BeanUtil.setWText(ck_Column16, P3030000.getMesg(LangRes.CHCK_TEXT_COLUMN16));
        BeanUtil.setWTips(ck_Column16, P3030000.getMesg(LangRes.CHCK_TIPS_COLUMN16));

        // 10进制
        BeanUtil.setWText(ck_Column10, P3030000.getMesg(LangRes.CHCK_TEXT_COLUMN10));
        BeanUtil.setWTips(ck_Column10, P3030000.getMesg(LangRes.CHCK_TIPS_COLUMN10));

        // 8进制
        BeanUtil.setWText(ck_Column08, P3030000.getMesg(LangRes.CHCK_TEXT_COLUMN08));
        BeanUtil.setWTips(ck_Column08, P3030000.getMesg(LangRes.CHCK_TIPS_COLUMN08));

        // 2进制
        BeanUtil.setWText(ck_Column02, P3030000.getMesg(LangRes.CHCK_TEXT_COLUMN02));
        BeanUtil.setWTips(ck_Column02, P3030000.getMesg(LangRes.CHCK_TIPS_COLUMN02));

        // 填充
        BeanUtil.setWText(ck_FixedSize, P3030000.getMesg(LangRes.CHCK_TEXT_FIXEDSIZE));
        BeanUtil.setWTips(ck_FixedSize, P3030000.getMesg(LangRes.CHCK_TIPS_FIXEDSIZE));

        BeanUtil.setWTips(tb_DataList, P3030000.getMesg(LangRes.TBLE_TIPS_DATALIST));
    }

    /**
     * 
     */
    private void itb()
    {
        BeanUtil.setWTips(tf_SttField, P3030000.getMesg(LangRes.FILD_TIPS_STTFIELD1));
    }

    /**
     * 
     */
    private void itc()
    {
        BeanUtil.setWTips(tf_SttField, P3030000.getMesg(LangRes.FILD_TIPS_STTFIELD2));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 查询按钮事件处理
     * 
     * @param evt
     */
    private void bt_Query_Handler(java.awt.event.ActionEvent evt)
    {
        if (this.rb_CharMode.isSelected())
        {
            tm_DataList.setCharModel(true);
            String userText = this.tf_SttField.getText();
            if (userText.length() < 1)
            {
                MesgUtil.showMessageDialog(P3030000.getForm(), P3030000.getMesg(LangRes.MESG_0001));
                this.tf_SttField.requestFocus();
                return;
            }
            tm_DataList.setUsrChar(userText);
        }
        else
        {
            numbQuery();
        }

        tm_DataList.fireTableDataChanged();
    }

    /**
     * @param evt
     */
    private void ck_ColumnCH_Handler(java.awt.event.ActionEvent evt)
    {
        tm_DataList.setShowColCh(this.ck_ColumnCH.isSelected());
        tm_DataList.fireTableStructureChanged();
    }

    /**
     * @param evt
     */
    private void ck_Column16_Handler(java.awt.event.ActionEvent evt)
    {
        tm_DataList.setShowCol16(this.ck_Column16.isSelected());
        tm_DataList.fireTableStructureChanged();
    }

    /**
     * @param evt
     */
    private void ck_Column10_Handler(java.awt.event.ActionEvent evt)
    {
        tm_DataList.setShowCol10(this.ck_Column10.isSelected());
        tm_DataList.fireTableStructureChanged();
    }

    /**
     * @param evt
     */
    private void ck_Column08_Handler(java.awt.event.ActionEvent evt)
    {
        tm_DataList.setShowCol08(this.ck_Column08.isSelected());
        tm_DataList.fireTableStructureChanged();
    }

    /**
     * @param evt
     */
    private void ck_Column02_Handler(java.awt.event.ActionEvent evt)
    {
        tm_DataList.setShowCol02(this.ck_Column02.isSelected());
        tm_DataList.fireTableStructureChanged();
    }

    /**
     * @param evt
     */
    private void ck_FixedSize_Handler(java.awt.event.ActionEvent evt)
    {
        tm_DataList.setFixLength(this.ck_FixedSize.isSelected());
        tm_DataList.fireTableDataChanged();
    }

    /**
     * 字符模式按钮事件处理
     * 
     * @param evt
     */
    private void rb_CharMode_Handler(java.awt.event.ActionEvent evt)
    {
        pl_EndPanel.setVisible(false);
        itb();
    }

    /**
     * 数值模式按钮事件处理
     * 
     * @param evt
     */
    private void rb_CodeMode_Handler(java.awt.event.ActionEvent evt)
    {
        pl_EndPanel.setVisible(true);
        itc();
    }

    /**
     * 结束文本条按钮事件处理
     * 
     * @param evt
     */
    private void tf_EndField_Handler(java.awt.event.ActionEvent evt)
    {
        numbQuery();

        tm_DataList.fireTableDataChanged();
    }

    /**
     * 起始文本条按钮事件处理
     * 
     * @param evt
     */
    private void tf_SttField_Handler(java.awt.event.ActionEvent evt)
    {
        if (this.rb_CharMode.isSelected())
        {
            tm_DataList.setCharModel(true);
            String userText = this.tf_SttField.getText();
            if (userText.length() < 1)
            {
                MesgUtil.showMessageDialog(P3030000.getForm(), P3030000.getMesg(LangRes.MESG_0001));
                this.tf_SttField.requestFocus();
                return;
            }
            tm_DataList.setUsrChar(userText);
        }
        else
        {
            numbQuery();
        }

        tm_DataList.fireTableDataChanged();
    }

    /**
     * 
     */
    private void numbQuery()
    {
        tm_DataList.setCharModel(false);
        String sttChar = this.tf_SttField.getText().toLowerCase();
        String endChar = this.tf_EndField.getText().toLowerCase();
        // 两者不能同时为空
        if (sttChar.length() < 1 && endChar.length() < 1)
        {
            MesgUtil.showMessageDialog(P3030000.getForm(), P3030000.getMesg(LangRes.MESG_0002));
            this.tf_SttField.requestFocus();
            return;
        }

        if (sttChar.length() < 1)
        {
            sttChar = endChar;
        }
        if (endChar.length() < 1)
        {
            endChar = sttChar;
        }

        try
        {
            tm_DataList.setSttChar(sttChar);
        }
        catch (NumberFormatException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(P3030000.getForm(), P3030000.getMesg(LangRes.MESG_0003));
            this.tf_SttField.requestFocus();
            return;
        }

        try
        {
            tm_DataList.setEndChar(endChar);
        }
        catch (NumberFormatException exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(P3030000.getForm(), P3030000.getMesg(LangRes.MESG_0004));
            this.tf_EndField.requestFocus();
            return;
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JRadioButton rb_CharMode;
    private javax.swing.JRadioButton rb_CodeMode;
    private javax.swing.JPanel pl_SttPanel;
    private javax.swing.JLabel lb_SttLabel;
    private javax.swing.JTextField tf_SttField;
    private javax.swing.JPanel pl_EndPanel;
    private javax.swing.JLabel lb_EndLabel;
    private javax.swing.JTextField tf_EndField;
    private javax.swing.JCheckBox ck_Column02;
    private javax.swing.JCheckBox ck_Column08;
    private javax.swing.JCheckBox ck_Column10;
    private javax.swing.JCheckBox ck_Column16;
    private javax.swing.JCheckBox ck_ColumnCH;
    private javax.swing.JCheckBox ck_FixedSize;
    private javax.swing.JButton bt_Query;
    private javax.swing.JTable tb_DataList;
}
