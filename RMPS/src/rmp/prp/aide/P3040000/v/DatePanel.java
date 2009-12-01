/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.v;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

import javax.swing.JPanel;

import rmp.util.ImageUtil;
import com.amonsoft.util.LogUtil;
import cons.EnvCons;
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
 * @author Amon
 */
public class DatePanel extends JPanel
{
    private BufferedImage bi_BgImage;

    public DatePanel()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        try
        {
            bi_BgImage = ImageUtil.readJarImage(EnvCons.PATH_P3040000, ConstUI.PATH_BG);
        }
        catch (Exception exp)
        {
            bi_BgImage = new BufferedImage(130, 141, BufferedImage.TYPE_INT_ARGB);
            LogUtil.exception(exp);
        }

        setPreferredSize(new java.awt.Dimension(bi_BgImage.getWidth(), bi_BgImage.getHeight()));
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JComponent#paintComponent(java.awt.Graphics)
     */
    protected void paintComponent(Graphics g)
    {
        if (bi_BgImage == null)
        {
            return;
        }

        Dimension size = getSize();

        int x = (size.width - bi_BgImage.getWidth()) >> 1;
        int y = (size.height - bi_BgImage.getHeight()) >> 1;
        g.drawImage(bi_BgImage, x, y, this);

    }
    /** serialVersionUID */
    private static final long serialVersionUID = -1586233476753939906L;
}
