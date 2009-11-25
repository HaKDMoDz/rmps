/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.b;

import java.awt.FlowLayout;

import com.amonsoft.rmps.prp.ISoft;
import rmp.prp.Prps;
import rmp.util.BeanUtil;
import rmp.util.ImageUtil;
import cons.prp.LangRes;
import com.amonsoft.skin.ISkin;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 标准插件对象
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class StdPlugin extends javax.swing.JPanel
{
    /** 快捷菜单按钮图标 */
    private static javax.swing.ImageIcon softm;
    /** 标准插件对象 */
    private ISoft soft;
    /** 标准插件快捷菜单 */
    private StdPopMenu menu;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    static
    {
        softm = new javax.swing.ImageIcon(ImageUtil.readImage("logo/softm.png"));
    }

    /**
     * 默认构造函数
     */
    public StdPlugin()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        ica();
        ita();

        // 快捷菜单
        menu = new StdPopMenu();
        menu.wInit();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        tl_TreeLabl = new TreeLabel();
        tl_TreeLabl.wInit();
        tl_TreeLabl.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lt_TreeLabl_Handler(evt);
            }
        });

        bt_SoftButn = new javax.swing.JButton();
        bt_SoftButn.setFocusable(false);
        bt_SoftButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_SoftButn.setHorizontalAlignment(javax.swing.JButton.LEFT);
        bt_SoftButn.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SoftButn_Handler(evt);
            }
        });

        bt_MenuButn = new javax.swing.JButton();
        bt_MenuButn.setIcon(softm);
        bt_MenuButn.setFocusable(false);
        bt_MenuButn.setMargin(new java.awt.Insets(1, 1, 1, 1));
        bt_MenuButn.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_MenuButn_Handler(evt);
            }
        });

        pl_SoftPanel = new javax.swing.JPanel();
        pl_SoftPanel.setName(ISkin.PANEL_TAIL);
        pl_SoftPanel.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        pl_SoftPanel.setVisible(false);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(tl_TreeLabl).addComponent(bt_SoftButn,
                javax.swing.GroupLayout.DEFAULT_SIZE, 110, Short.MAX_VALUE).addComponent(bt_MenuButn)).addGroup(
                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(pl_SoftPanel,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.CENTER).addComponent(tl_TreeLabl).addComponent(bt_MenuButn).addComponent(bt_SoftButn)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_SoftPanel,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap()));
    }

    /**
     * 界面语言初始化
     */
    private void ita()
    {
        // 扩展
        BeanUtil.setWText(tl_TreeLabl, Prps.getMesg(LangRes.BUTN_TEXT_PANEBUTN));
        BeanUtil.setWTips(tl_TreeLabl, Prps.getMesg(LangRes.BUTN_TIPS_PANEBUTN_C));

        // 菜单
        BeanUtil.setWText(bt_MenuButn, Prps.getMesg(LangRes.BUTN_TEXT_MENUBUTN));
        BeanUtil.setWTips(bt_MenuButn, Prps.getMesg(LangRes.BUTN_TIPS_MENUBUTN));
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 设置构件对应的软件对象
     * 
     * @return
     */
    public boolean setSoft(ISoft soft)
    {
        this.soft = soft;
        bt_SoftButn.setIcon(new javax.swing.ImageIcon(soft.wGetIconImage(ISoft.ICON_LOGO0016)));
        javax.swing.JMenu m = menu.getSoftMenu();
        menu.setSoftMenuVisible(soft.wInitMenu(m));
        BeanUtil.setWText(bt_SoftButn, soft.wGetTitle());
        BeanUtil.setWTips(bt_SoftButn, soft.wGetDescription());
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 级联按钮事件处理，用于打开或关闭内嵌面板
     * 
     * @param evt
     */
    private void lt_TreeLabl_Handler(java.awt.event.MouseEvent evt)
    {
        // 显示状态判断
        boolean b = !tl_TreeLabl.isSelected();
        tl_TreeLabl.setSelected(b);
        pl_SoftPanel.setVisible(b);
        tl_TreeLabl.setToolTipText(b ? Prps.getMesg(LangRes.BUTN_TIPS_PANEBUTN_X) : Prps.getMesg(LangRes.BUTN_TIPS_PANEBUTN_C));

        // 构件显示
        b = soft.wInitTail(pl_SoftPanel);
        if (!b)
        {
            if (lb_InfoLabl == null)
            {
                lb_InfoLabl = new javax.swing.JLabel(Prps.getMesg(LangRes.LABL_TEXT_INFOLABL));
                pl_SoftPanel.setLayout(new FlowLayout());
            }
            pl_SoftPanel.removeAll();
            pl_SoftPanel.add(lb_InfoLabl);
        }

        // 记录当前软件
        Prps.setCurrSoft(soft);
    }

    /**
     * 软件标签按钮事件处理，用于打开或关闭内嵌面板
     * 
     * @param evt
     */
    private void bt_SoftButn_Handler(java.awt.event.ActionEvent evt)
    {
        // 显示状态判断
        boolean b = !tl_TreeLabl.isSelected();
        tl_TreeLabl.setSelected(b);
        pl_SoftPanel.setVisible(b);
        tl_TreeLabl.setToolTipText(b ? Prps.getMesg(LangRes.BUTN_TIPS_PANEBUTN_X) : Prps.getMesg(LangRes.BUTN_TIPS_PANEBUTN_C));

        // 构件显示
        b = soft.wInitTail(pl_SoftPanel);
        if (!b)
        {
            if (lb_InfoLabl == null)
            {
                lb_InfoLabl = new javax.swing.JLabel(Prps.getMesg(LangRes.LABL_TEXT_INFOLABL));
                pl_SoftPanel.setLayout(new FlowLayout());
            }
            pl_SoftPanel.removeAll();
            pl_SoftPanel.add(lb_InfoLabl);
        }

        // 记录当前软件
        Prps.setCurrSoft(soft);
    }

    /**
     * @param evt
     */
    private void bt_MenuButn_Handler(java.awt.event.ActionEvent evt)
    {
        // 显示弹出式菜单
        menu.show(bt_MenuButn, 0, bt_MenuButn.getSize().height);

        // 记录当前软件
        Prps.setCurrSoft(soft);
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面变量区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JButton bt_MenuButn;
    private javax.swing.JButton bt_SoftButn;
    private javax.swing.JLabel lb_InfoLabl;
    private javax.swing.JPanel pl_SoftPanel;
    private TreeLabel tl_TreeLabl;
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;
}
