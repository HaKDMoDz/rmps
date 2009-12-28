/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.amon.data.A2010000.m;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import javax.swing.table.DefaultTableModel;

import rmp.comn.amon.data.A2010000.b.WDataBase;
import rmp.comn.amon.data.A2010000.t.Util;

import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.db.AmonCons;

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
public class WTableModel extends DefaultTableModel
{
    private String[] nameList;
    private List<String[]> dataList;

    /**
     * 
     */
    public WTableModel()
    {
        nameList = new String[]
        { "索引", "表格标记", "中文名称", "数据类型", "数据长度", "是否主键", "是否为空", "是否唯一", "默认数据", "参考外键", "类别标记", "所属系统", "创建者", "数据版本", "表格描述", "更新日期", "提交日期" };
        dataList = new ArrayList<String[]>();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#getColumnClass(int)
     */
    public Class<?> getColumnClass(int columnIndex)
    {
        return String.class;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getColumnCount()
     */
    public int getColumnCount()
    {
        return nameList.length;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getColumnName(int)
     */
    public String getColumnName(int columnIndex)
    {
        return nameList[columnIndex];
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getRowCount()
     */
    public int getRowCount()
    {
        return dataList != null ? dataList.size() : 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#getValueAt(int, int)
     */
    public Object getValueAt(int rowIndex, int columnIndex)
    {
        if (columnIndex == 0)
        {
            return rowIndex + 1;
        }
        return dataList != null ? dataList.get(rowIndex)[columnIndex - 1] : "";
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#isCellEditable(int, int)
     */
    public boolean isCellEditable(int rowIndex, int columnIndex)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.DefaultTableModel#setValueAt(java.lang.Object,
     * int, int)
     */
    public void setValueAt(Object value, int rowIndex, int columnIndex)
    {
    }

    /**
     * @param wdb
     * @param sid
     */
    public void viewData(WDataBase wdb, String sid)
    {
        Connection conn = Util.getConnection(wdb);

        dataList.clear();
        getRowList(conn, sid);

        Util.closeConnection(wdb, conn);

        fireTableStructureChanged();
    }

    /**
     * @param rowIndex
     * @return
     */
    public String[] getRowData(int rowIndex)
    {
        return dataList.get(rowIndex);
    }

    /**
     * @return
     */
    private void getRowList(Connection conn, String sid)
    {
        String sqlSelect = "SELECT * FROM " + AmonCons.A2010100;
        if (CharUtil.isValidate(sid))
        {
            if (sid.length() > 6)
            {
                sid = sid.substring(0, 6);
            }
            sid += '%';
            sqlSelect += CharUtil.format(" WHERE {0} LIKE '{1}'", AmonCons.A2010101, sid);
        }
        sqlSelect += CharUtil.format(" ORDER BY {0} ASC", AmonCons.A2010101);

        Statement stat = null;
        ResultSet rest = null;
        try
        {
            stat = conn.createStatement();
            rest = stat.executeQuery(sqlSelect);
            int size = nameList.length;
            String[] temp;
            while (rest.next())
            {
                temp = new String[size];
                for (int i = 1; i <= size; i += 1)
                {
                    temp[i - 1] = rest.getString(i);
                }
                dataList.add(temp);
            }
        }
        catch (SQLException exp)
        {
            exp.printStackTrace();
        }
        finally
        {
            // 关闭结果集
            try
            {
                if (rest != null)
                {
                    rest.close();
                }
            }
            catch (SQLException exp)
            {
                LogUtil.exception(exp);
            }

            // 关闭会话
            try
            {
                if (stat != null)
                {
                    stat.close();
                }
            }
            catch (SQLException exp)
            {
                LogUtil.exception(exp);
            }
        }
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -657512102410414086L;
}
