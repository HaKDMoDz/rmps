/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.imp.m;

import com.amonsoft.rmps.imp.b.ISession;
import com.amonsoft.rmps.imp.b.IMessage;

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
public interface IService
{
    void doInit(ISession session, IMessage message);

    void doHelp(ISession session, IMessage message);

    void doDeal(ISession session, IMessage message);
}
