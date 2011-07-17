// JScript 文件
//当前光标偏移位置
var _p;
//光标之前第一个等号偏移位置
var _s;
//光标之后第一个等号偏移位置
var _e;
//TextArea对象句柄
var _t;
//Hidden对象句柄
var _d;
//Mozilla FireFox标记
var _f;
//Microsoft Internet Explorer标记
var _m;

function I()
{
    _t = $E('ta_MathExps');
    _d = $E('hd_MathExps');
    _f = (typeof(_t.selectionStart) == 'number');
    _m = (typeof($D().selection) == 'object');

    _p = _t.value.length;
    _s = _p;
    _e = _p;
    S(_s, _e);
}

//获取光标位置
function P()
{
    if(_f)
    {
        _p = _t.selectionStart;
    }
    else if(_m)
    {
        var r = _t.createTextRange();
        r.moveToPoint(event.x, event.y);
        r.moveStart("character", -_t.value.length);
        _p = r.text.replace(new RegExp('[\\n]','g'), '').length;
    }
}

//键盘事件处理
function K(evt)
{
    if (!evt)
    {
        evt = window.event;
    }
    if((evt.keyCode || evt.which) != 61)
    {
        return evt.keyCode;
    }
    M();
    $E('bt_S6').click();
}

//获取选中行文本
function M()
{
    if(_p < 0)
    {
        return;
    }

    var v = _t.value;
    _e = v.indexOf('\n=', _p);
    _s = v.lastIndexOf('=', _p);
    if(_e < 0)
    {
        _e = v.length;
    }
    _d.value = v.substring(_s + 1, _e);
}

//设置选中状态
function S(s, e)
{
    if(_f)
    {
        _t.focus();
        _t.selectionStart = s;
        _t.selectionEnd = e;
        return;
    }

    if(_m)
    {
        var r = _t.createTextRange();
        r.moveEnd("character", -_t.value.length);
        r.moveStart("character", -_t.value.length);
        r.collapse(true);
        r.moveEnd("character", e);
        r.moveStart("character", s);
        r.select();
        return;
    }
}

//追加文字
function A(t, b)
{
    var v = _t.value;
    var p = _p;
    if(_m)
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
    _t.value = v.substring(0, p) + t + v.substring(p);
    _p += t.length;
    _p += b;
    S(_p, _p);
}

function C()
{
    _t.value = '';
    _d.value = '';
}

function D()
{
    var v = _t.value;
    if(v == null || v == '')
    {
        return;
    }

    if(_s == _e)
    {
        _s = _p - 1;
    }
}

var r;
//文字查询
function Q(w)
{
    if(w == '')
    {
        return;
    }
    if(r == null)
    {
        r = _t.createTextRange();
    }

    var s = 0;
    if(_m)
    {
        s = $D().selection.createRange().text.length;
    }
    r.moveEnd("character", _t.value.length);
    r.moveStart("character", s);
    if(r.findText(w))
    {
        r.select();
    }
    if(r.text != w)
    {
        alert("已经搜索完了！");
        r = _t.createTextRange();
    }
}