/*
 * FileName:       WIconForm.java
 * CreateDate:     2007-7-14 上午08:54:32
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.b;

import java.awt.Point;
import java.io.File;
import java.io.IOException;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;

import rmp.bean.FilesFilter;
import rmp.face.WBean;
import rmp.prp.aide.extparse.Extparse;
import rmp.ui.icon.WIconLabel;
import rmp.util.FileUtil;
import rmp.util.ImageUtil;
import rmp.util.LogUtil;
import cons.EnvCons;
import cons.SysCons;
import com.amonsoft.skin.ISkin;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 图像快速预览窗口
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
 * 日期： 2007-7-14 上午08:54:32
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class WIconForm extends JDialog implements WBean
{
    /**  */
    private static final long serialVersionUID = -6331881788469650979L;
    /** 窗口位置是否锁定 */
    private boolean           pntLocked;
    /** PNG图像文件目录 */
    private String            pngFolder;
    /** PNG图像文件名称 */
    private String            pngName;

    /**
     * @param owner
     */
    public WIconForm(JFrame owner)
    {
        super(owner);

        this.setUndecorated(true);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        ica();

        return true;
    }

    /**
     * 窗口位置是否锁定
     * 
     * @return
     */
    public boolean isPointLocked()
    {
        return pntLocked;
    }

    /**
     * @param filePath
     * @param fileName
     */
    public void readPngImage(String filePath, String fileName)
    {
        this.pngFolder = filePath;
        this.pngName = fileName;
        Extparse.readEnvImage(il_IconLbl, pngFolder, pngName, SysCons.ICON_SIZE_0128);
    }

    /**
     * 
     */
    private void ica()
    {
        javax.swing.JPanel pc = new javax.swing.JPanel();
        pc.setName(ISkin.PANEL_VIEW);

        il_IconLbl = new rmp.ui.icon.WIconLabel();
        bt_SavePng = new javax.swing.JButton();
        bt_SaveIco = new javax.swing.JButton();
        bt_HideWnd = new javax.swing.JButton();
        bt_LockPnt = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        pc.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        pc.addMouseListener(new java.awt.event.MouseAdapter()
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
        pc.addMouseMotionListener(new java.awt.event.MouseMotionAdapter()
        {
            public void mouseDragged(java.awt.event.MouseEvent evt)
            {
                pc_MouseDragged(evt);
            }
        });

        il_IconLbl.setToolTipText("\u5feb\u901f\u9884\u89c8");
        il_IconLbl.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        il_IconLbl.setMaximumSize(new java.awt.Dimension(132, 132));
        il_IconLbl.setMinimumSize(new java.awt.Dimension(128, 128));
        il_IconLbl.setPreferredSize(new java.awt.Dimension(130, 130));

        bt_SavePng.setText("P");
        bt_SavePng.setToolTipText("\u5bfc\u51fa\u4e3aPNG\u56fe\u50cf");
        bt_SavePng.setFocusPainted(false);
        bt_SavePng.setFocusable(false);
        bt_SavePng.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_SavePng.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_SavePng.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_SavePng.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_SavePng.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SavePng_Handler(evt);
            }
        });

        bt_SaveIco.setText("C");
        bt_SaveIco.setToolTipText("\u5bfc\u51fa\u4e3aICO\u56fe\u50cf");
        bt_SaveIco.setFocusPainted(false);
        bt_SaveIco.setFocusable(false);
        bt_SaveIco.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_SaveIco.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_SaveIco.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_SaveIco.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_SaveIco.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SaveIco_Handler(evt);
            }
        });

        bt_HideWnd.setText("X");
        bt_HideWnd.setToolTipText("\u5173\u95ed\u7a97\u53e3");
        bt_HideWnd.setFocusPainted(false);
        bt_HideWnd.setFocusable(false);
        bt_HideWnd.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_HideWnd.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_HideWnd.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_HideWnd.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_HideWnd.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_HideWnd_Handler(evt);
            }
        });

        bt_LockPnt.setText("L");
        bt_LockPnt.setToolTipText("\u9501\u5b9a\u4f4d\u7f6e");
        bt_LockPnt.setFocusPainted(false);
        bt_LockPnt.setFocusable(false);
        bt_LockPnt.setMargin(new java.awt.Insets(0, 0, 0, 0));
        bt_LockPnt.setMaximumSize(new java.awt.Dimension(20, 20));
        bt_LockPnt.setMinimumSize(new java.awt.Dimension(16, 16));
        bt_LockPnt.setPreferredSize(new java.awt.Dimension(18, 18));
        bt_LockPnt.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_LockPnt_Handler(evt);
            }
        });

        javax.swing.GroupLayout pcLayout = new javax.swing.GroupLayout(pc);
        pc.setLayout(pcLayout);
        pcLayout.setHorizontalGroup(pcLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            pcLayout.createSequentialGroup().addContainerGap().addGroup(
                pcLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(il_IconLbl,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                    pcLayout.createSequentialGroup().addComponent(bt_SavePng, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_SaveIco,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                        Short.MAX_VALUE).addComponent(bt_LockPnt, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_HideWnd,
                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap(12, Short.MAX_VALUE)));
        pcLayout.setVerticalGroup(pcLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            pcLayout.createSequentialGroup().addContainerGap().addComponent(il_IconLbl,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                pcLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_SavePng,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_SaveIco,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_HideWnd,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(bt_LockPnt,
                    javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE)));

        getContentPane().add(pc, java.awt.BorderLayout.CENTER);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_HideWnd_Handler(java.awt.event.ActionEvent evt)
    {
        this.setVisible(false);
    }

    /**
     * 窗口位置锁定事件处理
     * 
     * @param evt
     */
    private void bt_LockPnt_Handler(java.awt.event.ActionEvent evt)
    {
        pntLocked = !pntLocked;
    }

    /**
     * @param evt
     */
    private void bt_SaveIco_Handler(java.awt.event.ActionEvent evt)
    {
        // ICO文件过滤器
        FilesFilter filter = new FilesFilter();
        filter.setTextInclude(new String[]{".ico"});
        filter.setDescription(new String[]{"ICO图像"});

        File dstFile = FileUtil.showSingleFileSave(this, false, filter);
        if (dstFile == null)
        {
            return;
        }

        if (!dstFile.getPath().endsWith(".ico"))
        {
            dstFile = new File(dstFile.getPath() + ".ico");
        }
        ImageUtil.exptIcoImage(pngFolder, pngName, dstFile);
    }

    /**
     * @param evt
     */
    private void bt_SavePng_Handler(java.awt.event.ActionEvent evt)
    {
        // PNG文件过滤器
        FilesFilter filter = new FilesFilter();
        filter.setTextInclude(new String[]{".png"});
        filter.setDescription(new String[]{"PNG图像"});

        File dstFile = FileUtil.showSingleFileSave(this, false, filter);
        if (dstFile == null)
        {
            return;
        }

        if (!dstFile.getPath().endsWith(".png"))
        {
            dstFile = new File(dstFile.getPath() + ".png");
        }

        File srcFile = new File(pngFolder + EnvCons.COMN_SP_FILE + pngName + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON);
        try
        {
            FileUtil.copyFile(srcFile, dstFile, true);
        }
        catch(IOException exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * @param evt
     */
    private void pc_MouseDragged(java.awt.event.MouseEvent evt)
    {
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
        p = this.getLocation();
        m = evt.getPoint();
    }

    /**
     * @param evt
     */
    private void pc_MouseReleased(java.awt.event.MouseEvent evt)
    {
        Point c = evt.getPoint();
        c.x -= m.x;
        c.y -= m.y;
        p.x += c.x;
        p.y += c.y;
        this.setLocation(p);
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 窗口初始位置 */
    private Point      p;
    /** 鼠标点击位置 */
    private Point      m;

    /** 预览窗口隐藏 */
    private JButton    bt_HideWnd;
    /** 锁定窗口按钮 */
    private JButton    bt_LockPnt;
    /** 保存为ICO文件按钮 */
    private JButton    bt_SaveIco;
    /** 保存为Png文件按钮 */
    private JButton    bt_SavePng;
    /** 文件图标 */
    private WIconLabel il_IconLbl;
}
