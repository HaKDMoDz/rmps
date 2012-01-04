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
public class LoginRequestReplyPacket extends BasicInPacket {
	public byte replyCode;
	public String replyMessage;
	// 响应令牌
	public byte[] answerToken;
	public byte[] pngToken;
	public byte hasPngData;
	public byte next;
	public byte[] pngData;
	
    /**
     * 构造函数
     * @param buf 缓冲区
     * @param length 包长度
     * @throws PacketParseException 解析错误
     */
    public LoginRequestReplyPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }   
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.InPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Request Reply Packet";
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
        replyCode = buf.get(); //03: ok   04: need verifying
        buf.get(); //00
        buf.get(); //05
        hasPngData = buf.get();
        buf.getInt();	//需要验证码时为00 00 01 23，不需要时为全0
        next = 0;
        
        // 令牌长度
        int len = buf.getChar();
        // 令牌
        answerToken = new byte[len];
        buf.get(answerToken);
        
        if (hasPngData == 1) { //there's data for the png picture
        	len = buf.getChar();
        	pngData = new byte[len];
        	buf.get(pngData);
        	buf.get();
        	next = buf.get();
        	
//        	char path[PATH_LEN];
//    		sprintf( path, "%s/%u.png", qq->verify_dir, qq->number );
//    		FILE *fp;
//    		if( next ){
//    			fp = fopen( path, "wb" );
//    		}else{
//    			fp = fopen( path, "ab" );
//    			DBG("got png at %s", path );
//    		}
//    		if( fp ){
//    			fwrite( data, len, 1, fp );
//    			fclose( fp );
//    		}
//    		DEL( data );
        	
        	len = buf.getChar();
        	pngToken = new byte[len];
        	buf.get(pngToken);
        }
        
    	//parse the data we got
//    	if( pngData>0 ){
//    		if( next>0){
//    			prot_login_request( qq, &png_token, 0, 1 );
//    		}else{
//    			qq->data.verify_token = answer_token;
//    			qqclient_set_process( qq, P_VERIFYING );
//    		}
//    	} else {
//    		log.debug("process verify password");
//    		user.setAuthToken(answerToken);
//    		prot_login_verify( qq );
//    	}
        replyCode = 0;
    }
}
