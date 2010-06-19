function saveData()
{
    var obj=$E('cb_DataItem');
    var val=obj.value;
    if(!val)
    {
        alert('请选择通讯方式！');
        obj.focus();
        return false;
    }
    
    obj=$E('');
    val=obj.value;
    if(!val)
    {
        alert('请输入通讯信息！');
        obj.focus();
        return false;
    }
    
    return true;
}
function dropData()
{
    var obj=$E('hd_IsUpdate');
    var val=obj.value;
    alert(val);
    if(val.length!=16)
    {
        return false;
    }
    return confirm('此操作将不可恢复，确认要删除此数据吗？');
}