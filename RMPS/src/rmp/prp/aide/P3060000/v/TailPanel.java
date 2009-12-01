/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.v;

import rmp.prp.aide.P3060000.P3060000;
import rmp.prp.aide.P3060000.t.Util;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import com.amonsoft.util.LogUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P3060000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class TailPanel
{
    private javax.swing.JPanel pl_TailPanel;

    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P3060000 soft, javax.swing.JPanel tailPanel)
    {
        this.pl_TailPanel = tailPanel;
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
     * 界面初始化
     */
    private void ica()
    {
        java.awt.GridBagConstraints gbc = new java.awt.GridBagConstraints();

        tf_UserExps = new javax.swing.JTextField();
        bt_ButnExec = new javax.swing.JButton();

        pl_TailPanel.setLayout(new java.awt.GridBagLayout());

        tf_UserExps.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_UserExps_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;
        gbc.insets = new java.awt.Insets(5, 5, 5, 5);
        pl_TailPanel.add(tf_UserExps, gbc);

        bt_ButnExec.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_ButnExec.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_ButnExec_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.NONE;
        gbc.weightx = 0.0;
        gbc.insets = new java.awt.Insets(5, 0, 5, 5);
        pl_TailPanel.add(bt_ButnExec, gbc);
    }

    /**
     * 语言初始化
     */
    private void ita()
    {
        BeanUtil.setWText(tf_UserExps, P3060000.getMesg(LangRes.P3064401));
        BeanUtil.setWTips(tf_UserExps, P3060000.getMesg(LangRes.P3064402));

        BeanUtil.setWText(bt_ButnExec, P3060000.getMesg(LangRes.P3064501));
        BeanUtil.setWTips(bt_ButnExec, P3060000.getMesg(LangRes.P3064502));
    }

    /**
     * 表达式文本框事件处理
     * 
     * @param evt
     */
    private void tf_UserExps_Handler(java.awt.event.ActionEvent evt)
    {
        doCalculate();
    }

    /**
     * 计算按钮事件处理
     * 
     * @param evt
     */
    private void bt_ButnExec_Handler(java.awt.event.ActionEvent evt)
    {
        doCalculate();
    }

    /**
     * 用户表达式计算
     */
    private void doCalculate()
    {
        String t = tf_UserExps.getText().trim();
        if (!CheckUtil.isValidate(t))
        {
            MesgUtil.showMessageDialog(pl_TailPanel, "请输入您要计算的表达式！");
            tf_UserExps.requestFocus();
            return;
        }

        try
        {
            MesgUtil.showMessageDialog(pl_TailPanel, Util.calculate(t, 8, null));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            MesgUtil.showMessageDialog(pl_TailPanel, exp.getMessage());
            tf_UserExps.requestFocus();
        }
    }
    private javax.swing.JTextField tf_UserExps;
    private javax.swing.JButton bt_ButnExec;
}
