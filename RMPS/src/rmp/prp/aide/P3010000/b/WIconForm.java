/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import java.awt.Point;

import javax.swing.ImageIcon;

import rmp.prp.aide.P30F0000.P30F0000;
import rmp.util.BeanUtil;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import rmp.util.StringUtil;
import cons.EnvCons;
import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 图像预览窗口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class WIconForm extends javax.swing.JDialog
{
    private static WIconForm iconForm;
    /** 图标大小 */
    private int iconSize;
    /** 图标路径 */
    private String iconPath;
    /** 图标名称 */
    private String iconName;

    /**
     * 
     */
    private WIconForm()
    {
        super((javax.swing.JFrame) P30F0000.getForm());
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        setUndecorated(true);

        iconSize = 128;

        ica();
        ita();

        return true;
    }

    /**
     * @param owner
     */
    public static WIconForm getInstance()
    {
        if (iconForm == null)
        {
            iconForm = new WIconForm();
            iconForm.wInit();
        }
        return iconForm;
    }

    /**
     * 
     */
    private void ica()
    {
        javax.swing.JPanel pl_Contxt = new javax.swing.JPanel();
        javax.swing.JPanel pl_Switch = new javax.swing.JPanel();
        lb_IconView = new javax.swing.JLabel();
        bt_ExptPng = new javax.swing.JButton();
        bt_ExptIco = new javax.swing.JButton();
        bt_HideWnd = new javax.swing.JButton();
        bt_LockPos = new javax.swing.JToggleButton();
        bt_ViewMod = new javax.swing.JButton();

        lb_IconView.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_IconView.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        lb_IconView.setPreferredSize(new java.awt.Dimension(132, 132));

        bt_ExptPng.setMnemonic('P');
        bt_ExptPng.setText("P");
        bt_ExptPng.setToolTipText("导出为PNG格式图像文件");
        bt_ExptPng.setMargin(new java.awt.Insets(2, 2, 2, 2));
        bt_ExptPng.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExptPng_Handler(evt);
            }
        });

        bt_ExptIco.setMnemonic('C');
        bt_ExptIco.setText("C");
        bt_ExptIco.setToolTipText("导出为ICO图像格式文件");
        bt_ExptIco.setMargin(new java.awt.Insets(2, 2, 2, 2));
        bt_ExptIco.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExptIco_Handler(evt);
            }
        });

        bt_HideWnd.setMnemonic('X');
        bt_HideWnd.setText("X");
        bt_HideWnd.setToolTipText("关闭图像预览窗口");
        bt_HideWnd.setMargin(new java.awt.Insets(2, 2, 2, 2));
        bt_HideWnd.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_HideWnd_Handler(evt);
            }
        });

        bt_LockPos.setMnemonic('L');
        bt_LockPos.setText("L");
        bt_LockPos.setToolTipText("锁定预览窗口位置");
        bt_LockPos.setMargin(new java.awt.Insets(2, 2, 2, 2));
        bt_LockPos.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LockPos_Handler(evt);
            }
        });

        pl_Switch.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 5, 0));

        bt_ViewMod.setMnemonic('V');
        bt_ViewMod.setText("V");
        bt_ViewMod.setToolTipText("显示256*256窗口");
        bt_ViewMod.setMargin(new java.awt.Insets(2, 2, 2, 2));
        bt_ViewMod.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ViewMod_Handler(evt);
            }
        });
        pl_Switch.add(bt_ViewMod);

        pl_Contxt.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        pl_Contxt.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mousePressed(java.awt.event.MouseEvent evt)
            {
                pc_MousePressed(evt);
            }

            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                pc_MouseReleased(evt);
            }
        });
        pl_Contxt.addMouseMotionListener(new java.awt.event.MouseMotionAdapter()
        {
            public void mouseDragged(java.awt.event.MouseEvent evt)
            {
                pc_MouseDragged(evt);
            }
        });
        setContentPane(pl_Contxt);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_Contxt);
        pl_Contxt.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(lb_IconView,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                layout.createSequentialGroup().addComponent(bt_ExptPng).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_ExptIco).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_Switch,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_LockPos).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_HideWnd))).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_IconView,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_ExptPng).addComponent(bt_ExptIco).addComponent(bt_HideWnd).addComponent(bt_LockPos)).addComponent(
                pl_Switch, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE)));
    }

    /**
     * 预览模式快捷菜单初始化
     */
    private void icb()
    {
        pm_ViewMod = new javax.swing.JPopupMenu();
        mi_View128 = new javax.swing.JCheckBoxMenuItem();
        mi_View192 = new javax.swing.JCheckBoxMenuItem();
        mi_View256 = new javax.swing.JCheckBoxMenuItem();
        javax.swing.ButtonGroup bg = new javax.swing.ButtonGroup();

        mi_View128.setText("128*128模式(A)");
        mi_View128.setToolTipText("以128*128大小窗口预览图像");
        mi_View128.setMnemonic('A');
        mi_View128.setSelected(true);
        mi_View128.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_View128_Handler(evt);
            }
        });
        bg.add(mi_View128);
        pm_ViewMod.add(mi_View128);

        mi_View192.setText("192*192模式(B)");
        mi_View192.setToolTipText("以192*192大小窗口预览图像");
        mi_View192.setMnemonic('B');
        mi_View192.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_View192_Handler(evt);
            }
        });
        bg.add(mi_View192);
        pm_ViewMod.add(mi_View192);

        mi_View256.setText("256*256模式(C)");
        mi_View256.setToolTipText("以256*256大小窗口预览图像");
        mi_View256.setMnemonic('C');
        mi_View256.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_View256_Handler(evt);
            }
        });
        bg.add(mi_View256);
        pm_ViewMod.add(mi_View256);
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 
     */
    private void itb()
    {
    }

    // ========================================================================
    // 对外接口区域
    // ========================================================================
    /**
     * 设置图片提示信息
     * 
     * @param tips
     */
    public void setWTips(String tips)
    {
        lb_IconView.setToolTipText(tips);
    }

    /**
     * @return the iconPath
     */
    public String getIconPath()
    {
        return iconPath;
    }

    /**
     * @param iconPath the iconPath to set
     */
    public void setIconPath(String iconPath)
    {
        this.iconPath = iconPath;
    }

    /**
     * @return the iconName
     */
    public String getIconName()
    {
        return iconName;
    }

    /**
     * @param iconName the iconName to set
     */
    public void setIconName(String iconName)
    {
        this.iconName = iconName;
    }

    /**
     * @param iconPath
     * @param iconName
     */
    public void viewImage(String iconPath, String iconName)
    {
        this.iconPath = iconPath;
        this.iconName = iconName;

        viewImage();
    }

    /**
     * 
     */
    private void viewImage()
    {
        String size = StringUtil.lPad(Integer.toHexString(iconSize), 4, '0');
        String path = iconPath + EnvCons.COMN_SP_FILE + iconName + size + SysCons.EXTS_ICON;
        lb_IconView.setIcon(new ImageIcon(ImageUtil.readImage(path)));
    }

    // ========================================================================
    // 事件处理区域
    // ========================================================================
    /**
     * @param evt
     */
    private void bt_ExptPng_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void bt_ExptIco_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void bt_LockPos_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void bt_HideWnd_Handler(java.awt.event.ActionEvent evt)
    {
        setVisible(false);
        dispose();
    }

    /**
     * @param evt
     */
    private void bt_ViewMod_Handler(java.awt.event.ActionEvent evt)
    {
        if (pm_ViewMod == null)
        {
            LogUtil.log("快捷菜单初始化！");
            icb();
            itb();
        }
        java.awt.Dimension s = bt_ViewMod.getSize();
        pm_ViewMod.show(bt_ViewMod, 0, s.height);
    }

    /**
     * @param evt
     */
    private void mi_View128_Handler(java.awt.event.ActionEvent evt)
    {
        bt_ExptPng.setIcon(null);
        bt_ExptPng.setText("P");

        bt_ExptIco.setIcon(null);
        bt_ExptIco.setText("C");

        bt_ViewMod.setIcon(null);
        bt_ViewMod.setText("V");

        bt_LockPos.setIcon(null);
        bt_LockPos.setText("L");

        bt_HideWnd.setIcon(null);
        bt_HideWnd.setText("X");

        iconSize = 128;
        viewImage();
        int t = iconSize + 4;
        lb_IconView.setPreferredSize(new java.awt.Dimension(t, t));
        lb_IconView.setSize(t, t);

        validate();
        pack();
    }

    /**
     * @param evt
     */
    private void mi_View192_Handler(java.awt.event.ActionEvent evt)
    {
        bt_ExptPng.setIcon(null);
        bt_ExptPng.setText("P");

        bt_ExptIco.setIcon(null);
        bt_ExptIco.setText("C");

        bt_ViewMod.setIcon(null);
        bt_ViewMod.setText("V");

        bt_LockPos.setIcon(null);
        bt_LockPos.setText("L");

        bt_HideWnd.setIcon(null);
        bt_HideWnd.setText("X");

        iconSize = 192;
        viewImage();
        int t = iconSize + 4;
        lb_IconView.setPreferredSize(new java.awt.Dimension(t, t));
        lb_IconView.setSize(t, t);

        validate();
        pack();
    }

    /**
     * @param evt
     */
    private void mi_View256_Handler(java.awt.event.ActionEvent evt)
    {
        bt_ExptPng.setIcon(new ImageIcon(BeanUtil.getLogoImage()));
        bt_ExptPng.setText("");

        bt_ExptIco.setIcon(new ImageIcon(BeanUtil.getLogoImage()));
        bt_ExptIco.setText("");

        bt_ViewMod.setIcon(new ImageIcon(BeanUtil.getLogoImage()));
        bt_ViewMod.setText("");

        bt_LockPos.setIcon(new ImageIcon(BeanUtil.getLogoImage()));
        bt_LockPos.setText("");

        bt_HideWnd.setIcon(new ImageIcon(BeanUtil.getLogoImage()));
        bt_HideWnd.setText("");

        iconSize = 256;
        viewImage();
        int t = iconSize + 4;
        lb_IconView.setPreferredSize(new java.awt.Dimension(t, t));
        lb_IconView.setSize(t, t);

        validate();
        pack();
    }

    /**
     * @param evt
     */
    private void pc_MouseDragged(java.awt.event.MouseEvent evt)
    {
        if (bt_LockPos.isSelected())
        {
            return;
        }

        Point c = evt.getPoint();
        c.x -= m.x;
        c.y -= m.y;
        p.x += c.x;
        p.y += c.y;
        this.setLocation(p);
    }

    /**
     * @param evt
     */
    private void pc_MousePressed(java.awt.event.MouseEvent evt)
    {
        if (bt_LockPos.isSelected())
        {
            return;
        }

        p = this.getLocation();
        m = evt.getPoint();
    }

    /**
     * @param evt
     */
    private void pc_MouseReleased(java.awt.event.MouseEvent evt)
    {
        if (bt_LockPos.isSelected())
        {
            return;
        }

        Point c = evt.getPoint();
        c.x -= m.x;
        c.y -= m.y;
        p.x += c.x;
        p.y += c.y;
        this.setLocation(p);
    }
    // ========================================================================
    // 界面变量区域
    // ========================================================================
    /** 窗口初始位置 */
    private Point p;
    /** 鼠标点击位置 */
    private Point m;
    private javax.swing.JPopupMenu pm_ViewMod;
    private javax.swing.JCheckBoxMenuItem mi_View128;
    private javax.swing.JCheckBoxMenuItem mi_View192;
    private javax.swing.JCheckBoxMenuItem mi_View256;
    private javax.swing.JButton bt_ExptIco;
    private javax.swing.JButton bt_ExptPng;
    private javax.swing.JButton bt_HideWnd;
    private javax.swing.JToggleButton bt_LockPos;
    private javax.swing.JButton bt_ViewMod;
    private javax.swing.JLabel lb_IconView;
    /** serialVersionUID */
    private static final long serialVersionUID = 6645127861648852258L;
}
