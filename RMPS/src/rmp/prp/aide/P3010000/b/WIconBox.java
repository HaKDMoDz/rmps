/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import rmp.face.WBackCall;
import rmp.prp.aide.P3010000.P3010000;
import rmp.ui.icon.WIconLabel;
import rmp.util.ImageUtil;
import cons.EnvCons;
import cons.SysCons;
import cons.ui.ConstUI;

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
public class WIconBox extends javax.swing.JPanel
{
    /** 图标文件目录 */
    private String iconPath;
    /** 图标文件名称（即数据库中图标索引） */
    private String iconName;
    /** 回调事件对象 */
    private WBackCall bc_BackCall;

    /**
     * 
     */
    public WIconBox(P3010000 soft)
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        setBorder(javax.swing.BorderFactory.createEtchedBorder());
        setLayout(new java.awt.BorderLayout());

        pm_MiniView = new javax.swing.JPopupMenu();

        // 预览窗口
        mi_IconView = new javax.swing.JMenuItem("显示预览窗口");
        mi_IconView.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_IconView_Handler(evt);
            }
        });
        pm_MiniView.add(mi_IconView);

        // 选择图标
        mi_OpenIcon = new javax.swing.JMenuItem("更新图标数据");
        mi_OpenIcon.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_OpenIcon_Handler(evt);
            }
        });
        pm_MiniView.add(mi_OpenIcon);

        // 清除图标
        mi_DeltIcon = new javax.swing.JMenuItem("清除图标数据");
        mi_DeltIcon.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DeltIcon_Handler(evt);
            }
        });
        pm_MiniView.add(mi_DeltIcon);

        il_IconView = new WIconLabel();
        il_IconView.setComponentPopupMenu(pm_MiniView);
        il_IconView.setMaximumSize(new java.awt.Dimension(ConstUI.ICON_WIDH + 4, ConstUI.ICON_HIGH + 4));
        il_IconView.setMinimumSize(new java.awt.Dimension(ConstUI.ICON_WIDH, ConstUI.ICON_HIGH));
        il_IconView.setPreferredSize(new java.awt.Dimension(ConstUI.ICON_WIDH + 2, ConstUI.ICON_HIGH + 2));
        add(il_IconView, java.awt.BorderLayout.CENTER);

        il_IconView.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                il_IconLabel_Handler(evt);
            }
        });
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 显示预览窗口事件处理
     * 
     * @param evt
     */
    private void mi_IconView_Handler(java.awt.event.ActionEvent evt)
    {
        WIconForm.getInstance().viewImage(iconPath, iconName);
    }

    /**
     * @param evt
     */
    private void il_IconLabel_Handler(java.awt.event.MouseEvent evt)
    {
        WIconForm.getInstance().viewImage(iconPath, iconName);
    }

    /**
     * @param evt
     */
    private void mi_DeltIcon_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void mi_OpenIcon_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param backCall
     */
    public void enableEvent(WBackCall backCall)
    {
        if (backCall != null && mi_InfoView == null)
        {
            // 分隔符
            sp1 = new javax.swing.JPopupMenu.Separator();
            pm_MiniView.add(sp1);

            // 详细信息
            mi_InfoView = new javax.swing.JMenuItem("显示详细信息");
            mi_InfoView.addActionListener(new java.awt.event.ActionListener()
            {
                public void actionPerformed(java.awt.event.ActionEvent evt)
                {
                    if (bc_BackCall != null)
                    {
                        bc_BackCall.wAction(evt, mi_InfoView, null);
                    }
                }
            });
            pm_MiniView.add(mi_InfoView);
        }
        else if (mi_InfoView != null)
        {
            pm_MiniView.remove(mi_InfoView);
            pm_MiniView.remove(sp1);
        }
        bc_BackCall = backCall;
    }

    /**
     * 设置图标文档路径
     * 
     * @param path
     */
    public void setIconPath(String path)
    {
        iconPath = path;
    }

    /**
     * 获取图标文档路径
     * 
     * @param path
     * @return
     */
    public String getIconPath(String path)
    {
        return iconPath;
    }

    /**
     * 设置图标文档名称
     * 
     * @param hash
     */
    public void setIconName(String name)
    {
        iconName = name;
        String path = iconPath + EnvCons.COMN_SP_FILE + iconName + "0030" + SysCons.EXTS_ICON;
        ii_ImageIcon.setImage(ImageUtil.readImage(path));
        il_IconView.setIcon(new javax.swing.ImageIcon(ImageUtil.readImage(path)));
    }

    /**
     * 获取图标文档名称
     */
    public String getIconName()
    {
        return iconName;
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 标签 */
    private javax.swing.JLabel il_IconView;
    /** 图标预览 */
    private javax.swing.JMenuItem mi_IconView;
    /** 详细信息 */
    private javax.swing.JMenuItem mi_InfoView;
    /** 清除图标 */
    private javax.swing.JMenuItem mi_DeltIcon;
    /** 选择图标 */
    private javax.swing.JMenuItem mi_OpenIcon;
    /** 图像右键菜单 */
    private javax.swing.JPopupMenu pm_MiniView;
    /**  */
    private javax.swing.JPopupMenu.Separator sp1;
    private javax.swing.ImageIcon ii_ImageIcon;
    /** serialVersionUID */
    private static final long serialVersionUID = 8781384858161453421L;
}
