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
package edu.tsinghua.lumaqq.qq.beans;

import java.nio.ByteBuffer;

import edu.tsinghua.lumaqq.qq.packets.in.ReceiveIMPacket;

/**
 * 自定义头像变化信息Bean
 * 
 * @author luma
 * @see ReceiveIMPacket
 */
public class CustomHead {
	public int qq;
	public int timestamp;
	public byte[] md5;
	
	public void readBean(ByteBuffer buf) {
		qq = buf.getInt();
		timestamp = buf.getInt();
		md5 = new byte[16];
		buf.get(md5);
	}
}
