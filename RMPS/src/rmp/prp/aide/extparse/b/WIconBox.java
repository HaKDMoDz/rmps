/*
 * FileName:       WIconBox.java
 * CreateDate:     2007-7-11 下午11:12:36
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.b;

import java.awt.Cursor;
import java.awt.Dimension;
import java.awt.Image;
import java.awt.Paint;
import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.io.File;
import java.io.IOException;

import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JPopupMenu;

import rmp.face.WBean;
import rmp.prp.aide.extparse.Extparse;
import rmp.ui.icon.WIconLabel;
import rmp.util.CheckUtil;
import rmp.util.FileUtil;
import rmp.util.HashUtil;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.EnvCons;
import cons.SysCons;
import cons.prp.aide.extparse.LangRes;
import cons.ui.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 图标专用构件
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-7-11 下午11:12:36
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class WIconBox extends JPanel implements WBean
{
    /**  */
    private static final long serialVersionUID = 3498132523007130752L;
    /** 当前快速预览窗口所属IconBox名称 */
    private static String     miniFormName;
    /** 用户是否可以通过鼠标选择图像背景文件 */
    private boolean           userEditable;
    /** 是否显示快速预览窗口 */
    private boolean           showMiniForm;
    /** 背景图像文件路径对象 */
    private File              extPath;
    /** PNG文件目录 */
    private String            iconPath;
    /** PNG文件名称 */
    private String            iconHash;
    /** 父应用引用 */
    private Extparse          me_MainSoft;

    /**
     * @param soft
     */
    public WIconBox(Extparse soft)
    {
        this.me_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        miniFormName = "";
        userEditable = false;
        showMiniForm = true;
        iconHash = "0";

        ica();

        return true;
    }

    /**
     * @return the miniFormName
     */
    public static String getMiniFormName()
    {
        return miniFormName;
    }

    /**
     * @param miniFormName the miniFormName to set
     */
    public static void setMiniFormName(String miniFormName)
    {
        WIconBox.miniFormName = miniFormName;
    }

    /**
     * @return the showMiniForm
     */
    public boolean isShowMiniForm()
    {
        return showMiniForm;
    }

    /**
     * @param b
     */
    public void setShowMiniForm(boolean b)
    {
        il_IconLabel.setComponentPopupMenu(b ? pm_MiniView : null);
    }

    /**
     * @return the userEditable
     */
    public boolean isUserEditable()
    {
        return userEditable;
    }

    /**
     * @param userEditable the userEditable to set
     */
    public void setUserEditable(boolean userEditable)
    {
        this.userEditable = userEditable;
        if (userEditable)
        {
            il_IconLabel.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        }
        else
        {
            il_IconLabel.setCursor(Cursor.getDefaultCursor());
        }
    }

    /**
     * @return
     */
    public Image getBackgroundImage()
    {
        return il_IconLabel.getBackgroundImage();
    }

    /**
     * @param image
     * @return
     */
    public Image setBackgroundImage(Image image)
    {
        return il_IconLabel.setBackgroundImage(image);
    }

    /**
     * @return
     */
    public Paint getBackgroundPaint()
    {
        return il_IconLabel.getBackgroundPaint();
    }

    /**
     * @param paint
     * @return
     */
    public Paint setBackgroundPaint(Paint paint)
    {
        return il_IconLabel.setBackgroundPaint(paint);
    }

    /**
     * @return the iconLabel
     */
    public WIconLabel getIconLabel()
    {
        return il_IconLabel;
    }

    /**
     * @return the extPath
     */
    public File getExtPath()
    {
        return extPath;
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
     * @return the iconHash
     */
    public String getIconHash()
    {
        return iconHash;
    }

    /**
     * @param iconHash the iconHash to set
     */
    public void setIconHash(String iconHash)
    {
        setIconHash(iconHash, false);
    }

    /**
     * @param iconHash 图像文件名称
     * @param miniChg 是否强制更改预览窗口图像
     */
    public void setIconHash(String iconHash, boolean miniChg)
    {
        this.iconHash = iconHash;
        Extparse.readEnvImage(il_IconLabel, iconPath, iconHash, SysCons.ICON_SIZE_0048);
        if (miniFormName.equals(getName()) || miniChg)
        {
            if_IconForm.readPngImage(iconPath, iconHash);
        }
    }

    /**
     * @return
     */
    public boolean saveExtImage()
    {
        // 用户选择图像文件对象
        // 用户没有改变图像文件的情况下，直接返回
        if (extPath == null)
        {
            return true;
        }

        // 目录存储目录文件路径
        if (iconPath == null)
        {
            return false;
        }

        // 图像文件名称
        if (iconHash == null || "0".equals(iconHash))
        {
            iconHash = HashUtil.getCurrTimeHex(true);
        }

        // 图像存储
        try
        {
            ImageUtil.saveExtImage(extPath.getPath(), iconPath, iconHash);
        }
        catch(IOException exp)
        {
            LogUtil.exception(exp);
            return false;
        }

        extPath = null;
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
        mi_MiniView = new javax.swing.JMenuItem("显示预览窗口");
        pm_MiniView.add(mi_MiniView);
        mi_MiniView.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent ent)
            {
                mi_MiniView_Handler(ent);
            }
        });

        mi_InfoView = new javax.swing.JMenuItem("显示详细信息");
        pm_MiniView.add(mi_InfoView);
        mi_InfoView.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent ent)
            {
                mi_InfoView_Handler(ent);
            }
        });

        il_IconLabel = new WIconLabel();
        il_IconLabel.setToolTipText("\u56fe\u6807");
        il_IconLabel.setComponentPopupMenu(pm_MiniView);
        il_IconLabel.setMaximumSize(new java.awt.Dimension(ConstUI.ICON_WIDH + 4, ConstUI.ICON_HIGH + 4));
        il_IconLabel.setMinimumSize(new java.awt.Dimension(ConstUI.ICON_WIDH, ConstUI.ICON_HIGH));
        il_IconLabel.setPreferredSize(new java.awt.Dimension(ConstUI.ICON_WIDH + 2, ConstUI.ICON_HIGH + 2));
        add(il_IconLabel, java.awt.BorderLayout.CENTER);

        il_IconLabel.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                il_IconLabel_MouseClicked_Handler(evt);
            }
        });
    }

    /**
     * @param ent
     */
    private void il_IconLabel_MouseClicked_Handler(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() > 1)
        {
            showInfoForm();
            return;
        }

        // 可编辑状态下，显示打开文件对话框
        if (userEditable)
        {
            // 显示文件打开对话框
            extPath = FileUtil.showSingleFileOpen(this, false, null);

            try
            {
                // 用户选择图像显示
                Image image;
                if (extPath != null)
                {
                    image = ImageUtil.readExtImage(extPath.getPath());
                }
                else
                {
                    image = ImageUtil.readExtImage(iconPath + EnvCons.COMN_SP_FILE + "0030.png");
                }
                il_IconLabel.setBackgroundImage(image);
            }
            catch(IOException exp)
            {
                LogUtil.exception(exp);
                String arg1 = Extparse.getMesg(LangRes.MESG_INIT_0010);
                String mesg = StringUtil.format(LangRes.IDIO_MESG_ICON_0001, "", arg1);
                MesgUtil.showMessageDialog(Extparse.getForm(), mesg);
            }
        }
        // 不可编辑状态下，显示预览图像
        else
        {
            if (if_IconForm != null && if_IconForm.isVisible())
            {
                if_IconForm.readPngImage(iconPath, iconHash);
            }
        }
    }

    /**
     * @param evt
     */
    private void mi_InfoView_Handler(java.awt.event.ActionEvent evt)
    {
        showInfoForm();
    }

    /**
     * @param ent
     */
    private void mi_MiniView_Handler(java.awt.event.ActionEvent evt)
    {
        // 预览窗口
        if (if_IconForm == null)
        {
            // if_IconForm = new WIconForm(Extparse.getForm());
            if_IconForm.wInit();
            if_IconForm.pack();
        }

        // 可视设定
        if (!if_IconForm.isVisible())
        {
            if_IconForm.setVisible(true);
        }

        // 位置设定
        if (!if_IconForm.isPointLocked())
        {
            Point p = this.getLocationOnScreen();
            Dimension s = this.getSize();
            p.y += s.height;
            if_IconForm.setLocation(p);
        }

        if_IconForm.toFront();

        // 图标设定
        if_IconForm.readPngImage(iconPath, iconHash);
    }

    /**
     * 显示详细信息面板
     */
    private void showInfoForm()
    {
        String iconName = getName();
        // 文件图标
        if (cons.prp.aide.extparse.ConstUI.PROP_FILEICON.equals(iconName))
        {
            String fileHash = me_MainSoft.getBaseData().getFileIndx();
            if (CheckUtil.isValidate(fileHash))
            {
                me_MainSoft.showFileForm().hashSelect(fileHash);
            }
            return;
        }
        // 软件图标
        if (cons.prp.aide.extparse.ConstUI.PROP_SOFTICON.equals(iconName))
        {
            String softHash = me_MainSoft.getBaseData().getSoftIndx();
            if (CheckUtil.isValidate(softHash))
            {
                me_MainSoft.showSoftForm().hashSelect(softHash);
            }
            return;
        }
        // 公司图标
        if (cons.prp.aide.extparse.ConstUI.PROP_CORPICON.equals(iconName))
        {
            String corpHash = me_MainSoft.getBaseData().getCorpIndx();
            if (CheckUtil.isValidate(corpHash))
            {
                me_MainSoft.showCorpForm().hashSelect(corpHash);
            }
            return;
        }
        // 个人图标
        if (cons.prp.aide.extparse.ConstUI.PROP_IDIOICON.equals(iconName))
        {
            String idioHash = me_MainSoft.getBaseData().getIdioIndx();
            if (CheckUtil.isValidate(idioHash))
            {
                me_MainSoft.showIdioForm().hashSelect(idioHash);
            }
            return;
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 迷你窗口主面板 */
    private static WIconForm if_IconForm;
    /** 标签 */
    private WIconLabel       il_IconLabel;
    /** 图标预览 */
    private JMenuItem        mi_MiniView;
    /** 详细信息 */
    private JMenuItem        mi_InfoView;
    /** 图像右键菜单 */
    private JPopupMenu       pm_MiniView;
}
