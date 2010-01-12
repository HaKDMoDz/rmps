/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.irp.m;

import java.util.List;

import rmp.bean.K1SV1S;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.ISession;

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
public interface IService
{
    boolean wInit();

    String getCode();

    String getName();

    String getDescription();

    List<K1SV1S> getHelpTips();

    void doInit(ISession session, IMessage message);

    void doMenu(ISession session, IMessage message);

    void doHelp(ISession session, IMessage message);

    void doDeal(ISession session, IMessage message);

    void doStep(ISession session, IMessage message);

    void doExit(ISession session, IMessage message);

    void doRoot(ISession session, IMessage message);
}
