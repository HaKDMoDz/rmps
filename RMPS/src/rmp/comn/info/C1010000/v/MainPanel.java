/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.info.C1010000.v;

import java.io.File;
import java.io.FileInputStream;
import java.util.HashMap;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;

import rmp.comn.info.C1010000.C1010000;
import rmp.face.WBean;
import rmp.ui.link.WLinkLabel;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import com.amonsoft.util.LogUtil;
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
public class MainPanel extends javax.swing.JPanel implements WBean
{
    private C1010000 me_MainSoft;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     */
    public MainPanel(C1010000 soft)
    {
        this.me_MainSoft = soft;
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

        // 软件版权
        txt = propMap.get(ConstUI.INFO_COPYRIGHT_TXT);
        lt_Copyright.setText(txt);
        tip = propMap.get(ConstUI.INFO_COPYRIGHT_TIP);
        lt_Copyright.setToolTipText(tip);

        // 软件首页
        txt = propMap.get(ConstUI.INFO_HOMEPAGE_TXT);
        lt_SoftSite.setText(txt);
        tip = propMap.get(ConstUI.INFO_HOMEPAGE_TIP);
        lt_SoftSite.setToolTipText(tip);
        key = propMap.get(ConstUI.INFO_HOMEPAGE_KEY);
        lt_SoftSite.setLinkUrl(key);

        try
        {
            tip = propMap.get(ConstUI.INFO_LOGO00_TIPS);
            lt_SoftLogo.setToolTipText(tip);
            txt = propMap.get(ConstUI.INFO_LOGO00_PATH);
            if (CheckUtil.isValidate(txt))
            {
                LogUtil.log("图标资源：" + txt);
                File file;
                char c = txt.charAt(0);
                // 相对根目录
                if (c == '$')
                {
                    file = new File(txt.substring(2));
                }
                // 相对软件目录
                else if (c == '#')
                {
                    file = new File(me_MainSoft.wGetPlusFolder(), txt.substring(2));
                }
                // 绝对路径目录
                else
                {
                    file = new File(txt);
                }
                LogUtil.log("图标读取：" + file.getPath());
                if (file.exists() && file.isFile() && file.canRead())
                {
                    FileInputStream fis = new FileInputStream(file);
                    lt_SoftLogo.setIcon(new ImageIcon(ImageIO.read(fis)));
                    fis.close();
                }
            }
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
        lt_SoftLogo = new javax.swing.JLabel();
        lb_SoftName = new javax.swing.JLabel();
        lt_SoftName = new javax.swing.JLabel();
        lb_SoftEdit = new javax.swing.JLabel();
        lt_SoftEdit = new javax.swing.JLabel();
        lb_SoftMail = new javax.swing.JLabel();
        lt_SoftMail = new WLinkLabel();
        lt_SoftMail.setAutoOpenLink(true);
        javax.swing.JScrollPane sp_DespInfo = new javax.swing.JScrollPane();
        ta_DespInfo = new javax.swing.JTextArea();
        lt_Copyright = new javax.swing.JLabel();
        lt_SoftSite = new WLinkLabel();
        lt_SoftSite.setAutoOpenLink(true);
        bt_ExitButn = new javax.swing.JButton();

        lt_SoftLogo.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        lt_SoftLogo.setHorizontalAlignment(javax.swing.JLabel.CENTER);

        lb_SoftName.setText("\u8f6f\u4ef6\u540d\u79f0");

        lt_SoftName.setText("PRP");

        lb_SoftEdit.setText("\u53d1\u884c\u7248\u672c");

        lt_SoftEdit.setText("V1.1.0.0 Build20080101");

        lb_SoftMail.setText("\u8f6f\u4ef6\u4f5c\u8005");

        lt_SoftMail.setText("Amon");

        ta_DespInfo.setColumns(20);
        ta_DespInfo.setEditable(false);
        ta_DespInfo.setLineWrap(true);
        ta_DespInfo.setRows(4);
        sp_DespInfo.setViewportView(ta_DespInfo);

        lt_Copyright.setText("Copyright (C) 2007 Winshine");

        lt_SoftSite.setText("http://www.amonsoft.cn/");

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
                layout.createSequentialGroup().addContainerGap().addComponent(lt_SoftLogo,
                javax.swing.GroupLayout.PREFERRED_SIZE, 104, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SoftName).addComponent(lb_SoftEdit).addComponent(lb_SoftMail)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lt_SoftName).addComponent(lt_SoftEdit).addComponent(lt_SoftMail)).addContainerGap()).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addContainerGap(289, Short.MAX_VALUE).addComponent(bt_ExitButn).addGap(10,
                10, 10)).addGroup(
                layout.createSequentialGroup().addGap(120, 120, 120).addComponent(lt_SoftSite).addContainerGap(102,
                Short.MAX_VALUE)).addGroup(
                layout.createSequentialGroup().addGap(120, 120, 120).addComponent(lt_Copyright).addContainerGap(78,
                Short.MAX_VALUE)).addGroup(
                layout.createSequentialGroup().addGap(120, 120, 120).addComponent(sp_DespInfo,
                javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE).addContainerGap(10, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftName).addComponent(lt_SoftName)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftEdit).addComponent(lt_SoftEdit)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SoftMail).addComponent(lt_SoftMail)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_DespInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_Copyright).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lt_SoftSite).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addComponent(bt_ExitButn)).addComponent(lt_SoftLogo,
                javax.swing.GroupLayout.DEFAULT_SIZE, 218, Short.MAX_VALUE)).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        BeanUtil.setWTips(lt_SoftLogo, C1010000.getMesg(LangRes.LABL_TIPS_SOFTLOGO));

        BeanUtil.setWText(lb_SoftName, C1010000.getMesg(LangRes.LABL_TEXT_SOFTNAME));
        BeanUtil.setWTips(lb_SoftName, C1010000.getMesg(LangRes.LABL_TIPS_SOFTNAME));

        BeanUtil.setWText(lb_SoftEdit, C1010000.getMesg(LangRes.LABL_TEXT_SOFTEDIT));
        BeanUtil.setWTips(lb_SoftEdit, C1010000.getMesg(LangRes.LABL_TIPS_SOFTEDIT));

        BeanUtil.setWText(lb_SoftMail, C1010000.getMesg(LangRes.LABL_TEXT_SOFTCOPY));
        BeanUtil.setWTips(lb_SoftMail, C1010000.getMesg(LangRes.LABL_TIPS_SOFTCOPY));

        BeanUtil.setWText(ta_DespInfo, C1010000.getMesg(LangRes.AREA_TEXT_SOFTDESP));
        BeanUtil.setWTips(ta_DespInfo, C1010000.getMesg(LangRes.AREA_TIPS_SOFTDESP));

        BeanUtil.setWText(ta_DespInfo, C1010000.getMesg(LangRes.AREA_TEXT_SOFTDESP));
        BeanUtil.setWTips(ta_DespInfo, C1010000.getMesg(LangRes.AREA_TIPS_SOFTDESP));

        BeanUtil.setWText(ta_DespInfo, C1010000.getMesg(LangRes.AREA_TEXT_SOFTDESP));
        BeanUtil.setWTips(ta_DespInfo, C1010000.getMesg(LangRes.AREA_TIPS_SOFTDESP));

        BeanUtil.setWText(bt_ExitButn, C1010000.getMesg(LangRes.BUTN_TEXT_EXITBUTN));
        BeanUtil.setWTips(bt_ExitButn, C1010000.getMesg(LangRes.BUTN_TIPS_EXITBUTN));
    }

    /**
     * @param evt
     */
    private void bt_ExitButn_Handler(java.awt.event.ActionEvent evt)
    {
//        FForm fForm = (FForm) C1010000.getForm();
//        fForm.setVisible(false);
//        fForm.dispose();
    }
    private javax.swing.JButton bt_ExitButn;
    private javax.swing.JLabel lb_SoftEdit;
    private javax.swing.JLabel lt_SoftLogo;
    private javax.swing.JLabel lb_SoftMail;
    private javax.swing.JLabel lb_SoftName;
    private javax.swing.JLabel lt_SoftEdit;
    private javax.swing.JLabel lt_SoftName;
    private javax.swing.JLabel lt_Copyright;
    private javax.swing.JTextArea ta_DespInfo;
    private WLinkLabel lt_SoftMail;
    private WLinkLabel lt_SoftSite;
}
