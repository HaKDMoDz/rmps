/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package com.amonsoft.bean;

import com.amonsoft.skin.ISkin;
import java.awt.event.WindowEvent;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author yihaodian
 */
public class WForm extends javax.swing.JApplet
{
    private WHead appHead;
    private javax.swing.JFrame appForm;
    private javax.swing.JPanel appPane;

    @Override
    public void init()
    {
        wInit(true);
    }

    public boolean wInit(boolean applet)
    {
        if (!applet)
        {
            appForm = new javax.swing.JFrame()
            {
                @Override
                protected void processWindowEvent(java.awt.event.WindowEvent evt)
                {
                    switch (evt.getID())
                    {
                        // 窗口关闭事件
                        case WindowEvent.WINDOW_CLOSING:
                            if (wExit())
                            {
                                super.processWindowEvent(evt);
                            }
                            break;
                        // 窗口最小化事件
                        case WindowEvent.WINDOW_ICONIFIED:
                            if (wHide())
                            {
                                super.processWindowEvent(evt);
                            }
                            break;
                        // 窗口最大化事件
                        case WindowEvent.WINDOW_DEICONIFIED:
                            if (wView())
                            {
                                super.processWindowEvent(evt);
                            }
                            break;
                        default:
                            super.processWindowEvent(evt);
                            break;
                    }
                }
            };
            appForm.getContentPane().setName(ISkin.CONTAINER);
        }
        else
        {
            getContentPane().setName(ISkin.CONTAINER);
        }
        return true;
    }

    protected boolean wExit()
    {
        return true;
    }

    protected boolean wHide()
    {
        return true;
    }

    protected boolean wView()
    {
        return true;
    }

    /**
     * 设置最大化按钮是否显示<br />
     * 默认不显示
     *
     * @param b
     */
    public void setMaxButtonVisible(boolean b)
    {
        appHead.setMaxButtonVisible(b);
    }

    /**
     * 设置菜单按钮是否显示<br />
     * 默认不显示
     *
     * @param b
     */
    public void setMenuButtonVisible(boolean b)
    {
        appHead.setMenuButtonVisible(b);
    }

    /**
     * 设置最小化按钮是否显示<br />
     * 默认显示
     *
     * @param b
     */
    public void setMinButtonVisible(boolean b)
    {
        appHead.setMinButtonVisible(b);
    }

    public void setState(int state)
    {
    }

    public void setTitle(String title)
    {
        if (appForm != null)
        {
            appForm.setTitle(title);
            if (appHead != null)
            {
                appHead.setTitle(title);
            }
        }
    }

    public void setIconImage(java.awt.Image image)
    {
        if (appForm != null)
        {
            appForm.setIconImage(image);
        }
        if (appHead != null)
        {
            appHead.setIconImage(image);
        }
    }

    @Override
    public void setJMenuBar(javax.swing.JMenuBar menubar)
    {
        if (appForm != null)
        {
            appForm.getRootPane().setJMenuBar(menubar);
        }
        else
        {
            getRootPane().setJMenuBar(menubar);
        }
    }

    @Override
    public java.awt.Container getContentPane()
    {
        if (appForm != null)
        {
            return appForm.isUndecorated() ? appPane : appForm.getContentPane();
        }
        return getRootPane().getContentPane();
    }

    @Override
    public void setContentPane(java.awt.Container contentPane)
    {
        if (appForm != null)
        {
            if (appForm.isUndecorated())
            {
                appForm.getContentPane().add(contentPane, java.awt.BorderLayout.CENTER);
            }
            else
            {
                appForm.setContentPane(contentPane);
            }
        }
        else
        {
            super.setContentPane(contentPane);
        }
    }

    public void setDefaultCloseOperation(int operation)
    {
        if (appForm != null)
        {
            appForm.setDefaultCloseOperation(operation);
        }
    }

    @Override
    public void setSize(java.awt.Dimension dimension)
    {
        if (appForm != null)
        {
            appForm.setSize(dimension);
        }
    }

    @Override
    public void setSize(int width, int height)
    {
        if (appForm != null)
        {
            appForm.setSize(width, height);
        }
    }

    @Override
    public void setVisible(boolean visible)
    {
        if (appForm != null)
        {
            appForm.setVisible(visible);
        }
    }

    public int getExtendedState()
    {
        return (appForm != null) ? appForm.getExtendedState() : -1;
    }

    public void setExtendedState(int state)
    {
        if (appForm != null)
        {
            appForm.setExtendedState(state);
        }
    }

    public final void setAlwaysOnTop(boolean alwaysOnTop) throws SecurityException
    {
        if (appForm != null)
        {
            appForm.setAlwaysOnTop(alwaysOnTop);
        }
    }

    public void pack()
    {
        if (appForm != null)
        {
            appForm.pack();
        }
    }

    public void center(javax.swing.JComponent component)
    {
        int x = 0;
        int y = 0;
        java.awt.Dimension dim;
        if (component != null)
        {
            java.awt.Point pnt = component.getLocationOnScreen();
            x = pnt.x;
            y = pnt.y;
            dim = component.getSize();
        }
        else
        {
            dim = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        }
        setLocation(x + (dim.width - getWidth()) >> 1, y + (dim.height - getHeight()) >> 1);
    }

    public void setUndecorated(boolean undecorated)
    {
        if (appForm != null)
        {
            appForm.setUndecorated(undecorated);
            if (undecorated)
            {
                appHead = new WHead(this);
                appHead.wInit();
                getContentPane().add(appHead, java.awt.BorderLayout.NORTH);

                appPane = new javax.swing.JPanel();
                appPane.setName(ISkin.PANEL_BASE);
                getContentPane().add(appPane, java.awt.BorderLayout.CENTER);
            }
        }
    }

    class WHead extends javax.swing.JPanel
    {
        private WForm form;

        /**
         * 默认构造函数
         */
        public WHead(WForm form)
        {
            this.form = form;
        }

        /*
         * (non-Javadoc)
         *
         * @see rmp.face.WRmps#wInit()
         */
        public boolean wInit()
        {
            initView();
            initLang();

            return true;
        }

        private void initView()
        {
            lb_Icon = new javax.swing.JLabel();
            lb_Text = new javax.swing.JLabel();
            lb_Menu = new javax.swing.JLabel();
            lb_Exit = new javax.swing.JLabel();
            lb_Full = new javax.swing.JLabel();
            lb_Exit = new javax.swing.JLabel();
            pm_Menu = new javax.swing.JPopupMenu();

            lb_Text.setName(ISkin.LABEL_TEXT);
            lb_Text.addMouseListener(new java.awt.event.MouseAdapter()
            {
                @Override
                public void mousePressed(java.awt.event.MouseEvent evt)
                {
                    p = form.getLocation();
                    m = evt.getPoint();
                }

                @Override
                public void mouseReleased(java.awt.event.MouseEvent evt)
                {
                    java.awt.Point c = evt.getPoint();
                    // p.x -= m.x;
                    // p.y -= m.y;
                    c.x -= m.x;
                    c.y -= m.y;
                    p.x += c.x;
                    p.y += c.y;
                    form.setLocation(p);
                }
            });
            lb_Text.addMouseMotionListener(new java.awt.event.MouseMotionAdapter()
            {
                @Override
                public void mouseDragged(java.awt.event.MouseEvent evt)
                {
                    java.awt.Point c = evt.getPoint();
                    c.x -= m.x;
                    c.y -= m.y;
                    p.x += c.x;
                    p.y += c.y;
                    form.setLocation(p);
                }
            });

            lb_Menu.setName(ISkin.LABEL_MENU);
            lb_Menu.addMouseListener(new java.awt.event.MouseListener()
            {
                @Override
                public void mouseClicked(java.awt.event.MouseEvent evt)
                {
//                if (form == null)
//                {
//                    form = new FMenu(ff);
//                    form.wInit();
//                }
//                fm.show(lb_MenuLabl, 0, lb_MenuLabl.getSize().height);
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

            lb_Exit.setName(ISkin.LABEL_HIDE);
            lb_Exit.addMouseListener(new java.awt.event.MouseListener()
            {
                @Override
                public void mouseClicked(java.awt.event.MouseEvent evt)
                {
                    form.setState(javax.swing.JFrame.ICONIFIED);
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

            lb_Full.setName(ISkin.LABEL_FULL);
            lb_Full.addMouseListener(new java.awt.event.MouseListener()
            {
                @Override
                public void mouseClicked(java.awt.event.MouseEvent evt)
                {
                    form.setExtendedState(form.getExtendedState() == javax.swing.JFrame.MAXIMIZED_BOTH ? javax.swing.JFrame.NORMAL : javax.swing.JFrame.MAXIMIZED_BOTH);
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

            lb_Exit.setName(ISkin.LABEL_EXIT);
            lb_Exit.addMouseListener(new java.awt.event.MouseListener()
            {
                @Override
                public void mouseClicked(java.awt.event.MouseEvent evt)
                {
//                ff.wExit();
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

            javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
            this.setLayout(layout);
            javax.swing.GroupLayout.SequentialGroup hsg = layout.createSequentialGroup();
            hsg.addContainerGap();
            hsg.addComponent(lb_Icon);
            hsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED);
            hsg.addComponent(lb_Text, javax.swing.GroupLayout.DEFAULT_SIZE, 88, Short.MAX_VALUE);
            hsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED);
            hsg.addComponent(lb_Exit);
            hsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED);
            hsg.addComponent(lb_Full);
            hsg.addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED);
            hsg.addComponent(lb_Exit);
            hsg.addContainerGap();
            layout.setHorizontalGroup(hsg);

            javax.swing.GroupLayout.ParallelGroup vpg = layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE);
            vpg.addComponent(lb_Exit);
            vpg.addComponent(lb_Full);
            vpg.addComponent(lb_Exit);
            vpg.addComponent(lb_Icon);
            vpg.addComponent(lb_Text);
            layout.setVerticalGroup(vpg);
        }

        /**
         * 标题语言初始化
         */
        private void initLang()
        {
            // 系统图标
            //lb_Icon.setIcon(new javax.swing.ImageIcon(BeanUtil.getLogoImage()));

            // 菜单按钮
            //lb_Menu.setIcon(new ImageIcon(""));
            lb_Menu.setText("+");
            lb_Menu.setToolTipText("快捷菜单");

            // 最小化按钮
            //lb_Exit.setIcon(new ImageIcon(""));
            lb_Exit.setText("_");
            lb_Exit.setToolTipText("隐藏窗口");

            // 最大化按钮
            //lb_Full.setIcon(new ImageIcon(""));
            lb_Full.setText("□");
            lb_Full.setToolTipText("还原窗口");

            // 退出按钮
            //lb_Exit.setIcon(new ImageIcon(""));
            lb_Exit.setText("×");
            lb_Exit.setToolTipText("关闭窗口");
        }

        /**
         * 添加用户级联菜单
         *
         * @param menu
         */
        public void addMenu(javax.swing.JMenu menu)
        {
            pm_Menu.add(menu);
        }

        /**
         * 添加用户菜单项
         *
         * @param item
         */
        public void addMenuItem(javax.swing.JMenuItem item)
        {
            pm_Menu.add(item);
        }

        /**
         * 设置退出按钮是否显示<br />
         * 默认显示
         *
         * @param b
         */
        public void setExitButtonVisible(boolean b)
        {
            lb_Exit.setVisible(b);
        }

        /**
         * 设置最大化按钮是否显示<br />
         * 默认不显示
         *
         * @param b
         */
        public void setMaxButtonVisible(boolean b)
        {
            lb_Full.setVisible(b);
        }

        /**
         * 设置菜单按钮是否显示<br />
         * 默认不显示
         *
         * @param b
         */
        public void setMenuButtonVisible(boolean b)
        {
            lb_Menu.setVisible(b);
        }

        /**
         * 设置最小化按钮是否显示<br />
         * 默认显示
         *
         * @param b
         */
        public void setMinButtonVisible(boolean b)
        {
            lb_Exit.setVisible(b);
        }

        /**
         * @param image
         */
        public void setIconImage(java.awt.Image image)
        {
            lb_Icon.setIcon(new javax.swing.ImageIcon(image));
        }

        /**
         * @param title
         */
        public void setTitle(String title)
        {
            lb_Text.setText(title);
            lb_Text.setToolTipText(title);
        }
        /** 窗口初始位置 */
        private java.awt.Point p;
        /** 鼠标点击位置 */
        private java.awt.Point m;
        /** 窗口关闭按钮 */
        private javax.swing.JLabel lb_Exit;
        /** 窗口菜单按钮 */
        private javax.swing.JLabel lb_Menu;
        /** 窗口还原按钮 */
        private javax.swing.JLabel lb_Full;
        /** 窗口图标标签 */
        private javax.swing.JLabel lb_Icon;
        /** 窗口文本标签 */
        private javax.swing.JLabel lb_Text;
        /** 系统默认菜单 */
        private javax.swing.JPopupMenu pm_Menu;
    }
}
