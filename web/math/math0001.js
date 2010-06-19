// JScript 文件
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
    if(R())$E('bt_S6').click();
}
function C()
{
    var obj=$E('ta_MathExps');
    var val=obj.value;
    if(val.trim()=='')
    {
        $X('ctl00_lb_ErrMsg').innerHTML='请输入您的运算表达式！';
        obj.focus();
        return false;
    }
    var t=val.lastIndexOf('=')+1;
    if(t==val.length)
    {
        $X('ctl00_lb_ErrMsg').innerHTML='请输入您的运算表达式！';
        obj.focus();
        return false;
    }
    t=val.substring(t).trim().replace('\r','').replace('\n','');
    if(t=='')
    {
        $X('ctl00_lb_ErrMsg').innerHTML='请输入您的运算表达式！';
        obj.focus();
        return false;
    }
    $E('hd_MathExps').value=t;
    
    var dec=$E('tf_Decimals');
    var d=dec.value;
    var reg=/^\d+$/;
    if(!reg.test(d)||d>64)
    {
        $X('ctl00_lb_ErrMsg').innerHTML='请输入一个合适的运算精度！';
        dec.focus();
        return false;
    }
    return true;
}
function R()
{
    if(C()) $E('ta_MathExps').value+='\n='+math_math0001.calc($E('hd_MathExps').value,$E('tf_Decimals').value).value;
    return false;
}
function showExps()
{
    if(C()) $X('dv_TextArea').innerHTML=math_math0001.step($E('hd_MathExps').value,$E('tf_Decimals').value).value;

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

var textArea = $E('ta_MathExps');
ito.init(textArea, textArea.value.length);