/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30A0000.v;

import com.amonsoft.rmps.prp.v.IView;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import rmp.comn.tray.C3010000.C3010000;
import rmp.prp.aide.P30A0000.P30A0000;
import rmp.prp.aide.P30A0000.m.DataModel;
import rmp.prp.aide.P30A0000.t.Util;
import rmp.ui.form.DForm;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;

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
public class TailPanel implements IView
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 主程序对象 */
    private P30A0000 ms_MainSoft;
    /** 内嵌面板对象 */
    private javax.swing.JPanel tp_TailPanel;
    /** 数据模型 */
    private DataModel dm_DataModel;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P30A0000 soft, javax.swing.JPanel tailPanel)
    {
        this.ms_MainSoft = soft;
        this.tp_TailPanel = tailPanel;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面初始化
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @return
     */
    @Override
    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面视图区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局初始化
    // ----------------------------------------------------
    /**
     * 
     */
    private void ica()
    {
        java.awt.GridBagConstraints gridBagConstraints;

        javax.swing.JPanel p1 = new javax.swing.JPanel();
        tf_SttCity = new javax.swing.JTextField();
        javax.swing.JLabel l1 = new javax.swing.JLabel();
        tf_EndCity = new javax.swing.JTextField();
        javax.swing.JPanel p2 = new javax.swing.JPanel();
        tf_TheDate = new javax.swing.JTextField();
        bt_QueryNow = new javax.swing.JButton();

        tp_TailPanel.setLayout(new java.awt.GridLayout(2, 1, 5, 5));

        p1.setLayout(new java.awt.GridBagLayout());

        tf_SttCity.setText("上海");
        tf_SttCity.setToolTipText("起始城市");
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 0.5;
        gridBagConstraints.insets = new java.awt.Insets(5, 5, 0, 0);
        p1.add(tf_SttCity, gridBagConstraints);

        l1.setText("->");
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.insets = new java.awt.Insets(5, 5, 0, 5);
        p1.add(l1, gridBagConstraints);

        tf_EndCity.setText("北京");
        tf_EndCity.setToolTipText("到达城市");
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 0.5;
        gridBagConstraints.insets = new java.awt.Insets(5, 0, 0, 5);
        p1.add(tf_EndCity, gridBagConstraints);

        tp_TailPanel.add(p1);

        p2.setLayout(new java.awt.GridBagLayout());

        tf_TheDate.setToolTipText("出行时间");
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 0.5;
        gridBagConstraints.insets = new java.awt.Insets(0, 5, 5, 5);
        p2.add(tf_TheDate, gridBagConstraints);

        bt_QueryNow.setMnemonic('Q');
        bt_QueryNow.setText("查询(Q)");
        bt_QueryNow.setToolTipText("查询飞机航班");
        bt_QueryNow.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_QueryNow.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_QueryNow_Handler(evt);
            }
        });
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.insets = new java.awt.Insets(0, 0, 5, 5);
        p2.add(bt_QueryNow, gridBagConstraints);

        tp_TailPanel.add(p2);
    }

    /**
     * 查询结果显示
     */
    private void icb()
    {
        javax.swing.JPanel viewPanel = new javax.swing.JPanel();

        javax.swing.JScrollPane sp_DataList = new javax.swing.JScrollPane();
        tb_DataList = new javax.swing.JTable();

        dm_DataModel = new DataModel();
        tb_DataList.setModel(dm_DataModel);

        sp_DataList.setViewportView(tb_DataList);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(viewPanel);
        viewPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_DataList,
                javax.swing.GroupLayout.DEFAULT_SIZE, 202, Short.MAX_VALUE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_DataList,
                javax.swing.GroupLayout.DEFAULT_SIZE, 136, Short.MAX_VALUE).addContainerGap()));

        df_DataView = new DForm(C3010000.queryRef("prp"));
        df_DataView.wInit();
        df_DataView.setContentPane(viewPanel);
        df_DataView.pack();
        df_DataView.center();
        df_DataView.setVisible(true);
        df_DataView.setDefaultCloseOperation(DForm.DISPOSE_ON_CLOSE);
    }

    // ----------------------------------------------------
    // 界面语言初始化
    // ----------------------------------------------------
    /**
     * 
     */
    private void ita()
    {
        tf_TheDate.setToolTipText("出行时间，仅接受yyyy-MM-dd格式的日期");
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        tf_TheDate.setText(sdf.format(new Date()));
    }

    /**
     * 
     */
    private void itb()
    {
        df_DataView.setTitle(ms_MainSoft.wGetTitle() + " " + tf_TheDate.getText());
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param evt
     */
    private void bt_QueryNow_Handler(java.awt.event.ActionEvent evt)
    {
        String sttCity = tf_SttCity.getText().trim();
        String endCity = tf_EndCity.getText().trim();
        String theDate = tf_TheDate.getText().trim();

        try
        {
            List<HashMap<String, String>> dataList = Util.getDomesticAirlinesTime(sttCity, endCity, theDate);

            if (dataList == null || dataList.size() < 1)
            {
                MesgUtil.showMessageDialog(null, "查询不到数据！");
                return;
            }

            if (df_DataView == null)
            {
                icb();
                itb();
            }

            if (!df_DataView.isVisible())
            {
                df_DataView.setVisible(true);
            }

            dm_DataModel.setDataModel(dataList);
            dm_DataModel.fireTableDataChanged();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 起始城市 */
    private javax.swing.JTextField tf_SttCity;
    /** 结束城市 */
    private javax.swing.JTextField tf_EndCity;
    /** 查询时间 */
    private javax.swing.JTextField tf_TheDate;
    /** 执行查询 */
    private javax.swing.JButton bt_QueryNow;
    /** 结果显示表格 */
    private javax.swing.JTable tb_DataList;
    private DForm df_DataView;
}
