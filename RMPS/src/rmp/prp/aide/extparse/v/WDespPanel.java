/*
 * FileName:       WDespPanel.java
 * CreateDate:     2007-8-29 下午08:34:02
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.v;

import rmp.face.WBean;
import rmp.prp.aide.extparse.Extparse;
import rmp.util.BeanUtil;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2007-8-29 下午08:34:02
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class WDespPanel extends javax.swing.JPanel implements WBean
{
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        ica();
        ita();
        return true;
    }

    private void ica()
    {
        lb_ExtsDesp = new javax.swing.JLabel();
        cb_LangList = new javax.swing.JComboBox();
        javax.swing.JScrollPane sp_ExtsDesp = new javax.swing.JScrollPane();
        ta_ExtsDesp = new javax.swing.JTextArea();
        lb_MimeType = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_MimeType = new javax.swing.JScrollPane();
        ls_MimeType = new javax.swing.JList();
        lb_AsocSoft = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_AsocSoft = new javax.swing.JScrollPane();
        ls_AsocSoft = new javax.swing.JList();

        lb_ExtsDesp.setText("\u540e\u7f00\u63cf\u8ff0");
        lb_ExtsDesp.setToolTipText("\u540e\u7f00\u63cf\u8ff0");
        lb_ExtsDesp.setLabelFor(cb_LangList);

        cb_LangList.setToolTipText("\u663e\u793a\u4e0d\u540c\u8bed\u8a00\u7684\u540e\u7f00\u63cf\u8ff0\u4fe1\u606f");

        ta_ExtsDesp.setColumns(20);
        ta_ExtsDesp.setEditable(false);
        ta_ExtsDesp.setLineWrap(true);
        ta_ExtsDesp.setToolTipText("\u540e\u7f00\u63cf\u8ff0\u4fe1\u606f");
        sp_ExtsDesp.setViewportView(ta_ExtsDesp);

        lb_MimeType.setText("MIME\u7c7b\u578b");
        lb_MimeType.setToolTipText("MIME\u7c7b\u578b");

        ls_MimeType.setToolTipText("MIME\u7c7b\u578b\u5217\u8868");
        ls_MimeType.setVisibleRowCount(4);
        sp_MimeType.setViewportView(ls_MimeType);

        lb_AsocSoft.setText("\u5907\u9009\u8f6f\u4ef6");
        lb_AsocSoft.setToolTipText("\u5907\u9009\u8f6f\u4ef6");

        ls_AsocSoft.setToolTipText("\u5907\u9009\u8f6f\u4ef6\u5217\u8868");
        ls_AsocSoft.setVisibleRowCount(4);
        sp_AsocSoft.setViewportView(ls_AsocSoft);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(sp_ExtsDesp,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 234, Short.MAX_VALUE).addGroup(
                    layout.createSequentialGroup().addComponent(lb_ExtsDesp).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cb_LangList, 0, 182,
                        Short.MAX_VALUE)).addComponent(sp_AsocSoft, javax.swing.GroupLayout.DEFAULT_SIZE, 234,
                    Short.MAX_VALUE).addComponent(lb_AsocSoft).addComponent(sp_MimeType,
                    javax.swing.GroupLayout.DEFAULT_SIZE, 234, Short.MAX_VALUE).addComponent(lb_MimeType))
                .addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
            layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_ExtsDesp)
                    .addComponent(cb_LangList, javax.swing.GroupLayout.PREFERRED_SIZE,
                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_ExtsDesp,
                javax.swing.GroupLayout.DEFAULT_SIZE, 79, Short.MAX_VALUE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_MimeType).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_MimeType,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(lb_AsocSoft).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_AsocSoft,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap()));
    }

    /**
     * @param isHash
     */
    private void ita()
    {
        // 后缀描述
        BeanUtil.setWText(lb_ExtsDesp, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_EXTSDESP));
        BeanUtil.setWTips(lb_ExtsDesp, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_EXTSDESP));

        BeanUtil.setWTips(cb_LangList, Extparse.getMesg(LangRes.MAIN_COMB_TIPS_LANGLIST));

        BeanUtil.setWText(ta_ExtsDesp, Extparse.getMesg(LangRes.MAIN_AREA_TEXT_EXTSDESP));
        BeanUtil.setWTips(ta_ExtsDesp, Extparse.getMesg(LangRes.MAIN_AREA_TIPS_EXTSDESP));

        // 备选软件
        BeanUtil.setWText(lb_AsocSoft, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_ASOCSOFT));
        BeanUtil.setWTips(lb_AsocSoft, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_ASOCSOFT));

        BeanUtil.setWTips(ls_AsocSoft, Extparse.getMesg(LangRes.MAIN_LIST_TIPS_ASOCSOFT));

        // MIME类型
        BeanUtil.setWText(lb_MimeType, Extparse.getMesg(LangRes.MAIN_LABL_TEXT_MIMETYPE));
        BeanUtil.setWTips(lb_MimeType, Extparse.getMesg(LangRes.MAIN_LABL_TIPS_MIMETYPE));

        BeanUtil.setWTips(ls_MimeType, Extparse.getMesg(LangRes.MAIN_LIST_TIPS_MIMETYPE));
    }

    protected javax.swing.JComboBox cb_LangList;
    protected javax.swing.JLabel    lb_AsocSoft;
    protected javax.swing.JLabel    lb_ExtsDesp;
    protected javax.swing.JLabel    lb_MimeType;
    protected javax.swing.JList     ls_AsocSoft;
    protected javax.swing.JList     ls_MimeType;
    protected javax.swing.JTextArea ta_ExtsDesp;
}
