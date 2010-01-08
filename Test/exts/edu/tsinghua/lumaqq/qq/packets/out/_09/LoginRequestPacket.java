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
 * 请求登录令牌的包，格式为：
 * 
 * ***** 格式1 *******
 * 头部
 * 随机密钥，16字节
 * ---------- 加密开始(使用2部分的随机密钥) -----------
 * 子命令，1字节, 0x01, 表示QQ_SUB_CMD_LOGIN_AUTH
 * 未知2字节，0x0005
 * 未知4字节，0x00000000
 * ---------- 加密结束 ----------- 
 * 尾部
 * 
 * ******* 格式2 *******
 * 头部
 * 随机密钥，16字节
 * ---------- 加密开始(使用2部分的随机密钥) -----------
 * 子命令，1字节, 0x02, 表示QQ_SUB_CMD_SUBMIT_VERIFY_CODE
 * 未知2字节，0x0005
 * 未知4字节，0x00000000
 * 验证码长度，2字节 
 * 验证码字符串，如果想刷新验证码字符串，就在这里乱填一个，像QQ，填的是"2006"
 * 验证码图片令牌长度，2字节 
 * 验证码图片令牌
 * ---------- 加密结束 ----------- 
 * 尾部
 * </pre>
 * 
 * @author luma
 */
public class LoginRequestPacket extends BasicOutPacket {
	private byte subCommand;
	private byte[] puzzleToken;
	private String verifyCode;
	public byte[] pngToken;
	public byte hasPngData;
	private byte[] code;
	
    /**
     * 构造函数
     */
    public LoginRequestPacket(QQUser user) {
        super(QQ.QQ09_CMD_LOGIN_REQUEST, true, user);
    }
    
    public LoginRequestPacket(QQUser user, byte[] pngTocken, byte[] code, byte hasPngData) {
        super(QQ.QQ09_CMD_LOGIN_REQUEST, true, user);
        this.hasPngData = hasPngData;
        this.pngToken = pngTocken;
        this.code = code;
    }

    /**
     * @param buf
     * @param length
     * @throws PacketParseException
     */
    public LoginRequestPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Request Packet";
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
	
	@Override
	protected int getEncryptStart() {
		return QQ.QQ_LENGTH_KEY;
	}
	
	@Override
	protected int getDecryptStart() {
		return QQ.QQ_LENGTH_KEY;
	}
	
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#putBody(java.nio.ByteBuffer)
     */
	@Override
    protected void putBody(ByteBuffer buf) {
		buf.put(user.getInitKey());
		
		buf.putChar((char)0x0001);
		buf.put(QQ.QQ09_LOCALE );
		buf.put(QQ.QQ09_VERSION_SPEC );
		buf.putChar((char)user.getLoginToken().length);
		buf.put(user.getLoginToken());
		
		if( code == null )
			buf.put((byte) 3 );
		else
			buf.put((byte) 4 );
		
		buf.put((byte) 0 );
		buf.put((byte) 5 );
		buf.putInt( 0 );
		
		buf.put( hasPngData );
		
		if (code !=null && pngToken!= null) {
			buf.put((byte) 4 );
			buf.put(code);
			buf.putChar((char)pngToken.length);
			buf.put(pngToken);
		} else if (pngToken!= null && hasPngData==1) {
			buf.putChar((char)pngToken.length);
			buf.put(pngToken);
		} else {
			buf.put((byte) 0 );
			buf.put((byte) 0 );
		}
		
//		if( code && tok ){
//			put_byte( buf, 4 );
//			put_int( buf, htonl( code ) );
//			//answer token
//			put_word( buf, tok->len );
//			put_data( buf, tok->data, tok->len );
//		}else if( png_data && tok ){
//			//png token
//			put_word( buf, tok->len );
//			put_data( buf, tok->data, tok->len );
//		}else{
//			put_byte( buf, 0 );
//			put_byte( buf, 0 );
//		}
		
    }

	public byte getSubCommand() {
		return subCommand;
	}

	public void setSubCommand(byte subCommand) {
		this.subCommand = subCommand;
	}

	public byte[] getPuzzleToken() {
		return puzzleToken;
	}

	public void setPuzzleToken(byte[] puzzleToken) {
		this.puzzleToken = puzzleToken;
	}

	public String getVerifyCode() {
		return verifyCode;
	}

	public void setVerifyCode(String verifyCode) {
		this.verifyCode = verifyCode;
	}
}
