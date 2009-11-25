/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.v;

import javax.swing.BorderFactory;
import javax.swing.border.Border;

import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.P3010000.b.WIconBox;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀解析迷你模式面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel
{
    /** 界面布局管理器 */
    private java.awt.CardLayout cl_CardPanl;
    /** 上一次选择的标签 */
    private javax.swing.JLabel lb_LastLabl;
    /** 多个软件弹出式选择菜单 */
    private javax.swing.JPopupMenu pm_SoftMenu;
    /** 父应用引用 */
    // private P3010000 ms_MainSoft;
    /**  */
    private Border me_FlashBorder;

    /**
     * @param soft
     */
    public MiniPanel(P3010000 soft)
    {
        // ms_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.frm.FViewPanel#wInit()
     */
    public boolean wInit()
    {
        me_FlashBorder = BorderFactory.createLineBorder(new java.awt.Color(204, 204, 204));

        // 迷你模式面板初始化
        ica();

        // 描述信息面板初始化
        icb();

        // MIME类型面板初始化
        icc();

        // 公司信息面板初始化
        icd();

        // 软件信息面板初始化
        ice();

        // 文件信息面板初始化
        icf();

        // 备选软件面板初始化
        icg();

        // 特别致谢面板初始化
        ich();

        // 添加面板
        pl_CardPanl.add(ConstUI.PROP_ITEM_DESP, pl_DespInfo);
        pl_CardPanl.add(ConstUI.PROP_ITEM_MIME, pl_MimeInfo);
        pl_CardPanl.add(ConstUI.PROP_ITEM_CORP, pl_CorpInfo);
        pl_CardPanl.add(ConstUI.PROP_ITEM_SOFT, pl_SoftInfo);
        pl_CardPanl.add(ConstUI.PROP_ITEM_FILE, pl_FileInfo);
        pl_CardPanl.add(ConstUI.PROP_ITEM_ASOC, pl_AsocInfo);
        pl_CardPanl.add(ConstUI.PROP_ITEM_IDIO, pl_IdioInfo);

        ita();

        // 当前选择标签状态设置
        java.awt.Color lbc = new java.awt.Color(176, 216, 255);
        lb_DespInfo.setBackground(lbc);
        lb_MimeInfo.setBackground(lbc);
        lb_CorpInfo.setBackground(lbc);
        lb_SoftInfo.setBackground(lbc);
        lb_FileInfo.setBackground(lbc);
        lb_AsocInfo.setBackground(lbc);
        lb_IdioInfo.setBackground(lbc);

        lb_DespInfo.setOpaque(true);
        lb_LastLabl = lb_DespInfo;

        // 快捷菜单
        pm_SoftMenu = new javax.swing.JPopupMenu();
        ib_SoftIcon.setIconPath(EnvUtil.getIconSoftDir());

        return true;
    }

    // ========================================================================
    // 界面初始化区域
    // ========================================================================
    /**
     * 迷你模式面板初始化
     */
    private void ica()
    {
        ib_SoftIcon = new WIconBox(null);
        tf_ExtsName = new javax.swing.JTextField();
        lb_SoftList = new javax.swing.JLabel();
        bt_SoftList = new javax.swing.JButton();
        javax.swing.JSeparator sp1 = new javax.swing.JSeparator();
        pl_CardPanl = new javax.swing.JPanel();
        javax.swing.JSeparator sp2 = new javax.swing.JSeparator();
        lb_IdioInfo = new javax.swing.JLabel();
        lb_AsocInfo = new javax.swing.JLabel();
        lb_FileInfo = new javax.swing.JLabel();
        lb_SoftInfo = new javax.swing.JLabel();
        lb_CorpInfo = new javax.swing.JLabel();
        lb_MimeInfo = new javax.swing.JLabel();
        lb_DespInfo = new javax.swing.JLabel();
        jLabel10 = new javax.swing.JLabel();
        jLabel11 = new javax.swing.JLabel();
        jLabel12 = new javax.swing.JLabel();
        rl_NoteInfo = new rmp.comn.rmps.C4010000.C4010000();
        rl_NoteInfo.wInit();
        rl_NoteInfo.wShowView(P3010000.VIEW_NORM);

        ib_SoftIcon.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        ib_SoftIcon.setPreferredSize(new java.awt.Dimension(52, 52));

        tf_ExtsName.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_ExtsName_Handler(evt);
            }
        });

        lb_SoftList.setText("jphli中文");

        bt_SoftList.setText("L");
        bt_SoftList.setMargin(new java.awt.Insets(2, 2, 2, 2));
        bt_SoftList.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_SoftList_Handler(evt);
            }
        });

        pl_CardPanl.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(204, 204, 204)));
        pl_CardPanl.setPreferredSize(new java.awt.Dimension(200, 162));

        cl_CardPanl = new java.awt.CardLayout();
        pl_CardPanl.setLayout(cl_CardPanl);
        pl_CardPanl.setPreferredSize(new java.awt.Dimension(200, 162));

        lb_IdioInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_IdioInfo.setText("I");
        lb_IdioInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_IdioInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_IdioInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_IdioInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_IdioInfo.setBorder(null);
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

        lb_AsocInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_AsocInfo.setText("A");
        lb_AsocInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_AsocInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_AsocInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_AsocInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_AsocInfo.setBorder(null);
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

        lb_FileInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_FileInfo.setText("F");
        lb_FileInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_FileInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_FileInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_FileInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_FileInfo.setBorder(null);
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

        lb_SoftInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_SoftInfo.setText("S");
        lb_SoftInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_SoftInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_SoftInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_SoftInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_SoftInfo.setBorder(null);
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

        lb_CorpInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_CorpInfo.setText("C");
        lb_CorpInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_CorpInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_CorpInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_CorpInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_CorpInfo.setBorder(null);
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

        lb_MimeInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_MimeInfo.setText("M");
        lb_MimeInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_MimeInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_MimeInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_MimeInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_MimeInfo.setBorder(null);
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

        lb_DespInfo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lb_DespInfo.setText("D");
        lb_DespInfo.setPreferredSize(new java.awt.Dimension(14, 16));
        lb_DespInfo.addMouseListener(new java.awt.event.MouseListener()
        {
            @Override
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lb_DespInfo_Handler(evt);
            }

            @Override
            public void mouseEntered(java.awt.event.MouseEvent evt)
            {
                lb_DespInfo.setBorder(me_FlashBorder);
            }

            @Override
            public void mouseExited(java.awt.event.MouseEvent evt)
            {
                lb_DespInfo.setBorder(null);
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

        jLabel10.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel10.setText("5");
        jLabel10.setPreferredSize(new java.awt.Dimension(14, 16));

        jLabel11.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel11.setText("0");
        jLabel11.setPreferredSize(new java.awt.Dimension(14, 16));

        jLabel12.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel12.setText("4");
        jLabel12.setPreferredSize(new java.awt.Dimension(14, 16));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rl_NoteInfo.getAd(),
                javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addComponent(pl_CardPanl,
                javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addComponent(sp1,
                javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addGroup(
                layout.createSequentialGroup().addComponent(ib_SoftIcon, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_ExtsName,
                javax.swing.GroupLayout.DEFAULT_SIZE, 136, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(lb_SoftList,
                javax.swing.GroupLayout.DEFAULT_SIZE, 117, Short.MAX_VALUE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_SoftList)))).addComponent(sp2, javax.swing.GroupLayout.DEFAULT_SIZE, 194, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(jLabel12, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel10,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel11,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addGap(6, 6, 6).addComponent(lb_DespInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_MimeInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_CorpInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_SoftInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_FileInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_AsocInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_IdioInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(
                layout.createSequentialGroup().addComponent(tf_ExtsName, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(bt_SoftList).addComponent(lb_SoftList))).addComponent(ib_SoftIcon,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp1,
                javax.swing.GroupLayout.PREFERRED_SIZE, 2, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_CardPanl,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp2,
                javax.swing.GroupLayout.PREFERRED_SIZE, 2, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IdioInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_AsocInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_FileInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_SoftInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_CorpInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_MimeInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lb_DespInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel10,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel11,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel12,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(rl_NoteInfo.getAd()).addContainerGap(
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
    }

    /**
     * 描述信息面板初始化
     */
    private void icb()
    {
        pl_DespInfo = new javax.swing.JPanel();
        pl_DespInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_DespInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_ExtsType = new javax.swing.JLabel();
        pl_DespInfo.add(lb_ExtsType, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_ExtsType = new javax.swing.JLabel();
        pl_DespInfo.add(lt_ExtsType, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_ArchBits = new javax.swing.JLabel();
        pl_DespInfo.add(lb_ArchBits, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_ArchBits = new javax.swing.JLabel();
        pl_DespInfo.add(lt_ArchBits, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_PlatForm = new javax.swing.JLabel();
        pl_DespInfo.add(lb_PlatForm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_PlatForm = new javax.swing.JLabel();
        pl_DespInfo.add(lt_PlatForm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_ExtsDesp = new javax.swing.JLabel();
        pl_DespInfo.add(lb_ExtsDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_ExtsDesp = new javax.swing.JScrollPane();
        lt_ExtsDesp = new javax.swing.JTextArea();
        lt_ExtsDesp.setEditable(false);
        lt_ExtsDesp.setLineWrap(true);
        sp_ExtsDesp.setViewportView(lt_ExtsDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_DespInfo.add(sp_ExtsDesp, gridBagConstraints);
    }

    /**
     * MIME类型面板初始化
     */
    private void icc()
    {
        pl_MimeInfo = new javax.swing.JPanel();
        lb_MimeType = new javax.swing.JLabel();
        lt_MimeNm00 = new javax.swing.JLabel();
        lt_MimeNm01 = new javax.swing.JLabel();
        lt_MimeNm02 = new javax.swing.JLabel();
        lt_MimeNm03 = new javax.swing.JLabel();
        lt_MimeNm04 = new javax.swing.JLabel();
        lt_MimeNm05 = new javax.swing.JLabel();

        pl_MimeInfo.setPreferredSize(new java.awt.Dimension(200, 162));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_MimeInfo);
        pl_MimeInfo.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lt_MimeNm00,
                javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                lb_MimeType).addComponent(lt_MimeNm01, javax.swing.GroupLayout.DEFAULT_SIZE, 180, Short.MAX_VALUE).addComponent(lt_MimeNm02, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_MimeNm03,
                javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_MimeNm04, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_MimeNm05,
                javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_MimeType).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm00).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm01).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm02).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm03).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm04).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_MimeNm05).addContainerGap(17,
                Short.MAX_VALUE)));
    }

    /**
     * 公司息面板初始化
     */
    private void icd()
    {
        pl_CorpInfo = new javax.swing.JPanel();
        pl_CorpInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_CorpInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_CorpLcNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpLcNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_CorpLcNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lt_CorpLcNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CorpEnNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpEnNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_CorpEnNm = new javax.swing.JLabel();
        pl_CorpInfo.add(lt_CorpEnNm, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CorpSite = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_CorpSite = new rmp.ui.link.WLinkLabel();
        lt_CorpSite.setAutoOpenLink(true);
        pl_CorpInfo.add(lt_CorpSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CorpDesp = new javax.swing.JLabel();
        pl_CorpInfo.add(lb_CorpDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_CorpDesp = new javax.swing.JTextArea();
        lt_CorpDesp.setEditable(false);
        lt_CorpDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_CorpDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_CorpInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 软件信息面板初始化
     */
    private void ice()
    {
        pl_SoftInfo = new javax.swing.JPanel();
        pl_SoftInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_SoftInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_SoftName = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_SoftName = new javax.swing.JLabel();
        pl_SoftInfo.add(lt_SoftName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SoftExts = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftExts, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_SoftExts = new javax.swing.JLabel();
        pl_SoftInfo.add(lt_SoftExts, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SoftSite = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_SoftSite = new rmp.ui.link.WLinkLabel();
        lt_SoftSite.setAutoOpenLink(true);
        pl_SoftInfo.add(lt_SoftSite, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SoftDesp = new javax.swing.JLabel();
        pl_SoftInfo.add(lb_SoftDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_SoftDesp = new javax.swing.JTextArea();
        lt_SoftDesp.setEditable(false);
        lt_SoftDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_SoftDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_SoftInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 文件信息面板初始化
     */
    private void icf()
    {
        pl_FileInfo = new javax.swing.JPanel();
        pl_FileInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_FileInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_SignChar = new javax.swing.JLabel();
        pl_FileInfo.add(lb_SignChar, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_SignChar = new javax.swing.JLabel();
        pl_FileInfo.add(lt_SignChar, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_SignCode = new javax.swing.JLabel();
        pl_FileInfo.add(lb_SignCode, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_SignCode = new javax.swing.JLabel();
        pl_FileInfo.add(lt_SignCode, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_CipherSn = new javax.swing.JLabel();
        pl_FileInfo.add(lb_CipherSn, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_CipherSn = new javax.swing.JLabel();
        pl_FileInfo.add(lt_CipherSn, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_FileDesp = new javax.swing.JLabel();
        pl_FileInfo.add(lb_FileDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_FileDesp = new javax.swing.JTextArea();
        lt_FileDesp.setEditable(false);
        lt_FileDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_FileDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_FileInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 备选软件面板初始化
     */
    private void icg()
    {
        pl_AsocInfo = new javax.swing.JPanel();
        lb_AsocSoft = new javax.swing.JLabel();
        lt_AsocNm00 = new javax.swing.JLabel();
        lt_AsocNm01 = new javax.swing.JLabel();
        lt_AsocNm02 = new javax.swing.JLabel();
        lt_AsocNm03 = new javax.swing.JLabel();
        lt_AsocNm04 = new javax.swing.JLabel();
        lt_AsocNm05 = new javax.swing.JLabel();

        pl_AsocInfo.setPreferredSize(new java.awt.Dimension(200, 162));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_AsocInfo);
        pl_AsocInfo.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lt_AsocNm00,
                javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                lb_AsocSoft).addComponent(lt_AsocNm01, javax.swing.GroupLayout.DEFAULT_SIZE, 180, Short.MAX_VALUE).addComponent(lt_AsocNm02, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_AsocNm03,
                javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_AsocNm04, javax.swing.GroupLayout.PREFERRED_SIZE, 180,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(lt_AsocNm05,
                javax.swing.GroupLayout.PREFERRED_SIZE, 180, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lb_AsocSoft).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm00).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm01).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm02).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm03).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm04).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_AsocNm05).addContainerGap(17,
                Short.MAX_VALUE)));
    }

    /**
     * 特别致谢面板初始化
     */
    private void ich()
    {
        pl_IdioInfo = new javax.swing.JPanel();
        pl_IdioInfo.setPreferredSize(new java.awt.Dimension(200, 162));
        pl_IdioInfo.setLayout(new java.awt.GridBagLayout());

        java.awt.GridBagConstraints gridBagConstraints;

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.insets = new java.awt.Insets(6, 6, 3, 3);
        lb_IdioMail = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_IdioMail, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(6, 3, 3, 6);
        lt_IdioMail = new rmp.ui.link.WLinkLabel();
        lt_IdioMail.setAutoOpenLink(true);
        pl_IdioInfo.add(lt_IdioMail, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_NickName = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_NickName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_NickName = new javax.swing.JLabel();
        pl_IdioInfo.add(lt_NickName, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_HomePage = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_HomePage, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 3, 3, 6);
        lt_HomePage = new rmp.ui.link.WLinkLabel();
        lt_HomePage.setAutoOpenLink(true);
        pl_IdioInfo.add(lt_HomePage, gridBagConstraints);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 3;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 3, 3);
        lb_IdioDesp = new javax.swing.JLabel();
        pl_IdioInfo.add(lb_IdioDesp, gridBagConstraints);

        javax.swing.JScrollPane sp_SoftDesp = new javax.swing.JScrollPane();
        lt_IdioDesp = new javax.swing.JTextArea();
        lt_IdioDesp.setEditable(false);
        lt_IdioDesp.setLineWrap(true);
        sp_SoftDesp.setViewportView(lt_IdioDesp);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 4;
        gridBagConstraints.gridwidth = 3;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        gridBagConstraints.insets = new java.awt.Insets(3, 6, 6, 6);
        pl_IdioInfo.add(sp_SoftDesp, gridBagConstraints);
    }

    /**
     * 
     */
    private void ita()
    {
        // ------------------------------------------------
        // 迷你面板
        // ------------------------------------------------
        // 后缀名称
        BeanUtil.setWText(tf_ExtsName, P3010000.getMesg(LangRes.MAIN_FILD_TEXT_EXTSNAME));
        BeanUtil.setWTips(tf_ExtsName, P3010000.getMesg(LangRes.MAIN_FILD_TIPS_EXTSNAME));

        // 软件名称
        BeanUtil.setWText(lb_SoftList, P3010000.getMesg(LangRes.EXTS_COMB_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftList, P3010000.getMesg(LangRes.EXTS_COMB_TIPS_SOFTNAME));

        // 结果数量
        BeanUtil.setWText(bt_SoftList, P3010000.getMesg(LangRes.MINI_BUTN_TEXT_SOFTLIST));
        BeanUtil.setWTips(bt_SoftList, P3010000.getMesg(LangRes.MINI_BUTN_TIPS_SOFTLIST));

        // 后缀描述
        BeanUtil.setWText(lb_DespInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_DESPINFO));
        BeanUtil.setWTips(lb_DespInfo, P3010000.getMesg(LangRes.TITLE_DESPFORM));

        // MIME类型
        BeanUtil.setWText(lb_MimeInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_MIMEINFO));
        BeanUtil.setWTips(lb_MimeInfo, P3010000.getMesg(LangRes.TITLE_MIMEFORM));

        // 公司信息
        BeanUtil.setWText(lb_CorpInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_CORPINFO));
        BeanUtil.setWTips(lb_CorpInfo, P3010000.getMesg(LangRes.TITLE_CORPFORM));

        // 软件信息
        BeanUtil.setWText(lb_SoftInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_SOFTINFO));
        BeanUtil.setWTips(lb_SoftInfo, P3010000.getMesg(LangRes.TITLE_SOFTFORM));

        // 文件信息
        BeanUtil.setWText(lb_FileInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_FILEINFO));
        BeanUtil.setWTips(lb_FileInfo, P3010000.getMesg(LangRes.TITLE_FILEFORM));

        // MIME类型
        BeanUtil.setWText(lb_AsocInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_ASOCINFO));
        BeanUtil.setWTips(lb_AsocInfo, P3010000.getMesg(LangRes.TITLE_ASOCFORM));

        // 特别致谢
        BeanUtil.setWText(lb_IdioInfo, P3010000.getMesg(LangRes.MINI_LABL_TEXT_IDIOINFO));
        BeanUtil.setWTips(lb_IdioInfo, P3010000.getMesg(LangRes.TITLE_IDIOFORM));

        // 公益广告
        // BeanUtil.setWTips(rl_NoteInfo,
        // P3010000.getMesg(LangRes.MAIN_ROLL_TIPS_PUBLICAD));

        // ------------------------------------------------
        // 后缀描述
        // ------------------------------------------------
        // 所属类别
        BeanUtil.setWText(lb_ExtsType, P3010000.getMesg(LangRes.MAIN_COMN_TEXT_EXTSTYPE));
        BeanUtil.setWTips(lb_ExtsType, P3010000.getMesg(LangRes.MAIN_COMN_TEXT_EXTSTYPE));

        // CPU 类型
        BeanUtil.setWText(lb_ArchBits, P3010000.getMesg(LangRes.MAIN_COMN_TEXT_ARCHBITS));
        BeanUtil.setWTips(lb_ArchBits, P3010000.getMesg(LangRes.MAIN_COMN_TEXT_ARCHBITS));

        // 运行平台
        BeanUtil.setWText(lb_PlatForm, P3010000.getMesg(LangRes.MAIN_COMN_TEXT_EXTSPLAT));
        BeanUtil.setWTips(lb_PlatForm, P3010000.getMesg(LangRes.MAIN_COMN_TEXT_EXTSPLAT));

        // 后缀说明
        BeanUtil.setWText(lb_ExtsDesp, P3010000.getMesg(LangRes.DESP_COMN_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, P3010000.getMesg(LangRes.DESP_COMN_TEXT_EXTSDESP));

        // 后缀说明
        BeanUtil.setWText(lb_ExtsDesp, P3010000.getMesg(LangRes.DESP_AREA_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, P3010000.getMesg(LangRes.DESP_AREA_TIPS_EXTSDESP));

        // ------------------------------------------------
        // MIME类型
        // ------------------------------------------------
        BeanUtil.setWText(lb_MimeType, P3010000.getMesg(LangRes.MIME_COMN_TEXT_MIMENAME));
        BeanUtil.setWTips(lb_MimeType, P3010000.getMesg(LangRes.MIME_COMN_TEXT_MIMENAME));

        // ------------------------------------------------
        // 公司信息
        // ------------------------------------------------
        BeanUtil.setWText(lb_CorpLcNm, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPLCNM));
        BeanUtil.setWTips(lb_CorpLcNm, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPLCNM));

        BeanUtil.setWText(lb_CorpEnNm, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPENNM));
        BeanUtil.setWTips(lb_CorpEnNm, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPENNM));

        BeanUtil.setWText(lb_CorpSite, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPSITE));
        BeanUtil.setWTips(lb_CorpSite, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPSITE));

        BeanUtil.setWText(lb_CorpDesp, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPDESP));
        BeanUtil.setWTips(lb_CorpDesp, P3010000.getMesg(LangRes.CORP_COMN_TEXT_CORPDESP));

        // ------------------------------------------------
        // 软件信息
        // ------------------------------------------------
        BeanUtil.setWText(lb_SoftName, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftName, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTNAME));

        BeanUtil.setWText(lb_SoftExts, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTEXTS));
        BeanUtil.setWTips(lb_SoftExts, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTEXTS));

        BeanUtil.setWText(lb_SoftSite, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTSITE));
        BeanUtil.setWTips(lb_SoftSite, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTSITE));

        BeanUtil.setWText(lb_SoftDesp, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTDESP));
        BeanUtil.setWTips(lb_SoftDesp, P3010000.getMesg(LangRes.SOFT_COMN_TEXT_SOFTDESP));

        // ------------------------------------------------
        // 文件信息
        // ------------------------------------------------
        BeanUtil.setWText(lb_SignChar, P3010000.getMesg(LangRes.FILE_COMN_TEXT_SIGNCHAR));
        BeanUtil.setWTips(lb_SignChar, P3010000.getMesg(LangRes.FILE_COMN_TEXT_SIGNCHAR));

        BeanUtil.setWText(lb_SignCode, P3010000.getMesg(LangRes.FILE_COMN_TEXT_SIGNCODE));
        BeanUtil.setWTips(lb_SignCode, P3010000.getMesg(LangRes.FILE_COMN_TEXT_SIGNCODE));

        BeanUtil.setWText(lb_CipherSn, P3010000.getMesg(LangRes.FILE_COMN_TEXT_CIPHERSN));
        BeanUtil.setWTips(lb_CipherSn, P3010000.getMesg(LangRes.FILE_COMN_TEXT_CIPHERSN));

        BeanUtil.setWText(lb_FileDesp, P3010000.getMesg(LangRes.FILE_COMN_TEXT_FILEDESP));
        BeanUtil.setWTips(lb_FileDesp, P3010000.getMesg(LangRes.FILE_COMN_TEXT_FILEDESP));

        // ------------------------------------------------
        // 备选软件
        // ------------------------------------------------
        BeanUtil.setWText(lb_AsocSoft, P3010000.getMesg(LangRes.ASOC_COMN_TEXT_ASOCSOFT));
        BeanUtil.setWTips(lb_AsocSoft, P3010000.getMesg(LangRes.ASOC_COMN_TEXT_ASOCSOFT));

        // ------------------------------------------------
        // 特别致谢
        // ------------------------------------------------
        BeanUtil.setWText(lb_IdioMail, P3010000.getMesg(LangRes.IDIO_COMN_TEXT_IDIOMAIL));
        BeanUtil.setWTips(lb_IdioMail, P3010000.getMesg(LangRes.IDIO_COMN_TEXT_IDIOMAIL));

        BeanUtil.setWText(lb_NickName, P3010000.getMesg(LangRes.MINI_LABL_TEXT_NICKNAME));
        BeanUtil.setWTips(lb_NickName, P3010000.getMesg(LangRes.MINI_LABL_TIPS_NICKNAME));

        BeanUtil.setWText(lb_HomePage, P3010000.getMesg(LangRes.IDIO_COMN_TEXT_HOMEPAGE));
        BeanUtil.setWTips(lb_HomePage, P3010000.getMesg(LangRes.IDIO_COMN_TEXT_HOMEPAGE));

        BeanUtil.setWText(lb_IdioDesp, P3010000.getMesg(LangRes.IDIO_COMN_TEXT_IDIODESP));
        BeanUtil.setWTips(lb_IdioDesp, P3010000.getMesg(LangRes.IDIO_COMN_TEXT_IDIODESP));
    }

    // ========================================================================
    // 事件处理区域
    // ========================================================================
    /**
     * @param evt
     */
    private void bt_SoftList_Handler(java.awt.event.ActionEvent evt)
    {
        if (pm_SoftMenu.getComponentCount() > 0)
        {
            pm_SoftMenu.show(bt_SoftList, 0, bt_SoftList.getSize().height);
        }
    }

    /**
     * @param evt
     */
    private void tf_ExtsName_Handler(java.awt.event.ActionEvent evt)
    {
        // // 用户输入数据合法性检测
        // UserData userMeta = new UserData();
        // userMeta.wInit();
        //
        // // 数据检测
        // if (!userMeta.setExtsName(this.tf_ExtsName.getText()))
        // {
        // MesgUtil.showMessageDialog(P3010000.getForm(), userMeta.getErrMsg());
        // this.tf_ExtsName.requestFocus();
        // return;
        // }
        // this.tf_ExtsName.setText(userMeta.getExtsName());
        //
        // // 数据查询
        // metaSelect(userMeta.getExtsName());
    }

    /**
     * @param evt
     */
    private void lb_DespInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_DESP);
        changeLabel(lb_DespInfo);
    }

    /**
     * @param evt
     */
    private void lb_MimeInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_MIME);
        changeLabel(lb_MimeInfo);
    }

    /**
     * @param evt
     */
    private void lb_CorpInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_CORP);
        changeLabel(lb_CorpInfo);
    }

    /**
     * @param evt
     */
    private void lb_SoftInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_SOFT);
        changeLabel(lb_SoftInfo);
    }

    /**
     * @param evt
     */
    private void lb_FileInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_FILE);
        changeLabel(lb_FileInfo);
    }

    /**
     * @param evt
     */
    private void lb_AsocInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_ASOC);
        changeLabel(lb_AsocInfo);
    }

    /**
     * @param evt
     */
    private void lb_IdioInfo_Handler(java.awt.event.MouseEvent evt)
    {
        cl_CardPanl.show(pl_CardPanl, ConstUI.PROP_ITEM_IDIO);
        changeLabel(lb_IdioInfo);
    }

    // ========================================================================
    // 公共接口区域
    // ========================================================================
    /**
     * 标签背景颜色交替显示
     * 
     * @param currLabl
     */
    private void changeLabel(javax.swing.JLabel currLabl)
    {
        lb_LastLabl.setOpaque(false);
        lb_LastLabl.repaint();

        lb_LastLabl = currLabl;

        lb_LastLabl.setOpaque(true);
        lb_LastLabl.repaint();
    }
    // ========================================================================
    // 界面组件区域
    // ========================================================================
    private javax.swing.JButton bt_SoftList;
    private javax.swing.JLabel lb_AsocInfo;
    private javax.swing.JLabel lb_CorpInfo;
    private javax.swing.JLabel lb_DespInfo;
    private javax.swing.JLabel lb_FileInfo;
    private javax.swing.JLabel lb_IdioInfo;
    private javax.swing.JLabel lb_MimeInfo;
    private javax.swing.JLabel lb_SoftInfo;
    private javax.swing.JLabel lb_SoftList;
    private javax.swing.JPanel pl_CardPanl;
    private javax.swing.JTextField tf_ExtsName;
    private WIconBox ib_SoftIcon;
    private rmp.comn.rmps.C4010000.C4010000 rl_NoteInfo;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    // ----------------------------------------------------
    // 后缀描述组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_DespInfo;
    private javax.swing.JLabel lb_ExtsType;
    private javax.swing.JLabel lb_ArchBits;
    private javax.swing.JLabel lb_PlatForm;
    private javax.swing.JLabel lb_ExtsDesp;
    private javax.swing.JLabel lt_ExtsType;
    private javax.swing.JLabel lt_ArchBits;
    private javax.swing.JLabel lt_PlatForm;
    private javax.swing.JTextArea lt_ExtsDesp;
    // ----------------------------------------------------
    // 公司信息组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_CorpInfo;
    private javax.swing.JLabel lb_CorpDesp;
    private javax.swing.JLabel lb_CorpEnNm;
    private javax.swing.JLabel lb_CorpLcNm;
    private javax.swing.JLabel lb_CorpSite;
    private javax.swing.JTextArea lt_CorpDesp;
    private javax.swing.JLabel lt_CorpEnNm;
    private javax.swing.JLabel lt_CorpLcNm;
    private rmp.ui.link.WLinkLabel lt_CorpSite;
    // ----------------------------------------------------
    // 软件信息组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_SoftInfo;
    private javax.swing.JLabel lb_SoftDesp;
    private javax.swing.JLabel lb_SoftName;
    private javax.swing.JLabel lb_SoftExts;
    private javax.swing.JLabel lb_SoftSite;
    private javax.swing.JTextArea lt_SoftDesp;
    private javax.swing.JLabel lt_SoftName;
    private javax.swing.JLabel lt_SoftExts;
    private rmp.ui.link.WLinkLabel lt_SoftSite;
    // ----------------------------------------------------
    // 文件信息组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_FileInfo;
    private javax.swing.JLabel lb_FileDesp;
    private javax.swing.JLabel lb_SignChar;
    private javax.swing.JLabel lb_SignCode;
    private javax.swing.JLabel lb_CipherSn;
    private javax.swing.JTextArea lt_FileDesp;
    private javax.swing.JLabel lt_SignChar;
    private javax.swing.JLabel lt_SignCode;
    private javax.swing.JLabel lt_CipherSn;
    // ----------------------------------------------------
    // MIME类型组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_MimeInfo;
    private javax.swing.JLabel lb_MimeType;
    private javax.swing.JLabel lt_MimeNm00;
    private javax.swing.JLabel lt_MimeNm01;
    private javax.swing.JLabel lt_MimeNm02;
    private javax.swing.JLabel lt_MimeNm03;
    private javax.swing.JLabel lt_MimeNm04;
    private javax.swing.JLabel lt_MimeNm05;
    // ----------------------------------------------------
    // 备选软件组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_AsocInfo;
    private javax.swing.JLabel lb_AsocSoft;
    private javax.swing.JLabel lt_AsocNm00;
    private javax.swing.JLabel lt_AsocNm01;
    private javax.swing.JLabel lt_AsocNm02;
    private javax.swing.JLabel lt_AsocNm03;
    private javax.swing.JLabel lt_AsocNm04;
    private javax.swing.JLabel lt_AsocNm05;
    // ----------------------------------------------------
    // 特别致谢组件区域
    // ----------------------------------------------------
    private javax.swing.JPanel pl_IdioInfo;
    private javax.swing.JLabel lb_IdioDesp;
    private javax.swing.JLabel lb_IdioMail;
    private javax.swing.JLabel lb_NickName;
    private javax.swing.JLabel lb_HomePage;
    private javax.swing.JTextArea lt_IdioDesp;
    private rmp.ui.link.WLinkLabel lt_IdioMail;
    private javax.swing.JLabel lt_NickName;
    private rmp.ui.link.WLinkLabel lt_HomePage;
    /** serialVersionUID */
    private static final long serialVersionUID = 3402287005504434362L;
}
