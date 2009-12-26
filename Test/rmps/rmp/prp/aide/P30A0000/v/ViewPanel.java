/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30A0000.v;

import rmp.prp.aide.P3030000.m.CodeData;
import cons.prp.aide.P3030000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class ViewPanel extends javax.swing.JPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 结果数据模型 */
    private CodeData tm_DataList;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    public ViewPanel()
    {
    }

    /**
     * @return
     */
    public boolean init()
    {
        ica();
        ita();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
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
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    private void ica()
    {
        javax.swing.JScrollPane sp_DataList = new javax.swing.JScrollPane();
        tb_DataList = new javax.swing.JTable();

        tm_DataList = new CodeData();
        tb_DataList.setModel(tm_DataList);

        sp_DataList.setViewportView(tb_DataList);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_DataList, javax.swing.GroupLayout.DEFAULT_SIZE, 202, Short.MAX_VALUE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addComponent(sp_DataList, javax.swing.GroupLayout.DEFAULT_SIZE, 136, Short.MAX_VALUE).addContainerGap()));
    }

    /**
     * 
     */
    private void ita()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面构件区域
    // ////////////////////////////////////////////////////////////////////////
    /** 结果显示表格 */
    private javax.swing.JTable tb_DataList;
    /** serialVersionUID */
    private static final long serialVersionUID = 7178484293596134411L;
}
