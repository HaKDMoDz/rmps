/*
* LumaQQ - Java QQ Client
*
* Copyright (C) 2004 notXX
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
package edu.tsinghua.lumaqq.qq.net;

import java.io.IOException;
import java.nio.ByteBuffer;
import java.nio.channels.ClosedChannelException;
import java.nio.channels.DatagramChannel;
import java.nio.channels.SelectableChannel;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.SocketChannel;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.Vector;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import edu.tsinghua.lumaqq.qq.packets.PacketParseException;

/**
 * 鍙戦�佹帴鏀剁嚎绋�
 * 
 * @author notxx
 */
public final class Porter extends Thread {
	/** Logger */
	private static final Log log = LogFactory.getLog(Porter.class);

	/** 绾跨▼鏄惁缁撴潫鐨勬爣蹇� */
	protected boolean shutdown = false;
	/** 绔彛閫夋嫨鍣� */
	protected Selector selector;
	
	// port鍒楄〃
	private List<IPort> ports;
	// proxy鍒楄〃
	private List<IProxy> proxies;
	
	// 杩炴帴閲婃斁璇锋眰
	private Queue<Object> disposeQueue;
	
	// 鏂拌繛鎺ヨ姹�
	private List<Object> newConnections;
	
	/**
	 * 鏋勯�犱竴涓狿orter.
	 */
	public Porter() {
		super("Porter");
	    ports = new ArrayList<IPort>();
	    proxies = new ArrayList<IProxy>();
	    newConnections = new Vector<Object>();
	    disposeQueue = new LinkedList<Object>();
		setName("Porter");
		setDaemon(true);
	    // 鍒涘缓鏂扮殑Selector
		try {
			selector = Selector.open();
		} catch (IOException e) {
			log.debug(e);
			throw new RuntimeException(e);
		}
	}
	
	/**
	 * 娉ㄥ唽涓�涓猵ort鍒皃orter涓�
	 * 
	 * @param port
	 * 		IPort瀹炵幇
	 * @throws ClosedChannelException
	 * 		濡傛灉娉ㄥ唽澶辫触
	 */
	public void register(IPort port) throws ClosedChannelException {
	    SelectableChannel channel = port.channel();
	    if(channel instanceof SocketChannel)
		    channel.register(selector, SelectionKey.OP_CONNECT, port.getNIOHandler());
	    else if(channel instanceof DatagramChannel)
		    channel.register(selector, SelectionKey.OP_READ, port.getNIOHandler());
	    if(!ports.contains(port))
	        ports.add(port);
	}
	
	/**
	 * 浠ユ寚瀹氱殑鎿嶄綔娉ㄥ唽channel
	 * 
	 * @param port
	 * @param ops
	 * @throws ClosedChannelException
	 */
	public void register(IPort port, int ops) throws ClosedChannelException {
	    SelectableChannel channel = port.channel();
	    if(channel instanceof SocketChannel)
		    channel.register(selector, ops, port.getNIOHandler());
	    else if(channel instanceof DatagramChannel)
		    channel.register(selector, ops, port.getNIOHandler());
	    if(!ports.contains(port))
	        ports.add(port);
	}
	
	/**
	 * 娉ㄥ唽涓�涓唬鐞嗭紝鐢ㄥ湪浠ｇ悊楠岃瘉涓�
	 * 
	 * @param proxy
	 * 		IProxy瀹炵幇绫�
	 * @throws ClosedChannelException
	 * 		濡傛灉娉ㄥ唽澶辫触
	 */
	public void register(IProxy proxy) throws ClosedChannelException {
	    SelectableChannel channel = proxy.channel();
	    if(channel instanceof SocketChannel)
		    channel.register(selector, SelectionKey.OP_CONNECT, proxy.getNIOHandler());
	    else if(channel instanceof DatagramChannel)
		    channel.register(selector, SelectionKey.OP_READ, proxy.getNIOHandler());
	    if(!proxies.contains(proxy))
	        proxies.add(proxy);
	}
	
	/**
	 * 鍒犻櫎涓�涓猵ort锛岃繖涓猵ort鐨刢hannel灏嗚鍏抽棴
	 * 
	 * @param port
	 * 		IPort瀹炵幇
	 * @throws IOException
	 */
	private void deregister(IPort port) {
		if(port == null)
			return;
		
	    if(!ports.remove(port))
	    	return;
    	SelectionKey key = port.channel().keyFor(selector);
    	if(key != null)
    		key.cancel();
        port.dispose();
	}
	
	/**
	 * 鍒犻櫎涓�涓猵roxy
	 * 
	 * @param proxy
	 */
	private void deregister(IProxy proxy) {
		if(proxy == null)
			return;
		
	    if(!proxies.remove(proxy))
	    	return;
    	SelectionKey key = proxy.channel().keyFor(selector);
    	if(key != null)
    		key.cancel();
        proxy.dispose();
	}
	
	/**
	 * 鍙戦�侀敊璇簨浠跺埌鎵�鏈塸ort
	 * 
	 * @param e
	 * 		鍖呭惈閿欒淇℃伅鐨凟xception
	 */
	private void dispatchErrorToAll(Exception e) {
		for(IPort port : ports)
			port.getNIOHandler().processError(e);
	    for(IProxy proxy: proxies)
			proxy.getNIOHandler().processError(e);
	}
	
	/**
	 * 閫氱煡鎵�鏈塸ort鍙戦�佸寘
	 * @throws IOException
	 */
	private void notifySend() {
	    int size = ports.size();
	    for(int i = 0; i < size; i++) {
	        INIOHandler handler = null;
	        try {
		        handler = (ports.get(i)).getNIOHandler();
                handler.processWrite();
            } catch (IOException e) {
	            log.error(e.getMessage());
	            handler.processError(e);
            } catch (IndexOutOfBoundsException e) {                
            }
	    }
	    
	    size = proxies.size();
	    for(int i = 0; i < size; i++) {
	        INIOHandler handler = null;
	        try {
		        handler = (proxies.get(i)).getNIOHandler();
                handler.processWrite();
            } catch (IOException e) {
	            log.error(e.getMessage());
	            handler.processError(e);
            } catch (IndexOutOfBoundsException e) {                
            }
	    }
	}
	
	/**
	 * 涓嶆柇杩愯浆缁存姢鎵�鏈夋敞鍐岀殑IPort瀵硅薄.
	 * 閫氳繃璋冪敤瀹冧滑鐨勫嚑涓嚱鏁板垎鍒仛鍒版竻绌哄彂閫侀槦鍒�/濉厖鎺ユ敹闃熷垪/缁存姢闃熷垪鐨勫姛鑳�.
	 * @see IPort#send(ByteBuffer)
	 * @see IPort#receive(ByteBuffer)
	 * @see IPort#maintain()
	 */
	@Override
	public void run() {
		log.debug("Porter宸茬粡鍚姩");	

		int n = 0;
	    while(!shutdown) {
	        // do select
            try {
                n = selector.select(3000);
                // 濡傛灉瑕乻hutdown锛屽叧闂璼elector閫�鍑�
                if (shutdown) {
                    selector.close();
                	break;			        
                }
            } catch (IOException e) {
	            log.error(e.getMessage());
	            dispatchErrorToAll(e);
            } 
            
            // 澶勭悊杩炴帴閲婃斁璇锋眰
            processDisposeQueue();
            
		    // 濡傛灉select杩斿洖澶т簬0锛屽鐞嗕簨浠�
		    if(n > 0) {
		        for (Iterator<SelectionKey> i = selector.selectedKeys().iterator(); i.hasNext();) {
					// 寰楀埌涓嬩竴涓狵ey
					SelectionKey sk = i.next();
					i.remove();
					// 妫�鏌ュ叾鏄惁杩樻湁鏁�
	                if(!sk.isValid())
	                    continue;

					// 澶勭悊
					INIOHandler handler = (INIOHandler)sk.attachment();
		            try {
                        if(sk.isConnectable())
                            handler.processConnect(sk);
                        else if (sk.isReadable())
                            handler.processRead(sk);
                    } catch (IOException e) {
        	            log.error(e.getMessage());
        	            handler.processError(e);
                    } catch (PacketParseException e) {
        	            log.debug("鍖呰В鏋愰敊璇� " + e.getMessage());
    	            } catch (RuntimeException e) {
    	                log.error(e.getMessage());
    	            }
		        }
		        
		        n = 0;
		    }
		    
		    checkNewConnection();		    
		    notifySend();		    
		} 
	    
        selector = null;
        shutdown = false;
		log.debug("Porter宸茬粡閫�鍑�");
	}
	
	/**
	 * 娣诲姞閲婃斁璇锋眰
	 * 
	 * @param p
	 */
	public void addDisposeRequest(IPort p) {
		synchronized(disposeQueue) {
			disposeQueue.offer(p);
		}
	}
	
	/**
	 * 娣诲姞閲婃斁璇锋眰
	 * 
	 * @param p
	 */
	public void addDisposeRequest(IProxy p) {
		synchronized(disposeQueue) {
			disposeQueue.offer(p);
		}
	}
	
    /**
     * 妫�鏌ユ槸鍚︽湁鏂拌繛鎺ヨ鍔犲叆
     */
    private void checkNewConnection() {	 
        while(!newConnections.isEmpty()) {
            Object handler = newConnections.remove(0);
	        if(handler instanceof IProxy) {
		        try {
	                register((IProxy)handler);
	            } catch (ClosedChannelException e1) {
	            }
	        } else if(handler instanceof IPort) {
		        try {
	                register((IPort)handler);
	            } catch (ClosedChannelException e1) {
	            }
	        }            
        }
    }
    
    /**
     * 澶勭悊杩炴帴閲婃斁璇锋眰
     */
    private void processDisposeQueue() {
    	synchronized(disposeQueue) {
    		while(!disposeQueue.isEmpty()) {
    			Object obj = disposeQueue.poll();
    			if(obj instanceof IPort)
    				deregister((IPort)obj);
    			else if(obj instanceof IProxy)
    				deregister((IProxy)obj);
    		}
    	}
    }

    /**
     * 鍏抽棴porter
     */
    public void shutdown() {
	    if(selector != null) {
		    shutdown = true;
	        selector.wakeup();	        
	    }
    }
    
    /**
     * 鍞ら啋selector
     */
    public void wakeup() {
        selector.wakeup();
    }
    
    /**
     * 鍞ら啋selector鐒跺悗娉ㄥ唽杩欎釜proxy
     * 
     * @param proxy
     */
    public void wakeup(Object handler) {
        newConnections.add(handler);
        selector.wakeup();
    }
}