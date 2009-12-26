/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.b;

import java.awt.Color;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.Insets;

import javax.swing.JTextField;

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
public class WCalField extends JTextField
{
    /** 输入数值 */
    private StringBuffer text;
    /** 运算符号 */
    private String operator;

    /**
     * 
     */
    public WCalField()
    {
        text = new StringBuffer();
        setHorizontalAlignment(RIGHT);
        Color c = getBackground();
        setEditable(false);
        setBackground(c);
    }

    /**
     * @param t
     */
    public void setOperator(String t)
    {
        operator = t.trim();
        repaint();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.text.JTextComponent#setText(java.lang.String)
     */
    public void setText(String t)
    {
        super.setText(t);
        text.delete(0, text.length()).append(t);
    }

    /**
     * 删除最近输入的一个数值
     * 
     * @return
     */
    public String deleteEnd()
    {
        text.deleteCharAt(text.length() - 1);
        if (text.length() == 0)
        {
            text.append("0");
        }
        String temp = text.toString();
        super.setText(temp);
        return temp;
    }

    /**
     * 清除所有显示数据
     */
    public void deleteAll()
    {
        super.setText(text.delete(0, text.length()).append("0").toString());
    }

    /**
     * 用户数据输入并连续显示
     * 
     * @param t
     */
    public String append(String t)
    {
        String temp = text.append(t).toString();
        super.setText(temp);
        return temp;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);

        if (operator != null)
        {
            FontMetrics fm = getFontMetrics(getFont());
            int h = fm.getAscent() - fm.getLeading();

            Insets i = getInsets();
            Insets m = getMargin();
            g.drawString(operator, i.left + m.left, (getSize().height - i.bottom + h) >> 1);
        }
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -4374162950893688067L;
}
