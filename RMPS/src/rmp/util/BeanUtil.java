/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.awt.Color;
import java.awt.Rectangle;
import java.awt.image.BufferedImage;
import java.io.InputStream;

import javax.imageio.ImageIO;
import javax.swing.AbstractButton;
import javax.swing.BorderFactory;
import javax.swing.JComponent;
import javax.swing.JLabel;
import javax.swing.JTable;
import javax.swing.JViewport;
import javax.swing.border.Border;
import javax.swing.text.JTextComponent;

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
public class BeanUtil
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统可变窗口资源，此资源并不需要实时维护，可以根据需要建立或释放
    // ////////////////////////////////////////////////////////////////////////
    /** 系统图标 */
    private static BufferedImage sysLogo = null;

    /**
     * 
     */
    private BeanUtil()
    {
    }

    /**
     * 获得系统图标，返回对象总是一个BufferedImage实例，并且保证不为空
     * 
     * @return
     */
    public static synchronized BufferedImage getLogoImage()
    {
        if (sysLogo == null)
        {
            // Logo图像读取
            try
            {
                LogUtil.log("系统初始化：LOGO图标读取..");

                InputStream inStream = BeanUtil.class.getResourceAsStream("/res/logo10.png");
                if (inStream != null)
                {
                    sysLogo = ImageIO.read(inStream);
                    inStream.close();
                }
                else
                {
                    sysLogo = drawLogoImage();
                }
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                sysLogo = drawLogoImage();
            }
        }
        return sysLogo;
    }

    /**
     * 绘制系统图像
     * 
     * @param logoImage
     * @return
     */
    private static BufferedImage drawLogoImage()
    {
        BufferedImage logoImage = new BufferedImage(16, 16, BufferedImage.TYPE_INT_ARGB);
        return logoImage;
    }

    /**
     * @param c
     * @param wText
     * @param isHash
     */
    @Deprecated
    public static void setWText(AbstractButton c, String wText)
    {
        if (wText == null)
        {
            return;
        }

        // 快捷字符替换
        if (CheckUtil.isValidate(wText))
        {
            int si = wText.indexOf('&');
            if (si >= 0)
            {
                wText = wText.replace("&", "");
                if (wText.length() > si)
                {
                    c.setMnemonic(wText.charAt(si));
                }
            }
        }

        c.setText(wText);
    }

    /**
     * @param c
     * @param wText
     * @param isHash
     */
    @Deprecated
    public static void setWText(JTextComponent c, String wText)
    {
        if (wText == null)
        {
            return;
        }

        c.setText(wText);
    }

    /**
     * @param c
     * @param wText
     * @param isHash
     */
    @Deprecated
    public static void setWText(JLabel c, String wText)
    {
        if (wText == null)
        {
            return;
        }

        // 快捷字符替换
        if (CheckUtil.isValidate(wText))
        {
            int si = wText.indexOf('&');
            if (si >= 0)
            {
                wText = wText.replace("&", "");
                if (wText.length() > si)
                {
                    c.setDisplayedMnemonic(wText.charAt(si));
                }
            }
        }

        c.setText(wText);
    }

    /**
     * @param c
     * @param wTips
     * @param isHash
     */
    @Deprecated
    public static void setWTips(JComponent c, String wTips)
    {
        if (wTips == null)
        {
            return;
        }

        c.setToolTipText(wTips);
    }

    public static void scrollToVisible(JTable table, int rowIndex, int vColIndex, boolean center)
    {
        if (!(table.getParent() instanceof JViewport))
        {
            return;
        }

        JViewport viewport = (JViewport) table.getParent();

        // This rectangle is relative to the table where the
        // northwest corner of cell (0,0) is always (0,0).
        Rectangle rect = table.getCellRect(rowIndex, vColIndex, true);

        // The location of the view relative to the table
        Rectangle viewRect = viewport.getViewRect();

        // Translate the cell location so that it is relative
        // to the view, assuming the northwest corner of the
        // view is (0,0).
        rect.setLocation(rect.x - viewRect.x, rect.y - viewRect.y);

        if (center)
        {
            // Calculate location of rect if it were at the center of view
            int centerX = (viewRect.width - rect.width) >> 1;
            int centerY = (viewRect.height - rect.height) >> 1;

            // Fake the location of the cell so that scrollRectToVisible
            // will move the cell to the center
            if (rect.x < centerX)
            {
                centerX = -centerX;
            }
            if (rect.y < centerY)
            {
                centerY = -centerY;
            }
            rect.translate(centerX, centerY);
        }

        // Scroll the area into view.
        viewport.scrollRectToVisible(rect);
    }
}
