/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.icon;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Paint;
import java.awt.RenderingHints;

import javax.swing.JLabel;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 图像标签
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class WIconLabel extends JLabel
{
    /** */
    private static final long serialVersionUID = 1L;
    /** 背景图像 */
    private Image bgImage = null;
    /** 背景颜色 */
    private Paint bgPaint = Color.WHITE;

    /**
     * 
     */
    public WIconLabel()
    {
    }

    /**
     * @return
     */
    public Image getBackgroundImage()
    {
        return bgImage;
    }

    /**
     * 设置当前图像标签的背景图像。
     * 
     * @param image
     * @return 返回已有背景图像对象
     */
    public Image setBackgroundImage(Image image)
    {
        Image t = this.bgImage;
        this.bgImage = image;
        this.repaint();
        return t;
    }

    /**
     * @return
     */
    public Paint getBackgroundPaint()
    {
        return bgPaint;
    }

    /**
     * 设置当前图像标签的背景颜色
     * 
     * @param paint
     * @return 返回已有背景颜色对象
     */
    public Paint setBackgroundPaint(Paint paint)
    {
        Paint t = bgPaint;
        this.bgPaint = paint;
        this.repaint();
        return t;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        Graphics2D g2d = (Graphics2D) g;

        // 绘制背景
        if (bgPaint != null)
        {
            g2d.setPaint(bgPaint);
            g2d.fillRect(0, 0, this.getWidth(), this.getHeight());
        }

        // 绘制图像
        if (bgImage != null)
        {
            g2d.setRenderingHint(RenderingHints.KEY_TEXT_ANTIALIASING, RenderingHints.VALUE_TEXT_ANTIALIAS_ON);
            int imgWidh = bgImage.getWidth(this);
            int imgHigh = bgImage.getHeight(this);
            int imgXPos = (this.getWidth() - imgWidh) >> 1;
            int imgYPos = (this.getHeight() - imgHigh) >> 1;
            g2d.drawImage(bgImage, imgXPos, imgYPos, imgWidh, imgHigh, this);
        }
    }
}
