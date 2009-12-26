/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.data.A2010000.v;

import java.io.File;
import java.sql.Connection;

import javax.swing.DefaultComboBoxModel;
import javax.swing.ListSelectionModel;

import rmp.comn.amon.data.A2010000.A2010000;
import rmp.comn.amon.data.A2010000.b.WDataBase;
import rmp.comn.amon.data.A2010000.m.WTableModel;
import rmp.comn.amon.data.A2010000.t.Util;
import rmp.face.WBean;
import rmp.util.CheckUtil;
import rmp.util.MesgUtil;
import rmp.util.StringUtil;
import cons.comn.amon.data.A2010000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class NormPanel extends javax.swing.JPanel implements WBean
{
    private StepPanel sp_StepPanel;
    private DefaultComboBoxModel cm_DBType;
    private WTableModel tm_DBView;
    private WDataBase db_DataBase;

    /**
     * @param soft
     */
    public NormPanel(A2010000 soft)
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

        db_DataBase = new WDataBase();

        cm_DBType = new DefaultComboBoxModel();
        cm_DBType.addElement("HSQLDB");
        cm_DBType.addElement("Access");

        cb_DBType.setModel(cm_DBType);

        tm_DBView = new WTableModel();
        tb_DBView.setModel(tm_DBView);

        return true;
    }

    /**
     * 
     */
    private void ica()
    {
        lb_DBType = new javax.swing.JLabel();
        cb_DBType = new javax.swing.JComboBox();
        lb_DBPath = new javax.swing.JLabel();
        tf_DBPath = new javax.swing.JTextField();
        bt_DBPath = new javax.swing.JButton();
        lb_DBTable = new javax.swing.JLabel();
        tf_DBTable = new javax.swing.JTextField();
        sp_DBView = new javax.swing.JScrollPane();
        tb_DBView = new javax.swing.JTable();
        bt_Export = new javax.swing.JButton();
        bt_Delete = new javax.swing.JButton();
        bt_Update = new javax.swing.JButton();
        bt_Create = new javax.swing.JButton();
        bt_Select = new javax.swing.JButton();

        lb_DBType.setDisplayedMnemonic('K');
        lb_DBType.setText("\u6570\u636e\u5e93\u7c7b\u578b(K)");

        cb_DBType.addItemListener(new java.awt.event.ItemListener()
        {
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_DBType_Handler(evt);
            }
        });

        lb_DBPath.setDisplayedMnemonic('P');
        lb_DBPath.setText("\u6570\u636e\u5e93\u8def\u5f84(P)");

        tf_DBPath.setText("1000000/dat/amon");

        bt_DBPath.setMnemonic('S');
        bt_DBPath.setText("\u9009\u62e9(S)");
        bt_DBPath.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_DBPath_Handler(evt);
            }
        });

        lb_DBTable.setDisplayedMnemonic('T');
        lb_DBTable.setText("\u67e5\u770b\u8868\u683c(T)");

        tf_DBTable.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_DBTable_Handler(evt);
            }
        });

        sp_DBView.setViewportView(tb_DBView);
        tb_DBView.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);

        bt_Export.setMnemonic('E');
        bt_Export.setText("E");
        bt_Export.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Export_Handler(evt);
            }
        });

        bt_Delete.setMnemonic('D');
        bt_Delete.setText("D");
        bt_Delete.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Delete_Handler(evt);
            }
        });

        bt_Update.setText("U");
        bt_Update.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Update_Handler(evt);
            }
        });

        bt_Create.setText("N");
        bt_Create.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Create_Handler(evt);
            }
        });

        bt_Select.setText("V");
        bt_Select.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_Select_Handler(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                                javax.swing.GroupLayout.Alignment.TRAILING,
                                layout.createSequentialGroup().addGroup(
                                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(lb_DBType).addComponent(lb_DBPath).addComponent(lb_DBTable))
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                                                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(cb_DBType, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                        javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(
                                                        javax.swing.GroupLayout.Alignment.TRAILING,
                                                        layout.createSequentialGroup().addComponent(tf_DBPath, javax.swing.GroupLayout.DEFAULT_SIZE, 225, Short.MAX_VALUE).addPreferredGap(
                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_DBPath)).addGroup(
                                                        javax.swing.GroupLayout.Alignment.TRAILING,
                                                        layout.createSequentialGroup().addComponent(tf_DBTable, javax.swing.GroupLayout.DEFAULT_SIZE, 80, Short.MAX_VALUE).addPreferredGap(
                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Select).addPreferredGap(
                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Create).addPreferredGap(
                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Update).addPreferredGap(
                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Delete).addPreferredGap(
                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(bt_Export)))).addComponent(sp_DBView,
                                javax.swing.GroupLayout.DEFAULT_SIZE, 388, Short.MAX_VALUE)).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DBType).addComponent(cb_DBType, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DBPath).addComponent(bt_DBPath).addComponent(tf_DBPath,
                                javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(
                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                        layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(lb_DBTable).addComponent(bt_Export).addComponent(bt_Delete).addComponent(bt_Update)
                                .addComponent(bt_Create).addComponent(bt_Select).addComponent(tf_DBTable, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                        javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sp_DBView,
                        javax.swing.GroupLayout.DEFAULT_SIZE, 155, Short.MAX_VALUE).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * @param evt
     */
    private void bt_Delete_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void bt_Export_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = cb_DBType.getSelectedItem();
        if (obj == null)
        {
            MesgUtil.showMessageDialog(this, "请选择您要连接的数据库类型！");
            cb_DBType.requestFocus();
            return;
        }

        String url = tf_DBPath.getText();
        if (!CheckUtil.isValidate(url))
        {
            MesgUtil.showMessageDialog(this, "请选择或输入数据库服务器地址或路径！");
            tf_DBPath.requestFocus();
            return;
        }

        if (ConstUI.HSQLDB_KEY.equals(obj))
        {
            db_DataBase.setDriver(ConstUI.HSQLDB_DRV);
            db_DataBase.setUrl(StringUtil.format(ConstUI.HSQLDB_URL, url));
        }

        Connection conn = Util.getConnection(db_DataBase);
        Util.exportDBA(conn, tf_DBTable.getText(), new File("D:\\amon.sql"));
        // String dbm = Util.exportDBM(conn, tf_DBTable.getText(), "key");
        Util.closeConnection(db_DataBase, conn);
        // System.out.println(dbm);
    }

    /**
     * @param evt
     */
    private void bt_Update_Handler(java.awt.event.ActionEvent evt)
    {
        int idx = tb_DBView.getSelectedRow();
        if (idx < 0 || idx > tm_DBView.getRowCount())
        {
            MesgUtil.showMessageDialog(this, "请选择您要更新的数据！");
            return;
        }

        if (sp_StepPanel == null)
        {
            sp_StepPanel = new StepPanel();
            sp_StepPanel.wInit();
        }
        sp_StepPanel.setUpdate(true);
        sp_StepPanel.setUpdateData(tm_DBView.getRowData(idx));
    }

    /**
     * @param evt
     */
    private void bt_Create_Handler(java.awt.event.ActionEvent evt)
    {
        if (sp_StepPanel == null)
        {
            sp_StepPanel = new StepPanel();
            sp_StepPanel.wInit();
        }
    }

    /**
     * @param evt
     */
    private void bt_Select_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = cb_DBType.getSelectedItem();
        if (obj == null)
        {
            MesgUtil.showMessageDialog(this, "请选择您要连接的数据库类型！");
            cb_DBType.requestFocus();
            return;
        }

        String url = tf_DBPath.getText();
        if (!CheckUtil.isValidate(url))
        {
            MesgUtil.showMessageDialog(this, "请选择或输入数据库服务器地址或路径！");
            tf_DBPath.requestFocus();
            return;
        }

        if (ConstUI.HSQLDB_KEY.equals(obj))
        {
            db_DataBase.setDriver(ConstUI.HSQLDB_DRV);
            db_DataBase.setUrl(StringUtil.format(ConstUI.HSQLDB_URL, url));
        }

        tm_DBView.viewData(db_DataBase, tf_DBTable.getText());
    }

    /**
     * @param evt
     */
    private void bt_DBPath_Handler(java.awt.event.ActionEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void cb_DBType_Handler(java.awt.event.ItemEvent evt)
    {
    }

    /**
     * @param evt
     */
    private void tf_DBTable_Handler(java.awt.event.ActionEvent evt)
    {
        Object obj = cb_DBType.getSelectedItem();
        if (obj == null)
        {
            MesgUtil.showMessageDialog(this, "请选择您要连接的数据库类型！");
            cb_DBType.requestFocus();
            return;
        }

        String url = tf_DBPath.getText();
        if (!CheckUtil.isValidate(url))
        {
            MesgUtil.showMessageDialog(this, "请选择或输入数据库服务器地址或路径！");
            tf_DBPath.requestFocus();
            return;
        }

        String sid = tf_DBTable.getText();
        if (!CheckUtil.isValidate(sid))
        {
            MesgUtil.showMessageDialog(this, "请输入您要查看的数据表格名称ID！");
            tf_DBTable.requestFocus();
            return;
        }

        if (ConstUI.HSQLDB_KEY.equals(obj))
        {
            db_DataBase.setDriver(ConstUI.HSQLDB_DRV);
            db_DataBase.setUrl(StringUtil.format(ConstUI.HSQLDB_URL, url));
        }

        tm_DBView.viewData(db_DataBase, sid);
    }

    private javax.swing.JButton bt_Create;
    private javax.swing.JButton bt_DBPath;
    private javax.swing.JButton bt_Delete;
    private javax.swing.JButton bt_Export;
    private javax.swing.JButton bt_Select;
    private javax.swing.JButton bt_Update;
    private javax.swing.JComboBox cb_DBType;
    private javax.swing.JLabel lb_DBPath;
    private javax.swing.JLabel lb_DBTable;
    private javax.swing.JLabel lb_DBType;
    private javax.swing.JScrollPane sp_DBView;
    private javax.swing.JTable tb_DBView;
    private javax.swing.JTextField tf_DBPath;
    private javax.swing.JTextField tf_DBTable;
    /**  */
    private static final long serialVersionUID = 243137893346591751L;
}
