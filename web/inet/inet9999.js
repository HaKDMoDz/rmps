// JScript 文件
function checkNull()
{
    var sid = $E('lb_Replace').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要替换的数据项！');
        $E('lb_Replace').focus();
        return;
    }
    return $W().confirm('确认要执行删除操作吗？此操作将不可恢复！');
}