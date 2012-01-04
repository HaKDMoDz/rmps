/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.b;

import java.awt.Dimension;
import java.awt.Graphics;

import cons.prp.aide.P3040000.ConstUI;

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
public class DateLabel extends javax.swing.JLabel
{
    /** 是否为今日日期 */
    private boolean today;

    /**
     * 默认构造函数
     */
    public DateLabel()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        this.setOpaque(true);
        this.setBorder(ConstUI.BORDER);
        this.setHorizontalAlignment(CENTER);

        super.setBackground(ConstUI.D_B_COLOR);
        super.setForeground(ConstUI.D_F_COLOR);

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);

        // 绘制今日标记
        if (today)
        {
            g.setColor(java.awt.Color.RED);
            Dimension s = getSize();
            g.drawRect(3, 3, s.width - 6, s.height - 6);
        }
    }

    /**
     * 设置标签是否被选择
     * 
     * @param b
     *            true标签被选择
     */
    public void setSelected(boolean b)
    {
        if (b)
        {
            this.setBackground(ConstUI.S_B_COLOR);
            this.setForeground(ConstUI.S_F_COLOR);
        }
        else
        {
            this.setBackground(ConstUI.D_B_COLOR);
            this.setForeground(ConstUI.D_F_COLOR);
        }
    }

    /**
     * @return the today
     */
    public boolean isToday()
    {
        return today;
    }

    /**
     * @param today
     *            the today to set
     */
    public void setToday(boolean today)
    {
        this.today = today;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -1225262291911738948L;
}
