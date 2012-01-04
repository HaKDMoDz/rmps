/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3080000.v;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.image.BufferedImage;
import java.text.SimpleDateFormat;
import java.util.EventObject;

import rmp.face.WBackCall;
import rmp.prp.aide.P3080000.P3080000;
import rmp.prp.aide.P3080000.t.Util;
import rmp.util.ImageUtil;
import rmp.util.StringUtil;
import cons.EnvCons;
import cons.prp.aide.P3080000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 内嵌面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class TailPanel extends javax.swing.JPanel implements WBackCall
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 主应用程序 */
    // private P3080000 ms_MainSoft;
    /** 上一秒 */
    private int lastSecond = 0;
    /** 日历对象 */
    private java.util.Calendar cl_Calendar;
    /** 用户时区 */
    private java.util.TimeZone tz_TimeZone;
    /** 内嵌页面 */
    private javax.swing.JPanel tp_TailPanel;
    /** 定时器 */
    private javax.swing.Timer tm_Timer;
    /** 背景图片 */
    private BufferedImage bi_am;         // 上午
    private BufferedImage bi_bg;         // 背景
    private BufferedImage bi_gmt;        // 时区
    private BufferedImage bi_hl;         // 高亮
    private BufferedImage bi_pm;         // 下午
    private BufferedImage bi_tc;         // 秒针
    private BufferedImage[] bi_nn;         // 数值
    private BufferedImage[] bi_wk;         // 星期
    private BufferedImage[] bi_tz;         // 时区
    private BufferedImage[] bi_pa;         // 正负

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P3080000 soft, javax.swing.JPanel tailPanel)
    {
        // this.ms_MainSoft = soft;
        this.tp_TailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        // 计时器
        tz_TimeZone = java.util.TimeZone.getDefault();
        Util.setZoneOffset(tz_TimeZone.getRawOffset() / 3600000);
        cl_Calendar = java.util.Calendar.getInstance();

        // 背景图片初始化
        bi_am = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "am"));// 上午
        bi_bg = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "bg"));// 背景
        bi_pm = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "pm"));// 下午
        bi_gmt = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "gmt"));// 时区
        bi_hl = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "hl"));// 高亮
        bi_tc = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "tc"));// 秒针
        bi_pa = new BufferedImage[3];
        bi_pa[0] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "sn"));// 无
        bi_pa[1] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "s+"));// 正号
        bi_pa[2] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "s-"));// 负号
        bi_nn = new BufferedImage[10];
        bi_tz = new BufferedImage[10];
        bi_wk = new BufferedImage[7];
        for (int i = 0; i < 7; i += 1)
        {
            bi_wk[i] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "w" + i));// 星期
            bi_nn[i] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "n" + i));// 数值
            bi_tz[i] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "s" + i));// 数值
        }
        bi_nn[7] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "n7"));// 数值
        bi_nn[8] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "n8"));// 数值
        bi_nn[9] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "n9"));// 数值
        bi_tz[7] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "s7"));// 数值
        bi_tz[8] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "s8"));// 数值
        bi_tz[9] = ImageUtil.readImage(EnvCons.FOLDER0_TPLT + StringUtil.format(ConstUI.PATH_PICT, "s9"));// 数值

        // 界面初始化
        ica();

        // 语言初始化
        ita();

        // 定时器
        tm_Timer = new javax.swing.Timer(200, new java.awt.event.ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                repaintClock();
            }
        });
        tm_Timer.start();

        Util.register("tailPanel", this);

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object)
     */
    @Override
    public void wAction(EventObject event, Object object, String property)
    {
        if ("default".equals(object))
        {
            tz_TimeZone = java.util.TimeZone.getDefault();
            Util.setZoneOffset(tz_TimeZone.getRawOffset() / 3600000);
        }
        else
        {
            tz_TimeZone.setRawOffset(Util.getZoneOffset() * 3600000);
        }
        repaintClock();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);

        int ii;
        BufferedImage bi;

        // ////////////////////////////////////////////////////////////////////
        // 绘制背景
        // ////////////////////////////////////////////////////////////////////
        bi = bi_bg;
        g.drawImage(bi, 0, 0, bi.getWidth(), bi.getHeight(), this);

        // ////////////////////////////////////////////////////////////////////
        // 绘制时
        // ////////////////////////////////////////////////////////////////////
        ii = cl_Calendar.get(java.util.Calendar.HOUR_OF_DAY);

        // 绘制上下午
        bi = (ii >= 12 ? bi_pm : bi_am);
        g.drawImage(bi, 103, 12, bi.getWidth(), bi.getHeight(), this);

        // 时第一位
        bi = bi_nn[ii / 10];
        g.drawImage(bi, 14, 12, bi.getWidth(), bi.getHeight(), this);

        // 时第二位
        bi = bi_nn[ii % 10];
        g.drawImage(bi, 34, 12, bi.getWidth(), bi.getHeight(), this);

        // ////////////////////////////////////////////////////////////////////
        // 绘制分
        // ////////////////////////////////////////////////////////////////////
        ii = cl_Calendar.get(java.util.Calendar.MINUTE);

        // 分第一位
        bi = bi_nn[ii / 10];
        g.drawImage(bi, 64, 12, bi.getWidth(), bi.getHeight(), this);

        // 分第二位
        bi = bi_nn[ii % 10];
        g.drawImage(bi, 84, 12, bi.getWidth(), bi.getHeight(), this);

        // ////////////////////////////////////////////////////////////////////
        // 绘制秒
        // ////////////////////////////////////////////////////////////////////
        ii = cl_Calendar.get(java.util.Calendar.SECOND);

        // 闪动秒
        bi = bi_tc;
        if (ii != lastSecond)
        {
            g.drawImage(bi_tc, 54, 12, bi.getWidth(), bi.getHeight(), this);
            lastSecond = ii;
        }

        // 绘制星期
        ii = cl_Calendar.get(java.util.Calendar.DAY_OF_WEEK) - 1;
        bi = bi_wk[ii];
        g.drawImage(bi, 17, 42, bi.getWidth(), bi.getHeight(), this);

        // GMT时区
        bi = bi_gmt;
        g.drawImage(bi, 37, 40, bi.getWidth(), bi.getHeight(), this);
        bi = bi_pa[0];
        ii = Util.getZoneOffset();
        if (ii > 0)
        {
            bi = bi_pa[1];
        }
        else if (ii < 0)
        {
            ii = -ii;
            bi = bi_pa[2];
        }
        g.drawImage(bi, 55, 40, bi.getWidth(), bi.getHeight(), this);
        bi = bi_tz[ii / 10];
        g.drawImage(bi, 61, 40, bi.getWidth(), bi.getHeight(), this);
        bi = bi_tz[ii % 10];
        g.drawImage(bi, 67, 40, bi.getWidth(), bi.getHeight(), this);

        // 绘制高亮
        bi = bi_hl;
        g.drawImage(bi, 4, 4, bi.getWidth(), bi.getHeight(), this);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 重新绘制时钟
     */
    private void repaintClock()
    {
        cl_Calendar = java.util.Calendar.getInstance(tz_TimeZone);
        repaint();
    }

    /**
     * 显示提示窗口
     */
    private void showTips()
    {
        // 显示文本
        int i;

        StringBuffer sb = new StringBuffer();

        sb.append("<html>");

        // 星期
        sb.append("星期：");
        String[] w =
        {
            "日", "一", "二", "三", "四", "五", "六"
        };
        sb.append(w[cl_Calendar.get(java.util.Calendar.DAY_OF_WEEK) - 1]);
        sb.append("<br />");
        // 时刻
        i = cl_Calendar.get(java.util.Calendar.HOUR_OF_DAY);
        sb.append("时刻：");
        sb.append(i >= 12 ? "下午" : "上午");
        sb.append("<br />");
        // 时间
        sb.append("时间：");
        sb.append(new SimpleDateFormat("yyyy/MM/dd HH:mm:ss").format(cl_Calendar.getTime()));
        sb.append("<br />");
        // 时区
        sb.append("时区：");
        int tz = Util.getZoneOffset();
        sb.append("GMT ");
        if (tz > 0)
        {
            sb.append('+');
        }
        else if (tz < 0)
        {
            tz = -tz;
            sb.append(' ');
        }
        else
        {
            sb.append(' ');
        }
        sb.append(tz / 10).append(tz % 10);
        sb.append("<br />");

        sb.append("</html>");

        setToolTipText(sb.toString());
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        this.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                showTips();
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
            }
        });
        tp_TailPanel.add(this);
        setPreferredSize(new Dimension(132, 56));
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** serialVersionUID */
    private static final long serialVersionUID = 6370118885229251300L;
}
