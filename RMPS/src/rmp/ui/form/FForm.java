/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.form;

import java.awt.AWTEvent;
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.Image;
import java.awt.MenuBar;
import java.awt.event.WindowEvent;

import javax.swing.BorderFactory;
import javax.swing.JFrame;
import javax.swing.JMenuBar;

import rmp.face.WBean;
import com.amonsoft.rmps.prp.IPrpPlus;
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
public class FForm extends JFrame implements WBean
{
    /** 标准插件 */
    private IPrpPlus ms_MainSoft;
    /** 系统标题 */
    private FHead mb_MainMenu;
    /** 用户菜单 */
    private JMenuBar mb_UserMenu;

    /**
     * 默认构造函数
     */
    public FForm()
    {
        if (false)
        {
            setUndecorated(true);
            mb_MainMenu = new FHead(this);
            mb_MainMenu.wInit();
            super.setJMenuBar(mb_MainMenu);
        }

        getContentPane().setName(ISkin.CONTAINER);
        getRootPane().setBorder(BorderFactory.createLineBorder(Color.LIGHT_GRAY));
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        // 主窗口无框架设置

        enableEvents(AWTEvent.WINDOW_EVENT_MASK);

        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.awt.Frame#setTitle(java.lang.String)
     */
    @Override
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
    @Override
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
     * @see java.awt.Container#removeAll()
     */
    @Override
    public void removeAll()
    {
        getContentPane().removeAll();
        if (mb_UserMenu != null)
        {
            getContentPane().add(mb_UserMenu, java.awt.BorderLayout.NORTH);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JFrame#setContentPane(java.awt.Container)
     */
    @Override
    public void setContentPane(Container contentPane)
    {
        // 不是定制风格时，不进行下面的处理
        if (true)
        {
            super.setContentPane(contentPane);
            return;
        }

        contentPane.setName(ISkin.PANEL_BASE);
        getContentPane().add(contentPane, java.awt.BorderLayout.CENTER);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JFrame#setJMenuBar(javax.swing.JMenuBar)
     */
    @Override
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
     * @see java.awt.Frame#setMenuBar(java.awt.MenuBar)
     */
    @Deprecated
    @Override
    public void setMenuBar(MenuBar menubar)
    {
        throw new RuntimeException("");
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.awt.Frame#setResizable(boolean)
     */
    @Override
    public void setResizable(boolean resizable)
    {
        super.setResizable(resizable);
        if (mb_MainMenu != null)
        {
            mb_MainMenu.setMaxButtonVisible(resizable);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JFrame#processWindowEvent(java.awt.event.WindowEvent)
     */
    @Override
    protected void processWindowEvent(WindowEvent e)
    {
        switch (e.getID())
        {
            // FForm关闭事件
            case WindowEvent.WINDOW_CLOSING:
                wExit();
                break;

            // FForm最小化事件
            case WindowEvent.WINDOW_ICONIFIED:
                wHide();
                break;

            case WindowEvent.WINDOW_DEICONIFIED:
                wView();
                break;

            // 忽略其他事件，交给FForm处理
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
        mb_MainMenu.addMenu(menu);
    }

    /**
     * 添加用户菜单项
     * 
     * @param item
     */
    public void addMenuItem(javax.swing.JMenuItem item)
    {
        mb_MainMenu.addMenuItem(item);
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
     * 设置最大化按钮是否显示<br />
     * 默认不显示
     * 
     * @param b
     */
    public void setMaxButtonVisible(boolean b)
    {
        mb_MainMenu.setMaxButtonVisible(b);
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
     * @return
     */
    public IPrpPlus getSoft()
    {
        return ms_MainSoft;
    }

    /**
     * @param soft
     */
    public void setSoft(IPrpPlus soft)
    {
        this.ms_MainSoft = soft;
        setResizable(false);
        if (soft != null)
        {
            setTitle(soft.wGetTitle());
            setIconImage(soft.wGetIconImage(IPrpPlus.ICON_LOGO0016));
        }
        else
        {
            setTitle("");
            setIconImage(null);
        }
    }

    /**
     * 系统退出事件处理
     * 
     * @param e
     */
    void wExit()
    {
        if (ms_MainSoft != null)
        {
            ms_MainSoft.wClosing();
        }
    }

    /**
     * 窗口最小化事件处理
     * 
     * @param e
     */
    void wHide()
    {
        if (ms_MainSoft != null)
        {
            ms_MainSoft.wDeiconified();
        }
    }

    /**
     * 窗口复原事件处理
     */
    void wView()
    {
        if (ms_MainSoft != null)
        {
            ms_MainSoft.wIconified();
        }
    }
}
