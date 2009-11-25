/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import javax.swing.JPanel;

import rmp.prp.aide.P3010000.P3010000;
import rmp.util.BeanUtil;
import cons.SysCons;
import cons.prp.aide.P3010000.LangRes;

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
public class PlatBean extends JPanel
{
    /**
     * 
     */
    public PlatBean()
    {
    }

    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    private void ica()
    {
        ck_PfAll = new javax.swing.JCheckBox();
        ck_PfWin = new javax.swing.JCheckBox();
        ck_PfMac = new javax.swing.JCheckBox();
        ck_PfUnx = new javax.swing.JCheckBox();
        ck_PfLnx = new javax.swing.JCheckBox();
        ck_PfMbl = new javax.swing.JCheckBox();
        ck_PfSpc = new javax.swing.JCheckBox();

        ck_PfAll.setMnemonic('G');
        ck_PfAll.setSelected(true);
        ck_PfAll.setText("\u5e73\u53f0\u901a\u7528(G)");
        ck_PfAll.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfAll.setMargin(new java.awt.Insets(0, 0, 0, 0));
        ck_PfAll.addChangeListener(new javax.swing.event.ChangeListener()
        {
            public void stateChanged(javax.swing.event.ChangeEvent evt)
            {
                ck_PfAll_Handler(evt);
            }
        });

        ck_PfWin.setMnemonic('W');
        ck_PfWin.setText("Windows(W)");
        ck_PfWin.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfWin.setDisplayedMnemonicIndex(8);
        ck_PfWin.setEnabled(false);
        ck_PfWin.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMac.setMnemonic('M');
        ck_PfMac.setText("Macintosh(M)");
        ck_PfMac.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMac.setDisplayedMnemonicIndex(10);
        ck_PfMac.setEnabled(false);
        ck_PfMac.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfUnx.setMnemonic('U');
        ck_PfUnx.setText("Unix(U)");
        ck_PfUnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfUnx.setDisplayedMnemonicIndex(5);
        ck_PfUnx.setEnabled(false);
        ck_PfUnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfLnx.setMnemonic('L');
        ck_PfLnx.setText("Linux(L)");
        ck_PfLnx.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfLnx.setDisplayedMnemonicIndex(6);
        ck_PfLnx.setEnabled(false);
        ck_PfLnx.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfMbl.setMnemonic('B');
        ck_PfMbl.setText("\u79fb\u52a8\u5e73\u53f0(B)");
        ck_PfMbl.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfMbl.setEnabled(false);
        ck_PfMbl.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_PfSpc.setMnemonic('O');
        ck_PfSpc.setText("\u5176\u5b83\u5e73\u53f0(O)");
        ck_PfSpc.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_PfSpc.setEnabled(false);
        ck_PfSpc.setMargin(new java.awt.Insets(0, 0, 0, 0));
    }

    private void ita()
    {
        // 应用平台
        // BeanUtil.setWText(lb_PlatForm,
        // P3010000.getMesg(LangRes.MAIN_LABL_TEXT_PLATFORM));
        // BeanUtil.setWTips(lb_PlatForm,
        // P3010000.getMesg(LangRes.MAIN_LABL_TIPS_PLATFORM));

        // 平台通用
        BeanUtil.setWText(ck_PfAll, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFALL));
        BeanUtil.setWTips(ck_PfAll, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFALL));

        // 平台通用
        BeanUtil.setWText(ck_PfAll, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFALL));
        BeanUtil.setWTips(ck_PfAll, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFALL));

        // Windows
        BeanUtil.setWText(ck_PfWin, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFWIN));
        BeanUtil.setWTips(ck_PfWin, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFWIN));

        // Macintosh
        BeanUtil.setWText(ck_PfMac, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFMAC));
        BeanUtil.setWTips(ck_PfMac, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFMAC));

        // Unix
        BeanUtil.setWText(ck_PfUnx, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFUNX));
        BeanUtil.setWTips(ck_PfUnx, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFUNX));

        // Linux
        BeanUtil.setWText(ck_PfLnx, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFLNX));
        BeanUtil.setWTips(ck_PfLnx, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFLNX));

        // 移动平台
        BeanUtil.setWText(ck_PfMbl, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFMBL));
        BeanUtil.setWTips(ck_PfMbl, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFMBL));

        // 其它平台
        BeanUtil.setWText(ck_PfSpc, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_PFSPC));
        BeanUtil.setWTips(ck_PfSpc, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_PFSPC));
    }

    /**
     * @param all
     */
    public void setDefault()
    {
        this.ck_PfAll.setSelected(true);

        setPlatForm(false);
    }

    /**
     * @param platForm
     */
    public void decodePlatForm(int platForm)
    {
    }

    /**
     * @return
     */
    public int encodePlatForm()
    {
        // 平台通用
        if (this.ck_PfAll.isSelected())
        {
            return SysCons.OS_IDX_ALL;
        }

        int platForm = 0;

        // Windows
        if (this.ck_PfWin.isSelected())
        {
            platForm |= SysCons.OS_IDX_WINDOWS;
        }

        // Macintosh
        if (this.ck_PfMac.isSelected())
        {
            platForm |= SysCons.OS_IDX_MACINTOSH;
        }

        // Unix
        if (this.ck_PfUnx.isSelected())
        {
            platForm |= SysCons.OS_IDX_UNIX;
        }

        // Linux
        if (this.ck_PfLnx.isSelected())
        {
            platForm |= SysCons.OS_IDX_LINUX;
        }

        // 移动平台
        if (this.ck_PfMbl.isSelected())
        {
            platForm |= SysCons.OS_IDX_MOBILE;
        }

        // 其它平台
        if (this.ck_PfSpc.isSelected())
        {
            platForm |= SysCons.OS_IDX_UNKNOWN;
        }

        return platForm;
    }

    /**
     * @param evt
     */
    private void ck_PfAll_Handler(javax.swing.event.ChangeEvent evt)
    {
        setPlatForm(ck_PfAll.isSelected());
    }

    /**
     * @param all
     */
    private void setPlatForm(boolean all)
    {
        all = !all;

        this.ck_PfWin.setEnabled(all);
        this.ck_PfMac.setEnabled(all);
        this.ck_PfUnx.setEnabled(all);
        this.ck_PfLnx.setEnabled(all);
        this.ck_PfMbl.setEnabled(all);
        this.ck_PfSpc.setEnabled(all);
    }
    private javax.swing.JCheckBox ck_PfAll;
    private javax.swing.JCheckBox ck_PfLnx;
    private javax.swing.JCheckBox ck_PfMac;
    private javax.swing.JCheckBox ck_PfMbl;
    private javax.swing.JCheckBox ck_PfSpc;
    private javax.swing.JCheckBox ck_PfUnx;
    private javax.swing.JCheckBox ck_PfWin;
    /**  */
    private static final long serialVersionUID = 7668064810437669045L;
}
