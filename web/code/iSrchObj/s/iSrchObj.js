/****************************************************************
 * iSrchObj v1.0
 * http://www.amonsoft.cn/code/iSrchObj/
 * Copyright (c) 2008 Amonsoft.cn
 ****************************************************************/
function iSrchObj()
{
	var THIS = this;
	var NAME = 'iSrchObj';
	var HOST = 'http://www.amonsoft.cn/';
	var PATH = HOST + 'code/' + NAME + '/';

	///////////////////////////////////////////////////////////////////////////////////////////////////
	// 搜索引擎定制区域
	///////////////////////////////////////////////////////////////////////////////////////////////////
	THIS.senm = new Array();//搜索引擎名称
	THIS.selg = new Array();//搜索引擎图标
	THIS.sept = new Array();//搜索引擎路径
	THIS.sedi = '0';//默认搜索引擎

	///////////////////////////////////////////////////////////////////////////////////////////////
	// 全局变量区域
	///////////////////////////////////////////////////////////////////////////////////////////////
	var sDiv;//划词搜索面板DIV
	var _msb;//Microsoft Internet Explorer
	var sObj;//起始选择对象
	var eObj;//结束选择对象
	var uTxt;//用户选择文本
	var mDiv;//搜索菜单DIV
	var _msw;//菜单宽度
	var _msh;//菜单高度
	var xPos;//划词搜索显示X坐标
	var yPos;//划词搜索显示Y坐标
	var isdb = false;//是否用户双击鼠标
	var isme = false;//是否弹出菜单处于显示状态
	var _rng;
	
	///////////////////////////////////////////////////////////////////////////////////////////////
	// 常量区域
	///////////////////////////////////////////////////////////////////////////////////////////////
	var TPLT = '<tr><th width="20">{2}</th><td align="left"><a href="#" onclick="return iso.C({0})">{1}</a></td></tr>';
	
	///////////////////////////////////////////////////////////////////////////////////////////////
	// 对外公开方法
	///////////////////////////////////////////////////////////////////////////////////////////////
	THIS.init = function()
	{
		_msb = navigator.appName.indexOf("icrosoft") > 0;
		if (_msb)
		{
			$D().onmousedown = ssObj;
			$D().ondblclick = dbClk;
			$D().onmouseup = seObj;
		}
		else
		{
			$W().onmousedown = ssObj;
			$W().ondblclick = dbClk;
			$W().onmouseup = seObj;
		}
	
		sDiv = $D().createElement('div');
		sDiv.innerHTML = S();
		$D().body.insertBefore(sDiv, $D().body.firstChild);
		sDiv = $X(NAME);
		mDiv = $X(NAME + '_MENU');
		
		THIS.addSearchEngine('页面搜索', '', '');
	};
	/**
	 * 添加用户自定义搜索引擎
	 */
	THIS.addSearchEngine = function(name, logo, uri)
	{
		THIS.senm.push(name);
		THIS.selg.push(logo);
		THIS.sept.push(uri);
	};
	
	/**
	 * 设置默认搜索引擎
	 */
	THIS.setDefaultSearchEngine = function(se)
	{
	    THIS.sedi = se;
	};
	
	///////////////////////////////////////////////////////////////////////////////////////////////
	// 
	///////////////////////////////////////////////////////////////////////////////////////////////
	/**
	 * 页面鼠标双击事件
	 */
	function dbClk(evt)
	{
		isdb = true;
	}
	/**
	 * 记录用户选择起始对象
	 */
	function ssObj(evt)
	{
		evt = E(evt);
		if (evt)
		{
			sObj = (evt.target) ? evt.target : evt.srcElement;
		}
	}
	/**
	 * 记录用户选择结束对象
	 */
	function seObj(evt)
	{
		evt = E(evt);
		if (evt)
		{
			if (evt.target)
			{
				eObj = evt.target;
				uTxt = $W().getSelection().toString();
			}
			else
			{
				eObj = evt.srcElement;
				uTxt = $D().selection.createRange().text;
			}
		}
	
		var tag = eObj.tagName.toUpperCase();
		if(!isdb && eObj == sObj && tag != 'A' && tag != 'INPUT')
		{
			vSrch(uTxt, evt);
		}
	
		isdb = false;
	}
	/**
	 * 显示划词搜索界面
	 */
	function vSrch(str,evt)
	{
		if(str.length < 1 || str.indexOf('\n') >= 0 || str.length > 64)
		{
			sDiv.style.display = 'none';
			mDiv.style.display = 'none';
			return;
		}

		if(_msb)
		{
			xPos = $D().documentElement.scrollTop + evt.y - 30;
			yPos = $D().documentElement.scrollLeft + evt.x + 5;
		}
		else
		{
			xPos = $D().body.scrollTop + evt.pageY - 30;
			yPos = $D().body.scrollLeft + evt.pageX + 5;
		}
	    sDiv.style.top = xPos + 'px';
	    sDiv.style.left = yPos + 'px';
		sDiv.style.display = '';
	}
	/**
	 * 搜索事件响应，并显示搜索结果
	 */
	THIS.dSrch = function()
	{
		var se = _gc(NAME);
		if (se == '0')
		{
			dFind();
			return;
		}
		$W().open(THIS.sept[se].replace('{0}', uTxt), NAME);
		return false;
	};
	
	THIS.dHome = function()
	{
		$W().open(PATH);
		return false;
	};
	
	function dFind()
	{
		if($W().find)
		{
			var b = $W().find(uTxt, false, false, true);
			if(!b)
			{
				alert('页面搜索完毕！');
			}
			return;
		}

		if(!_rng)
		{
			_rng = $D().body.createTextRange();
		}
		if(_rng.findText(uTxt))
		{
			_rng.scrollIntoView();
			_rng.select();
			_rng.collapse(false);
		}
		else
		{
			alert('页面搜索完毕！');
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	// 列表菜单
	//////////////////////////////////////////////////////////////////////////////////////////////////
	/**
	 * 鼠标点击搜索引擎菜单选择按钮事件处理
	 */
	THIS.mbo = function()
	{
		if(isme)
		{
			mbx();
			return false;
		}

		_msw = 0;
		_msh = 0;
		mDiv.innerHTML = '';
		mDiv.style.display = '';
		mDiv.style.width = '0px';
		mDiv.style.height = '1px';
		mDiv.style.top = (xPos + 22) + 'px';
		mDiv.style.left = (yPos + 30) + 'px';
	
		mtw();
		isme = true;
		return false;
	};
	/**
	 * 鼠标退出搜索引擎菜单选择按钮事件处理
	 */
	function mbx()
	{
		mDiv.style.display = 'none';
		isme = false;
	}
	/**
	 * 鼠标进入搜索引擎菜单DIV事件处理
	 */
	THIS.mdo = function()
	{
		mDiv.style.display = '';
		isme = true;
	};
	/**
	 * 鼠标进入搜索引擎菜单DIV事件处理
	 */
	THIS.mdx = function()
	{
		mDiv.style.display = 'none';
		isme = false;
	};
	/**
	 * 基于时间的动态显示搜索引擎菜单（宽度）
	 */
	function mtw()
	{
		if(_msw >= 140)
		{
			mth();
			return ;
		}
	
		_msw += 10;
		mDiv.style.width = _msw + 'px';
		$W().setTimeout(mtw, 1);
	}
	/**
	 * 基于时间的动态显示搜索引擎菜单（高度）
	 */
	function mth()
	{
		if(_msh >= 150)
		{
			mtc();
			return ;
		}
	
		_msh += 6;
		mDiv.style.height = _msh + 'px';
		$W().setTimeout(mth, 1);
	}
	/**
	 * 基于时间的动态显示搜索引擎菜单（内容）
	 */
	function mtc()
	{
		var innerHTML = '<table width="100%" border="0" cellpadding="1" cellspacing="0">';
		var i = 0;
		var g;
		var u = _gc(NAME);
		while(i< THIS.senm.length)
		{
			g = i == u ? '&oplus;' : '&nbsp;';
			innerHTML += TPLT.replace('{0}', i).replace('{1}', THIS.senm[i]).replace('{2}', g);
			i += 1;
		}
		innerHTML += '</table>';
		mDiv.innerHTML = innerHTML;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	// 内部私有方法
	//////////////////////////////////////////////////////////////////////////////////////////////////
	/**
	 * 获得正确的页面对象
	 */
	function $(obj)
	{
		return (typeof(obj) == '') ? $D().getElementById(obj) : obj;
	}
	/**
	 * 引用鼠标事件
	 */
	function E(evt)
	{
		return evt ? evt : $W().event;
	}
	/**
	 * 获取鼠标事件发生的对象
	 */
	function O(evt)
	{
		return (evt.target) ? evt.target : evt.srcElement;
	}
	/**
	 * 初始化划词搜索面板DIV
	 */
	function S()
	{
		/*搜索枯肠*/
		var sdiv = '<div id="'+ NAME + '" style="position:absolute;z-index:998;width:160px;height:28px;background-image:url(\'' + PATH + 'icon/back.gif\');display:none;">';
		sdiv += '<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border: #FFFFFF solid 1px;">';
		sdiv += '<tr>';
		sdiv += '<td width="6" height="26"></td>';
		sdiv += '<td width="20" height="26" align="center"><input id="ib_Logo" type="image" src="' + PATH + 'icon/logo.png" onclick="return iso.dHome()" style="border:0px" alt="LOGO" title="访问作者网站" /></td>';
		sdiv += '<td width="28" height="26" align="center"><input id="ib_Srch" type="image" src="' + PATH + 'icon/srch.gif" onclick="return iso.mbo()" style="border:0px" alt="引擎" title="选择搜索引擎" /></td>';
		sdiv += '<td width="62" height="26" align="left"><label id="lb_Name">Amon搜索</label></td>';
		sdiv += '<td width="44" height="26" align="center"><input id="ib_Butn" type="image" src="' + PATH + 'icon/butn.gif" onclick="return iso.dSrch()" style="border:0px" alt="搜索" title="搜索当前文字" /></td>';
		sdiv += '</tr>';
		sdiv += '</table>';
		sdiv += '</div>';
		
		/*菜单*/
		sdiv += '<div id="' + NAME + '_MENU" style="display:none;overflow: hidden;border-width: 2px;border-style:solid;border-color:#51789b;position: absolute;z-index:999;float: left;top: 1px;left: 1px;height: 1px;width: 1px;background-color: #999999;" onmouseover="iso.mdo()" onmouseout="iso.mdx()"></div>';

		return sdiv;
	}

	/**
	 * 设置Cookie信息，保存用户设置的搜索引擎信息
	 */
	THIS.C = function(i)
	{
		_sc(NAME, i, 30);
		mDiv.style.display = 'none';
		return false;
	};
	
	///////////////////////////////////////////////////////////////////////////////////////////////
	// Cookie
	///////////////////////////////////////////////////////////////////////////////////////////////
	/**
	 * 设置读取Cookie
	 * n - name Cookie存取名称
	 */
	function _gc(n)
	{
		var s = $D().cookie.indexOf(n + '=');
		if ((!s) && (n != $D().cookie.substring(0, n.length)))
		{
			return THIS.sedi;
		}
		if (s < 0)
		{
			return THIS.sedi;
		}
		var l = s + n.length + 1;
		var e = $D().cookie.indexOf(';', l);
		if(e < 0)
		{
			e = $D().cookie.length;
		}
		return unescape($D().cookie.substring(l, e));
	}
	/**
	 * 设置Cookie
	 * n - name Cookie存取名称
	 * v - value Cookie数据
	 * x - expires Cookie过期时间
	 * p - path
	 * d - domain
	 * s - secure
	 */
	function _sc(n, v, x, p, d, s)
	{
		var td = new Date();
		td.setTime(td.getTime());
		if(x)
		{
			x = x * 86400000;/*1000 * 60 * 60 * 24;*/
		}
	
		var ed = new Date(td.getTime() + (x));
		$D().cookie = n + '=' + escape(v) + ((x) ? ';expires=' + ed.toGMTString() : '') + ((p) ? ';path=' + p : '') + ((d) ? ';domain=' + d : '') + ((s) ? ';secure' : '');
	}
	
	/**
	 * 删除Cookie
	 * n - name Cookie存取名称
	 * p - path
	 * d - domain
	 */
	function _dc(n, p, d)
	{
		if(_gc(n))
		{
			$D().cookie = n + '=' + ((p) ? ';path=' + p : '') + ((d) ? ';domain=' + d : '') + ';expires=Thu, 01-Jan-1970 00:00:01 GMT';
		}
	}

	/**
	 * 获取文档中document对象的引用。
	 */
	function $D()
	{
		return document;
	}
	/**
	 * 获取文档中window对象的引用。
	 */
	function $W()
	{
		return window;
	}
	function $X(obj)
	{
		return $D().getElementById(obj);
	}
	THIS.init();
}

if(!iso) var iso = new iSrchObj();