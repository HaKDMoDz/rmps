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

import rmp.util.LogUtil;
import edu.tsinghua.lumaqq.qq.QQ;
import edu.tsinghua.lumaqq.qq.Util;
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
public class LoginVerifyPacket extends BasicOutPacket {
	private byte subCommand;
	private byte[] puzzleToken;
	private String verifyCode;
	public byte[] pngToken;
	public byte pngData;
	
    /**
     * 构造函数
     */
    public LoginVerifyPacket(QQUser user) {
        super(QQ.QQ09_CMD_LOGIN_VERIFY, true, user);
    }
    
    public LoginVerifyPacket(QQUser user, byte[] pngTocken, byte pngData) {
        super(QQ.QQ09_CMD_LOGIN_VERIFY, true, user);
        this.pngData = pngData;
        this.pngToken = pngTocken;
    }

    /**
     * @param buf
     * @param length
     * @throws PacketParseException
     */
    public LoginVerifyPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Verify Packet";
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

		ByteBuffer verifyData = ByteBuffer.allocate(buf.limit());
		
		verifyData.putInt( Util.random().nextInt() );	//random??
		verifyData.putChar((char)0x0001 );
		verifyData.putInt(user.getQQ());
		verifyData.put(QQ.QQ09_VERSION_SPEC );
		verifyData.put((byte) 00 );
		verifyData.putChar((char) 00 );	//0x0001 什么来的？
		verifyData.put(user.getMd5pwd1()); //buf.put(crypter.encrypt("".getBytes(), user.getPasswordKey()));
		verifyData.putInt(user.getServerTime()); //put_int( verify_data, qq->server_time );
		verifyData.position(verifyData.position() + 13);
		verifyData.put(user.getServerIp());
		verifyData.putInt( 0 );
		verifyData.putInt( 0 );
		verifyData.putChar( (char) 0x0010 );
		verifyData.put( user.getInitKey() ); //verify_key1
		verifyData.put( user.getPasswordKey() ); //verify_key2
		
		if( verifyData.position() != 104 ){ LogUtil.log("Wrong pos!!!");	}
		//加密 verifyData
		byte[] encrypted = crypter.encrypt(verifyData.array(), 0, verifyData.position(), user.getMd5pwd2());
		
		//
		buf.put(user.getInitKey());
		buf.putChar( (char) 0x00DE );	//sub cmd?? 00CA-myqq
		buf.putChar( (char) 0x0001 );
		buf.put(QQ.QQ09_LOCALE );
		buf.put(QQ.QQ09_VERSION_SPEC );
		buf.putChar((char)user.getAuthToken().length );
		buf.put( user.getAuthToken() );
		
		buf.putChar( (char) encrypted.length );
		buf.put( encrypted);
		
//		buf.putChar( (char) 0x0000 );
//		buf.putChar( (char) 0x018B );
		
		buf.putChar( (char) 0x0014 );
		byte[] random = new byte[20];
		Util.random().nextBytes(random);
		buf.put(random);
		
		buf.put((byte) 0x01 );
		buf.put((byte) 0x77 );
		buf.put((byte) 0x2E );	//length of the following info
		byte unknown6[] = {0x74,(byte)0xB5,0x30,(byte)0x99,(byte)0x9D,(byte)0xAF,(byte)0xBC,(byte)0xBE,0x4F,(byte)0x9D,(byte)0xB8,0x24,(byte)0xEF,(byte)0xF6,0x10,(byte)0xCC};
		byte unknown7[] = {0x2B,(byte)0xB5,(byte)0x91,(byte)0xD5,0x02,0x3D,(byte)0xAE,0x1C,0x46,0x44,(byte)0x98,(byte)0xCE,0x6B,0x34,(byte)0xE0,0x5E};
		buf.put((byte) 0x01 );
		buf.putInt(Util.random().nextInt() );
		buf.putChar((char) unknown6.length  );
		buf.put( unknown6 );
		buf.put((byte) 0x02 );
		buf.putInt( Util.random().nextInt());
		buf.putChar((char) unknown7.length  );
		buf.put( unknown7 );
		buf.position(buf.position() + 0x0148);	//328 zeros
		
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
