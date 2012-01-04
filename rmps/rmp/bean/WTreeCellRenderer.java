/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.bean;

import java.awt.Color;
import java.awt.Component;

import javax.swing.ImageIcon;
import javax.swing.JTree;
import javax.swing.tree.TreeCellRenderer;

import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import cons.EnvCons;

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
public class WTreeCellRenderer extends javax.swing.JLabel implements TreeCellRenderer
{
    /**  */
    private static ImageIcon collapsedIcon;
    /**  */
    private static ImageIcon expandedIcon;

    /**
     * 
     */
    public WTreeCellRenderer()
    {
        try
        {
            collapsedIcon = new ImageIcon(ImageUtil.readJarImage(EnvCons.FOLDER1_PRP, "treec.png"));
            expandedIcon = new ImageIcon(ImageUtil.readJarImage(EnvCons.FOLDER1_PRP, "treee.png"));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public Component getTreeCellRendererComponent(JTree tree, Object value, boolean selected, boolean expanded, boolean leaf, int row, boolean hasFocus)
    {
        this.setOpaque(true);
        setFont(tree.getFont());
        setEnabled(tree.isEnabled());

        if (selected)
        {
            setBackground(Color.GRAY);
            // setForeground();
        }
        else
        {
            setBackground(tree.getBackground());
            // setForeground(tree.getForeground());
        }

        setIcon(expanded ? expandedIcon : collapsedIcon);

        if (value instanceof K1SV2S)
        {
            K1SV2S kvItem = (K1SV2S) value;
            setText(kvItem.getV1());
            setToolTipText(kvItem.getV2());
        }
        else
        {
            setText(value.toString());
            setToolTipText(value.toString());
        }

        return this;
    }

    /**
     * @return the collapsedIcon
     */
    public static ImageIcon getCollapsedIcon()
    {
        return collapsedIcon;
    }

    /**
     * @param collapsedIcon
     *            the collapsedIcon to set
     */
    public static void setCollapsedIcon(ImageIcon collapsedIcon)
    {
        WTreeCellRenderer.collapsedIcon = collapsedIcon;
    }

    /**
     * @return the expandedIcon
     */
    public static ImageIcon getExpandedIcon()
    {
        return expandedIcon;
    }

    /**
     * @param expandedIcon
     *            the expandedIcon to set
     */
    public static void setExpandedIcon(ImageIcon expandedIcon)
    {
        WTreeCellRenderer.expandedIcon = expandedIcon;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -8588227466731676154L;
}
