/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.form;

import java.awt.AWTEvent;
import java.awt.Container;
import java.awt.Dialog;
import java.awt.Dimension;
import java.awt.Frame;
import java.awt.Image;
import java.awt.event.WindowEvent;

import javax.swing.JDialog;
import javax.swing.JMenuBar;

import com.amonsoft.rmps.IRmps;
import com.amonsoft.rmps.prp.ISoft;
import rmp.util.EnvUtil;
import com.amonsoft.skin.ISkin;

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
public class DForm extends JDialog
{
    /** 标准插件 */
    private ISoft ms_MainSoft;
    /** 系统标题 */
    private DHead mb_MainMenu;
    /** 用户菜单 */
    private JMenuBar mb_UserMenu;

    /**
     * 默认构造函数
     */
    public DForm(Frame owner)
    {
        super(owner);

        if (owner != null)
        {
            this.setUndecorated(owner.isUndecorated());
        }
        this.getContentPane().setName(ISkin.CONTAINER);
    }

    /**
     * @param owner
     * @param modal
     */
    public DForm(Frame owner, boolean modal)
    {
        super(owner, modal);

        if (owner != null)
        {
            this.setUndecorated(owner.isUndecorated());
        }
        this.getContentPane().setName(ISkin.CONTAINER);
    }

    /**
     * 默认构造函数
     * 
     * @param owner
     */
    public DForm(Dialog owner)
    {
        super(owner);

        this.setUndecorated(owner.isUndecorated());
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IRmps#init()
     */
    public boolean wInit()
    {
        enableEvents(AWTEvent.WINDOW_EVENT_MASK);

        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.awt.Frame#setTitle(java.lang.String)
     */
    public void setTitle(String title)
    {
        super.setTitle(title);
        if (mb_MainMenu != null)
        {
            mb_MainMenu.setTitle(title);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JFrame#setIconImage(java.awt.Image)
     */
    public void setIconImage(Image image)
    {
        super.setIconImage(image);
        if (mb_MainMenu != null)
        {
            mb_MainMenu.setIconImage(image);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JDialog#setContentPane(java.awt.Container)
     */
    public void setContentPane(Container contentPane)
    {
        // 不是定制风格时，不进行下面的处理
        if (true)
        {
            super.setContentPane(contentPane);
            return;
        }

        getContentPane().add(contentPane, java.awt.BorderLayout.CENTER);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JDialog#setJMenuBar(javax.swing.JMenuBar)
     */
    public void setJMenuBar(JMenuBar menubar)
    {
        // 不是定制风格时，不进行下面的处理
        if (true)
        {
            super.setJMenuBar(menubar);
            return;
        }

        if (mb_MainMenu == menubar)
        {
            return;
        }
        if (mb_UserMenu != null)
        {
            getContentPane().remove(mb_UserMenu);
        }
        mb_UserMenu = menubar;
        getContentPane().add(mb_UserMenu, java.awt.BorderLayout.NORTH);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JDialog#processWindowEvent(java.awt.event.WindowEvent)
     */
    protected void processWindowEvent(WindowEvent e)
    {
        switch (e.getID())
        {
            // DForm关闭事件
            case WindowEvent.WINDOW_CLOSING:
                wExit();
                break;

            // DForm最小化事件
            case WindowEvent.WINDOW_ICONIFIED:
                wHide();
                break;

            case WindowEvent.WINDOW_DEICONIFIED:
                wView();
                break;

            // 忽略其他事件，交给DForm处理
            default:
                super.processWindowEvent(e);
                break;
        }
    }

    /**
     * 添加用户级联菜单
     * 
     * @param menu
     */
    public void addMenu(javax.swing.JMenu menu)
    {
        mb_MainMenu.add(menu);
    }

    /**
     * 添加用户菜单项
     * 
     * @param item
     */
    public void addMenuItem(javax.swing.JMenuItem item)
    {
        mb_MainMenu.add(item);
    }

    /**
     * 设置退出按钮是否显示<br />
     * 默认显示
     * 
     * @param b
     */
    public void setExitButtonVisible(boolean b)
    {
        mb_MainMenu.setExitButtonVisible(b);
    }

    /**
     * 设置菜单按钮是否显示<br />
     * 默认不显示
     * 
     * @param b
     */
    public void setMenuButtonVisible(boolean b)
    {
        mb_MainMenu.setMenuButtonVisible(b);
    }

    /**
     * 设置最小化按钮是否显示<br />
     * 默认显示
     * 
     * @param b
     */
    public void setMinButtonVisible(boolean b)
    {
        mb_MainMenu.setMinButtonVisible(b);
    }

    /**
     * @param soft
     */
    public void setSoft(ISoft soft)
    {
        this.ms_MainSoft = soft;
        setResizable(false);
        if (ms_MainSoft != null)
        {
            setTitle(soft.wGetTitle());
            setIconImage(soft.wGetIconImage(ISoft.ICON_LOGO0016));
        }
        else
        {
            setTitle("");
            setIconImage(null);
        }
    }

    /**
     */
    void wExit()
    {
        if (ms_MainSoft != null)
        {
            ms_MainSoft.wDispose();
        }
    }

    /**
     * 窗口隐藏事件处理
     */
    void wHide()
    {
        if (ms_MainSoft != null)
        {
            ms_MainSoft.wStop();
        }
    }

    /**
     * 窗口复原事件处理
     */
    void wView()
    {
        if (ms_MainSoft != null)
        {
            ms_MainSoft.wStart();
        }
    }

    /**
     * 窗口居中显示
     */
    public void center()
    {
        Dimension size = EnvUtil.getScreenSize();
        int x = (size.width - getWidth()) >> 1;
        int y = (size.height - getHeight()) >> 1;
        setLocation(x, y);
    }
    /** serialVersionUID */
    private static final long serialVersionUID = 7810209068083202977L;
}
