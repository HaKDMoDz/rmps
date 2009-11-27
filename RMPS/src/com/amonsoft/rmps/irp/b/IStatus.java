/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.irp.b;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface IStatus
{
    /**
     * 未知
     */
    int INIT = 0;
    /**
     * 在线
     */
    int LINE = 1;
    /**
     * 空闲
     */
    int IDLE = 2;
    /**
     * 离开
     */
    int AWAY = 3;
    /**
     * 隐身
     */
    int HIDE = 4;
    /**
     * 离线
     */
    int DOWN = 5;
    /**
     * 忙碌
     */
    int BUSY = 10;
    /**
     * 电话
     */
    int BUSY_PHONE = 0;
    /**
     * 午餐
     */
    int BUSY_LUNCH = 0;
}
