/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P30A0000.m;

import java.util.HashMap;
import java.util.List;

import javax.swing.table.AbstractTableModel;

import cons.prp.aide.P30A0000.ConstUI;

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
    private List<HashMap<String, String>> dataList;

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getColumnCount()
     */
    @ Override
    public int getColumnCount()
    {
        return 10;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#getColumnName(int)
     */
    public String getColumnName(int column)
    {
        switch (column)
        {
            case 0:
                return "索引";
            case 1:
                return "航空公司";
            case 2:
                return "航班号";
            case 3:
                return "出发机场";
            case 4:
                return "到达机场";
            case 5:
                return "出发时间";
            case 6:
                return "到达时间";
            case 7:
                return "机型";
            case 8:
                return "经停";
            case 9:
                return "飞行周期";
            default:
                return "";
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getRowCount()
     */
    @ Override
    public int getRowCount()
    {
        return dataList != null ? dataList.size() : 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getValueAt(int, int)
     */
    @ Override
    public Object getValueAt(int rowIndex, int columnIndex)
    {
        if (dataList == null)
        {
            return "";
        }

        if (columnIndex == 0)
        {
            return rowIndex + 1;
        }

        return dataList.get(rowIndex).get(ConstUI.DATA_ITEM[columnIndex]);
    }

    /**
     * @param m
     */
    public void setDataModel(List<HashMap<String, String>> m)
    {
        this.dataList = m;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = 2560950666645822074L;
}
