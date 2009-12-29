/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.C1010000.v;

import java.io.FileInputStream;
import java.util.HashMap;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;

import rmp.comn.C1010000.C1010000;
import rmp.face.WBean;
import rmp.ui.link.WLinkLabel;
import rmp.util.LogUtil;


import cons.comn.info.C1010000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 关于软件
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Style002 extends javax.swing.JPanel implements WBean
{
    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public Style002(C1010000 soft)
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

        // 软件名称
        txt = propMap.get(ConstUI.INFO_TITLE_TXT);
        lt_SoftName.setText(txt);
        tip = propMap.get(ConstUI.INFO_TITLE_TIP);
        lt_SoftName.setToolTipText(tip);

        // 发行版本
        txt = propMap.get(ConstUI.INFO_VERSION_TXT) + ' ' + propMap.get(ConstUI.INFO_BUILD_TXT);
        lt_SoftEdit.setText(txt);
        tip = propMap.get(ConstUI.INFO_VERSION_TIP) + ' ' + propMap.get(ConstUI.INFO_BUILD_TIP);
        lt_SoftEdit.setToolTipText(tip);

        // 软件作者
        txt = propMap.get(ConstUI.INFO_VENDOR_TXT);
        lt_SoftMail.setText(txt);
        tip = propMap.get(ConstUI.INFO_VENDOR_TIP);
        lt_SoftMail.setToolTipText(tip);
        key = "mailto:" + propMap.get(ConstUI.INFO_MAIL_KEY);
        lt_SoftMail.setLinkUrl(key);

        // 说明信息
        txt = propMap.get(ConstUI.INFO_DESP_TXT);
        ta_DespInfo.setText(txt);
        tip = propMap.get(ConstUI.INFO_DESP_TIP);
        ta_DespInfo.setToolTipText(tip);

        // 软件首页
        txt = propMap.get(ConstUI.INFO_HOMEPAGE_TXT);
        lt_SoftSite.setText(txt);
        tip = propMap.get(ConstUI.INFO_HOMEPAGE_TIP);
        lt_SoftSite.setToolTipText(tip);
        key = propMap.get(ConstUI.INFO_HOMEPAGE_KEY);
        lt_SoftSite.setLinkUrl(key);

        try
        {
            txt = propMap.get(ConstUI.INFO_LOGO30_PATH);
            FileInputStream fis = new FileInputStream(txt);
            lt_SoftLogo.setIcon(new ImageIcon(ImageIO.read(fis)));
            fis.close();
            tip = propMap.get(ConstUI.INFO_LOGO30_PATH);
            lt_SoftLogo.setToolTipText(tip);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * 
     */
    private void ica()
    {
        lb_SoftName = new javax.swing.JLabel();
        lt_SoftName = new javax.swing.JLabel();
        javax.swing.JPanel pl_SoftIcon = new javax.swing.JPanel();
        lt_SoftLogo = new javax.swing.JLabel();
        lb_SoftEdit = new javax.swing.JLabel();
        lt_SoftEdit = new javax.swing.JLabel();
        lb_SoftMail = new javax.swing.JLabel();
        lt_SoftMail = new WLinkLabel();
        lb_SoftSite = new javax.swing.JLabel();
        lt_SoftSite = new WLinkLabel();
        javax.swing.JScrollPane sp_DespInfo = new javax.swing.JScrollPane();
        ta_DespInfo = new javax.swing.JTextArea();
        bt_ExitButn = new javax.swing.JButton();

        lb_SoftName.setText("\u8f6f\u4ef6\u540d\u79f0");

        lt_SoftName.setText("\u5173\u4e8e\u8f6f\u4ef6");

        lt_SoftLogo.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        lt_SoftLogo.setPreferredSize(new java.awt.Dimension(42, 42));
        pl_SoftIcon.add(lt_SoftLogo);

        lb_SoftEdit.setText("\u53d1\u884c\u7248\u672c");

        lt_SoftEdit.setText("V1.0.0.0 Build 2008-01-01");

        lb_SoftMail.setText("\u7535\u5b50\u90ae\u4ef6");

        lt_SoftMail.setText("Amon.CT@163.com");

        lb_SoftSite.setText("\u8f6f\u4ef6\u9996\u9875");

        lt_SoftSite.setText("http://www.amonsoft.cn/");

        ta_DespInfo.setColumns(20);
        ta_DespInfo.setEditable(false);
        ta_DespInfo.setLineWrap(true);
        ta_DespInfo.setRows(3);
        sp_DespInfo.setViewportView(ta_DespInfo);

        bt_ExitButn.setMnemonic('O');
        bt_ExitButn.setText("\u786e\u5b9a(O)");
        bt_ExitButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_ExitButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExitButn_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SoftName).addComponent(lb_SoftEdit).addComponent(lb_SoftMail).addComponent(lb_SoftSite))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                        layout.createSequentialGroup().addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lt_SoftName).addComponent(lt_SoftEdit).addComponent(lt_SoftMail))
                                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 27, Short.MAX_VALUE).addComponent(pl_SoftIcon,
                                                        javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addComponent(lt_SoftSite)).addContainerGap()).addGroup(javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(232, Short.MAX_VALUE).addComponent(bt_ExitButn).addGap(10, 10, 10)).addGroup(
                layout.createSequentialGroup().addGap(10, 10, 10).addComponent(sp_DespInfo, javax.swing.GroupLayout.DEFAULT_SIZE, 281, Short.MAX_VALUE).addContainerGap(12, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                layout.createSequentialGroup().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftName).addComponent(lt_SoftName))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftEdit).addComponent(lt_SoftEdit)).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftMail).addComponent(lt_SoftMail))).addComponent(pl_SoftIcon,
                                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftSite).addComponent(lt_SoftSite)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_DespInfo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                        javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(bt_ExitButn).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 确定按钮事件处理
     * 
     * @param evt
     */
    private void bt_ExitButn_Handler(java.awt.event.ActionEvent evt)
    {
        // FForm fForm = (FForm) C1010000.getForm();
        // fForm.setVisible(false);
        // fForm.dispose();
    }

    private javax.swing.JButton bt_ExitButn;
    private javax.swing.JLabel lb_SoftEdit;
    private javax.swing.JLabel lt_SoftLogo;
    private javax.swing.JLabel lb_SoftMail;
    private javax.swing.JLabel lb_SoftName;
    private javax.swing.JLabel lb_SoftSite;
    private javax.swing.JLabel lt_SoftEdit;
    private WLinkLabel lt_SoftMail;
    private javax.swing.JLabel lt_SoftName;
    private WLinkLabel lt_SoftSite;
    private javax.swing.JTextArea ta_DespInfo;
}
