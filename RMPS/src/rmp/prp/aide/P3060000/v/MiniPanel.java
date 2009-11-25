/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.v;

import com.amonsoft.rmps.prp.v.IView;
import java.awt.GridLayout;
import java.math.BigDecimal;

import rmp.prp.aide.P3060000.P3060000;
import rmp.prp.aide.P3060000.b.WCalField;
import rmp.util.BeanUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P3060000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 迷你模式计算器，提供简单的四则运算，在用户输入同时计算结果并显示。
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel implements IView
{
    /** 是否已输入小数点 */
    private boolean flagDecimal;
    /** 是否在现有输入数据上追加数值 */
    private boolean flagOperator;
    /** 计算精度 */
    private int precision;
    /** 上一个操作数 */
    private BigDecimal lastOperand;
    /** 下一个操作数 */
    private BigDecimal nextOperand;
    /** 记忆体数据 */
    private BigDecimal memoOperand;
    /** 上一个运算符 */
    private String lastOperator;

    /**
     * @param soft
     */
    public MiniPanel(P3060000 soft)
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
        precision = 8;

        ica();
        icb();
        icc();
        icd();

        ita();
        itb();
        itc();
        itd();

        setDefault();
        memoOperand = new BigDecimal(0);

        return true;
    }

    /**
     * 运算按钮布局
     */
    private void ica()
    {
        pl_SPanel = new javax.swing.JPanel();
        pl_SPanel.setLayout(new GridLayout(4, 5, 3, 3));

        // 7
        bt_ButtonN7 = new javax.swing.JButton("7");
        bt_ButtonN7.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN7);

        // 8
        bt_ButtonN8 = new javax.swing.JButton("8");
        bt_ButtonN8.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN8);

        // 9
        bt_ButtonN9 = new javax.swing.JButton("9");
        bt_ButtonN9.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN9);

        // /
        bt_ButtonS3 = new javax.swing.JButton("/");
        bt_ButtonS3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonSx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonS3);

        // x^y
        bt_ButtonA2 = new javax.swing.JButton("x^y");
        bt_ButtonA2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA2_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonA2);

        // 4
        bt_ButtonN4 = new javax.swing.JButton("4");
        bt_ButtonN4.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN4);

        // 5
        bt_ButtonN5 = new javax.swing.JButton("5");
        bt_ButtonN5.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN5);

        // 6
        bt_ButtonN6 = new javax.swing.JButton("6");
        bt_ButtonN6.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN6);

        // *
        bt_ButtonS2 = new javax.swing.JButton("*");
        bt_ButtonS2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonSx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonS2);

        // %
        bt_ButtonA1 = new javax.swing.JButton("%");
        bt_ButtonA1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA1_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonA1);

        // 1
        bt_ButtonN1 = new javax.swing.JButton("1");
        bt_ButtonN1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN1);

        // 2
        bt_ButtonN2 = new javax.swing.JButton("2");
        bt_ButtonN2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN2);

        // 3
        bt_ButtonN3 = new javax.swing.JButton("3");
        bt_ButtonN3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN3);

        // -
        bt_ButtonS1 = new javax.swing.JButton("-");
        bt_ButtonS1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonSx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonS1);

        // 1/x
        bt_ButtonA0 = new javax.swing.JButton("1/x");
        bt_ButtonA0.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonA0_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonA0);

        // 0
        bt_ButtonN0 = new javax.swing.JButton("0");
        bt_ButtonN0.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonNx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonN0);

        // +/-
        bt_ButtonC2 = new javax.swing.JButton("+/-");
        bt_ButtonC2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonC2_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonC2);

        // .
        bt_ButtonC1 = new javax.swing.JButton(".");
        bt_ButtonC1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonC1_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonC1);

        // +
        bt_ButtonS0 = new javax.swing.JButton("+");
        bt_ButtonS0.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonSx_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonS0);

        // =
        bt_ButtonC0 = new javax.swing.JButton("=");
        bt_ButtonC0.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonC0_Handler(evt);
            }
        });
        pl_SPanel.add(bt_ButtonC0);
    }

    /**
     * 内存操作按钮
     */
    private void icb()
    {
        pl_MPanel = new javax.swing.JPanel();
        pl_MPanel.setLayout(new GridLayout(4, 0, 3, 3));

        bt_ButtonMC = new javax.swing.JButton("MC");
        bt_ButtonMC.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonMC_Handler(evt);
            }
        });
        pl_MPanel.add(bt_ButtonMC);

        bt_ButtonMR = new javax.swing.JButton("MR");
        bt_ButtonMR.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonMR_Handler(evt);
            }
        });
        pl_MPanel.add(bt_ButtonMR);

        bt_ButtonMS = new javax.swing.JButton("MS");
        bt_ButtonMS.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonMS_Handler(evt);
            }
        });
        pl_MPanel.add(bt_ButtonMS);

        bt_ButtonMP = new javax.swing.JButton("M+");
        bt_ButtonMP.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonMP_Handler(evt);
            }
        });
        pl_MPanel.add(bt_ButtonMP);
    }

    /**
     * 显示控制按钮
     */
    private void icc()
    {
        pl_CPanel = new javax.swing.JPanel();

        tf_Precision = new javax.swing.JTextField(4);
        tf_Precision.setHorizontalAlignment(javax.swing.JTextField.TRAILING);
        tf_Precision.setText("8");
        tf_Precision.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_Precision_Handler(evt);
            }
        });
        tf_Precision.addFocusListener(new java.awt.event.FocusListener()
        {
            public void focusGained(java.awt.event.FocusEvent evt)
            {
            }

            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_Precision_Handler(evt);
            }
        });

        bt_ButtonV2 = new javax.swing.JButton("<-");
        bt_ButtonV2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonV2_Handler(evt);
            }
        });
        pl_CPanel.add(bt_ButtonV2);

        bt_ButtonV1 = new javax.swing.JButton("CE");
        bt_ButtonV1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonV1_Handler(evt);
            }
        });

        bt_ButtonV0 = new javax.swing.JButton("CR");
        bt_ButtonV0.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButtonV0_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_CPanel);
        pl_CPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(1, Short.MAX_VALUE).addComponent(tf_Precision,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ButtonV2).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ButtonV1).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ButtonV0)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ButtonV0).addComponent(bt_ButtonV1).addComponent(bt_ButtonV2).addComponent(tf_Precision,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)));
    }

    /**
     * 界面布局
     */
    private void icd()
    {
        tf_RestFild = new WCalField();

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_CPanel,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(tf_RestFild, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                layout.createSequentialGroup().addComponent(pl_MPanel, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                pl_SPanel, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(tf_RestFild,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_CPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_MPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(pl_SPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE)));
    }

    private void ita()
    {
        BeanUtil.setWText(bt_ButtonN7, P3060000.getMesg(LangRes.P306550F));
        BeanUtil.setWTips(bt_ButtonN7, P3060000.getMesg(LangRes.P3065510));

        BeanUtil.setWText(bt_ButtonN8, P3060000.getMesg(LangRes.P3065511));
        BeanUtil.setWTips(bt_ButtonN8, P3060000.getMesg(LangRes.P3065512));

        BeanUtil.setWText(bt_ButtonN9, P3060000.getMesg(LangRes.P3065513));
        BeanUtil.setWTips(bt_ButtonN9, P3060000.getMesg(LangRes.P3065514));

        BeanUtil.setWText(bt_ButtonS3, P3060000.getMesg(LangRes.P306551B));
        BeanUtil.setWTips(bt_ButtonS3, P3060000.getMesg(LangRes.P306551C));

        BeanUtil.setWText(bt_ButtonA2, P3060000.getMesg(LangRes.P306552F));
        BeanUtil.setWTips(bt_ButtonA2, P3060000.getMesg(LangRes.P3065530));

        BeanUtil.setWText(bt_ButtonN4, P3060000.getMesg(LangRes.P3065509));
        BeanUtil.setWTips(bt_ButtonN4, P3060000.getMesg(LangRes.P306550A));

        BeanUtil.setWText(bt_ButtonN5, P3060000.getMesg(LangRes.P306550B));
        BeanUtil.setWTips(bt_ButtonN5, P3060000.getMesg(LangRes.P306550C));

        BeanUtil.setWText(bt_ButtonN6, P3060000.getMesg(LangRes.P306550D));
        BeanUtil.setWTips(bt_ButtonN6, P3060000.getMesg(LangRes.P306550E));

        BeanUtil.setWText(bt_ButtonS2, P3060000.getMesg(LangRes.P3065519));
        BeanUtil.setWTips(bt_ButtonS2, P3060000.getMesg(LangRes.P306551A));

        BeanUtil.setWText(bt_ButtonA1, P3060000.getMesg(LangRes.P306551D));
        BeanUtil.setWTips(bt_ButtonA1, P3060000.getMesg(LangRes.P306551E));

        BeanUtil.setWText(bt_ButtonN1, P3060000.getMesg(LangRes.P3065503));
        BeanUtil.setWTips(bt_ButtonN1, P3060000.getMesg(LangRes.P3065504));

        BeanUtil.setWText(bt_ButtonN2, P3060000.getMesg(LangRes.P3065505));
        BeanUtil.setWTips(bt_ButtonN2, P3060000.getMesg(LangRes.P3065506));

        BeanUtil.setWText(bt_ButtonN3, P3060000.getMesg(LangRes.P3065507));
        BeanUtil.setWTips(bt_ButtonN3, P3060000.getMesg(LangRes.P3065508));

        BeanUtil.setWText(bt_ButtonS1, P3060000.getMesg(LangRes.P3065517));
        BeanUtil.setWTips(bt_ButtonS1, P3060000.getMesg(LangRes.P3065518));

        BeanUtil.setWText(bt_ButtonA0, P3060000.getMesg(LangRes.P306552D));
        BeanUtil.setWTips(bt_ButtonA0, P3060000.getMesg(LangRes.P306552E));

        BeanUtil.setWText(bt_ButtonN0, P3060000.getMesg(LangRes.P3065501));
        BeanUtil.setWTips(bt_ButtonN0, P3060000.getMesg(LangRes.P3065502));

        BeanUtil.setWText(bt_ButtonC2, P3060000.getMesg(LangRes.P306551F));
        BeanUtil.setWTips(bt_ButtonC2, P3060000.getMesg(LangRes.P3065520));

        BeanUtil.setWText(bt_ButtonC1, P3060000.getMesg(LangRes.P3065521));
        BeanUtil.setWTips(bt_ButtonC1, P3060000.getMesg(LangRes.P3065522));

        BeanUtil.setWText(bt_ButtonS0, P3060000.getMesg(LangRes.P3065515));
        BeanUtil.setWTips(bt_ButtonS0, P3060000.getMesg(LangRes.P3065516));

        BeanUtil.setWText(bt_ButtonC0, P3060000.getMesg(LangRes.P3065523));
        BeanUtil.setWTips(bt_ButtonC0, P3060000.getMesg(LangRes.P3065524));
    }

    private void itb()
    {
        BeanUtil.setWText(bt_ButtonMC, P3060000.getMesg(LangRes.P3065525));
        BeanUtil.setWTips(bt_ButtonMC, P3060000.getMesg(LangRes.P3065526));

        BeanUtil.setWText(bt_ButtonMR, P3060000.getMesg(LangRes.P3065527));
        BeanUtil.setWTips(bt_ButtonMR, P3060000.getMesg(LangRes.P3065528));

        BeanUtil.setWText(bt_ButtonMS, P3060000.getMesg(LangRes.P3065529));
        BeanUtil.setWTips(bt_ButtonMS, P3060000.getMesg(LangRes.P306552A));

        BeanUtil.setWText(bt_ButtonMP, P3060000.getMesg(LangRes.P306552B));
        BeanUtil.setWTips(bt_ButtonMP, P3060000.getMesg(LangRes.P306552C));
    }

    private void itc()
    {
        BeanUtil.setWText(tf_Precision, P3060000.getMesg(LangRes.P3065401));
        BeanUtil.setWTips(tf_Precision, P3060000.getMesg(LangRes.P3065402));

        BeanUtil.setWText(bt_ButtonV2, P3060000.getMesg(LangRes.P3065531));
        BeanUtil.setWTips(bt_ButtonV2, P3060000.getMesg(LangRes.P3065532));

        BeanUtil.setWText(bt_ButtonV1, P3060000.getMesg(LangRes.P3065533));
        BeanUtil.setWTips(bt_ButtonV1, P3060000.getMesg(LangRes.P3065534));

        BeanUtil.setWText(bt_ButtonV0, P3060000.getMesg(LangRes.P3065535));
        BeanUtil.setWTips(bt_ButtonV0, P3060000.getMesg(LangRes.P3065536));
    }

    private void itd()
    {
        BeanUtil.setWText(tf_RestFild, P3060000.getMesg(LangRes.P3065403));
        BeanUtil.setWTips(tf_RestFild, P3060000.getMesg(LangRes.P3065404));
    }

    /**
     * 数值按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonNx_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (obj instanceof javax.swing.JButton)
        {
            javax.swing.JButton b = (javax.swing.JButton) obj;
            // 上一输入数据为运算符的处理：进行新的数据输入
            if (flagOperator)
            {
                tf_RestFild.setText(b.getText());
                flagOperator = false;
            }
            // 上一输入数据不是运算符的处理：继续拼接数值
            else
            {
                tf_RestFild.append(b.getText());
            }
        }
    }

    /**
     * 四则运算按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonSx_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = evt.getSource();
        if (!(obj instanceof javax.swing.JButton))
        {
            return;
        }

        operate();

        javax.swing.JButton b = (javax.swing.JButton) obj;
        lastOperator = b.getText();
        tf_RestFild.setOperator(lastOperator);
        tf_RestFild.setText(lastOperand.toPlainString());
    }

    /**
     * 求结果按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonC0_Handler(java.awt.event.ActionEvent evt)
    {
        operate();

        tf_RestFild.setOperator(bt_ButtonC0.getText());
        tf_RestFild.setText(lastOperand.toPlainString());

        setDefault();
    }

    /**
     * 小数点按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonC1_Handler(java.awt.event.ActionEvent evt)
    {
        if (!flagDecimal)
        {
            tf_RestFild.append(bt_ButtonC1.getText());
            flagDecimal = true;
        }
    }

    /**
     * 取负值按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonC2_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.setText(new BigDecimal(tf_RestFild.getText()).negate().toPlainString());
    }

    /**
     * 计算结果按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonMC_Handler(java.awt.event.ActionEvent evt)
    {
        memoOperand = new BigDecimal(0);
    }

    /**
     * MR按钮事件处理：显示记忆体数据
     * 
     * @param evt
     */
    private void bt_ButtonMR_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.setText(memoOperand.toPlainString());
    }

    /**
     * MS按钮事件处理：将显示数据保存在记忆体中
     * 
     * @param evt
     */
    private void bt_ButtonMS_Handler(java.awt.event.ActionEvent evt)
    {
        memoOperand = new BigDecimal(tf_RestFild.getText());
    }

    /**
     * MP按钮事件处理：将显示数据与记忆体中数据相加，但不显示
     * 
     * @param evt
     */
    private void bt_ButtonMP_Handler(java.awt.event.ActionEvent evt)
    {
        memoOperand = memoOperand.add(new BigDecimal(tf_RestFild.getText()));
    }

    /**
     * 清除运算结果
     * 
     * @param evt
     */
    private void bt_ButtonV0_Handler(java.awt.event.ActionEvent evt)
    {
        setDefault();
        tf_RestFild.setText("0");
        tf_RestFild.setOperator("");
    }

    /**
     * 清除显示结果
     * 
     * @param evt
     */
    private void bt_ButtonV1_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.setText("0");
    }

    /**
     * 删除一个字符
     * 
     * @param evt
     */
    private void bt_ButtonV2_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.deleteEnd();
    }

    /**
     * 1/x按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonA0_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.setOperator("=");

        BigDecimal a = new BigDecimal(0);
        BigDecimal b = new BigDecimal(tf_RestFild.getText());
        if (b.compareTo(a) == 0)
        {
            return;
        }

        a = new BigDecimal(1);
        a = a.divide(b, precision, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros();
        tf_RestFild.setText(a.toPlainString());
    }

    /**
     * %按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButtonA1_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.setOperator("=");

        BigDecimal a = new BigDecimal(tf_RestFild.getText());
        a = a.divide(new BigDecimal(100), precision, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros();
        tf_RestFild.setText(a.toPlainString());
    }

    /**
     * n次方运算
     * 
     * @param evt
     */
    private void bt_ButtonA2_Handler(java.awt.event.ActionEvent evt)
    {
        tf_RestFild.setOperator("=");

        BigDecimal a = new BigDecimal(tf_RestFild.getText());
        a = a.pow(2);
        tf_RestFild.setText(a.toPlainString());
    }

    /**
     * @param evt
     */
    private void tf_Precision_Handler(java.awt.AWTEvent evt)
    {
        String text = tf_Precision.getText();
        if (text == null)
        {
            text = "8";
        }
        text = text.trim();
        if (text.length() == 0)
        {
            text = "8";
        }
        precision = Integer.parseInt(text);
        if (precision > 20)
        {
            MesgUtil.showMessageDialog(this, P3060000.getMesg(LangRes.P3065A01));
        }
    }

    /**
     * 进行四则运算
     */
    private void operate()
    {
        nextOperand = new BigDecimal(tf_RestFild.getText());

        if ("+".equals(lastOperator))
        {
            lastOperand = lastOperand.add(nextOperand);
        }
        else if ("-".equals(lastOperator))
        {
            lastOperand = lastOperand.subtract(nextOperand);
        }
        else if ("*".equals(lastOperator))
        {
            lastOperand = lastOperand.multiply(nextOperand);
        }
        else if ("/".equals(lastOperator))
        {
            lastOperand = lastOperand.divide(nextOperand, precision, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros();
        }

        // 小数点没有输入状态
        flagDecimal = false;
        // 当前输入为运算符
        flagOperator = true;
    }

    /**
     * 设置计算器的默认状态
     */
    private void setDefault()
    {
        lastOperand = new BigDecimal(0);
        lastOperator = "+";
        flagOperator = true;
    }
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
    // ----------------------------------------------------
    // 运算控制区域
    // ----------------------------------------------------
    /** = */
    private javax.swing.JButton bt_ButtonC0;
    /** . */
    private javax.swing.JButton bt_ButtonC1;
    /** +/- */
    private javax.swing.JButton bt_ButtonC2;
    // ----------------------------------------------------
    // 内存操作区域
    // ----------------------------------------------------
    /** MC(清除记忆数据) */
    private javax.swing.JButton bt_ButtonMC;
    /** MR(显示记忆数据) */
    private javax.swing.JButton bt_ButtonMR;
    /** MS(记忆现有数据) */
    private javax.swing.JButton bt_ButtonMS;
    /** M+(现有数据与记忆数据相加，但不显示) */
    private javax.swing.JButton bt_ButtonMP;
    // ----------------------------------------------------
    // 代数运算区域
    // ----------------------------------------------------
    /** 1/x */
    private javax.swing.JButton bt_ButtonA0;
    /** % */
    private javax.swing.JButton bt_ButtonA1;
    /** x^y */
    private javax.swing.JButton bt_ButtonA2;
    // ----------------------------------------------------
    // 显示控制区域
    // ----------------------------------------------------
    /** 清除运算结果 */
    private javax.swing.JButton bt_ButtonV0;
    /** 清除显示数值 */
    private javax.swing.JButton bt_ButtonV1;
    /** 清除最一个字符 */
    private javax.swing.JButton bt_ButtonV2;
    /** 计算输出结果精度 */
    private javax.swing.JTextField tf_Precision;
    /** 结果显示区域 */
    private WCalField tf_RestFild;
    private javax.swing.JPanel pl_SPanel;
    private javax.swing.JPanel pl_CPanel;
    private javax.swing.JPanel pl_MPanel;
    /** serialVersionUID */
    private static final long serialVersionUID = 6473758374183319642L;
}
