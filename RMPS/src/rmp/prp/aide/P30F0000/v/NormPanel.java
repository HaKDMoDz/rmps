/*
 * FileName:       NormPanel.java
 * CreateDate:     2008-2-28 下午08:11:51
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.v;

import java.awt.CardLayout;
import java.awt.Cursor;
import java.awt.Dimension;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;
import java.awt.event.MouseEvent;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.EventObject;

import javax.swing.ImageIcon;
import javax.swing.JComponent;
import javax.swing.JOptionPane;
import javax.swing.KeyStroke;
import javax.swing.ToolTipManager;
import javax.swing.tree.TreePath;
import javax.swing.tree.TreeSelectionModel;

import rmp.Rmps;
import rmp.bean.K1SV1S;
import rmp.bean.K1SV2S;
import rmp.bean.WTreeCellRenderer;
import rmp.face.WBackCall;
import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.b.AreaBean;
import rmp.prp.aide.P30F0000.b.DateBean;
import rmp.prp.aide.P30F0000.b.InfoBean;
import rmp.prp.aide.P30F0000.b.LinkBean;
import rmp.prp.aide.P30F0000.b.MailBean;
import rmp.prp.aide.P30F0000.b.MetaBean;
import rmp.prp.aide.P30F0000.b.PropItem;
import rmp.prp.aide.P30F0000.b.PwdsBean;
import rmp.prp.aide.P30F0000.b.TextBean;
import rmp.prp.aide.P30F0000.b.TypeItem;
import rmp.prp.aide.P30F0000.i.WProp;
import rmp.prp.aide.P30F0000.m.NameData;
import rmp.prp.aide.P30F0000.m.UserData;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.user.U0020000.U0020000;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.DateUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-2-28 下午08:11:51
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class NormPanel extends javax.swing.JPanel implements WBackCall
{
    /**  */
    private int        row;
    /**  */
    private K1SV2S     kv_LastItem;
    /** 名称列表 */
    private NameData   nd_NameList;
    /** 列表模型 */
    private UserData   ud_DataList;
    /** 用户交互区域布局管理器 */
    private CardLayout cl_CardLayout;
    /**  */
    private WProp[]    wp_PropBean = new WProp[ConstUI.RECORD_PROP_NAME.length];
    /**  */
    private P30F0000   ms_MainSoft;
    private HistPanel  hp_HistForm;

    /**
     * @param soft
     */
    public NormPanel(P30F0000 soft)
    {
        this.ms_MainSoft = soft;
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
        icc();
        icd();
        ita();
        itb();
        itc();
        itd();

        tr_TypeList.setModel(Util.getTypeList());

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WBackCall#wAction(java.util.EventObject, java.lang.Object)
     */
    @ Override
    public void wAction(EventObject event, Object object, String property)
    {
        if (object == null)
        {
            return;
        }
        try
        {
            K1SV1S kv = (K1SV1S)object;
            boolean b = Util.getUserData().signPwd(kv.getK(), kv.getV());
            if (b)
            {
                MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A0E));
            }
            else
            {
                MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A0F));
            }
        }
        catch(Exception exp)
        {
            MesgUtil.showMessageDialog(this, exp.getMessage());
        }
    }

    /**
     * 列表组件初始化
     */
    private void ica()
    {
        sp_UserList = new javax.swing.JSplitPane();
        sp_UserList.setDividerLocation(180);
        sp_UserList.setDividerSize(8);
        sp_UserList.setOrientation(javax.swing.JSplitPane.VERTICAL_SPLIT);
        sp_UserList.setOneTouchExpandable(true);
        // sp_UserList.setPreferredSize(new java.awt.Dimension(150, 364));

        javax.swing.JScrollPane sp1 = new javax.swing.JScrollPane();
        tr_TypeList = new javax.swing.JTree();
        javax.swing.JScrollPane sp2 = new javax.swing.JScrollPane();
        ls_DataList = new javax.swing.JList();

        tr_TypeList.setModel(null);
        tr_TypeList.setCellRenderer(new WTreeCellRenderer());
        tr_TypeList.getSelectionModel().setSelectionMode(TreeSelectionModel.SINGLE_TREE_SELECTION);
        ToolTipManager.sharedInstance().registerComponent(tr_TypeList);
        tr_TypeList.addTreeSelectionListener(new javax.swing.event.TreeSelectionListener()
        {
            @ Override
            public void valueChanged(javax.swing.event.TreeSelectionEvent evt)
            {
                tr_TypeListValueChanged(evt);
            }
        });
        sp1.setViewportView(tr_TypeList);
        sp_UserList.setTopComponent(sp1);

        nd_NameList = new NameData();
        nd_NameList.wInit();
        ls_DataList.setModel(nd_NameList);
        ls_DataList.addListSelectionListener(new javax.swing.event.ListSelectionListener()
        {
            public void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                ls_DataListValueChanged(evt);
            }
        });
        ls_DataList.addMouseListener(new java.awt.event.MouseListener()
        {
            @ Override
            public void mouseClicked(MouseEvent e)
            {
                if (e.getClickCount() < 2)
                {
                    return;
                }
                K1SV2S item = (K1SV2S)ls_DataList.getSelectedValue();
                if (!(item instanceof K1SV2S))
                {
                    return;
                }

                K1SV2S kv = (K1SV2S)item;
                hp_HistForm = HistPanel.getInstance(ud_DataList);
                hp_HistForm.setVisible(true);
                hp_HistForm.setUserKeys(kv.getK());
            }

            @ Override
            public void mouseEntered(MouseEvent e)
            {
            }

            @ Override
            public void mouseExited(MouseEvent e)
            {
            }

            @ Override
            public void mousePressed(MouseEvent e)
            {
            }

            @ Override
            public void mouseReleased(MouseEvent e)
            {
            }
        });
        sp2.setViewportView(ls_DataList);
        sp_UserList.setBottomComponent(sp2);
    }

    /**
     * 用户交互主界面初始化
     */
    private void icb()
    {
        lb_KeysName = new javax.swing.JLabel();
        tf_KeysName = new javax.swing.JTextField();
        bt_KeysName = new javax.swing.JButton();
        sp_PropList = new javax.swing.JScrollPane();
        tb_PropList = new javax.swing.JTable();
        bt_MoveUp = new javax.swing.JButton();
        bt_MoveDn = new javax.swing.JButton();
        bt_Other = new javax.swing.JButton();
        bt_UserMenu = new javax.swing.JButton();
        ck_DbBackUp = new javax.swing.JCheckBox();
        pl_PropEdit = new javax.swing.JPanel();

        lb_KeysName.setLabelFor(tf_KeysName);

        tf_KeysName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_KeysNameActionPerformed(evt);
            }
        });

        bt_KeysName.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_KeysNameActionPerformed(evt);
            }
        });

        sp_PropList.setPreferredSize(new java.awt.Dimension(347, 147));

        ud_DataList = Util.getUserData();
        tb_PropList.setModel(ud_DataList);
        tb_PropList.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        // 属性数据上移排序事件
        tb_PropList.getActionMap().put("MoveUp", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 3762318450026326385L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                moveUp();
            }
        });
        tb_PropList.getInputMap().put(KeyStroke.getKeyStroke(KeyEvent.VK_UP, InputEvent.CTRL_MASK), "MoveUp");
        // 属性数据下移排序事件
        tb_PropList.getActionMap().put("MoveDn", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                moveDown();
            }
        });
        tb_PropList.getInputMap().put(KeyStroke.getKeyStroke(KeyEvent.VK_DOWN, InputEvent.CTRL_MASK), "MoveDn");
        // 添加口令记录事件
        tb_PropList.getActionMap().put("CrtData", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                createData();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_N, InputEvent.CTRL_MASK), "CrtData");
        // 删除口令记录事件
        tb_PropList.getActionMap().put("DelData", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                deleteData();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_D, InputEvent.CTRL_MASK), "DelData");
        // 保存口令记录事件
        tb_PropList.getActionMap().put("UpdData", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                updateData();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_S, InputEvent.CTRL_MASK), "UpdData");
        // 添加文本属性事件
        tb_PropList.getActionMap().put("NewText", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                appendTextBean();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_1, InputEvent.CTRL_MASK), "NewText");
        // 添加口令属性事件
        tb_PropList.getActionMap().put("NewPwds", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                appendPwdsBean();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_2, InputEvent.CTRL_MASK), "NewPwds");
        // 添加链接属性事件
        tb_PropList.getActionMap().put("NewLink", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                appendLinkBean();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_3, InputEvent.CTRL_MASK), "NewLink");
        // 添加邮件属性事件
        tb_PropList.getActionMap().put("NewMail", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                appendMailBean();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_4, InputEvent.CTRL_MASK), "NewMail");
        // 添加说明属性事件
        tb_PropList.getActionMap().put("NewArea", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 88427311386097933L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                appendAreaBean();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_5, InputEvent.CTRL_MASK), "NewArea");
        // 向上选择属性事件
        tb_PropList.getActionMap().put("SelectUp", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = 1198388119671947614L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                selectUp();
            }
        });
        tb_PropList.getInputMap().put(KeyStroke.getKeyStroke(KeyEvent.VK_UP, 0), "SelectUp");
        // 向下选择属性事件
        tb_PropList.getActionMap().put("SelectDn", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = -969654585699157745L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                selectDown();
            }
        });
        tb_PropList.getInputMap().put(KeyStroke.getKeyStroke(KeyEvent.VK_DOWN, 0), "SelectDn");

        // 窗口隐藏事件
        tb_PropList.getActionMap().put("hideData", new javax.swing.AbstractAction()
        {
            private static final long serialVersionUID = -969654585699157745L;

            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                hideData();
            }
        });
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_ENTER, InputEvent.CTRL_MASK), "hideData");
        tb_PropList.getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(
            KeyStroke.getKeyStroke(KeyEvent.VK_H, InputEvent.CTRL_MASK), "hideData");

        // 用户选择事件
        tb_PropList.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseReleased(java.awt.event.MouseEvent evt)
            {
                tb_PropListMouseReleased(evt);
            }
        });
        sp_PropList.setViewportView(tb_PropList);

        javax.swing.table.TableColumn tc = tb_PropList.getColumnModel().getColumn(0);
        tc.setPreferredWidth(tb_PropList.getFontMetrics(tb_PropList.getFont()).stringWidth("99999"));
        tc = tb_PropList.getColumnModel().getColumn(1);
        tc.setPreferredWidth(500);

        java.awt.Insets ins = new java.awt.Insets(0, 0, 0, 0);
        bt_MoveUp.setMargin(ins);
        bt_MoveUp.setBorderPainted(false);
        bt_MoveUp.setContentAreaFilled(false);
        bt_MoveUp.setFocusable(false);
        bt_MoveUp.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_MoveUp.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_MoveUpActionPerformed(evt);
            }
        });

        bt_MoveDn.setMargin(ins);
        bt_MoveDn.setBorderPainted(false);
        bt_MoveDn.setContentAreaFilled(false);
        bt_MoveDn.setFocusable(false);
        bt_MoveDn.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        bt_MoveDn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_MoveDnActionPerformed(evt);
            }
        });

        bt_Other.setMargin(ins);
        bt_Other.setBorderPainted(false);
        bt_Other.setContentAreaFilled(false);
        bt_Other.setFocusable(false);
        bt_Other.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_OtherActionPerformed(evt);
            }
        });

        bt_UserMenu.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_UserMenuActionPerformed(evt);
            }
        });

        ck_DbBackUp.setSelected(true);

        tb_Border = new javax.swing.border.TitledBorder("");
        pl_PropEdit.setBorder(tb_Border);

        cl_CardLayout = new java.awt.CardLayout();
        pl_PropEdit.setLayout(cl_CardLayout);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(sp_UserList,
                javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                    layout.createSequentialGroup().addComponent(lb_KeysName).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tf_KeysName,
                        javax.swing.GroupLayout.DEFAULT_SIZE, 223, Short.MAX_VALUE).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_KeysName)).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(sp_PropList, javax.swing.GroupLayout.DEFAULT_SIZE, 329,
                        Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(bt_MoveUp)
                            .addComponent(bt_MoveDn).addComponent(bt_Other))).addGroup(
                    javax.swing.GroupLayout.Alignment.TRAILING,
                    layout.createSequentialGroup().addComponent(ck_DbBackUp).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED, 184, Short.MAX_VALUE).addComponent(
                        bt_UserMenu)).addComponent(pl_PropEdit, javax.swing.GroupLayout.DEFAULT_SIZE,
                    javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                    layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(lb_KeysName).addComponent(bt_KeysName).addComponent(tf_KeysName,
                                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                            layout.createSequentialGroup().addComponent(bt_MoveUp).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_MoveDn)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                    bt_Other)).addComponent(sp_PropList, javax.swing.GroupLayout.DEFAULT_SIZE, 147,
                            Short.MAX_VALUE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(pl_PropEdit, javax.swing.GroupLayout.PREFERRED_SIZE,
                            javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                                bt_UserMenu).addComponent(ck_DbBackUp))).addComponent(sp_UserList,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 320, Short.MAX_VALUE)).addContainerGap()));
    }

    /**
     * 
     */
    private void icc()
    {
        pm_UserMenu = new javax.swing.JPopupMenu();

        // 新增数据
        mi_CreateData = new javax.swing.JMenuItem();
        mi_CreateData.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_CreateDataActionPerformed(evt);
            }
        });
        mi_CreateData.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_N,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_CreateData);

        // 保存数据
        mi_UpdateData = new javax.swing.JMenuItem();
        mi_UpdateData.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_UpdateDataActionPerformed(evt);
            }
        });
        mi_UpdateData.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_S,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_UpdateData);

        // 删除数据
        mi_DeleteData = new javax.swing.JMenuItem();
        mi_DeleteData.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DeleteDataActionPerformed(evt);
            }
        });
        mi_DeleteData.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_D,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_DeleteData);

        pm_UserMenu.addSeparator();

        // 单行文本
        mi_TextItem = new javax.swing.JMenuItem();
        mi_TextItem.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_TextItemActionPerformed(evt);
            }
        });
        mi_TextItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_1,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_TextItem);

        // 用户口令
        mi_PwdsItem = new javax.swing.JMenuItem();
        mi_PwdsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_PwdsItemActionPerformed(evt);
            }
        });
        mi_PwdsItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_2,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_PwdsItem);

        // 链接地址
        mi_LinkItem = new javax.swing.JMenuItem();
        mi_LinkItem.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_LinkItemActionPerformed(evt);
            }
        });
        mi_LinkItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_3,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_LinkItem);

        // 电子邮件
        mi_MailItem = new javax.swing.JMenuItem();
        mi_MailItem.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_MailItemActionPerformed(evt);
            }
        });
        mi_MailItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_4,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_MailItem);

        // 多行文本
        mi_AreaItem = new javax.swing.JMenuItem();
        mi_AreaItem.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_AreaItemActionPerformed(evt);
            }
        });
        mi_AreaItem.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_5,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_AreaItem);

        pm_UserMenu.addSeparator();

        // 创建类别
        mi_CreateType = new javax.swing.JMenuItem();
        mi_CreateType.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_CreateTypeActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_CreateType);

        // 更新类别
        mi_UpdateType = new javax.swing.JMenuItem();
        mi_UpdateType.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_UpdateTypeActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_UpdateType);

        // 删除类别
        mi_DeleteType = new javax.swing.JMenuItem();
        mi_DeleteType.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_DeleteTypeActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_DeleteType);

        pm_UserMenu.addSeparator();

        // 隐藏窗口
        mi_HideWindow = new javax.swing.JMenuItem();
        mi_HideWindow.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_HideWindowActionPerformed(evt);
            }
        });
        mi_HideWindow.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_ENTER,
            java.awt.event.InputEvent.CTRL_MASK));
        pm_UserMenu.add(mi_HideWindow);

        // 修改口令
        mi_ChangePwds = new javax.swing.JMenuItem();
        mi_ChangePwds.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_ChangePwdsActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_ChangePwds);

        // 清除历史记录
        mi_RemoveBack = new javax.swing.JMenuItem();
        mi_RemoveBack.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_RemoveBackActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_RemoveBack);

        // 查看历史记录
        mi_PickupBack = new javax.swing.JMenuItem();
        mi_PickupBack.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_PickupBackActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_PickupBack);

        pm_UserMenu.addSeparator();

        // 退出系统
        mi_SystemExit = new javax.swing.JMenuItem();
        mi_SystemExit.addActionListener(new java.awt.event.ActionListener()
        {
            @ Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mi_SystemExitActionPerformed(evt);
            }
        });
        pm_UserMenu.add(mi_SystemExit);
    }

    /**
     * 密码数据编辑组件初始化
     */
    private void icd()
    {
        int i = 0;

        // 信息对象
        InfoBean bi_InfoBean = new InfoBean();
        wp_PropBean[i++] = bi_InfoBean;
        bi_InfoBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_INFO], bi_InfoBean);

        // 文本对象
        TextBean bt_TextBean = new TextBean(this, ud_DataList);
        wp_PropBean[i++] = bt_TextBean;
        bt_TextBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_TEXT], bt_TextBean);

        // 口令对象
        PwdsBean bp_PwdsBean = new PwdsBean(this, ud_DataList);
        wp_PropBean[i++] = bp_PwdsBean;
        bp_PwdsBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_PWDS], bp_PwdsBean);

        // 链接对象
        LinkBean bl_LinkBean = new LinkBean(this, ud_DataList);
        wp_PropBean[i++] = bl_LinkBean;
        bl_LinkBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_LINK], bl_LinkBean);

        // 邮件对象
        MailBean bm_MailBean = new MailBean(this, ud_DataList);
        wp_PropBean[i++] = bm_MailBean;
        bm_MailBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_MAIL], bm_MailBean);

        // 描述对象
        AreaBean ba_AreaBean = new AreaBean(this, ud_DataList);
        wp_PropBean[i++] = ba_AreaBean;
        ba_AreaBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_AREA], ba_AreaBean);

        // 日期对象
        DateBean bt_TimeBean = new DateBean(this, ud_DataList);
        wp_PropBean[i++] = bt_TimeBean;
        bt_TimeBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_DATE], bt_TimeBean);

        // 名称对象
        MetaBean bm_MetaBean = new MetaBean(this, ud_DataList);
        wp_PropBean[i++] = bm_MetaBean;
        bm_MetaBean.wInit();
        pl_PropEdit.add(ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_META], bm_MetaBean);
    }

    /**
     * 列表组件语言初始化
     */
    private void ita()
    {
    }

    /**
     * 用户交互界面语言初始化
     */
    private void itb()
    {
        // 数据查询
        BeanUtil.setWText(lb_KeysName, P30F0000.getMesg(LangRes.P30F6301));
        BeanUtil.setWTips(lb_KeysName, P30F0000.getMesg(LangRes.P30F6302));

        BeanUtil.setWText(tf_KeysName, P30F0000.getMesg(LangRes.P30F6401));
        BeanUtil.setWTips(tf_KeysName, P30F0000.getMesg(LangRes.P30F6402));

        BeanUtil.setWText(bt_KeysName, P30F0000.getMesg(LangRes.P30F6501));
        BeanUtil.setWTips(bt_KeysName, P30F0000.getMesg(LangRes.P30F6502));

        // 向上移动
        ImageIcon ii = Util.getIcon(ConstUI.ICON_P30F0002);
        if (ii != null)
        {
            bt_MoveUp.setIcon(ii);
        }
        else
        {
            BeanUtil.setWTips(bt_MoveUp, P30F0000.getMesg(LangRes.P30F6505));
        }
        BeanUtil.setWTips(bt_MoveUp, P30F0000.getMesg(LangRes.P30F6506));

        // 向下移动
        ii = Util.getIcon(ConstUI.ICON_P30F0003);
        if (ii != null)
        {
            bt_MoveDn.setIcon(ii);
        }
        else
        {
            BeanUtil.setWTips(bt_MoveDn, P30F0000.getMesg(LangRes.P30F6507));
        }
        BeanUtil.setWTips(bt_MoveDn, P30F0000.getMesg(LangRes.P30F6508));

        // 标题边框
        tb_Border.setTitle(P30F0000.getMesg(LangRes.P30F6901));

        // 多选框
        BeanUtil.setWText(ck_DbBackUp, P30F0000.getMesg(LangRes.P30F6801));
        BeanUtil.setWTips(ck_DbBackUp, P30F0000.getMesg(LangRes.P30F6802));

        // 菜单
        BeanUtil.setWText(bt_UserMenu, P30F0000.getMesg(LangRes.P30F6503));
        BeanUtil.setWTips(bt_UserMenu, P30F0000.getMesg(LangRes.P30F6504));

        bt_Other.setVisible(false);
    }

    /**
     * 
     */
    private void itc()
    {
        // 新增数据
        BeanUtil.setWText(mi_CreateData, P30F0000.getMesg(LangRes.P30F6601));
        BeanUtil.setWTips(mi_CreateData, P30F0000.getMesg(LangRes.P30F6602));

        // 保存数据
        BeanUtil.setWText(mi_UpdateData, P30F0000.getMesg(LangRes.P30F6603));
        BeanUtil.setWTips(mi_UpdateData, P30F0000.getMesg(LangRes.P30F6604));

        // 删除数据
        BeanUtil.setWText(mi_DeleteData, P30F0000.getMesg(LangRes.P30F6605));
        BeanUtil.setWTips(mi_DeleteData, P30F0000.getMesg(LangRes.P30F6606));

        // 添加单行文本
        BeanUtil.setWText(mi_TextItem, P30F0000.getMesg(LangRes.P30F6607));
        // 添加用户口令
        BeanUtil.setWText(mi_PwdsItem, P30F0000.getMesg(LangRes.P30F6608));
        // 添加链接地址
        BeanUtil.setWText(mi_LinkItem, P30F0000.getMesg(LangRes.P30F6609));
        // 添加链接地址
        BeanUtil.setWText(mi_MailItem, P30F0000.getMesg(LangRes.P30F6619));
        // 添加多行文本
        BeanUtil.setWText(mi_AreaItem, P30F0000.getMesg(LangRes.P30F660A));

        // 创建类别
        BeanUtil.setWText(mi_CreateType, P30F0000.getMesg(LangRes.P30F660F));
        BeanUtil.setWTips(mi_CreateType, P30F0000.getMesg(LangRes.P30F6610));

        // 更新类别
        BeanUtil.setWText(mi_UpdateType, P30F0000.getMesg(LangRes.P30F6611));
        BeanUtil.setWText(mi_UpdateType, P30F0000.getMesg(LangRes.P30F6612));

        // 删除类别
        BeanUtil.setWText(mi_DeleteType, P30F0000.getMesg(LangRes.P30F6613));
        BeanUtil.setWText(mi_DeleteType, P30F0000.getMesg(LangRes.P30F6614));

        // 隐藏窗口
        BeanUtil.setWText(mi_HideWindow, P30F0000.getMesg(LangRes.P30F6615));
        BeanUtil.setWTips(mi_HideWindow, P30F0000.getMesg(LangRes.P30F6616));

        // 更改用户口令
        BeanUtil.setWText(mi_ChangePwds, P30F0000.getMesg(LangRes.P30F660B));
        BeanUtil.setWTips(mi_ChangePwds, P30F0000.getMesg(LangRes.P30F660C));

        // 清除历史
        BeanUtil.setWText(mi_RemoveBack, P30F0000.getMesg(LangRes.P30F6617));
        BeanUtil.setWTips(mi_RemoveBack, P30F0000.getMesg(LangRes.P30F6618));

        // 查看历史
        BeanUtil.setWText(mi_PickupBack, P30F0000.getMesg(LangRes.P30F662D));
        BeanUtil.setWTips(mi_PickupBack, P30F0000.getMesg(LangRes.P30F662E));

        // 系统退出
        BeanUtil.setWText(mi_SystemExit, P30F0000.getMesg(LangRes.P30F660D));
        BeanUtil.setWTips(mi_SystemExit, P30F0000.getMesg(LangRes.P30F660E));
    }

    /**
     * 
     */
    private void itd()
    {
    }

    /**
     * 用户选择其它密码数据
     * 
     * @param evt
     */
    private void ls_DataListValueChanged(javax.swing.event.ListSelectionEvent evt)
    {
        // 保存已有数据
        if (ud_DataList.isModified())
        {
            askForSave();
        }

        // 重复事件处理
        K1SV2S kv = (K1SV2S)ls_DataList.getSelectedValue();
        if (kv == null || kv == kv_LastItem)
        {
            return;
        }
        kv_LastItem = kv;

        // 读取口令数据
        try
        {
            ud_DataList.readData(kv.getK());
            if (ud_DataList.getRowCount() > 1)
            {
                requestName();
                row = 1;
            }
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A10));
        }
    }

    /**
     * @param evt
     */
    private void tf_KeysNameActionPerformed(java.awt.event.ActionEvent evt)
    {
        String keysName = tf_KeysName.getText().trim();
        if (!CheckUtil.isValidate(keysName))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A02));
            tf_KeysName.requestFocus();
            return;
        }

        nd_NameList.readNameByName(keysName);
    }

    /**
     * @param evt
     */
    private void bt_KeysNameActionPerformed(java.awt.event.ActionEvent evt)
    {
        String keysName = tf_KeysName.getText().trim();
        if (!CheckUtil.isValidate(keysName))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A02));
            tf_KeysName.requestFocus();
            return;
        }

        nd_NameList.readNameByName(keysName);
    }

    /**
     * @param evt
     */
    private void bt_MoveUpActionPerformed(java.awt.event.ActionEvent evt)
    {
        moveUp();
    }

    /**
     * @param evt
     */
    private void bt_MoveDnActionPerformed(java.awt.event.ActionEvent evt)
    {
        moveDown();
    }

    /**
     * @param evt
     */
    private void bt_OtherActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void bt_UserMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
        System.out.print(sp_PropList.getSize());
        pm_UserMenu.show(bt_UserMenu, 0, 0);
        Dimension size = pm_UserMenu.getSize();
        pm_UserMenu.show(bt_UserMenu, 0, -size.height);
    }

    /**
     * 用户改变选择属性事件处理
     * 
     * @param evt
     */
    private void tb_PropListMouseReleased(java.awt.event.MouseEvent evt)
    {
        row = tb_PropList.getSelectedRow();
        PropItem item = (PropItem)ud_DataList.getValueAt(row, 1);
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[item.getType()]);
        wp_PropBean[item.getType()].setPropItem(item);

        wp_PropBean[item.getType()].requestFocus();
    }

    /**
     * @param evt
     */
    private void tr_TypeListValueChanged(javax.swing.event.TreeSelectionEvent evt)
    {
        readNameList();
    }

    /**
     * 读取指定类别下的数据列表
     */
    private void readNameList()
    {
        TreePath tp = tr_TypeList.getSelectionPath();
        if (tp == null)
        {
            return;
        }

        Object obj = tp.getLastPathComponent();
        if (obj instanceof TypeItem)
        {
            TypeItem item = (TypeItem)obj;
            K1SV2S kv = (K1SV2S)item.getUserObject();
            nd_NameList.readNameByHash(kv.getK());
        }
    }

    /**
     * @param evt
     */
    private void mi_ChangePwdsActionPerformed(java.awt.event.ActionEvent evt)
    {
        U0020000 u002 = new U0020000();
        u002.wInit();
        u002.register(CfgCons.SIGN_PWD, this);
        u002.wShowView(IPrpPlus.VIEW_MINI);
    }

    /**
     * @param evt
     */
    private void mi_CreateDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        createData();
    }

    /**
     * @param evt
     */
    private void mi_CreateTypeActionPerformed(java.awt.event.ActionEvent evt)
    {
        String typeName = JOptionPane.showInputDialog(this, P30F0000.getMesg(LangRes.P30F6A12));
        if (!CheckUtil.isValidate(typeName))
        {
            return;
        }

        TreePath tp = tr_TypeList.getSelectionPath();
        Object obj = null;
        if (tp != null)
        {
            obj = tp.getLastPathComponent();
        }
        if (obj == null)
        {
            obj = Util.getTypeRoot();
        }
        if (!(obj instanceof TypeItem))
        {
            return;
        }

        TypeItem item = (TypeItem)obj;
        K1SV2S kv = (K1SV2S)item.getUserObject();

        int size = item.getChildCount();
        String hash = Util.createType(kv.getK(), typeName);
        Util.getTypeList().insertNodeInto(new TypeItem(new K1SV2S(hash, typeName, typeName)), item, size);
    }

    /**
     * @param evt
     */
    private void mi_DeleteTypeActionPerformed(java.awt.event.ActionEvent evt)
    {
        TreePath tp = tr_TypeList.getSelectionPath();
        if (tp == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A14));
            tr_TypeList.requestFocus();
            return;
        }
        Object obj = tp.getLastPathComponent();
        if (tp == null || obj == Util.getTypeRoot())
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A14));
            tr_TypeList.requestFocus();
            return;
        }

        if (!(obj instanceof TypeItem))
        {
            return;
        }

        // 用户选择确认
        if (0 != MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30F6A15)))
        {
            return;
        }

        TypeItem item = (TypeItem)obj;
        K1SV2S kv = (K1SV2S)item.getUserObject();

        Util.deleteType(kv.getK());

        Util.getTypeList().removeNodeFromParent(item);
    }

    /**
     * @param evt
     */
    private void mi_HideWindowActionPerformed(java.awt.event.ActionEvent evt)
    {
        hideData();
    }

    /**
     * @param evt
     */
    private void mi_RemoveBackActionPerformed(java.awt.event.ActionEvent evt)
    {
        K1SV2S item = (K1SV2S)ls_DataList.getSelectedValue();
        if (item == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A17));
            ls_DataList.requestFocus();
            return;
        }

        if (0 != MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30F6A18)))
        {
            return;
        }

        if (1 != MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30F6A19)))
        {
            return;
        }

        String date = new SimpleDateFormat("yyyy-MM-dd").format(new Date());
        String text = MesgUtil.showInputDialog(this, P30F0000.getMesg(LangRes.P30F6A1A), date);
        // 用户取消
        if (text == null)
        {
            return;
        }
        if (!CheckUtil.isValidate(text))
        {
            text = date;
        }
        Calendar cal = null;
        try
        {
            cal = DateUtil.stringToDate(text + " 00:00:00", '-', ':', ' ');
        }
        catch(Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(this, exp.getMessage());
            return;
        }

        date = StringUtil.lPad(Long.toHexString(cal.getTimeInMillis()), 16, '0');
        date = "" + Util.deleteBack(item.getK(), date);
        MesgUtil.showMessageDialog(this, StringUtil.format(P30F0000.getMesg(LangRes.P30F6A1B), date));
    }

    private void mi_PickupBackActionPerformed(java.awt.event.ActionEvent evt)
    {
        K1SV2S item = (K1SV2S)ls_DataList.getSelectedValue();
        if (item == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A21));
            ls_DataList.requestFocus();
            return;
        }

        if (!(item instanceof K1SV2S))
        {
            return;
        }

        K1SV2S kv = (K1SV2S)item;
        hp_HistForm = HistPanel.getInstance(ud_DataList);
        hp_HistForm.setVisible(true);
        hp_HistForm.setUserKeys(kv.getK());
    }

    /**
     * @param evt
     */
    private void mi_UpdateTypeActionPerformed(java.awt.event.ActionEvent evt)
    {
        TreePath tp = tr_TypeList.getSelectionPath();
        if (tp == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A13));
            tr_TypeList.requestFocus();
            return;
        }
        Object obj = tp.getLastPathComponent();
        if (tp == null || obj == Util.getTypeRoot())
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A13));
            tr_TypeList.requestFocus();
            return;
        }

        String typeName = JOptionPane.showInputDialog(this, P30F0000.getMesg(LangRes.P30F6A12));
        if (!CheckUtil.isValidate(typeName))
        {
            return;
        }

        if (!(obj instanceof TypeItem))
        {
            return;
        }

        TypeItem item = (TypeItem)obj;
        K1SV2S kv = (K1SV2S)item.getUserObject();

        Util.updateType(kv.getK(), typeName);
        kv.setV1(typeName);
        kv.setV2(typeName);
        Util.getTypeList().nodeChanged(item);
    }

    /**
     * @param evt
     */
    private void mi_DeleteDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        deleteData();
    }

    /**
     * @param evt
     */
    private void mi_UpdateDataActionPerformed(java.awt.event.ActionEvent evt)
    {
        updateData();
    }

    /**
     * @param evt
     */
    private void mi_SystemExitActionPerformed(java.awt.event.ActionEvent evt)
    {
        P30F0000.getForm().setVisible(false);
        Rmps.exit(0, true, true);
    }

    /**
     * @param evt
     */
    private void mi_AreaItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        appendAreaBean();
    }

    /**
     * @param evt
     */
    private void mi_LinkItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        appendLinkBean();
    }

    /**
     * @param evt
     */
    private void mi_MailItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        appendMailBean();
    }

    /**
     * @param evt
     */
    private void mi_PwdsItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        appendPwdsBean();
    }

    /**
     * @param evt
     */
    private void mi_TextItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        appendTextBean();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 共用方法区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 询问用户保存数据
     */
    private void askForSave()
    {
        if (0 == MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30F6A01)))
        {
            if (ud_DataList.getTypeHash() == null)
            {
                ud_DataList.setTypeHash("0");
            }
            if (ud_DataList.getKeysName() == null)
            {
                ud_DataList.setKeysName("<未命名>");
            }
            ud_DataList.saveData(!ck_DbBackUp.isSelected());
        }
        else
        {
            ud_DataList.clear();
            ud_DataList.setModified(false);
            ud_DataList.fireTableDataChanged();
        }
    }

    /**
     * 
     */
    private void hideData()
    {
        if (hp_HistForm != null)
        {
            hp_HistForm.setVisible(false);
        }
        ms_MainSoft.wShowView(IPrpPlus.VIEW_STEP);
    }

    /**
     * 将选中数据行向上移动一行
     */
    private void moveUp()
    {
        // 选择区域判断
        int s = tb_PropList.getSelectedRow();
        if (s < ConstUI.FIXED_ROW_NUM)
        {
            return;
        }

        int t = ConstUI.FIXED_ROW_NUM;
        row = s - 1;
        if (row < t)
        {
            row = t;
        }
        ud_DataList.moveRow(s, row);
        ud_DataList.fireTableDataChanged();

        // 表格显示
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);
    }

    /**
     * 将选中数据行向下移动一行
     */
    private void moveDown()
    {
        // 选择区域判断
        int s = tb_PropList.getSelectedRow();
        if (s < ConstUI.FIXED_ROW_NUM)
        {
            return;
        }

        int t = ud_DataList.getRowCount() - 1;
        row = s + 1;
        if (row > t)
        {
            row = t;
        }
        ud_DataList.moveRow(s, row);
        ud_DataList.fireTableDataChanged();

        // 表格显示
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);
    }

    /**
     * 选择上一行数据
     */
    private void selectUp()
    {
        row = tb_PropList.getSelectedRow() - 1;
        if (row < 0)
        {
            row = ud_DataList.getRowCount() - 1;
        }

        // 表格显示
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        PropItem item = (PropItem)ud_DataList.getValueAt(row, 1);
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[item.getType()]);
        wp_PropBean[item.getType()].setPropItem(item);
    }

    /**
     * 选择下一行数据
     */
    private void selectDown()
    {
        row = tb_PropList.getSelectedRow() + 1;
        if (row >= ud_DataList.getRowCount())
        {
            row = 0;
        }

        // 表格显示
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        PropItem item = (PropItem)ud_DataList.getValueAt(row, 1);
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[item.getType()]);
        wp_PropBean[item.getType()].setPropItem(item);
    }

    /**
     * 
     */
    public void selectNext()
    {
        int t = ud_DataList.getRowCount() - 1;
        if (row > t)
        {
            row = t;
        }
        tb_PropList.setRowSelectionInterval(row, row);
        tb_PropList.requestFocus();
    }

    /**
     * 
     */
    private void appendAreaBean()
    {
        if (ud_DataList.getKeysName() == null && ud_DataList.getRowCount() < 2)
        {
            requestType();
            return;
        }

        int t = ConstUI.RECORD_TYPE_AREA;
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
        wp_PropBean[t].setPropItem(ud_DataList.append(t));
        ud_DataList.fireTableDataChanged();

        row = ud_DataList.getRowCount() - 1;
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        wp_PropBean[t].requestFocus();
    }

    /**
     * 
     */
    private void appendLinkBean()
    {
        if (ud_DataList.getKeysName() == null && ud_DataList.getRowCount() < 2)
        {
            requestType();
            return;
        }

        int t = ConstUI.RECORD_TYPE_LINK;
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
        wp_PropBean[t].setPropItem(ud_DataList.append(t));
        ud_DataList.fireTableDataChanged();

        row = ud_DataList.getRowCount() - 1;
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        wp_PropBean[t].requestFocus();
    }

    /**
     * 
     */
    private void appendMailBean()
    {
        if (ud_DataList.getKeysName() == null && ud_DataList.getRowCount() < 2)
        {
            requestType();
            return;
        }

        int t = ConstUI.RECORD_TYPE_MAIL;
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
        wp_PropBean[t].setPropItem(ud_DataList.append(t));
        ud_DataList.fireTableDataChanged();

        row = ud_DataList.getRowCount() - 1;
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        wp_PropBean[t].requestFocus();
    }

    /**
     * 
     */
    private void appendPwdsBean()
    {
        if (ud_DataList.getKeysName() == null && ud_DataList.getRowCount() < 2)
        {
            requestType();
            return;
        }

        int t = ConstUI.RECORD_TYPE_PWDS;
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
        wp_PropBean[t].setPropItem(ud_DataList.append(t));
        ud_DataList.fireTableDataChanged();

        row = ud_DataList.getRowCount() - 1;
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        wp_PropBean[t].requestFocus();
    }

    /**
     * 
     */
    private void appendTextBean()
    {
        if (ud_DataList.getKeysName() == null && ud_DataList.getRowCount() < 2)
        {
            requestType();
            return;
        }

        int t = ConstUI.RECORD_TYPE_TEXT;
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
        wp_PropBean[t].setPropItem(ud_DataList.append(t));
        ud_DataList.fireTableDataChanged();

        row = ud_DataList.getRowCount() - 1;
        tb_PropList.setRowSelectionInterval(row, row);
        BeanUtil.scrollToVisible(tb_PropList, row, 0, false);

        wp_PropBean[t].requestFocus();
    }

    /**
     * 添加新的口令数据
     */
    private void createData()
    {
        if (ud_DataList.isModified())
        {
            askForSave();
        }
        requestType();
        row = 1;
    }

    /**
     * 要求用户选择数据类别
     */
    private void requestType()
    {
        int t = ConstUI.RECORD_TYPE_DATE;
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
        wp_PropBean[t].setPropItem(ud_DataList.reInit());
        ud_DataList.fireTableDataChanged();
    }

    /**
     * 要求用户输入数据名称
     * 
     * @param row
     */
    public void requestName()
    {
        if (ud_DataList.getRowCount() > 1)
        {
            tb_PropList.setRowSelectionInterval(1, 1);
            int t = ConstUI.RECORD_TYPE_META;
            cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[t]);
            wp_PropBean[t].setPropItem((PropItem)ud_DataList.getValueAt(1, 1));
        }
    }

    /**
     * 
     */
    private void deleteData()
    {
        String hash = ud_DataList.getKeysHash();
        if (hash == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A03));
            ls_DataList.requestFocus();
            return;
        }

        // 删除确认
        if (0 != MesgUtil.showConfirmDialog(this, P30F0000.getMesg(LangRes.P30F6A1C)))
        {
            return;
        }

        ud_DataList.deleteData();
        ud_DataList.clear();
        ud_DataList.fireTableDataChanged();
        cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_INFO]);
        wp_PropBean[ConstUI.RECORD_TYPE_INFO].setPropItem(null);

        nd_NameList.remove(hash);

        MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A1D));
    }

    /**
     * 保存现有数据
     */
    private void updateData()
    {
        if (ud_DataList.getRowCount() < 1)
        {
            return;
        }

        // 口令名称检测
        if (!CheckUtil.isValidate(ud_DataList.getKeysName()))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A11));
            requestName();
            return;
        }

        // 获取类别信息
        TreePath tp = tr_TypeList.getSelectionPath();
        if (tp == null)
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A04));
            tr_TypeList.requestFocus();
            return;
        }
        Object ob1 = tp.getLastPathComponent();
        if (ob1 == null || !(ob1 instanceof TypeItem))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A04));
            tr_TypeList.requestFocus();
            return;
        }
        TypeItem ti = (TypeItem)ob1;
        Object ob2 = ti.getUserObject();
        if (ob2 == null || !(ob2 instanceof K1SV2S))
        {
            MesgUtil.showMessageDialog(this, P30F0000.getMesg(LangRes.P30F6A04));
            tr_TypeList.requestFocus();
            return;
        }
        K1SV2S kv = (K1SV2S)ob2;
        ud_DataList.setTypeHash(kv.getK());

        if (ud_DataList.saveData(!ck_DbBackUp.isSelected()))
        {
            ud_DataList.clear();
            ud_DataList.fireTableDataChanged();
            cl_CardLayout.show(pl_PropEdit, ConstUI.RECORD_PROP_NAME[ConstUI.RECORD_TYPE_INFO]);
            wp_PropBean[ConstUI.RECORD_TYPE_INFO].setPropItem(null);

            readNameList();
        }
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private javax.swing.JSplitPane          sp_UserList;
    private javax.swing.JList               ls_DataList;
    private javax.swing.JTree               tr_TypeList;

    private javax.swing.JButton             bt_KeysName;
    private javax.swing.JButton             bt_MoveDn;
    private javax.swing.JButton             bt_MoveUp;
    private javax.swing.JButton             bt_Other;
    private javax.swing.JButton             bt_UserMenu;
    private javax.swing.JCheckBox           ck_DbBackUp;
    private javax.swing.JLabel              lb_KeysName;
    private javax.swing.JPanel              pl_PropEdit;
    private javax.swing.JScrollPane         sp_PropList;
    private javax.swing.JTable              tb_PropList;
    private javax.swing.JTextField          tf_KeysName;
    private javax.swing.border.TitledBorder tb_Border;

    private javax.swing.JMenuItem           mi_ChangePwds;
    private javax.swing.JMenuItem           mi_CreateData;
    private javax.swing.JMenuItem           mi_CreateType;
    private javax.swing.JMenuItem           mi_DeleteData;
    private javax.swing.JMenuItem           mi_DeleteType;
    private javax.swing.JMenuItem           mi_UpdateData;
    private javax.swing.JMenuItem           mi_UpdateType;
    private javax.swing.JMenuItem           mi_SystemExit;
    private javax.swing.JMenuItem           mi_HideWindow;
    private javax.swing.JMenuItem           mi_RemoveBack;
    private javax.swing.JMenuItem           mi_PickupBack;
    private javax.swing.JMenuItem           mi_AreaItem;
    private javax.swing.JMenuItem           mi_LinkItem;
    private javax.swing.JMenuItem           mi_MailItem;
    private javax.swing.JMenuItem           mi_PwdsItem;
    private javax.swing.JMenuItem           mi_TextItem;
    private javax.swing.JPopupMenu          pm_UserMenu;

    /** serialVersionUID */
    private static final long               serialVersionUID = -4212813403173269809L;
}
