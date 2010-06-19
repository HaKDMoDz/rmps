// JScript File
function checkNull()
{
    var arr=document.getElementsByTagName('INPUT');
    var cnt=0;
    for(var i=0;i<arr.length;i+=1)
    {
        if((arr[i].id.indexOf(_PRE+'tv_P3070A04')==0)&&arr[i].checked)
        {
            cnt+=1;
        }
    }
    if(cnt==0)
    {
        alert('请选择上级类别！');
        return false;
    }
    if(cnt!=1)
    {
        alert('只能选择一个上级类别！');
        return false;
    }
    var obj=$E('tf_P3070A06');
    if(obj.value.trim()=='')
    {
        alert('请输入有效的类别名称！');
        obj.focus();
        return false;
    }
    return true;
}
var inited=false;
function checkType()
{
    var obj=$X('dv_P3070A04');
    obj.style.display=(obj.style.display==''?'none':'');
    if(!inited)
    {
        iNetHelper.blur('dv_P3070A04',true);
        inited=true;
    }
    return false;
}
function unCheck(obj)
{
    $X('dv_P3070A04').style.display='none';
    if(!obj.checked)
    {
        obj.checked=true;
        return;
    }

    var tmp=obj.id;
    var idx=tmp.indexOf('CheckBox');
    tmp='tv_P3070A04t'+tmp.substring(tmp.indexOf('tv_P3070A04')+12,idx);
    $E('tf_P3070A04').value=$E(tmp).innerHTML;

    var objs=$D().getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        tmp=objs[i];
        if(tmp.type=='checkbox'&&tmp.id.indexOf(_PRE+'tv_P3070A04')==0&&tmp.id!=obj.id)
        {
            tmp.checked=false;
        }
    }
}
function histBack()
{
    $W().location.href=$E('hd_HistBack').value;
}
function addEvent()
{
    var objs=$D().getElementsByTagName("input");
    for(var i=0;i<objs.length;i++)
    {
        var obj=objs[i];
        if(obj.type=='checkbox'&&obj.id.indexOf(_PRE+'tv_P3070A04')==0)
        {
            obj.onclick=function(){unCheck(this);};
        }
    }
}
addEvent();