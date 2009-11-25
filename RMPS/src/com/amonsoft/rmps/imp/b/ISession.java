/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.imp.b;

import com.amonsoft.bean.IProcess;
import com.amonsoft.rmps.imp.*;
import java.io.File;

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
public interface ISession
{
    /**
     * 发送正在处理信息
     */
    void send();

    /**
     * 发送纯文本消息
     * @param text
     */
    void send(String message);

    /**
     * 发送Message消息
     * @param message
     */
    void send(IMessage message);

    /**
     * 发送多媒体消息
     * @param message
     */
    void send(IMimeMessage message);

    /**
     * 发送文件
     * @param file
     */
    void send(File file);

    /**
     * 获取不同消息中新行信息
     * @return
     */
    String netLine();

    /**
     * 获取会话联系人
     * @return
     */
    IContact getContact();

    /**
     * 创建一个消息对象
     * @return
     */
    IMessage createMessage();

    /**
     * 创建一个多媒体消息对象
     * @return
     */
    IMimeMessage createMimeMessage();

    /**
     * 获取用户会话相关信息
     * @param key
     * @return
     */
    Object getAttribute(String key);

    /**
     * 会话状态数据保持
     * @param key
     * @param obj
     */
    void setAttribute(String key, Object obj);

    /**
     * 当前处理功能
     * @return
     */
    IProcess getProcess();
}
