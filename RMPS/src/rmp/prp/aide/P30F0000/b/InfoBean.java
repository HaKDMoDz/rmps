/*
 * FileName:       InfoBean.java
 * CreateDate:     2008-4-14 下午09:25:50
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_03
 * CopyRight:      Amon (C) 2008 & Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn/ ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

import java.util.Random;

import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.i.WProp;
import rmp.util.CheckUtil;
import rmp.util.LogUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P30F0000.LangRes;

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
 * 日期： 2008-4-14 下午09:25:50
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class InfoBean extends javax.swing.JPanel implements WProp
{
    private int tipsSize;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        ica();
        ita();

        // 读取提示信息个数
        String s = P30F0000.getMesg(LangRes.P30F1B00);
        if (!CheckUtil.isValidate(s))
        {
            tipsSize = 0;
        }
        else
        {
            try
            {
                tipsSize = Integer.parseInt(s, 16);
            }
            catch(NumberFormatException exp)
            {
                tipsSize = 0;
                LogUtil.exception(exp);
            }
        }

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.prp.aide.P30F0000.i.WProp#setPropItem(rmp.prp.aide.P30F0000.b.PropItem)
     */
    @ Override
    public void setPropItem(PropItem pi)
    {
        if (pi != null)
        {
            lb_InfoName.setText(pi.getName());
            ta_InfoData.setText(pi.getData());
            return;
        }

        if (tipsSize <= 0)
        {
            return;
        }

        // 显示提示信息
        String t = Integer.toHexString(new Random().nextInt(tipsSize));
        t = "P30F1B" + StringUtil.lPad(t, 2, '0');
        lb_InfoName.setText(P30F0000.getMesg(LangRes.P30F1B01));
        ta_InfoData.setText(P30F0000.getMesg(t));
    }

    /**
     * 
     */
    private void ica()
    {
        lb_InfoName = new javax.swing.JLabel();
        ta_InfoData = new javax.swing.JTextArea();

        lb_InfoName.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        // lb_InfoName.setFont(lb_InfoName.getFont().deriveFont(java.awt.Font.BOLD));

        ta_InfoData.setLineWrap(true);
        ta_InfoData.setWrapStyleWord(true);
        ta_InfoData.setEditable(false);
        ta_InfoData.setOpaque(false);
        ta_InfoData.setTabSize(4);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            javax.swing.GroupLayout.Alignment.TRAILING,
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(ta_InfoData,
                    javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 247,
                    Short.MAX_VALUE).addComponent(lb_InfoName, javax.swing.GroupLayout.Alignment.LEADING,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 247, Short.MAX_VALUE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addComponent(lb_InfoName).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(ta_InfoData,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
        lb_InfoName.setText(P30F0000.getMesg(LangRes.P30F1B01));
        ta_InfoData.setText(P30F0000.getMesg(LangRes.P30F1B08));
    }

    private javax.swing.JLabel    lb_InfoName;
    private javax.swing.JTextArea ta_InfoData;

    /** serialVersionUID */
    private static final long     serialVersionUID = -4557938928002854599L;
}
