/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.bean;

import java.awt.Component;
import java.awt.Dimension;

import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JTable;
import javax.swing.JTree;
import javax.swing.ListCellRenderer;
import javax.swing.table.TableCellRenderer;
import javax.swing.tree.TreeCellRenderer;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 列表内容渲染
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class CellRender extends JLabel implements ListCellRenderer, TableCellRenderer, TreeCellRenderer
{
    /** 文本对齐方式 */
    private int textAligh = JLabel.LEFT;

    /**
     * 
     */
    public CellRender()
    {
        this(JLabel.LEFT);
    }

    /**
     * @param textAligh
     */
    public CellRender(int textAligh)
    {
        this.textAligh = textAligh;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * javax.swing.ListCellRenderer#getListCellRendererComponent(javax.swing
     * .JList, java.lang.Object, int, boolean, boolean)
     */
    @Override
    public Component getListCellRendererComponent(JList list, Object value, int index, boolean isSelected, boolean cellHasFocus)
    {
        setOpaque(true);

        // 前景及背景颜色设置
        if (isSelected)
        {
            setBackground(list.getSelectionBackground());
            setForeground(list.getSelectionForeground());
        }
        else
        {
            setBackground(list.getBackground());
            setForeground(list.getForeground());
        }

        // 文字属性设置
        setHorizontalAlignment(textAligh);
        setFont(list.getFont());

        // 可编辑状态设置
        setEnabled(list.isEnabled());

        // 显示文本及提示信息
        if (value instanceof K1SV2S)
        {
            K1SV2S kvItem = (K1SV2S) value;
            setText(kvItem.getV1());
            setToolTipText(kvItem.getV2());
        }
        else if (value instanceof K1IV3S)
        {
            K1IV3S kvItem = (K1IV3S) value;
            setText(kvItem.getV1());
            setToolTipText(kvItem.getV2());
        }
        else
        {
            setText(value.toString());
        }

        return this;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * javax.swing.table.TableCellRenderer#getTableCellRendererComponent(javax
     * .swing.JTable, java.lang.Object, boolean, boolean, int, int)
     */
    @Override
    public Component getTableCellRendererComponent(JTable table, Object value, boolean isSelected, boolean hasFocus, int row, int column)
    {
        // 前景及背景颜色设置
        if (isSelected)
        {
            setBackground(table.getSelectionBackground());
            setForeground(table.getSelectionForeground());
        }
        else
        {
            setBackground(table.getBackground());
            setForeground(table.getForeground());
        }
        setOpaque(true);

        // 文字属性设置
        setHorizontalAlignment(textAligh);
        setFont(table.getFont());

        // 可编辑状态设置
        setEnabled(table.isEnabled());

        // 显示文本及提示信息
        // if (value instanceof K1V1)
        // {
        // K1V1 kvItem = (K1V1)value;
        // setText(kvItem.getV());
        // setToolTipText(kvItem.getK());
        // }
        // else
        // {
        setText(value.toString());
        // }

        return this;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#getPreferredSize()
     */
    public Dimension getPreferredSize()
    {
        Dimension d = super.getPreferredSize();
        d.width += 4;
        return d;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * javax.swing.tree.TreeCellRenderer#getTreeCellRendererComponent(javax.
     * swing.JTree, java.lang.Object, boolean, boolean, boolean, int, boolean)
     */
    @Override
    public Component getTreeCellRendererComponent(JTree tree, Object value, boolean selected, boolean expanded, boolean leaf, int row, boolean hasFocus)
    {
        // TODO Auto-generated method stub
        return null;
    }
}
