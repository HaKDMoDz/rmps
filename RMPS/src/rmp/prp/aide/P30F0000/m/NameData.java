/*
 * FileName:       NameData.java
 * CreateDate:     2008-3-22 上午01:07:37
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.m;

import java.util.ArrayList;
import java.util.List;

import javax.swing.AbstractListModel;

import rmp.bean.K1SV2S;
import rmp.prp.aide.P30F0000.t.Util;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-3-22 上午01:07:37
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class NameData extends AbstractListModel
{
    private List<K1SV2S> dataList;

    /**
     * 
     */
    public NameData()
    {
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        dataList = new ArrayList<K1SV2S>();
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.ListModel#getElementAt(int)
     */
    @ Override
    public Object getElementAt(int index)
    {
        return dataList.get(index);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.ListModel#getSize()
     */
    @ Override
    public int getSize()
    {
        return dataList != null ? dataList.size() : 0;
    }

    /**
     * 根据用户输入类别索引进行精确查询
     * 
     * @param typeHash
     */
    public void readNameByHash(String typeHash)
    {
        int s = dataList.size();
        dataList.clear();
        fireIntervalRemoved(this, 0, s);
        Util.readNameList(typeHash, dataList);
        s = dataList.size();
        fireIntervalAdded(this, 0, s);
    }

    /**
     * 根据用户输入密码名称进行模糊查询
     * 
     * @param keysName
     */
    public void readNameByName(String keysName)
    {
        int s = dataList.size();
        dataList.clear();
        fireIntervalRemoved(this, 0, s);
        Util.queryUserData(keysName, dataList);
        s = dataList.size();
        fireIntervalAdded(this, 0, s);
    }

    public void remove(String keysHash)
    {
        K1SV2S kv;
        for (int i = 0, j = dataList.size(); i < j; i += 1)
        {
            kv = dataList.get(i);
            if (keysHash.equals(kv.getK()))
            {
                dataList.remove(i);
                fireIntervalRemoved(this, 0, j);
                break;
            }
        }
    }

    /** serialVersionUID */
    private static final long serialVersionUID = 362630480968632844L;
}
