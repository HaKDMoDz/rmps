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
package edu.tsinghua.lumaqq.qq.packets.out._09;

import java.nio.ByteBuffer;

import edu.tsinghua.lumaqq.qq.QQ;
import edu.tsinghua.lumaqq.qq.beans.QQUser;
import edu.tsinghua.lumaqq.qq.packets.BasicOutPacket;
import edu.tsinghua.lumaqq.qq.packets.PacketParseException;


/**
 * <pre>
 * QQ登录请求包，格式为
 * 1. 头部
 * 2. 初始密钥，16字节
 * ----------- 加密开始（使用上一部分的密钥）------------
 * 3. 用户的密码密钥加密一个空串得到的16字节
 * 4. 35字节的固定内容，未知含义
 * 5. 未知1字节
 * 6. 登录状态，隐身登录还是什么，1字节
 * 7. 16字节固定内容，未知含义
 * 8. 未知1字节，0x01
 * 9. 未知4字节
 * 10. 未知4字节
 * 11. 16字节固定内容
 * 12. 登录令牌长度，1字节
 * 13. 登录令牌
 * 14. 登录模式，1字节，目前只支持普通模式
 * 15. 后面的内容不是固定内容，但是可以近似认为其是固定的，321字节
 * ---------- 加密结束 ----------------
 * 16. 尾部
 * </pre>
 *
 * @author luma
 */
public class LoginTouchPacket extends BasicOutPacket {
    /**
     * 构造函数
     */
    public LoginTouchPacket(QQUser user) {
        super(QQ.QQ09_CMD_LOGIN_TOUCH, true, user);
    }
	
    /**
     * @param buf
     * @param length
     * @throws PacketParseException
     */
    public LoginTouchPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Touch Packet";
    }
	
	@Override
	protected int getEncryptStart() {
		return QQ.QQ_LENGTH_KEY;
	}
	
	@Override
	protected int getDecryptStart() {
		return QQ.QQ_LENGTH_KEY;
	}
	
	@Override
	public byte[] getDecryptKey(byte[] body) {
		byte[] key = new byte[QQ.QQ_LENGTH_KEY];
		System.arraycopy(body, 0, key, 0, QQ.QQ_LENGTH_KEY);
		return key;
	}
	
	@Override
	public byte[] getEncryptKey(byte[] body) {
		byte[] key = new byte[QQ.QQ_LENGTH_KEY];
		System.arraycopy(body, 0, key, 0, QQ.QQ_LENGTH_KEY);
		return key;
	}
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#putBody(java.nio.ByteBuffer)
     */
	@Override
    protected void putBody(ByteBuffer buf) {
        // 初始密钥
        buf.put(user.getInitKey());
		
        buf.putChar((char)0x0001);
		buf.put(QQ.QQ09_LOCALE );
		buf.put(QQ.QQ09_VERSION_SPEC );
		buf.put(QQ.QQ09_ZEROS15);
    }
}
