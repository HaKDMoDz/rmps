/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.rmps.C4010000.v;

import java.awt.Dimension;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Paint;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;

import javax.swing.Timer;

import rmp.comn.rmps.C4010000.C4010000;
import rmp.comn.rmps.C4010000.t.Util;
import rmp.face.WBean;
import cons.comn.rmps.C4010000.ConstUI;

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
public class NormPanel extends javax.swing.JPanel implements WBean
{
    /** 当前滚动显示广告是否暂停滚动 */
    private boolean stopScroll = false;
    /** 滚动显示标记 */
    private int scrollSign;
    /** 当前显示文本在当前字体下的高度 */
    private int textHigh;
    /** 当前显示文本在当前字体下的宽度 */
    private int textWidh;
    /** 当前文本显示X坐标 */
    private int textXPos;
    /** 当前文本显示Y坐标 */
    private int textYPos;
    /** 背景颜色 */
    private Paint bgPaint;
    /** 前景颜色 */
    private Paint fgPaint;
    /** 当前显示的文本信息 */
    private String scrollText;
    /** 定时器 */
    private Timer tmTimer;
    /**  */
    private C4010000 ms_MainSoft;

    /**
     * @param soft
     */
    public NormPanel(C4010000 soft)
    {
        this.ms_MainSoft = soft;
        ms_MainSoft.wCode();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        // 计时器启动
        ActionListener al = new ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tmTimer_Handler(evt);
            }
        };
        tmTimer = new Timer(60, al);
        tmTimer.start();

        // 鼠标事件侦听
        this.addMouseListener(new MouseAdapter()
        {
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                stopScroll = true;
            }

            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                stopScroll = false;
            }
        });

        // 公益广告
        setToolTipText("为了您和他人，请支持公益广告！");

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#getPreferredSize()
     */
    public Dimension getPreferredSize()
    {
        Dimension size = super.getPreferredSize();
        if (size.height < 25)
        {
            size.height = 25;
        }
        return size;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        super.paintComponents(g);

        // 绘制颜色初始化
        if (bgPaint == null)
        {
            bgPaint = this.getBackground();
        }
        if (fgPaint == null)
        {
            fgPaint = this.getForeground();
        }

        // 二维绘制对象
        Graphics2D g2d = (Graphics2D) g;

        // 不同滚动模式的消息显示
        switch (scrollSign)
        {
            // 从右到左滚动
            case ConstUI.SCROLL_R2L:
                scrollR2L(g2d);
                break;

            // 从左到右滚动
            case ConstUI.SCROLL_L2R:
                scrollL2R(g2d);
                break;

            // 从上到下滚动
            case ConstUI.SCROLL_T2B:
                scrollT2B(g2d);
                break;

            // 由下向上滚动
            case ConstUI.SCROLL_B2T:
                scrollB2T(g2d);
                break;

            // 容错处理
            default:
                break;
        }
    }

    /**
     * 
     */
    public void stop()
    {
        tmTimer.stop();
    }

    /**
     * 
     */
    public void start()
    {
        tmTimer.start();
    }

    /**
     * 设置背景颜色
     * 
     * @param paint
     * @return
     */
    public Paint setBackgroundPaint(Paint paint)
    {
        this.bgPaint = paint;
        return paint;
    }

    /**
     * 设置前景颜色
     * 
     * @param paint
     * @return
     */
    public Paint setForegroundPaint(Paint paint)
    {
        this.fgPaint = paint;
        return paint;
    }

    /**
     * 定时器事件处理
     */
    private void tmTimer_Handler(java.awt.event.ActionEvent evt)
    {
        this.repaint();
    }

    /**
     * 文字从左到右滚动
     * 
     * @param g2d
     */
    private void scrollR2L(Graphics2D g2d)
    {
        // 当前标签显示区域大小
        Dimension size = this.getSize();

        // 绘制X坐标计算
        if (textXPos + textWidh <= 0)
        {
            scrollText = Util.nextAd();

            // 当前显示字符屏幕像素宽度
            FontMetrics fm = this.getFontMetrics(this.getFont());
            textWidh = fm.stringWidth(scrollText);
            textHigh = fm.getAscent() - fm.getLeading();

            textXPos = size.width;
        }

        // 绘制背景颜色
        g2d.setPaint(bgPaint);
        g2d.drawString(scrollText, textXPos, textYPos);

        // 停止滚动显示
        if (!stopScroll)
        {
            textXPos -= 1;
        }

        // 绘制Y坐标计算
        textYPos = (size.height + textHigh) >> 1;

        // 绘制显示文本
        g2d.setPaint(fgPaint);
        g2d.drawString(scrollText, textXPos, textYPos);
    }

    /**
     * @param g2d
     */
    private void scrollL2R(Graphics2D g2d)
    {
    }

    /**
     * @param g2d
     */
    private void scrollB2T(Graphics2D g2d)
    {
    }

    /**
     * @param g2d
     */
    private void scrollT2B(Graphics2D g2d)
    {
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -865685488754467026L;
}
