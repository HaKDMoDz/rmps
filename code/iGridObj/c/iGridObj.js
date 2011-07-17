function iGridObj()
{
	var THIS = this;
	var NAME = 'iGridObj';
	var _DOC = document;
	
	// TR对象在鼠标进入时的背景颜色
	var troc = '#68B4FF';
	// TR对象在鼠标退出时的背景颜色
	var trec = '#FFFFFF';
	// TD对象在鼠标进入时的背景颜色
	var tdoc = '#FFCC66';
	// TD对象在鼠标退出时的背景颜色
	var tdec = '#FFFFFF';

	var grid;
	var head;
	var widh;
	var high;
	var rows;
	var cols;
	
	THIS.init = function(d, t, w, h, r, c)
	{
		THIS.grid = d;
		THIS.head = t ? t : new Array(2);
		THIS.widh = w ? w : 400;
		THIS.high = h ? h : 300;
		THIS.rows = r ? r : 5;
		THIS.cols = c ? c : 2;
	}
	
	THIS.setHead = function(t)
	{
		THIS.head = t;
	}
	
	THIS.setWidth = function(w)
	{
		THIS.widh = w;
	}
	
	THIS.setHeight = function(h)
	{
		THIS.high = h;
	}
	
	THIS.setRows = function(r)
	{
		THIS.rows = r;
	}
	
	THIS.setCols = function(c)
	{
		THIS.cols = c;
	}
	
	THIS.mouseOver = function(tr, td)
	{
		if(tr)
		{
			tr.style.backgroundColor = troc;
		}
		if(td)
		{
			td.style.backgroundColor = tdoc;
		}
	}
	
	THIS.mouseExit = function(tr, td)
	{
		if(tr)
		{
			tr.style.backgroundColor = trec;
		}
		if(td)
		{
			td.style.backgroundColor = tdec;
		}
	}
	
	function createTable()
	{
		$(o).style.width = widh + 'px';
		$(o).style.height = high + 'px';
		
		var g = '<table width="100%" border="0" cellpadding="0" cellspacing="0">';
		g += '</table>';
	}
	
	function $(o)
	{
		return typeof(o)=='string' ? _DOC.getElementById(o) : o;
	}
	
	function test()
	{
		alert(THIS.head);
		alert(THIS.widh);
		alert(THIS.high);
		alert(THIS.rows);
		alert(THIS.cols);
	}
}
var igo = new iGridObj();