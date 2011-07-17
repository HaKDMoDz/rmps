// JScript 文件
function checkNull()
{
    var obj=$E('tf_P3010306');
    var val=obj.value;
    if(val==null||val==''||val.trim()=='')
    {
        alert('请输入数值签名！');
        obj.focus();
        return false;
    }
    return true;
}