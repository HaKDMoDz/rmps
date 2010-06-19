// JScript 文件
function checkNull()
{
    var obj=$E('tf_P3010205');
    var val=obj.value;
    if(val==null||val==''||val.trim()=='')
    {
        alert('请输入软件名称！');
        obj.focus();
        return false;
    }
    return true;
}