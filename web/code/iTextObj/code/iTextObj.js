// JScript 文件
function iTextObj()
{
	/*类自身引用*/
	var THIS = this;
	
	/*服务器路径*/
	var NAME = 'iTextObj';
	var HOST = 'http://www.amonsoft.cn/';
	var PATH = HOST + 'code/';
	
	var _DOC = document;
	var _WND = window;

	var _ta;//TextArea对象句柄
	var _ff;//Mozilla FireFox标记
	var _ms;//Microsoft Internet Explorer标记

	/**
	 * ta: TextArea对象名称；
	 * cp: 默认光标所在位置；
	 * sp: 选择文本起始位置；
	 * ep: 选择文本结束位置；
	 */
	THIS.init = function(ta, sp, ep)
	{
		_ta = ta;

		_ff = (typeof(_ta.selectionStart) == 'number');
		_ms = (typeof(_DOC.selection) == 'object');

		if(!sp)
		{
			sp = 0;
		}
		if(!ep)
		{
			ep = sp;
		}
		THIS.select(sp, ep);

		//_ta.onkeydown = kd;
		_ta.onkeyup = ku;
		_ta.onmousedown = md;
		_ta.onmouseup = mu;
	}
	
	/**
	 * 清除现有数据
	 */
	THIS.clear = function()
	{
		_ta.value = '';
	}
	
	/**
	 * 在选择文本后面追加字符串
	 */
	THIS.append = function (txt, pos)
	{
		var v = _ta.value;
		var sp = THIS.selection();
		var p = sp[1];
		if(_ms)
		{
			var i = 0;
			while(i < p)
			{
				if (v.charAt(i++) == '\n')
				{
					p += 1;
				}
			}
		}
		_ta.value = v.substring(0, p) + txt + v.substring(p);

		p += (txt.length + pos);
		THIS.select(p, p);
	}
	
	THIS.remove = function(cast)
	{
		var v = _ta.value;
		if(v == null || v == '')
		{
			return;
		}
	
		var sp = THIS.selection();
		var s = sp[0];
		var e = sp[1];
		if(s == e)
		{
			if(cast)
			{
				s -= 1;
			}
			else
			{
				return;
			}
		}
		if(_ms)
		{
			var i = 0;
			while(i < s)
			{
				if (v.charAt(i++) == '\n')
				{
					s += 1;
				}
			}
			while(i < e)
			{
				if (v.charAt(i++) == '\n')
				{
					e += 1;
				}
			}
			if(s == e)
			{
				s -= 2;
			}
		}
		_ta.value = v.substring(0, s)  + v.substring(e);
	}
	
	/**
	 * 替换选中部分文本为目标文本
	 */
	THIS.replace = function(txt)
	{
		var v = _ta.value;
		if(v == null || v == '')
		{
			return;
		}
	
		var se = THIS.selection();
		var s = s[0];
		var e = s[1];
		/*if(_ms)
		{
			var i = 0;
			while(i < s)
			{
				if (v.charAt(i++) == '\n')
				{
					s += 1;
				}
			}
			while(i < e)
			{
				if (v.charAt(i++) == '\n')
				{
					e += 1;
				}
			}
		}*/
		_ta.value = v.substring(0, s) + txt + v.substring(e);
	}
	
	/**
	 * 设置文本框选中状态
	 */
	THIS.select = function(s, e)
	{
		if(_ff)
		{
			_ta.focus();
			_ta.selectionStart = s;
			_ta.selectionEnd = e;
			return;
		}
	
		if(_ms)
		{
			var r = _ta.createTextRange();
			r.moveEnd("character", -_ta.value.length)
			r.moveStart("character", -_ta.value.length)
			r.collapse(true);
			r.moveEnd("character", e)
			r.moveStart("character", s)
			r.select();
			return;
		}
	}
	
	/**
	 * 获取用户选择始末光标位置
	 */
	THIS.selection = function()
	{
		var ss;
		var se;
		if(_ff)
		{
			ss = _ta.selectionStart;
			se = _ta.selectionEnd;
		}
		else if(_ms)
		{
		    _ta.focus();
			var sr = _DOC.selection.createRange();
			var br = _DOC.body.createTextRange();
			br.moveToElementText(_ta);
			for (ss=0; br.compareEndPoints("StartToStart", sr) < 0; ss++)
			{
				br.moveStart('character', 1);
				if(br.text.charAt(ss) == '\n')
				{
					ss += 1;
				}
			}
			var br = document.body.createTextRange();
			br.moveToElementText(_ta);
			for (se = 0; br.compareEndPoints('StartToEnd', sr) < 0; se ++)
			{
				br.moveStart('character', 1);
				if(br.text.charAt(se) == '\n')
				{
					se += 1;
				}
			}
		}
		return [ss, se];
	}
	
	/**
	 * 获取选中行文本
	 */
	THIS.paragraph = function()
	{
	    var sp = THIS.selection();
	    if(sp[1] < 0)
        {
            return;
        }

        var v = _ta.value;
        var s = v.lastIndexOf('\n', sp[0] - 1);
        var e = v.indexOf('\n', sp[1] + 1);
        if(e < 0)
        {
            e = v.length;
        }
        return v.substring(s + 1, e);
	}
};
if(!ito) var ito = new iTextObj();