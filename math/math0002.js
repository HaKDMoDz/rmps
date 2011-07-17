// JScript 文件
var newNo=true;
var mem=0;
var carry=10;
var hexNo="0123456789abcdef";
var angle="d";
var stack='';
var level='0';
var layer=0;

//数字键
function no(key)
{
    var o=$X('tf_Dsp');
    if(newNo)
    {
        newNo=false;
        o.value=key;
        return;
    }
    if(o.value==null||o.value=='NaN'||o.value=='0')
    {
        o.value=key;
        return;
    }
    
    o.value+=key;
}

function changeSign()
{
    var o=$X('tf_Dsp');
    if (o.value=='0')
    {
        return;
    }
    if(o.value.substr(0,1)=="-")
    {
        o.value=o.value.substr(1);
    }
    else
    {
        o.value="-"+o.value;
    }
}
 
//函数键
function fs(fun,shiftfun)
{
    newNo=true;
    if ($X('ck_Inv').checked)
    {
        $X('tf_Dsp').value=decto(funcalc(shiftfun,(todec($X('tf_Dsp').value,carry))),carry);
    }
    else
    {
        $X('tf_Dsp').value=decto(funcalc(fun,(todec($X('tf_Dsp').value,carry))),carry);
    }
    $X('ck_Inv').checked=false;
    $X('ck_Hyp').checked=false;
    inputshift();
}
 
function tg(trig,arctrig,hyp,archyp)
{
    if ($X('ck_Hyp').checked)
    {
        inputfunction(hyp,archyp);
    }
    else
    {
        inputfunction(trig,arctrig);
    }
}
 
 
//运算符
function op(join,newlevel)
{
    newNo=true;
    var temp=stack.substr(stack.lastIndexOf("(")+1)+$X('tf_Dsp').value;
    while (newlevel!=0 && (newlevel<=(level.charAt(level.length-1))))
    {
        temp=parse(temp);
        level=level.slice(0,-1);
    }
    if (temp.match(/^(.*\d[\+\-\*\/\%\^\&\|x])?([+-]?[0-9a-f\.]+)$/))
    $X('tf_Dsp').value=RegExp.$2;
    stack=stack.substr(0,stack.lastIndexOf("(")+1)+temp+join;
    $X('tf_Opr').value=" "+join+" ";
    level=level+newlevel;
}
 
//括号
function addbracket()
{
    newNo=true;
    $X('tf_Dsp').value=0;
    stack=stack+'(';
    $X('tf_Opr').value='';
    level=level+0;
     
    layer+=1;
    $X('tf_Bkt').value="(="+layer;
}
 
function disbracket()
{
    newNo=true;
    var temp=stack.substr(stack.lastIndexOf("(")+1)+$X('tf_Dsp').value;
    while ((level.charAt(level.length-1))>0)
    {
        temp=parse(temp);
        level=level.slice(0,-1);
    }
     
    $X('tf_Dsp').value=temp;
    stack=stack.substr(0,stack.lastIndexOf("("));
    $X('tf_Opr').value="   ";
    level=level.slice(0,-1);
     
    layer-=1;
    if (layer>0)
    {
        $X('tf_Bkt').value="(="+layer;
    }
    else
    {
        $X('tf_Bkt').value='';
    }
}
 
//等号
function result()
{
    newNo=true;
    while (layer>0)
    {
        disbracket();
    }
    var temp=stack+$X('tf_Dsp').value;
    while ((level.charAt(level.length-1))>0)
    {
        temp=parse(temp);
        level=level.slice(0,-1);
    }
     
    $X('tf_Dsp').value=temp;
    $X('tf_Bkt').value='';
    $X('tf_Opr').value='';
    stack='';
    level='0';
}

/**
 * 退格
 */
function bs()
{
    if (!newNo)
    {
        if($X('tf_Dsp').value.length>1)
        {
            $X('tf_Dsp').value=$X('tf_Dsp').value.substring(0,$X('tf_Dsp').value.length - 1);
        }
        else
        {
            $X('tf_Dsp').value=0;
        }
    }
}

/**
 * 清除显示
 */
function cs()
{
    $X('tf_Dsp').value='0';
}

/**
 * 清除所有
 */
function ca()
{
    $X('tf_Dsp').value='0';
    newNo=true;
    stack='';
    level='0';
    layer='';
    $X('tf_Opr').value='';
    $X('tf_Bkt').value='';
}

//转换键
function inputChangCarry(newcarry)
{
    newNo=true;
    $X('tf_Dsp').value=(decto(todec($X('tf_Dsp').value,carry),newcarry));
    carry=newcarry;

    $X('bt_Sin').disabled=(carry!=10);
    $X('bt_Cos').disabled=(carry!=10);
    $X('bt_Tan').disabled=(carry!=10);
    $X('bt_Dms').disabled=(carry!=10);
    $X('bt_P').disabled=(carry!=10);
    $X('bt_E').disabled=(carry!=10);
    $X('bt_D').disabled=(carry!=10);
     
    $X('bt_2').disabled=(carry<=2);
    $X('bt_3').disabled=(carry<=2);
    $X('bt_4').disabled=(carry<=2);
    $X('bt_5').disabled=(carry<=2);
    $X('bt_6').disabled=(carry<=2);
    $X('bt_7').disabled=(carry<=2);
    $X('bt_8').disabled=(carry<=8);
    $X('bt_9').disabled=(carry<=8);
    $X('bt_a').disabled=(carry<=10);
    $X('bt_b').disabled=(carry<=10);
    $X('bt_c').disabled=(carry<=10);
    $X('bt_d').disabled=(carry<=10);
    $X('bt_e').disabled=(carry<=10);
    $X('bt_f').disabled=(carry<=10);
}
 
function inputChangAngle(angletype)
{
    newNo=true;
    angle=angletype;
    if (angle=="d")
    {
        $X('tf_Dsp').value=radiansToDegress($X('tf_Dsp').value);
    }
    else
    {
        $X('tf_Dsp').value=degressToRadians($X('tf_Dsp').value);
    }
    newNo=true;
}
 
function inputshift()
{
    if ($X('ck_Inv').checked)
    {
        $X('bt_Dms').value="deg";
        $X('bt_Lne').value="exp";
        $X('bt_Log').value="expd";
         
        if ($X('ck_Hyp').checked)
        {
            $X('bt_Sin').value="ahs";
            $X('bt_Cos').value="ahc";
            $X('bt_Tan').value="aht";
        }
        else
        {
            $X('bt_Sin').value="asin";
            $X('bt_Cos').value="acos";
            $X('bt_Tan').value="atan";
        }
         
        $X('bt_Sqr').value="x^.5";
        $X('bt_Cub').value="x^.3";
         
        $X('bt_Int').value="Flt";
    }
    else
    {
        $X('bt_Dms').value="dms";
        $X('bt_Lne').value="ln";
        $X('bt_Log').value="log";
         
        if ($X('ck_Hyp').checked)
        {
            $X('bt_Sin').value="hsin";
            $X('bt_Cos').value="hcos";
            $X('bt_Tan').value="htan";
        }
        else
        {
            $X('bt_Sin').value="sin";
            $X('bt_Cos').value="cos";
            $X('bt_Tan').value="tan";
        }
         
        $X('bt_Sqr').value="x^2";
        $X('bt_Cub').value="x^3";
         
        $X('bt_Int').value="Int";
    }
}

//存储器部分
function mc()
{
    mem=0;
    $X('tf_Mem').value='';
}
 
function mr()
{
    newNo=true;
    $X('tf_Dsp').value=decto(mem,carry);
}
 
function ms()
{
    newNo=true;
    if ($X('tf_Dsp').value!=0)
    {
        mem=todec($X('tf_Dsp').value,carry);
        $X('tf_Mem').value='M';
    }
    else
    {
        $X('tf_Mem').value='';
    }
}
 
function ma()
{
    newNo=true;
    mem=parseFloat(mem)+parseFloat(todec($X('tf_Dsp').value,carry));
    if (mem==0)
    {
        $X('tf_Mem').value='';
    }
    else
    {
        $X('tf_Mem').value='M';
    }
}
 
function mm()
{
    newNo=true;
    mem=parseFloat(mem)*parseFloat(todec($X('tf_Dsp').value,carry));
    if (mem==0)
    {
        $X('tf_Mem').value='';
    }
    else
    {
        $X('tf_Mem').value='M';
    }
}
 
//十进制转换
function todec(num,oldcarry)
{
    if (oldcarry==10||num==0)
    {
        return(num);
    }
        
    var neg=(num.charAt(0)=='-');
    if (neg) num=num.substr(1);
    var newnum=0;
    for (var index=1;index<=num.length;index++)
    {
        newnum=newnum*oldcarry+hexNo.indexOf(num.charAt(index-1));
    }
    if (neg)
    {
        newnum=-newnum;
    }
    return(newnum);
}
 
function decto(num,newcarry)
{
    var neg=(num<0);
    if (newcarry==10||num==0)
    {
        return(num);
    }
        
    num=''+Math.abs(num);
    var newnum='';
    while (num!=0)
    {
        newnum=hexNo.charAt(num%newcarry)+newnum;
        num=Math.floor(num/newcarry);
    }
    
    if (neg)
    {
        newnum="-"+newnum;
    }
    return(newnum);
}
 
//表达式解析
function parse(string)
{
    if (string.match(/^(.*\d[\+\-\*\/\%\^\&\|x\<])?([+-]?[0-9a-f\.]+)([\+\-\*\/\%\^\&\|x\<])([+-]?[0-9a-f\.]+)$/))
    {
        return(RegExp.$1+cypher(RegExp.$2,RegExp.$3,RegExp.$4));
    }
    else
    {
        return(string);
    }
}
 
//数学运算和位运算
function cypher(left,join,right)
{
    left=todec(left,carry);
    right=todec(right,carry);
    if (join=="+")
    {
        return(decto(parseFloat(left)+parseFloat(right),carry));
    }
        
    if (join=="-")
    {
        return(decto(left-right,carry));
    }
        
    if (join=="*")
    {
        return(decto(left*right,carry));
    }
        
    if (join=="/" && right!=0)
    {
        return(decto(left/right,carry));
    }

    if (join=="%")
    {
        return(decto(left%right,carry));
    }
       
    if (join=="&")
    {
        return(decto(left&right,carry));
    }
       
    if (join=="|")
    {
        return(decto(left|right,carry));
    }
       
    if (join=="^")
    {
        return(decto(Math.pow(left,right),carry));
    }
    
    if (join=="x")
    {
        return(decto(left^right,carry));
    }
    
    if (join=="<")
    {
        return(decto(left<<right,carry));
    }
    
    alert("除数不能为零！");
    return(left);
}
 
//函数计算
function funcalc(fun,num)
{
    with(Math)
    {
        if (fun=="pi")
        {
            return(PI);
        }
        
        if (fun=="e")
        {
            return(E);
        }
        
        if (fun=="abs")
        {
            return(abs(num));
        }
        
        if (fun=="ceil")
        {
            return(ceil(num));
        }
        
        if (fun=="round")
        {
            return(round(num));
        }
        
        if (fun=="floor")
        {
            return(floor(num));
        }
        
        if (fun=="deci")
        {
            return(num-floor(num));
        }
        
        if (fun=="ln" && num>0)
        {
            return(log(num));
        }
        
        if (fun=="exp")
        {
            return(exp(num));
        }
        
        if (fun=="log" && num>0)
        {
            return(log(num)*LOG10E);
        }
        
        if (fun=="expdec")
        {
            return(pow(10,num));
        }

        if (fun=="cube")
        {
            return(num*num*num);
        }
        
        if (fun=="cubt")
        {
            return(pow(num,1/3));
        }
        
        if (fun=="sqr")
        {
            return(num*num);
        }

        if (fun=="sqrt" && num>=0)
        {
            return(sqrt(num));
        }
        
        if (fun=="!")
        {
            return(factorial(num));
        }

        if (fun=="recip" && num!=0)
        {
            return(1/num);
        }
        
        if (fun=="dms")
        {
            return(dms(num));
        }
        
        if (fun=="deg")
        {
            return(deg(num));
        }
        
        if (fun=="~")
        {
            return(~num);
        }
        
        if (angle=="d")
        {
            if (fun=="sin")
            {
                return(sin(degressToRadians(num)));
            }
            if (fun=="cos")
            {
                return(cos(degressToRadians(num)));
            }
            if (fun=="tan")
            {
                return(tan(degressToRadians(num)));
            }
            if (fun=="arcsin" && abs(num)<=1)
            {
                return(radiansToDegress(asin(num)));
            }
            if (fun=="arccos" && abs(num)<=1)
            {
                return(radiansToDegress(acos(num)));
            }
            if (fun=="arctan")
            {
                return(radiansToDegress(atan(num)));
            }
        }
        else
        {
            if (fun=="sin")
            {
                return(sin(num));
            }
            if (fun=="cos")
            {
                return(cos(num));
            }
            if (fun=="tan")
            {
                return(tan(num));
            }
            if (fun=="arcsin" && abs(num)<=1)
            {
                return(asin(num));
            }   
            if (fun=="arccos" && abs(num)<=1)
            {
                return(acos(num));
            }
            if (fun=="arctan")
            {
                return(atan(num));
            }
        }
         
        if (fun=="hypsin")
        {
            return((exp(num)-exp(0-num))*0.5);
        }
        if (fun=="hypcos")
        {
            return((exp(num)+exp(-num))*0.5);
        }
        if (fun=="hyptan")
        {
            return((exp(num)-exp(-num))/(exp(num)+exp(-num)));
        }
        if (fun=="ahypsin" | fun=="hypcos" | fun=="hyptan")
        {
            alert("对不起，公式还没有查到！");
            return(num);
        }
        
        alert("超出函数定义范围！");
        return(num);
    }
}

function factorial(n)
{
    n=Math.abs(parseInt(n));
    var fac=1;
    for(;n>0;n-=1)
    {
        fac*=n;
    }
    return(fac);
}

function dms(n)
{
    var neg=(n<0);
    with(Math)
    {
        n=abs(n);
        var d=floor(n);
        var m=floor(60*(n-d));
        var s=(n-d)*60-m;
    }
    var dms=d+m/100+s*0.006;
    if (neg)
    {
        dms=-dms;
    }
    return(dms);
}

function deg(n)
{
    var neg=(n<0);
    with(Math)
    {
        n=abs(n);
        var d=floor(n);
        var m=floor((n-d)*100);
        var s=(n-d)*100-m;
    }
    var deg=d+m/60+s/36;
    if (neg)
    {
        deg=-deg;
    }
    return(deg);
}

function degressToRadians(degress)
{
    return(degress*Math.PI/180);
}

function radiansToDegress(radians)
{
    return(radians*180/Math.PI);
}