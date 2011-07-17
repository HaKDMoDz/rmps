// JScript 文件
function checkNull()
{
    var obj=$E('tf_P3010105');
    var val=obj.value;
    if(val==null||val==''||val.trim()=='')
    {
        alert('请输入公司名称！');
        obj.focus();
        return false;
    }
    return true;
}