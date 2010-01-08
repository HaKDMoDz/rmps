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
import java.util.ArrayList;
import java.util.List;

import edu.tsinghua.lumaqq.qq.beans.ClusterInfo;
import edu.tsinghua.lumaqq.qq.beans.QQFriend;
import edu.tsinghua.lumaqq.qq.beans.QQUser;
import edu.tsinghua.lumaqq.qq.packets.BasicInPacket;
import edu.tsinghua.lumaqq.qq.packets.PacketParseException;


/**
 *
 * @author Michael Liu
 */
public class LoginGetListReplyPacket extends BasicInPacket {
	 public boolean hasMore;
	 public List<QQFriend> friends;
	 public List<ClusterInfo> clusters;
	
    /**
     * 构造函数
     * @param buf 缓冲区
     * @param length 包长度
     * @throws PacketParseException 解析错误
     */
    public LoginGetListReplyPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }   
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.InPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        return "Login Get List Reply Packet";
    }
	
    @Override
    public byte[] getDecryptKey(byte[] body) {
    	return user.getLoginInfoKey2();
    }
    
    @Override
    public byte[] getFallbackDecryptKey(byte[] body) {
    	return null;
    }
        
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.InPacket#parseBody(java.nio.ByteBuffer)
     */
	@Override
    protected void parseBody(ByteBuffer buf) throws PacketParseException {
		friends = new ArrayList<QQFriend>();
		clusters = new ArrayList<ClusterInfo>();
		int len = buf.getChar(); //未知
		buf.getInt(); //00 00 00 00
		buf.getChar(); //可能是判断是否还有好友
		if( len == 0x038A ){
			hasMore = true;
		} else {
			hasMore = false;
		}
		while(buf.remaining()>2) { //2zeros in the end
			int number = buf.getInt();
			byte type = buf.get();
			int gid = buf.get();
			switch(type) {
			case 0x01: //好友
				QQFriend friend = new QQFriend();
				friend.qqNum = number;
				friend.groupSeq = gid/4;
				friends.add(friend);
				break;
			case 0x04: //群
				ClusterInfo cluster = new ClusterInfo();
				cluster.clusterId = number;
				cluster.externalId = number;
				clusters.add(cluster);
				break;
			}
		}
//		len = get_word( buf );	//00 9C
//		get_int( buf );	//00 00 00 00
//		next_pos = get_word( buf );
//		if( next_pos > 0x0000 ){
//			//Well, i don't know how to judge whether we have got the whole list, so I just 
//			//tested the length.
//			DBG("next_pos = %d", next_pos );
//			if( len == 0x038A ){
//				prot_login_get_list( qq, ++ qq->data.login_list_count );
//			}
//		}else{
//			prot_login_send_info( qq );
//		}
//		while( buf->pos < buf->len-2 ){	//2zeros in the end
//			uint number = get_int( buf );
//			uchar type = get_byte( buf );
//			uchar gid = get_byte( buf );
//			if( type == 0x04 )	//if it is a qun
//			{
//	#ifndef NO_QUN_INFO
//				qun_get( qq, number, 1 );
//	#endif
//			}else if( type == 0x01 ){
//	#ifndef NO_BUDDY_INFO
//				qqbuddy* b = buddy_get( qq, number, 1 );
//				if( b )
//					b->gid = gid / 4;
//	#endif
//			}
//			number = type = gid = 0;
//		}
    	
    }
}
