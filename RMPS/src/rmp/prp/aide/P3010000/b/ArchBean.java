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
public class ArchBean extends JPanel
{
    /**
     * 
     */
    public ArchBean()
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
        ck_Ab64 = new javax.swing.JCheckBox();
        ck_Ab32 = new javax.swing.JCheckBox();
        ck_Ab16 = new javax.swing.JCheckBox();
        ck_Ab00 = new javax.swing.JCheckBox();

        ck_Ab64.setMnemonic('3');
        ck_Ab64.setText("64\u4f4d(3)");
        ck_Ab64.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab64.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab32.setMnemonic('2');
        ck_Ab32.setSelected(true);
        ck_Ab32.setText("32\u4f4d(2)");
        ck_Ab32.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab32.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab16.setMnemonic('1');
        ck_Ab16.setText("16\u4f4d(1)");
        ck_Ab16.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab16.setMargin(new java.awt.Insets(0, 0, 0, 0));

        ck_Ab00.setMnemonic('0');
        ck_Ab00.setText("\u5176\u5b83(0)");
        ck_Ab00.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_Ab00.setMargin(new java.awt.Insets(0, 0, 0, 0));
    }

    private void ita()
    {
        // CPU 架构
        // BeanUtil.setWText(lb_ArchBits,
        // P3010000.getMesg(LangRes.MAIN_LABL_TEXT_ARCHBITS));
        // BeanUtil.setWTips(lb_ArchBits,
        // P3010000.getMesg(LangRes.MAIN_LABL_TIPS_ARCHBITS));

        // 64位
        BeanUtil.setWText(ck_Ab64, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_AB64));
        BeanUtil.setWTips(ck_Ab64, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_AB64));

        // 32位
        BeanUtil.setWText(ck_Ab32, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_AB32));
        BeanUtil.setWTips(ck_Ab32, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_AB32));

        // 16位
        BeanUtil.setWText(ck_Ab16, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_AB16));
        BeanUtil.setWTips(ck_Ab16, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_AB16));

        // 其它
        BeanUtil.setWText(ck_Ab00, P3010000.getMesg(LangRes.MAIN_CHCK_TEXT_AB00));
        BeanUtil.setWTips(ck_Ab00, P3010000.getMesg(LangRes.MAIN_CHCK_TIPS_AB00));
    }

    public void setDefault()
    {
        this.ck_Ab64.setSelected(false);
        this.ck_Ab32.setSelected(true);
        this.ck_Ab16.setSelected(false);
        this.ck_Ab00.setSelected(false);
    }

    /**
     * @param archBits
     */
    public void decodeArchBits(int archBits)
    {
    }

    /**
     * 系统架构
     */
    public int encodeArchBits()
    {
        int archBits = 0;

        // 64位
        if (this.ck_Ab64.isSelected())
        {
            archBits |= SysCons.BITS_IDX_64;
        }

        // 32位
        if (this.ck_Ab32.isSelected())
        {
            archBits |= SysCons.BITS_IDX_32;
        }

        // 16位
        if (this.ck_Ab16.isSelected())
        {
            archBits |= SysCons.BITS_IDX_16;
        }

        // 其它
        if (this.ck_Ab00.isSelected())
        {
            archBits |= SysCons.BITS_IDX_00;
        }

        return archBits;
    }
    private javax.swing.JCheckBox ck_Ab00;
    private javax.swing.JCheckBox ck_Ab16;
    private javax.swing.JCheckBox ck_Ab32;
    private javax.swing.JCheckBox ck_Ab64;
    /** serialVersionUID */
    private static final long serialVersionUID = -1323939643260023016L;
}
