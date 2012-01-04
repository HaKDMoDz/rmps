// JScript 文件
function askClean()
{
    return $W().confirm('确认要进行清理操作吗？');
}
function askRemove()
{
    return $W().confirm('确认要清除文件吗？');
}
function askChange()
{
    var extsSize = $W().prompt('请输入您要增加或减少显示的数值：', '0');
    if(extsSize==null || extsSize.trim()=='')
    {
        return false;
    }
    try
    {
        $E('hd_TempData').value = parseInt(extsSize);
        return true;
    }
    catch(exception)
    {
        return false;
    }
}
function askUpdate()
{
    return $W().confirm('确认要执行此操作吗？');
}
function askMethod()
{
    if(!$W().confirm('请选择您要进行的操作类型：\n是：读取并清理；\n否：读取不清理。'))
    {
        $E('hd_TempData').value='1';
    }
    return $W().confirm('确认要执行此操作吗？');
}
function askBackup()
{
    return $W().confirm('确认要进行数据备份吗？');
}