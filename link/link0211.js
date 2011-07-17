// JScript File
function chooseNode()
{
    var max=$('MaxCnt').val();
    var mix=$('MinCnt').val();
    if(max<1||max<min)
    {
        return;
    }

    var arr=document.getElementsByTagName('INPUT');
    var cnt=0;
    var val='';
    for(var i=0;i<arr.length;i+=1)
    {
        if((arr[i].id.indexOf('KindList')==0)&&arr[i].checked)
        {
            cnt+=1;
            val+=',';
        }
    }

    if(cnt==0)
    {
        alert('请选择上级类别！');
        return false;
    }

    if(cnt<min)
    {
        alert('请至少选择 '+min+' 个类别！');
        return false;
    }
    if(cnt>max)
    {
        alert('请最多选择 '+max+' 个类别！');
        return false;
    }
    return val;
}