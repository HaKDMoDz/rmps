/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.info.C1010000.v;

import java.util.HashMap;

import rmp.comn.info.C1010000.C1010000;
import rmp.face.WBean;
import rmp.ui.form.FForm;
import rmp.ui.link.WLinkLabel;
import rmp.util.BeanUtil;
import cons.comn.info.C1010000.ConstUI;
import cons.comn.info.C1010000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class MiniPanel extends javax.swing.JPanel implements WBean
{
    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public MiniPanel(C1010000 soft)
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    /**
     * 显示关于信息
     */
    public void showInfo()
    {
        HashMap<String, String> propMap = C1010000.getInfoRes();
        String txt;
        String tip;
        String key;

        // 软件名称及版本
        txt = propMap.get(ConstUI.INFO_TITLE_TXT) + ' ' + propMap.get(ConstUI.INFO_VERSION_TXT);
        lt_SoftName.setText(txt);
        tip = propMap.get(ConstUI.INFO_TITLE_TIP) + ' ' + propMap.get(ConstUI.INFO_VERSION_TIP);
        lt_SoftName.setToolTipText(tip);

        // 说明信息
        txt = propMap.get(ConstUI.INFO_DESP_TXT);
        ta_DespInfo.setText(txt);
        tip = propMap.get(ConstUI.INFO_DESP_TIP);
        ta_DespInfo.setToolTipText(tip);

        // 软件版权
        txt = propMap.get(ConstUI.INFO_COPYRIGHT_TXT);
        lt_Copyright.setText(txt);
        tip = propMap.get(ConstUI.INFO_COPYRIGHT_TIP);
        lt_Copyright.setToolTipText(tip);

        // 说明信息
        txt = propMap.get(ConstUI.INFO_DESP_TXT);
        ta_DespInfo.setText(txt);
        tip = propMap.get(ConstUI.INFO_DESP_TIP);
        ta_DespInfo.setToolTipText(tip);

        // 软件首页
        // txt = propMap.get(ConstUI.INFO_HOMEPAGE_TXT);
        // lt_SoftSite.setText(txt);
        tip = propMap.get(ConstUI.INFO_HOMEPAGE_TIP);
        lt_SoftSite.setToolTipText(tip);
        key = propMap.get(ConstUI.INFO_HOMEPAGE_KEY);
        lt_SoftSite.setLinkUrl(key);

        // 电子邮件
        // txt = propMap.get(ConstUI.INFO_MAIL_TXT);
        // lt_SoteMail.setText(txt);
        tip = propMap.get(ConstUI.INFO_MAIL_TIP);
        lt_SoftMail.setToolTipText(tip);
        key = "mailto:" + propMap.get(ConstUI.INFO_MAIL_KEY);
        lt_SoftMail.setLinkUrl(key);
    }

    /**
     * 
     */
    private void ica()
    {
        lt_SoftName = new javax.swing.JLabel();
        lt_Copyright = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_DespInfo = new javax.swing.JScrollPane();
        ta_DespInfo = new javax.swing.JTextArea();
        lt_SoftMail = new WLinkLabel();
        lt_SoftMail.setAutoOpenLink(true);
        lt_SoftSite = new WLinkLabel();
        lt_SoftSite.setAutoOpenLink(true);
        javax.swing.JPanel p = new javax.swing.JPanel();
        bt_ExitButn = new javax.swing.JButton();

        lt_SoftName.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lt_SoftName.setText("软件名称及版本");

        lt_Copyright.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lt_Copyright.setText("版权所有 (C) 2007 Winshine");

        ta_DespInfo.setColumns(20);
        ta_DespInfo.setEditable(false);
        ta_DespInfo.setLineWrap(true);
        ta_DespInfo.setRows(3);
        sp_DespInfo.setViewportView(ta_DespInfo);

        lt_SoftMail.setText("电子邮件");

        lt_SoftSite.setText("软件首页");

        p.setLayout(new java.awt.FlowLayout(java.awt.FlowLayout.CENTER, 0, 0));

        bt_ExitButn.setText("确定");
        bt_ExitButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_ExitButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExitButn_Handler(evt);
            }
        });
        p.add(bt_ExitButn);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(p,
                javax.swing.GroupLayout.DEFAULT_SIZE, 220, Short.MAX_VALUE).addComponent(sp_DespInfo,
                javax.swing.GroupLayout.DEFAULT_SIZE, 220, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addComponent(lt_SoftSite).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_SoftMail)).addComponent(
                lt_SoftName, javax.swing.GroupLayout.DEFAULT_SIZE, 220, Short.MAX_VALUE).addComponent(lt_Copyright,
                javax.swing.GroupLayout.DEFAULT_SIZE, 220, Short.MAX_VALUE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(lt_SoftName).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_Copyright).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_DespInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lt_SoftMail).addComponent(lt_SoftSite)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(p,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWText(lt_SoftMail, C1010000.getMesg(LangRes.LABL_TEXT_SOFTMAIL));

        BeanUtil.setWText(lt_SoftSite, C1010000.getMesg(LangRes.LABL_TEXT_SOFTSITE));

        BeanUtil.setWText(bt_ExitButn, C1010000.getMesg(LangRes.BUTN_TEXT_EXITBUTN));
        BeanUtil.setWTips(bt_ExitButn, C1010000.getMesg(LangRes.BUTN_TIPS_EXITBUTN));
    }

    /**
     * @param evt
     */
    private void bt_ExitButn_Handler(java.awt.event.ActionEvent evt)
    {
        FForm fForm = (FForm) C1010000.getForm();
        fForm.setVisible(false);
        fForm.dispose();
    }
    private javax.swing.JButton bt_ExitButn;
    private javax.swing.JLabel lt_Copyright;
    private javax.swing.JLabel lt_SoftName;
    private WLinkLabel lt_SoftMail;
    private WLinkLabel lt_SoftSite;
    private javax.swing.JTextArea ta_DespInfo;
    /** serialVersionUID */
    private static final long serialVersionUID = 2192076797419381472L;
}
