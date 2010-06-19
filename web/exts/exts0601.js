// JScript 文件
function checkNull()
{
    var obj=$E('tf_P301F206');
    var val=obj.value;
    if(val==null||val==''||val.trim()=='')
    {
        alert('请输入平台名称！');
        obj.focus();
        return false;
    }
    return true;
}