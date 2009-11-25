/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3030000.v;

import rmp.comn.tray.C3010000.C3010000;
import rmp.prp.aide.P3030000.P3030000;
import rmp.prp.aide.P3030000.m.CodeData;
import rmp.ui.form.DForm;
import rmp.util.BeanUtil;
import rmp.util.CheckUtil;
import rmp.util.MesgUtil;
import cons.prp.aide.P3030000.ConstUI;
import cons.prp.aide.P3030000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 编码查询内嵌面板
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class TailPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    private P3030000 ms_MainSoft;
    /**  */
    private javax.swing.JPanel tp_TailPanel;
    /** 结果数据模型 */
    private CodeData tm_DataList;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * @param soft
     * @param panel
     */
    public TailPanel(P3030000 soft, javax.swing.JPanel panel)
    {
        this.ms_MainSoft = soft;
        this.tp_TailPanel = panel;
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

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 布局管理区域
    // ----------------------------------------------------
    /**
     * 查询界面用户交互区域初始化
     */
    private void ica()
    {
        java.awt.GridBagConstraints gbc = new java.awt.GridBagConstraints();

        tf_CharCode = new javax.swing.JTextField();
        bt_CharCode = new javax.swing.JButton();

        tp_TailPanel.setLayout(new java.awt.GridBagLayout());

        tf_CharCode.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                tf_CharCode_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gbc.weightx = 1.0;
        gbc.insets = new java.awt.Insets(5, 5, 5, 5);
        tp_TailPanel.add(tf_CharCode, gbc);

        bt_CharCode.setMnemonic('Q');
        bt_CharCode.setText("查询(Q)");
        bt_CharCode.setMargin(new java.awt.Insets(1, 7, 1, 7));
        bt_CharCode.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                bt_CharCode_Handler(evt);
            }
        });
        gbc.fill = java.awt.GridBagConstraints.NONE;
        gbc.weightx = 0.0;
        gbc.insets = new java.awt.Insets(5, 0, 5, 5);
        tp_TailPanel.add(bt_CharCode, gbc);
    }

    /**
     * 
     */
    private void icb()
    {
        javax.swing.JPanel viewPanel = new javax.swing.JPanel();

        javax.swing.JScrollPane sp_DataList = new javax.swing.JScrollPane();
        tb_DataList = new javax.swing.JTable();

        tm_DataList = new CodeData();
        tb_DataList.setModel(tm_DataList);

        sp_DataList.setViewportView(tb_DataList);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(viewPanel);
        viewPanel.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_DataList,
                javax.swing.GroupLayout.DEFAULT_SIZE, 202, Short.MAX_VALUE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_DataList,
                javax.swing.GroupLayout.DEFAULT_SIZE, 136, Short.MAX_VALUE).addContainerGap()));

        df_Dialog = new DForm(C3010000.queryRef("prp"));
        df_Dialog.wInit();
        df_Dialog.setContentPane(viewPanel);
        df_Dialog.setTitle(ms_MainSoft.wGetTitle());
        df_Dialog.pack();
        df_Dialog.center();
        df_Dialog.setDefaultCloseOperation(DForm.DISPOSE_ON_CLOSE);
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 界面语言显示
     */
    private void ita()
    {
        BeanUtil.setWText(tf_CharCode, P3030000.getMesg(LangRes.FILD_TEXT_CHARCODE));
        BeanUtil.setWTips(tf_CharCode, P3030000.getMesg(LangRes.FILD_TIPS_CHARCODE));
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
     * 文本查询事件处理
     * 
     * @param evt
     */
    private void tf_CharCode_Handler(java.awt.event.ActionEvent evt)
    {
        queryData();
    }

    /**
     * 按钮查询事件处理
     * 
     * @param evt
     */
    private void bt_CharCode_Handler(java.awt.event.ActionEvent evt)
    {
        queryData();
    }

    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 数据查询
     */
    private void queryData()
    {
        String text = this.tf_CharCode.getText();
        if (!CheckUtil.isValidate(text))
        {
            MesgUtil.showMessageDialog(tp_TailPanel, "查询内容不能为空，请重新输入！");
            this.tf_CharCode.requestFocus();
            return;
        }

        // 是否第一次显示界面
        if (df_Dialog == null)
        {
            icb();
            itb();
        }

        // 窗口可见性设置
        if (!df_Dialog.isVisible())
        {
            df_Dialog.setVisible(true);
        }
        else
        {
            df_Dialog.toFront();
        }

        // 数据查询
        try
        {
            setData(text);
        }
        catch (NumberFormatException exp)
        {
            MesgUtil.showMessageDialog(tp_TailPanel, exp.getMessage());
            this.tf_CharCode.requestFocus();
            return;
        }
    }

    /**
     * @param userData
     */
    public void setData(String userData) throws NumberFormatException
    {
        String temp = userData.toLowerCase();
        // 数值查询n:
        if (temp.startsWith(ConstUI.QUERY_NUM))
        {
            userData = temp.substring(ConstUI.QUERY_NUM.length());
            int spIndx = userData.indexOf(ConstUI.QUERY_SP);

            tm_DataList.setCharModel(false);
            if (0 < spIndx && spIndx < userData.length() - 1)
            {
                tm_DataList.setSttChar(userData.substring(0, spIndx));
                tm_DataList.setEndChar(userData.substring(spIndx + 1));
            }
            else
            {
                tm_DataList.setSttChar(userData);
                tm_DataList.setEndChar(userData);
            }
            tm_DataList.fireTableDataChanged();
            return;
        }

        // 字符查询c:
        if (temp.startsWith(ConstUI.QUERY_CHAR))
        {
            userData = userData.substring(ConstUI.QUERY_CHAR.length());
        }
        tm_DataList.setCharModel(true);
        tm_DataList.setUsrChar(userData);
        tm_DataList.fireTableDataChanged();
    }
    // ////////////////////////////////////////////////////////////////////////
    // 界面构件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 查询按钮 */
    private javax.swing.JButton bt_CharCode;
    /** 用户输入文本框 */
    private javax.swing.JTextField tf_CharCode;
    /** 结果显示表格 */
    private javax.swing.JTable tb_DataList;
    /** 查询结果显示对话框 */
    private DForm df_Dialog;
}
