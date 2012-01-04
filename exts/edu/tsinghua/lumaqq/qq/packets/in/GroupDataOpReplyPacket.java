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
package edu.tsinghua.lumaqq.qq.packets.in;

import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.List;

import edu.tsinghua.lumaqq.qq.QQ;
import edu.tsinghua.lumaqq.qq.Util;
import edu.tsinghua.lumaqq.qq.beans.QQUser;
import edu.tsinghua.lumaqq.qq.packets.BasicInPacket;
import edu.tsinghua.lumaqq.qq.packets.PacketParseException;

/**
 * <pre>
 * 下载分组名称的回复包，格式为
 * 1. 头部
 * 2. 子命令，1字节，下载是0x1
 * 3. 回复码，1字节
 * 5. 未知的1�7�节
 * 6. 组序号，仄1�7�1�7始，0表示我的好友组，因为是缺省组，所以不包含在包丄1�7
 * 7. 16字节的组信息，开始是组名，以0结尾，如果长度不趄1�7字节，则其余部分可能丄1�7�也可能
 *    为其他字节，含义不明
 * 8. 若有多个组，重复6＄1�7�分
 * 9. 尾部
 * 
 * 上传分组名称的回复包，格式为
 * 1. 头部
 * 2. 子命令，1字节
 * 3. 回复码，1字节
 * 4. 组需要，仄1�7�1�7始，0表示我的好友组，因为是缺省组，所以不包含在包丄1�7
 * 5. 如果有更多组，重处1�7�分
 * 6. 尾部
 * </pre>
 *  
 * @author luma
 */
public class GroupDataOpReplyPacket extends BasicInPacket {
	public List<String> groupNames;
	public List<Integer> groupSeqs;
	public byte subCommand;
	public byte replyCode;
	
    /**
     * 构�1�7�函敄1�7
     * @param buf 缓冲匄1�7
     * @param length 包长庄1�7
     * @throws PacketParseException 解析错误
     */
    public GroupDataOpReplyPacket(ByteBuffer buf, int length, QQUser user) throws PacketParseException {
        super(buf, length, user);
    }   
    
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.OutPacket#getPacketName()
     */
	@Override
    public String getPacketName() {
        switch(subCommand) {
            case QQ.QQ_SUB_CMD_UPLOAD_GROUP_NAME:
                return "Group Data Reply Packet - Upload Group";
            case QQ.QQ_SUB_CMD_DOWNLOAD_GROUP_NAME:
                return "Group Data Reply Packet - Download Group";
            default:
                return "Group Data Reply Packet - Unknown Sub Command";
        }
    }
	
    /* (non-Javadoc)
     * @see edu.tsinghua.lumaqq.qq.packets.InPacket#parseBody(java.nio.ByteBuffer)
     */
	@Override
    protected void parseBody(ByteBuffer buf) throws PacketParseException {
    	// 得到操作类型
    	subCommand = buf.get();
    	// 回复码
    	replyCode = buf.get();
    	if(replyCode == QQ.QQ_REPLY_OK) {
	    	// 如果是下载包，继续解析内容
	    	if(subCommand == QQ.QQ_SUB_CMD_DOWNLOAD_GROUP_NAME) {
	        	// 创建list
	        	groupNames = new ArrayList<String>();
	        	groupSeqs = new ArrayList<Integer>();
	        	// 未知4个字节
	    	    buf.getInt(); 
	    	    buf.getChar();
	        	// 读取每个组名
	    	    while(buf.hasRemaining()) {
	    	        int groupSeq = buf.get(); 
	    	        buf.get(); //未知，与groupSeq相同
	    	        int length = buf.get();
	    	        groupNames.add(Util.getString(Util.getBytes(buf, length), "utf-8"));
	    	        groupSeqs.add(groupSeq);
	    	    }
	    	}
    	}
    }
}
