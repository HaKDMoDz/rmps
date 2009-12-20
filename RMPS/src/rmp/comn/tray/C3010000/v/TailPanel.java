/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.tray.C3010000.v;

import java.awt.FlowLayout;

import rmp.comn.tray.C3010000.C3010000;
import rmp.comn.tray.C3010000.t.Util;
import cons.comn.tray.C3010000.ConstUI;
import cons.comn.tray.C3010000.LangRes;
import rmp.Rmps;

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
    private C3010000 ms_MainSoft;
    private javax.swing.JPanel tp_TailPanel;

    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(C3010000 soft, javax.swing.JPanel tailPanel)
    {
        this.ms_MainSoft = soft;
        this.tp_TailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        if (!Util.isTraySupport())
        {
            ica();
            ita();
        }
        else
        {
            icb();
            itb();
        }

        return true;
    }

    /**
     * 不支持系统托盘时的界面布局初始化
     */
    private void ica()
    {
        tp_TailPanel.setLayout(new FlowLayout());
        javax.swing.JLabel l = new javax.swing.JLabel();
        l.setText("您系统不提供托盘支持！");
        tp_TailPanel.add(l);
    }

    /**
     * 支持系统托盘时的界面布局初始化
     */
    private void icb()
    {
        java.awt.GridBagConstraints gbc = new java.awt.GridBagConstraints();

        tf_TrayTips = new javax.swing.JTextField();
        bt_TrayTips = new javax.swing.JButton();

        tp_TailPanel.setLayout(new java.awt.GridBagLayout());

        tf_TrayTips.setToolTipText("系统托盘提示内容");
        tf_TrayTips.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_TrayTips_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;
        gbc.insets = new java.awt.Insets(5, 5, 5, 5);
        tp_TailPanel.add(tf_TrayTips, gbc);

        bt_TrayTips.setMnemonic('U');
        bt_TrayTips.setText("更新(U)");
        bt_TrayTips.setToolTipText("更新系统托盘提示");
        bt_TrayTips.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_TrayTips.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_TrayTips_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.NONE;
        gbc.weightx = 0.0;
        gbc.insets = new java.awt.Insets(5, 0, 5, 5);
        tp_TailPanel.add(bt_TrayTips, gbc);
    }

    /**
     * 不支持系统托盘时的界面语言初始化
     */
    private void ita()
    {
    }

    /**
     * 支持系统托盘时的界面语言初始化
     */
    private void itb()
    {
    }

    /**
     * 文本框事件处理
     * 
     * @param evt
     */
    private void tf_TrayTips_Handler(java.awt.event.ActionEvent evt)
    {
        changeDisplayMessage();
    }

    /**
     * 按钮事件处理
     * 
     * @param evt
     */
    private void bt_TrayTips_Handler(java.awt.event.ActionEvent evt)
    {
        changeDisplayMessage();
    }

    /**
     * 改变系统托盘提示信息
     */
    private void changeDisplayMessage()
    {
        String mesg = tf_TrayTips.getText().trim();
        ms_MainSoft.displayMessage(LangRes.TITLE_MESSAGE_CHANGE, mesg, java.awt.TrayIcon.MessageType.INFO);
        ms_MainSoft.changeTooltips(mesg);
        Rmps.getUser().setCfg(ConstUI.CFG_USERMESG, mesg.length() > 0 ? mesg : LangRes.TRAY_TIPS_ICONTRAY);
    }
    /** 查询按钮 */
    private javax.swing.JButton bt_TrayTips;
    /** 用户输入文本框 */
    private javax.swing.JTextField tf_TrayTips;
}
