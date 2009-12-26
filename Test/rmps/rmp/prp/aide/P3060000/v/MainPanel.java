/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.v;

import com.amonsoft.rmps.prp.v.IView;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.Point;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JDialog;
import javax.swing.text.BadLocationException;
import javax.swing.text.Caret;
import javax.swing.text.Document;

import rmp.bean.K1SV2S;
import rmp.prp.aide.P3060000.P3060000;
import rmp.prp.aide.P3060000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import com.amonsoft.util.LogUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P3060000.ConstUI;
import cons.prp.aide.P3060000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 高级计算器，可以根据用户输入的代数表达式进行求值计算，并可以根据需要显示每一步的运算过程。
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MainPanel extends javax.swing.JPanel implements IView
{
    /**  */
    private JDialog dg_StepForm;
    /**  */
    private StepPanel sp_StepPanel;
    /** 计算精度 */
    private int precision = 8;

    public MainPanel(P3060000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        ica();
        icb();
        icc();
        icd();
        ice();

        ita();
        itb();
        itc();
        itd();
        ite();

        bt_ButtonT5.setEnabled(false);
        bt_ButtonT4.setEnabled(false);
        bt_ButtonT3.setEnabled(false);

        return true;
    }

    /**
     * 数据及四则运算输入区域
     */
    private void ica()
    {
        pl_NPanel = new javax.swing.JPanel();
        pl_NPanel.setLayout(new GridLayout(4, 4, 3, 3));

        bt_ButtonN7 = new javax.swing.JButton("7");
        bt_ButtonN7.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN7_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN7);

        bt_ButtonN8 = new javax.swing.JButton("8");
        bt_ButtonN8.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN8_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN8);

        bt_ButtonN9 = new javax.swing.JButton("9");
        bt_ButtonN9.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN9_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN9);

        bt_ButtonS3 = new javax.swing.JButton("/");
        bt_ButtonS3.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS3_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonS3);

        bt_ButtonN4 = new javax.swing.JButton("4");
        bt_ButtonN4.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN4_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN4);

        bt_ButtonN5 = new javax.swing.JButton("5");
        bt_ButtonN5.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN5_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN5);

        bt_ButtonN6 = new javax.swing.JButton("6");
        bt_ButtonN6.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN6_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN6);

        bt_ButtonS2 = new javax.swing.JButton("*");
        bt_ButtonS2.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS2_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonS2);

        bt_ButtonN1 = new javax.swing.JButton("1");
        bt_ButtonN1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN1_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN1);

        bt_ButtonN2 = new javax.swing.JButton("2");
        bt_ButtonN2.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN2_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN2);

        bt_ButtonN3 = new javax.swing.JButton("3");
        bt_ButtonN3.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN3_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN3);

        bt_ButtonS1 = new javax.swing.JButton("-");
        bt_ButtonS1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS1_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonS1);

        bt_ButtonN0 = new javax.swing.JButton("0");
        bt_ButtonN0.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonN0_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonN0);

        // .
        bt_ButtonS5 = new javax.swing.JButton(".");
        bt_ButtonS5.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS5_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonS5);

        // %
        bt_ButtonS4 = new javax.swing.JButton("%");
        bt_ButtonS4.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS4_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonS4);

        bt_ButtonS0 = new javax.swing.JButton("+");
        bt_ButtonS0.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS0_Handler(evt);
            }
        });
        pl_NPanel.add(bt_ButtonS0);
    }

    /**
     * 括号及PI等输入区域
     */
    private void icb()
    {
        pl_PPanel = new javax.swing.JPanel();
        pl_PPanel.setLayout(new GridLayout(4, 2, 3, 3));

        bt_ButtonP5 = new javax.swing.JButton("(");
        bt_ButtonP5.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonP5_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonP5);

        bt_ButtonP4 = new javax.swing.JButton(")");
        bt_ButtonP4.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonP4_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonP4);

        bt_ButtonP3 = new javax.swing.JButton("[");
        bt_ButtonP3.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonP3_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonP3);

        bt_ButtonP2 = new javax.swing.JButton("]");
        bt_ButtonP2.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonP2_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonP2);

        bt_ButtonP1 = new javax.swing.JButton("{");
        bt_ButtonP1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonP1_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonP1);

        bt_ButtonP0 = new javax.swing.JButton("}");
        bt_ButtonP0.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonP0_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonP0);

        bt_ButtonA6 = new javax.swing.JButton("π");
        bt_ButtonA6.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA6_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonA6);

        bt_ButtonA5 = new javax.swing.JButton("e");
        bt_ButtonA5.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA5_Handler(evt);
            }
        });
        pl_PPanel.add(bt_ButtonA5);
    }

    /**
     * 代数运算输入区域
     */
    private void icc()
    {
        pl_TPanel = new javax.swing.JPanel();
        pl_TPanel.setLayout(new GridLayout(4, 3, 3, 3));

        // x^y
        bt_ButtonA3 = new javax.swing.JButton("x^y");
        bt_ButtonA3.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA3_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonA3);

        // sin
        bt_ButtonT2 = new javax.swing.JButton("sin");
        bt_ButtonT2.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonT2_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonT2);

        // csc
        bt_ButtonT5 = new javax.swing.JButton("csc");
        bt_ButtonT5.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonT5_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonT5);

        // √
        bt_ButtonA2 = new javax.swing.JButton("√");
        bt_ButtonA2.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA2_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonA2);

        // cos
        bt_ButtonT1 = new javax.swing.JButton("cos");
        bt_ButtonT1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonT1_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonT1);

        // sec
        bt_ButtonT4 = new javax.swing.JButton("sec");
        bt_ButtonT4.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonT4_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonT4);

        // log
        bt_ButtonA1 = new javax.swing.JButton("log");
        bt_ButtonA1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA1_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonA1);

        // tan
        bt_ButtonT0 = new javax.swing.JButton("tan");
        bt_ButtonT0.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonT0_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonT0);

        // cot
        bt_ButtonT3 = new javax.swing.JButton("cot");
        bt_ButtonT3.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonT3_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonT3);

        // ln
        bt_ButtonA0 = new javax.swing.JButton("ln");
        bt_ButtonA0.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA0_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonA0);

        // n!
        bt_ButtonA4 = new javax.swing.JButton("n!");
        bt_ButtonA4.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA4_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonA4);

        // =
        bt_ButtonS6 = new javax.swing.JButton("=");
        bt_ButtonS6.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonS6_Handler(evt);
            }
        });
        pl_TPanel.add(bt_ButtonS6);
    }

    /**
     * 
     */
    private void icd()
    {
        pl_VPanel = new javax.swing.JPanel();
        pl_VPanel.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.RIGHT, 6, 0));

        tf_Precision = new javax.swing.JTextField();
        bt_ButtonV1 = new javax.swing.JButton();
        bt_ButtonV0 = new javax.swing.JButton();
        bt_ShowStep = new javax.swing.JButton();

        tf_Precision.setColumns(4);
        tf_Precision.setHorizontalAlignment(javax.swing.JTextField.TRAILING);
        tf_Precision.setText("8");
        tf_Precision.setToolTipText("结果计算精度");
        tf_Precision.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_Precision_Handler(evt);
            }
        });
        tf_Precision.addFocusListener(new java.awt.event.FocusListener()
        {
            @Override
            public void focusGained(java.awt.event.FocusEvent evt)
            {
            }

            @Override
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_Precision_Handler(evt);
            }
        });
        pl_VPanel.add(tf_Precision);

        bt_ButtonV1.setText("CR");
        bt_ButtonV1.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonV1_Handler(evt);
            }
        });
        pl_VPanel.add(bt_ButtonV1);

        bt_ButtonV0.setText("<-");
        bt_ButtonV0.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonV0_Handler(evt);
            }
        });
        pl_VPanel.add(bt_ButtonV0);

        bt_ShowStep.setMnemonic('S');
        bt_ShowStep.setText(">>");
        bt_ShowStep.setToolTipText("显示计算过程");
        bt_ShowStep.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ShowStep_Handler(evt);
            }
        });
        pl_VPanel.add(bt_ShowStep);
    }

    /**
     * 单步显示初始化
     */
    private void ice()
    {
        javax.swing.JScrollPane sp_UserForm = new javax.swing.JScrollPane();
        ta_UserForm = new javax.swing.JTextArea();

        ta_UserForm.setRows(4);
        ta_UserForm.setLineWrap(true);
        ta_UserForm.setWrapStyleWord(true);
        sp_UserForm.setViewportView(ta_UserForm);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp_UserForm,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(pl_VPanel, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(
                layout.createSequentialGroup().addComponent(pl_NPanel, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(
                pl_PPanel, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(
                pl_TPanel, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_UserForm,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(pl_VPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_NPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(pl_PPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(pl_TPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE)));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(bt_ButtonN7, P3060000.getMesg(LangRes.P306750F));
        BeanUtil.setWTips(bt_ButtonN7, P3060000.getMesg(LangRes.P3067510));

        BeanUtil.setWText(bt_ButtonN8, P3060000.getMesg(LangRes.P3067511));
        BeanUtil.setWTips(bt_ButtonN8, P3060000.getMesg(LangRes.P3067512));

        BeanUtil.setWText(bt_ButtonN9, P3060000.getMesg(LangRes.P3067513));
        BeanUtil.setWTips(bt_ButtonN9, P3060000.getMesg(LangRes.P3067514));

        BeanUtil.setWText(bt_ButtonS3, P3060000.getMesg(LangRes.P306751B));
        BeanUtil.setWTips(bt_ButtonS3, P3060000.getMesg(LangRes.P306751C));

        BeanUtil.setWText(bt_ButtonN4, P3060000.getMesg(LangRes.P3067509));
        BeanUtil.setWTips(bt_ButtonN4, P3060000.getMesg(LangRes.P306750A));

        BeanUtil.setWText(bt_ButtonN5, P3060000.getMesg(LangRes.P306750B));
        BeanUtil.setWTips(bt_ButtonN5, P3060000.getMesg(LangRes.P306750C));

        BeanUtil.setWText(bt_ButtonN6, P3060000.getMesg(LangRes.P306750D));
        BeanUtil.setWTips(bt_ButtonN6, P3060000.getMesg(LangRes.P306750E));

        BeanUtil.setWText(bt_ButtonS2, P3060000.getMesg(LangRes.P3067519));
        BeanUtil.setWTips(bt_ButtonS2, P3060000.getMesg(LangRes.P306751A));

        BeanUtil.setWText(bt_ButtonN1, P3060000.getMesg(LangRes.P3067503));
        BeanUtil.setWTips(bt_ButtonN1, P3060000.getMesg(LangRes.P3067504));

        BeanUtil.setWText(bt_ButtonN2, P3060000.getMesg(LangRes.P3067505));
        BeanUtil.setWTips(bt_ButtonN2, P3060000.getMesg(LangRes.P3067506));

        BeanUtil.setWText(bt_ButtonN3, P3060000.getMesg(LangRes.P3067507));
        BeanUtil.setWTips(bt_ButtonN3, P3060000.getMesg(LangRes.P3067508));

        BeanUtil.setWText(bt_ButtonS1, P3060000.getMesg(LangRes.P3067517));
        BeanUtil.setWTips(bt_ButtonS1, P3060000.getMesg(LangRes.P3067518));

        BeanUtil.setWText(bt_ButtonN0, P3060000.getMesg(LangRes.P3067501));
        BeanUtil.setWTips(bt_ButtonN0, P3060000.getMesg(LangRes.P3067502));

        BeanUtil.setWText(bt_ButtonS5, P3060000.getMesg(LangRes.P306751F));
        BeanUtil.setWTips(bt_ButtonS5, P3060000.getMesg(LangRes.P3067520));

        BeanUtil.setWText(bt_ButtonS4, P3060000.getMesg(LangRes.P306751D));
        BeanUtil.setWTips(bt_ButtonS4, P3060000.getMesg(LangRes.P306751E));

        BeanUtil.setWText(bt_ButtonS0, P3060000.getMesg(LangRes.P3067515));
        BeanUtil.setWTips(bt_ButtonS0, P3060000.getMesg(LangRes.P3067516));
    }

    /**
     * 
     */
    private void itb()
    {
        BeanUtil.setWText(bt_ButtonP5, P3060000.getMesg(LangRes.P3067523));
        BeanUtil.setWTips(bt_ButtonP5, P3060000.getMesg(LangRes.P3067524));

        BeanUtil.setWText(bt_ButtonP4, P3060000.getMesg(LangRes.P3067525));
        BeanUtil.setWTips(bt_ButtonP4, P3060000.getMesg(LangRes.P3067526));

        BeanUtil.setWText(bt_ButtonP3, P3060000.getMesg(LangRes.P3067527));
        BeanUtil.setWTips(bt_ButtonP3, P3060000.getMesg(LangRes.P3067528));

        BeanUtil.setWText(bt_ButtonP2, P3060000.getMesg(LangRes.P3067529));
        BeanUtil.setWTips(bt_ButtonP2, P3060000.getMesg(LangRes.P306752A));

        BeanUtil.setWText(bt_ButtonP1, P3060000.getMesg(LangRes.P306752B));
        BeanUtil.setWTips(bt_ButtonP1, P3060000.getMesg(LangRes.P306752C));

        BeanUtil.setWText(bt_ButtonP0, P3060000.getMesg(LangRes.P306752D));
        BeanUtil.setWTips(bt_ButtonP0, P3060000.getMesg(LangRes.P306752E));

        BeanUtil.setWText(bt_ButtonA6, P3060000.getMesg(LangRes.P306753F));
        BeanUtil.setWTips(bt_ButtonA6, P3060000.getMesg(LangRes.P3067540));

        BeanUtil.setWText(bt_ButtonA5, P3060000.getMesg(LangRes.P306753D));
        BeanUtil.setWTips(bt_ButtonA5, P3060000.getMesg(LangRes.P306753E));
    }

    /**
     * 
     */
    private void itc()
    {
        BeanUtil.setWText(bt_ButtonA3, P3060000.getMesg(LangRes.P3067539));
        BeanUtil.setWTips(bt_ButtonA3, P3060000.getMesg(LangRes.P306753A));

        BeanUtil.setWText(bt_ButtonT2, P3060000.getMesg(LangRes.P3067545));
        BeanUtil.setWTips(bt_ButtonT2, P3060000.getMesg(LangRes.P3067546));

        BeanUtil.setWText(bt_ButtonT5, "csc");
        BeanUtil.setWTips(bt_ButtonT5, null);

        BeanUtil.setWText(bt_ButtonA2, P3060000.getMesg(LangRes.P3067537));
        BeanUtil.setWTips(bt_ButtonA2, P3060000.getMesg(LangRes.P3067538));

        BeanUtil.setWText(bt_ButtonT1, P3060000.getMesg(LangRes.P3067543));
        BeanUtil.setWTips(bt_ButtonT1, P3060000.getMesg(LangRes.P3067544));

        BeanUtil.setWText(bt_ButtonT4, "sec");
        BeanUtil.setWTips(bt_ButtonT4, null);

        BeanUtil.setWText(bt_ButtonA1, P3060000.getMesg(LangRes.P3067535));
        BeanUtil.setWTips(bt_ButtonA1, P3060000.getMesg(LangRes.P3067536));

        BeanUtil.setWText(bt_ButtonT0, P3060000.getMesg(LangRes.P3067541));
        BeanUtil.setWTips(bt_ButtonT0, P3060000.getMesg(LangRes.P3067542));

        BeanUtil.setWText(bt_ButtonT3, "cot");
        BeanUtil.setWTips(bt_ButtonT3, null);

        BeanUtil.setWText(bt_ButtonA0, P3060000.getMesg(LangRes.P3067533));
        BeanUtil.setWTips(bt_ButtonA0, P3060000.getMesg(LangRes.P3067534));

        BeanUtil.setWText(bt_ButtonA4, P3060000.getMesg(LangRes.P306753B));
        BeanUtil.setWTips(bt_ButtonA4, P3060000.getMesg(LangRes.P306753C));

        BeanUtil.setWText(bt_ButtonS6, P3060000.getMesg(LangRes.P3067521));
        BeanUtil.setWTips(bt_ButtonS6, P3060000.getMesg(LangRes.P3067522));
    }

    /**
     * 
     */
    private void itd()
    {
        BeanUtil.setWText(tf_Precision, P3060000.getMesg(LangRes.P3067401));
        BeanUtil.setWTips(tf_Precision, P3060000.getMesg(LangRes.P3067402));

        BeanUtil.setWText(bt_ButtonV1, P3060000.getMesg(LangRes.P3067548));
        BeanUtil.setWTips(bt_ButtonV1, P3060000.getMesg(LangRes.P3067549));

        BeanUtil.setWText(bt_ButtonV0, P3060000.getMesg(LangRes.P306754A));
        BeanUtil.setWTips(bt_ButtonV0, P3060000.getMesg(LangRes.P306754B));

        BeanUtil.setWText(bt_ShowStep, P3060000.getMesg(LangRes.P306754C));
        BeanUtil.setWTips(bt_ShowStep, P3060000.getMesg(LangRes.P306754D));
    }

    /**
     * 
     */
    private void ite()
    {
        BeanUtil.setWText(ta_UserForm, P3060000.getMesg(LangRes.P3067403));
        BeanUtil.setWTips(ta_UserForm, P3060000.getMesg(LangRes.P3067404));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数值输入区域
    // ----------------------------------------------------
    /**
     * @param evt
     */
    private void bt_ButtonN0_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_0);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN1_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_1);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN2_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_2);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN3_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_3);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN4_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_4);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN5_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_5);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN6_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_6);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN7_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_7);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN8_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_8);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonN9_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_9);
        ta_UserForm.requestFocus();
    }

    // ----------------------------------------------------
    // 四则运算区域
    // ----------------------------------------------------
    /**
     * 加
     * 
     * @param evt
     */
    private void bt_ButtonS0_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_ADD_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * 减
     * 
     * @param evt
     */
    private void bt_ButtonS1_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_SUB_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * 乘
     * 
     * @param evt
     */
    private void bt_ButtonS2_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_MUL_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * 除
     * 
     * @param evt
     */
    private void bt_ButtonS3_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_DIV_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonS4_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_MOD_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonS5_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_D);
        ta_UserForm.requestFocus();
    }

    /**
     * 等号按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonS6_Handler(java.awt.event.ActionEvent evt)
    {
        String exps = ta_UserForm.getText();
        if (!CheckUtil.isValidate(exps))
        {
            MesgUtil.showMessageDialog(this, P3060000.getMesg(LangRes.P3067A01));
            ta_UserForm.requestFocus();
            return;
        }

        int idx1 = exps.lastIndexOf(ConstUI.OPR_EQU_EXP);
        if (exps.endsWith(ConstUI.OPR_EQU_EXP))
        {
            int idx2 = exps.lastIndexOf(ConstUI.OPR_EQU_EXP, idx1);
            if (idx2 >= 0)
            {
                exps = exps.substring(idx2 + 1, idx1);
            }
        }
        else
        {
            if (idx1 >= 0)
            {
                exps = exps.substring(exps.lastIndexOf(ConstUI.OPR_EQU_EXP) + 1);
            }
            ta_UserForm.append(ConstUI.OPR_EQU_EXP);
        }

        try
        {
            List<K1SV2S> stepList = null;
            if (dg_StepForm != null)
            {
                stepList = new ArrayList<K1SV2S>();
            }
            ta_UserForm.append(Util.calculate(exps, precision, stepList));
            if (dg_StepForm != null)
            {
                sp_StepPanel.setRoot(exps);
                sp_StepPanel.setStep(stepList);
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, exp.getMessage());
        }
    }

    // ----------------------------------------------------
    // 括号事件区域
    // ----------------------------------------------------
    /**
     * @param evt
     */
    private void bt_ButtonP0_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.append(ConstUI.OPR_LRB_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonP1_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_LLB_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonP2_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_MRB_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonP3_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_MLB_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonP4_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_SRB_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonP5_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_SLB_EXP);
        ta_UserForm.requestFocus();
    }

    // ----------------------------------------------------
    // 代数运算区域
    // ----------------------------------------------------
    /**
     * @param evt
     */
    private void bt_ButtonA0_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_LNE_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonA1_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_LOG_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonA2_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_ROT_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonA3_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_POW_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonA4_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_FAC_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonA5_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_E);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonA6_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.NUM_P);
        ta_UserForm.requestFocus();
    }

    // ----------------------------------------------------
    // 三角函数区域
    // ----------------------------------------------------
    /**
     * @param evt
     */
    private void bt_ButtonT0_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_TAN_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonT1_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_COS_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonT2_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_SIN_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonT3_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_COT_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonT4_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_SEC_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void bt_ButtonT5_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.replaceSelection(ConstUI.OPR_CSC_EXP);
        ta_UserForm.requestFocus();
    }

    /**
     * 显示单步运算过程
     * 
     * @param evt
     */
    private void bt_ShowStep_Handler(java.awt.event.ActionEvent evt)
    {
        // 实例化单步窗口
        if (dg_StepForm == null)
        {
            sp_StepPanel = new StepPanel();
            sp_StepPanel.wInit();

            javax.swing.JFrame frame = null;
            dg_StepForm = new javax.swing.JDialog(frame);
            dg_StepForm.getContentPane().add(sp_StepPanel);
            dg_StepForm.pack();

            Point p = frame.getLocation();
            Dimension s = frame.getSize();
            dg_StepForm.setLocation(p.x + s.width, p.y);

            dg_StepForm.setTitle("单步计算");

            String exps = ta_UserForm.getText();
            int idx = exps.indexOf("=");
            if (idx > 0)
            {
                exps = exps.substring(0, idx);
            }
            List<K1SV2S> stepList = new ArrayList<K1SV2S>();
            try
            {
                if (exps.length() > 0)
                {
                    Util.calculate(exps, precision, stepList);
                }

                sp_StepPanel.setRoot(exps);
                sp_StepPanel.setStep(stepList);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }

        // 窗口可视
        if (!dg_StepForm.isVisible())
        {
            dg_StepForm.setVisible(true);
        }
    }

    /**
     * @param evt
     */
    private void bt_ButtonV0_Handler(java.awt.event.ActionEvent evt)
    {
        try
        {
            Document doc = ta_UserForm.getDocument();
            Caret caret = ta_UserForm.getCaret();
            int dot = caret.getDot();
            int mark = caret.getMark();
            if (dot != mark)
            {
                doc.remove(Math.min(dot, mark), Math.abs(dot - mark));
            }
            else if (dot > 0)
            {
                int delChars = 1;

                if (dot > 1)
                {
                    String dotChars = doc.getText(dot - 2, 2);
                    char c0 = dotChars.charAt(0);
                    char c1 = dotChars.charAt(1);

                    if (c0 >= '\uD800' && c0 <= '\uDBFF' && c1 >= '\uDC00' && c1 <= '\uDFFF')
                    {
                        delChars = 2;
                    }
                }

                doc.remove(dot - delChars, delChars);
            }
            ta_UserForm.requestFocus();
        }
        catch (BadLocationException bl)
        {
        }
    }

    /**
     * @param evt
     */
    private void bt_ButtonV1_Handler(java.awt.event.ActionEvent evt)
    {
        ta_UserForm.setText("");
        ta_UserForm.requestFocus();
    }

    /**
     * @param evt
     */
    private void tf_Precision_Handler(java.awt.AWTEvent evt)
    {
        String t = tf_Precision.getText();
        if (t.trim().length() < 1)
        {
            t = "8";
        }
        try
        {
            precision = Integer.parseInt(t);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, P3060000.getMesg(LangRes.P3067A02));
            tf_Precision.requestFocus();
        }
        if (precision < 0)
        {
            precision = 8;
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面变更区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数值输入区域
    // ----------------------------------------------------
    /** 0 */
    private javax.swing.JButton bt_ButtonN0;
    /** 1 */
    private javax.swing.JButton bt_ButtonN1;
    /** 2 */
    private javax.swing.JButton bt_ButtonN2;
    /** 3 */
    private javax.swing.JButton bt_ButtonN3;
    /** 4 */
    private javax.swing.JButton bt_ButtonN4;
    /** 5 */
    private javax.swing.JButton bt_ButtonN5;
    /** 6 */
    private javax.swing.JButton bt_ButtonN6;
    /** 7 */
    private javax.swing.JButton bt_ButtonN7;
    /** 8 */
    private javax.swing.JButton bt_ButtonN8;
    /** 9 */
    private javax.swing.JButton bt_ButtonN9;
    // ----------------------------------------------------
    // 四则运算区域
    // ----------------------------------------------------
    /** + */
    private javax.swing.JButton bt_ButtonS0;
    /** - */
    private javax.swing.JButton bt_ButtonS1;
    /** x */
    private javax.swing.JButton bt_ButtonS2;
    /** / */
    private javax.swing.JButton bt_ButtonS3;
    /** % */
    private javax.swing.JButton bt_ButtonS4;
    /** . */
    private javax.swing.JButton bt_ButtonS5;
    /** = */
    private javax.swing.JButton bt_ButtonS6;
    // ----------------------------------------------------
    // 括号按钮区域
    // ----------------------------------------------------
    /** } */
    private javax.swing.JButton bt_ButtonP0;
    /** { */
    private javax.swing.JButton bt_ButtonP1;
    /** ] */
    private javax.swing.JButton bt_ButtonP2;
    /** [ */
    private javax.swing.JButton bt_ButtonP3;
    /** ) */
    private javax.swing.JButton bt_ButtonP4;
    /** ( */
    private javax.swing.JButton bt_ButtonP5;
    // ----------------------------------------------------
    // 代数运算区域
    // ----------------------------------------------------
    /** ln */
    private javax.swing.JButton bt_ButtonA0;
    /** log */
    private javax.swing.JButton bt_ButtonA1;
    /** √ */
    private javax.swing.JButton bt_ButtonA2;
    /** x^y */
    private javax.swing.JButton bt_ButtonA3;
    /** n! */
    private javax.swing.JButton bt_ButtonA4;
    /** e */
    private javax.swing.JButton bt_ButtonA5;
    /** π */
    private javax.swing.JButton bt_ButtonA6;
    // ----------------------------------------------------
    // 三角函数区域
    // ----------------------------------------------------
    /** tan */
    private javax.swing.JButton bt_ButtonT0;
    /** cos */
    private javax.swing.JButton bt_ButtonT1;
    /** sin */
    private javax.swing.JButton bt_ButtonT2;
    /** cot */
    private javax.swing.JButton bt_ButtonT3;
    /** sec */
    private javax.swing.JButton bt_ButtonT4;
    /** csc */
    private javax.swing.JButton bt_ButtonT5;
    private javax.swing.JPanel pl_NPanel;
    private javax.swing.JPanel pl_PPanel;
    private javax.swing.JPanel pl_TPanel;
    private javax.swing.JPanel pl_VPanel;
    /** 清除一个字符 */
    private javax.swing.JButton bt_ButtonV0;
    /** 清除所有结果 */
    private javax.swing.JButton bt_ButtonV1;
    /** 是否显示计算过程 */
    private javax.swing.JButton bt_ShowStep;
    /** 计算精度 */
    private javax.swing.JTextField tf_Precision;
    /** 用户计算式输入区域 */
    private javax.swing.JTextArea ta_UserForm;
    /** serialVersionUID */
    private static final long serialVersionUID = 5864479988152708567L;
}
