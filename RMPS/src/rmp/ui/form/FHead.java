/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.form;

import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JMenu;
import javax.swing.JMenuBar;

import rmp.face.WBean;
import rmp.util.BeanUtil;
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
class FHead extends JMenuBar implements WBean
{
    private FForm ff;
    private FMenu fm;

    /**
     * 默认构造函数
     */
    public FHead(FForm form)
    {
        this.ff = form;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        icb();
        ita();
        itb();

        lb_TextLabl.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
                p = ff.getLocation();
                m = evt.getPoint();
            }

            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                java.awt.Point c = evt.getPoint();
                // p.x -= m.x;
                // p.y -= m.y;
                c.x -= m.x;
                c.y -= m.y;
                p.x += c.x;
                p.y += c.y;
                ff.setLocation(p);
            }
        });
        lb_TextLabl.addMouseMotionListener(new java.awt.event.MouseMotionAdapter()
        {
            public void mouseDragged(java.awt.event.MouseEvent evt)
            {
                java.awt.Point c = evt.getPoint();
                c.x -= m.x;
                c.y -= m.y;
                p.x += c.x;
                p.y += c.y;
                ff.setLocation(p);
            }
        });
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.JMenuBar#add(javax.swing.JMenu)
     */
    public JMenu add(JMenu c)
    {
        super.add(c);
        return c;
    }

    /**
     * 标题布局初始化
     */
    private void ica()
    {
        // 水平间距
        final int HGAP = 10;
        // 垂直间距
        final int VGAP = 3;
        // 构件间距
        final int LGAP = 2;

        java.awt.GridBagConstraints gbc = new java.awt.GridBagConstraints();
        gbc.insets = new java.awt.Insets(0, 0, 0, 0);
        setLayout(new java.awt.GridBagLayout());

        lb_IconLabl = new javax.swing.JLabel();
        lb_IconLabl.setIcon(new ImageIcon(BeanUtil.getLogoImage()));
        gbc.insets.top = VGAP;
        gbc.insets.left = HGAP;
        gbc.insets.bottom = VGAP;
        gbc.insets.right = 0;
        add(lb_IconLabl, gbc);

        lb_TextLabl = new javax.swing.JLabel();
        lb_TextLabl.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;
        gbc.insets.left = 0;
        add(lb_TextLabl, gbc);

        lb_MenuLabl = new javax.swing.JLabel();
        lb_MenuLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        lb_MenuLabl.setName(ISkin.LABEL_MENU);
        lb_MenuLabl.setPreferredSize(lb_IconLabl.getPreferredSize());
        lb_MenuLabl.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                if (fm == null)
                {
                    fm = new FMenu(ff);
                    fm.wInit();
                }
                fm.show(lb_MenuLabl, 0, lb_MenuLabl.getSize().height);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
            }
        });
        gbc.fill = java.awt.GridBagConstraints.NONE;
        gbc.weightx = 0;
        gbc.insets.left = 0;
        gbc.insets.right = LGAP;
        add(lb_MenuLabl, gbc);

        lb_HideLabl = new javax.swing.JLabel();
        lb_HideLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        lb_HideLabl.setName(ISkin.LABEL_HIDE);
        lb_HideLabl.setPreferredSize(lb_IconLabl.getPreferredSize());
        lb_HideLabl.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ff.setState(FForm.ICONIFIED);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
            }
        });
        gbc.insets.left = LGAP;
        add(lb_HideLabl, gbc);

        lb_FullLabl = new javax.swing.JLabel();
        lb_FullLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        lb_FullLabl.setName(ISkin.LABEL_FULL);
        lb_FullLabl.setPreferredSize(lb_IconLabl.getPreferredSize());
        lb_FullLabl.setVisible(false);
        lb_FullLabl.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ff.setExtendedState(ff.getExtendedState() == FForm.MAXIMIZED_BOTH ? FForm.NORMAL
                        : FForm.MAXIMIZED_BOTH);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
            }
        });
        add(lb_FullLabl, gbc);

        lb_ExitLabl = new javax.swing.JLabel();
        lb_ExitLabl.setHorizontalAlignment(javax.swing.JLabel.CENTER);
        lb_ExitLabl.setName(ISkin.LABEL_EXIT);
        lb_ExitLabl.setPreferredSize(lb_IconLabl.getPreferredSize());
        lb_ExitLabl.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ff.wExit();
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
            }

            @Override
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
            }
        });
        gbc.insets.right = HGAP;
        add(lb_ExitLabl, gbc);
    }

    /**
     * 系统菜单初始化
     */
    private void icb()
    {
        pm_MainMenu = new javax.swing.JPopupMenu();
    }

    /**
     * 标题语言初始化
     */
    private void ita()
    {
        // 系统图标
        lb_IconLabl.setIcon(new ImageIcon(BeanUtil.getLogoImage()));

        // 菜单按钮
        lb_MenuLabl.setIcon(new ImageIcon(""));
        lb_MenuLabl.setText("+");
        lb_MenuLabl.setToolTipText("快捷菜单");

        // 最小化按钮
        lb_HideLabl.setIcon(new ImageIcon(""));
        lb_HideLabl.setText("_");
        lb_HideLabl.setToolTipText("隐藏窗口");

        // 最大化按钮
        lb_FullLabl.setIcon(new ImageIcon(""));
        lb_FullLabl.setText("□");
        lb_FullLabl.setToolTipText("还原窗口");

        // 退出按钮
        lb_ExitLabl.setIcon(new ImageIcon(""));
        lb_ExitLabl.setText("×");
        lb_ExitLabl.setToolTipText("关闭窗口");
    }

    /**
     * 系统菜单语言初始化
     */
    private void itb()
    {
    }

    /**
     * 添加用户级联菜单
     * 
     * @param menu
     */
    public void addMenu(javax.swing.JMenu menu)
    {
        pm_MainMenu.add(menu);
    }

    /**
     * 添加用户菜单项
     * 
     * @param item
     */
    public void addMenuItem(javax.swing.JMenuItem item)
    {
        pm_MainMenu.add(item);
    }

    /**
     * 设置退出按钮是否显示<br />
     * 默认显示
     * 
     * @param b
     */
    public void setExitButtonVisible(boolean b)
    {
        lb_ExitLabl.setVisible(b);
    }

    /**
     * 设置最大化按钮是否显示<br />
     * 默认不显示
     * 
     * @param b
     */
    public void setMaxButtonVisible(boolean b)
    {
        lb_FullLabl.setVisible(b);
    }

    /**
     * 设置菜单按钮是否显示<br />
     * 默认不显示
     * 
     * @param b
     */
    public void setMenuButtonVisible(boolean b)
    {
        lb_MenuLabl.setVisible(b);
    }

    /**
     * 设置最小化按钮是否显示<br />
     * 默认显示
     * 
     * @param b
     */
    public void setMinButtonVisible(boolean b)
    {
        lb_HideLabl.setVisible(b);
    }

    /**
     * @param image
     */
    public void setIconImage(Image image)
    {
        lb_IconLabl.setIcon(new ImageIcon(image));
    }

    /**
     * @param title
     */
    public void setTitle(String title)
    {
        lb_TextLabl.setText(title);
        lb_TextLabl.setToolTipText(title);
    }
    /** 窗口初始位置 */
    private java.awt.Point p;
    /** 鼠标点击位置 */
    private java.awt.Point m;
    /** 窗口关闭按钮 */
    private javax.swing.JLabel lb_ExitLabl;
    /** 窗口隐藏按钮 */
    private javax.swing.JLabel lb_HideLabl;
    /** 窗口菜单按钮 */
    private javax.swing.JLabel lb_MenuLabl;
    /** 窗口还原按钮 */
    private javax.swing.JLabel lb_FullLabl;
    /** 窗口图标标签 */
    private javax.swing.JLabel lb_IconLabl;
    /** 窗口文本标签 */
    private javax.swing.JLabel lb_TextLabl;
    /** 系统默认菜单 */
    private javax.swing.JPopupMenu pm_MainMenu;
}
