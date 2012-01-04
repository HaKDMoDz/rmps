/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.irp.m;

import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.b.IMessage;

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
    boolean wInit();

    String getCode();

    String getName();

    String getDescription();

    void doInit(ISession session, IMessage message);

    void doMenu(ISession session, IMessage message);

    void doHelp(ISession session, IMessage message);

    void doDeal(ISession session, IMessage message);

    void doStep(ISession session, IMessage message);

    void doExit(ISession session, IMessage message);
}
