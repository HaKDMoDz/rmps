// JScript 文件
var OBJ = 'tb_MiniExps';
var ERR = '计算错误！';
var isNum = false;
var isDot = false;
var exObj = document.getElementById(OBJ);

function pNum(num)
{
    if(exObj.value == ERR)
    {
        exObj.value = '';
    }
    exObj.value += num;
    isNum = true;
}

function pDot(dot)
{
    if(exObj.value == ERR)
    {
        exObj.value = '';
    }
    if(isNum && !isDot)
    {
        exObj.value += dot;
        isDot = true;
    }
}

function pSgn(sgn)
{
    if(isDot && exObj.value.substring(exObj.value.length - 1) == '.')
    {
        exObj.value += '0';
    }
    if(isNum)
    {
        exObj.value += sgn;
    }
    isNum = false;
    isDot = false;
}

function pClr()
{
    exObj.value = '';
    isNum = false;
}

function pDel()
{
    isDot = false;
    var val = exObj.value;
    if (val.lengh < 1)
    {
        isNum = false;
        return;
    }
    val = val.substring(0, val.length - 1);
    exObj.value = val;
    if (val.length < 1)
    {
        isNum = false;
        return;
    }
    
    var len = val.length;
    var chr = val.substring(len - 1);
    isNum = (chr >= '0' && chr <= '9');
    
    while(len >= 0)
    {
        chr = val.substring(len - 1, len);
        if(chr == '+' || chr == '-' || chr == '*' || chr == '/')
        {
            break;
        }
        if(chr == '.')
        {
            isDot = true;
            break;
        }
        len -= 1;
    }
}

function pCal()
{
    try
    {
        exObj.value = eval(exObj.value);
    } catch(ex)
    {
        exObj.value = ERR;
    }
}