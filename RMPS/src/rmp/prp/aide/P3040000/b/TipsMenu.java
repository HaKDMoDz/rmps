/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.b;

import java.awt.Component;
import java.awt.Dimension;
import java.awt.FontMetrics;
import java.util.List;

import javax.swing.JPopupMenu;

import rmp.bean.K1IV2S;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class TipsMenu extends JPopupMenu
{
    private java.awt.Font normFont;
    private java.awt.Font boldFont;
    private int startIdx;

    /**
     * 
     */
    public TipsMenu()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        // 取得系统使用字体
        javax.swing.JMenuItem m = new javax.swing.JMenuItem("中");
        normFont = m.getFont();
        boldFont = normFont.deriveFont(java.awt.Font.BOLD);
        add(m);

        // 设置默认宽度
        Dimension s = m.getPreferredSize();
        FontMetrics fm = m.getFontMetrics(boldFont);
        s.width = fm.stringWidth("中") * 8;
        m.setPreferredSize(s);
        return true;
    }

    /**
     * 
     */
    public void removeAll()
    {
        for (Component c : getComponents())
        {
            c.setVisible(false);
        }
        startIdx = 0;
    }

    /**
     * 公历日期提示
     */
    public void setData(String title, List<K1IV2S> dataList)
    {
        // 计算所需标签数量
        int s1 = startIdx + 1;
        s1 += (dataList != null ? dataList.size() : 0);
        int s2 = getComponentCount();

        // 添加足够的标签到菜单
        while (s2 < s1)
        {
            add(new javax.swing.JMenuItem());
            s2++;
        }

        Component c[] = getComponents();

        // 设置标题
        javax.swing.JMenuItem m = (javax.swing.JMenuItem) c[startIdx++];
        m.setFont(boldFont);
        m.setText(title);
        m.setVisible(true);
        m.setSelected(true);

        if (dataList == null)
        {
            return;
        }

        K1IV2S k;
        int i = startIdx;
        while (i < s1)
        {
            k = dataList.get(i - startIdx);
            m = (javax.swing.JMenuItem) c[i];
            m.setFont(normFont);
            m.setText(k.getV1());
            m.setVisible(true);
            i += 1;
        }

        while (i < s2)
        {
            c[i++].setVisible(false);
        }
        startIdx += s1;
    }
    /**  */
    private static final long serialVersionUID = -4912572279773671885L;
}
