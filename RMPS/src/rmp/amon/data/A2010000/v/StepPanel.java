/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.amon.data.A2010000.v;

import java.sql.Connection;

import javax.swing.DefaultComboBoxModel;

import rmp.amon.data.A2010000.b.WDataBase;
import rmp.amon.data.A2010000.t.Util;
import rmp.bean.K1SV1S;
import rmp.util.CheckUtil;
import com.amonsoft.util.LogUtil;
import cons.db.AmonCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class StepPanel extends javax.swing.JPanel
{
    private javax.swing.JDialog dg_DForm;
    private boolean isUpdate;
    private DefaultComboBoxModel cm_SKind;
    private DefaultComboBoxModel cm_SSystem;
    private DefaultComboBoxModel cm_DBKind;

    /**
     * 
     */
    public StepPanel()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.ui.dlg.DViewPanel#wInit()
     */
    public boolean wInit()
    {
        ica();
        icb();

        ita();
        itb();

        cm_SKind = new DefaultComboBoxModel();
        cm_SKind.addElement(new K1SV1S("6", "字段"));
        cm_SKind.addElement(new K1SV1S("5", "表格"));
        cm_SKind.addElement(new K1SV1S("4", "区位"));
        cm_SKind.addElement(new K1SV1S("3", "功能"));
        cm_SKind.addElement(new K1SV1S("2", "软件"));
        cm_SKind.addElement(new K1SV1S("1", "模块"));
        cm_SKind.addElement(new K1SV1S("0", "系统"));
        cb_SKind.setModel(cm_SKind);

        cm_SSystem = new DefaultComboBoxModel();
        cm_SSystem.addElement(new K1SV1S("P", "Prps"));
        cm_SSystem.addElement(new K1SV1S("C", "Comn"));
        cm_SSystem.addElement(new K1SV1S("A", "Amon"));
        cm_SSystem.addElement(new K1SV1S("W", "Wrps"));
        cm_SSystem.addElement(new K1SV1S("M", "Mrps"));
        cm_SSystem.addElement(new K1SV1S("E", "Erps"));
        cb_SSystem.setModel(cm_SSystem);

        cm_DBKind = new DefaultComboBoxModel();
        cm_DBKind.addElement(new K1SV1S("0", "可变字符"));
        cm_DBKind.addElement(new K1SV1S("1", "定长字符"));
        cm_DBKind.addElement(new K1SV1S("2", "小数数据"));
        cm_DBKind.addElement(new K1SV1S("3", "整数数据"));
        cm_DBKind.addElement(new K1SV1S("4", "日期数据"));
        cm_DBKind.addElement(new K1SV1S("5", "时间数据"));
        cb_DBKind.setModel(cm_DBKind);

        dg_DForm = new javax.swing.JDialog();
        dg_DForm.setResizable(false);
        dg_DForm.setContentPane(this);
        dg_DForm.pack();
        dg_DForm.setVisible(true);

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        pl_Filed = new javax.swing.JPanel();
        lb_DBKind = new javax.swing.JLabel();
        cb_DBKind = new javax.swing.JComboBox();
        lb_DBSize = new javax.swing.JLabel();
        tf_DBSize = new javax.swing.JTextField();
        lb_IsPK = new javax.swing.JLabel();
        ck_IsPK = new javax.swing.JCheckBox();
        lb_IsNL = new javax.swing.JLabel();
        ck_IsNL = new javax.swing.JCheckBox();
        lb_IsUK = new javax.swing.JLabel();
        ck_IsUK = new javax.swing.JCheckBox();
        lb_DefValue = new javax.swing.JLabel();
        tf_DefValue = new javax.swing.JTextField();
        lb_FKey = new javax.swing.JLabel();
        tf_FKey = new javax.swing.JTextField();

        lb_DBKind.setDisplayedMnemonic('T');
        lb_DBKind.setText("\u6570\u636e\u7c7b\u578b(T)");

        cb_DBKind.addItemListener(new java.awt.event.ItemListener()
        {
            @Override
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_DBKind_Handler(evt);
            }
        });

        lb_DBSize.setDisplayedMnemonic('L');
        lb_DBSize.setText("\u6570\u636e\u957f\u5ea6(L)");

        tf_DBSize.setColumns(10);

        lb_IsPK.setText("\u662f\u5426\u4e3b\u952e");

        ck_IsPK.setMnemonic('P');
        ck_IsPK.setText("\u4e3b\u952e(P)");
        ck_IsPK.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_IsPK.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_IsNL.setText("\u53ef\u5426\u4e3a\u7a7a");

        ck_IsNL.setMnemonic('N');
        ck_IsNL.setSelected(true);
        ck_IsNL.setText("\u4e3a\u7a7a(N)");
        ck_IsNL.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_IsNL.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_IsUK.setText("\u662f\u5426\u552f\u4e00");

        ck_IsUK.setMnemonic('U');
        ck_IsUK.setText("\u552f\u4e00(U)");
        ck_IsUK.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        ck_IsUK.setMargin(new java.awt.Insets(0, 0, 0, 0));

        lb_DefValue.setDisplayedMnemonic('D');
        lb_DefValue.setText("\u9ed8\u8ba4\u6570\u636e(D)");

        lb_FKey.setDisplayedMnemonic('F');
        lb_FKey.setText("\u53c2\u8003\u5916\u952e(F)");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(pl_Filed);
        pl_Filed.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_DBKind).addComponent(lb_DBSize).addComponent(lb_IsPK).addComponent(lb_IsNL).addComponent(lb_IsUK).addComponent(lb_DefValue).addComponent(lb_FKey)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(cb_DBKind,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(tf_DBSize,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(ck_IsPK).addComponent(ck_IsNL).addComponent(
                ck_IsUK).addComponent(tf_FKey, javax.swing.GroupLayout.DEFAULT_SIZE, 210, Short.MAX_VALUE).addComponent(tf_DefValue, javax.swing.GroupLayout.DEFAULT_SIZE, 210, Short.MAX_VALUE))));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DBKind).addComponent(cb_DBKind, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DBSize).addComponent(tf_DBSize, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IsPK).addComponent(ck_IsPK)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IsNL).addComponent(ck_IsNL)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_IsUK).addComponent(ck_IsUK)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DefValue).addComponent(tf_DefValue, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_FKey).addComponent(tf_FKey, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))));
    }

    /**
     * 
     */
    private void icb()
    {
        lb_Sid = new javax.swing.JLabel();
        tf_Sid = new javax.swing.JTextField();
        lb_SName = new javax.swing.JLabel();
        tf_SName = new javax.swing.JTextField();
        lb_SKind = new javax.swing.JLabel();
        cb_SKind = new javax.swing.JComboBox();
        lb_SSystem = new javax.swing.JLabel();
        cb_SSystem = new javax.swing.JComboBox();
        lb_SCreater = new javax.swing.JLabel();
        tf_SCreater = new javax.swing.JTextField();
        lb_SVer = new javax.swing.JLabel();
        tf_SVer = new javax.swing.JTextField();
        lb_SDesp = new javax.swing.JLabel();
        javax.swing.JScrollPane sp_SDesp = new javax.swing.JScrollPane();
        ta_SDesp = new javax.swing.JTextArea();
        sp_SLine = new javax.swing.JSeparator();
        bt_Update = new javax.swing.JButton();

        lb_Sid.setDisplayedMnemonic('A');
        lb_Sid.setText("\u5b57\u6bb5\u7d22\u5f15(A)");

        tf_Sid.setColumns(20);

        lb_SName.setDisplayedMnemonic('N');
        lb_SName.setText("\u5b57\u6bb5\u540d\u79f0(N)");

        lb_SKind.setDisplayedMnemonic('K');
        lb_SKind.setText("\u6240\u5c5e\u7c7b\u522b(K)");

        cb_SKind.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_SKind_Handler(evt);
            }
        });

        lb_SSystem.setDisplayedMnemonic('S');
        lb_SSystem.setText("\u6240\u5c5e\u7cfb\u7edf(S)");

        lb_SCreater.setDisplayedMnemonic('C');
        lb_SCreater.setText("\u521b\u5efa\u4eba\u5458(C)");

        lb_SVer.setDisplayedMnemonic('V');
        lb_SVer.setText("\u5f53\u524d\u7248\u672c(V)");

        tf_SVer.setEditable(false);

        lb_SDesp.setDisplayedMnemonic('D');
        lb_SDesp.setText("\u76f8\u5173\u8bf4\u660e(D)");

        ta_SDesp.setColumns(20);
        ta_SDesp.setRows(4);
        sp_SDesp.setViewportView(ta_SDesp);

        bt_Update.setMnemonic('O');
        bt_Update.setText("\u786e\u5b9a(O)");
        bt_Update.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Update_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_Filed,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(sp_SLine, javax.swing.GroupLayout.Alignment.TRAILING,
                javax.swing.GroupLayout.DEFAULT_SIZE, 280, Short.MAX_VALUE).addGroup(
                javax.swing.GroupLayout.Alignment.TRAILING,
                layout.createSequentialGroup().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_Sid).addComponent(lb_SName).addComponent(lb_SKind).addComponent(lb_SSystem).addComponent(
                lb_SCreater).addComponent(lb_SVer).addComponent(lb_SDesp)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(tf_Sid,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(cb_SKind,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(cb_SSystem,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(sp_SDesp,
                javax.swing.GroupLayout.DEFAULT_SIZE, 210, Short.MAX_VALUE).addComponent(tf_SCreater,
                javax.swing.GroupLayout.DEFAULT_SIZE, 210, Short.MAX_VALUE).addComponent(tf_SVer,
                javax.swing.GroupLayout.DEFAULT_SIZE, 210, Short.MAX_VALUE).addComponent(tf_SName,
                javax.swing.GroupLayout.DEFAULT_SIZE, 210, Short.MAX_VALUE))).addComponent(bt_Update,
                javax.swing.GroupLayout.Alignment.TRAILING)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_Sid).addComponent(tf_Sid, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SName).addComponent(tf_SName, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SKind).addComponent(cb_SKind, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SSystem).addComponent(cb_SSystem, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SCreater).addComponent(tf_SCreater, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_SVer).addComponent(tf_SVer, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_SDesp).addComponent(sp_SDesp, javax.swing.GroupLayout.PREFERRED_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_SLine,
                javax.swing.GroupLayout.PREFERRED_SIZE, 2, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_Filed,
                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE,
                Short.MAX_VALUE).addComponent(bt_Update).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 
     */
    private void itb()
    {
    }

    /**
     * @param data
     */
    public void setUpdateData(String[] data)
    {
        tf_Sid.setText(data[0]);
        tf_SName.setText(data[1]);
        ta_SDesp.setText(data[13]);
    }

    /**
     * @param evt
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        if (!checkInput())
        {
            return;
        }

        K1SV1S kvItem;
        StringBuffer sqlUpdate = new StringBuffer();
        if (isUpdate)
        {
            sqlUpdate.append("UPDATE ").append(AmonCons.A2010100).append(" SET ");
            sqlUpdate.append(AmonCons.A2010102).append(" = '").append(tf_SName.getText()).append("', ");
            kvItem = (K1SV1S) cb_DBKind.getSelectedItem();
            sqlUpdate.append(AmonCons.A2010103).append(" = '").append(kvItem.getK()).append("', ");
            String size = tf_DBSize.getText();
            sqlUpdate.append(AmonCons.A2010104).append(" = '").append(CheckUtil.isValidate(size) ? size : "0").append(
                    "', ");
            sqlUpdate.append(AmonCons.A2010105).append(" = '").append(ck_IsPK.isSelected() ? '1' : '0').append("', ");
            sqlUpdate.append(AmonCons.A2010106).append(" = '").append(ck_IsNL.isSelected() ? '1' : '0').append("', ");
            sqlUpdate.append(AmonCons.A2010107).append(" = '").append(ck_IsUK.isSelected() ? '1' : '0').append("', ");
            sqlUpdate.append(AmonCons.A2010108).append(" = '").append(tf_DefValue.getText()).append("', ");
            sqlUpdate.append(AmonCons.A2010109).append(" = '").append(tf_FKey.getText()).append("', ");
            kvItem = (K1SV1S) cb_SKind.getSelectedItem();
            sqlUpdate.append(AmonCons.A201010A).append(" = '").append(kvItem.getK()).append("', ");
            kvItem = (K1SV1S) cb_SSystem.getSelectedItem();
            sqlUpdate.append(AmonCons.A201010B).append(" = '").append(kvItem.getK()).append("', ");
            sqlUpdate.append(AmonCons.A201010C).append(" = '").append(tf_SCreater.getText()).append("', ");
            sqlUpdate.append(AmonCons.A201010D).append(" = '").append(tf_SVer.getText()).append("', ");
            sqlUpdate.append(AmonCons.A201010E).append(" = '").append(ta_SDesp.getText()).append("', ");
            sqlUpdate.append(AmonCons.A201010F).append(" = NOW");
            sqlUpdate.append(" WHERE ").append(AmonCons.A2010101).append(" = '").append(tf_Sid.getText()).append("'");
        }
        else
        {
            sqlUpdate.append("INSERT INTO ").append(AmonCons.A2010100).append(" VALUES (");
            sqlUpdate.append('\'').append(tf_Sid.getText()).append("', ");
            sqlUpdate.append('\'').append(tf_SName.getText()).append("', ");
            kvItem = (K1SV1S) cb_DBKind.getSelectedItem();
            sqlUpdate.append('\'').append(kvItem.getK()).append("', ");
            String size = tf_DBSize.getText();
            sqlUpdate.append(CheckUtil.isValidate(size) ? size : "0").append(", ");
            sqlUpdate.append('\'').append(ck_IsPK.isSelected() ? '1' : '0').append("', ");
            sqlUpdate.append('\'').append(ck_IsNL.isSelected() ? '1' : '0').append("', ");
            sqlUpdate.append('\'').append(ck_IsUK.isSelected() ? '1' : '0').append("', ");
            sqlUpdate.append('\'').append(tf_DefValue.getText()).append("', ");
            sqlUpdate.append('\'').append(tf_FKey.getText()).append("', ");
            kvItem = (K1SV1S) cb_SKind.getSelectedItem();
            sqlUpdate.append('\'').append(kvItem.getK()).append("', ");
            kvItem = (K1SV1S) cb_SSystem.getSelectedItem();
            sqlUpdate.append('\'').append(kvItem.getK()).append("', ");
            sqlUpdate.append('\'').append(tf_SCreater.getText()).append("', ");
            sqlUpdate.append('\'').append(tf_SVer.getText()).append("', ");
            sqlUpdate.append('\'').append(ta_SDesp.getText()).append("', ");
            sqlUpdate.append("NOW").append(", ");
            sqlUpdate.append("NOW").append(")");
        }
        System.out.println(sqlUpdate.toString());

        try
        {
            WDataBase wdb = new WDataBase();
            Connection conn = Util.getConnection(wdb);
            conn.createStatement().executeUpdate(sqlUpdate.toString());
            Util.closeConnection(wdb, conn);
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return;
        }

        tf_SName.setText("");
        ta_SDesp.setText("");
        tf_DefValue.setText("");
        tf_FKey.setText("");
    }

    /**
     * @param evt
     */
    private void cb_DBKind_Handler(java.awt.event.ItemEvent evt)
    {
        tf_DBSize.setEditable(cb_DBKind.getSelectedIndex() < 3);
    }

    /**
     * @param evt
     */
    private void cb_SKind_Handler(java.awt.event.ItemEvent evt)
    {
        boolean b = cb_SKind.getSelectedIndex() == 0;
        sp_SLine.setVisible(b);
        pl_Filed.setVisible(b);
        tf_SVer.setEditable(!b);
        dg_DForm.pack();
    }

    /**
     * @return
     */
    private boolean checkInput()
    {
        return true;
    }
    private javax.swing.JButton bt_Update;
    private javax.swing.JComboBox cb_SKind;
    private javax.swing.JComboBox cb_SSystem;
    private javax.swing.JLabel lb_SCreater;
    private javax.swing.JLabel lb_SDesp;
    private javax.swing.JLabel lb_SKind;
    private javax.swing.JLabel lb_SName;
    private javax.swing.JLabel lb_SSystem;
    private javax.swing.JLabel lb_SVer;
    private javax.swing.JLabel lb_Sid;
    private javax.swing.JTextArea ta_SDesp;
    private javax.swing.JTextField tf_SCreater;
    private javax.swing.JTextField tf_SName;
    private javax.swing.JTextField tf_SVer;
    private javax.swing.JTextField tf_Sid;
    private javax.swing.JSeparator sp_SLine;
    private javax.swing.JPanel pl_Filed;
    private javax.swing.JComboBox cb_DBKind;
    private javax.swing.JCheckBox ck_IsNL;
    private javax.swing.JCheckBox ck_IsPK;
    private javax.swing.JCheckBox ck_IsUK;
    private javax.swing.JLabel lb_DBKind;
    private javax.swing.JLabel lb_DBSize;
    private javax.swing.JLabel lb_DefValue;
    private javax.swing.JLabel lb_FKey;
    private javax.swing.JLabel lb_IsNL;
    private javax.swing.JLabel lb_IsPK;
    private javax.swing.JLabel lb_IsUK;
    private javax.swing.JTextField tf_DBSize;
    private javax.swing.JTextField tf_DefValue;
    private javax.swing.JTextField tf_FKey;
    /**  */
    private static final long serialVersionUID = 7534909244729937280L;

    /**
     * @return the isUpdate
     */
    public boolean isUpdate()
    {
        return isUpdate;
    }

    /**
     * @param isUpdate the isUpdate to set
     */
    public void setUpdate(boolean isUpdate)
    {
        this.isUpdate = isUpdate;
    }
}
