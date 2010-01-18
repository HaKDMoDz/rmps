/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.irp.b;

import java.util.List;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统入口
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface IContact
{
    /**
     * 用户索引
     * 
     * @return
     */
    String getId();

    /**
     * 用户代码
     * 
     * @return
     */
    String getCode();

    /**
     * 用户账户
     * 
     * @return
     */
    String getUser();

    /**
     * 用户名称
     * 
     * @return
     */
    String getName();

    /**
     * 显示名称
     * 
     * @return
     */
    String getDisplayName();

    /**
     * 电子邮件
     * 
     * @return
     */
    String getEmail();

    /**
     * 状态说明
     * 
     * @return
     */
    IPresence getPresence();

    /**
     * 个人消息
     * 
     * @return
     */
    String getPersonalMessage();

    /**
     * 获取用户所属的组
     * 
     * @return
     */
    List<ICatalog> getCatalogs();
}
