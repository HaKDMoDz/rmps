package edu.tsinghua.lumaqq.qq.beans;

import edu.tsinghua.lumaqq.qq.Util;


public class IMMessage {
	private byte type; //01 pure text 02 face 03 image
	private byte[] messageBytes;
	private byte face;
	private byte[] picToken;
	private String encoding;
	
	public IMMessage(byte type, byte[] b) {
		this.type = type;
		switch(type) {
		case 01:
			messageBytes = b;
			break;
		case 02: 
			face = b[0];
			break;
		case 03:
			picToken = b;
			break;
		}
		this.encoding = "UTF-8";
	}
	
	public IMMessage(byte type, byte[] b, String encoding) {
		this.type = type;
		switch(type) {
		case 01:
			messageBytes = b;
			break;
		case 02: 
			face = b[0];
			break;
		case 03:
			picToken = b;
			break;
		}
		this.encoding = encoding;
	}
	public IMMessage(byte face) {
		this.type = 0x02;
		this.face = face;
		encoding = "UTF-8";
	}
	
	public byte getType() {
		return type;
	}
	public void setType(byte type) {
		this.type = type;
	}
	public byte[] getMessageBytes() {
		return messageBytes;
	}
	public void setMessageBytes(byte[] messageBytes) {
		this.messageBytes = messageBytes;
	}
	public byte getFace() {
		return face;
	}
	public void setFace(byte face) {
		this.face = face;
	}
	public byte[] getPicToken() {
		return picToken;
	}
	public void setPicToken(byte[] picToken) {
		this.picToken = picToken;
	}
	
	@Override
	public String toString() {
		switch(type) {
		case 01:
			return Util.getString(messageBytes, encoding);
		case 02: 
			return Util.convertByteToHexString(new byte[]{face});
		case 03:
			return "[图片]";
		default:
			return "[不支持格式]";
		}
	}
	public String getEncoding() {
		return encoding;
	}
	public void setEncoding(String encoding) {
		this.encoding = encoding;
	}
}
