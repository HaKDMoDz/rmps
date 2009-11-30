/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.info.C1010000.v;

import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.imageio.ImageIO;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JTextArea;

import rmp.face.WBean;
import rmp.ui.icon.WIconLabel;
import rmp.ui.link.WLinkLabel;
import rmp.util.CheckUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import cons.comn.info.C1010000.ConstUI;
import rmp.util.DeskUtil;

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
public class Style001 extends javax.swing.JPanel implements WBean
{
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();

        return true;
    }

    /**
     * 读取软件信息
     * 
     * @param infoFile
     */
    public void readInfo(File infoFile)
    {
        if (infoFile == null || !infoFile.exists() || !infoFile.canRead())
        {
            return;
        }

        // 读取文件信息
        try
        {

            BufferedReader br = FileUtil.getReader(infoFile, "UTF-8");
            StringBuffer sb = new StringBuffer();

            String text;
            while (true)
            {
                // 读取一行信息,并显示
                text = br.readLine();
                if (!CheckUtil.isValidate(text))
                {
                    break;
                }

                // 信息标记判断
                int spIndx = text.indexOf('=');
                if (spIndx < 0)
                {
                    continue;
                }

                String idStr = text.substring(0, spIndx);
                // 软件名称判断
                if (ConstUI.INFO_TITLE_TXT.equalsIgnoreCase(idStr))
                {
                    lb_SoftName.setText(text.substring(spIndx + 1));
                    continue;
                }
                // 软件版本判断
                if (ConstUI.INFO_VERSION_TXT.equalsIgnoreCase(idStr))
                {
                    lb_SoftEdit.setText(text.substring(spIndx + 1));
                    continue;
                }
                // 邮件判断
                if (ConstUI.INFO_MAIL_TXT.equalsIgnoreCase(idStr))
                {
                    ll_SoftMail.setText(text.substring(spIndx + 1));
                    continue;
                }
                // 邮件地址
                if (ConstUI.INFO_MAIL_SUB.equals(idStr))
                {
                    ll_SoftMail.setLinkUrl(text.substring(spIndx + 1));
                    continue;
                }
                // 网站判断
                if (ConstUI.INFO_HOMEPAGE_TXT.equalsIgnoreCase(idStr))
                {
                    ll_SoftSite.setText(text.substring(spIndx + 1));
                    continue;
                }
                // 网站地址:
                if (ConstUI.INFO_HOMEPAGE_KEY.equals(idStr))
                {
                    ll_SoftSite.setLinkUrl(text.substring(spIndx + 1));
                    continue;
                }
                // 信息描述
                if (ConstUI.INFO_DESP_TXT.equalsIgnoreCase(idStr))
                {
                    sb.append(text.substring(spIndx + 1)).append("\n");
                    continue;
                }
            }

            ta_SoftInfo.setText(sb.toString());
            sb = null;

            // 关闭输入流
            br.close();
        }
        catch (IOException ioe)
        {
            LogUtil.exception(ioe);
        }
    }

    /**
     * 读取软件图标
     * 
     * @param iconFile
     */
    public void readIcon(File iconFile)
    {
        try
        {
            // 获取徽标文件路径
            FileInputStream fis = new FileInputStream(iconFile);

            // 读取徽标图像并显示
            BufferedImage logoImg = ImageIO.read(fis);
            fis.close();

            il_SoftLogo.setBackgroundImage(logoImg);
        }
        catch (IOException ioe)
        {
            LogUtil.exception(ioe);
        }
    }

    /**
     * 
     */
    private void ica()
    {
        javax.swing.JLabel lt_SoftName = new javax.swing.JLabel();
        lb_SoftName = new javax.swing.JLabel();
        javax.swing.JLabel lt_SoftEdit = new javax.swing.JLabel();
        lb_SoftEdit = new javax.swing.JLabel();
        javax.swing.JLabel lt_SoftMail = new javax.swing.JLabel();
        ll_SoftMail = new rmp.ui.link.WLinkLabel();
        javax.swing.JLabel lt_SoftSite = new javax.swing.JLabel();
        ll_SoftSite = new rmp.ui.link.WLinkLabel();
        javax.swing.JScrollPane sp_SoftInfo = new javax.swing.JScrollPane();
        ta_SoftInfo = new javax.swing.JTextArea();
        bt_ExitButn = new javax.swing.JButton();
        il_SoftLogo = new rmp.ui.icon.WIconLabel();

        lt_SoftName.setText("\u8f6f\u4ef6\u540d\u79f0");

        lb_SoftName.setText("\u540e\u7f00\u89e3\u6790");

        lt_SoftEdit.setText("\u53d1\u884c\u7248\u672c");

        lb_SoftEdit.setText("V2.1.1.3 Build 2007-07-22");

        lt_SoftMail.setText("\u7535\u5b50\u90ae\u4ef6");

        ll_SoftMail.setText("Amon.CT@163.com");
        ll_SoftMail.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ll_SoftMail_Handler(evt);
            }
        });

        lt_SoftSite.setText("\u8f6f\u4ef6\u9996\u9875");

        ll_SoftSite.setText("http://www.amonsoft.cn");
        ll_SoftSite.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ll_SoftSite_Handler(evt);
            }
        });

        ta_SoftInfo.setColumns(20);
        ta_SoftInfo.setEditable(false);
        ta_SoftInfo.setLineWrap(true);
        ta_SoftInfo.setRows(5);
        sp_SoftInfo.setViewportView(ta_SoftInfo);

        bt_ExitButn.setMnemonic('O');
        bt_ExitButn.setText("\u786e\u5b9a(O)");
        bt_ExitButn.setToolTipText("\u5173\u95ed\u7a97\u53e3");
        bt_ExitButn.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_ExitButn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ExitButn_Handler(evt);
            }
        });

        il_SoftLogo.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        il_SoftLogo.setBorder(javax.swing.BorderFactory.createEtchedBorder());
        il_SoftLogo.setPreferredSize(new java.awt.Dimension(50, 50));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp_SoftInfo,
                javax.swing.GroupLayout.DEFAULT_SIZE, 323, Short.MAX_VALUE).addComponent(bt_ExitButn,
                javax.swing.GroupLayout.Alignment.TRAILING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(lt_SoftName).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(lb_SoftName)).addGroup(
                layout.createSequentialGroup().addComponent(lt_SoftEdit).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(lb_SoftEdit)).addGroup(
                layout.createSequentialGroup().addComponent(lt_SoftMail).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(ll_SoftMail)).addGroup(
                layout.createSequentialGroup().addComponent(lt_SoftSite).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(ll_SoftSite))).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 53, Short.MAX_VALUE).addComponent(il_SoftLogo, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lt_SoftName).addComponent(lb_SoftName)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lt_SoftEdit).addComponent(lb_SoftEdit)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lt_SoftMail).addComponent(ll_SoftMail)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lt_SoftSite).addComponent(ll_SoftSite))).addComponent(il_SoftLogo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_SoftInfo,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addComponent(bt_ExitButn).addContainerGap()));
    }

    /**
     * 确定按钮事件处理
     * 
     * @param evt
     */
    private void bt_ExitButn_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * 电子邮件事件处理
     */
    private void ll_SoftMail_Handler(java.awt.event.MouseEvent evt)
    {
        try
        {
            DeskUtil.mail(ll_SoftMail.getLinkUrl());
        }
        catch (Exception ex)
        {
            Logger.getLogger(Style001.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * 访问网站地址事件处理
     */
    private void ll_SoftSite_Handler(java.awt.event.MouseEvent evt)
    {
        try
        {
            DeskUtil.browse(ll_SoftSite.getLinkUrl());
        }
        catch (Exception ex)
        {
            Logger.getLogger(Style001.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    /** 关闭窗口按钮 */
    private JButton bt_ExitButn;
    /** 版本版本 */
    private JLabel lb_SoftEdit;
    /** 软件名称 */
    private JLabel lb_SoftName;
    /** 关于信息显示文本区域 */
    private JTextArea ta_SoftInfo;
    /** 软件徽标 */
    private WIconLabel il_SoftLogo;
    /** 邮件 */
    private WLinkLabel ll_SoftMail;
    /** 网站 */
    private WLinkLabel ll_SoftSite;
    /** serialVersionUID */
    private static final long serialVersionUID = 3279492119651720521L;
}
