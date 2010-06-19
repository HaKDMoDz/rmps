// JScript 文件
function checkNull()
{
    var obj=$E('ta_P3010109');
    if(!obj)
    {
        return false;
    }
    var val=obj.value;
    if(!val)
    {
        showMesg('请输入您要删除此数据的原因！');
        obj.focus();
        return false;
    }
    return true;
}