/******************************************************************************
 * Javascript Document
 * iBookObj v2.3
 * http://www.amonsoft.cn/code/iBookObj/
 * Copyright (c) 2008 Amonsoft.cn
 ******************************************************************************/
var iBookObj = function()
{
	/*类自身引用*/
	var THIS = this;
	
	/*服务器路径*/
	var NAME = 'iBookObj';
	var HOST = 'http://www.amonsoft.cn/';
	var PATH = HOST + 'code/';
	
	/*资源常量*/
	var PANE = new Array('IBMS', 'IRSS', 'INFO', 'LINK');
	var LIST = new Array('网摘', '阅读', '关于', '链接');

	/*用户配置参数：显示DIV层的左偏移量*/
	var offL = 0;
	/*用户配置参数：显示DIV层的上偏移量*/
	var offT = 0;
	
	/*定时变量，用于DIV层的显示及隐藏*/
	var xFun = null;
	
	/*页面参数：主机地址*/
	var xHst = null;
	/*页面参数：页面地址*/
	var xUrl = null;
	/*页面参数：页面标题*/
	var xTtl = null;
	/*页面参数：页面摘要*/
	var xDsc = null;
	var xViw = null;
	
	/*是否隐藏主窗口*/
	var xHid = '';

	/**
	 * 链接连接方式：
	 *     icon:图标
	 *     text:文本
	 *     icon_text:图标与文本
	 */
	var xViw = 'icon_text';
	
	/*分页索引*/
	var tabi = 0;
	/*分页索引*/
	var tabs = null;

	/**收藏链接数组*/
	THIS.IBMS = new Array();
	/**阅读链接数组*/
	THIS.IRSS = new Array();
	/**网站连接查询*/
	THIS.LINK = new Array();
	/**作者联系信息*/
	THIS.INFO = new Array();

	/**
	 * type: 要显示的网摘的类型
	 *      menu 按钮
	 *      link 文本
	 *      list 列表
	 * kind: 显示的面板类型，仅在type为link时有效
	 *       bms 书签
	 *       rss 阅读
	 * view: 图像及文本显示方式
	 *       icon: 仅图标
	 *       text: 仅文本
	 *       icon_text:图标及文本
	 * rows: 要显示网摘的行数
	 * cols: 要显示网摘的列数
	 * title:标题
	 * url:  链接
	 * desp: 摘要
	 * hide: 是否需要隐藏界面，此功能主要用于外部页面调用类的内部方法，其值为为'hide'时都将会隐藏。
	 */
	THIS.bookMark = function(type, kind, view, rows, cols, title, url, desp, hide)
	{
		// 为空判断
		if (!title || title == '')
		{
			title = _D.title;
		}
		xTtl = title;
		
		// 为空判断
		if(!url || url == '')
		{
			url = location.href;
		}
		xUrl = url;

		// 为空判断
		if(!desp)
		{
			desp = '';
		}
		xDsc = desp;
		
		if (!hide || hide == '')
		{
		    hide = '';
		}
		xHid = hide;
		
		// 显示方式
		xViw = view;

		// 引入样式表
		THIS.style();

		// 显示正确类别
		type = type.toLowerCase();
		if(type=='menu')
		{
			var div = _D.createElement('div');
			div.innerHTML = divMenu(rows, cols);
			_D.body.insertBefore(div, _D.body.firstChild);
			div.style.zIndex = 1000000;
			return;
		}
		if(type=='link')
		{
			_D.write(divLink(rows, cols, kind.toLowerCase()));
			return;
		}
		if(type=='list')
		{
		    _D.write(divList(rows, kind.toLowerCase()));
			return;
		}
	};
	
	THIS.style = function()
	{
	    var lnk = _D.createElement("link");
		lnk.rel="stylesheet";
		lnk.type="text/css";
		lnk.href= PATH + NAME + '/c/' + NAME + '.css';
		lnk.media="all";
		_D.lastChild.firstChild.appendChild(lnk);
	};

	/**
	 * 打开网摘快捷窗口（DIV小窗口）
	 * obj:调用此方法的事件源对象
	 * did:默认要打开的窗口区分字符串，（即DIV的标记ID）
	 * url:进行网摘收录的来源页面地址
	 * ttl:进行网摘收录的来源页面标题
	 * msg:进行网摘收录的用户选择文本
	 */
	THIS.open = function(obj,did,url,ttl,msg)
	{
		THIS.show();

		// 获取链接内的图片对象<a><img></a>
		var ofh = 16;
		var ofw = 12 * obj.innerHTML.length;
		var img = obj.getElementsByTagName('img');
		if(img && img[0])
		{
			obj=img[0];
			ofh = obj.height;
			ofw = obj.width;
		}

		// 显示默认DIV界面
		tabv();

		var loc=$L(obj);
		var ofx=loc[0] + offL;
		var ofy=loc[1] + offT + ofh + 2;
		var p=$P();
		var r=$R();
		var wnd=$X(NAME);
		wnd.style.display='';
		if(ofx-r[0]+wnd.clientWidth+20>p[0])
		{
			ofx=ofx-wnd.clientWidth+ofw;
		}
		if(ofy-r[1]+wnd.clientHeight+obj.clientHeight+20>p[1])
		{
			ofy=ofy-wnd.clientHeight-ofh-2;
		}
		wnd.style.left=ofx+'px';
		wnd.style.top=ofy+'px';

		return false;
	};

	THIS.mail = function()
	{
		var obj;
		
		obj = $X(NAME + '_TM');
		var mtm=obj.value.trim();
		if(mtm == '')
		{
			alert('请输入接收邮件！');
			obj.focus();
			return false;
		}
		var ai = mtm.indexOf('@');
		var di = mtm.indexOf('.', ai+1);
		if(ai<0 || di < ai)
		{
			alert('您输入的接收邮件格式不正确，请重新输入！');
			obj.focus();
			return false;
		}
		
		obj = $X(NAME + '_FM');
		var mfm=obj.value.trim();
		if(mfm == '')
		{
			alert('请输入发送邮件！');
			obj.focus();
			return false;
		}
		var ai = mfm.indexOf('@');
		var di = mfm.indexOf('.', ai+1);
		if(ai<0 || di < ai)
		{
			alert('您输入的发送邮件格式不正确，请重新输入！');
			obj.focus();
			return false;
		}
		
		obj = $X(NAME + '_FM');
		var mcm = obj.value.trim();
		if(mcm == '')
		{
			alert('请输入邮件内容！');
			obj.focus();
			return false;
		}
		var euc=encodeURIComponent;
		new Image().src='http://www.amonsoft.cn/iask/index.aspx';
		alert('邮件发送成功！');
		xFun=setTimeout("ibo.hide()",1200);
		return false;
	};

	/**
	 * DIV层关闭处理：如果用户在指定时间内鼠标在<a>标签和<div>标签之间移动，则不进行DIV层的关闭操作。
	 */
	THIS.show = function()
	{
		if(xFun != null)
		{
			clearTimeout(xFun);
		}
	};
	
	THIS.exit = function()
	{
		xFun=setTimeout("ibo.hide()", 500);
	};

	/**
	 * 级联菜单风格
	 */
	function divMenu(rows, cols)
	{
	    var i = 0;

		var sdiv = '<div id="' + NAME + '" onmouseover="ibo.show()" onmouseout="ibo.exit()" style="position:absolute;width:200px;height:158px;z-index:100000;display:none;">';
		sdiv += '<table id="' + NAME + '_HEAD_TB" width="100%" border="0" cellspacing="0" cellpadding="0">';
		sdiv += '<tr><th align="left" valign="middle"><div id="' + NAME + '_HEAD_DV" style="height: 18px; padding-top: 4px; padding-left: 4px;"></div></th></tr>';

		sdiv += '<tr><td>';
		sdiv += '<div id="' + NAME + '_TABS_DV">';
		sdiv += '<table width="100%" border="0" cellspacing="0" cellpadding="0">';
		sdiv += '<tr align="center">';
		sdiv += '<td id="' + NAME + '_TAB0" width="40" class="TABS" onMouseOver="ibo.tabo(this, 0)" onMouseOut="ibo.tabx(this, 0)" onMouseUp="ibo.tabs(this, 0)"><a href="" onclick="javascript: return false">' + LIST[0] + '</a></td>';
		sdiv += '<td id="' + NAME + '_TAB1" width="40" class="TABD" onMouseOver="ibo.tabo(this, 1)" onMouseOut="ibo.tabx(this, 1)" onMouseUp="ibo.tabs(this, 1)"><a href="" onclick="javascript: return false">' + LIST[1] + '</a></td>';
		sdiv += '<td id="' + NAME + '_TAB2" width="40" class="TABD" onMouseOver="ibo.tabo(this, 2)" onMouseOut="ibo.tabx(this, 2)" onMouseUp="ibo.tabs(this, 2)"><a href="" onclick="javascript: return false">' + LIST[2] + '</a></td>';
		if (THIS.host().indexOf('amonsoft.') >= 0)
		{
		    sdiv += '<td id="' + NAME + '_TAB3" width="40" class="TABD" onMouseOver="ibo.tabo(this, 3)" onMouseOut="ibo.tabx(this, 3)" onMouseUp="ibo.tabs(this, 3)"><a href="" onclick="javascript: return false">' + LIST[3] + '</a></td>';
		}
		sdiv += '<td class="TABN">&nbsp;</td>';
		sdiv += '</tr>';
		sdiv += '</table>';
		sdiv += '</div>';
		sdiv += '</td></tr>';
		
		sdiv += '<tr><td>';
		sdiv += udiv(i++);
		sdiv += rdiv(i++);
		sdiv += idiv(i++);
		sdiv += ldiv(i++);
		sdiv += '</td></tr>';
		
		sdiv += '<tr><td align="right" height="18">';
		sdiv += '<a href="http://www.amonsoft.cn/code/' + NAME + '/" target="_blank" title="Amon软件">Amonsoft</a>&nbsp;';
		sdiv += '<a href="http://www.amonsoft.cn/tool/tool1307.aspx" target="_blank" onclick="return openWnd(\'http://www.amonsoft.cn/tool/tool1307.aspx?t=' + xTtl + '&u=' + xUrl + 'd=' + xDsc + '\', 500, 600)" title="更多网摘">更多…</a>&nbsp;';
		sdiv += '</td></tr>';

		sdiv += '</table>';
		sdiv += '</div>';

		return sdiv;
	}
	
	/**
	 * 链接标签风格
	 */
	function divLink(rows, cols, kind)
	{
		if(!cols || cols=='')
		{
			cols = 8;
		}
		if(!rows || rows=='')
		{
			rows = 1;
		}

		var list;
	    var labl = '';
	    if (kind == 'bms')
	    {
	        list = THIS.IBMS;
	        labl = LIST[0];
	    }
	    else if (kind == 'rss')
	    {
	        list = THIS.IRSS;
	        labl = LIST[1];
	    }
	    
	    if(list == null)
	    {
	        return 'Amon网络收藏出现配置错误！';
	    }

		var sdiv = '<table border="0" cellspacing="0" cellpadding="2">';

		var k = _L(list, cols, rows);
		var i = 0;
		var j = 0;
		sdiv += '<tr>';
		sdiv += '<td rowspan="' + rows + '">Amon&nbsp;' + labl + '：</td>';
		while(j++ < cols)
		{
			sdiv += '<td align="left" height="20">';
			sdiv += THIS.link(list[i++], xViw, kind);
			sdiv += '</td>';
		}
		sdiv += '</tr>';
			
		while (i < k)
		{
			sdiv += '<tr>';
			j = 0;
			while(j++ < cols)
			{
				sdiv += '<td align="left" height="20">';
				sdiv += THIS.link(list[i++], xViw, kind);
				sdiv += '</td>';
			}
			sdiv += '</tr>';
		}

		sdiv += '</table>';
		
		return sdiv;
	}
	
	/**
	 * 下拉列表风格
	 */
	function divList(size, kind)
	{
	    if(!size || size == '')
	    {
	        size = 8;
	    }
	    
	    var list;
	    var labl = '';
	    if (kind == 'bms')
	    {
	        list = THIS.IBMS;
	        labl = LIST[0];
	    }
	    else if (kind == 'rss')
	    {
	        list = THIS.IRSS;
	        labl = LIST[1];
	    }
	    
	    if(list == null)
	    {
	        return 'Amon网络收藏出现配置错误！';
	    }
	    
	    if (size > list.length)
	    {
	        size = list.length;
	    }
	    

	    var sdiv = '<select name="select" onchange="ibo.book(document.getElementById(\'' + NAME + '_' + kind + '_OP\'+this.value));this.value=\'-1\';">';
	    sdiv += '<option value="-1">Amon&nbsp;' + labl + '</option>';
	    var o;
	    for (var i=0; i<size; i+=1)
	    {
	        o = list[i];
	        sdiv += '<option id="' + NAME + '_' + kind + '_OP' + i + '"  value="' + i + '" url="' + o[1] + '" esp="' + o[5] + '" wnd="' + o[0] + '" w="' + o[6] + '" h="' + o[7] + '" k="' + kind + '">' + o[3] + '</option>';
	    }
	    sdiv += '</select>';

	    return sdiv;
	}
	
	/**
	 * 共用DIV
	 */
	function cdiv(list, cols, rows, kind)
	{
		if(!cols || cols < 0)
		{
			cols = 2;
		}
		var k = _L(list, cols, rows);

		var sdiv = '';
		var i = 0;
		var j = 0;
		while (i < k)
		{
			sdiv += '<tr>';
			j = 0;
			while(j++ < cols)
			{
				sdiv += '<td align="left" height="20">';
				sdiv += THIS.link(list[i++], xViw, kind);
				sdiv += '</td>';
			}
			sdiv += '</tr>';
		}

		return sdiv;
	}
	
	/**
	 * 收藏DIV
	 */
	function udiv(idx)
	{
		var sdiv = '<div style="height:100px;" id="' + NAME + '_' + PANE[idx] + '_DV">';
		sdiv += '<table width="100%" border="0" cellspacing="0" cellpadding="0" id="' + NAME + '_' + PANE[idx] + '_TB">';
		sdiv += cdiv(THIS.IBMS, 2, 5, 'bms');
		sdiv += '</table>';
		sdiv += '</div>';
		
		return sdiv;
	}
	
	/**
	 * 阅读DIV
	 */
	function rdiv(idx)
	{
		var sdiv = '<div style="height:100px;display:none;" id="' + NAME + '_' + PANE[idx] + '_DV">';
		sdiv += '<table width="100%" border="0" cellspacing="0" cellpadding="0" id="' + NAME + '_' + PANE[idx] + '_TB">';
		sdiv += cdiv(THIS.IRSS, 2, 5, 'rss');
		sdiv += '</table>';
		sdiv += '</div>';
		
		return sdiv;
	}
	
	/**
	 * 信息DIV
	 */
	function idiv(idx)
	{
		var sdiv = '<div style="height:100px;display:none;" id="' + NAME + '_' + PANE[idx] + '_DV">';
		sdiv += '<table width="100%" border="0" cellpadding="0" cellspacing="0" id="' + NAME + '_' + PANE[idx] + '_TB">';
		var size = _L(THIS.INFO, 2, 5);
		var idx = 0;
		var obj;
		while(idx < size)
		{
		    sdiv += '<tr>';
		    
		    obj = THIS.INFO[idx++];
		    if(obj.length<8)
		    {
		        break;
		    }
		    sdiv += '<td align="left" height="20">';
		    sdiv += '<a href="' + obj[5] + '" title="' + obj[3] + '" target="' + (obj[0].toLowerCase() == 'url' ? '_blank' : '_self') + '" onclick="return ibo.isIE(this, \'' + obj[4] + '\', \'' + obj[7] + '\', \'' + obj[6] + '\');">';
		    sdiv += '<img src="';
		    if(obj[1].indexOf('/') < 0)
		    {
		        sdiv += '/code/' + NAME + '/i/';
		    }
		    sdiv += obj[1];
		    sdiv += '" width="16" height="16" />&nbsp;' + obj[2] + '</a>';
		    sdiv += '</td>';
		    
		    obj = THIS.INFO[idx++];
		    if(obj.length<8)
		    {
		        break;
		    }
		    sdiv += '<td align="left" height="20">';
		    sdiv += '<a href="' + obj[5] + '" title="' + obj[3] + '" target="' + (obj[0].toLowerCase() == 'url' ? '_blank' : '_self') + '" onclick="return ibo.isIE(this, \'' + obj[4] + '\', \'' + obj[7] + '\', \'' + obj[6] + '\');">';
		    sdiv += '<img src="';
		    if(obj[1].indexOf('/') < 0)
		    {
		        sdiv += '/code/' + NAME + '/i/';
		    }
		    sdiv += obj[1];
		    sdiv += '" width="16" height="16" />&nbsp;' + obj[2] + '</a>';
		    sdiv += '</td>';
		    
		    sdiv += '</tr>';
		}
        sdiv += '</table>';
		sdiv += '</div>';

		return sdiv;
	}
	
	/**
	 * 链接DIV
	 */
	function ldiv(idx)
	{
		var sdiv = '<div style="height:100px;display:none;" id="' + NAME + '_' + PANE[idx] + '_DV">';
		sdiv += '<table width="100%" border="0" cellpadding="0" cellspacing="0" id="' + NAME + '_' + PANE[idx] + '_TB">';
		var size = THIS.LINK.length < 4 ? THIS.LINK.length : 4;
		var obj;
		for(var i=0; i<size; i+=1)
		{
		    obj = THIS.LINK[i];
		    sdiv += '<tr>';
		    sdiv += '<td align="left" height="25" title="' + obj[0] + '收录查询"><input type="checkbox" onclick="ibo.ajaxStart(\'' + obj[0] + '\', this);"><img src="/code/' + NAME + '/i/'+ obj[1] + '" alt="' + obj[0] + '" width="16" height="16"></td>';
		    sdiv += '<td align="left" height="25" width="75">收录：<a id="' + NAME + '_LINK_' + obj[0] + '_Site" href="#" title="点击查看详细信息" style="color: #009900" onclick="return ibo.openWnd(\'' + obj[0] + '\', 0, this);">...</a></td>';
		    sdiv += '<td align="left" height="25" width="75">链入：<a id="' + NAME + '_LINK_' + obj[0] + '_Link" href="#" title="点击查看详细信息" style="color: #009900" onclick="return ibo.openWnd(\'' + obj[0] + '\', 1, this);">...</a></td>';
		    sdiv += '</tr>';
		}
		sdiv += '</table>';
		sdiv += '</div>';
		
		return sdiv;
	}

	/**
	 * div层隐藏事件处理
	 */
	THIS.hide = function()
	{
	    if(xHid != 'hide')
	    {
		    var o=$X(NAME);
		    if(o)
		    {
			    o.style.display = 'none';
		    }
		}
		return false;
	};
	
	/**
	 * TAB鼠标进入事件
	 */
	THIS.tabo = function(obj, idx)
	{
		if(tabs != obj)
		{
			obj.className = 'TABO';
		}
	};
	
	/**
	 * TAB鼠标退出事件
	 */
	THIS.tabx = function(obj, idx)
	{
		if(tabs != obj)
		{
			obj.className = 'TABD';
		}
	};
	
	/**
	 * TAB鼠标选择事件
	 */
	THIS.tabs = function(obj, idx)
	{
		if(tabs != obj)
		{
			if(tabs)
			{
				tabs.className = 'TABD';
			}
			tabs = obj;
			tabs.className = 'TABS';
			tabi = idx;
			tabv();
		}
	};

	/**
	 * 访问指定的网摘
	 * obj 链接对象
	 * wnd 打开窗口名柄
	 * w 打开窗口宽度
	 * h 打开窗口高度
	 * k 打开窗口类别，比如bms,rss等
	 */
	THIS.book = function(obj)
	{
		// 隐藏DIV用户界面
		THIS.hide();

        var wnd = obj.attributes['wnd'].nodeValue;
		// 添加到收藏夹
		if(wnd == 'favorites')
		{
			if(_D.all)
			{
				_W.external.AddFavorite(xUrl, xTtl);
			}
			else
			{
				_W.sidebar.addPanel(xTtl, xUrl, '');
			}
			return false;
		}

		if(!obj)
		{
			return false;
		}

		var dsp = xDsc;
		if(dsp == '')
		{
			dsp = _D.selection ? (_D.selection.type != 'None' ? _D.selection.createRange().text : '') : (_D.getSelection ? _D.getSelection() : '');
		}
		
		var esp = obj.attributes['esp'].nodeValue;
		var url;
		if(!esp || esp == '')
		{
			url = obj.attributes['url'].nodeValue.replace('{0}', xTtl).replace('{1}', xUrl).replace('{2}', dsp);
		}
		else
		{
			url = obj.attributes['url'].nodeValue.replace('{0}', eval(esp)(xTtl)).replace('{1}', eval(esp)(xUrl)).replace('{2}', eval(esp)(dsp));
		}
		
		if(obj.attributes['k'].nodeValue == 'bms')
		{
			var sts = 'width=' + obj.attributes['w'].nodeValue + ',height=' + obj.attributes['h'].nodeValue + ',menubar=no,toolbar=no,location=no,status=no,scrollbars=yes,resizable=yes';
			_W.open(url, wnd, sts);
		}
		else
		{
			_W.open(url, wnd);
		}
		return false;
	};

	/**
	 * 生成链接字符串
	 */
	THIS.link = function(o, v, k)
	{
		var text = o[3];
		if(v != 'text')
		{
			if(o[4])
			{
				text = '<img src="' + PATH + NAME + '/i/' + o[4] + '" alt="' + text + '" style="border:0px;width:16px;height:16px;">';
			}
			if(v != 'icon')
			{
				text += o[3];
			}
		}
		
		return '<a href="#" url="' + o[1] + '" esp="' + o[5] + '" wnd="' + o[0] + '" w="' + o[6] + '" h="' + o[7] + '" k="' + k + '" title="' + o[2] +'" onclick="return ibo.book(this);">' + text + '</a>';
	};
	
	/**
	 * 检测浏览器是否为IE浏览器
	 */
	THIS.isIE = function(obj, oie, msg, uri)
	{
	    var run = false;
        if(!oie || oie == '')
        {
            run = true;
        }
        else
        {
            var inm = oie.split(',');
            var ugt = navigator.userAgent.toLowerCase();
            for(var idx=0; idx<inm.length; idx+=1)
            {
                if(ugt.indexOf(inm[idx].toLowerCase()) >= 0)
                {
                    run = true;
                    break;
                }
            }
        }

	    if(!run)
	    {
	        if (!uri || uri == '')
	        {
	            if(!msg || msg == '')
	            {
	                msg = '此协议仅支持在' + oie + '浏览器下运行！';
	            }
	            alert(msg);
	            return false;
	        }
	        
	        if(!msg || msg == '')
	        {
	            msg = '此协议仅支持在' + oie + '浏览器下运行，是否要执行相关替代协议？';
	        }
	        if(!_W.confirm(msg))
	        {
                return false;
	        }
	        obj.href=uri;
	    }
	    return true;
	};
	
	/**
	 * 获取主机地址
	 */
	THIS.host = function()
	{
	    if(!xHst)
	    {
	        var reg = /(^\w+:\/\/)((\w|\.)+)(:\d+)?\//;
            var tmp = reg.exec(xUrl + '/');
            xHst = tmp ? tmp[2] : xUrl;
        }
        return xHst;
        //return 'www.amonsoft.cn';
	};
	
	THIS.hostNav = function(se)
	{
	    var obj;
	    for(var i=0; i<THIS.LINK.length; i+=1)
	    {
	        obj = THIS.LINK[i];
	        if(obj[0]==se)
	        {
	            return [obj[2]+obj[3].replace('{0}', THIS.host()), obj[2]+obj[6].replace('{0}', THIS.host())];
	        }
	    }
	};
	
	THIS.openWnd = function(se, idx, obj)
	{
	    if(obj)
	    {
	        if(obj.href.indexOf('#')+1==obj.href.length)
	        {
	            return false;
	        }
	    }

	    _W.open(THIS.hostNav(se)[idx]);
	    return false;
	};
	
	THIS.ajaxStart = function(id, obj)
	{
	    if(obj)
	    {
	        if(!obj.checked)
	        {
	            $X(NAME + '_LINK_'+id+'_Site').innerHTML='...';
	            $X(NAME + '_LINK_'+id+'_Site').href='#';
	            $X(NAME + '_LINK_'+id+'_Link').innerHTML='...';
	            $X(NAME + '_LINK_'+id+'_Link').href='#';
	            return;
	        }
	    }

        if (_W.ActiveXObject)
        {
            ajax = new ActiveXObject("Microsoft.XMLHTTP");
        }
        else if (_W.XMLHttpRequest)
        {
            ajax = new XMLHttpRequest();
        }
        if(!ajax)
        {
            return;
        }
        
        ajax.onreadystatechange = THIS.ajaxHandle;
        ajax.open('GET', '/ajax/ajax1307.aspx?pp='+id+ '&pq='+escape(THIS.host()), true);
        ajax.send(null);
	};
	
	THIS.ajaxHandle = function()
	{
        if(ajax.readyState == 4)
        {
            if(ajax.status == 200)
            {
                var data = ajax.responseText;
                var i1 = data.indexOf(':');
                var i2 = data.indexOf(',', i1);
                var name = data.substring(0, i1);
                var nav = THIS.hostNav(name);

	            var os = $X(NAME + '_LINK_'+name+'_Site');
	            var ol = $X(NAME + '_LINK_'+name+'_Link');

                os.innerHTML=data.substring(i1 + 1, i2);
                if(os.href)os.href=nav[0];
                ol.innerHTML=data.substring(i2 + 1);
                if(ol.href)ol.href=nav[1];
            }
        }
	};
	
	/**
	 * 调整列表长度，使其能够整行显示。
	 */
	function _L(list, cols, rows)
	{
		var size = cols * rows;
		if(list.length < size)
		{
			var o = size - list.length;
			while(o-- > 0)
			{
				list.push(new Array());
			}
		}
		return size;
	}
	
	/**
	 * 设置指定组件的可视性
	 * _5:组件区分字符串
	 */
	function tabv()
	{
		for(var i=0; i<PANE.length; i+=1)
		{
			$X(NAME + '_' + PANE[i] + '_DV').style.display = (tabi == i ? '' : 'none');
		}
		$X(NAME + '_HEAD_DV').innerHTML = 'Amon '+ LIST[tabi];
		if(!tabs)
		{
			tabs = $X(NAME + '_TAB0');
		}
	}
	
	function $X(obj)
	{
		return _D.getElementById(obj);
	}

	function $L(obj)
	{
		var a=0;
		var b=0;
		do
		{
			a += obj.offsetLeft || 0;
			b += obj.offsetTop || 0;
			obj = obj.offsetParent;
		}while(obj);
		return [a,b];
	}

	function $P()
	{
		if(typeof (_W.innerWidth)=='number')
		{
			return [_W.innerWidth, _W.innerHeight];
		}
	
		var o =_D.documentElement;
		if(o&&(o.clientWidth || o.clientHeight))
		{
			return [o.clientWidth, o.clientHeight];
		}
	
		o = _D.body;
		if(o&&(o.clientWidth || o.clientHeight))
		{
			return [o.clientWidth, o.clientHeight];
		}
	
		return [0, 0];
	}
	
	/**
	 * 页面偏移位置
	 */
	function $R()
	{
		if(typeof (_W.pageYOffset)=='number')
		{
			return [_W.pageXOffset, _W.pageYOffset];
		}
	
		var o = _D.documentElement;
		if(o&&(o.scrollLeft || o.scrollTop))
		{
			return [o.scrollLeft, o.scrollTop];
		}
	
		o = _D.body;
		if(o&&(o.scrollLeft || o.scrollTop))
		{
			return [o.scrollLeft, o.scrollTop];
		}
	
		return [0,0];
	}

    var _D = document;
    var _W = window;
    var ajax;
};
String.prototype.trim=function()
{
	return this.replace(/(^\s*)|(\s*$)/g, '');
};
if (!ibo)var ibo = new iBookObj();