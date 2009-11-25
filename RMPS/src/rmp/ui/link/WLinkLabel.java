/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.link;

import java.awt.Color;
import java.awt.Cursor;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JLabel;

import rmp.util.CheckUtil;
import rmp.util.EnvUtil;
import cons.ui.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 链接标签
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class WLinkLabel extends JLabel
{
    /**  */
    private static final long serialVersionUID = 1363632283600471859L;

    /**
     * 
     */
    public WLinkLabel()
    {
        this.setForeground(Color.BLUE);
        this.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        this.setName(ConstUI.LINK_PROP);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean init()
    {
        return true;
    }

    /**
     * @return the linkUrl
     */
    public String getLinkUrl()
    {
        return linkUrl;
    }

    /**
     * @param linkUrl the linkUrl to set
     */
    public void setLinkUrl(String linkUrl)
    {
        this.linkUrl = linkUrl;
    }

    /**
     * @param autoOpen
     */
    public void setAutoOpenLink(boolean autoOpen)
    {
        if (autoOpen)
        {
            if (listener == null)
            {
                listener = new MouseAdapter()
                {
                    public void mouseClicked(MouseEvent evt)
                    {
                        openLinkUrl(linkUrl);
                    }
                };
            }
            this.addMouseListener(listener);
        }
        else
        {
            this.removeMouseListener(listener);
        }
    }

    /**
     * @param linkUrl
     * @return
     */
    public boolean openLinkUrl(String linkUrl)
    {
        if (!CheckUtil.isValidate(linkUrl))
        {
            return false;
        }

        if (linkUrl.toLowerCase().startsWith("mailto:"))
        {
            EnvUtil.mail(linkUrl);
        }
        else
        {
            EnvUtil.browse(linkUrl);
        }
        return true;
    }
    /** 链接地址 */
    private String linkUrl;
    /**  */
    private MouseListener listener;
}
