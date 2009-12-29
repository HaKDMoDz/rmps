/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.v;

import java.awt.CardLayout;

import rmp.io.db.DBAccess;
import rmp.prp.aide.P3040000.P3040000;
import rmp.prp.aide.P3040000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.HashUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;

import com.amonsoft.util.CharUtil;

import cons.SysCons;
import cons.db.PrpCons;
import cons.prp.aide.P3040000.ConstUI;
import cons.prp.aide.P3040000.LangRes;

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
public class StepPanel extends javax.swing.JPanel
{
    /**  */
    private static final long serialVersionUID = -926825002283435989L;
    /**  */
    private int currStep = 0;
    /**  */
    private CardLayout cl_CardPanl;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    public StepPanel()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#wInit()
     */
    public boolean wInit()
    {
        ica();
        icb();
        icc();
        icd();
        ice();
        icf();
        icg();
        ich();
        ici();
        icj();
        ick();

        ita();
        itb();
        itc();
        itd();
        ite();
        itf();
        itg();
        ith();
        iti();
        itj();
        itk();

        return true;
    }

    /**
     * 基本界面初始化
     */
    private void ica()
    {
        ta_NoteInfo = new javax.swing.JTextArea();
        pl_CardPanl = new javax.swing.JPanel();
        bt_ExitButn = new javax.swing.JButton();
        bt_NextStep = new javax.swing.JButton();
        bt_PrevStep = new javax.swing.JButton();

        ta_NoteInfo.setEditable(false);
        ta_NoteInfo.setLineWrap(true);
        ta_NoteInfo.setRows(3);
        ta_NoteInfo.setWrapStyleWord(true);

        cl_CardPanl = new CardLayout();
        pl_CardPanl.setLayout(cl_CardPanl);

        bt_ExitButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExitButnActionPerformed(evt);
            }
        });

        bt_NextStep.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_NextStepActionPerformed(evt);
            }
        });

        bt_PrevStep.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_PrevStepActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                javax.swing.GroupLayout.Alignment.TRAILING,
                                layout.createSequentialGroup().addComponent(bt_PrevStep).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextStep).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExitButn)).addComponent(pl_CardPanl, javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(ta_NoteInfo)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(ta_NoteInfo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_CardPanl, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED,
                        javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExitButn).addComponent(bt_NextStep).addComponent(bt_PrevStep)).addContainerGap()));
    }

    /**
     * 节日文本信息
     */
    private void icb()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_NoteHead = new javax.swing.JLabel();
        tf_NoteHead = new javax.swing.JTextField();
        lb_NoteInfo = new javax.swing.JLabel();
        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        ta_NoteDesp = new javax.swing.JTextArea();

        ta_NoteDesp.setColumns(20);
        ta_NoteDesp.setLineWrap(true);
        ta_NoteDesp.setRows(3);
        sp1.setViewportView(ta_NoteDesp);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE, 258, Short.MAX_VALUE).addGroup(
                                layout.createSequentialGroup().addComponent(lb_NoteHead).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_NoteHead,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, 188, Short.MAX_VALUE)).addComponent(lb_NoteInfo)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_NoteHead).addComponent(tf_NoteHead, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                        lb_NoteInfo).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp1, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_NOTE, p);
    }

    /**
     * 节日起始时间
     */
    private void icc()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();

        lb_ts = new javax.swing.JLabel();
        lb_sy = new javax.swing.JLabel();
        tf_sy = new javax.swing.JTextField();
        lb_sm = new javax.swing.JLabel();
        tf_sm = new javax.swing.JTextField();
        lb_sd = new javax.swing.JLabel();
        tf_sd = new javax.swing.JTextField();
        lb_sw = new javax.swing.JLabel();
        tf_sw = new javax.swing.JTextField();
        lb_sz = new javax.swing.JLabel();
        tf_sz = new javax.swing.JTextField();

        tf_sy.setColumns(16);

        tf_sm.setColumns(16);
        tf_sm.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_smFocusLost(evt);
            }
        });

        tf_sd.setColumns(16);

        tf_sw.setColumns(16);
        tf_sw.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_swFocusLost(evt);
            }
        });

        tf_sz.setColumns(16);
        tf_sz.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_szFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                layout.createSequentialGroup().addContainerGap().addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_sd).addComponent(lb_sm).addComponent(lb_sy)).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_sy, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_sm, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_sd, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_sw).addComponent(lb_sz)).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_sw, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_sz, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addGroup(
                                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(lb_ts))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_ts).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_sy).addComponent(tf_sy, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_sm).addComponent(tf_sm, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_sw).addComponent(tf_sw, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_sd).addComponent(tf_sd, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_sz).addComponent(tf_sz, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_SDATE, p);
    }

    /**
     * 提示年份
     */
    private void icd()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_ty = new javax.swing.JLabel();
        lb_fy = new javax.swing.JLabel();
        tf_fy = new javax.swing.JTextField();
        rb_y1 = new javax.swing.JRadioButton();
        rb_y2 = new javax.swing.JRadioButton();
        rb_y3 = new javax.swing.JRadioButton();
        tf_ny = new javax.swing.JTextField();
        lb_ny = new javax.swing.JLabel();
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        lb_fy.setLabelFor(tf_fy);

        tf_fy.setColumns(20);
        tf_fy.setEditable(false);

        bg.add(rb_y1);
        rb_y1.setSelected(true);
        rb_y1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_y1ActionPerformed(evt);
            }
        });

        bg.add(rb_y2);
        rb_y2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_y2ActionPerformed(evt);
            }
        });

        bg.add(rb_y3);
        rb_y3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_y3ActionPerformed(evt);
            }
        });

        tf_ny.setColumns(6);
        tf_ny.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        tf_ny.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_nyFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_fy, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(lb_ty,
                                javax.swing.GroupLayout.Alignment.TRAILING)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rb_y1).addComponent(tf_fy, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                layout.createSequentialGroup().addComponent(rb_y2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_ny,
                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(4, 4, 4).addComponent(lb_ny))
                                .addComponent(rb_y3)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_ty).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_fy).addComponent(tf_fy, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_y1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(rb_y2).addComponent(tf_ny, javax.swing.GroupLayout.PREFERRED_SIZE,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_ny)).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_y3).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_FYEAR, p);
    }

    /**
     * 提示月份
     */
    private void ice()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_tm = new javax.swing.JLabel();
        lb_fm = new javax.swing.JLabel();
        tf_fm = new javax.swing.JTextField();
        rb_m1 = new javax.swing.JRadioButton();
        rb_m2 = new javax.swing.JRadioButton();
        rb_m3 = new javax.swing.JRadioButton();
        tf_nm = new javax.swing.JTextField();
        lb_nm = new javax.swing.JLabel();
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        lb_fm.setLabelFor(tf_fm);

        tf_fm.setColumns(20);

        bg.add(rb_m1);
        rb_m1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_m1ActionPerformed(evt);
            }
        });

        bg.add(rb_m2);
        rb_m2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_m2ActionPerformed(evt);
            }
        });

        bg.add(rb_m3);
        rb_m3.setSelected(true);
        rb_m3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_m3ActionPerformed(evt);
            }
        });

        tf_nm.setColumns(6);
        tf_nm.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        tf_nm.setText("1");
        tf_nm.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_nmFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_fm, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(lb_tm,
                                javax.swing.GroupLayout.Alignment.TRAILING)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rb_m1).addComponent(tf_fm, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                layout.createSequentialGroup().addComponent(rb_m2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_nm,
                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(4, 4, 4).addComponent(lb_nm))
                                .addComponent(rb_m3)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_tm).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_fm).addComponent(tf_fm, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_m1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(rb_m2).addComponent(tf_nm, javax.swing.GroupLayout.PREFERRED_SIZE,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_nm)).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_m3).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_FMONTH, p);
    }

    /**
     * 提示日期
     */
    private void icf()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_td = new javax.swing.JLabel();
        lb_fd = new javax.swing.JLabel();
        tf_fd = new javax.swing.JTextField();
        rb_d1 = new javax.swing.JRadioButton();
        rb_d2 = new javax.swing.JRadioButton();
        rb_d3 = new javax.swing.JRadioButton();
        tf_nd = new javax.swing.JTextField();
        lb_nd = new javax.swing.JLabel();
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        lb_fd.setLabelFor(tf_fd);

        tf_fd.setColumns(20);

        bg.add(rb_d1);
        rb_d1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_d1ActionPerformed(evt);
            }
        });

        bg.add(rb_d2);
        rb_d2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_d2ActionPerformed(evt);
            }
        });

        bg.add(rb_d3);
        rb_d3.setSelected(true);
        rb_d3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_d3ActionPerformed(evt);
            }
        });

        tf_nd.setColumns(6);
        tf_nd.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        tf_nd.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_ndFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_fd, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(lb_td,
                                javax.swing.GroupLayout.Alignment.TRAILING)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rb_d1).addComponent(tf_fd, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                layout.createSequentialGroup().addComponent(rb_d2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_nd,
                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(4, 4, 4).addComponent(lb_nd))
                                .addComponent(rb_d3)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_td).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_fd).addComponent(tf_fd, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_d1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(rb_d2).addComponent(tf_nd, javax.swing.GroupLayout.PREFERRED_SIZE,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_nd)).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_d3).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_FDATE, p);
    }

    /**
     * 提示月周
     */
    private void icg()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_tz = new javax.swing.JLabel();
        lb_fz = new javax.swing.JLabel();
        tf_fz = new javax.swing.JTextField();
        rb_z1 = new javax.swing.JRadioButton();
        rb_z2 = new javax.swing.JRadioButton();
        rb_z3 = new javax.swing.JRadioButton();
        tf_nz = new javax.swing.JTextField();
        lb_nz = new javax.swing.JLabel();
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        lb_fz.setLabelFor(tf_fz);

        tf_fz.setColumns(20);
        tf_fz.setEditable(false);

        bg.add(rb_z1);
        rb_z1.setSelected(true);
        rb_z1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_z1ActionPerformed(evt);
            }
        });

        bg.add(rb_z2);
        rb_z2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_z2ActionPerformed(evt);
            }
        });

        bg.add(rb_z3);
        rb_z3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_z3ActionPerformed(evt);
            }
        });

        tf_nz.setColumns(6);
        tf_nz.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        tf_nz.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_nzFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_fz, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(lb_tz,
                                javax.swing.GroupLayout.Alignment.TRAILING)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rb_z1).addComponent(tf_fz, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                layout.createSequentialGroup().addComponent(rb_z2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_nz,
                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(4, 4, 4).addComponent(lb_nz))
                                .addComponent(rb_z3)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_tz).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_fz).addComponent(tf_fz, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_z1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(rb_z2).addComponent(tf_nz, javax.swing.GroupLayout.PREFERRED_SIZE,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_nz)).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_z3).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_FWEEKOFMONTH, p);
    }

    /**
     * 提示年周
     */
    private void ich()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_tw = new javax.swing.JLabel();
        lb_fw = new javax.swing.JLabel();
        tf_fw = new javax.swing.JTextField();
        rb_w1 = new javax.swing.JRadioButton();
        rb_w2 = new javax.swing.JRadioButton();
        rb_w3 = new javax.swing.JRadioButton();
        tf_nw = new javax.swing.JTextField();
        lb_nw = new javax.swing.JLabel();
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        lb_fw.setLabelFor(tf_fw);

        tf_fw.setColumns(20);
        tf_fw.setEditable(false);

        bg.add(rb_w1);
        rb_w1.setSelected(true);
        rb_w1.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_w1ActionPerformed(evt);
            }
        });

        bg.add(rb_w2);
        rb_w2.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_w2ActionPerformed(evt);
            }
        });

        bg.add(rb_w3);
        rb_w3.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rb_w3ActionPerformed(evt);
            }
        });

        tf_nw.setColumns(6);
        tf_nw.setHorizontalAlignment(javax.swing.JTextField.RIGHT);
        tf_nw.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_nwFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_fw, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(lb_tw,
                                javax.swing.GroupLayout.Alignment.TRAILING)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rb_w1).addComponent(tf_fw, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                layout.createSequentialGroup().addComponent(rb_w2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_nw,
                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(4, 4, 4).addComponent(lb_nw))
                                .addComponent(rb_w3)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_tw).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_fw).addComponent(tf_fw, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_w1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(rb_w2).addComponent(tf_nw, javax.swing.GroupLayout.PREFERRED_SIZE,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_nw)).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rb_w3).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_FWEEKOFYEAR, p);
    }

    /**
     * 节日结束时间
     */
    private void ici()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();

        lb_te = new javax.swing.JLabel();
        lb_ey = new javax.swing.JLabel();
        tf_ey = new javax.swing.JTextField();
        lb_em = new javax.swing.JLabel();
        tf_em = new javax.swing.JTextField();
        lb_ed = new javax.swing.JLabel();
        tf_ed = new javax.swing.JTextField();
        lb_ew = new javax.swing.JLabel();
        tf_ew = new javax.swing.JTextField();
        lb_ez = new javax.swing.JLabel();
        tf_ez = new javax.swing.JTextField();

        tf_ey.setColumns(16);

        tf_em.setColumns(16);
        tf_em.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_emFocusLost(evt);
            }
        });

        tf_ed.setColumns(16);

        tf_ew.setColumns(16);
        tf_ew.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_ewFocusLost(evt);
            }
        });

        tf_ez.setColumns(16);
        tf_ez.addFocusListener(new java.awt.event.FocusAdapter()
        {
            public void focusLost(java.awt.event.FocusEvent evt)
            {
                tf_ezFocusLost(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                layout.createSequentialGroup().addContainerGap().addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_ed).addComponent(lb_em).addComponent(lb_ey)).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_ey, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_em, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_ed, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_ew).addComponent(lb_ez)).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_ew, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_ez, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addGroup(
                                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(lb_te))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_te).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ey).addComponent(tf_ey, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_em).addComponent(tf_em, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_ew).addComponent(tf_ew, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ed).addComponent(tf_ed, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_ez).addComponent(tf_ez, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_EDATE, p);
    }

    /**
     * 其它信息
     */
    private void icj()
    {
        javax.swing.JPanel p = new javax.swing.JPanel();
        lb_LinkAddr = new javax.swing.JLabel();
        tf_LinkAddr = new javax.swing.JTextField();
        lb_IdioMark = new javax.swing.JLabel();
        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        ta_IdioMark = new javax.swing.JTextArea();

        ta_IdioMark.setColumns(20);
        ta_IdioMark.setLineWrap(true);
        ta_IdioMark.setRows(3);
        sp1.setViewportView(ta_IdioMark);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(p);
        p.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp1, javax.swing.GroupLayout.DEFAULT_SIZE, 258, Short.MAX_VALUE).addGroup(
                                layout.createSequentialGroup().addComponent(lb_LinkAddr).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_LinkAddr,
                                        javax.swing.GroupLayout.DEFAULT_SIZE, 188, Short.MAX_VALUE)).addComponent(lb_IdioMark)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_LinkAddr).addComponent(tf_LinkAddr, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                        lb_IdioMark).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp1, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));

        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_DESP, p);
    }

    /**
     * 数据添加成功
     */
    private void ick()
    {
        lb_NoteAddOK = new javax.swing.JLabel();
        lb_NoteAddOK.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        pl_CardPanl.add(ConstUI.CARD_STEP + ConstUI.STEP_END, lb_NoteAddOK);
    }

    /**
     * 基本界面语言初始化
     */
    private void ita()
    {
        ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049401));

        // 上一步
        BeanUtil.setWText(bt_PrevStep, P3040000.getMesg(LangRes.P3049501));
        BeanUtil.setWTips(bt_PrevStep, P3040000.getMesg(LangRes.P3049502));

        // 下一步
        BeanUtil.setWText(bt_NextStep, P3040000.getMesg(LangRes.P3049503));
        BeanUtil.setWTips(bt_NextStep, P3040000.getMesg(LangRes.P3049504));

        // 取消
        BeanUtil.setWText(bt_ExitButn, P3040000.getMesg(LangRes.P3049505));
        BeanUtil.setWTips(bt_ExitButn, P3040000.getMesg(LangRes.P3049506));
    }

    /**
     * 节日信息
     */
    private void itb()
    {
        // 显示标题
        BeanUtil.setWText(lb_NoteHead, P3040000.getMesg(LangRes.P3049301));
        BeanUtil.setWTips(lb_NoteHead, P3040000.getMesg(LangRes.P3049302));

        BeanUtil.setWText(tf_NoteHead, P3040000.getMesg(LangRes.P3049409));
        BeanUtil.setWTips(tf_NoteHead, P3040000.getMesg(LangRes.P304940A));

        // 节日说明
        BeanUtil.setWText(lb_NoteInfo, P3040000.getMesg(LangRes.P3049303));
        BeanUtil.setWTips(lb_NoteInfo, P3040000.getMesg(LangRes.P3049304));

        BeanUtil.setWText(ta_NoteDesp, P3040000.getMesg(LangRes.P304940B));
        BeanUtil.setWTips(ta_NoteDesp, P3040000.getMesg(LangRes.P304940C));
    }

    /**
     * 起始年份
     */
    private void itc()
    {
        // 节日起始年份
        BeanUtil.setWText(lb_ts, P3040000.getMesg(LangRes.P3049305));
        // BeanUtil.setWTips(lb_ts, P3040000.getMesg(LangRes.P3049304));

        // 年
        BeanUtil.setWText(lb_sy, P3040000.getMesg(LangRes.P3049306));
        BeanUtil.setWText(tf_sy, P3040000.getMesg(LangRes.P304940D));
        BeanUtil.setWTips(tf_sy, P3040000.getMesg(LangRes.P304940E));

        // 月
        BeanUtil.setWText(lb_sm, P3040000.getMesg(LangRes.P3049307));
        BeanUtil.setWText(tf_sm, P3040000.getMesg(LangRes.P304940F));
        BeanUtil.setWTips(tf_sm, P3040000.getMesg(LangRes.P3049410));

        // 日
        BeanUtil.setWText(lb_sd, P3040000.getMesg(LangRes.P3049308));
        BeanUtil.setWText(tf_sd, P3040000.getMesg(LangRes.P3049411));
        BeanUtil.setWTips(tf_sd, P3040000.getMesg(LangRes.P3049412));

        // 周（年）
        BeanUtil.setWText(lb_sw, P3040000.getMesg(LangRes.P3049309));
        BeanUtil.setWText(tf_sw, P3040000.getMesg(LangRes.P3049413));
        BeanUtil.setWTips(tf_sw, P3040000.getMesg(LangRes.P3049414));

        // 周（月）
        BeanUtil.setWText(lb_sz, P3040000.getMesg(LangRes.P304930A));
        BeanUtil.setWText(tf_sz, P3040000.getMesg(LangRes.P3049415));
        BeanUtil.setWTips(tf_sz, P3040000.getMesg(LangRes.P3049416));
    }

    /**
     * 提示年份
     */
    private void itd()
    {
        // 提示年份周期
        BeanUtil.setWText(lb_ty, P3040000.getMesg(LangRes.P304930B));
        // BeanUtil.setWTips(lb_ty, P3040000.getMesg(LangRes.P3049416));

        // 年份
        BeanUtil.setWText(lb_fy, P3040000.getMesg(LangRes.P304930C));
        // BeanUtil.setWTips(lb_ty, P3040000.getMesg(LangRes.P3049416));

        // 年份公式
        BeanUtil.setWText(tf_fy, P3040000.getMesg(LangRes.P3049417));
        // BeanUtil.setWTips(tf_fy, P3040000.getMesg(LangRes.P3049416));

        // 每隔年份
        BeanUtil.setWText(tf_ny, P3040000.getMesg(LangRes.P3049418));
        // BeanUtil.setWTips(tf_ny, P3040000.getMesg(LangRes.P3049416));

        // 每年
        BeanUtil.setWText(rb_y1, P3040000.getMesg(LangRes.P3049701));
        BeanUtil.setWTips(rb_y1, P3040000.getMesg(LangRes.P3049702));

        // 每隔
        BeanUtil.setWText(rb_y2, P3040000.getMesg(LangRes.P3049703));
        BeanUtil.setWTips(rb_y2, P3040000.getMesg(LangRes.P3049704));

        BeanUtil.setWText(lb_ny, P3040000.getMesg(LangRes.P304930F));
        // BeanUtil.setWTips(lb_cy, P3040000.getMesg(LangRes.P3049416));

        // 其它
        BeanUtil.setWText(rb_y3, P3040000.getMesg(LangRes.P3049705));
        BeanUtil.setWTips(rb_y3, P3040000.getMesg(LangRes.P3049706));
    }

    /**
     * 提示月份周期
     */
    private void ite()
    {
        // 提示月份周期
        BeanUtil.setWText(lb_tm, P3040000.getMesg(LangRes.P3049311));
        // BeanUtil.setWTips(lb_tm, P3040000.getMesg(LangRes.P3049311));

        // 月份
        BeanUtil.setWText(lb_fm, P3040000.getMesg(LangRes.P3049312));
        // BeanUtil.setWTips(lb_lm, P3040000.getMesg(LangRes.P3049312));

        // 月份公式
        BeanUtil.setWText(tf_fm, P3040000.getMesg(LangRes.P3049419));
        // BeanUtil.setWTips(tf_fm, P3040000.getMesg(LangRes.P3049416));

        // 每隔月份
        BeanUtil.setWText(tf_nm, P3040000.getMesg(LangRes.P304941A));
        // BeanUtil.setWTips(tf_nm, P3040000.getMesg(LangRes.P3049416));

        // 每月
        BeanUtil.setWText(rb_m1, P3040000.getMesg(LangRes.P3049707));
        BeanUtil.setWTips(rb_m1, P3040000.getMesg(LangRes.P3049708));

        // 每隔
        BeanUtil.setWText(rb_m2, P3040000.getMesg(LangRes.P3049709));
        BeanUtil.setWTips(rb_m2, P3040000.getMesg(LangRes.P304970A));

        BeanUtil.setWText(lb_nm, P3040000.getMesg(LangRes.P3049315));
        // BeanUtil.setWTips(lb_nm, P3040000.getMesg(LangRes.P3049416));

        // 其它
        BeanUtil.setWText(rb_m3, P3040000.getMesg(LangRes.P304970B));
        BeanUtil.setWTips(rb_m3, P3040000.getMesg(LangRes.P304970C));
    }

    /**
     * 提示日期周期
     */
    private void itf()
    {
        // 提示日期周期
        BeanUtil.setWText(lb_td, P3040000.getMesg(LangRes.P3049317));
        // BeanUtil.setWTips(lb_tm, P3040000.getMesg(LangRes.P3049311));

        // 日期
        BeanUtil.setWText(lb_fd, P3040000.getMesg(LangRes.P3049318));
        // BeanUtil.setWTips(lb_fd, P3040000.getMesg(LangRes.P3049312));

        // 日期公式
        BeanUtil.setWText(tf_fd, P3040000.getMesg(LangRes.P304941B));
        // BeanUtil.setWTips(tf_fd, P3040000.getMesg(LangRes.P3049416));

        // 每隔日期
        BeanUtil.setWText(tf_nd, P3040000.getMesg(LangRes.P304941C));
        // BeanUtil.setWTips(tf_nd, P3040000.getMesg(LangRes.P3049416));

        // 每日
        BeanUtil.setWText(rb_d1, P3040000.getMesg(LangRes.P304970D));
        BeanUtil.setWTips(rb_d1, P3040000.getMesg(LangRes.P304970E));

        // 每隔
        BeanUtil.setWText(rb_d2, P3040000.getMesg(LangRes.P304970F));
        BeanUtil.setWTips(rb_d2, P3040000.getMesg(LangRes.P3049710));

        BeanUtil.setWText(lb_nd, P3040000.getMesg(LangRes.P304931B));
        // BeanUtil.setWTips(lb_nd, P3040000.getMesg(LangRes.P3049416));

        // 其它
        BeanUtil.setWText(rb_d3, P3040000.getMesg(LangRes.P3049711));
        BeanUtil.setWTips(rb_d3, P3040000.getMesg(LangRes.P3049712));
    }

    /**
     * 提示周（月）
     */
    private void itg()
    {
        // 提示日期周期
        BeanUtil.setWText(lb_tz, P3040000.getMesg(LangRes.P304932A));
        // BeanUtil.setWTips(lb_tm, P3040000.getMesg(LangRes.P3049311));

        // 日期
        BeanUtil.setWText(lb_fz, P3040000.getMesg(LangRes.P304932B));
        // BeanUtil.setWTips(lb_fz, P3040000.getMesg(LangRes.P3049312));

        // 日期公式
        BeanUtil.setWText(tf_fz, P3040000.getMesg(LangRes.P3049415));
        // BeanUtil.setWTips(tf_fz, P3040000.getMesg(LangRes.P3049416));

        // 每隔日期
        BeanUtil.setWText(tf_nz, P3040000.getMesg(LangRes.P304941C));
        // BeanUtil.setWTips(tf_nz, P3040000.getMesg(LangRes.P3049416));

        // 每日
        BeanUtil.setWText(rb_z1, P3040000.getMesg(LangRes.P3049719));
        BeanUtil.setWTips(rb_z1, P3040000.getMesg(LangRes.P304971A));

        // 每隔
        BeanUtil.setWText(rb_z2, P3040000.getMesg(LangRes.P304971B));
        BeanUtil.setWTips(rb_z2, P3040000.getMesg(LangRes.P304971C));

        BeanUtil.setWText(lb_nz, P3040000.getMesg(LangRes.P304931B));
        // BeanUtil.setWTips(lb_nz, P3040000.getMesg(LangRes.P3049416));

        // 其它
        BeanUtil.setWText(rb_z3, P3040000.getMesg(LangRes.P304971D));
        BeanUtil.setWTips(rb_z3, P3040000.getMesg(LangRes.P304971E));
    }

    /**
     * 提示周（年）
     */
    private void ith()
    {
        // 提示日期周期
        BeanUtil.setWText(lb_tw, P3040000.getMesg(LangRes.P3049327));
        // BeanUtil.setWTips(lb_tm, P3040000.getMesg(LangRes.P3049311));

        // 日期
        BeanUtil.setWText(lb_fw, P3040000.getMesg(LangRes.P3049328));
        // BeanUtil.setWTips(lb_fd, P3040000.getMesg(LangRes.P3049312));

        // 日期公式
        BeanUtil.setWText(tf_fw, P3040000.getMesg(LangRes.P304941B));
        // BeanUtil.setWTips(tf_fd, P3040000.getMesg(LangRes.P3049416));

        // 每隔日期
        BeanUtil.setWText(tf_nw, P3040000.getMesg(LangRes.P304941C));
        // BeanUtil.setWTips(tf_nw, P3040000.getMesg(LangRes.P3049416));

        // 每日
        BeanUtil.setWText(rb_w1, P3040000.getMesg(LangRes.P3049713));
        BeanUtil.setWTips(rb_w1, P3040000.getMesg(LangRes.P3049714));

        // 每隔
        BeanUtil.setWText(rb_w2, P3040000.getMesg(LangRes.P3049715));
        BeanUtil.setWTips(rb_w2, P3040000.getMesg(LangRes.P3049716));

        BeanUtil.setWText(lb_nw, P3040000.getMesg(LangRes.P304931B));
        // BeanUtil.setWTips(lb_nw, P3040000.getMesg(LangRes.P3049416));

        // 其它
        BeanUtil.setWText(rb_w3, P3040000.getMesg(LangRes.P3049717));
        BeanUtil.setWTips(rb_w3, P3040000.getMesg(LangRes.P3049718));
    }

    /**
     * 节日结束日期
     */
    private void iti()
    {
        // 节日起始年份
        BeanUtil.setWText(lb_te, P3040000.getMesg(LangRes.P304931D));
        // BeanUtil.setWTips(lb_ts, P3040000.getMesg(LangRes.P3049304));

        // 年
        BeanUtil.setWText(lb_ey, P3040000.getMesg(LangRes.P304931F));
        BeanUtil.setWText(tf_ey, P3040000.getMesg(LangRes.P304941D));
        BeanUtil.setWTips(tf_ey, P3040000.getMesg(LangRes.P304941E));

        // 月
        BeanUtil.setWText(lb_em, P3040000.getMesg(LangRes.P3049320));
        BeanUtil.setWText(tf_em, P3040000.getMesg(LangRes.P304941F));
        BeanUtil.setWTips(tf_em, P3040000.getMesg(LangRes.P3049420));

        // 日
        BeanUtil.setWText(lb_ed, P3040000.getMesg(LangRes.P3049321));
        BeanUtil.setWText(tf_ed, P3040000.getMesg(LangRes.P3049421));
        BeanUtil.setWTips(tf_ed, P3040000.getMesg(LangRes.P3049422));

        // 周（年）
        BeanUtil.setWText(lb_ew, P3040000.getMesg(LangRes.P3049322));
        BeanUtil.setWText(tf_ew, P3040000.getMesg(LangRes.P3049423));
        BeanUtil.setWTips(tf_ew, P3040000.getMesg(LangRes.P3049424));

        // 周（月）
        BeanUtil.setWText(lb_ez, P3040000.getMesg(LangRes.P3049323));
        BeanUtil.setWText(tf_ez, P3040000.getMesg(LangRes.P3049425));
        BeanUtil.setWTips(tf_ez, P3040000.getMesg(LangRes.P3049426));
    }

    /**
     * 其它信息
     */
    private void itj()
    {
        BeanUtil.setWText(lb_LinkAddr, P3040000.getMesg(LangRes.P3049324));
        // BeanUtil.setWTips(lb_LinkAddr, P3040000.getMesg(LangRes.P3049426));

        BeanUtil.setWText(tf_LinkAddr, P3040000.getMesg(LangRes.P3049427));
        BeanUtil.setWTips(tf_LinkAddr, P3040000.getMesg(LangRes.P3049428));

        BeanUtil.setWText(lb_IdioMark, P3040000.getMesg(LangRes.P3049324));
        // BeanUtil.setWTips(lb_IdioMark, P3040000.getMesg(LangRes.P3049426));

        BeanUtil.setWText(ta_IdioMark, P3040000.getMesg(LangRes.P3049429));
        BeanUtil.setWTips(ta_IdioMark, P3040000.getMesg(LangRes.P304942A));
    }

    /**
     * 添加成功
     */
    private void itk()
    {
        BeanUtil.setWText(lb_NoteAddOK, P3040000.getMesg(LangRes.P3049326));
    }

    /**
     * 提示标题用户输入数据检测<br />
     * 提示标题不能为空
     * 
     * @return
     */
    private boolean ivb()
    {
        String t = tf_NoteHead.getText();
        if (!CharUtil.isValidate(t))
        {
            MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A01));
            tf_NoteHead.requestFocus();
            return false;
        }
        if (!CharUtil.isValidate(t, PrpCons.P3040118_SIZE))
        {
            MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A02), PrpCons.P3040118_SIZE));
            tf_NoteHead.requestFocus();
            return false;
        }
        t = ta_NoteInfo.getText();
        if (!CharUtil.isValidate(t, PrpCons.P3040119_SIZE))
        {
            MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A02), PrpCons.P3040118_SIZE));
            ta_NoteInfo.requestFocus();
            return false;
        }
        return true;
    }

    /**
     * 起始时间数据合法性检测<br />
     * 用户是否输入非法数值或字符
     * 
     * @return
     */
    private boolean ivc()
    {
        String t = tf_sy.getText();
        // 年份
        if (!CharUtil.isValidate(t, PrpCons.P3040106_SIZE))
        {
            MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A04), PrpCons.P3040106_SIZE));
            tf_sm.requestFocus();
            return false;
        }
        if (!Util.validate(t, ConstUI.PARAM_Y_E, ConstUI.PARAM_Y_C))
        {
            MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A05));
            tf_sm.requestFocus();
            return false;
        }

        // 月份
        if (tf_sm.isEnabled())
        {
            t = tf_sm.getText();
            if (!CharUtil.isValidate(t, PrpCons.P3040107_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A06), PrpCons.P3040107_SIZE));
                tf_sm.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_M_E, ConstUI.PARAM_M_C))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A07));
                tf_sm.requestFocus();
                return false;
            }
        }

        // 年周
        if (tf_sw.isEnabled())
        {
            t = tf_sw.getText();
            if (!CharUtil.isValidate(t, PrpCons.P3040109_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A0A), PrpCons.P3040109_SIZE));
                tf_sw.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_W_Y, ConstUI.PARAM_W_Y))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A0B));
                tf_sw.requestFocus();
                return false;
            }
        }

        // 日期
        if (tf_sd.isEnabled())
        {
            t = tf_sd.getText();
            if (!CharUtil.isValidate(t, PrpCons.P3040108_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A08), PrpCons.P3040108_SIZE));
                tf_sd.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_D_E, ConstUI.PARAM_D_C))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A09));
                tf_sd.requestFocus();
                return false;
            }
        }

        // 月周
        if (tf_sz.isEnabled())
        {
            t = tf_sz.getText();
            if (!CharUtil.isValidate(t, PrpCons.P304010A_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A0C), PrpCons.P304010A_SIZE));
                tf_sz.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_W_M, ConstUI.PARAM_W_M))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A0D));
                tf_sz.requestFocus();
                return false;
            }
        }
        return true;
    }

    /**
     * 提示年份用户输入数据检测<br />
     * 提示年份不能为空
     * 
     * @return
     */
    private boolean ivd()
    {
        String t = tf_fy.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_fy.requestFocus();
            return false;
        }
        if (!CharUtil.isValidate(t, PrpCons.P304010C_SIZE))
        {
            tf_fy.requestFocus();
            return false;
        }
        if (!Util.validate(t, ConstUI.PARAM_Y_E, ConstUI.PARAM_Y_C))
        {
            MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A05));
            tf_fy.requestFocus();
            return false;
        }
        return true;
    }

    /**
     * 提示月份用户输入数据检测<br />
     * 提示月份不能为空
     * 
     * @return
     */
    private boolean ive()
    {
        String t = tf_fm.getText();
        if (!CharUtil.isValidate(t, PrpCons.P304010D_SIZE))
        {
            tf_fm.requestFocus();
            return false;
        }
        if (!Util.validate(t, ConstUI.PARAM_M_E, ConstUI.PARAM_M_C))
        {
            MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A05));
            tf_fm.requestFocus();
            return false;
        }
        return true;
    }

    /**
     * 提示日期用户输入数据检测<br />
     * 提示日期不能为空
     * 
     * @return
     */
    private boolean ivf()
    {
        return true;
    }

    private boolean ivg()
    {
        return true;
    }

    private boolean ivh()
    {
        return true;
    }

    /**
     * 结束日期用户输入数据检测<br />
     * 用户是否输入合法字符及数据
     * 
     * @return
     */
    private boolean ivi()
    {
        String t = tf_ey.getText();
        // 年份
        if (!CharUtil.isValidate(t, PrpCons.P3040106_SIZE))
        {
            MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A04), PrpCons.P3040106_SIZE));
            tf_em.requestFocus();
            return false;
        }
        if (!Util.validate(t, ConstUI.PARAM_Y_E, ConstUI.PARAM_Y_C))
        {
            MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A05));
            tf_em.requestFocus();
            return false;
        }

        // 月份
        if (tf_em.isEnabled())
        {
            t = tf_em.getText();
            if (!CharUtil.isValidate(t, PrpCons.P3040107_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A06), PrpCons.P3040107_SIZE));
                tf_em.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_M_E, ConstUI.PARAM_M_C))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A07));
                tf_em.requestFocus();
                return false;
            }
        }

        // 年周
        if (tf_ew.isEnabled())
        {
            t = tf_ew.getText();
            if (!CharUtil.isValidate(t, PrpCons.P3040109_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A0A), PrpCons.P3040109_SIZE));
                tf_ew.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_W_Y, ConstUI.PARAM_W_Y))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A0B));
                tf_ew.requestFocus();
                return false;
            }
        }

        // 日期
        if (tf_ed.isEnabled())
        {
            t = tf_ed.getText();
            if (!CharUtil.isValidate(t, PrpCons.P3040108_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A08), PrpCons.P3040108_SIZE));
                tf_ed.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_D_E, ConstUI.PARAM_D_C))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A09));
                tf_ed.requestFocus();
                return false;
            }
        }

        // 月周
        if (tf_ez.isEnabled())
        {
            t = tf_ez.getText();
            if (!CharUtil.isValidate(t, PrpCons.P304010A_SIZE))
            {
                MesgUtil.showMessageDialog(this, CharUtil.format(P3040000.getMesg(LangRes.P3049A0C), PrpCons.P304010A_SIZE));
                tf_ez.requestFocus();
                return false;
            }
            if (!Util.validate(t, ConstUI.PARAM_W_M, ConstUI.PARAM_W_M))
            {
                MesgUtil.showMessageDialog(this, P3040000.getMesg(LangRes.P3049A0D));
                tf_ez.requestFocus();
                return false;
            }
        }
        return true;
    }

    /**
     * 相关说明用户输入合法性检测<br />
     * 用户输入数据是否超长
     * 
     * @return
     */
    private boolean ivj()
    {
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面构件事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 取消按钮事件处理
     * 
     * @param evt
     */
    private void bt_ExitButnActionPerformed(java.awt.event.ActionEvent evt)
    {
        // this.getRootForm().setVisible(false);
        // this.getRootForm().dispose();
    }

    /**
     * 下一步按钮事件处理
     * 
     * @param evt
     */
    private void bt_NextStepActionPerformed(java.awt.event.ActionEvent evt)
    {
        switch (currStep)
        {
            // 提示信息
            case ConstUI.STEP_NOTE:
                if (!ivb())
                {
                    return;
                }
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049402));
                bt_PrevStep.setVisible(true);
                currStep += 1;
                break;
            // 起始日期
            case ConstUI.STEP_SDATE:
                // 起始日期不做任何限制
                if (!ivc())
                {
                    return;
                }
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049403));
                currStep += 1;
                break;
            // 提示年份
            case ConstUI.STEP_FYEAR:
                // 提示年份不能为空
                if (!ivd())
                {
                    return;
                }
                tf_fm.setText(Integer.toString(Util.getMonth()));
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049404));
                currStep += 1;
                break;
            // 提示月份
            case ConstUI.STEP_FMONTH:
                // 月份不为空，则进行日期输入界面
                if (CharUtil.isValidate(tf_fm.getText()))
                {
                    tf_fw.setText("");
                    if (!ive())
                    {
                        return;
                    }
                    tf_fd.setText(Integer.toString(Util.getDay()));
                    ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049405));
                    currStep += 1;
                }
                // 月份为空，则进行年周输入界面
                else
                {
                    ta_NoteInfo.setText(P3040000.getMesg(LangRes.P304942B));
                    currStep = ConstUI.STEP_FWEEKOFYEAR;
                }
                break;
            case ConstUI.STEP_FDATE:
                // 日期不为空，则进入结束日期输入界面
                if (CharUtil.isValidate(tf_fd.getText()))
                {
                    tf_fz.setText("");
                    if (!ivf())
                    {
                        return;
                    }
                    ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049406));
                    currStep = ConstUI.STEP_EDATE;
                }
                // 日期为空，则进入月周输入界面
                else
                {
                    ta_NoteInfo.setText(P3040000.getMesg(LangRes.P304942C));
                    currStep += 1;
                }
                break;
            // 月周提示
            case ConstUI.STEP_FWEEKOFMONTH:
                // 月周通过，则进行结束日期输入界面
                if (!ivg())
                {
                    return;
                }
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049406));
                currStep = ConstUI.STEP_EDATE;
                break;
            // 年周提示
            case ConstUI.STEP_FWEEKOFYEAR:
                if (!ivh())
                {
                    return;
                }
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049406));
                currStep += 1;
                break;
            // 结束日期
            case ConstUI.STEP_EDATE:
                // 结束日期不做任何限制
                if (!ivi())
                {
                    return;
                }
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049407));
                currStep += 1;
                break;
            case ConstUI.STEP_DESP:
                if (!ivj())
                {
                    return;
                }
                saveData();
                bt_PrevStep.setVisible(false);
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049408));
                BeanUtil.setWText(bt_NextStep, P3040000.getMesg(LangRes.P3049507));
                BeanUtil.setWText(bt_NextStep, P3040000.getMesg(LangRes.P3049508));
                BeanUtil.setWText(bt_ExitButn, P3040000.getMesg(LangRes.P3049509));
                BeanUtil.setWText(bt_ExitButn, P3040000.getMesg(LangRes.P304950A));
                currStep += 1;
                break;
            case ConstUI.STEP_END:
                currStep = 0;
                ta_NoteInfo.setText(P3040000.getMesg(LangRes.P3049401));
                break;
            default:
                break;
        }

        cl_CardPanl.show(pl_CardPanl, ConstUI.CARD_STEP + currStep);
    }

    /**
     * 上一步按钮事件处理
     * 
     * @param evt
     */
    private void bt_PrevStepActionPerformed(java.awt.event.ActionEvent evt)
    {
        switch (currStep)
        {
            // 添加成功
            case ConstUI.STEP_END:
                break;
            // 相关说明
            case ConstUI.STEP_DESP:
                currStep -= 1;
                break;
            // 结束日期
            case ConstUI.STEP_EDATE:
                if (CharUtil.isValidate(tf_fw.getText()))
                {
                    currStep -= 1;
                }
                else if (CharUtil.isValidate(tf_fz.getText()))
                {
                    currStep = ConstUI.STEP_FWEEKOFMONTH;
                }
                else
                {
                    currStep = ConstUI.STEP_FDATE;
                }
                break;
            // 年周提示
            case ConstUI.STEP_FWEEKOFYEAR:
                currStep = ConstUI.STEP_FYEAR;
                break;
            // 月周提示
            case ConstUI.STEP_FWEEKOFMONTH:
                currStep = ConstUI.STEP_FMONTH;
                break;
            // 提示日期
            case ConstUI.STEP_FDATE:
                currStep -= 1;
                break;
            // 提示月份
            case ConstUI.STEP_FMONTH:
                currStep -= 1;
                break;
            // 提示年份
            case ConstUI.STEP_FYEAR:
                currStep -= 1;
                break;
            // 起始日期
            case ConstUI.STEP_SDATE:
                bt_PrevStep.setVisible(false);
                currStep -= 1;
                break;
            // 提示信息
            case ConstUI.STEP_NOTE:
                break;
            default:
                break;
        }

        cl_CardPanl.show(pl_CardPanl, ConstUI.CARD_STEP + currStep);
    }

    /**
     * 每年单选按钮事件处理
     * 
     * @param evt
     */
    private void rb_y1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fy.setText(ConstUI.FORMULA_Y_E);
        tf_fy.setEditable(false);
    }

    /**
     * 每隔单选按钮事件处理
     * 
     * @param evt
     */
    private void rb_y2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fy.setText(CharUtil.format(ConstUI.FORMULA_Y_N, tf_ny.getText(), "" + Util.getYear()));
        tf_fy.setEditable(false);
    }

    /**
     * 其它单选按钮事件处理
     * 
     * @param evt
     */
    private void rb_y3ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fy.setEditable(true);
    }

    /**
     * 每隔文本框事件处理
     * 
     * @param evt
     */
    private void tf_nyFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_ny.getText();
        if (!Util.validate(t, ".", "."))
        {
            t = "1";
            tf_ny.setText(t);
        }
        tf_fy.setText(CharUtil.format(ConstUI.FORMULA_Y_N, "" + Util.getYear(), t));
    }

    /**
     * @param evt
     */
    private void rb_m1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fm.setText(ConstUI.FORMULA_M_E);
        tf_fm.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_m2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fm.setText(CharUtil.format(ConstUI.FORMULA_M_N, tf_nm.getText(), "" + Util.getMonth()));
        tf_fm.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_m3ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fm.setEditable(true);
    }

    /**
     * @param evt
     */
    private void tf_nmFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_nm.getText();
        if (!Util.validate(t, ".", "."))
        {
            t = "" + Util.getMonth();
            tf_nm.setText(t);
        }
        tf_fm.setText(t);
    }

    /**
     * @param evt
     */
    private void rb_d1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fd.setText(ConstUI.FORMULA_D_E);
        tf_fd.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_d2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fd.setText(CharUtil.format(ConstUI.FORMULA_D_N, tf_nd.getText(), "" + Util.getDay()));
        tf_fd.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_d3ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fd.setEditable(true);
    }

    /**
     * @param evt
     */
    private void tf_ndFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_nd.getText();
        if (!Util.validate(t, ".", "."))
        {
            t = "" + Util.getDay();
            tf_nd.setText(t);
        }
        tf_fd.setText(t);
    }

    /**
     * @param evt
     */
    private void rb_w1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fw.setText(ConstUI.FORMULA_W_E);
        tf_fw.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_w2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fw.setText(CharUtil.format(ConstUI.FORMULA_W_N, tf_nw.getText(), "1"));
        tf_fw.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_w3ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fw.setEditable(true);
    }

    /**
     * @param evt
     */
    private void tf_nwFocusLost(java.awt.event.FocusEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void rb_z1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fz.setText(ConstUI.FORMULA_Z_E);
        tf_fz.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_z2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fz.setText(CharUtil.format(ConstUI.FORMULA_Z_N, tf_nz.getText(), "1"));
        tf_fz.setEditable(false);
    }

    /**
     * @param evt
     */
    private void rb_z3ActionPerformed(java.awt.event.ActionEvent evt)
    {
        tf_fz.setEditable(true);
    }

    /**
     * @param evt
     */
    private void tf_nzFocusLost(java.awt.event.FocusEvent evt)
    {
    }

    /**
     * 起始月份文本框焦点失去事件处理
     * 
     * @param evt
     */
    private void tf_smFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_sm.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_sw.setEnabled(true);
            return;
        }
        tf_sw.setText("");
        tf_sw.setEnabled(false);
        tf_sd.requestFocus();
    }

    /**
     * 起始周（年）文本框失去焦点事件处理
     * 
     * @param evt
     */
    private void tf_swFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_sw.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_sm.setEnabled(true);
            tf_sz.setEnabled(true);
            return;
        }
        tf_sm.setText("");
        tf_sm.setEnabled(false);
        tf_sz.setText("");
        tf_sz.setEnabled(false);
        tf_sd.requestFocus();
    }

    /**
     * 起始周（月）文本框失去焦点事件处理
     * 
     * @param evt
     */
    private void tf_szFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_sz.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_sw.setEnabled(true);
            return;
        }
        tf_sw.setText("");
        tf_sw.setEnabled(false);
    }

    /**
     * @param evt
     */
    private void tf_emFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_em.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_ew.setEnabled(true);
            return;
        }
        tf_ew.setText("");
        tf_ew.setEnabled(false);
    }

    /**
     * @param evt
     */
    private void tf_ewFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_ew.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_em.setEnabled(true);
            tf_ez.setEnabled(true);
            return;
        }
        tf_em.setText("");
        tf_em.setEnabled(false);
        tf_ez.setText("");
        tf_ez.setEnabled(false);

    }

    /**
     * @param evt
     */
    private void tf_ezFocusLost(java.awt.event.FocusEvent evt)
    {
        String t = tf_ez.getText();
        if (!CharUtil.isValidate(t))
        {
            tf_ew.setEnabled(true);
            return;
        }
        tf_ew.setText("");
        tf_ew.setEnabled(false);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 添加数据
     */
    private void saveData()
    {
        DBAccess dba = new DBAccess();

        try
        {
            dba.wInit();

            dba.addTable(PrpCons.P3040100);
            dba.addParam(PrpCons.P3040101, "0", false);
            dba.addParam(PrpCons.P3040102, "2");
            dba.addParam(PrpCons.P3040103, HashUtil.getCurrTimeHex(false));
            dba.addParam(PrpCons.P3040104, SysCons.UI_LANGHASH);
            dba.addParam(PrpCons.P3040105, "0");
            dba.addParam(PrpCons.P3040106, tf_sy.getText());
            dba.addParam(PrpCons.P3040107, tf_sm.isEnabled() ? tf_sm.getText() : "");
            dba.addParam(PrpCons.P3040108, tf_sd.getText());
            dba.addParam(PrpCons.P3040109, tf_sw.isEnabled() ? tf_sw.getText() : "");
            dba.addParam(PrpCons.P304010A, tf_sz.isEnabled() ? tf_sz.getText() : "");
            dba.addParam(PrpCons.P304010B, "NOW", false);
            dba.addParam(PrpCons.P304010C, tf_fy.getText());
            dba.addParam(PrpCons.P304010D, tf_fm.getText());
            dba.addParam(PrpCons.P304010E, tf_fd.getText());
            dba.addParam(PrpCons.P304010F, tf_fw.getText());
            dba.addParam(PrpCons.P3040110, tf_fz.getText());
            dba.addParam(PrpCons.P3040111, "NOW", false);
            dba.addParam(PrpCons.P3040112, tf_ey.getText());
            dba.addParam(PrpCons.P3040113, tf_em.isEnabled() ? tf_em.getText() : "");
            dba.addParam(PrpCons.P3040114, tf_ed.getText());
            dba.addParam(PrpCons.P3040115, tf_ew.isEnabled() ? tf_ew.getText() : "");
            dba.addParam(PrpCons.P3040116, tf_ez.isEnabled() ? tf_ez.getText() : "");
            dba.addParam(PrpCons.P3040117, "NOW", false);
            dba.addParam(PrpCons.P3040118, tf_NoteHead.getText());
            dba.addParam(PrpCons.P3040119, ta_NoteInfo.getText());
            dba.addParam(PrpCons.P304011A, tf_LinkAddr.getText());
            dba.addParam(PrpCons.P304011B, ta_NoteDesp.getText());
            dba.addParam(PrpCons.P304011C, "NOW", false);
            dba.addParam(PrpCons.P304011D, "NOW", false);

            dba.executeInsert();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.close();
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面视图构件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JButton bt_ExitButn;
    private javax.swing.JButton bt_NextStep;
    private javax.swing.JButton bt_PrevStep;
    private javax.swing.JPanel pl_CardPanl;
    private javax.swing.JTextArea ta_NoteInfo;
    // 提示文本
    private javax.swing.JLabel lb_NoteHead;
    private javax.swing.JLabel lb_NoteInfo;
    private javax.swing.JTextArea ta_NoteDesp;
    private javax.swing.JTextField tf_NoteHead;
    // 起始时间
    private javax.swing.JLabel lb_sd;
    private javax.swing.JLabel lb_sm;
    private javax.swing.JLabel lb_sw;
    private javax.swing.JLabel lb_sy;
    private javax.swing.JLabel lb_sz;
    private javax.swing.JLabel lb_ts;
    private javax.swing.JTextField tf_sd;
    private javax.swing.JTextField tf_sm;
    private javax.swing.JTextField tf_sw;
    private javax.swing.JTextField tf_sy;
    private javax.swing.JTextField tf_sz;
    // 年份面板
    private javax.swing.JLabel lb_ny;
    private javax.swing.JLabel lb_fy;
    private javax.swing.JLabel lb_ty;
    private javax.swing.JRadioButton rb_y1;
    private javax.swing.JRadioButton rb_y2;
    private javax.swing.JRadioButton rb_y3;
    private javax.swing.JTextField tf_fy;
    private javax.swing.JTextField tf_ny;
    // 月份面板
    private javax.swing.JLabel lb_nm;
    private javax.swing.JLabel lb_fm;
    private javax.swing.JLabel lb_tm;
    private javax.swing.JRadioButton rb_m1;
    private javax.swing.JRadioButton rb_m2;
    private javax.swing.JRadioButton rb_m3;
    private javax.swing.JTextField tf_fm;
    private javax.swing.JTextField tf_nm;
    // 日期面板
    private javax.swing.JLabel lb_nd;
    private javax.swing.JLabel lb_fd;
    private javax.swing.JLabel lb_td;
    private javax.swing.JRadioButton rb_d1;
    private javax.swing.JRadioButton rb_d2;
    private javax.swing.JRadioButton rb_d3;
    private javax.swing.JTextField tf_fd;
    private javax.swing.JTextField tf_nd;
    // 年周面板
    private javax.swing.JLabel lb_nw;
    private javax.swing.JLabel lb_fw;
    private javax.swing.JLabel lb_tw;
    private javax.swing.JRadioButton rb_w1;
    private javax.swing.JRadioButton rb_w2;
    private javax.swing.JRadioButton rb_w3;
    private javax.swing.JTextField tf_fw;
    private javax.swing.JTextField tf_nw;
    // 月周面板
    private javax.swing.JLabel lb_nz;
    private javax.swing.JLabel lb_fz;
    private javax.swing.JLabel lb_tz;
    private javax.swing.JRadioButton rb_z1;
    private javax.swing.JRadioButton rb_z2;
    private javax.swing.JRadioButton rb_z3;
    private javax.swing.JTextField tf_fz;
    private javax.swing.JTextField tf_nz;
    // 结束时间
    private javax.swing.JLabel lb_ed;
    private javax.swing.JLabel lb_em;
    private javax.swing.JLabel lb_ew;
    private javax.swing.JLabel lb_ey;
    private javax.swing.JLabel lb_ez;
    private javax.swing.JLabel lb_te;
    private javax.swing.JTextField tf_ed;
    private javax.swing.JTextField tf_em;
    private javax.swing.JTextField tf_ew;
    private javax.swing.JTextField tf_ey;
    private javax.swing.JTextField tf_ez;
    // 其它信息
    private javax.swing.JLabel lb_IdioMark;
    private javax.swing.JLabel lb_LinkAddr;
    private javax.swing.JTextArea ta_IdioMark;
    private javax.swing.JTextField tf_LinkAddr;
    private javax.swing.JLabel lb_NoteAddOK;
}
