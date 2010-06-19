// JScript 文件
var inited=false;
function initView()
{
    if(!inited)
    {
        iNetHelper.init('date', 'menu', 'yyyy-MM-dd', 160, 120, _PRE + 'tf_CurrDate', 'im_CurrDate');
        inited=true;
    }
}

function readArea()
{
    var obj=$E('cb_AreaList');
    if(obj.value=='')
    {
        alert('请选择收视地区！');
        obj.focus();
        return false;
    }
    
    var val=iask_iask13A1.readStation(obj.value).value.split(';');
    obj=$E('cb_StatList');
    for(var i=obj.options.length-1;i>=0;i-=1)
    {
        obj.remove(i);
    }
    obj.add(new Option('请选择',''));
    for(var i=0;i<val.length;i+=1)
    {
        if(val[i]=='')
        {
            continue;
        }
        b=val[i].split(',');
        obj.add(new Option(b[0],b[1]));
    }
    return false;
}

function readStat()
{
    var obj=$E('cb_StatList');
    if(obj.value=='')
    {
        alert('请选择收视电台！');
        obj.focus();
        return false;
    }
    
    var val=iask_iask13A1.readChannel(obj.value).value.split(';');
    obj=$E('cb_ChnlList');
    for(var i=obj.options.length-1;i>=0;i-=1)
    {
        obj.remove(i);
    }
    obj.add(new Option('请选择',''));
    for(var i=0;i<val.length;i+=1)
    {
        if(val[i]=='')
        {
            continue;
        }
        b=val[i].split(',');
        obj.add(new Option(b[0],b[1]));
    }
    return false;
}

function readChnl()
{
    $X('td_ProgList').innerHTML=iask_iask13A1.readProgram($E('cb_ChnlList').value,$E('tf_CurrDate').value).value;
}