/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.info.C1010000.v;

import rmp.comn.info.C1010000.C1010000;
import com.amonsoft.rmps.prp.IPrpPlus;
import rmp.ui.link.WLinkLabel;
import rmp.util.BeanUtil;
import cons.comn.info.C1010000.ConstUI;
import cons.comn.info.C1010000.LangRes;

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
public class TailPanel
{
    // private IPrpPlus soft;
    private javax.swing.JPanel tailPanel;

    /**
     * @param soft
     * @param view
     */
    public TailPanel(IPrpPlus soft, javax.swing.JPanel view)
    {
        // this.soft = soft;
        this.tailPanel = view;
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
     * 界面布局控制
     */
    private void ica()
    {
        final int GAPS = 6;
        java.awt.GridBagConstraints gbc;

        lb_DespInfo = new javax.swing.JLabel();
        ll_SoftSite = new WLinkLabel();
        ll_SoftMail = new WLinkLabel();

        tailPanel.setLayout(new java.awt.GridBagLayout());

        lb_DespInfo.setText("说明信息");
        gbc = new java.awt.GridBagConstraints();
        gbc.gridwidth = 2;
        gbc.fill = java.awt.GridBagConstraints.BOTH;
        gbc.weightx = 1.0;
        gbc.weighty = 1.0;
        gbc.insets = new java.awt.Insets(GAPS, GAPS, GAPS, GAPS);
        tailPanel.add(lb_DespInfo, gbc);

        ll_SoftSite.setText("软件首页");
        gbc = new java.awt.GridBagConstraints();
        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 0.5;
        gbc.insets = new java.awt.Insets(0, GAPS, GAPS, 0);
        tailPanel.add(ll_SoftSite, gbc);

        ll_SoftMail.setHorizontalAlignment(javax.swing.SwingConstants.TRAILING);
        ll_SoftMail.setText("电子邮件");
        gbc = new java.awt.GridBagConstraints();
        gbc.gridx = 1;
        gbc.gridy = 1;
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 0.5;
        gbc.insets = new java.awt.Insets(0, 0, GAPS, GAPS);
        tailPanel.add(ll_SoftMail, gbc);
    }

    /**
     * 界面语言显示
     */
    private void ita()
    {
        BeanUtil.setWText(lb_DespInfo, C1010000.getMesg(LangRes.LABL_TEXT_TAILINFO));

        BeanUtil.setWText(ll_SoftSite, C1010000.getMesg(LangRes.LABL_TEXT_SOFTSITE));
        BeanUtil.setWTips(ll_SoftSite, C1010000.getMesg(LangRes.LABL_TIPS_SOFTSITE));

        BeanUtil.setWText(ll_SoftMail, C1010000.getMesg(LangRes.LABL_TEXT_SOFTMAIL));
        BeanUtil.setWTips(ll_SoftMail, C1010000.getMesg(LangRes.LABL_TIPS_SOFTMAIL));

        ll_SoftSite.setAutoOpenLink(true);
        ll_SoftSite.setLinkUrl(ConstUI.URL_SOFT);

        ll_SoftMail.setAutoOpenLink(true);
        ll_SoftMail.setLinkUrl("mailto:" + ConstUI.URL_MAIL);
    }
    private javax.swing.JLabel lb_DespInfo;
    private WLinkLabel ll_SoftMail;
    private WLinkLabel ll_SoftSite;
}
