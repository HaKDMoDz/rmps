/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.b;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JLabel;

import rmp.face.WBean;
import rmp.util.ImageUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class TreeLabel extends JLabel implements WBean
{
    /** 默认状态显示图像 */
    private static Icon dIcon;
    /** 选中状态显示图像 */
    private static Icon sIcon;
    /** 当前标签是否处于选中状态 */
    private boolean selected;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    static
    {
        dIcon = new ImageIcon(ImageUtil.readImage("logo/softc.png"));
        sIcon = new ImageIcon(ImageUtil.readImage("logo/softx.png"));
    }

    /**
     * 默认构造函数
     */
    public TreeLabel()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.setIcon(dIcon);
        return true;
    }

    /**
     * @return the dIcon
     */
    public static Icon getDefaultIcon()
    {
        return dIcon;
    }

    /**
     * @param icon the dIcon to set
     */
    public static void setDefaultIcon(Icon icon)
    {
        dIcon = icon;
    }

    /**
     * @return the sIcon
     */
    public static Icon getSelectedIcon()
    {
        return sIcon;
    }

    /**
     * @param icon the sIcon to set
     */
    public static void setSelectedIcon(Icon icon)
    {
        sIcon = icon;
    }

    /**
     * @return the selected
     */
    public boolean isSelected()
    {
        return selected;
    }

    /**
     * @param selected the selected to set
     */
    public void setSelected(boolean selected)
    {
        this.selected = selected;
        setIcon(selected ? sIcon : dIcon);
    }
}
