// JScript 文件
//键盘事件处理
function ku(evt)
{
    if (!evt)
    {
        evt = window.event;
    }
	var code = evt.keyCode || evt.which;
    if(code != 61)
    {
        return code;
    }
    R();
    $E('bt_S6').click();
}
function R()
{
    var t = ito.paragraph();
    if(t == null || t.trim() == '')
    {
        return false;
    }
    if(t.charAt(0) == '=')
    {
        t = t.substring(1);
    }
    $E('hd_MathExps').value = t;
    return true;
}

var textArea = $E('ta_MathExps');
ito.init(textArea, textArea.value.length);

function addFav()
{
    return addFavorite('http://amonsoft.cn/tool/tool1306.aspx', '计算助理', '');
}

function showExps()
{
    var dv = $X('dv_MathExps');
    dv.style.top = ($D().documentElement.clientHeight - 165) / 2 + 'px';
    dv.style.left = ($D().documentElement.clientWidth - 320) / 2 + 'px';
    dv.style.display = '';
    return false;
}
function hideExps()
{
    $X('dv_MathExps').style.display = 'none';
    return false;
}
function lastStep()
{
    if(mathStep < 1)
    {
        return;
    }
    $X('tr_MathStep' + (--currStep)).style.display = 'none';
    $X('hl_NextStep').style.display = '';
    if(currStep <= 0)
    {
        $X('hl_LastStep').style.display = 'none';
    }
    return false;
}
function nextStep()
{
    if(mathStep < 1)
    {
        return;
    }
    $X('tr_MathStep' + (currStep++)).style.display = '';
    $X('hl_LastStep').style.display = '';
    if(currStep >= mathStep)
    {
        $X('hl_NextStep').style.display = 'none';
    }
    return false;
}