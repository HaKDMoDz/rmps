/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.m;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import javax.swing.table.AbstractTableModel;

import rmp.prp.aide.P3020000.b.FileBean;
import rmp.util.CheckUtil;
import cons.prp.aide.P3020000.LangRes;

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
public class DataModel extends AbstractTableModel
{
    private List<FileBean> fileList;

    /**
     * 
     */
    public DataModel()
    {
        fileList = new ArrayList<FileBean>();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getColumnCount()
     */
    @Override
    public int getColumnCount()
    {
        return 2;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.AbstractTableModel#getColumnName(int)
     */
    @Override
    public String getColumnName(int column)
    {
        if (column == 0)
        {
            return LangRes.TABL_HEAD_COLS0001;
        }
        if (column == 1)
        {
            return LangRes.TABL_HEAD_COLS0002;
        }
        return "";
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getRowCount()
     */
    @Override
    public int getRowCount()
    {
        return fileList.size();
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.table.TableModel#getValueAt(int, int)
     */
    @Override
    public Object getValueAt(int rowIndex, int columnIndex)
    {
        if (fileList == null)
        {
            return "";
        }

        if (columnIndex == 0)
        {
            return fileList.get(rowIndex).getSrcName();
        }
        return fileList.get(rowIndex).getDstName();
    }

    /**
     * 获得指定路径文件或文件夹的文件清单
     * 
     * @param filePath
     * @return
     */
    public boolean listFiles(String filePath)
    {
        // 清除已有文件列表
        fileList.clear();

        // 路径合法性判断
        if (!CheckUtil.isValidate(filePath))
        {
            return false;
        }

        File userFile = new File(filePath);

        // 指定文档不存在
        if (!userFile.exists())
        {
            return false;
        }

        // 指定文档不可读
        if (!userFile.canRead())
        {
            return false;
        }

        // 文件文档
        if (userFile.isFile())
        {
            fileList.add(new FileBean(userFile.getName()));
            return true;
        }

        // 文件夹文档
        if (userFile.isDirectory())
        {
            File[] list = userFile.listFiles();
            if (list == null)
            {
                return false;
            }
            for (int i = 0, j = list.length; i < j; i += 1)
            {
                fileList.add(new FileBean(list[i].getName()));
            }
            return true;
        }

        // 其它情况
        return false;
    }

    /**
     * @return the fileList
     */
    public List<FileBean> getFileList()
    {
        return fileList;
    }

    /**  */
    private static final long serialVersionUID = 4224116269868586503L;
}
