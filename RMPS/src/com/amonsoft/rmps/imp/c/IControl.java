/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.imp.c;

import com.amonsoft.rmps.imp.b.ISession;
import com.amonsoft.rmps.imp.b.IMessage;
import com.amonsoft.rmps.imp.*;

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
public interface IControl
{
    /**
     * 登录完成时发生
     * @param session
     */
    void loginCompleted(ISession session);

    /**
     *
     * @param session
     */
    void contactListInitCompleted(ISession session);

    /**
     * 更新好友列表完成时发生
     */
    void contactListSyncCompleted(ISession session);

    /**
     * 打开一个聊天窗口时发生
     * @param session
     */
    void sessionOpened(ISession session);

    /**
     * 关闭一个聊天窗口时发生
     * @param session
     */
    void sessionClosed(ISession session);

    /**
     * 收到正常信息事件，主要用于用户对话时
     * @param session
     * @param message
     */
    void instantMessageReceived(ISession session, IMessage message);

    /**
     * 收到系统信息事件，主要用于系统登录时
     * @param session
     * @param message
     */
    void systemMessageReceived(ISession session, IMessage message);

    /**
     * 用户进行输入事件，当在联系人聊天窗口获得光标并按下第一个键时发生
     * @param session
     * @param message
     */
    void controlMessageReceived(ISession session, IMessage message);

    /**
     * 收到系统广播信息时发生
     * @param session
     * @param message
     */
    void datacastMessageReceived(ISession session, IMessage message);

    /**
     * 收到目前不能处理的信息时发生
     * @param session
     * @param message
     */
    void unknownMessageReceived(ISession session, IMessage message);

    void contactStatusChanged();

    void contactAddedMe();

    void contactRemovedMe();

    void contactJoinMeeting();

    void contactLeaveMeeting();

    /**
     * 异常时发生
     * @param session
     */
    void exceptionCaught(ISession session);

    /**
     * 注销时发生
     * @param session
     */
    void willLogout(ISession session);
}
