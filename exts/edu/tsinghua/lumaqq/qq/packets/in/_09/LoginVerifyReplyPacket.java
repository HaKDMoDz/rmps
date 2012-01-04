/*
* LumaQQ - Java QQ Client
*
* Copyright (C) 2004 luma <stubma@163.com>
*
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; either version 2 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
*/
package edu.tsinghua.lumaqq.qq.packets.in._09;

import java.nio.ByteBuffer;

import edu.tsinghua.lumaqq.qq.QQ;
import edu.tsinghua.lumaqq.qq.Util;
import edu.tsinghua.lumaqq.qq.beans.QQUser;
import edu.tsinghua.lumaqq.qq.packets.BasicInPacket;
import edu.tsinghua.lumaqq.qq.packets.PacketParseException;


/**
 * <pre>
 * QQ登陆应答包
 * 1. 头部
 * 2. 回复码, 1字节
 * 2部分如果是0x00
 * 3. session key, 16字节
 * 4. 用户QQ号，4字节
 * 5. 我的外部IP，4字节
 * 6. 我的外部端口，2字节
 * 7. 服务器IP，4字节
 * 8. 服务器端口，2字节
 * 9. 本次登录时间，4字节，为从1970-1-1开始的毫秒数除1000
 * 10. 未知的2字节
 * 11. 用户认证令牌,24字节
 * 12. 一个未知服务器1的ip，4字节
 * 13. 一个未知服务器1的端口，2字节
 * 14. 一个未知服务器2的ip，4字节
 * 15. 一个未知服务器2的端口，2字节
 * 16. 8个未知字节
 * 17. client key，32字节，这个key用在比如登录QQ家园之类的地方
 * 18. 12个未知字节
 * 19. 上次登陆的ip，4字节
 * 20. 上次登陆的时间，4字节
 * 21. 49个未知字节
 * 2部分如果是0x0A，表示重定向
 * 3. 用户QQ号，4字节
 * 4. 未知10字节，0x0101 0x0000 0x0001 0x0000 0x0000
 * 5. 重定向到的服务器IP，4字节
 * 2部分如果是0x09，表示登录失败
 * 3. 一个错误消息
 * </pre>
 *
 * @author luma
 */
public class LoginVerifyReplyPacket extends BasicInPacket {
	public byte replyCode;
	public String replyMessage;
	public byte[] loginToken;
	public int serverTime;
	public byte[] loginInfoUnknow1;
	public byte[] loginInfoData;
	public byte[] loginInfoMagic;
	public byte[] loginInfoKey1;
	public byte[] loginInfoKey3;
	
    /**
     * 构造函数
     * @param buf 缓冲区
     * @param length 包长度
     * @throws PacketParseException 解析错误
     */
    public LoginVerifyReplyPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }   
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.InPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Verify Reply Packet";
    }
	
	@Override
	public byte[] getDecryptKey(byte[] body) {
		return user.getPasswordKey();
	}
	
	@Override
	public byte[] getFallbackDecryptKey(byte[] body) {
		return user.getInitKey();
	}
        
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.InPacket#parseBody(java.nio.ByteBuffer)
     */
	@Override
    protected void parseBody(ByteBuffer buf) throws PacketParseException {
		buf.getChar();
        replyCode = buf.get();
        switch(replyCode) {
        case QQ.QQ_REPLY_OK:
            loginToken = Util.getToken(buf);
            loginInfoUnknow1 = Util.getBytes(buf, 4);
    		serverTime = buf.getInt(); //服务器时间
    		loginInfoData = Util.getToken(buf);
    		loginInfoMagic = Util.getToken(buf);
    		loginInfoKey1 = Util.getBytes(buf, 16);
    		buf.getChar();	//00 00
    		loginInfoKey3 = Util.getBytes(buf, 16);
    		buf.getChar();	//00 00
    		break;
    	default:
    		buf.position(11);
	    	int len = buf.getChar();
	    	byte[] msg = new byte[len];
	    	buf.get(msg);
	    	replyMessage = Util.getString(msg);
    		break;
        }
    }
}
