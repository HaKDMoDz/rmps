/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.imp.b;

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
public interface IMessage
{
    /**
     * 获取当前消息的唯一标记
     * @return
     */
    String getMessageUID();

    /**
     * 获取当前消息的主题
     * @return
     */
    String getSubject();

    /**
     * 设置当前消息的主题
     * @param subject
     */
    void setSubject(String subject);

    /**
     * 获取当前消息内容
     * @return
     */
    String getContent();

    /**
     * 设置当前消息内容
     * @param content
     */
    void setContent(String content);

    /**
     * 获取当前消息的MIME类型
     * @return
     */
    String getContentType();

    /**
     * 设置当前消息的MIME类型
     * @param contentType
     */
    void setContentType(String contentType);

    /**
     * 设置消息的编码格式
     * @return
     */
    String getEncoding();

    /**
     * 设置消息的编码格式
     * @param encoding
     */
    void setEncoding(String encoding);

    /**
     * 获取当前消息的字节信息
     * @return
     */
    byte[] getRawData();
}
