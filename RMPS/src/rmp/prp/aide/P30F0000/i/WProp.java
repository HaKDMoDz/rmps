/*
 * FileName:       WProp.java
 * CreateDate:     2008-3-23 下午05:09:11
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.i;

import rmp.face.WBean;
import rmp.prp.aide.P30F0000.b.PropItem;

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
 * 日期： 2008-3-23 下午05:09:11
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public interface WProp extends WBean
{
    /**
     * 设置要显示的对象信息
     * 
     * @param pi
     */
    void setPropItem(PropItem pi);

    /**
     * 
     */
    void requestFocus();
}
