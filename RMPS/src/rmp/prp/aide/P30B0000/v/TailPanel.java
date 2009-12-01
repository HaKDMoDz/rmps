/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30B0000.v;

import com.amonsoft.bean.WForm;
import com.amonsoft.rmps.prp.v.IView;
import java.util.HashMap;
import java.util.List;

import javax.swing.WindowConstants;
import rmp.prp.aide.P30A0000.m.DataModel;
import rmp.prp.aide.P30A0000.t.Util;
import rmp.prp.aide.P30B0000.P30B0000;
import com.amonsoft.util.LogUtil;
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
    /**  */
    // private P30B0000 ms_MainSoft;
    /**  */
    private javax.swing.JPanel tp_TailPanel;
    /**  */
    private DataModel dm_DataModel;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param tailPanel
     */
    public TailPanel(P30B0000 soft, javax.swing.JPanel tailPanel)
    {
        // this.ms_MainSoft = soft;
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
        tf_SttCity = new javax.swing.JTextField();
        tp_TailPanel.add(tf_SttCity);

        tf_EndCity = new javax.swing.JTextField();
        tp_TailPanel.add(tf_EndCity);

        tf_TheDate = new javax.swing.JTextField();
        tp_TailPanel.add(tf_TheDate);

        bt_QueryNow = new javax.swing.JButton();
        bt_QueryNow.setText("查询");
        bt_QueryNow.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_QueryNow_Handler(evt);
            }
        });
        tp_TailPanel.add(bt_QueryNow);
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

        df_DataView = new WForm();
        df_DataView.wInit(false);
        df_DataView.setContentPane(viewPanel);
        df_DataView.center(null);
        df_DataView.setDefaultCloseOperation(WindowConstants.HIDE_ON_CLOSE);
    }

    // ----------------------------------------------------
    // 界面语言初始化
    // ----------------------------------------------------
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
    private WForm df_DataView;
}
