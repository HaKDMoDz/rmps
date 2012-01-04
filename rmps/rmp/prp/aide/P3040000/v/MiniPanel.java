/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.v;

import java.awt.Dimension;
import java.util.List;

import javax.swing.SwingUtilities;

import rmp.bean.K1IV2S;
import rmp.face.WBean;
import rmp.prp.aide.P3040000.P3040000;
import rmp.prp.aide.P3040000.b.MiniLabel;
import rmp.prp.aide.P3040000.b.TipsMenu;
import rmp.prp.aide.P3040000.b.WeekLabel;
import rmp.prp.aide.P3040000.lunar.Chinese;
import rmp.prp.aide.P3040000.solar.Gregorian;
import rmp.prp.aide.P3040000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.DateUtil;

import com.amonsoft.util.CharUtil;

import cons.prp.aide.P3040000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 迷你视图，以尽量精简的方式显示日历视图，仅提供一些简约而又重要的提醒或节日信息
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel implements WBean
{
    /** 用户上一次选择的日期标签 */
    private MiniLabel dl_LastDays;
    /** 转到今日标签 */
    private MiniLabel dl_ThisDays;
    /** 提示数据管理 */
    private MiniLabel dl_DataMngr;
    /** 快捷提示菜单 */
    private TipsMenu tm_TipsMenu;
    /** 一周第一天是星期几 */
    private int weekOfDays1;
    /**  */
    private P3040000 ms_MainSoft;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    public MiniPanel(P3040000 soft)
    {
        this.ms_MainSoft = soft;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
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

        // 显示今日
        if (Util.getYear() == 0)
        {
            Util.setDate();
        }
        initMonthView();
        initMonthData();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        pl_DatePanel = new javax.swing.JPanel();
        pl_DatePanel.setLayout(new java.awt.GridLayout(7, 7, 1, 1));

        // 标题标签
        WeekLabel wl;
        wl_WeekLabl = new WeekLabel[7];
        for (int i = 0; i < 7; i += 1)
        {
            wl = new WeekLabel();
            wl.wInit();
            pl_DatePanel.add(wl);
            wl_WeekLabl[i] = wl;
        }

        // 日期标签事件
        java.awt.event.MouseAdapter msEvt = new java.awt.event.MouseAdapter()
        {
            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                dl_DaysLablMouseReleased(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                dl_DaysLablMouseEntered(evt);
            }
        };

        // 日期标签
        MiniLabel dl;
        dl_DaysLabl = new MiniLabel[42];
        for (int i = 1; i < 41; i += 1)
        {
            dl = new MiniLabel();
            dl.wInit();
            dl.addMouseListener(msEvt);
            pl_DatePanel.add(dl);
            dl_DaysLabl[i] = dl;
        }

        // 管理
        dl_DataMngr = new MiniLabel();
        dl_DataMngr.wInit();
        pl_DatePanel.add(dl_DataMngr);
        dl_DataMngr.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                dl_DataMngr_Handler(evt);
            }
        });
        dl_DaysLabl[41] = dl_DataMngr;

        // 今日
        dl_ThisDays = new MiniLabel();
        dl_ThisDays.wInit();
        pl_DatePanel.add(dl_ThisDays);
        dl_ThisDays.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                dl_ThisDays_Handler(evt);
            }
        });
        dl_DaysLabl[0] = dl_ThisDays;
    }

    /**
     * 
     */
    private void icb()
    {
        lb_CurrDate = new javax.swing.JLabel();
        bt_PrevYear = new javax.swing.JButton();
        bt_PrevMnth = new javax.swing.JButton();
        bt_NextYear = new javax.swing.JButton();
        bt_NextMnth = new javax.swing.JButton();

        lb_CurrDate.setHorizontalAlignment(javax.swing.JLabel.CENTER);

        bt_PrevYear.setFocusable(false);
        bt_PrevYear.setMargin(new java.awt.Insets(1, 2, 1, 2));
        bt_PrevYear.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LastYear_Handler(evt);
            }
        });

        bt_PrevMnth.setFocusable(false);
        bt_PrevMnth.setMargin(new java.awt.Insets(1, 2, 1, 2));
        bt_PrevMnth.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LastMnth_Handler(evt);
            }
        });

        bt_NextYear.setFocusable(false);
        bt_NextYear.setMargin(new java.awt.Insets(1, 2, 1, 2));
        bt_NextYear.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_NextYear_Handler(evt);
            }
        });

        bt_NextMnth.setFocusable(false);
        bt_NextMnth.setMargin(new java.awt.Insets(1, 2, 1, 2));
        bt_NextMnth.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_NextMnth_Handler(evt);
            }
        });

        addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                mp_MiniPanelMouseEntered(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_DatePanel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                Short.MAX_VALUE).addGroup(
                                layout.createSequentialGroup().addComponent(bt_PrevYear).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_PrevMnth).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_CurrDate, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE,
                                        Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextMnth).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_NextYear))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.CENTER).addComponent(lb_CurrDate, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_PrevYear).addComponent(bt_PrevMnth).addComponent(bt_NextYear).addComponent(
                                        bt_NextMnth))).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_DatePanel, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(wl_WeekLabl[0], P3040000.getMesg(LangRes.P3041301));
        BeanUtil.setWTips(wl_WeekLabl[0], P3040000.getMesg(LangRes.P3041302));

        BeanUtil.setWText(wl_WeekLabl[1], P3040000.getMesg(LangRes.P3041303));
        BeanUtil.setWTips(wl_WeekLabl[1], P3040000.getMesg(LangRes.P3041304));

        BeanUtil.setWText(wl_WeekLabl[2], P3040000.getMesg(LangRes.P3041305));
        BeanUtil.setWTips(wl_WeekLabl[2], P3040000.getMesg(LangRes.P3041306));

        BeanUtil.setWText(wl_WeekLabl[3], P3040000.getMesg(LangRes.P3041307));
        BeanUtil.setWTips(wl_WeekLabl[3], P3040000.getMesg(LangRes.P3041308));

        BeanUtil.setWText(wl_WeekLabl[4], P3040000.getMesg(LangRes.P3041309));
        BeanUtil.setWTips(wl_WeekLabl[4], P3040000.getMesg(LangRes.P304130A));

        BeanUtil.setWText(wl_WeekLabl[5], P3040000.getMesg(LangRes.P304130B));
        BeanUtil.setWTips(wl_WeekLabl[5], P3040000.getMesg(LangRes.P304130C));

        BeanUtil.setWText(wl_WeekLabl[6], P3040000.getMesg(LangRes.P304130D));
        BeanUtil.setWTips(wl_WeekLabl[6], P3040000.getMesg(LangRes.P304130E));
    }

    /**
     * 
     */
    private void itb()
    {
        BeanUtil.setWText(bt_PrevYear, P3040000.getMesg(LangRes.P3045501));
        BeanUtil.setWTips(bt_PrevYear, P3040000.getMesg(LangRes.P3045502));

        BeanUtil.setWText(bt_PrevMnth, P3040000.getMesg(LangRes.P3045503));
        BeanUtil.setWTips(bt_PrevMnth, P3040000.getMesg(LangRes.P3045504));

        BeanUtil.setWText(bt_NextMnth, P3040000.getMesg(LangRes.P3045505));
        BeanUtil.setWTips(bt_NextMnth, P3040000.getMesg(LangRes.P3045506));

        BeanUtil.setWText(bt_NextYear, P3040000.getMesg(LangRes.P3045507));
        BeanUtil.setWTips(bt_NextYear, P3040000.getMesg(LangRes.P3045508));

        // 转到今日
        BeanUtil.setWText(dl_ThisDays, P3040000.getMesg(LangRes.P3045301));
        BeanUtil.setWTips(dl_ThisDays, P3040000.getMesg(LangRes.P3045302));

        // 数据管理
        BeanUtil.setWText(dl_DaysLabl[41], P3040000.getMesg(LangRes.P3045303));
        BeanUtil.setWTips(dl_DaysLabl[41], P3040000.getMesg(LangRes.P3045304));

        // 用户配置
        // BeanUtil.setWText(dl_DaysLabl[40],
        // P3040000.getMesg(LangRes.P3045305));
        // BeanUtil.setWTips(dl_DaysLabl[40],
        // P3040000.getMesg(LangRes.P3045306));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_NextYear_Handler(java.awt.event.ActionEvent evt)
    {
        Util.addYear(1);
        initMonthView();
        initMonthData();
    }

    /**
     * @param evt
     */
    private void bt_NextMnth_Handler(java.awt.event.ActionEvent evt)
    {
        Util.addMonth(1);
        initMonthView();
        initMonthData();
    }

    /**
     * @param evt
     */
    private void bt_LastMnth_Handler(java.awt.event.ActionEvent evt)
    {
        Util.addMonth(-1);
        initMonthView();
        initMonthData();
    }

    /**
     * @param evt
     */
    private void bt_LastYear_Handler(java.awt.event.ActionEvent evt)
    {
        Util.addYear(-1);
        initMonthView();
        initMonthData();
    }

    /**
     * @param evt
     */
    private void dl_DaysLablMouseEntered(java.awt.event.MouseEvent evt)
    {
        MiniLabel label = (MiniLabel) evt.getSource();
        if (!CharUtil.isValidate(label.getText()))
        {
            return;
        }

        if (tm_TipsMenu == null)
        {
            tm_TipsMenu = new TipsMenu();
            tm_TipsMenu.wInit();
        }
        tm_TipsMenu.removeAll();

        // 公共节日
        tm_TipsMenu.setData(Util.getDate(label.getText()), label.getItem());

        // 中国节日
        Chinese chinese = new Chinese(new Gregorian(Util.getYear(), Util.getMonth(), 1).toFixed());
        tm_TipsMenu.setData(chinese.format(), null);

        Dimension s = label.getSize();
        tm_TipsMenu.show(label, s.width - 5, s.height - 5);
    }

    /**
     * @param evt
     */
    private void mp_MiniPanelMouseEntered(java.awt.event.MouseEvent evt)
    {
        if (tm_TipsMenu != null)
        {
            tm_TipsMenu.setVisible(false);
            tm_TipsMenu.removeAll();
        }
    }

    /**
     * @param evt
     */
    private void dl_DaysLablMouseReleased(java.awt.event.MouseEvent evt)
    {
        // 事件源标签设置选中状态
        MiniLabel dl = (MiniLabel) evt.getSource();

        // 上一次事件源标签设置未选中
        if (dl_LastDays != null)
        {
            dl_LastDays.setSelected(false);
        }

        dl.setSelected(true);
        Util.setDay(Integer.parseInt(dl.getText()));
        String t = Util.getDate();
        lb_CurrDate.setText(t);
        lb_CurrDate.setToolTipText(t);

        // 记录本次事件源
        dl_LastDays = dl;
    }

    /**
     * @param evt
     */
    private void dl_ThisDays_Handler(java.awt.event.MouseEvent evt)
    {
        Util.setDate();
        initMonthView();
        initMonthData();
    }

    /**
     * @param evt
     */
    private void dl_DataMngr_Handler(java.awt.event.MouseEvent evt)
    {
        ms_MainSoft.wShowView(P3040000.VIEW_STEP);
    }

    /**
     * 显示当前月视图
     */
    private void initMonthView()
    {
        weekOfDays1 = DateUtil.dayInWeek(Util.getYear(), Util.getMonth(), 1);
        int currDate = 1;
        while (currDate <= weekOfDays1)
        {
            dl_DaysLabl[currDate++].setText("");
        }
        int totlDays = DateUtil.daysOfMonth(Util.getYear(), Util.getMonth());
        for (int i = 1; i <= totlDays; i += 1)
        {
            dl_DaysLabl[weekOfDays1 + i].setText(Integer.toString(i));
        }
        totlDays += (weekOfDays1 + 1);
        while (totlDays < 40)
        {
            dl_DaysLabl[totlDays++].setText("");
        }
        if (dl_LastDays != null)
        {
            dl_LastDays.setSelected(false);
        }
        dl_LastDays = dl_DaysLabl[weekOfDays1 + Util.getDay()];
        dl_LastDays.setSelected(true);

        String t = Util.getDate();
        lb_CurrDate.setText(t);
        lb_CurrDate.setToolTipText(t);
    }

    /**
     * 显示当前月节日数据
     */
    private void initMonthData()
    {
        Runnable run = new Runnable()
        {
            public void run()
            {
                List<K1IV2S> dataList = Util.initViewDataByMonth();
                for (MiniLabel ml : dl_DaysLabl)
                {
                    ml.clear();
                }
                for (K1IV2S kv : dataList)
                {
                    dl_DaysLabl[weekOfDays1 + kv.getK()].addItem(kv);
                }
            }
        };
        SwingUtilities.invokeLater(run);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 界面构件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JLabel lb_CurrDate;
    private javax.swing.JPanel pl_DatePanel;
    private rmp.prp.aide.P3040000.b.WeekLabel wl_WeekLabl[];
    private rmp.prp.aide.P3040000.b.MiniLabel dl_DaysLabl[];
    private javax.swing.JButton bt_PrevMnth;
    private javax.swing.JButton bt_PrevYear;
    private javax.swing.JButton bt_NextMnth;
    private javax.swing.JButton bt_NextYear;
    /** serialVersionUID */
    private static final long serialVersionUID = 6890952986801867650L;
}
