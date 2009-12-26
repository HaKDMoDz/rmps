/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.v;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.util.EventObject;

import javax.swing.ImageIcon;

import rmp.face.WBackCall;
import rmp.prp.aide.P3040000.P3040000;
import rmp.prp.aide.P3040000.b.DateLabel;
import rmp.prp.aide.P3040000.b.WeekLabel;
import rmp.prp.aide.P3040000.lunar.Chinese;
import rmp.prp.aide.P3040000.solar.Gregorian;
import rmp.prp.aide.P3040000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.DateUtil;

import com.amonsoft.util.LogUtil;

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
public class TailPanel implements WBackCall
{
    /**  */
    private javax.swing.JPanel tp_TailPanel;
    /** 用户上一次选择的日期标签 */
    private DateLabel dl_LastDays;
    /** 转到今日标签 */
    private DateLabel dl_ThisDays;
    private ImageIcon ii_PrevImgD;
    private ImageIcon ii_PrevImgE;
    private ImageIcon ii_PrevImgP;
    private ImageIcon ii_NextImgD;
    private ImageIcon ii_NextImgE;
    private ImageIcon ii_NextImgP;
    private boolean isMonthView;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param tailPanel
     */
    public TailPanel(javax.swing.JPanel tailPanel)
    {
        this.tp_TailPanel = tailPanel;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    public boolean wInit()
    {
        try
        {
            // ii_PrevImgD = new
            // ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P3040000,
            // "ld.png"));
            // ii_PrevImgE = new
            // ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P3040000,
            // "le.png"));
            // ii_PrevImgP = new
            // ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P3040000,
            // "lp.png"));
            // ii_NextImgD = new
            // ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P3040000,
            // "rd.png"));
            // ii_NextImgE = new
            // ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P3040000,
            // "re.png"));
            // ii_NextImgP = new
            // ImageIcon(ImageUtil.readJarImage(EnvCons.PATH_P3040000,
            // "rp.png"));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        ica();
        ita();

        Util.register(ConstUI.BACK_K_TAILPANEL, this);

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object)
     */
    @Override
    public void wAction(EventObject event, Object object, String property)
    {
        if (ConstUI.BACK_V_DATEVIEW.equals(object))
        {
            tp_TailPanel.removeAll();
            ica();
            ita();
            isMonthView = false;
            return;
        }
        if (ConstUI.BACK_V_MONTHVIEW.equals(object))
        {
            tp_TailPanel.removeAll();
            icb();
            itb();
            isMonthView = true;
            return;
        }
        if (ConstUI.BACK_V_UPDATE.equals(object))
        {
            if (isMonthView)
            {
                initMonthView();
            }
            else
            {
                initDateView();
            }
        }
    }

    /**
     * 
     */
    private void ica()
    {
        dp_DatePanel = new DatePanel();
        dp_DatePanel.wInit();
        dp_DatePanel.setLayout(new BorderLayout());

        javax.swing.JPanel p1 = new javax.swing.JPanel();
        p1.setLayout(new GridLayout(0, 1));
        p1.setOpaque(false);

        p1.add(new javax.swing.JLabel("  "));

        javax.swing.JPanel p = new javax.swing.JPanel();
        p.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 0));
        p.setOpaque(false);
        p1.add(p);

        lb_PrevDate = new javax.swing.JLabel();
        lb_PrevDate.setIcon(ii_PrevImgD);
        lb_PrevDate.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                Util.addDay(-1);
                initDateView();
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent e)
            {
                lb_PrevDate.setIcon(ii_PrevImgE);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent e)
            {
                lb_PrevDate.setIcon(ii_PrevImgD);
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent e)
            {
                lb_PrevDate.setIcon(ii_PrevImgP);
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent e)
            {
                lb_PrevDate.setIcon(ii_PrevImgE);
            }
        });
        p.add(lb_PrevDate);

        lb_YearLabl = new javax.swing.JLabel();
        lb_YearLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        p.add(lb_YearLabl);

        lb_NextDate = new javax.swing.JLabel();
        lb_NextDate.setIcon(ii_NextImgD);
        lb_NextDate.setOpaque(false);
        lb_NextDate.setFocusable(false);
        lb_NextDate.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                Util.addDay(1);
                initDateView();
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent e)
            {
                lb_NextDate.setIcon(ii_NextImgE);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent e)
            {
                lb_NextDate.setIcon(ii_NextImgD);
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent e)
            {
                lb_NextDate.setIcon(ii_NextImgP);
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent e)
            {
                lb_NextDate.setIcon(ii_NextImgE);
            }
        });
        p.add(lb_NextDate);

        dp_DatePanel.add(p1, BorderLayout.NORTH);

        lb_DateLabl = new javax.swing.JLabel();
        lb_DateLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        lb_DateLabl.setFont(lb_DateLabl.getFont().deriveFont(60F));
        dp_DatePanel.add(lb_DateLabl, BorderLayout.CENTER);

        javax.swing.JPanel p2 = new javax.swing.JPanel();
        p2.setLayout(new GridLayout(0, 1));
        p2.setOpaque(false);

        lb_WeekLabl = new javax.swing.JLabel();
        lb_WeekLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        p2.add(lb_WeekLabl);
        lb_LunarLbl = new javax.swing.JLabel();
        lb_LunarLbl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        p2.add(lb_LunarLbl);
        dp_DatePanel.add(p2, BorderLayout.SOUTH);
        p2.add(new javax.swing.JLabel("  "));

        tp_TailPanel.setLayout(new BorderLayout());
        tp_TailPanel.add(dp_DatePanel);
    }

    /**
     * 
     */
    private void icb()
    {
        tp_TailPanel.setLayout(new java.awt.GridLayout(7, 7, 1, 1));

        // 标题标签
        WeekLabel wl;
        wl_WeekLabl = new WeekLabel[7];
        for (int i = 0; i < 7; i += 1)
        {
            wl = new WeekLabel();
            wl.wInit();
            tp_TailPanel.add(wl);
            wl_WeekLabl[i] = wl;
        }

        // 日期标签事件
        java.awt.event.MouseAdapter msEvt = new java.awt.event.MouseAdapter()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                dl_DaysLablMouseClicked(evt);
            }
        };

        // 日期标签
        DateLabel dl;
        dl_DaysLabl = new DateLabel[42];
        for (int i = 1; i < 42; i += 1)
        {
            dl = new DateLabel();
            dl.wInit();
            dl.addMouseListener(msEvt);
            tp_TailPanel.add(dl);
            dl_DaysLabl[i] = dl;
        }

        // 今日
        dl_ThisDays = new DateLabel();
        dl_ThisDays.wInit();
        tp_TailPanel.add(dl_ThisDays);
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
    private void ita()
    {
        if (Util.getYear() == 0)
        {
            Util.setDate();
        }

        initDateView();
    }

    /**
     * 语言资源初始化
     */
    private void itb()
    {
        BeanUtil.setWText(wl_WeekLabl[0], P3040000.getMesg(LangRes.P3044301));
        BeanUtil.setWTips(wl_WeekLabl[0], P3040000.getMesg(LangRes.P3044302));

        BeanUtil.setWText(wl_WeekLabl[1], P3040000.getMesg(LangRes.P3044303));
        BeanUtil.setWTips(wl_WeekLabl[1], P3040000.getMesg(LangRes.P3044304));

        BeanUtil.setWText(wl_WeekLabl[2], P3040000.getMesg(LangRes.P3044305));
        BeanUtil.setWTips(wl_WeekLabl[2], P3040000.getMesg(LangRes.P3044306));

        BeanUtil.setWText(wl_WeekLabl[3], P3040000.getMesg(LangRes.P3044307));
        BeanUtil.setWTips(wl_WeekLabl[3], P3040000.getMesg(LangRes.P3044308));

        BeanUtil.setWText(wl_WeekLabl[4], P3040000.getMesg(LangRes.P3044309));
        BeanUtil.setWTips(wl_WeekLabl[4], P3040000.getMesg(LangRes.P304430A));

        BeanUtil.setWText(wl_WeekLabl[5], P3040000.getMesg(LangRes.P304430B));
        BeanUtil.setWTips(wl_WeekLabl[5], P3040000.getMesg(LangRes.P304430C));

        BeanUtil.setWText(wl_WeekLabl[6], P3040000.getMesg(LangRes.P304430D));
        BeanUtil.setWTips(wl_WeekLabl[6], P3040000.getMesg(LangRes.P304430E));

        BeanUtil.setWText(dl_ThisDays, P3040000.getMesg(LangRes.P304430F));
        BeanUtil.setWTips(dl_ThisDays, P3040000.getMesg(LangRes.P3044310));

        // 取今天日期
        if (Util.getYear() == 0)
        {
            Util.setDate();
        }
        initMonthView();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void dl_DaysLablMouseClicked(java.awt.event.MouseEvent evt)
    {
        // 事件源标签设置选中状态
        DateLabel dl = (DateLabel) evt.getSource();

        // 上一次事件源标签设置未选中
        if (dl_LastDays != null)
        {
            dl_LastDays.setSelected(false);
        }

        dl.setSelected(true);
        Util.setDay(Integer.parseInt(dl.getText()));

        // 记录本次事件源
        dl_LastDays = dl;
    }

    /**
     * 转到今日事件处理
     * 
     * @param evt
     */
    private void dl_ThisDays_Handler(java.awt.event.MouseEvent evt)
    {
        Util.setDate();
        initMonthView();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 显示日视图
     */
    private void initDateView()
    {
        lb_YearLabl.setText(Util.getYear() + "-" + Util.getMonth());
        lb_DateLabl.setText(Integer.toString(Util.getDay()));
        String[] week =
        { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        lb_WeekLabl.setText(week[DateUtil.dayInWeek(Util.getYear(), Util.getMonth(), Util.getDay())]);
        lb_LunarLbl.setText(new Chinese(new Gregorian(Util.getYear(), Util.getMonth(), Util.getDay()).toFixed()).format());
    }

    /**
     * 显示月视图
     */
    private void initMonthView()
    {
        int currDate = 1;
        int day1Week = DateUtil.dayInWeek(Util.getYear(), Util.getMonth(), 1);
        while (currDate <= day1Week)
        {
            dl_DaysLabl[currDate++].setText("");
        }
        int totlDays = DateUtil.daysOfMonth(Util.getYear(), Util.getMonth());
        for (int i = 1; i <= totlDays; i += 1)
        {
            dl_DaysLabl[day1Week + i].setText(Integer.toString(i));
        }
        totlDays += (day1Week + 1);
        while (totlDays < 41)
        {
            dl_DaysLabl[totlDays++].setText("");
        }
        if (dl_LastDays != null)
        {
            dl_LastDays.setSelected(false);
        }
        dl_LastDays = dl_DaysLabl[day1Week + Util.getDay()];
        dl_LastDays.setSelected(true);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 标题标签 */
    private WeekLabel[] wl_WeekLabl;
    /** 日期标签 */
    private DateLabel[] dl_DaysLabl;
    private DatePanel dp_DatePanel;
    private javax.swing.JLabel lb_PrevDate;
    private javax.swing.JLabel lb_NextDate;
    private javax.swing.JLabel lb_YearLabl;
    private javax.swing.JLabel lb_DateLabl;
    private javax.swing.JLabel lb_WeekLabl;
    private javax.swing.JLabel lb_LunarLbl;
}
