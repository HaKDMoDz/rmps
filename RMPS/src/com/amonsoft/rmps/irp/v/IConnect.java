/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.irp.v;

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
public interface IConnect
{
    /**
     * 加载用户配置信息
     * @return
     */
    boolean load();

    /**
     * 获取登录用户
     * @return
     */
    String getUser();

    /**
     * 获取登录口令
     * @return
     */
    String getPwds();

    /**
     * 获取用户邮件
     * @return
     */
    String getMail();
}
