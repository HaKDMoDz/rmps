/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.face;

import java.util.EventObject;

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
public interface WBackCall
{
    /**
     * 系统回调函数，用于激发相应的事件处理程序，响应用户动作
     * 
     * @param event
     * @param object
     * @param property
     *            TODO
     */
    void wAction(EventObject event, Object object, String property);
}
