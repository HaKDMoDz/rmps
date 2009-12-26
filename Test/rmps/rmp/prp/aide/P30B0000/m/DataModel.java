/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30B0000.m;

import javax.swing.table.AbstractTableModel;

import rmp.bean.K1SV1S;

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
public class DataModel extends AbstractTableModel
{
    private java.util.List<java.util.HashMap<String, String>> dataList;
    private java.util.List<K1SV1S> nameList;

    /**
     * 
     */
    public DataModel()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getColumnCount()
     */
    @Override
    public int getColumnCount()
    {
        return nameList != null ? nameList.size() : 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getRowCount()
     */
    @Override
    public int getRowCount()
    {
        return dataList != null ? dataList.size() : 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getValueAt(int, int)
     */
    @Override
    public Object getValueAt(int rowIndex, int columnIndex)
    {
        if (dataList == null)
        {
            return dataList.get(rowIndex).get(nameList.get(columnIndex));
        }
        return "";
    }

    /**
     * @param list
     */
    public void setDataList(java.util.List<java.util.HashMap<String, String>> list)
    {
        this.dataList = list;
    }

    /**
     * @param list
     */
    public void setNameList(java.util.List<K1SV1S> list)
    {
        this.nameList = list;
    }
    /** serialVersionUID */
    private static final long serialVersionUID = 4864552477900497236L;
}
