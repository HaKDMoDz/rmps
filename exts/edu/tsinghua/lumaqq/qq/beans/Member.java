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

import edu.tsinghua.lumaqq.qq.QQ;

/**
 * 得到群信息中的成员信息bean
 * 
 * @author luma
 */
public class Member {
	public int qq;
	public int organization;
	public byte role;
	
	public void readBean(ByteBuffer buf) {
		qq = buf.getInt();
		organization = buf.get() & 0xFF;
		role = buf.get();
 	}
	
	public void readTempBean(ByteBuffer buf) {
		qq = buf.getInt();
		organization = buf.get() & 0xFF;
		role = 0;
	}
	
	public boolean isAdmin() {
		return (role & QQ.QQ_ROLE_ADMIN) != 0;
	}
	
	public boolean isStockholder() {
		return (role & QQ.QQ_ROLE_STOCKHOLDER) != 0;
	}
}
