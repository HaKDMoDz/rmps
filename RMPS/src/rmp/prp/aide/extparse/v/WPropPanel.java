/*
 * FileName:       WPropPanel.java
 * CreateDate:     2007-8-29 下午08:31:55
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import rmp.face.WBean;
import rmp.prp.aide.extparse.Extparse;
import rmp.prp.aide.extparse.b.WIconBox;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import cons.SysCons;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-8-29 下午08:31:55
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class WPropPanel extends javax.swing.JPanel implements WBean
{
    /** 父应用引用 */
    private Extparse          me_MainSoft;

    /**
     * @param soft
     */
    public WPropPanel(Extparse soft)
    {
        me_MainSoft = soft;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
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
        lb_PlatForm = new javax.swing.JLabel();
        ck_PfAll = new javax.swing.JCheckBox();
        ck_PfWin = new javax.swing.JCheckBox();
        ck_PfMac = new javax.swing.JCheckBox();
        ck_PfUnx = new javax.swing.JCheckBox();
        ck_PfLnx = new javax.swing.JCheckBox();
        ck_PfMbl = new javax.swing.JCheckBox();
        ck_PfSpc = new javax.swing.JCheckBox();
        lb_ArchBits = new javax.swing.JLabel();
        ck_Ab64 = new javax.swing.JCheckBox();
        ck_Ab32 = new javax.swing.JCheckBox();
        ck_Ab16 = new javax.swing.JCheckBox();
        ck_Ab00 = new javax.swing.JCheckBox();
        lb_ExtsType = new javax.swing.JLabel();
        tf_ExtsType = new javax.swing.JTextField();
        javax.swing.JPanel pl_IconPanl = new javax.swing.JPanel();
        ib_FileIcon = new WIconBox(me_MainSoft);
        ib_FileIcon.setIconPath(EnvUtil.getIconFileDir());
        ib_FileIcon.wInit();
        ib_FileIcon.setName(ConstUI.PROP_FILEICON);
        ib_SoftIcon = new WIconBox(me_MainSoft);
        ib_SoftIcon.setIconPath(EnvUtil.getIconSoftDir());
        ib_SoftIcon.wInit();
        ib_SoftIcon.setName(ConstUI.PROP_SOFTICON);
        ib_CorpIcon = new WIconBox(me_MainSoft);
        ib_CorpIcon.setIconPath(EnvUtil.getIconCorpDir());
        ib_CorpIcon.wInit();
        ib_CorpIcon.setName(ConstUI.PROP_CORPICON);
        ib_IdioIcon = new WIconBox(me_MainSoft);
        ib_IdioIcon.setIconPath(EnvUtil.getIconIdioDir());
        ib_IdioIcon.wInit();
        ib_IdioIcon.setName(ConstUI.PROP_IDIOICON);

        lb_PlatForm.setText("\u5e94\u7528\u5e73\u53f0");
        lb_PlatForm.setToolTipText("\u5e94\u7528\u5e73\u53f0");

        ck_PfAll.setSelected(true);
        ck_PfAll.setText("\u5e73\u53f0\u901a\u7528(G)");
        ck_PfAll.setToolTipText("\u5e73\u53f0\u901a\u7528");
        ck_PfAll.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfAll.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_PfAll.addChangeListener(new javax.swing.event.ChangeListener()
        {
            @ Override
            public void stateChanged(javax.swing.event.ChangeEvent evt)
            {
                ck_PfAll_Handler(evt);
            }
        });

        ck_PfWin.setMnemonic('W');
        ck_PfWin.setText("Windows(W)");
        ck_PfWin.setToolTipText("Windows");
        ck_PfWin.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfWin.setDisplayedMnemonicIndex(8);
        ck_PfWin.setEnabled(false);
        ck_PfWin.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMac.setMnemonic('M');
        ck_PfMac.setText("Macintosh(M)");
        ck_PfMac.setToolTipText("Macintosh");
        ck_PfMac.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMac.setDisplayedMnemonicIndex(10);
        ck_PfMac.setEnabled(false);
        ck_PfMac.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfUnx.setMnemonic('U');
        ck_PfUnx.setText("Unix(U)");
        ck_PfUnx.setToolTipText("Unix");
        ck_PfUnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfUnx.setDisplayedMnemonicIndex(5);
        ck_PfUnx.setEnabled(false);
        ck_PfUnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfLnx.setMnemonic('L');
        ck_PfLnx.setText("Linux(L)");
        ck_PfLnx.setToolTipText("Linux");
        ck_PfLnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfLnx.setDisplayedMnemonicIndex(6);
        ck_PfLnx.setEnabled(false);
        ck_PfLnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMbl.setMnemonic('M');
        ck_PfMbl.setText("\u79fb\u52a8\u5e73\u53f0(M)");
        ck_PfMbl.setToolTipText("\u79fb\u52a8\u5e73\u53f0");
        ck_PfMbl.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMbl.setEnabled(false);
        ck_PfMbl.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfSpc.setMnemonic('O');
        ck_PfSpc.setText("\u5176\u5b83\u5e73\u53f0(O)");
        ck_PfSpc.setToolTipText("\u5176\u5b83\u5e73\u53f0");
        ck_PfSpc.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfSpc.setEnabled(false);
        ck_PfSpc.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_ArchBits.setText("CPU \u67b6\u6784");
        lb_ArchBits.setToolTipText("CPU \u67b6\u6784");

        ck_Ab64.setMnemonic('0');
        ck_Ab64.setText("64\u4f4d(0)");
        ck_Ab64.setToolTipText("64\u4f4d");
        ck_Ab64.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab64.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab32.setMnemonic('1');
        ck_Ab32.setSelected(true);
        ck_Ab32.setText("32\u4f4d(1)");
        ck_Ab32.setToolTipText("32\u4f4d");
        ck_Ab32.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab32.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab16.setMnemonic('2');
        ck_Ab16.setText("16\u4f4d(2)");
        ck_Ab16.setToolTipText("16\u4f4d");
        ck_Ab16.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab16.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab00.setMnemonic('3');
        ck_Ab00.setText("\u5176\u5b83(3)");
        ck_Ab00.setToolTipText("\u5176\u5b83");
        ck_Ab00.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab00.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_ExtsType.setLabelFor(tf_ExtsType);
        lb_ExtsType.setText("\u6240\u5c5e\u7c7b\u522b(K)");
        lb_ExtsType.setToolTipText("\u6240\u5c5e\u7c7b\u522b");

        tf_ExtsType.setEditable(false);

        pl_IconPanl.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 10, 0));

        ib_FileIcon.setToolTipText("\u8f6f\u4ef6\u56fe\u6807");
        ib_FileIcon.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        ib_FileIcon.setPreferredSize(new java.awt.Dimension(50, 50));
        pl_IconPanl.add(ib_FileIcon);

        ib_SoftIcon.setToolTipText("\u6587\u4ef6\u56fe\u6807");
        ib_SoftIcon.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        ib_SoftIcon.setPreferredSize(new java.awt.Dimension(50, 50));
        pl_IconPanl.add(ib_SoftIcon);

        ib_CorpIcon.setToolTipText("\u6587\u4ef6\u56fe\u6807");
        ib_CorpIcon.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        ib_CorpIcon.setPreferredSize(new java.awt.Dimension(50, 50));
        pl_IconPanl.add(ib_CorpIcon);

        ib_IdioIcon.setToolTipText("\u6587\u4ef6\u56fe\u6807");
        ib_IdioIcon.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(0, 0, 0)));
        ib_IdioIcon.setPreferredSize(new java.awt.Dimension(50, 50));
        pl_IconPanl.add(ib_IdioIcon);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_IconPanl,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 248, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_PlatForm)
                            .addComponent(lb_ArchBits).addComponent(lb_ExtsType)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(
                                layout.createSequentialGroup().addGroup(
                                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(
                                        ck_PfAll).addComponent(ck_PfWin).addComponent(ck_PfUnx).addComponent(ck_PfMbl)
                                        .addComponent(ck_Ab64).addComponent(ck_Ab16)).addGroup(
                                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                        layout.createSequentialGroup().addGap(6, 6, 6).addComponent(ck_PfMac))
                                        .addGroup(
                                            layout.createSequentialGroup().addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                ck_PfLnx)).addGroup(
                                            layout.createSequentialGroup().addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                ck_PfSpc)).addGroup(
                                            layout.createSequentialGroup().addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                ck_Ab00)).addGroup(
                                            layout.createSequentialGroup().addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                ck_Ab32)))).addComponent(tf_ExtsType,
                                javax.swing.GroupLayout.DEFAULT_SIZE, 178, Short.MAX_VALUE)))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(pl_IconPanl,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_PlatForm)
                    .addComponent(ck_PfAll)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfWin)
                        .addComponent(ck_PfMac)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfUnx)
                        .addComponent(ck_PfLnx)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_PfMbl)
                        .addComponent(ck_PfSpc)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ArchBits)
                        .addComponent(ck_Ab64).addComponent(ck_Ab32)).addPreferredGap(
                    javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(ck_Ab16)
                        .addComponent(ck_Ab00)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ExtsType)
                        .addComponent(tf_ExtsType, javax.swing.GroupLayout.PREFERRED_SIZE,
                            javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // 应用平台
        BeanUtil.setWText(lb_PlatForm, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_PLATFORM));
        BeanUtil.setWTips(lb_PlatForm, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_PLATFORM));

        // 平台通用
        BeanUtil.setWText(ck_PfAll, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFALL));
        BeanUtil.setWTips(ck_PfAll, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFALL));

        // 平台通用
        BeanUtil.setWText(ck_PfAll, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFALL));
        BeanUtil.setWTips(ck_PfAll, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFALL));

        // Windows
        BeanUtil.setWText(ck_PfWin, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFWIN));
        BeanUtil.setWTips(ck_PfWin, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFWIN));

        // Macintosh
        BeanUtil.setWText(ck_PfMac, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFMAC));
        BeanUtil.setWTips(ck_PfMac, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFMAC));

        // Unix
        BeanUtil.setWText(ck_PfUnx, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFUNX));
        BeanUtil.setWTips(ck_PfUnx, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFUNX));

        // Linux
        BeanUtil.setWText(ck_PfLnx, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFLNX));
        BeanUtil.setWTips(ck_PfLnx, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFLNX));

        // 移动平台
        BeanUtil.setWText(ck_PfMbl, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFMBL));
        BeanUtil.setWTips(ck_PfMbl, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFMBL));

        // 其它平台
        BeanUtil.setWText(ck_PfSpc, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_PFSPC));
        BeanUtil.setWTips(ck_PfSpc, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_PFSPC));

        // CPU 架构
        BeanUtil.setWText(lb_ArchBits, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_ARCHBITS));
        BeanUtil.setWTips(lb_ArchBits, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_ARCHBITS));

        // 64位
        BeanUtil.setWText(ck_Ab64, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_AB64));
        BeanUtil.setWTips(ck_Ab64, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_AB64));

        // 32位
        BeanUtil.setWText(ck_Ab32, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_AB32));
        BeanUtil.setWTips(ck_Ab32, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_AB32));

        // 16位
        BeanUtil.setWText(ck_Ab16, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_AB16));
        BeanUtil.setWTips(ck_Ab16, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_AB16));

        // 其它
        BeanUtil.setWText(ck_Ab00, Extparse.getMesg(LangRes.MAIN_CHCK_TEXT_AB00));
        BeanUtil.setWTips(ck_Ab00, Extparse.getMesg(LangRes.MAIN_CHCK_TIPS_AB00));

        // 所属类别
        BeanUtil.setWText(lb_ExtsType, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_EXTSTYPE));
        BeanUtil.setWTips(lb_ExtsType, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_EXTSTYPE));

        BeanUtil.setWText(tf_ExtsType, Extparse.getMesg(LangRes.MAIN_FILD_TEXT_EXTSTYPE));
        BeanUtil.setWTips(tf_ExtsType, Extparse.getMesg(LangRes.MAIN_FILD_TIPS_EXTSTYPE));
    }

    /**
     * CPU架构信息显示
     * 
     * @param archBits
     */
    public void setArchBits(int archBits)
    {
        // 64位
        this.ck_Ab64.setSelected((SysCons.BITS_IDX_64 & archBits) != 0);
        // 32位
        this.ck_Ab32.setSelected((SysCons.BITS_IDX_32 & archBits) != 0);
        // 16位
        this.ck_Ab16.setSelected((SysCons.BITS_IDX_16 & archBits) != 0);
        // 其它
        this.ck_Ab00.setSelected((SysCons.BITS_IDX_00 & archBits) != 0);
    }

    /**
     * 应用平台信息显示
     * 
     * @param platForm
     */
    public void setPlatForm(int platForm)
    {
        // 平台通用
        boolean b = SysCons.OS_IDX_ALL == platForm;
        this.ck_PfAll.setSelected(b);

        // Windows平台
        this.ck_PfWin.setSelected((SysCons.OS_IDX_WINDOWS & platForm) != 0);
        // Macintosh平台
        this.ck_PfMac.setSelected((SysCons.OS_IDX_MACINTOSH & platForm) != 0);
        // Unix平台
        this.ck_PfUnx.setSelected((SysCons.OS_IDX_UNIX & platForm) != 0);
        // Linux平台
        this.ck_PfLnx.setSelected((SysCons.OS_IDX_LINUX & platForm) != 0);
        // 移动平台
        this.ck_PfMbl.setSelected((SysCons.OS_IDX_MOBILE & platForm) != 0);
        // 其它平台
        this.ck_PfSpc.setSelected((SysCons.OS_IDX_UNKNOWN & platForm) != 0);

        setPlatFormEnabled(!b);
    }

    /**
     * @param enabled
     */
    private void setPlatFormEnabled(boolean enabled)
    {
        this.ck_PfWin.setEnabled(enabled);
        this.ck_PfMac.setEnabled(enabled);
        this.ck_PfUnx.setEnabled(enabled);
        this.ck_PfLnx.setEnabled(enabled);
        this.ck_PfMbl.setEnabled(enabled);
        this.ck_PfSpc.setEnabled(enabled);
    }

    /**
     * 平台通用复选框事件处理
     * 
     * @param evt
     */
    private void ck_PfAll_Handler(javax.swing.event.ChangeEvent evt)
    {
        boolean b = !this.ck_PfAll.isSelected();

        this.ck_PfWin.setEnabled(b);
        this.ck_PfMac.setEnabled(b);
        this.ck_PfUnx.setEnabled(b);
        this.ck_PfLnx.setEnabled(b);
        this.ck_PfMbl.setEnabled(b);
        this.ck_PfSpc.setEnabled(b);
    }

    protected javax.swing.JCheckBox  ck_Ab00;
    protected javax.swing.JCheckBox  ck_Ab16;
    protected javax.swing.JCheckBox  ck_Ab32;
    protected javax.swing.JCheckBox  ck_Ab64;
    protected javax.swing.JCheckBox  ck_PfAll;
    protected javax.swing.JCheckBox  ck_PfLnx;
    protected javax.swing.JCheckBox  ck_PfMac;
    protected javax.swing.JCheckBox  ck_PfMbl;
    protected javax.swing.JCheckBox  ck_PfSpc;
    protected javax.swing.JCheckBox  ck_PfUnx;
    protected javax.swing.JCheckBox  ck_PfWin;
    protected javax.swing.JLabel     lb_ArchBits;
    protected javax.swing.JLabel     lb_ExtsType;
    protected javax.swing.JLabel     lb_PlatForm;
    protected javax.swing.JTextField tf_ExtsType;

    protected WIconBox               ib_CorpIcon;
    protected WIconBox               ib_FileIcon;
    protected WIconBox               ib_IdioIcon;
    protected WIconBox               ib_SoftIcon;
}
