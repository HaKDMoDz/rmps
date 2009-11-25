/*
 * FileName:       TypeItem.java
 * CreateDate:     2008-3-1 下午01:46:20
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.b;

import java.util.List;

import javax.swing.tree.DefaultMutableTreeNode;

import rmp.bean.K1SV2S;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.t.Util;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

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
 * 日期： 2008-3-1 下午01:46:20
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class TypeItem extends DefaultMutableTreeNode
{
    /**
     * 
     */
    public TypeItem()
    {
        this(new K1SV2S(ConstUI.ROOT_HASH, P30F0000.getMesg(LangRes.P30F1201), P30F0000.getMesg(LangRes.P30F1201)));
    }

    /**
     * @param kvItem
     */
    public TypeItem(K1SV2S kvItem)
    {
        super(kvItem);
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.tree.DefaultMutableTreeNode#isLeaf()
     */
    public boolean isLeaf()
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see javax.swing.tree.DefaultMutableTreeNode#getChildCount()
     */
    public int getChildCount()
    {
        if (!hasLoaded)
        {
            loadChildren();
        }
        return super.getChildCount();
    }

    /**
     * 获取下级目录数据列表
     */
    private void loadChildren()
    {
        K1SV2S kvItem = (K1SV2S)getUserObject();
        if (kvItem != null)
        {
            List<K1SV2S> list = Util.readTypeList(kvItem.getK());
            if (list != null)
            {
                for (int i = 0, j = list.size(); i < j; i += 1)
                {
                    /*
                     * Don't use add() here, add calls insert(newNode,
                     * getChildCount()) so if you want to use add, just be sure
                     * to set hasLoaded = true first.
                     */
                    insert(new TypeItem(list.get(i)), i);
                }
            }
        }
        hasLoaded = true;
    }

    /**
     * @return
     */
    public boolean isLoaded()
    {
        return hasLoaded;
    }

    private boolean           hasLoaded;
    /** serialVersionUID */
    private static final long serialVersionUID = 2455059377199694231L;
}
