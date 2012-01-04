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
import edu.tsinghua.lumaqq.qq.Util;
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
public class LoginSendInfoPacket extends BasicOutPacket {
    /**
     * 构造函数
     */
    public LoginSendInfoPacket(QQUser user) {
        super(QQ.QQ09_CMD_LOGIN_SEND_INFO, true, user);
    }
	
    /**
     * @param buf
     * @param length
     * @throws PacketParseException
     */
    public LoginSendInfoPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Send Info Packet";
    }
	
	@Override
	public byte[] getEncryptKey(byte[] body) {
		return user.getLoginInfoKey1();
	}
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#putBody(java.nio.ByteBuffer)
     */
	@Override
    protected void putBody(ByteBuffer buf) {
		byte unknown5[] = {0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01 };
		byte unknown6[] = {(byte)0x74,(byte)0xB5,(byte)0x30,(byte)0x99,(byte)0x9D,(byte)0xAF,(byte)0xBC,(byte)0xBE,
				(byte)0x4F,(byte)0x9D,(byte)0xB8,(byte)0x24,(byte)0xEF,(byte)0xF6,(byte)0x10,(byte)0xCC};
		byte unknown7[] = {(byte)0x94,(byte)0x54,(byte)0xE0,(byte)0xF2,(byte)0x48,(byte)0xF3,(byte)0x61,
				(byte)0x8B,(byte)0xF7,(byte)0x15,(byte)0x9E,(byte)0x92,(byte)0x38,(byte)0x4B,(byte)0xFB,(byte)0xEC};
		
		buf.putChar((char) 0x0001 );
		buf.put(QQ.QQ09_VERSION_SPEC);
		buf.put(user.getLoginInfoUnknow2());
		buf.putInt(user.getServerTime());
		buf.put(user.getIp());
		buf.putInt( 00000000 );
		buf.putChar((char)user.getLoginInfoLarge().length);
		buf.put(user.getLoginInfoLarge());
		for (int i=0; i<35; i++) { //35 zeros
			buf.put((byte)0);
		}
		buf.put( QQ.QQ09_EXE_HASH );
		byte[] rand = new byte[1];
		Util.random().nextBytes(rand);
		buf.put(rand);	//unknown important byte
		buf.put( user.getLoginMode() );
		buf.put( unknown5 );
		buf.put(QQ.QQ09_ZEROS15);
		buf.put(QQ.QQ09_LOCALE);
		buf.position(buf.position() + 16);//16 zeros
		buf.putChar((char) user.getAuthToken().length );
		buf.put( user.getAuthToken() );
		buf.putInt( 0x00000007 );
		buf.putInt( 0x00000000 );
		buf.putInt( 0x08041001 );
		buf.put((byte) 0x40 );	//length of the following
		buf.put((byte) 0x01 );
		buf.putInt( Util.random().nextInt()  );
//		buf.putInt( 0x0741E9748  );
		buf.putChar((char) unknown6.length );
		buf.put( unknown6 );
		buf.put( new byte[]{0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x00} );
		buf.put(QQ.QQ09_ZEROS15);
		buf.put((byte) 0x02 );
		buf.putInt(Util.random().nextInt()  );
//		buf.putInt( 0x8BED382E  );
		buf.putChar((char)unknown7.length );
		buf.put( unknown7 );
		buf.position(buf.position() + 249);//all zeros
    }
}
