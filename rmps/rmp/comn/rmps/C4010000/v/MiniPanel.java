/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.rmps.C4010000.v;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GradientPaint;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Paint;
import java.awt.RenderingHints;
import java.awt.event.ActionListener;

import javax.swing.Timer;

import rmp.comn.rmps.C4010000.C4010000;
import rmp.face.WBean;

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
public class MiniPanel extends javax.swing.JPanel implements WBean
{
    /** 定时器 */
    private Timer tmTimer;
    /** 背景颜色 */
    private Paint bgPaint;
    /** 前景颜色 */
    private Paint fgPaint;
    private int hGaps = 4;
    private int vGaps = 0;
    private int thmWidh = 40;
    private int thmHigh;
    private int arcWidh = 6;
    private int arcHigh = 6;
    /**  */
    private int currPos = -thmWidh;

    /**
     * 
     */
    public MiniPanel(C4010000 soft)
    {
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
        tmTimer = new Timer(40, al);
        tmTimer.start();

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

        Dimension size = getSize();
        size.height -= (hGaps << 1);

        thmHigh = size.height - 1;

        // 绘制颜色初始化
        if (bgPaint == null)
        {
            bgPaint = new GradientPaint(0.0f, 0.0f, Color.WHITE, 0.0f, thmHigh, Color.GREEN);
        }
        if (fgPaint == null)
        {
            fgPaint = this.getForeground();
        }

        Graphics2D g2d = (Graphics2D) g;
        g2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);

        g2d.setPaint(Color.WHITE);
        g2d.fillRoundRect(vGaps, hGaps, size.width, size.height, arcWidh, arcHigh);

        g2d.setPaint(Color.LIGHT_GRAY);
        g2d.drawRoundRect(vGaps, hGaps, size.width - 1, size.height, arcWidh, arcHigh);

        g2d.setPaint(bgPaint);
        g2d.fillRoundRect(currPos, hGaps + 1, thmWidh, thmHigh, arcWidh, arcHigh);
        currPos += 2;
        if (currPos > size.width)
        {
            currPos = -thmWidh;
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
     * 定时器事件处理
     */
    private void tmTimer_Handler(java.awt.event.ActionEvent evt)
    {
        this.repaint();
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -7993652455405271416L;
}
