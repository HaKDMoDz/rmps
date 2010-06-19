function pageInit()
{
    chgC0010105();
    chgC0010107();
}
function chgC0010105()
{
    $E('tf_C0010105').readOnly=!$E('ck_C0010105').checked;
}
function chgC0010107()
{
    if($E('ck_C0010107').checked)
    {
        $E('tf_C0010107').readOnly=true;
        var v=new Date();
        var y=v.getFullYear();  
        var m=v.getMonth() + 1;  
        var d=v.getDate();
        $E('tf_C0010107').value=y+'-'+(m<10?'0':'')+m+'-'+(d<10?'0':'')+d;
    }
    else
    {
        $E('tf_C0010107').readOnly=false;
    }
}

function saveData()
{
    var obj=$E('tf_C0010106');
    var val=obj.value;
    if(val=='')
    {
        alert('请输入软件名称！');
        obj.focus();
        return false;
    }
    
    obj=$E('tf_C0010104');
    val=obj.value;
    if(val=='')
    {
        alert('请输入软件代码！');
        obj.focus();
        return false;
    }
    
    obj=$E('tf_C0010105');
    val=obj.value;
    if(val=='')
    {
        alert('请输入软件版本！');
        obj.focus();
        return false;
    }
    return true;
}

$(document).ready(pageInit);